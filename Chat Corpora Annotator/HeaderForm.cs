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
            csvListBox.Items.AddRange(fields);
        }
        public void UpdateLabel(string filename)
        {
            label1.Text = filename + " columns:";
        }

        
        private void fieldButton_Click(object sender, EventArgs e)
        {
            foreach (var item in selectedListBox.Items)
            {
                SelectedFields.Add(item.ToString());
            }
            OnFieldButtonClicked(null);
            
        }

        protected virtual void OnFieldButtonClicked(EventArgs e)
        {
            
            EventHandler eh = FieldButtonClicked;
            eh?.Invoke(this, e);

        }

        private void HeaderForm_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            foreach (var item in csvListBox.SelectedItems)
            {
                if (!selectedListBox.Items.Contains(item))
                    selectedListBox.Items.Add(csvListBox.SelectedItem);
                else
                {
                    MessageBox.Show("Column " + item.ToString() + " is already added");
                }
            }
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < selectedListBox.SelectedItems.Count; i++)
            {
                selectedListBox.Items.RemoveAt(i);
            }
        }

        

        //the first selection feature
        //private void SelectColumns()
        //{

        //    foreach(var item in checkedListBox1.CheckedItems)
        //    {
        //        SelectedFields.Add(item.ToString());
        //    }
        //    UncheckAllItems();


    }
    //private void UncheckAllItems()
    //{
    //    while (checkedListBox1.CheckedIndices.Count > 0)
    //        checkedListBox1.SetItemChecked(checkedListBox1.CheckedIndices[0], false);

    //}
    //private void ClearSelectedFields()
    //{
    //    SelectedFields.Clear();
    //}




}
