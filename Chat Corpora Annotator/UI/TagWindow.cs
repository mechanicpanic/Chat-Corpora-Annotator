using BrightIdeasSoftware;
using IndexingServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Viewer.Framework.Views;

namespace Viewer.UI
{
	public partial class TagWindow : Form, ITagView
	{

		public Dictionary<string,int> SituationIndex { get; set; }
		public List<DynamicMessage> Messages { get; set; } = new List<DynamicMessage>();
		public TagWindow()
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
		public event EventHandler LoadMore;

		private void button1_Click(object sender, EventArgs e)
		{
			TagsetClick?.Invoke(this,EventArgs.Empty);

		}

		private void button4_Click(object sender, EventArgs e)
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

		private void loadMoreButton_Click(object sender, EventArgs e)
		{
			LoadMore?.Invoke(this,EventArgs.Empty);
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
			this.Show();
		}

		public void CloseView()
		{
			this.Hide();
		}

		public void UpdateTagset(List<string> tags)
		{
			listBox1.Items.Clear();
			foreach (var tag in tags)
			{
				listBox1.Items.Add(tag);
			}
		}

		public void DisplayDocuments()
		{
			SetUpChatView();
		}
	}
}
