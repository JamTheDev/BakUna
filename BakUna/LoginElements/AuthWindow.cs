using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using BakUna.WebAPI;
using BakUna.Utilities;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace BakUna.LoginElements
{
    public partial class AuthWindow : Form
    {
        WebApiController controller;
        string branch_city, branch_location;
        LoginScreen login;
        public AuthWindow(string branch_city, string branch_location, LoginScreen login)
        {
            this.branch_city = branch_city;
            this.branch_location = branch_location;

            this.login = login;

            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            controller = WebApiController.getInstance;
            city_branch_loc.Text = Beautify(branch_location).ToUpper();
            city_name_label.Text = Beautify(branch_city).ToUpper();
            loading_gif.Visible = false;

        }

        private string Beautify(string input)
        {
            return string.Join(" ", input.Split("_"));
        }



        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            loading_gif.Visible = true;
            Thread t = new Thread(StartTransaction);
            t.Start();
        }

        private async void StartTransaction()
        {
            string param = $"api/auth/validate?branch={branch_city}&auth_key={Encryptor.MD5Hash(password_txt.Text)}";
            Authentication auth;
            try
            {
                auth = await controller.GetHttpClient.GetFromJsonAsync<Authentication>(param);
                if (auth.authenticated)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        login.ConfirmAuthentication(branch_city, branch_location);
                        loading_gif.Visible = false;
                        Close();
                    });
                }
                else
                {
                    Invoke((MethodInvoker)delegate
                    {
                        loading_gif.Visible = false;
                    });
                }
            } catch (Exception err)
            {
                error.Text = err.Message;
            }
            
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
