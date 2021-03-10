using BrightIdeasSoftware;
using IndexEngine;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Viewer.Framework.Views;


namespace Viewer.UI
{


	public partial class TagWindow : Form, ITagView
	{
		private long scrollCount = 0;
		public event WriteEventHandler WriteToDisk;
		public event EventHandler SaveTagged;
		public event EventHandler LoadTagged;

		public void UpdateSituationCount(int count)
        {
			newSituationLabel.Text = count.ToString() + " situations";
        }
		public int CurIndex { get; set; }  = 0;
		public bool SituationsLoaded { get; set; }  = false;
		public event EventHandler TagsetClick;
		public event TaggerEventHandler AddTag;
		public event TaggerEventHandler RemoveTag;
		public event TaggerEventHandler DeleteSituation;
		public event EventHandler RequestColor;

		public event EventHandler LoadMore;
		public event EventHandler ShowSuggester;

		public event EventHandler SetTagset;
		public event EventHandler DisplayColors;
		public event TaggerEventHandler LoadTagset;


		public Dictionary<string, Color> TagsetColors { get; set; }
		public string Tagset { get; set; }

		public bool IsFiltered = false;
		public TagFilter filter = new TagFilter();

		//private Dictionary<string, int> SessionTagIndex { get; set; } = new Dictionary<string, int>();
		private HashSet<string> sit = new HashSet<string>();
		private bool chatViewSetUp = false;

		public TagWindow()
		{
			InitializeComponent();
			DisplayTagset(new List<string>());

			tagTable.FormatRow += ChatTable_FormatRow;
			//tagsetToolTip.SetToolTip(tagsetEditorButton,"Create and edit tagsets");

			
		}

		public void RefreshTagView()
        {
			tagTable.UpdateObjects(MessageContainer.Messages);
		}

		public void DisplayTagset(List<string> tags)
		{
			tagsetView.Items.Clear();
			foreach (var tag in tags)
			{
				tagsetView.Items.Add(tag);

			}
			
		}

		public void AddSituationIndexItem(string s)
        {
			if(sit.Add(s))
            {
				situationView.Items.Add(s.ToString());
            }
        }

		private void ChatTable_FormatRow(object sender, FormatRowEventArgs e)
		{
			DynamicMessage dyn = (DynamicMessage)e.Item.RowObject;
			if (TagsetColors != null)
			{
				if (dyn.Situations.Count != 0)
				{
					e.Item.BackColor = TagsetColors[dyn.Situations.Keys.ToList<string>()[0]];
				}
			}

		}



		private void button1_Click(object sender, EventArgs e)
		{
			TagsetClick?.Invoke(this, EventArgs.Empty);

		}

		private void button4_Click(object sender, EventArgs e)
		{
			WriteEventArgs args = new WriteEventArgs();
			//if (IsFiltered)
			//{
			//	foreach (var obj in tagTable.FilteredObjects)
			//	{
			//		DynamicMessage dyn = (DynamicMessage)obj;
			//		args.ids.Add(dyn);
			//	}

				WriteToDisk?.Invoke(this, args);
			//}
			//else
            //{
				//MessageBox.Show("Please click Tagged only");
            //}
		}

		private void button2_Click(object sender, EventArgs e)
		{

			if (tagsetView.SelectedItems.Count != 0 && tagTable.SelectedObjects.Count != 0)
			{
				TaggerEventArgs args = new TaggerEventArgs();

				args.Tag = tagsetView.SelectedItems[0].Text;

				args.messages = new List<int>();
				
				foreach (var obj in tagTable.SelectedObjects)
				{
					DynamicMessage msg = (DynamicMessage)obj;
					args.messages.Add(msg.Id);


				}

				AddTag?.Invoke(this, args);

				situationView.Items.Add(args.Tag + " " + args.Id);
				tagTable.UpdateObjects(MessageContainer.Messages.FindAll(x => args.messages.Contains(x.Id)));
			}
			else
			{
				MessageBox.Show("Select a tag and messages first");
			}

		}



