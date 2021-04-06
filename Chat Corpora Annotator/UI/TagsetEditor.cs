using IndexEngine.Paths;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public event TagsetUpdateEventHandler DeleteTagset;

        public void DisplayProjectTagsetName(string name)
        {
            label1.Text = "Current project tagset: " + name;
        }

        public void CloseView()
        {
            this.Hide();
        }

        public void ShowView()
        {

            if (ProjectInfo.TagsetSet)
            {
                DisplayProjectTagsetName(ProjectInfo.Tagset);
                comboBox1.SelectedItem =  ProjectInfo.Tagset;
            }
            this.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var item = new ListViewItem(textBox1.Text);
            if (!String.IsNullOrEmpty(textBox1.Text) && !tagView.Items.Contains(item))
            {
                tagView.Items.Add(item);
                TagsetUpdateEventArgs args = new TagsetUpdateEventArgs();
                args.Name = comboBox1.SelectedItem.ToString();
                args.Tag = textBox1.Text;
                args.Type = 1;
                UpdateTagset?.Invoke(this, args);
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Write your tag in the box below");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            TagsetUpdateEventArgs args = new TagsetUpdateEventArgs();
            args.Name = comboBox1.SelectedItem.ToString();
            args.Type = 0;
            args.Tag = tagView.SelectedItems[0].Text;
            UpdateTagset?.Invoke(this, args);
            if (tagView.SelectedItems.Count != 0)
            {
                foreach (int index in tagView.SelectedIndices)
                {

                    tagView.Items.RemoveAt(index);
                }


                tagView.SelectedItems.Clear();

            }


        }


        private void createTagsetButton_Click(object sender, EventArgs e)
        {
            TagsetName tn = new TagsetName();
            tn.NameButtonClicked += new EventHandler(NameButtonHandler);
            tn.FormClosed += Tn_FormClosed;
            tn.Show();
            
        }

        private void Tn_FormClosed(object sender, FormClosedEventArgs e)
        {
            comboBox1.SelectedItem = (sender as TagsetName).Tagset;
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

        public void DisplayTagset(Dictionary<string,Color> tags)
        {
            tagView.Items.Clear();
            foreach (var tag in tags)
            {
                var item = new ListViewItem(tag.Key);
                item.BackColor = tag.Value;
                tagView.Items.Add(item);
               
            }
        }

        public void DisplayTagsetNames(List<string> names)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(names.ToArray());
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("This will delete all previously tagged messages from the project. Auto-saving XML output...","a", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                if (comboBox1.SelectedItem != null)
                {
                    TagsetUpdateEventArgs args = new TagsetUpdateEventArgs();
                    args.Name = comboBox1.SelectedItem.ToString();
                    SetProjectTagset?.Invoke(this, args);
                    label1.Text = "Current project tagset: " + comboBox1.SelectedItem.ToString();
                }
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

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
