using System;
using BakUna.Utilities;
using BakUna.WebAPI;
using System.Windows.Forms;
using System.Threading;
using BakUna.MainScreenForm;

namespace BakUna
{
    public partial class LoginScreen : Form
    {
        WebApiController controller;
        RestJsonReciever reciever;
        public LoginScreen()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loading.Hide();
            // Create the recievers and controllers
            controller = WebApiController.getInstance;
            reciever = new RestJsonReciever();

            LoginButton.FlatAppearance.BorderSize = 0;

            // Setup the web api
            if (!controller.HasLoaded)
                controller.LoadWebApi("https://BakUnaAPI.jamemmanuelarev.repl.co");

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!controller.HasLoaded)
            {
                ConfirmationLabel.Text = "No internet connection, or database is not working!";
                return;
            }

            ConfirmationLabel.Text = "Authenticating. . .";
            Thread thread = new Thread(StartAuthentication);
            loading.Show();
            thread.Start();
        }

        public async void StartAuthentication()
        {
            int responseCode = 0;
            string param = "api/auth/?auth_key=" + Encryptor.MD5Hash(userid.Text + password.Text);
            Authentication auth = reciever.Deserialize<Authentication>(await controller.GetData(param, out responseCode));
            

            if (responseCode != 200)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    ConfirmationLabel.Text = "No internet connection!";
                    loading.Hide();
                }));
                return;
            }

            if (auth.LoginUser())
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    ConfirmationLabel.Text = "Success!";
                    loading.Hide();
                    NavigateToMainMenu();
                }));
            } else
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    ConfirmationLabel.Text = "Wrong password..." + responseCode;
                    loading.Hide();
                }));
                
            }

            
        }

        private void NavigateToMainMenu()
        {
            Hide();
            new MainScreen().Show();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
