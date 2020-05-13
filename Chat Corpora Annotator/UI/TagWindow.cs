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

		public Dictionary<List<string>,int> SituationIndex { get; set; }
		public List<DynamicMessage> Messages { get; set; } = new List<DynamicMessage>();
		public List<string> CurrentSituation { get; set; } = new List<string>();

		private Dictionary<string, int> TagIndex { get; set;} = new Dictionary<string, int>();
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
			WriteToDisk?.Invoke(this,EventArgs.Empty);
		}

		private void button2_Click(object sender, EventArgs e)
		{

			if (listBox1.SelectedItem != null && chatTable.SelectedObjects != null)
			{
				CurrentSituation.Clear();
				foreach (var VARIABLE in chatTable.SelectedObjects)
				{
					DynamicMessage msg = (DynamicMessage) chatTable.SelectedObject;
					CurrentSituation.Add(msg.Id);
				}
				
				AddTag?.Invoke(this,EventArgs.Empty);
			}
				var temp = "";
				foreach (var obj in chatTable.SelectedObjects)
				{
					temp = " [" + listBox1.SelectedItem + " ID " + TagIndex[listBox1.SelectedItem.ToString()] + "]";
					MessageContainer.Messages[MessageContainer.Messages.IndexOf((DynamicMessage)obj)].contents["text"] += temp;

				}
			listView1.Items.Add(new ListViewItem(temp));
			listView1.Update();
			TagIndex[listBox1.SelectedItem.ToString()]++;
			chatTable.UpdateObjects(MessageContainer.Messages);
		}
	

		private void loadMoreButton_Click(object sender, EventArgs e)
		{
			LoadMore?.Invoke(this,EventArgs.Empty);
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}
		public void SetUpChatView()
		{

			chatTable.SetObjects(MessageContainer.Messages);
			List<OLVColumn> columns = new List<OLVColumn>();

			foreach (var key in MessageContainer.Messages[0].contents.Keys)
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

		public void UpdateTagIndex(List<string> tags)
		{
			throw new NotImplementedException();
		}
	}
}
