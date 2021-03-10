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
		System.Random rnd = new System.Random();
		#region IMainView

		public event EventHandler OpenIndexedCorpus;
		public event EventHandler ChartClick;
		public event EventHandler HeatmapClick;
		public event EventHandler FileAndIndexSelected;
		public event LuceneQueryEventHandler FindClick;
		public event EventHandler LoadMore;
		public event PropertyChangedEventHandler PropertyChanged;
		public event EventHandler ConcordanceClick;
		public event EventHandler NGramClick;
		public event EventHandler TagClick;
		public event EventHandler KeywordClick;
		public event EventHandler LoadStatistics;
		public event EventHandler ExtractInfoClick;
        public event EventHandler VisualizeLengths;
        public event EventHandler VisualizeTokens;
        public event EventHandler VisualizeTokenLengths;

        public string CurrentPath { get; set; }
		public string CurrentIndexPath { get; set; }


		private Dictionary<string, Color> userColors;

		public PointPairList LengthHist { get; set; } = new PointPairList();


		private bool chatViewSetUp = false;
		public List<DynamicMessage> SearchResults { get; set; }
		private bool _fileLoadState = false;
		public bool FileLoadState { get { return _fileLoadState; } set { _fileLoadState = value; OnPropertyChanged(); } }

		Dictionary<string, double> IMainView.Statistics { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool InfoExtracted { get; set; }
        public PointPairList TokenHist { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SetLineCount(int count)
		{
			messageLabel.Text = count.ToString() + " messages";

		}
		public IConcordanceView CreateConcordancer()
		{
			return new Concordancer();
		}

		public void ShowConcordance(IConcordanceView con)
		{
			if (con.IsControl)
			{
				concordancePanel.Controls.Add((UserControl)con);
				concordancePanel.Controls[0].Dock = DockStyle.Fill;
			}
			concordancerButton.Visible = false;
		}

		public INGramView CreateNgramView()
		{
			return new NGramSearch();
		}

		public void ShowNgrams(INGramView nGram)
		{
			ngramPanel.Controls.Add((UserControl)nGram);
			ngramPanel.Controls[0].Dock = DockStyle.Fill;
			ngramButton.Visible = false;
		}
		public void DisplayDocuments()
		{
			
			if (!chatViewSetUp)
			{
				SetUpChatView();
				LoadTagged?.Invoke(this, EventArgs.Empty);
				LoadTagset?.Invoke(this, null);
				



			}
			
			chatTable.Invalidate();
			
		}
		public void DisplaySearchResults()
		{
			chatTable.SetObjects(SearchResults);
			//SetUpChatView();
			chatTable.Invalidate();
			var filters = new List<IModelFilter>();
			TextMatchFilter highlightingFilter = null;
			if (!String.IsNullOrEmpty(searchBox.Text))
			{
				char[] sep = { ',', '\"', ':' };
				var words = searchBox.Text.Trim().Split(sep);
				highlightingFilter = TextMatchFilter.Contains(chatTable, words);
				foreach (var word in words)
				{
					var filter = TextMatchFilter.Contains(chatTable, word);
					filters.Add(filter);
				}
			}
			var compositeFilter = new CompositeAllFilter(filters);

			chatTable.ModelFilter = highlightingFilter;
			chatTable.AdditionalFilter = compositeFilter;
			highlightTextRenderer1.Filter = highlightingFilter;


		}

		

		public void ShowView()
		{
			ShowDialog();

		}

		public void CloseView()
		{
			this.CloseView();
			SaveTagged?.Invoke(this, null);
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
		public TagFilter filter = new TagFilter();

		//private Dictionary<string, int> SessionTagIndex { get; set; } = new Dictionary<string, int>();
		private HashSet<string> sit = new HashSet<string>();
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

			//chatTable.FormatRow += ChatTable_FormatRow;


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
				//loadMoreButton.Visible = true;
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
				//loadMoreButton.Visible = false;
			}
		}

		protected void OnPropertyChanged(string name = "FileLoadState")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		#region csv loading

		private void loadCorpusToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openCsvDialog();
			csvDialog.ShowDialog();

		}
		private void openCsvDialog()
		{
			csvDialog = new OpenFileDialog();
			csvDialog.Filter = "CSV files (*.csv)|*.csv|TSV files (*.tsv)|*.tsv";
			csvDialog.Title = "Open a separated-value file";
			csvDialog.FileOk += csvDialog_FileOk;
		}
		private void csvDialog_FileOk(object sender, CancelEventArgs e)
		{

			this.CurrentPath = csvDialog.FileName;
			string name = Path.GetFileNameWithoutExtension(CurrentPath);
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			if (Directory.Exists(folderPath + "\\CCA"))
			{
				Directory.CreateDirectory(folderPath + "\\CCA" + "\\" + name);
			}
			else
			{
				//Directory.CreateDirectory(folderPath + "\\CCA");
				MessageBox.Show("Something went wrong. Please restart");
				//Directory.CreateDirectory(folderPath + "\\CCA" + "\\" + name);
			}

			this.CurrentIndexPath = folderPath + "\\CCA" + "\\" + name;
			FileAndIndexSelected?.Invoke(this, EventArgs.Empty);
			//SelectIndexFolder();

		}

		private void SelectIndexFolder()
		{
			indexDialog = new FolderBrowserDialog();

			indexDialog.Description = "Select index folder";
			DialogResult result = indexDialog.ShowDialog();
			if (result == DialogResult.OK)
			{

				this.CurrentIndexPath = indexDialog.SelectedPath;


				FileAndIndexSelected?.Invoke(this, EventArgs.Empty);
			}

		}

		#endregion

		#region chat table display

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
		private void SetUpChatView()
		{
			ShowUsers();
			SetDateView();
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

		private void ShowUsers()
		{
			userList.CheckBoxes = true;
			foreach (var user in IndexService.UserKeys)
			{
				userList.Items.Add(new ListViewItem(user));
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

		private void ChatTable_FormatCell(object sender, FormatCellEventArgs e)
		{
			if (e.Column.Text == IndexService.SenderFieldKey)
			{
				e.SubItem.ForeColor = IndexService.UserColors[e.SubItem.Text];
			}

		}
		#endregion



		#region event pipelining
		private void plotToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//ChartClick?.Invoke(this, EventArgs.Empty);
		}

		private void heatmapToolStripMenuItem_Click(object sender, EventArgs e)
		{

			HeatmapClick?.Invoke(this, EventArgs.Empty);

		}
		private void loadMoreButton_Click(object sender, EventArgs e)
		{
			LoadMore?.Invoke(this, EventArgs.Empty);

		}
		private void queryButton_Click(object sender, EventArgs e)
		{
			if (queryPanel.Visible)
			{
				queryPanel.Visible = false;
			}
			else
			{
				queryPanel.Visible = true;
			}
		}


		#endregion

		#region date view


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

		#endregion



		private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
		{
			searchBox.Text = "";
		}

		private void findButton_Click(object sender, EventArgs e)
		{

			if (searchBox.Text == "")
			{
			}
			else
			{
				LaunchSearch();
			}


		}

		private void LaunchSearch()
		{
			var temp = messageLabel.Text.Split().ElementAt(0);
			int count = Int32.Parse(temp); //это смешно, но лучше чем просто баг
			List<string> users = new List<string>();
			List<string> dates = new List<string>();
			var stringQuery = searchBox.Text;
			if (!userToggle.Checked && !dateToggle.Checked)
			{
				FindClick?.Invoke(this, new LuceneQueryEventArgs(stringQuery, count, false));
			}
			else if (userToggle.Checked && !dateToggle.Checked)
			{
				if (userList.CheckedItems.Count != 0)
				{
					users.Clear();
					foreach (ListViewItem item in userList.CheckedItems)
					{
						users.Add(item.Text);

					}
					FindClick?.Invoke(this, new LuceneQueryEventArgs(stringQuery, count, users.ToArray(), false));
				}
			}
			else if (!userToggle.Checked && dateToggle.Checked)
			{

				if (startDate.Checked && finishDate.Checked)
				{
					DateTime[] date = new DateTime[2];
					date[0] = startDate.Value;
					date[1] = finishDate.Value;
					FindClick?.Invoke(this, new LuceneQueryEventArgs(stringQuery, count, date, false));
				}

			}
			else if (userToggle.Checked && dateToggle.Checked)
			{
				users.Clear();
				foreach (ListViewItem item in userList.CheckedItems)
				{
					users.Add(item.Text);

				}
				DateTime[] date = new DateTime[2];
				date[0] = startDate.Value;
				date[1] = finishDate.Value;
				FindClick?.Invoke(this, new LuceneQueryEventArgs(stringQuery, 50, users.ToArray(), date, false));

			}
		}

		private void clearButton_Click(object sender, EventArgs e)
		{
			chatTable.SetObjects(MessageContainer.Messages);
			chatTable.ModelFilter = new ModelFilter(null);
			
			chatTable.Invalidate();
			foreach (ListViewItem check in userList.CheckedItems)
			{
				check.Checked = false;
			}

		}


		private void datesToggle_CheckedChanged(object sender, EventArgs e)
		{
			if (datesPanel.Visible)
			{
				datesPanel.Visible = false;
			}
			else
			{
				datesPanel.Visible = true;
			}
		}

		private void userToggle_CheckedChanged(object sender, EventArgs e)
		{
			if (userPanel.Visible)
			{
				userPanel.Visible = false;
			}
			else
			{
				userPanel.Visible = true;
			}
		}


		private void openCorpusToolStripMenuItem_Click(object sender, EventArgs e)
		{
			indexDialog = new FolderBrowserDialog();

			indexDialog.Description = "Select previously indexed corpus";
			DialogResult result = indexDialog.ShowDialog();
			if (result == DialogResult.OK)
			{

				this.CurrentIndexPath = indexDialog.SelectedPath;


				OpenIndexedCorpus?.Invoke(this, EventArgs.Empty);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			ConcordanceClick?.Invoke(this, EventArgs.Empty);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			NGramClick?.Invoke(this, EventArgs.Empty);
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			KeywordClick?.Invoke(this, EventArgs.Empty);
		}

		public IKeywordView CreateKeywordView()
		{
			return new Keyworder();
		}

		public void ShowKeywordView(IKeywordView key)
		{
			keywordPanel.Controls.Add((UserControl)key);
			keywordPanel.Controls[0].Dock = DockStyle.Fill;
			keywordButton.Visible = false;
		}

		public void ShowDates(List<DateTime> dates)
		{
			HashSet<DateTime> container = new HashSet<DateTime>();
			foreach(var message in MessageContainer.Messages)
            {
				container.Add(DateTime.Parse(message.Contents[IndexService.DateFieldKey].ToString()).Date);
            }

			//IEnumerable<DateTime> intersect = container.Intersect(dates);
			dateView.Items.Clear();
			foreach(var item in container)
			{
				dateView.Items.Add(new ListViewItem(item.Date.ToString().Split(' ')[0]));
			}
			dateView.Invalidate();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			LoadStatistics?.Invoke(this, EventArgs.Empty);
			
		}

		public void DisplayStatistics(StatisticsContainer stats)
		{

			listView1.Items.Add(new ListViewItem(new string[2] { "Average messsage length", stats.AverageLength.ToString() }));
			listView1.Items.Add(new ListViewItem(new string[2] { "Average messages per day", stats.AverageMessagesPerDay.ToString() }));
			listView1.Items.Add(new ListViewItem(new string[2] { "Number of messages", stats.NumberOfDocs.ToString() }));
			listView1.Items.Add(new ListViewItem(new string[2] { "Number of symbols", stats.NumberOfSymbols.ToString() }));
			listView1.Items.Add(new ListViewItem(new string[2] { "Number of tokens", stats.NumberOfTokens.ToString() }));

		}

		private void extractToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ExtractInfoClick?.Invoke(this, EventArgs.Empty);
		}

		public void ShowSorryMessage()
		{
			MessageBox.Show("You have to run the NLP extraction pipeline first. Click File > Extract...");
		}

		public void ShowExtractedMessage()
		{
			MessageBox.Show("Info already extracted");
		}

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (listBox1.Items[listBox1.SelectedIndex].ToString())
            {
				case "Message length":
					VisualizeLengths?.Invoke(this, EventArgs.Empty);
					break;
				case "Token number by message":
					VisualizeTokens?.Invoke(this, EventArgs.Empty);
					break;
				case "Token lengths":
					VisualizeTokenLengths?.Invoke(this, EventArgs.Empty);
					break;
            }

        }

		public void VisualizeHist(PointPairList list, string name)
        {
			zedGraphControl1.GraphPane.GraphObjList.Clear();
			zedGraphControl1.GraphPane.CurveList.Clear();
			zedGraphControl1.GraphPane.AddBar(name, list, Color.CornflowerBlue);
			
			zedGraphControl1.GraphPane.YAxis.Title.Text = "Count";
			zedGraphControl1.GraphPane.XAxis.Title.Text = "Value";
			zedGraphControl1.AxisChange();
			zedGraphControl1.Refresh();
		}
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void startTaggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
			TagClick?.Invoke(this, EventArgs.Empty);
		}

        private void chatTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
		private long scrollCount = 0;

        private void chatTable_Scroll(object sender, ScrollEventArgs e)
        {
			scrollCount = e.NewValue;
			Console.WriteLine(scrollCount);
		
				if ((scrollCount - 988) % 100 == 0)
				{
				LoadMore?.Invoke(this, EventArgs.Empty);
			}
			

		}

		public void SetTagsetLabel(string tagset)
        {
			tagsetLabel.Text = tagset;
        }

        public void RefreshTagView()
        {
            throw new NotImplementedException();
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

		private void addTagButton_Click(object sender, EventArgs e)
		{

			if (tagsetView.SelectedItems.Count != 0 && chatTable.SelectedObjects.Count != 0)
			{
				TaggerEventArgs args = new TaggerEventArgs();

				args.Tag = tagsetView.SelectedItems[0].Text;

				args.messages = new List<int>();

				foreach (var obj in chatTable.SelectedObjects)
				{
					DynamicMessage msg = (DynamicMessage)obj;
					args.messages.Add(msg.Id);


				}

				AddTag?.Invoke(this, args);

				situationView.Items.Add(args.Tag + " " + args.Id);
				chatTable.UpdateObjects(MessageContainer.Messages.FindAll(x => args.messages.Contains(x.Id)));
			}
			else
			{
				MessageBox.Show("Select a tag and messages first");
			}

		}
		private void suggester_Click(object sender, EventArgs e)
		{
			ShowSuggester?.Invoke(this, EventArgs.Empty);
		}

		private void removeTagButton_Click(object sender, EventArgs e)
		{
			if (chatTable.SelectedObjects != null)
			{
				foreach (var obj in chatTable.SelectedObjects)
				{
					DynamicMessage dyn = obj as DynamicMessage;
					MessageContainer.Messages[dyn.Id].Situations.Clear();
				}
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
				if (chatTable.Items.Count > messageID)
				{
					chatTable.EnsureVisible(messageID);
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

		private void deleteSituationButton_Click(object sender, EventArgs e)
		{
			TaggerEventArgs args = new TaggerEventArgs();
			args.Tag = situationView.SelectedItems[0].Text.Split(' ')[0];
			args.Id = Int32.Parse(situationView.SelectedItems[0].Text.Split(' ')[1]);


			//DeleteSituation?.Invoke(this, args);
		}

        private void tagsetEditorButton_ButtonClick(object sender, EventArgs e)
        {
			TagsetClick?.Invoke(this, EventArgs.Empty);
		}
    }
}

