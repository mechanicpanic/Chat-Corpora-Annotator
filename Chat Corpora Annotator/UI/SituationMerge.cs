using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewer.UI
{
    public partial class SituationMerge : Form
    {
        public string MergeTo;
        public string MergeFrom;
        public SituationMerge(List<string> situations)
        {
            InitializeComponent();

            comboBox1.Items.AddRange(situations.ToArray());
            comboBox2.Items.AddRange(situations.ToArray());
            
        }
        public event EventHandler OkButtonClicked;
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                this.MergeTo = comboBox2.SelectedItem.ToString();
                this.MergeFrom = comboBox1.SelectedItem.ToString();
                OkButtonClicked?.Invoke(this, null);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
