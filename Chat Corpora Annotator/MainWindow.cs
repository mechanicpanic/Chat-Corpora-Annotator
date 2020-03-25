using BrightIdeasSoftware;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Concurrent;

using Wintellect.PowerCollections;
using CSharpTest.Net.Collections;
using SoftCircuits.CsvParser;
using Lucene.Net;
using Lucene.Net.Util;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;


namespace Chat_Corpora_Annotator
{
	public partial class MainWindow : Form
	{
		#region fields
		public string csvPath;
		private string indexPath;

		public string[] allFields;
		public List<string> selectedFields = new List<string>();

		private string dateFieldKey;
		private string senderFieldKey;
		private string textFieldKey;


		private Random rnd = new Random();

		private HashSet<string> userKeys = new HashSet<string>();
		private Dictionary<string, Color> userColors = new Dictionary<string, Color>();

	   
		private List<DynamicMessage> messages = new List<DynamicMessage>();
		private BTreeDictionary<DateTime, int> messagesPerDay = new BTreeDictionary<DateTime, int>();
		//private ConcurrentDictionary<DateTime,int> messagesPerDay = new ConcurrentDictionary<DateTime,int>();
  
		List<Color> heatMapColors = new List<Color>();
	   

		
		FSDirectory dir;
		IndexWriterConfig indexConfig;
		IndexWriter writer;
		DirectoryReader reader;
		int readerIndex = 0;

		StandardAnalyzer analyzer;
		#endregion

		
		public MainWindow()
		{
			InitializeComponent();
			

		}
		private void MainWindow_Load(object sender, EventArgs e)
		{


		}


		#region csv loading
		private void csvLoadButton_Click(object sender, EventArgs e)
		{
			openCsvDialog();
			csvDialog.ShowDialog();
		}
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
				SelectFields();
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
				List<string> temp = new List<string>();
				var document = reader.Document(i);
				foreach (var field in selectedFields)
				{

					temp.Add(document.GetField(field).GetStringValue());
				}
				DynamicMessage message = new DynamicMessage(temp, selectedFields, dateFieldKey);
				messages.Add(message);
				readerIndex = n;

			}

		}


		#endregion

		#region header 
		private void SelectFields()
		{
			using (var parser = new TextFieldParser(csvPath))
			{
				parser.SetDelimiters(",");

				allFields = parser.ReadFields();
			}


			HeaderForm hf = new HeaderForm();
			AddOwnedForm(hf);
			hf.Show();
			hf.UpdateLabel(Path.GetFileName(csvPath));
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
			var AppLuceneVersion = LuceneVersion.LUCENE_48;

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
			}

		}
		private void PopulateIndex()
		{

			if (selectedFields != null)
				SetUpIndex();
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
				label1.Text = count.ToString() + " messages";
				DateTime date;

				//TODO: Redesign this urgently.
				var dateIndex = Array.IndexOf(allFields, dateFieldKey);
				var senderIndex = Array.IndexOf(allFields, senderFieldKey);
				var textIndex = Array.IndexOf(allFields, textFieldKey);

				row = null;
				
				using (var csv = new CsvReader(csvPath))
				{
					csv.ReadRow(ref row); //header read;


					while (csv.ReadRow(ref row))
					//Parallel.For(1, count, j =>
					 {
						 csv.ReadRow(ref row);
						 ArrayMessage message = new ArrayMessage(row, allFields, selectedFields, dateFieldKey);


						 date = DateTime.Parse(row[dateIndex]);
						 userKeys.Add(row[senderIndex]);


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

						 for (int i = 0; i < selectedFields.Count; i++)
						 {
							 int textindex = Array.IndexOf(selectedFields.ToArray(), textFieldKey);
							 int dateindex = Array.IndexOf(selectedFields.ToArray(), dateFieldKey);
							 if (i != textindex && i != dateindex)
							 {
								 document.Add(new StringField(selectedFields[i], message.Contents[i], Field.Store.YES));
							 }
							 else if (i == textindex)
							 {
								 document.Add(new TextField(selectedFields[i], message.Contents[i], Field.Store.YES));
							 }
							 else
							 {
								 var temp = DateTools.DateToString(date, DateTools.Resolution.MINUTE);
								 document.Add(new StringField(selectedFields[i], temp, Field.Store.YES));
							 }
						 }

						 writer.AddDocument(document);

					 }
					writer.Commit();
					writer.Flush(triggerMerge: false, applyAllDeletes: false);
					writer.Dispose();
				}

				
				DataLoaded();
				reader = DirectoryReader.Open(dir);



			}
		}
		private void DataLoaded()
		{
			DataLoaded dl = new DataLoaded();
			dl.Show();
			dl.OKButtonClicked += new EventHandler(DataLoadedButtonHandler);
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
				LoadSomeDocuments(50);
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

		private void chartButton_Click(object sender, EventArgs e)
		{
			ChartForm cf = new ChartForm();
			cf.InitializeChart(messagesPerDay.Keys.ToList(), messagesPerDay.Values.ToList());

		}

		private void heatMapButton_Click(object sender, EventArgs e)
		{
			//MessageBox.Show("Broken!");
			PopulateHeatmap();
			LinearHeatmapForm swf = new LinearHeatmapForm();
			swf.InitializeHeatMap(heatMapColors);
			swf.Show();
			swf.DrawHeatMap();
			swf.Draw();
		}

		private void searchButton_Click(object sender, EventArgs e)
		{
			SearchForm sf = new SearchForm(selectedFields, textFieldKey, dateFieldKey, indexPath);
			sf.Show();
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
			RetrieveVirtualItemEventHandler handler = new RetrieveVirtualItemEventHandler(this.dateView_RetrieveVirtualItem);
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

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void loadMoreButton_Click(object sender, EventArgs e)
		{
			LoadSomeDocuments(100);
			chatTable.UpdateObjects(messages);
		}
	}
}

