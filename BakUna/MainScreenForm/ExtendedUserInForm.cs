using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BakUna.Utilities;
using BakUna.WebAPI;
using Newtonsoft.Json;

namespace BakUna.MainScreenForm
{

    public partial class ExtendedUserInForm : Form
    {
        private UserData data;
        string branch_city, branch_loc;

        MainScreen parentForm;
        WebApiController controller;

        public ExtendedUserInForm(string branch_city, string branch_loc, UserData data, MainScreen parentForm)
        {
            this.data = data;
            this.parentForm = parentForm;

            this.branch_city = branch_city;
            this.branch_loc = branch_loc;

            controller = WebApiController.getInstance;
            InitializeComponent();

            loadingGif.Visible = false;
            ShowInfo();
        }

        public void ShowInfo()
        {
            name.Text = data.name;

            vaccine_tb.Text = data.vaccine_brand;
            first_dose_tb.Text = data.first_dose_date;
            second_dose_tb.Text = data.second_dose_date;

            vaccinator_tb.Text = data.vaccinator;
            vaccination_site_tb.Text = data.vaccination_site;

            vaccinator_booster_tb.Text = data.booster_shot_info.vaccinator;
            vaccination_site_booster_tb.Text = data.booster_shot_info.vaccination_site;
            vaccine_booster_tb.Text = data.booster_shot_info.booster_brand;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            parentForm.ThisWindowState = WindowOpen.Nothing;
            Close();
        }

        private void SaveAndClose(object sender, EventArgs e)
        {
            data.name = name.Text;
            data.vaccine_brand = vaccine_tb.Text;
            data.first_dose_date = first_dose_tb.Text;
            data.second_dose_date = second_dose_tb.Text;

            data.vaccination_site = vaccination_site_tb.Text;
            data.vaccinator = vaccinator_tb.Text;

            data.booster_shot_info.vaccination_site = vaccination_site_booster_tb.Text;
            data.booster_shot_info.booster_brand = vaccine_booster_tb.Text;
            data.booster_shot_info.vaccinator = vaccinator_booster_tb.Text;
            loadingGif.Visible = true;
            new Thread(StartTransaction).Start();
        }

        private async void StartTransaction()
        {
            string endpoint = $"api/branch/update/{data._id}?branch_city={branch_city}&branch_location={branch_loc}";
            string kvp = "{ \"vaccinated\":" + JsonConvert.SerializeObject(data) + " } ";

            HttpResponseMessage response = await controller.GetHttpClient.PatchAsync(endpoint, new StringContent(kvp, Encoding.UTF8, "application/json"));
            if(response.IsSuccessStatusCode)
            {
               Invoke((MethodInvoker)delegate
               {
                   loadingGif.Visible = false;
                   parentForm.ThisWindowState = WindowOpen.Nothing;
                   parentForm.Success();
                   Close();
               });
            } else
            {
               Invoke((MethodInvoker)delegate
               {
                   loadingGif.Visible = false;
                   ErrorDisplayLabel.ForeColor = Color.FromArgb(253, 106, 106);
                   ErrorDisplayLabel.Text = "Error! Please try again later.";
               });
                
            }
        }
    }
}
