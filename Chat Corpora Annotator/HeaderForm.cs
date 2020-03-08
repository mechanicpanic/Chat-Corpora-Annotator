using System;
using System.Collections.Generic;
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

            selectedListBox.Items.Remove(selectedListBox.SelectedItem);
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < selectedListBox.SelectedItems.Count; i++)
            {
                selectedListBox.Items.RemoveAt(i);
            }

        }


    }

}
