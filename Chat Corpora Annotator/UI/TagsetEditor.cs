using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Viewer.Framework.MyEventArgs;
using Viewer.Framework.Views;

namespace Viewer.UI
{
    public partial class TagsetEditor : Form, ITagsetView
    {
        public TagsetEditor()
        {
            InitializeComponent();
        }


        public event TagsetUpdateEventHandler AddNewTagset;
        //public event TagsetUpdateEventHandler DeleteTagset;

        public event TagsetUpdateEventHandler LoadExistingTagset;
        public event TagsetUpdateEventHandler UpdateTagset;
        public event TagsetUpdateEventHandler SetProjectTagset;

        public void DisplayProjectTagsetName(string name)
        {
            label2.Text = name;
        }

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
            if (!String.IsNullOrEmpty(textBox1.Text) && !listView1.Items.Contains(item))
            {
                listView1.Items.Add(item);
                TagsetUpdateEventArgs args = new TagsetUpdateEventArgs();
                args.Name = comboBox1.SelectedItem.ToString();
                args.Tag = textBox1.Text;
                args.Type = 1;
                UpdateTagset?.Invoke(this, args);
            }
            else
            {
                MessageBox.Show("Write your tag in the box below");
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

                TagsetUpdateEventArgs args = new TagsetUpdateEventArgs();
                args.Name = comboBox1.SelectedItem.ToString();
                args.Type = 0;
                args.Tag = listView1.SelectedItems[0].Text;
                listView1.SelectedItems.Clear();
                UpdateTagset?.Invoke(this, args);
            }


        }


        private void createTagsetButton_Click(object sender, EventArgs e)
        {
            TagsetName tn = new TagsetName();
            tn.NameButtonClicked += new EventHandler(NameButtonHandler);
            tn.Show();

        }

        private void NameButtonHandler(object sender, EventArgs e)
        {
            TagsetName tn = sender as TagsetName;
            if (tn != null)
            {
                TagsetUpdateEventArgs args = new TagsetUpdateEventArgs();
                args.Name = tn.Tagset;
                AddNewTagset?.Invoke(this, args);

            }
            tn.Close();



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TagsetUpdateEventArgs args = new TagsetUpdateEventArgs();
            args.Name = comboBox1.SelectedItem.ToString();
            LoadExistingTagset?.Invoke(this, args);
        }

        public void DisplayTagset(List<string> tags)
        {
            listView1.Items.Clear();
            foreach (var tag in tags)
            {
                listView1.Items.Add(new ListViewItem(tag));
            }
        }

        public void DisplayTagsetNames(List<string> names)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(names.ToArray());
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                TagsetUpdateEventArgs args = new TagsetUpdateEventArgs();
                args.Name = comboBox1.SelectedItem.ToString();
                SetProjectTagset?.Invoke(this, args);
                label2.Text = comboBox1.SelectedItem.ToString();
            }

        }

        private void TagsetEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
