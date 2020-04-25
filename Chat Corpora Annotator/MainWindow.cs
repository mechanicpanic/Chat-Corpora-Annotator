using BrightIdeasSoftware;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;


using CSharpTest.Net.Collections;
using SoftCircuits.CsvParser;
using Lucene.Net.Util;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;

using Lucene.Net.Search;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Queries;
using System.Drawing;
using Tagger;
using Viewer.CSV_Wizard;
using Viewer.Framework.Views;

namespace Viewer
{
	public partial class MainWindow : Form, IMainView
	{
		#region fields

		
		public string csvPath;
		private string indexPath;

		public string[] allFields;
		public List<string> selectedFields = new List<string>();

		private string dateFieldKey;
		private string senderFieldKey;
		private string textFieldKey;


		

		private HashSet<string> userKeys = new HashSet<string>();

		private Random rnd = new Random();
		private Dictionary<string, Color> userColors = new Dictionary<string, Color>();

	   
		private List<DynamicMessage> messages = new List<DynamicMessage>();
		private BTreeDictionary<DateTime, int> messagesPerDay = new BTreeDictionary<DateTime, int>();
		
  
		List<Color> heatMapColors = new List<Color>();


		LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;
		FSDirectory dir;
		IndexWriterConfig indexConfig;
		IndexWriter writer;
		DirectoryReader reader;
		int readerIndex;



		private StandardAnalyzer analyzer;

		private IndexSearcher searcher;
		private QueryParser textParser;
		private List<DynamicMessage> searchResults = new List<DynamicMessage>();
		#endregion

		#region IMainView

		public event EventHandler OpenIndexedCorpus;
		public event EventHandler ChartClick;
		public event EventHandler HeatmapClick;
		public event EventHandler FileAndIndexSelected;
		public event EventHandler FindClick;
		public event EventHandler LoadMoreClick;

		List<string> IMainView.Users { get; set; }
		public string CurrentPath { get; set; }
		public string CurrentIndexPath { get; set; }
		List<DynamicMessage> Messages { get; set; }


		public void SetLineCount(int count)
		{
			messageLabel.Text = count.ToString() + " messages";
		}

		public void DisplayDocuments()
		{
			chatTable.UpdateObjects(this.Messages);
			chatTable.Invalidate();
		}

		public new void Show()
		{
			ShowDialog();
		}

		public new void Close()
		{
			this.Close();
		}
		#endregion

		public MainWindow()
		{
			InitializeComponent();
			
			
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{


		}


		#region csv loading

		
		private void openCsvDialog()
		{
			csvDialog = new OpenFileDialog();
			csvDialog.Filter = "CSV files (*.csv)|*.csv";
			csvDialog.Title = "Open a .csv file";
			csvDialog.FileOk += csvDialog_FileOk;
		}
		private void csvDialog_FileOk(object sender, CancelEventArgs e)
		{
			csvPath = csvDialog.FileName;
			SelectIndexFolder();

		}

		private void SelectIndexFolder()
		{
			indexDialog = new FolderBrowserDialog();

			indexDialog.Description = "Select index folder";
			DialogResult result = indexDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				indexPath = indexDialog.SelectedPath;
				//SelectFields();

				FileAndIndexSelected?.Invoke(this, EventArgs.Empty);
			}

		}

		#endregion

		#region chat table display

		private void DisplayData()
		{
			PopulateSenderColors();
			chatTable.SetObjects(messages);
			
			List<OLVColumn> columns = new List<OLVColumn>();
			
			foreach(var key in selectedFields)
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
			chatTable.AllColumns.AddRange(columns);
			chatTable.RebuildColumns();


			FormatColumns();
			
		}

		private void FormatColumns()
		{
			foreach (var cl in chatTable.AllColumns)
			{
				if (cl.Text != textFieldKey)
				{
					cl.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
				}
				else
				{
					cl.FillsFreeSpace = true;
				}
			}
			chatTable.FormatCell += ChatTable_FormatCell;
			chatTable.Refresh();

		}
		private void PopulateSenderColors()
		{
			foreach (var user in userKeys)
			{
				Color tempColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
				userColors.Add(user, tempColor);
			}
		}
		private void ChatTable_FormatCell(object sender, FormatCellEventArgs e)
		{
			if (e.Column.Text == senderFieldKey)
			{
				e.SubItem.ForeColor = userColors[e.SubItem.Text];
			}

		}

