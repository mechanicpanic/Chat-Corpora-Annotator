using BrightIdeasSoftware;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Viewer.Framework.Views;
using Viewer.UI;
using ZedGraph;
using ColorLibrary;
using IndexEngine;

namespace Viewer
{

	public partial class MainWindow : Form, IMainView, ITagView, INotifyPropertyChanged
	{
		private long scrollCount = 0;
		private bool chatViewSetUp = false;
		private bool _fileLoadState = false;
		private HashSet<string> sit = new HashSet<string>();
		public bool FileLoadState { get { return _fileLoadState; } set { _fileLoadState = value; OnPropertyChanged(); } }
		#region IMainView

		public event EventHandler OpenIndexedCorpus;
		public event EventHandler ChartClick;
		public event EventHandler HeatmapClick;
		public event EventHandler FileAndIndexSelected;
		public event EventHandler LoadMore;

		public event EventHandler ConcordanceClick;
		public event EventHandler NGramClick;
		public event EventHandler TagClick;
		public event EventHandler KeywordClick;
		public event EventHandler LoadStatistics;
		public event EventHandler ExtractInfoClick;

        public event EventHandler VisualizeLengths;
        public event EventHandler VisualizeTokens;
        public event EventHandler VisualizeTokenLengths;

		public event LuceneQueryEventHandler FindClick;
		public event PropertyChangedEventHandler PropertyChanged;

		public string CurrentPath { get; set; }
		public string CurrentIndexPath { get; set; }
		public bool InfoExtracted { get; set; }
		public List<DynamicMessage> SearchResults { get; set; }

		public void ShowView()
		{
			ShowDialog();

		}

		public void CloseView()
		{
			this.CloseView();
			SaveTagged?.Invoke(this, null);
		}

		public void SetLineCount(int count)
		{
			messageLabel.Text = count.ToString() + " messages";

		}

		#endregion

		#region ITagView

		public event WriteEventHandler WriteToDisk;
		public event EventHandler SaveTagged;
		public event EventHandler LoadTagged;

		public void UpdateSituationCount(int count)
		{
			newSituationLabel.Text = count.ToString() + " situations";
		}
		public int CurIndex { get; set; } = 0;
		public bool SituationsLoaded { get; set; } = false;
		public event EventHandler TagsetClick;
		public event TaggerEventHandler AddTag;
		public event TaggerEventHandler RemoveTag;
		public event TaggerEventHandler DeleteSituation;
		public event EventHandler ShowSuggester;

		public event EventHandler SetTagset;
		public event EventHandler DisplayColors;
		public event TaggerEventHandler LoadTagset;


		public Dictionary<string, Color> TagsetColors { get; set; }
		public bool IsFiltered = false;
		public TagFilter tagFilter = new TagFilter();


		#endregion
		public MainWindow()
		{
			InitializeComponent();
			
			this.PropertyChanged += MainWindow_PropertyChanged;
			this.InfoExtracted = false;
			zedGraphControl1.GraphPane.Title.IsVisible = false;
			zedGraphControl1.GraphPane.YAxis.Title.Text = "";
			zedGraphControl1.GraphPane.XAxis.Title.Text = "";

			DisplayTagset(new List<string>());


		}

		private void MainWindow_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (this.FileLoadState)
			{
				queryButton.Enabled = true;
				userToggle.Enabled = true;
				dateToggle.Enabled = true;
				findButton.Enabled = true;
				clearButton.Enabled = true;
				concordancerButton.Enabled = true;
				ngramButton.Enabled = true;
				keywordButton.Enabled = true;
				tableLayoutPanel1.Visible = true;
				splitContainerRight.Visible = true;
			}

			if (!this.FileLoadState)
			{
				queryButton.Enabled = false;
				userToggle.Enabled = false;
				dateToggle.Enabled = false;
				findButton.Enabled = false;
				clearButton.Enabled = false;
				concordancerButton.Enabled = false;
				ngramButton.Enabled = false;
				keywordButton.Enabled = false;
				tableLayoutPanel1.Visible = false;
				splitContainerRight.Visible = false;
			}
		}