		private void loadMoreButton_Click(object sender, EventArgs e)
		{
			LoadMore?.Invoke(this, EventArgs.Empty);

		}

		public void SetUpChatView()
		{

			chatViewSetUp = true;
		LoadTagged?.Invoke(this, EventArgs.Empty);
			tagTable.SetObjects(MessageContainer.Messages);
			//MessageBox.Show(tagTable.VirtualListDataSource.ToString());

			List<OLVColumn> columns = new List<OLVColumn>();

			foreach (var key in MessageContainer.Messages[0].Contents.Keys)
			{
				OLVColumn cl = new OLVColumn();
				cl.AspectGetter = delegate (object x) { return OnTagValueGetter(cl, x, key); };

				cl.Name = key;
				cl.Text = key;
				cl.WordWrap = true;
				columns.Add(cl);



			}

			OLVColumn cltag = new OLVColumn();
			cltag.Name = "Tag";
			cltag.Text = "Tag";
			cltag.AspectGetter = delegate (object x) { return OnTagValueGetter(cltag, x, null); };
			tagTable.AllColumns.Clear();
			tagTable.AllColumns.Add(cltag);
			tagTable.AllColumns.AddRange(columns);



			//tagTable.ModelFilter = new TagFilter();

			tagTable.RebuildColumns();

			FormatColumns();
		}

		internal string OnTagValueGetter(OLVColumn cl, object o, string key)
		{
			//I mean shouldnt this work with AspectName instead lmao
			if (cl.Name != "Tag")
			{
				DynamicMessage message = (DynamicMessage)o;
				return message.Contents[key].ToString();
			}
			else
			{

				DynamicMessage m = (DynamicMessage)o;
				return String.Join(",", m.Situations.ToArray());
			}
		}




		private void FormatColumns()
		{
			foreach (var cl in tagTable.AllColumns)
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
			tagTable.Refresh();


		}

		public void ShowView()
		{
			this.Show();
			if(!chatViewSetUp) { 
				SetUpChatView();
				LoadTagset?.Invoke(this, null);
			}
			
		}

		public void CloseView()
		{		
				this.Hide();
				SaveTagged?.Invoke(this, EventArgs.Empty);
				TagsetIndex.WriteInfoToDisk();						
		}


		public void DisplayDocuments()
		{
			//tagTable.UpdateObjects(MessageContainer.Messages);
			tagTable.SetObjects(MessageContainer.Messages);
			tagTable.Invalidate();
		}

		public void UpdateTagIndex(List<string> tags)
		{
			throw new NotImplementedException();
		}


		private void suggester_Click(object sender, EventArgs e)
		{
			ShowSuggester?.Invoke(this, EventArgs.Empty);
		}


		public void DisplayTagsetColors(Dictionary<string, Color> dict)
		{
			TagsetColors = dict;
			foreach (ListViewItem item in tagsetView.Items)
			{
				if (dict.ContainsKey(item.Text))
				{
					item.BackColor = dict[item.Text];
				}
			}
		}

