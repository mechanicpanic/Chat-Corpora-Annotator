using BrightIdeasSoftware;
using IndexingServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Viewer.Framework.Views;

namespace Viewer.UI
{
	public partial class TagWindow : Form, ITagView
	{

		//public Dictionary<List<string>, Tuple<string, int>> SituationIndex { get; set; }

		public Tuple<List<string>, string> CurrentSituation { get; set; }

		private Dictionary<string,Color> SituationColor = new Dictionary<string,Color>();
		private Dictionary<List<string>,string> TaggedMessages = new Dictionary<List<string>,string>();
		private Dictionary<string, int> TagIndex { get; set; } = new Dictionary<string, int>();
		
		private void GenerateSituationColors()
		{
			SituationColor.Add("Meeting", Color.Bisque);
			SituationColor.Add("JobDiscussion", Color.MistyRose);
			SituationColor.Add("SoftwareSupport", Color.LavenderBlush);
			SituationColor.Add("CodeAssistance", Color.Lavender);

			
		}
		public TagWindow()
		{
			InitializeComponent();
			//Tags = new List<string>();
			//SituationIndex = new Dictionary<string, int>();

			//foreach(var tag in Tags)
			//{
			//	SituationIndex.Add(tag, 0);
			//}
			GenerateSituationColors();
			TagIndex.Add("Meeting", 0);
			TagIndex.Add("JobDiscussion", 0);
			TagIndex.Add("SoftwareSupport", 0);
			TagIndex.Add("CodeAssistance", 0);
			DisplayTagset(new List<string>());

			chatTable.FormatRow += ChatTable_FormatRow;
			
		}

		public void DisplayTagset(List<string> tags)
		{
			foreach(var key in TagIndex.Keys)
			{
				ListViewItem lvi = new ListViewItem(key);
				lvi.BackColor = SituationColor[key];
				listView2.Items.Add(lvi);
			}
			listView2.Invalidate();
			
		}

		private void ChatTable_FormatRow(object sender, FormatRowEventArgs e)
		{
			DynamicMessage dyn = (DynamicMessage)e.Item.RowObject;
			foreach (var kvp in TaggedMessages)
			{
				if (kvp.Key.Contains(dyn.Id))
				{
					e.Item.BackColor = SituationColor[kvp.Value];
				}
			}
		}

		public event EventHandler WriteToDisk;
		public event EventHandler TagsetClick;
		public event EventHandler AddTag;
		public event EventHandler RemoveTag;
		public event EventHandler EditSituation;
		public event EventHandler LoadMore;

		private void button1_Click(object sender, EventArgs e)
		{
			TagsetClick?.Invoke(this, EventArgs.Empty);

		}

		private void button4_Click(object sender, EventArgs e)
		{
			WriteToDisk?.Invoke(this, EventArgs.Empty);
		}

		private void button2_Click(object sender, EventArgs e)
		{

			if (listView2.SelectedItems != null && chatTable.SelectedObjects != null)
			{
				List<string> set = new List<string>();
				foreach (var obj in chatTable.SelectedObjects)
				{
					DynamicMessage msg = (DynamicMessage)obj;
					set.Add(msg.Id);
					
					
				}
				TaggedMessages.Add(set, listView2.SelectedItems[0].Text);
				CurrentSituation = new Tuple<List<string>, string>(set, listView2.SelectedItems[0].Text);

				AddTag?.Invoke(this, EventArgs.Empty);
			}
			var temp = "";
			foreach (var obj in chatTable.SelectedObjects)
			{
				temp = " [" + listView2.SelectedItems[0].Text + " ID " + TagIndex[listView2.SelectedItems[0].Text] + "]";
				MessageContainer.Messages[MessageContainer.Messages.IndexOf((DynamicMessage)obj)].contents["text"] += temp;

			}
			listView1.Items.Add(new ListViewItem(temp));
			listView1.Update();
			TagIndex[listView2.SelectedItems[0].Text]++;
			chatTable.UpdateObjects(MessageContainer.Messages);
		}


		private void loadMoreButton_Click(object sender, EventArgs e)
		{
			LoadMore?.Invoke(this, EventArgs.Empty);

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


			FormatColumns();

		}



		private void FormatColumns()
		{
			foreach (var cl in chatTable.AllColumns)
			{
				if (cl.Text != IndexService.TextFieldKey)
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
			listView1.Items.Clear();
			foreach (var tag in tags)
			{
				listView1.Items.Add(new ListViewItem(tag));
			}
		}

		public void DisplayDocuments()
		{
			SetUpChatView();
			chatTable.UpdateObjects(MessageContainer.Messages);
			chatTable.Invalidate();
		}

		public void UpdateTagIndex(List<string> tags)
		{
			throw new NotImplementedException();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			EditSituation?.Invoke(this, EventArgs.Empty);
		}

		private void listView2_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
