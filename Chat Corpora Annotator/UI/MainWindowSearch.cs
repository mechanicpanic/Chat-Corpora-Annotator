using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Viewer.Framework.MyEventArgs;
using Viewer.Framework.Views;

namespace Viewer
{
    public partial class MainWindow : Form, IMainView, ITagView, INotifyPropertyChanged
    {
        public void DisplaySearchResults()
        {
            chatTable.SetObjects(SearchResults);
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
                    //filters.Add(tagFilter);
                }
            }
            var compositeFilter = new CompositeAllFilter(filters);

            chatTable.ModelFilter = highlightingFilter;
            chatTable.AdditionalFilter = compositeFilter;
            highlightTextRenderer1.Filter = highlightingFilter;


        }

        private void LaunchSearch()
        {

            int count = IndexEngine.LuceneService.DirReader.MaxDoc;
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
    }
}
