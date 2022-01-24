using BakUna.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakUna.LoginElements
{
    
    public partial class UserItemDesign : UserControl
    {
        public delegate void ItemEvent(object sender, EventArgs e, int index);
        public event ItemEvent onItemClicked;

        public int Index { get; set; }

        UserData data;

        public UserData Data => data;

        public Button Button => selectButton;

        private void ItemSelected(object sender, EventArgs e)
        {
            onItemClicked(sender, e, Index);
        }

        public UserItemDesign(UserData data)
        {
            InitializeComponent();
            this.data = data;
        }

        

        private void UserItemDesign_Load(object sender, EventArgs e)
        {
            dynamic imageToLoad = (data.is_vaccinated, data.second_dose_date) switch
            {
                (true, not null) => Properties.Resources.vac,
                (true, null) => Properties.Resources.notfullyvac,
                (false, null) => Properties.Resources.notvac,
                _ => Properties.Resources.vac
            };

            string hex = (data.is_vaccinated, data.second_dose_date) switch
            {
                (true, not null) => "#47b975",
                (true, null or "null") => "#ce8f2a",
                (false, null) => "#ed6968",
                _ => "#47b975"
            };

            colorPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
            vaccinePicture.Image = imageToLoad;
            vaccine_label.Text = data.vaccine_brand;
            first_dose_label.Text = data.first_dose_date;
            second_dose_label.Text = data.second_dose_date;
            name_label.Text = data.name;
        }
    }
}
