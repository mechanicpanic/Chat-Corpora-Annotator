using java.awt;
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

		public event TagsetUpdateEventHandler SaveTagset;
		public event TagsetUpdateEventHandler AddNewTagset;
		public event TagsetUpdateEventHandler DeleteTagset;
		public event TagsetUpdateEventHandler SaveEditedTagset;
		public event TagsetUpdateEventHandler LoadExistingTagset;
        public event TagsetUpdateEventHandler UpdateTagset;

        public string TagsetName { get; set; }
		public List<string> SelectedTagset { get; set; }

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
				var args = new TagsetUpdateEventArgs();
				args.Tags = new List<string>();
				foreach (ListViewItem item in listView1.Items)
				{
					args.Tags.Add(item.Text);
				}
				args.Name = this.TagsetName;
				SaveEditedTagset?.Invoke(this, args);

			}
			else
			{
				MessageBox.Show("Can't save an empty tagset");
			}
			
		}

		private void button4_Click(object sender, EventArgs e)
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
				this.TagsetName = tn.name;
				
			}
			tn.Close();
			//AddNewTagset?.Invoke(this,)
			
			
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

			var result = MessageBox.Show("Save current tagset?","save", MessageBoxButtons.YesNoCancel);
			if (result == DialogResult.Yes) {
				var temp = new TagsetUpdateEventArgs();
				temp.Name = TagsetName;
				temp.Tags = this.CurrentTags;
				SaveEditedTagset?.Invoke(this, temp);
				var args = new TagsetUpdateEventArgs();
				args.Name = comboBox1.SelectedItem.ToString();
				LoadExistingTagset?.Invoke(this, args);
			}
			if (result == DialogResult.No)
			{
				var args = new TagsetUpdateEventArgs();
				args.Name = comboBox1.SelectedItem.ToString();
				LoadExistingTagset?.Invoke(this, args);
			}
			if (result == DialogResult.Cancel) { }
		}

		public void DisplayTagset(List<string> tags)
		{
			listView1.Items.Clear();
			foreach(var tag in tags)
			{
				listView1.Items.Add(tag);
			}
		}

		public void DisplayTagsetNames(List<string> names)
		{
			comboBox1.Items.AddRange(names.ToArray());
		}
	}
}
