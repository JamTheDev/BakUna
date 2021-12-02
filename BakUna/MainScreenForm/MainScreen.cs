using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BakUna.WebAPI;
using BakUna.Utilities;
using System.Drawing.Text;
using System.Diagnostics;

namespace BakUna.MainScreenForm
{
    public partial class MainScreen : Form
    {
        List<UserData> data;

        WebApiController controller;
        RestJsonReciever reciever;

        int responseCode;
        bool hasInteracted = false;

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
            data = reciever.Deserialize<List<UserData>>(await controller.GetData(param, out responseCode));

            VacListBox.DataSource = data;
        }


        /// <summary>
        /// This is for Drawing the items to both the VacBox and NonVacBox ListBoxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VacBoxDrawItem(object sender, DrawItemEventArgs e)
        {
            if(!hasInteracted)
                hasInteracted = true;

            Brush roomsBrush;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds,
                    e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, SystemColors.Control);

                roomsBrush = Brushes.Black;
            }
            else
            {
                roomsBrush = Brushes.Gray;
            }

            var linePen = new Pen(SystemBrushes.Control);
            var lineStartPoint = new Point(e.Bounds.Left, e.Bounds.Height + e.Bounds.Top);
            var lineEndPoint = new Point(e.Bounds.Width, e.Bounds.Height + e.Bounds.Top);

            e.Graphics.DrawLine(linePen, lineStartPoint, lineEndPoint);
            e.DrawBackground();

            var dataItem = VacListBox.Items[e.Index] as UserData;
            var nameFont = new Font("Segoe UI", 10, FontStyle.Bold);
            var isVaccinatedFont = new Font("Segoe UI", 8, FontStyle.Regular);

            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.DrawString("Name: " + dataItem.name, nameFont, Brushes.Black, e.Bounds.Left + 3, e.Bounds.Top + 5);
            if (!dataItem.second_dose_date.StartsWith("null"))
            {
                e.Graphics.DrawString("Is Vaccinated: " + dataItem.is_vaccinated + "\tSecond Dose: " + dataItem.second_dose_date, isVaccinatedFont, Brushes.Black, e.Bounds.Left + 3, e.Bounds.Top + 23);
            } else
            {
                e.Graphics.DrawString("Is Vaccinated: " + dataItem.is_vaccinated + "\tFirst Dose: " + dataItem.first_dose_date, isVaccinatedFont, roomsBrush, e.Bounds.Left + 3, e.Bounds.Top + 23);
            }
            
            
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

        private void VacBoxItemClicked(object sender, EventArgs e)
        {
            if (VacListBox.SelectedIndex < 0 || !hasInteracted)
                return;
            new ExtendedUserInForm(data[VacListBox.SelectedIndex]).Show();
        }

        private void OnApplicationClose(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
