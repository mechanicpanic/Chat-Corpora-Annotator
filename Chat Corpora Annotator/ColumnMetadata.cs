using System;
using System.Windows.Forms;

namespace Chat_Corpora_Annotator
{
    public partial class ColumnMetadata : Form
    {
        public string dateFieldKey;
        public string senderFieldKey;
        public event EventHandler ColumnButtonClicked;
        public ColumnMetadata()
        {
            InitializeComponent();
        }

        public void PopulateDateBox(string[] fields)
        {
            dateComboBox.Items.AddRange(fields);
        }

        public void PopulateSenderBox(string[] fields)
        {
            senderComboBox.Items.AddRange(fields);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateComboBox.SelectedItem != null && senderComboBox.SelectedItem != null)
            {
                dateFieldKey = dateComboBox.SelectedItem.ToString();
                senderFieldKey = senderComboBox.SelectedItem.ToString();
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
