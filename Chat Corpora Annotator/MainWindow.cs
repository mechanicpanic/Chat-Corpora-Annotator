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


		public List<string> Usernames { get; set; }
		public string CurrentPath { get; set; }
		public string CurrentIndexPath { get; set; }

		private List<DynamicMessage> _messages;
		private Dictionary<string,Color> userColors;

		public List<DynamicMessage> Messages { get { return _messages; } set { _messages = value; } }

		public List<DynamicMessage> SearchResults { get; set; }
		public BTreeDictionary<DateTime, int> MessagesPerDay { get; set; }
		public bool FileLoadState { get; set ; }
		public string TextFieldKey { get; set; }
		public string DateFieldKey { get; set; }
		public string SenderFieldKey { get; set; }

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
			

			ShowUsers();
			PopulateSenderColors();
			SetDateView();
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
			chatTable.AllColumns.Clear();
			chatTable.AllColumns.AddRange(columns);
			chatTable.RebuildColumns();


			FormatColumns();

		}

		private void ShowUsers()
		{
			userList.CheckBoxes = true;
			foreach(var user in Usernames)
			{
				userList.Items.Add(new ListViewItem(user));
			}

		}

		private void FormatColumns()
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
			foreach (var user in Usernames)
			{
				Color tempColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
				userColors.Add(user, tempColor);
			}
		}
		private void ChatTable_FormatCell(object sender, FormatCellEventArgs e)
		{
			if (e.Column.Text == SenderFieldKey)
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
			dateView.VirtualMode = true;
			dateView.VirtualListSize = MessagesPerDay.Keys.Count;
			//dateView.DoubleBuffering(true);
			RetrieveVirtualItemEventHandler handler = new RetrieveVirtualItemEventHandler(dateView_RetrieveVirtualItem);
			dateView.RetrieveVirtualItem += handler;


			}

		private void dateView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
		{
			int index = e.ItemIndex;
			string date = MessagesPerDay.Keys.ElementAt<DateTime>(index).ToShortDateString();
			e.Item = new ListViewItem(date);

		}


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
			List<string> users = new List<string>();
			List<string> dates = new List<string>();
			var stringQuery = searchBox.Text;
			if (!userToggle.Checked && !dateToggle.Checked)
			{
				FindClick?.Invoke(this, new LuceneQueryEventArgs(stringQuery, 50, false));
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
					FindClick?.Invoke(this, new LuceneQueryEventArgs(stringQuery, 50, users.ToArray(), false));
				}
			}
			else if (!userToggle.Checked && dateToggle.Checked)
			{

				if (startDate.Checked && finishDate.Checked)
				{
					DateTime[] date = new DateTime[2];
					date[0] = startDate.Value;
					date[1] = finishDate.Value;
					FindClick?.Invoke(this, new LuceneQueryEventArgs(stringQuery, 50, date, false));
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
				FindClick?.Invoke(this, new LuceneQueryEventArgs(stringQuery,50,users.ToArray(),date,false));

			}
		}

		private void clearButton_Click(object sender, EventArgs e)
		{
			chatTable.SetObjects(_messages);
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
	}
}

 