		private void LoadSomeDocuments(int n)
		{

			
			for (int i = readerIndex; i < n+readerIndex; i++)
			{
				Document document;
				List<string> temp = new List<string>();
				if (i < reader.MaxDoc)
				{
					document = reader.Document(i);
				}
				else
				{
					break;
				}
				foreach (var field in selectedFields)
				{

					temp.Add(document.GetField(field).GetStringValue());
				}
				DynamicMessage message = new DynamicMessage(temp, selectedFields, dateFieldKey);
				messages.Add(message);
				

			}
			readerIndex = n + readerIndex;

		}


		#endregion

		#region header 
		private void SelectFields()
		{
			using (var parser = new TextFieldParser(csvPath))
			{
				parser.SetDelimiters(","); //TODO: Delimiter select

				allFields = parser.ReadFields();
			}


			HeaderForm hf = new HeaderForm();
			AddOwnedForm(hf);
			hf.Show();
			//hf.UpdateLabel(Path.GetFileName(csvPath));
			hf.ShowFields(allFields);
			hf.FieldButtonClicked += new EventHandler(FieldButtonHandler);


		}
		private void SelectFieldMetadata()
		{
			ColumnMetadata cm = new ColumnMetadata();
			cm.PopulateDateBox(selectedFields.ToArray());
			cm.PopulateSenderBox(selectedFields.ToArray());
			cm.PopulateTextBox(selectedFields.ToArray());

			cm.Show();
			cm.ColumnButtonClicked += new EventHandler(ColumnButtonHandler);
		}
		#endregion

		#region index init and write
		private void SetUpIndex()
		{
			

			if (indexPath != null)
			{
				dir = FSDirectory.Open(indexPath);

				//create an analyzer to process the text
				analyzer = new StandardAnalyzer(AppLuceneVersion);

				//create an index writer
				indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
				writer = new IndexWriter(dir, indexConfig);
				writer.DeleteAll();
				writer.Commit();

				textParser = new QueryParser(AppLuceneVersion, textFieldKey, analyzer);
				readerIndex = 0;
				FirstRead();
			}

		}
		private int[] CreateLookupList()
		{
			int[] lookup = new int[3];
			foreach(var field in selectedFields)
			{
				if (field == dateFieldKey)
				{
					lookup[0] = Array.IndexOf(allFields,dateFieldKey);
				}
				if(field == senderFieldKey)
				{
					lookup[1] = Array.IndexOf(allFields, senderFieldKey);
				}
				if(field == textFieldKey)
				{
					lookup[2] = Array.IndexOf(allFields, textFieldKey);
				}
			}
			return lookup;
		}
		private void FirstRead()
		{
			string[] row = null;
			int count = 0;
			using (var csv = new CsvReader(csvPath))
			{
				csv.ReadRow(ref row); //header read;
				while (csv.ReadRow(ref row))
				{
					count++;
				}
			}
			
		}
		private void PopulateIndex()
		{

			if (selectedFields != null)
				SetUpIndex();
			{
				int[] lookup = CreateLookupList();
				string[] row = null;
				DateTime date;		
				using (var csv = new CsvReader(csvPath))
				{
					csv.ReadRow(ref row); //header read;


					while (csv.ReadRow(ref row))
					
					 {
						 
						 date = DateTime.Parse(row[lookup[0]]);
						 userKeys.Add(row[lookup[1]]);


						 var day = date.Date;
						 if (!messagesPerDay.Keys.Contains(day))
						 {
							 messagesPerDay.Add(day, 1);
						 }
						 else
						 {
							 int temp = messagesPerDay[day];
							 temp++;
							 messagesPerDay.TryUpdate(day, temp);
						 }
						Document document = new Document();
						for(int i = 0; i < row.Length; i++)
						 {
							if (lookup.Contains(i))
							{
								if (i == lookup[0])
								{
									var temp = DateTools.DateToString(date, DateTools.Resolution.MINUTE);
									document.Add(new StringField(allFields[i], temp, Field.Store.YES));
								}
								if (i == lookup[1])
								{
									document.Add(new StringField(allFields[i], row[i], Field.Store.YES));
								}
								if (i == lookup[2])
								{

									document.Add(new TextField(allFields[i], row[i], Field.Store.YES));
								}
							}
							else
							{
								document.Add(new StringField(allFields[i], row[i], Field.Store.YES));
							}
							//TODO: Still need to redesign this. Rework storing/indexing paradigm.
							 
						 }

						 writer.AddDocument(document);

					 }
					
				}


				writer.Commit();
				writer.Flush(triggerMerge: false, applyAllDeletes: false);
				writer.Dispose();
				reader = DirectoryReader.Open(dir);
				searcher = new IndexSearcher(reader);
				DataLoaded();
				foreach (var user in userKeys)
				{
					userList.Items.Add(user);
				}
				




			}
		}
		private void DataLoaded()
		{
			DataLoaded dl = new DataLoaded();
			dl.Show();
			dl.OKButtonClicked += DataLoadedButtonHandler;
		}

