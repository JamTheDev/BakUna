using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BakUna.MainScreenForm
{
    public partial class ExtendedUserInForm : Form
    {
        public ExtendedUserInForm()
        {
            InitializeComponent();
            ShowInfo();
        }

        public void ShowInfo()
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
