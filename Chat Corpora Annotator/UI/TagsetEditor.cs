using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Viewer.Framework.Views;

namespace Viewer.UI
{
    public partial class TagsetEditor : Form, ITagsetView
    {
        public TagsetEditor()
        {
            InitializeComponent();
        }

        public List<string> CurrentTags { get; set; } = new List<string>();

        public event EventHandler SaveTagset;
        public event EventHandler AddNewTagset;
        public event EventHandler DeleteTagset;

        public string TagsetName { get; set; }
        public void CloseView()
        {
            this.Hide();
        }

        public void ShowView()
        {
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) && !listBox1.Items.Contains(textBox1.Text))
            {
                listBox1.Items.Add(textBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                foreach (int index in listBox1.SelectedIndices)
                {

                    listBox1.Items.RemoveAt(index);
                }
                listBox1.SelectedItems.Clear();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                foreach (var item in listBox1.Items)
                {
                    CurrentTags.Add(item.ToString());
                }
            }
            SaveTagset?.Invoke(this, EventArgs.Empty);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TagsetName tn = new TagsetName();
            tn.Show();
            tn.NameButtonClicked += new EventHandler(NameButtonHandler);
            tn.Show();
            
        }

        private void NameButtonHandler(object sender, EventArgs e)
        {
            TagsetName tn = sender as TagsetName;
            if (tn != null)
            {
                this.TagsetName = tn.name;
            }
            tn.Close();
            
        }

        public void DisplayTagset()
        {
            throw new NotImplementedException();
        }
    }
}
