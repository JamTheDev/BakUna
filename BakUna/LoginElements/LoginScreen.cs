using System;
using BakUna.Utilities;
using BakUna.WebAPI;
using System.Windows.Forms;
using System.Threading;
using BakUna.MainScreenForm;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Diagnostics;
using BakUna.LoginElements;
using BakUna.CustomControls;

namespace BakUna
{
    public partial class LoginScreen : Form
    {
        WebApiController controller;

        int responseCode = 0;

        Dictionary<string, Label> labels;
        Dictionary<string, ProgressBar> bars;

        BranchInfo info;

        public LoginScreen() : base()
        {
            InitializeComponent();
            labels = new Dictionary<string, Label>()
            {
                {"sumapang_matanda", sumapa_percent_label},
                {"pinagbakahan", pngbkhn_percent_label},
                {"gatbuka", gatbuka_percent_label},
                {"pio_cruzcosa", pio_percent_label},
                {"starita", starita_percent_label},
            };

            bars = new Dictionary<string, ProgressBar>()
            {
                {"sumapang_matanda", sumapa_bar},
                {"pinagbakahan", pinagbakahan_bar},
                {"gatbuka", gatbuka_bar},
                {"pio_cruzcosa", pio_bar},
                {"starita", starita_bar},
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // Create the recievers and controllers
            controller = WebApiController.getInstance;


            // Setup the web api
            if(!controller.HasLoaded)
                controller.LoadWebApi("linktowebsite.com");

            pinagbakahan_view.Click += (sender, eventargs) => { PopupAuthWindow(sender, eventargs, "pinagbakahan", "malolos"); };
            sumapa_view.Click += (sender, eventargs) => { PopupAuthWindow(sender, eventargs, "sumapang_matanda", "malolos"); };
            gatbuka_view.Click += (sender, eventargs) => { PopupAuthWindow(sender, eventargs, "gatbuka", "calumpit"); };
            pio_view.Click += (sender, eventargs) => { PopupAuthWindow(sender, eventargs, "pio_cruzcosa", "calumpit"); };
            starita_view.Click += (sender, eventargs) => { PopupAuthWindow(sender, eventargs, "starita", "guiguinto"); };

            Thread thread = new Thread(LoadElements);
            thread.Start();
        }

        private async void LoadElements()
        {
            string param = "api/branch/get?branch_city=all&branch_location=all";
            info = await controller.GetHttpClient.GetFromJsonAsync<BranchInfo>(param);

            if (info.branches != null)
            {
                foreach (string key in info.branches.Keys)
                {

                    Invoke((MethodInvoker)delegate {
                        double result = 0.0;

                        if (info.branches[key].vaccinated_count > 0 || info.branches[key].non_vaccinated > 0)
                        {
                            result = ((double)info.branches[key].vaccinated_count / (double)(info.branches[key].vaccinated_count + info.branches[key].non_vaccinated)) * 100;
                            labels[key].Text = $"{ Math.Floor(result) }% - {info.branches[key].vaccinated_count} out of {info.branches[key].vaccinated_count + info.branches[key].non_vaccinated}";
                            bars[key].Value = (int)result;
                        }
                        else
                        {
                            labels[key].Text = "No records!";
                            bars[key].Value = (int)result;
                        }

                    });
                }
            }
        }


        private void PopupAuthWindow(object sender, EventArgs e, string branch_data, string branch_loc)
        {
            AuthWindow window = new AuthWindow(branch_data, branch_loc, this);
            window.Show();
        }

        public void ConfirmAuthentication(string branch_data, string branch_loc)
        {
            MainScreen mForm = new MainScreen(branch_data, branch_loc);
            mForm.Location = Location;
            mForm.StartPosition = FormStartPosition.CenterScreen;
            mForm.Show();
            Hide();
        }


        private void ExitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sumapa_view_Click(object sender, EventArgs e)
        {

        }

        private void sumapa_percent_label_Click(object sender, EventArgs e)
        {

        }

    }

}
