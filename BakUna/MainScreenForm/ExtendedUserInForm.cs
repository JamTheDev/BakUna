using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BakUna.Utilities;

namespace BakUna.MainScreenForm
{
    public partial class ExtendedUserInForm : Form
    {
        private UserData data;
        public ExtendedUserInForm(UserData data)
        {
            this.data = data;
            InitializeComponent();
            ShowInfo();
        }

        public void ShowInfo()
        {
            nameLabel.Text = data.name;

            vaccineLabel.Text = data.vaccine_brand;
            firstDoseLabel.Text = data.first_dose_date;
            secondDoseLabel.Text = data.second_dose_date;

            vaccinatorFi.Text = data.vaccinator;
            vaccinationSiteFi.Text = data.vaccination_site;

            vaccinatorBD.Text = data.booster_shot_info.vaccinator;
            vaccinationSiteBD.Text = data.booster_shot_info.vaccination_site;
            vaccineBD.Text = data.booster_shot_info.booster_brand;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

    }
}
