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

        public event EventHandler SaveEditedTagset;

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
            var item = new ListViewItem(textBox1.Text);
            if (String.IsNullOrEmpty(textBox1.Text) && !listView1.Items.Contains(item))
            {
                listView1.Items.Add(item);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                foreach (int index in listView1.SelectedIndices)
                {

                    listView1.Items.RemoveAt(index);
                }
                listView1.SelectedItems.Clear();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0)
            {
                foreach (var item in listView1.Items)
                {
                    CurrentTags.Add(item.ToString());
                }
            }
            SaveEditedTagset?.Invoke(this, EventArgs.Empty);
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
            AddNewTagset?.Invoke(this, EventArgs.Empty);
            
        }

        public void DisplayTagset()
        {
            throw new NotImplementedException();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