		#endregion

		#region dialogue buttons
		private void FieldButtonHandler(object sender, EventArgs e)
		{

			HeaderForm hf = sender as HeaderForm;
			if (hf != null)
			{
				selectedFields = hf.SelectedFields;
				SelectFieldMetadata();
				hf.Close();
			}

		}

		private void DataLoadedButtonHandler(object sender, EventArgs e)
		{
			DataLoaded dl = sender as DataLoaded;
			if (dl != null)
			{
				SetDateView();
				LoadSomeDocuments(500);
				DisplayData();
				
				dl.Close();
			}

		}

		private void ColumnButtonHandler(object sender, EventArgs e)
		{
			ColumnMetadata cm = sender as ColumnMetadata;
			if (cm != null)
			{
				dateFieldKey = cm.dateFieldKey;
				senderFieldKey = cm.senderFieldKey;
				textFieldKey = cm.textFieldKey;
				PopulateIndex();
				cm.Close();

			}

		}

		#endregion

		#region main window buttons


		private void plotToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//ChartForm cf = new ChartForm();
			//cf.InitializeChart(messagesPerDay.Keys.ToList(), messagesPerDay.Values.ToList());

			ChartClick?.Invoke(this, EventArgs.Empty);
		}

		private void heatmapToolStripMenuItem_Click(object sender, EventArgs e)
		{

			//PopulateHeatmap();
			//LinearHeatmapForm swf = new LinearHeatmapForm();
			//swf.InitializeHeatMap(heatMapColors);
			//swf.Show();
			//swf.DrawHeatMap();
			//swf.Draw();

			HeatmapClick?.Invoke(this, EventArgs.Empty);

		}

