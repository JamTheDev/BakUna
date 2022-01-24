using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakUna.WebAPI;
using System.Windows.Forms;
using BakUna.Utilities;
using Newtonsoft.Json;
using System.Threading;
using System.Net.Http;
using System.Diagnostics;

namespace BakUna.MainScreenForm
{
    public partial class MarkAsVacWindow : Form
    {
        string branch_city, branch_loc;

        WebApiController controller;
        UserData data; 
        MainScreen parentScreen;
        
        public MarkAsVacWindow(string branch_city, string branch_loc, UserData data, MainScreen parentScreen)
        {
            controller = WebApiController.getInstance;
            this.data = data;
            this.parentScreen = parentScreen;
            this.branch_city = branch_city;
            this.branch_loc = branch_loc;
            InitializeComponent();

            loadingGif.Visible = false;
            userLabel.Text = $"Mark {data.name} as vaccinated.";
        }

        private void OnConfirmChanges(object sender, EventArgs e)
        {
            
            if (doseComboBox == null || vaccinator_tb.Text == string.Empty || vaccination_site_tb.Text == string.Empty || vaccineComboBox.SelectedItem == null) return;
            confirm_btn.Enabled = false;
            string doseSelected = doseComboBox.SelectedItem.ToString().ToLower();
            string selectedVaccine = vaccineComboBox.SelectedItem.ToString();
            string date = vaccinationTimePicker.Value.Date.ToShortDateString();
            if (doseSelected == "second dose" && data.first_dose_date == null || data.first_dose_date == string.Empty)
            {
                transactionConfirmationlabel.ForeColor = Color.FromArgb(253, 106, 106);
                transactionConfirmationlabel.Text = "First dose not taken, or dose not specified.";
                confirm_btn.Enabled = true;
                return;
            }
            if((data.first_dose_date == string.Empty || data.first_dose_date == null) && (data.second_dose_date == string.Empty || data.second_dose_date == null) && doseSelected == "booster")
            {
                transactionConfirmationlabel.ForeColor = Color.FromArgb(253, 106, 106);
                transactionConfirmationlabel.Text = "First and Second dose not taken.";
                confirm_btn.Enabled = true;
                return;
            }

            data.is_vaccinated = true;


            switch (doseSelected)
            {
                case not "booster":
                    data.vaccine_brand = selectedVaccine;
                    data.vaccinator = vaccinator_tb.Text;
                    data.vaccination_site = vaccination_site_tb.Text;
                    if(doseSelected == "first dose")
                        data.first_dose_date = date;
                    else
                        data.second_dose_date = date;
                    break;
                case "booster":
                    if (data.first_dose_date == null && data.second_dose_date == null)
                    {
                        transactionConfirmationlabel.ForeColor = Color.FromArgb(253, 106, 106);
                        transactionConfirmationlabel.Text = "First and second dose not taken.";
                        confirm_btn.Enabled = true;
                        return;
                    }
                    data.booster_shot_info.vaccinator = vaccinator_tb.Text;
                    data.booster_shot_info.vaccination_site = vaccination_site_tb.Text;
                    data.booster_shot_info.booster_brand = selectedVaccine;
                    break;
            }

            loadingGif.Visible = true;
            new Thread(StartTransaction).Start();
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            parentScreen.ThisWindowState = WindowOpen.Nothing;
            Close();
        }

        private async void StartTransaction()
        {
            string endpoint = $"api/branch/update/{data._id}?branch_city={branch_city}&branch_location={branch_loc}";
            string kvp = "{ \"vaccinated\":" + JsonConvert.SerializeObject(data) + " } ";

            HttpResponseMessage response = await controller.GetHttpClient.PatchAsync(endpoint, new StringContent(kvp, Encoding.UTF8, "application/json"));

            if(response.IsSuccessStatusCode)
            {
                Debug.WriteLine(response.Content.ReadAsStringAsync().Result);
                Invoke((MethodInvoker) delegate
                {
                    
                    transactionConfirmationlabel.ForeColor = Color.FromArgb(2, 154, 2);
                    transactionConfirmationlabel.Text = "Success! You may now close this window.";
                    loadingGif.Visible = false;

                    parentScreen.ThisWindowState = WindowOpen.Nothing;
                    parentScreen.Success();
                    Close();
                });
            } else
            {
                Invoke((MethodInvoker) async delegate
                {
                    Debug.WriteLine(await response.Content.ReadAsStringAsync());
                    transactionConfirmationlabel.ForeColor = Color.FromArgb(253, 106, 106);
                    transactionConfirmationlabel.Text = "Error, please try again.";
                    confirm_btn.Enabled = true;
                    loadingGif.Visible = false;
                });
            }
            
        }


    }
}