		protected void OnPropertyChanged(string name = "FileLoadState")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}


        #region ChatView Display

        #region format events
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
		private void ChatTable_FormatCell(object sender, FormatCellEventArgs e)
		{
			if (e.Column.Text == IndexService.SenderFieldKey)
			{
				e.SubItem.ForeColor = IndexService.UserColors[e.SubItem.Text];
			}

		}
        #endregion

        #region create columns

        private void SetUpChatView()
		{
			ShowUsers();
			chatTable.SetObjects(MessageContainer.Messages);
			List<OLVColumn> columns = new List<OLVColumn>();

			foreach (var key in IndexService.SelectedFields)
			{
				OLVColumn cl = new OLVColumn();
				cl.AspectGetter = delegate (object x) { return OnTagValueGetter(cl, x, key); };
				cl.Text = key;
				cl.WordWrap = true;
				columns.Add(cl);
			}
			OLVColumn cltag = new OLVColumn();
			cltag.Name = "Tag";
			cltag.Text = "Tag";
			cltag.AspectGetter = delegate (object x) { return OnTagValueGetter(cltag, x, null); };
			chatTable.AllColumns.Clear();
			chatTable.AllColumns.Add(cltag);
			chatTable.AllColumns.AddRange(columns);
			chatTable.RebuildColumns();

			FormatColumns();
			chatViewSetUp = true;

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
			foreach (var cl in chatTable.AllColumns)
			{
				if (cl.Text != IndexService.TextFieldKey)
				{
					cl.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
				}
				else
				{
					cl.FillsFreeSpace = true;
					cl.Renderer = highlightTextRenderer1;
					cl.Sortable = true;

				}
			}
			highlightTextRenderer1.CanWrap = true;
			highlightTextRenderer1.UseRoundedRectangle = false;
			highlightTextRenderer1.CornerRoundness = 0.0F;
			highlightTextRenderer1.FramePen = new Pen(Color.White);
			highlightTextRenderer1.FillBrush = new SolidBrush(Color.Wheat);
			chatTable.DefaultRenderer = highlightTextRenderer1;
			chatTable.FormatCell += ChatTable_FormatCell;
			chatTable.FormatRow += ChatTable_FormatRow;
			chatTable.Refresh();

		}
        #endregion

        #region show data
        private void ShowUsers()
		{
			userList.CheckBoxes = true;
			foreach (var user in IndexService.UserKeys)
			{
				userList.Items.Add(new ListViewItem(user));
			}

		}
		public void DisplayDocuments()
		{

			if (!chatViewSetUp)
			{
				SetUpChatView();
				LoadTagged?.Invoke(this, EventArgs.Empty);
				this.SituationsLoaded = true;
				LoadTagset?.Invoke(this, null);

			}
			chatTable.SetObjects(MessageContainer.Messages);
			chatTable.Invalidate();

		}
		private void chatTable_Scroll(object sender, ScrollEventArgs e)
		{
			scrollCount = e.NewValue;
			Console.WriteLine(scrollCount);

			if ((scrollCount - 988) % 100 == 0 || ((scrollCount - 985) % 100 == 0) && scrollCount != 0) //i promise i will learn what wndproc is one day...
			{
				LoadMore?.Invoke(this, EventArgs.Empty);
			}


		}

		#endregion

		#endregion

		#region DateView Display


		public void SetDateView()
		{
			dateView.View = View.Details;
			dateView.VirtualMode = false;

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
					i = chatTable.IndexOf(message);
					break;
				}

			}
			if (i != -1)
			{
				var item = chatTable.GetItem(i);
				chatTable.SelectedItem = item;
				chatTable.EnsureVisible(chatTable.GetItemCount() - 1);
				chatTable.EnsureVisible(i);
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

		#endregion


		public void ShowSorryMessage()
		{
			MessageBox.Show("You have to run the NLP extraction pipeline first. Click File > Extract...");
		}

		public void ShowExtractedMessage()
		{
			MessageBox.Show("Info already extracted");
		}

		public void SetTagsetLabel(string tagset)
        {
			tagsetLabel.Text = tagset;
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

        public void DisplayTagset(List<string> tags)
        {
			tagsetView.Items.Clear();
			foreach (var tag in tags)
			{
				tagsetView.Items.Add(tag);

			}
		}

        public void DisplayTagErrorMessage()
        {
			MessageBox.Show("You have already added this tag to the selected message");
		}

        public void AddSituationIndexItem(string s)
        {
			if (sit.Add(s))
			{
				situationView.Items.Add(s.ToString());
			}
		}

		
        private void situationView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
			e.NewWidth = this.situationView.Columns[e.ColumnIndex].Width;
			e.Cancel = true;

        }
		private void dateView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
		{
			e.NewWidth = this.dateView.Columns[e.ColumnIndex].Width;
			e.Cancel = true;
		}

	}
}

