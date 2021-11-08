using System;
using BakUna.Utilities;
using BakUna.WebAPI;
using System.Windows.Forms;
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

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Create the recievers and controllers
            controller = WebApiController.getInstance;
            reciever = new RestJsonReciever();

            // Setup the web api
            if (!controller.HasLoaded)
                controller.LoadWebApi("https://BakUnaAPI.jamemmanuelarev.repl.co");

            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string param = "api/users/?user_id=" + userid.Text;
            Credentials creds = reciever.Deserialize<Credentials>(await controller.GetData(param));
            if (password.Text.Equals(creds.password))
            {
                userid.Text = "good pasword!";
            }
        }
    }
}
