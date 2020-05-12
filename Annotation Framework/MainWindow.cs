using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tagger.Framework.Main;

namespace Tagger
{
	public partial class MainWindow : Form, ITagView
	{
		public List<string> Tags { get; set; }

		public Dictionary<string,int> SituationIndex { get; set; }
		public List<DynamicMessage> Messages { get; set; }
		public MainWindow()
		{
			InitializeComponent();
			//Tags = new List<string>();
			//SituationIndex = new Dictionary<string, int>();
			//Tags.Add("Meeting");
			//Tags.Add("JobDiscussion");
			//Tags.Add("SoftwareSupport");
			//Tags.Add("CodeAssistance");
			//foreach(var tag in Tags)
			//{
			//	SituationIndex.Add(tag, 0);
			//}
		   
		}

		public event EventHandler WriteToDisk;
		public event EventHandler TagsetClick;
		public event EventHandler AddTag;
		public event EventHandler RemoveTag;
		public event EventHandler EditSituation;

		private void chatTable_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void panel3_Paint(object sender, PaintEventArgs e)
		{

		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			TagsetEditor te = new TagsetEditor();

		}

		private void button4_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void panel4_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			if(listBox1.SelectedItem!=null && chatTable.SelectedObjects != null)
			{
				var temp = "";
				foreach (var obj in chatTable.SelectedObjects)
				{
					temp = " [" + listBox1.SelectedItem + " ID " + SituationIndex[listBox1.SelectedItem.ToString()] + "]";
					Messages[Messages.IndexOf((DynamicMessage)obj)].contents["text"] += temp;

					

				}
				listView1.Items.Add(new ListViewItem(temp));
				listView1.Update();
				SituationIndex[listBox1.SelectedItem.ToString()]++;
				chatTable.UpdateObjects(Messages);
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void loadMoreButton_Click(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void MockTagger_Load(object sender, EventArgs e)
		{
			
		}

		public void SetUpChatView()
		{

			chatTable.SetObjects(this.Messages);
			List<OLVColumn> columns = new List<OLVColumn>();

			foreach (var key in Messages[0].contents.Keys)
			{
				OLVColumn cl = new OLVColumn();
				cl.AspectGetter = delegate (object x)
				{
					DynamicMessage message = (DynamicMessage)x;
					return message.contents[key];
				};
				cl.Text = key;
				cl.WordWrap = true;


				columns.Add(cl);


			}
			chatTable.AllColumns.Clear();
			chatTable.AllColumns.AddRange(columns);
			chatTable.RebuildColumns();


			FormatColumns("text");

		}



		private void FormatColumns(string TextFieldKey)
		{
			foreach (var cl in chatTable.AllColumns)
			{
				if (cl.Text != TextFieldKey)
				{
					cl.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
				}
				else
				{
					cl.FillsFreeSpace = true;
					

				}
			}
			chatTable.Refresh();

		}

		public void ShowView()
		{
			throw new NotImplementedException();
		}

		public void CloseView()
		{
			throw new NotImplementedException();
		}
	}
}
