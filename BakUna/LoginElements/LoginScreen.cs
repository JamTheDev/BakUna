using System;
using BakUna.Utilities;
using BakUna.WebAPI;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Serialization;

namespace BakUna
{
    public partial class LoginScreen : Form
    {
        WebApiController controller;
        RestJsonReciever reciever;
        public LoginScreen()
        {
            InitializeComponent();
            //
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the recievers and controllers
            controller = WebApiController.getInstance;
            reciever = new RestJsonReciever();

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
            thread.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public async void StartAuthentication()
        {
            int responseCode = 0;
            string param = "api/auth/?user_id=" + userid.Text + "&password=" + password.Text;
            Authentication auth = reciever.Deserialize<Authentication>(await controller.GetData(param, out responseCode));
            if (responseCode != 200)
            {
                ConfirmationLabel.Text = "No internet connection!";
                return;
            }
            if (auth.LoginUser())
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    ConfirmationLabel.Text = "Success!";
                }));
            } else
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    ConfirmationLabel.Text = "Wrong password..." + responseCode;
                }));
                
            }
        }

    }

}
