using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Corpora_Annotator
{
    public partial class ColumnMetadata : Form
    {
        public string dateFieldKey;
        public event EventHandler ColumnButtonClicked;
        public ColumnMetadata()
        {
            InitializeComponent();
        }

        public void PopulateDataBox(string[] fields)
        {
            comboBox1.Items.AddRange(fields);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                dateFieldKey = comboBox1.SelectedItem.ToString();
            }
            OnColumnButtonClicked(null);
        }
        protected virtual void OnColumnButtonClicked(EventArgs e)
        {

            EventHandler eh = ColumnButtonClicked;
            eh?.Invoke(this, e);

        }
    }
}
