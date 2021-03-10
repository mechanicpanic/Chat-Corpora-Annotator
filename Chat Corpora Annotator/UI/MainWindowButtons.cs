
using BrightIdeasSoftware;
using IndexEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Viewer.Framework.Views;
using Viewer.UI;


namespace Viewer
{
    public partial class MainWindow : Form, IMainView, ITagView, INotifyPropertyChanged
    {
		#region Instrument Buttons and Creators
		private void statistics_Click(object sender, EventArgs e)
		{
			LoadStatistics?.Invoke(this, EventArgs.Empty);

		}
        #region concordance
        private void concordance_Click(object sender, EventArgs e)
		{
			ConcordanceClick?.Invoke(this, EventArgs.Empty);
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
        #endregion

        #region ngram
        private void ngram_Click(object sender, EventArgs e)
		{
			NGramClick?.Invoke(this, EventArgs.Empty);
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
        #endregion

        #region keyword
        private void keyword_Click(object sender, EventArgs e)
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
		#endregion

		#endregion

		#region Tagging Buttons
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

        #endregion

        #region StatusStrip Buttons
        private void suggester_Click(object sender, EventArgs e)
		{
			ShowSuggester?.Invoke(this, EventArgs.Empty);
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
		#endregion

		#region MenuStrip Buttons
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
		private void extractToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ExtractInfoClick?.Invoke(this, EventArgs.Empty);
		}
		private void loadCorpusToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openCsvDialog();
			csvDialog.ShowDialog();

		}
		private void plotToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//ChartClick?.Invoke(this, EventArgs.Empty);
		}

		private void heatmapToolStripMenuItem_Click(object sender, EventArgs e)
		{

			HeatmapClick?.Invoke(this, EventArgs.Empty);

		}
		#endregion

		#region Search Panel Buttons
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
		#endregion
	}
}
