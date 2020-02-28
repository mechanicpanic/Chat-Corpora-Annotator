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
            checkedListBox1.Items.AddRange(fields);
        }
        private void SelectColumns()
        {
            
            foreach(var item in checkedListBox1.CheckedItems)
            {
                SelectedFields.Add(item.ToString());
            }
            UncheckAllItems();
            
            
        }
        private void UncheckAllItems()
        {
            while (checkedListBox1.CheckedIndices.Count > 0)
                checkedListBox1.SetItemChecked(checkedListBox1.CheckedIndices[0], false);
            
        }
        //private void ClearSelectedFields()
        //{
        //    SelectedFields.Clear();
        //}

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
