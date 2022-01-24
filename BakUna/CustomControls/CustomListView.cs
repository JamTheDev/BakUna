using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakUna.CustomControls
{
    [ToolboxItem(true)]
    class CustomListView : FlowLayoutPanel
    {
        List<UserControl> dataSource;

        public List<UserControl> DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

        public CustomListView()
        {
            
        }

        public void PopulateList()
        {
            if (DataSource.Count < 0 || DataSource == null) return;

            for (int i = 0; i < DataSource.Count; i++)
            {
                Controls.Add(dataSource[i]);
            }
        }


    }
}