		private void TagWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				this.CloseView();
			}
		}

		private void tagTable_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		//TODO: Fix these.
		private void removeTagButton_Click(object sender, EventArgs e)
		{
			if (tagTable.SelectedObjects != null)
			{
				foreach (var obj in tagTable.SelectedObjects) 
				{
					DynamicMessage dyn = obj as DynamicMessage;
					MessageContainer.Messages[dyn.Id].Situations.Clear();
						}
			}
		}

		private void deleteSituationButton_Click(object sender, EventArgs e)
		{
			TaggerEventArgs args = new TaggerEventArgs();
			args.Tag = situationView.SelectedItems[0].Text.Split(' ')[0];
			args.Id = Int32.Parse(situationView.SelectedItems[0].Text.Split(' ')[1]);


			//DeleteSituation?.Invoke(this, args);
		}

		public void DisplayTagErrorMessage()
		{
			MessageBox.Show("You have already added this tag to the selected message");

		}

		private void tagTable_SelectedIndexChanged_1(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (!IsFiltered)
			{
				IsFiltered = true;
				tagTable.ModelFilter = filter;
				tagTable.UseFilterIndicator = true;
				tagTable.UseFiltering = true;

			}
			else
			{
				IsFiltered = false;
				tagTable.UseFiltering = false;
				tagTable.ModelFilter = null;
			}

		}

        private void situationView_DoubleClick(object sender, EventArgs e)
        {
			string[] item = situationView.SelectedItems[0].Text.Split(' ');
			bool flag = false;
			int messageID = SituationIndex.Index[item[0]][Int32.Parse(item[1])][0];
			//tagTable.EnsureVisible(tagTable.GetItemCount() - 1);

			while (!flag)
			{
				if (tagTable.Items.Count > messageID)
				{
					tagTable.EnsureVisible(messageID);
					flag = true;
				}
				else
				{
					//DialogResult res = MessageBox.Show("This will load additional messages. Proceed?");
					//if (res == DialogResult.OK)
					//{
						LoadMore?.Invoke(this, EventArgs.Empty);
					//}
				}
			}
		}



        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
			SaveTagged?.Invoke(null, null);
        }

        private void writeToDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
			WriteToDisk?.Invoke(null, null);
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void tagTable_Scroll(object sender, ScrollEventArgs e)
        {
			scrollCount = e.NewValue;
			Console.WriteLine(scrollCount);
			if (!IsFiltered)
            {
				if(scrollCount == 1990 || (scrollCount - 1990) % 2000 == 0)
                {
					LoadMore?.Invoke(this, EventArgs.Empty);
				}
            }


		}

		private void dateView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ListView lw = sender as ListView;

			ListView.SelectedIndexCollection index = dateView.SelectedIndices;
			string date = dateView.Items[index[0]].SubItems[0].Text;
			DateTime key = DateTime.Parse(date);

			int i = -1;
			//int i = chatTable.IndexOf(messages[key].Block[0]);
			foreach (var message in MessageContainer.Messages)
			{
				DateTime temp = (DateTime)message.Contents[IndexService.DateFieldKey];
				if (temp.Date == key)
				{
					i = tagTable.IndexOf(message);
					break;
				}

			}
			if (i != -1)
			{
				var item = tagTable.GetItem(i);
				tagTable.SelectedItem = item;
				tagTable.EnsureVisible(tagTable.GetItemCount() - 1);
				tagTable.EnsureVisible(i);
			}
			else
			{
				MessageBox.Show("Broken!");
			}

		}

        public void ShowDates(List<DateTime> dates)
        {
			HashSet<DateTime> container = new HashSet<DateTime>();
			foreach (var message in MessageContainer.Messages)
			{
				container.Add(DateTime.Parse(message.Contents[IndexService.DateFieldKey].ToString()).Date);
			}

			//IEnumerable<DateTime> intersect = container.Intersect(dates);
			dateView.Items.Clear();
			foreach (var item in container)
			{
				dateView.Items.Add(new ListViewItem(item.Date.ToString().Split(' ')[0]));
			}
			dateView.Invalidate();
		}

        private void situationView_SelectedIndexChanged(object sender, EventArgs e)
        {
			if(situationView.SelectedItems.Count == 1)
            {
				editSituationButton.Visible = true;
            }
			if(situationView.SelectedItems.Count == 0)
            {
				editSituationButton.Visible = false;
            }
        }
    }

    public class TagFilter : IModelFilter
	{
		public bool Filter(object modelObject)
		{
			if (modelObject is DynamicMessage)
			{
				DynamicMessage d = (DynamicMessage)modelObject;
				if (d.Situations.Count != 0)
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

    public class SituationTagComparer<T> : IComparer<string>
    {
        public int Compare(string x, string y)
        {
			int res = 0;
			return res;
        }
    }
}