		private void loadCorpusToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openCsvDialog();
			csvDialog.ShowDialog();

		}

		private void loadMoreButton_Click(object sender, EventArgs e)
		{
			LoadMoreClick?.Invoke(this, EventArgs.Empty);
			LoadSomeDocuments(100);
			chatTable.UpdateObjects(messages);
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
		private void selectUsersButton_Click(object sender, EventArgs e)
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

		private void datesButton_Click(object sender, EventArgs e)
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

		#endregion

		#region heatmap
		public Color HeatMapColor(double value, double min, double max)
		{
			double val = (value - min) / (max - min);
			int r = Convert.ToByte(255 * val);
			int g = Convert.ToByte(255 * (1 - val));
			int b = 10;

			return Color.FromArgb(255, r, g, b);
		}
		private void PopulateHeatmap()
		{


			double max = messagesPerDay.Values.Max();
			double min = messagesPerDay.Values.Min();

			double temp = 998 / messagesPerDay.Keys.Count;
			if (temp >= 10.0)
			{
				foreach (var date in messagesPerDay.Keys)
				{
					double x = messagesPerDay[date];
					heatMapColors.Add(HeatMapColor(x, min, max));
				}
			}
			else
			{
				DateTime[] days = new DateTime[messagesPerDay.Keys.Count];
				
				messagesPerDay.Keys.CopyTo(days, 0);
				//Array.Sort(days);

				double block = (messagesPerDay.Keys.Count / 998.0) * 10.0;

				int blockDayCount = (int)Math.Floor(block);
				List<double> newCounts = new List<double>();
				double x = 0;
				int count = 0;
				int index = 0;
				while(index < days.Length)
				{
					if (days.Length - index > blockDayCount)
					{
						while (count < blockDayCount)
						{
							x += messagesPerDay[days[index]];
							index++;
							count++;
						}
						if (count == blockDayCount)
						{
							x += messagesPerDay[days[index]];
							newCounts.Add(x);
							count = 0;
							x = 0;
							index++;
						}
					}
					else
					{
						x += messagesPerDay[days[index]];
						index++;
						if(index == days.Length - 1)
						{
							newCounts.Add(x);
						}
					}
					
				}

				var newmax = newCounts.Max();
				var newmin = newCounts.Min();

				foreach (var cc in newCounts)
				{
					heatMapColors.Add(HeatMapColor(cc, newmin, newmax));
				}

			}
		}
		#endregion

		#region date view
		public void SetDateView()
		{
			dateView.View = View.Details;
			dateView.VirtualMode = true;
			dateView.VirtualListSize = messagesPerDay.Keys.Count;
			//dateView.DoubleBuffering(true);
			RetrieveVirtualItemEventHandler handler = new RetrieveVirtualItemEventHandler(dateView_RetrieveVirtualItem);
			dateView.RetrieveVirtualItem += handler;


		}

		private void dateView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
		{
			int index = e.ItemIndex;
			string date = messagesPerDay.Keys.ElementAt<DateTime>(index).ToShortDateString();


			e.Item = new ListViewItem(date);

		}


		private void dateView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ListView lw = sender as ListView;

			ListView.SelectedIndexCollection index = dateView.SelectedIndices;
			string date = dateView.Items[index[0]].SubItems[0].Text;
			DateTime key = DateTime.Parse(date);

			int i = -1;
			//int i = chatTable.IndexOf(messages[key].Block[0]);
			foreach (var message in messages)
			{
				DateTime temp = (DateTime)message.contents[dateFieldKey];
				if(temp.Date == key)
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


		#region search

		private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
		{
			searchBox.Text = "";
		}



		private void findButton_Click(object sender, EventArgs e)
		{
			FindClick?.Invoke(this, EventArgs.Empty);
			searchResults.Clear();
			if (searchBox.Text != "")
			{
				var stringQuery = searchBox.Text;


				if (stringQuery != "")
				{
					if (userList.CheckedItems.Count != 0)
					{
						List<string> users = new List<string>();
						foreach (ListViewItem item in userList.CheckedItems)
						{
							users.Add(item.Text);

						}
						SearchTextWithUser(stringQuery, users);

					}
					else
					{
						SearchText(stringQuery);
					}
					MessageBox.Show("Found " + searchResults.Count + " results.");
					DisplayResults();

				}
			}

		}
		private void SearchText(string stringQuery)
		{
			Query textQuery = textParser.Parse(stringQuery + "*");
			TopDocs temp = searcher.Search(textQuery, 50);
			for (int i = 0; i < temp.TotalHits; i++)
			{
				List<string> data = new List<string>();
				ScoreDoc d = temp.ScoreDocs[i];
				Document idoc = searcher.Doc(d.Doc);
				foreach (var field in selectedFields)
				{
					data.Add(idoc.GetField(field).GetStringValue());
				}
				DynamicMessage message = new DynamicMessage(data, selectedFields, dateFieldKey);
				searchResults.Add(message);
			}
		}
		private void SearchTextWithUser(string stringQuery, List<string> users)
		{
			Query textQuery = textParser.Parse(stringQuery + "*");

			FieldCacheTermsFilter userFilter = new FieldCacheTermsFilter(senderFieldKey, users.ToArray());

			var filter = new BooleanFilter();
			filter.Add(new FilterClause(userFilter, Occur.MUST));

			var hits = searcher.Search(textQuery, userFilter, 200).ScoreDocs;
			for (int i = 0; i < hits.Length; i++)
			{
				List<string> data = new List<string>();

				Document idoc = searcher.Doc(hits[i].Doc);

				foreach (var field in selectedFields)
				{
					data.Add(idoc.GetField(field).GetStringValue());
				}
				DynamicMessage message = new DynamicMessage(data, selectedFields, dateFieldKey);
				searchResults.Add(message);

			}
		}
		private void DisplayResults()
		{
			chatTable.SetObjects(searchResults);
			chatTable.Invalidate();
			
		}



		#endregion search

		private void generateNewToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}
	}
}

 