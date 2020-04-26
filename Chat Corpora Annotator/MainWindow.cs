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
		Random rnd = new Random();
		#region IMainView

		public event EventHandler OpenIndexedCorpus;
		public event EventHandler ChartClick;
		public event EventHandler HeatmapClick;
		public event EventHandler FileAndIndexSelected;
		public event LuceneQueryEventHandler FindClick;
		public event EventHandler LoadMoreClick;


		List<string> IMainView.Users { get; set; }
		public string CurrentPath { get; set; }
		public string CurrentIndexPath { get; set; }

		private List<DynamicMessage> _messages;
		public List<DynamicMessage> Messages { get { return _messages; } set { _messages = value; } }

		public List<DynamicMessage> SearchResults { get; set; }

		

		public void SetLineCount(int count)
		{
			messageLabel.Text = count.ToString() + " messages";
		}

		public void DisplayDocuments()
		{
			chatTable.SetObjects(_messages);
			SetUpChatView();
			chatTable.UpdateObjects(this.Messages);
			chatTable.Invalidate();
		}
		public void DisplaySearchResults()
		{
			chatTable.SetObjects(SearchResults);
			SetUpChatView();
			chatTable.Invalidate();
		}

		void IView.ShowView()
		{
			ShowDialog();
		}

		new public void CloseView()
		{
			this.CloseView();
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

		private void loadCorpusToolStripMenuItem_Click(object sender, EventArgs e)
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
			//csvPath = csvDialog.FileName;
			this.CurrentPath = csvDialog.FileName;
			SelectIndexFolder();

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
			//PopulateSenderColors();
			

			List<OLVColumn> columns = new List<OLVColumn>();

			foreach (var key in _messages[0].contents.Keys)
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


			//FormatColumns();

		}

		//private void FormatColumns()
		//{
		//	foreach (var cl in chatTable.AllColumns)
		//	{
		//		if (cl.Text != textFieldKey)
		//		{
		//			cl.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
		//		}
		//		else
		//		{
		//			cl.FillsFreeSpace = true;
		//		}
		//	}
		//	chatTable.FormatCell += ChatTable_FormatCell;
		//	chatTable.Refresh();

		//}
		//private void PopulateSenderColors()
		//{
		//	foreach (var user in userKeys)
		//	{
		//		Color tempColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
		//		userColors.Add(user, tempColor);
		//	}
		//}
		//private void ChatTable_FormatCell(object sender, FormatCellEventArgs e)
		//{
		//	if (e.Column.Text == senderFieldKey)
		//	{
		//		e.SubItem.ForeColor = userColors[e.SubItem.Text];
		//	}

		//}




		#endregion



		#region event pipelining
		private void plotToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChartClick?.Invoke(this, EventArgs.Empty);
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
		//public Color HeatMapColor(double value, double min, double max)
		//{
		//	double val = (value - min) / (max - min);
		//	int r = Convert.ToByte(255 * val);
		//	int g = Convert.ToByte(255 * (1 - val));
		//	int b = 10;

		//	return Color.FromArgb(255, r, g, b);
		//}
		//private void PopulateHeatmap()
		//{


		//	double max = messagesPerDay.Values.Max();
		//	double min = messagesPerDay.Values.Min();

		//	double temp = 998 / messagesPerDay.Keys.Count;
		//	if (temp >= 10.0)
		//	{
		//		foreach (var date in messagesPerDay.Keys)
		//		{
		//			double x = messagesPerDay[date];
		//			heatMapColors.Add(HeatMapColor(x, min, max));
		//		}
		//	}
		//	else
		//	{
		//		DateTime[] days = new DateTime[messagesPerDay.Keys.Count];

		//		messagesPerDay.Keys.CopyTo(days, 0);
		//		//Array.Sort(days);

		//		double block = (messagesPerDay.Keys.Count / 998.0) * 10.0;

		//		int blockDayCount = (int)Math.Floor(block);
		//		List<double> newCounts = new List<double>();
		//		double x = 0;
		//		int count = 0;
		//		int index = 0;
		//		while(index < days.Length)
		//		{
		//			if (days.Length - index > blockDayCount)
		//			{
		//				while (count < blockDayCount)
		//				{
		//					x += messagesPerDay[days[index]];
		//					index++;
		//					count++;
		//				}
		//				if (count == blockDayCount)
		//				{
		//					x += messagesPerDay[days[index]];
		//					newCounts.Add(x);
		//					count = 0;
		//					x = 0;
		//					index++;
		//				}
		//			}
		//			else
		//			{
		//				x += messagesPerDay[days[index]];
		//				index++;
		//				if(index == days.Length - 1)
		//				{
		//					newCounts.Add(x);
		//				}
		//			}

		//		}

		//		var newmax = newCounts.Max();
		//		var newmin = newCounts.Min();

		//		foreach (var cc in newCounts)
		//		{
		//			heatMapColors.Add(HeatMapColor(cc, newmin, newmax));
		//		}

		//	}
		//}
		#endregion

		#region date view
		//public void SetDateView()
		//{
		//	dateView.View = View.Details;
		//	dateView.VirtualMode = true;
		//	dateView.VirtualListSize = messagesPerDay.Keys.Count;
		//	//dateView.DoubleBuffering(true);
		//	RetrieveVirtualItemEventHandler handler = new RetrieveVirtualItemEventHandler(dateView_RetrieveVirtualItem);
		//	dateView.RetrieveVirtualItem += handler;


		//}

		//private void dateView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
		//{
		//	int index = e.ItemIndex;
		//	string date = messagesPerDay.Keys.ElementAt<DateTime>(index).ToShortDateString();


		//	e.Item = new ListViewItem(date);

		//}


		//private void dateView_MouseDoubleClick(object sender, MouseEventArgs e)
		//{
		//	ListView lw = sender as ListView;

		//	ListView.SelectedIndexCollection index = dateView.SelectedIndices;
		//	string date = dateView.Items[index[0]].SubItems[0].Text;
		//	DateTime key = DateTime.Parse(date);

		//	int i = -1;
		//	//int i = chatTable.IndexOf(messages[key].Block[0]);
		//	foreach (var message in messages)
		//	{
		//		DateTime temp = (DateTime)message.contents[dateFieldKey];
		//		if(temp.Date == key)
		//		{
		//			i = chatTable.IndexOf(message);
		//			break;
		//		}

		//	}
		//	if (i != -1)
		//	{
		//		var item = chatTable.GetItem(i);
		//		chatTable.SelectedItem = item;
		//		chatTable.EnsureVisible(chatTable.GetItemCount() - 1);
		//		chatTable.EnsureVisible(i);
		//	}
		//	else
		//	{
		//		MessageBox.Show("Broken!");
		//	}

		//}

		#endregion

		#region search

		private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
		{
			searchBox.Text = "";
		}



		private void findButton_Click(object sender, EventArgs e)
		{
			List<string> users = new List<string>();
			List<string> dates = new List<string>();
			//searchResults.Clear();
			if (searchBox.Text != "")
			{
				var stringQuery = searchBox.Text;
				if (!checkBox1.Checked && !checkBox2.Checked)
				{
					FindClick?.Invoke(this, new LuceneQueryEventArgs(stringQuery, 50, false));
				}
				else if (checkBox1.Checked && !checkBox2.Checked) {
					if (userList.CheckedItems.Count != 0)
					{
						users.Clear();
						foreach (ListViewItem item in userList.CheckedItems)
						{
							users.Add(item.Text);

						}
						FindClick?.Invoke(this, new LuceneQueryEventArgs(stringQuery, 50, users.ToArray(), false));
					}
				}
				else if (!checkBox1.Checked && checkBox2.Checked) {

					if(startDate.Checked && finishDate.Checked)
					{
						DateTime[] date = new DateTime[2];
						date[0] = startDate.Value;
						date[1] = finishDate.Value;
						FindClick?.Invoke(this, new LuceneQueryEventArgs(stringQuery, 50, date, false));
					}
										
				}
				else if (checkBox1.Checked && checkBox2.Checked) {
					MessageBox.Show("Not implemented yet");

				}
				//if (userList.CheckedItems.Count != 0)
				//{
				//	List<string> users = new List<string>();
				//	foreach (ListViewItem item in userList.CheckedItems)
				//	{
				//		users.Add(item.Text);

				//	}
				//	SearchTextWithUser(stringQuery, users);

				//}
				//else
				//{
				//	SearchText(stringQuery);
				//}
				//MessageBox.Show("Found " + searchResults.Count + " results.");
				//DisplayResults();


			}

			//}
			//private void SearchText(string stringQuery)
			//{
			//	Query textQuery = textParser.Parse(stringQuery + "*");
			//	TopDocs temp = searcher.Search(textQuery, 50);
			//	for (int i = 0; i < temp.TotalHits; i++)
			//	{
			//		List<string> data = new List<string>();
			//		ScoreDoc d = temp.ScoreDocs[i];
			//		Document idoc = searcher.Doc(d.Doc);
			//		foreach (var field in selectedFields)
			//		{
			//			data.Add(idoc.GetField(field).GetStringValue());
			//		}
			//		DynamicMessage message = new DynamicMessage(data, selectedFields, dateFieldKey);
			//		searchResults.Add(message);
			//	}
			//}
			//private void SearchTextWithUser(string stringQuery, List<string> users)
			//{
			//	Query textQuery = textParser.Parse(stringQuery + "*");

			//	FieldCacheTermsFilter userFilter = new FieldCacheTermsFilter(senderFieldKey, users.ToArray());

			//	var filter = new BooleanFilter();
			//	filter.Add(new FilterClause(userFilter, Occur.MUST));

			//	var hits = searcher.Search(textQuery, userFilter, 200).ScoreDocs;
			//	for (int i = 0; i < hits.Length; i++)
			//	{
			//		List<string> data = new List<string>();

			//		Document idoc = searcher.Doc(hits[i].Doc);

			//		foreach (var field in selectedFields)
			//		{
			//			data.Add(idoc.GetField(field).GetStringValue());
			//		}
			//		DynamicMessage message = new DynamicMessage(data, selectedFields, dateFieldKey);
			//		searchResults.Add(message);

			//	}
			//}
			//private void DisplayResults()
			//{
			//	chatTable.SetObjects(searchResults);
			//	chatTable.Invalidate();

			//}



			#endregion search


		}

	}
}

 