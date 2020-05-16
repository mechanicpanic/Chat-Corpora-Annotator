﻿using BrightIdeasSoftware;
using IndexingServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Viewer.Framework.Views;
using Viewer.UI;

namespace Viewer
{

	public partial class MainWindow : Form, IMainView, INotifyPropertyChanged
	{
		System.Random rnd = new System.Random();
		#region IMainView

		public event EventHandler OpenIndexedCorpus;
		public event EventHandler ChartClick;
		public event EventHandler HeatmapClick;
		public event EventHandler FileAndIndexSelected;
		public event LuceneQueryEventHandler FindClick;
		public event EventHandler LoadMoreClick;
		public event PropertyChangedEventHandler PropertyChanged;
		public event EventHandler ConcordanceClick;
		public event EventHandler NGramClick;
		public event EventHandler TagClick;

		public string CurrentPath { get; set; }
		public string CurrentIndexPath { get; set; }


		private Dictionary<string, Color> userColors;



		public List<DynamicMessage> SearchResults { get; set; }
		private bool _fileLoadState = false;
		public bool FileLoadState { get { return _fileLoadState; } set { _fileLoadState = value; OnPropertyChanged(); } }

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
			chatTable.SetObjects(MessageContainer.Messages);
			SetUpChatView();
			chatTable.UpdateObjects(MessageContainer.Messages);
			chatTable.Invalidate();
			LoadDates();
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
				var words = searchBox.Text.Trim().Split(null);
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

		CoreAnalyzer analyzer;

		public void ShowView()
		{
			ShowDialog();
		}

		public void CloseView()
		{
			this.CloseView();
		}
		#endregion
		
		public MainWindow()
		{
			InitializeComponent();
			analyzer = new CoreAnalyzer(@"C:\Users\voidl\Documents\stanford-corenlp-full-2016-10-31", @"C:\Users\voidl\Documents\stanford-ner-2016-10-31");

			this.PropertyChanged += MainWindow_PropertyChanged;


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
				loadMoreButton.Visible = true;
			}
			if (!this.FileLoadState)
			{
				queryButton.Enabled = false;
				userToggle.Enabled = false;
				dateToggle.Enabled = false;
				findButton.Enabled = false;
				clearButton.Enabled = false;
				loadMoreButton.Visible = false;
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
				Directory.CreateDirectory(folderPath + "\\CCA");
				Directory.CreateDirectory(folderPath + "\\CCA" + "\\" + name);
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


		private void SetUpChatView()
		{


			ShowUsers();
			PopulateSenderColors();
			SetDateView();
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

				}
			}
			highlightTextRenderer1.CanWrap = true;
			highlightTextRenderer1.UseRoundedRectangle = false;
			highlightTextRenderer1.CornerRoundness = 0.0F;
			highlightTextRenderer1.FramePen = new Pen(Color.White);
			highlightTextRenderer1.FillBrush = new SolidBrush(Color.Wheat);
			chatTable.DefaultRenderer = highlightTextRenderer1;
			chatTable.FormatCell += ChatTable_FormatCell;
			chatTable.Refresh();

		}
		private void PopulateSenderColors()
		{
			userColors = new Dictionary<string, Color>();
			foreach (var user in IndexService.UserKeys)
			{
				Color tempColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
				userColors.Add(user, tempColor);
			}
		}
		private void ChatTable_FormatCell(object sender, FormatCellEventArgs e)
		{
			if (e.Column.Text == IndexService.SenderFieldKey)
			{
				e.SubItem.ForeColor = userColors[e.SubItem.Text];
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
			LoadMoreClick?.Invoke(this, EventArgs.Empty);

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

		private void LoadDates()
		{
			//foreach(var msg in Messages)
			//{
			//	AddDateToDateView((DateTime)msg.contents[DateFieldKey]);
			//}
		}

		private void AddDateToDateView(DateTime date)
		{

			if (!dateView.Items.ContainsKey(date.Date.ToString("dd/MM/yyyy")))

			{
				var temp = new ListViewItem(date.Date.ToString("dd/MM/yyyy"));
				temp.Name = date.Date.ToString("dd/MM/yyyy");
				dateView.Items.Add(temp);
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
				DateTime temp = (DateTime)message.contents[IndexService.DateFieldKey];
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

			//searchResults.Clear();
			if (searchBox.Text == "")
			{
				MessageBox.Show("Empty queries not supported just yet");
				//if (result == DialogResult.OK)
				//{
				//	LaunchSearch();
				//}
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

		private void messageLabel_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

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


		private void button5_Click(object sender, EventArgs e)
		{

			////analyzer.LoadParserModels();


			//Annotation annotation = new Annotation("Is it like a topography that is made from cartography of me in California at 12 AM by Google");
			//CoreDocument coredoc = new CoreDocument(annotation);
			//StanfordCoreNLP pipeline = analyzer.SimplePipeline();
			////pipeline.annotate(annotation);
			//pipeline.annotate(coredoc);

			//List<string> nouns = new List<string>();

			//for (int i = 0; i < coredoc.entityMentions().size(); i++)
			//{
			//	CoreEntityMention em = (CoreEntityMention)coredoc.entityMentions().get(i);
			//	Console.WriteLine("\tdetected entity: \t" + em.text() + "\t" + em.entityType());
			//}
			//Tree constituencyParse;
			//ArrayList temp = (ArrayList)coredoc.annotation().get(typeof(CoreAnnotations.SentencesAnnotation));
			//CoreMap sentence = (CoreMap)temp.get(0);
			//constituencyParse = (Tree)sentence.get(typeof(TreeCoreAnnotations.TreeAnnotation));





			//Set treeConstituents = (Set)constituencyParse.constituents(new LabeledScoredConstituentFactory());
			//var treeArray = treeConstituents.toArray();
			//int index = 0;
			//while (index < treeArray.Length)
			//{
			//	Constituent constituent = (Constituent)treeArray[index];
			//	if (constituent.label() != null &&
			//		(constituent.label().toString().Equals("NP")))
			//	{
			//		Console.WriteLine("found constituent: " + constituent.toString());
			//		Console.WriteLine(constituencyParse.getLeaves().subList(constituent.start(), constituent.end() + 1));

			//	}
			//	if (constituent.label() != null && (constituent.label().toString().Equals("SQ") || constituent.label().toString().Equals("SBARQ")))
			//	{
			//		Console.WriteLine("Question");
			//	}
			//	index++;

			//}
			//constituencyParse.pennPrint();
			//int j = 0;
			//while (j < constituencyParse.taggedYield().toArray().Length)
			//{
			//	Console.WriteLine(constituencyParse.taggedYield().toArray()[j]);
			//	j++;
			//}

			Extractor extractor = new Extractor(this.analyzer);
			extractor.Extract();
		}

		private void dateView_Resize(object sender, EventArgs e)
		{
			dateView.Invalidate();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			TagClick?.Invoke(this, EventArgs.Empty);

		}
	}
}

