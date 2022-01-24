using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BakUna.WebAPI;

namespace BakUna.CustomControls
{
    class HttpForm : Form
    {
        private WebApiController controller;

        public WebApiController Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        public HttpForm()
        {
            MakeConnection();
        }

        private void MakeConnection()
        {
            if (controller.LoadApi("www.linktowebsite.com"))
                OnInternetConnected();
            else
                OnInternetFailConnection();
        }

        // method to trigger when API has been loaded
        public virtual void OnInternetConnected() { }

        // method to trigger when API has failed to load / connect
        public virtual void OnInternetFailConnection() { }
    }
}
