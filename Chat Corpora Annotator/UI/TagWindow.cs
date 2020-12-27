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
		public event EventHandler WriteToDisk;
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


		public TagWindow()
		{
			InitializeComponent();
			DisplayTagset(new List<string>());

			tagTable.FormatRow += ChatTable_FormatRow;
			LoadMore?.Invoke(this, EventArgs.Empty);
		}



		public void DisplayTagset(List<string> tags)
		{
			tagsetView.Items.Clear();
			foreach (var tag in tags)
			{
				tagsetView.Items.Add(tag);

			}
			DisplayBackTagsetColors();
		}
		private void DisplayBackTagsetColors()
		{
			foreach (ListViewItem item in tagsetView.Items)
			{
				if (TagsetColors.ContainsKey(item.Text))
				{
					item.BackColor = TagsetColors[item.Text];
				}
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
			WriteToDisk?.Invoke(this, EventArgs.Empty);
		}

		private void button2_Click(object sender, EventArgs e)
		{

			if (tagsetView.SelectedItems != null && tagTable.SelectedObjects != null)
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


				tagTable.UpdateObjects(MessageContainer.Messages);
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
		}

		public void CloseView()
		{
			this.Hide();
			TagsetIndex.WriteInfoToDisk();
		}


		public void DisplayDocuments()
		{
			SetUpChatView();
			tagTable.UpdateObjects(MessageContainer.Messages);
			tagTable.Invalidate();
		}

		public void UpdateTagIndex(List<string> tags)
		{
			throw new NotImplementedException();
		}


		private void listView2_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void button5_Click_1(object sender, EventArgs e)
		{
			ShowSuggester?.Invoke(this, EventArgs.Empty);
		}


		public void DisplayTagsetColors(Dictionary<string, Color> dict)
		{
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
				Hide();
			}
		}

		private void tagTable_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void removeTagButton_Click(object sender, EventArgs e)
		{
			if (tagTable.SelectedObjects != null)
			{

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
}
