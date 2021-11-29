using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BakUna.WebAPI;
using BakUna.Utilities;

namespace BakUna.MainScreenForm
{
    public partial class MainScreen : Form
    {
        WebApiController controller;
        RestJsonReciever reciever;
        int responseCode;

        public MainScreen()
        {
            InitializeComponent();
            Init();
        }

        private async void Init()
        {
            controller = WebApiController.getInstance;
            reciever = new RestJsonReciever();

            string param = "api/employeedata/employeevac/";
            List<UserData> data = reciever.Deserialize<List<UserData>>(await controller.GetData(param, out responseCode));

            VacListBox.DataSource = data;
        }


        /// <summary>
        /// This is for Drawing the items to both the VacBox and NonVacBox ListBoxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VacBoxDrawItem(object sender, DrawItemEventArgs e)
        {
            var dataItem = VacListBox.Items[e.Index] as UserData;
            var nameFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            var isVaccinatedFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
            e.Graphics.DrawString("Name: " + dataItem.name, nameFont, Brushes.Black, e.Bounds.Left + 3, e.Bounds.Top + 5);
            e.Graphics.DrawString("Is Vaccinated: " + dataItem.is_vaccinated, isVaccinatedFont, Brushes.Black, e.Bounds.Left + 3, e.Bounds.Top + 23);
        }

        private void NonVacDrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            VacListBox.DrawMode = DrawMode.OwnerDrawFixed;

            // Here we define the height of each item on your list.
            VacListBox.ItemHeight = 40;
        }

    }
}
