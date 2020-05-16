using System.Collections.Generic;
using System.Windows.Forms;

namespace Viewer.CSV_Wizard
{
    public partial class HeaderStep : UserControl, IWizardItem
    {
        private bool header;
        public string StepType { get { return "Header"; } }
        public HeaderStep(string[] fields)
        {
            InitializeComponent();
            foreach (var field in fields)
            {
                listView1.Items.Add(new ListViewItem(field));
            }
            listView1.Invalidate();
        }

        public string HeaderTitle { get { return "Select the columns to be uploaded. Note: this is the first line of your file. If your file does not have a header, you can add a header under the Toggle."; } }

        public List<string> GetValues()
        {
            List<string> selectedFields = new List<string>();
           
            foreach (ListViewItem item in listView1.CheckedItems)
                {
                    selectedFields.Add(item.Text);
                }
            if(header)
            {
                
                selectedFields.Add("header");
                
            }
            else
            {
                selectedFields.Add("no header");
                foreach(ListViewItem item in listView1.Items)
                {
                    selectedFields.Add(item.Text);
                }
            }
                
                return selectedFields;
            
            
        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            if(checkBox1.Checked)
            {
                panel2.Visible = true;
                header = false;
            }
            else
            {
                panel2.Visible = false;
                header = true;
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if(richTextBox1.Lines.Length > 0)
            {
                listView1.Items.Clear();
                foreach(string line in richTextBox1.Lines)
                {
                    listView1.Items.Add(new ListViewItem(line));
                }
                listView1.Invalidate();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
