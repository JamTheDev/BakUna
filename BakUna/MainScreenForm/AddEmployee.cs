using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BakUna.WebAPI;
using System.Net.Http.Json;
using System.Threading;
using BakUna.Utilities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;

namespace BakUna.MainScreenForm
{

    
    public partial class AddEmployee : Form
    {
        WebApiController controller;
        MainScreen parentScreen;

        string branch_city, branch_loc;
        public AddEmployee(string branch_city, string branch_loc, MainScreen parentScreen)
        {
            controller = WebApiController.getInstance;
            this.branch_city = branch_city;
            this.branch_loc = branch_loc;
            this.parentScreen = parentScreen;
            InitializeComponent();
            loadingGif.Visible = false;
        }

        private void OnConfirmChange(object sender, EventArgs e)
        {
            loadingGif.Visible = true;
            new Thread(StartTransaction).Start();
        }

        private async void StartTransaction()
        {
            
            UserVaccinationDetails data = new UserVaccinationDetails();
            DeclareVacStatus dataToPass = new DeclareVacStatus();
            string id = Extensions.GenerateID(8, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890");

            data.non_vaccinated = new List<UserData>();
            data.non_vaccinated.Add(new UserData());

            data.vaccinated = new List<UserData>();
            data.vaccinated.Add(new UserData());

            if (!isVaccinatedCB.Checked)
            {
                data.non_vaccinated[0].booster_shot_info = new UserDataBooster();
                data.non_vaccinated[0].name = name_tb.Text;
                data.non_vaccinated[0]._id = id;
                dataToPass.non_vaccinated = data.non_vaccinated[0];
            } else
            {
                data.vaccinated[0].booster_shot_info = new UserDataBooster();
                data.vaccinated[0].name = name_tb.Text;
                data.vaccinated[0]._id = id;
                dataToPass.vaccinated = data.vaccinated[0];
            }
            
            string endpoint = $"api/branch/create?branch_city={branch_city}&branch_location={branch_loc}";
            Debug.WriteLine(JsonConvert.SerializeObject(dataToPass));
            HttpResponseMessage response = await controller.GetHttpClient.PutAsJsonAsync(endpoint, dataToPass);
            if(response.IsSuccessStatusCode)
            {
                if (isVaccinatedCB.Checked)
                {
                   Invoke((MethodInvoker)delegate
                   {
                       MarkAsVacWindow window = new MarkAsVacWindow(branch_city, branch_loc, data.vaccinated[0], parentScreen);
                       window.Location = Location;
                       window.StartPosition = FormStartPosition.CenterScreen;
                       window.Show();
                       parentScreen.ThisWindowState = WindowOpen.MarkAsVaccinated;
                       Close();
                   });
                } else
                {
                    Invoke((MethodInvoker)delegate
                    {
                        parentScreen.Success();
                        parentScreen.ThisWindowState = WindowOpen.Nothing;
                        Close();
                    });
                }


            }

            response.Dispose();
            loadingGif.Visible = false;
        }
    }
}
