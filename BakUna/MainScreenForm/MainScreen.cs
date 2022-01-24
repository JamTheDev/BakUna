using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using BakUna.WebAPI;
using BakUna.Utilities;
using System.Drawing.Text;
using System.Net.Http.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using BakUna.MainScreenForm;
using BakUna.LoginElements;
using System.IO;
using Newtonsoft.Json;

namespace BakUna.MainScreenForm
{

    public enum WindowOpen
    {
        AddEmployee, ViewDetails, MarkAsVaccinated, Nothing
    }


    public partial class MainScreen : Form
    {
        string filter = string.Empty;
        UserVaccinationDetails data;
        WebApiController controller;
        UserItemDesign itemSelected = null;

        string branch_city, branch_location;
        string previousItemSelected = string.Empty;

        WindowOpen windowOpen = WindowOpen.Nothing;

        // getters and setters

        public WindowOpen ThisWindowState
        {
            get { return windowOpen; }
            set { windowOpen = value; }
        }

        public MainScreen(string branch_location, string branch_city)
        {
            InitializeComponent();

            controller = WebApiController.getInstance;

            this.branch_city = branch_city;
            this.branch_location = branch_location;

            branch_name.Text = branch_location;

            
            PopulateList();
        }

        private async Task RefreshData(string status)
        {

            string param = $"api/branch/get?branch_city={branch_city}&branch_location={branch_location}&status={status}";
            data = await controller.GetHttpClient.GetFromJsonAsync<UserVaccinationDetails>(param);
        }

        private async void PopulateList()
        {
            await RefreshData("all");

            progressBar.Value = 0;
            total_employees.Text = "0";
            vac_count_label.Text = "0";
            non_vac_count_label.Text = "0";

            List<UserData> dataMerged = filter switch { 
                "vaccinated" => data.vaccinated,
                "non_vaccinated" => data.non_vaccinated,
                "allrb" => Extensions.Join(data.vaccinated, data.non_vaccinated),
                _ => Extensions.Join(data.vaccinated, data.non_vaccinated)
            };

            if(panelList.Controls.Count > 0)
            {
                List<UserControl> listControls = panelList.Controls.Cast<UserControl>().ToList();
                foreach (UserItemDesign item in listControls)
                {
                    panelList.Controls.Remove(item);
                    item.Dispose();
                }
            }

            for (int i = 0; i < dataMerged.Count; i++)
            {
                if (dataMerged[i]._id == null || dataMerged[i]._id == "null") continue;
                UserItemDesign design = new UserItemDesign(dataMerged[i]);
                design.Index = i;
                design.Name = "item" + i;
                design.onItemClicked += OnItemSelected;
                panelList.Controls.Add(design);
            }
            decimal percentage = 0;
            if (data.vaccinated.Count + data.non_vaccinated.Count > 0)
            {
                percentage = ((decimal)data.vaccinated.Count / ((decimal)data.vaccinated.Count + data.non_vaccinated.Count)) * 100;
            }

            progressBar.Value = (int)Math.Round(percentage);
            total_employees.Text = data.vaccinated.Count + data.non_vaccinated.Count + "";
            vac_count_label.Text = data.vaccinated.Count.ToString();
            non_vac_count_label.Text = data.non_vaccinated.Count.ToString();
        }

        public void Success()
        {
            PopulateList();
        }

        private void OnItemSelected(object sender, EventArgs e, int index)
        {
            var button = sender as Button;
            

            if (previousItemSelected.Equals(string.Empty))
            {
                previousItemSelected = "item" + index;
            } else
            {
                if(previousItemSelected != "item" + index)
                {
                    UserItemDesign design = (UserItemDesign)panelList.Controls[previousItemSelected];
                    design.Button.Text = "SELECT";
                    previousItemSelected = "item" + index;
                }
            }

            button.Text = "SELECTED";

            itemSelected = panelList.Controls["item" + index] as UserItemDesign;

        }

        private void ViewDetailButton(object sender, EventArgs e)
        {
            if(itemSelected != null && windowOpen == WindowOpen.Nothing)
            {
                ExtendedUserInForm mForm = new ExtendedUserInForm(branch_city, branch_location, itemSelected.Data, this);
                mForm.Location = Location;
                mForm.StartPosition = FormStartPosition.CenterScreen;
                mForm.Show();
                windowOpen = WindowOpen.ViewDetails;
            }
        }

        private void MarkAsVaccinated(object sender, EventArgs e)
        {
            if (itemSelected != null && windowOpen == WindowOpen.Nothing)
            {
                MarkAsVacWindow mForm = new MarkAsVacWindow(branch_city, branch_location, itemSelected.Data, this);
                mForm.Location = Location;
                mForm.StartPosition = FormStartPosition.CenterScreen;
                mForm.Show();
                windowOpen = WindowOpen.MarkAsVaccinated;
            }
        }

        private void AddUser(object sender, EventArgs e)
        {
            if (windowOpen == WindowOpen.Nothing)
            {
                AddEmployee mForm = new AddEmployee(branch_city, branch_location, this);
                mForm.Location = Location;
                mForm.StartPosition = FormStartPosition.CenterScreen;
                mForm.Show();
                windowOpen = WindowOpen.AddEmployee;
            }
        }

        private void OnCheckedChange(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if(radio.Checked)
            {
                filter = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name.ToLower();
                
                PopulateList();
            }
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            LoginScreen mForm = new LoginScreen();
            mForm.Location = Location;
            mForm.StartPosition = FormStartPosition.CenterScreen;
            mForm.Show();
            Close();
        }
    }
}
