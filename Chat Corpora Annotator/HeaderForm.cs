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
    public partial class HeaderForm : Form
    {
        public event EventHandler FieldButtonClicked;
        public List<string> SelectedFields = new List<string>();
        public HeaderForm()
        {
            InitializeComponent();
        }
        public void ShowFields(string[] fields)
        {
            listBox1.Items.AddRange(fields);
        }
        private void SelectColumns()
        {
            
            foreach(var item in listBox1.SelectedItems)
            {
                SelectedFields.Add(item.ToString());
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectColumns();
            OnFieldButtonClicked(null);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual void OnFieldButtonClicked(EventArgs e)
        {
            EventHandler eh = FieldButtonClicked;
            eh?.Invoke(this, e);
        }

    }

}
