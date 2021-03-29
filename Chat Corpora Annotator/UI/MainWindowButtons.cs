
using BrightIdeasSoftware;
using CSharpTest.Net.Collections;
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
        private ConcordanceEventArgs _argstrack;
        private void concordance_Click(object sender, EventArgs e)
        {
            if (concordanceBox.Text.Split().Length > 1 || String.IsNullOrEmpty(Concordance.Text) || String.IsNullOrWhiteSpace(concordanceBox.Text))
            {
                MessageBox.Show("Please enter a single term");
            }
            else
            {
                if (charSelectionBox.SelectedIndex != -1)
                {
                    ConcordanceEventArgs args = new ConcordanceEventArgs();
                    args.Term = concordanceBox.Text;
                    args.Chars = int.Parse(charSelectionBox.SelectedItem.ToString());
                    _argstrack = args;

                    ConcordanceClick?.Invoke(this, args);



                }
                else
                {
                    MessageBox.Show("Please select char length");
                }
            }
        }
        private string PadString(string line, string term, int count)
        {
            string left;
            string center;
            string right;
            int index = line.ToLower().IndexOf(term);
            if (index != -1)
            {
                left = line.Substring(0, index);
                center = line.Substring(index, term.Length);
                right = line.Substring(index + term.Length);
            }
            else
            {
                //left = null;
                //center = null;
                //right = null;
                return null;

            }

            if (!String.IsNullOrEmpty(left))
            {
                if (left.Length < count)
                {
                    left = left.PadLeft(count + 3);

                }
                else
                {
                    left = left.Remove(0, left.Length - count);
                    left = "..." + left;
                }
            }
            else
            {
                left = " ";
                left = left.PadLeft(count + 3);
            }

            if (!String.IsNullOrEmpty(right))
            {
                if (right.Length < count)
                {
                    right = right.PadRight(count + 3);
                }
                else
                {
                    var temp = right.Length - count;
                    right = right.Remove(right.Length - temp, temp);
                    right = right + "...";
                }
            }
            else
            {
                right = " ";

                right = right.PadRight(count);
            }

            return left + center + right;
        }
        public void DisplayConcordance(string[] con)
        {
            //richTextBox1.Lines = con;
            concordanceView.Text = "";
            List<string> newlines = new List<string>();
            newlines.Add("Displaying " + con.Length.ToString() + " matches:");
            foreach (var line in con)
            {
                var newline = PadString(line, _argstrack.Term, _argstrack.Chars);
                newlines.Add(newline);
            }
            foreach (var line in newlines)
            {
                concordanceView.AddText(line);
                concordanceView.AddText("\n");
            }



        }


        #endregion

        #region ngram
        private void ngram_Click(object sender, EventArgs e)
        {
            if (ngramSearchBox.Text.Split().Length > 1 || String.IsNullOrEmpty(ngramSearchBox.Text) || String.IsNullOrWhiteSpace(ngramSearchBox.Text))
            {
                MessageBox.Show("Please enter a single term");
            }
            else
            {
                NgramEventArgs args = new NgramEventArgs();
                args.Term = ngramSearchBox.Text;
                args.maxSize = 2;
                args.minSize = 3;
                args.ShowUnigrams = false;



                NGramClick?.Invoke(this, args);
            }
        }

        public void UpdateNgramState(bool state, bool readstate)
        {
            if (state && readstate)
            {
                ngramIndexButton.Visible = false;
                ngramSearchButton.Enabled = true;
            }
            else if (state && !readstate)
            {
                ngramIndexButton.Visible = true;
                ngramSearchButton.Visible = true;
                ngramIndexButton.Text = "Read index";
                ngramSearchButton.Enabled = false;
            }
            else if (!state && !readstate)
            {
                ngramIndexButton.Visible = true;
                ngramSearchButton.Visible = true;
                ngramIndexButton.Text = "Build index";
                ngramSearchButton.Enabled = false;
            }
        }

        public void DisplayNGrams(List<BTreeDictionary<string, int>> grams)
        {
            bigramView.ClearObjects();
            trigramView.ClearObjects();
            fourgramView.ClearObjects();
            fivegramView.ClearObjects();
            foreach (var kvp in grams[0])
            {
                bigramView.AddObject(kvp);
            }

            foreach (var kvp in grams[1])
            {
                trigramView.AddObject(kvp);
            }

            foreach (var kvp in grams[2])
            {
                fourgramView.AddObject(kvp);
            }
            foreach (var kvp in grams[3])
            {
                fivegramView.AddObject(kvp);
            }


            bigramView.Invalidate();
            trigramView.Invalidate();
            fourgramView.Invalidate();
            fivegramView.Invalidate();
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
            //keywordButton.Visible = false;
        }
        #endregion

        #endregion

        #region Tagging Buttons
        private void addTagButton_Click(object sender, EventArgs e)
        {

            if (tagsetView.SelectedItems.Count != 0 && chatTable.SelectedObjects.Count != 0)
            {
                TaggerEventArgs args = new TaggerEventArgs();
                args.Id = IndexEngine.SituationIndex.TagsetCounter[tagsetView.SelectedItems[0].Text];

                args.Tag = tagsetView.SelectedItems[0].Text;

                args.messages = new List<int>();

                foreach (var obj in chatTable.SelectedObjects)
                {
                    DynamicMessage msg = (DynamicMessage)obj;
                    args.messages.Add(msg.Id);


                }

                AddTag?.Invoke(this, args);

                //fastSituationView.Items.Add(args.Tag + " " + args.Id);
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
            string[] item = fastSituationView.SelectedObject.ToString().Split(' ');
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
            args.Tag = fastSituationView.SelectedObject.ToString().Split(' ')[0];
            args.Id = Int32.Parse(fastSituationView.SelectedObject.ToString().Split(' ')[1]);


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
