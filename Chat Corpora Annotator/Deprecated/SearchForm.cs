using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lucene.Net.Search;

using Lucene.Net.Queries;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Util;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Documents;

namespace Chat_Corpora_Annotator
{
    public partial class SearchForm : Form
    {
        private List<DynamicMessage> searchResults = new List<DynamicMessage>();

        private List<string> selectedFields;
        private string textFieldKey;
        private string dateFieldKey;
        private string senderFieldKey;



        private IndexSearcher searcher;
        private QueryParser textParser;

        private StandardAnalyzer analyzer;
        private IndexReader reader;
        List<OLVColumn> columns;
        public SearchForm(List<string> selectedFields, string textFieldKey, string dateFieldKey, string indexDirectory, string senderFieldKey, HashSet<string> userKeys)
        {

            InitializeComponent();
            this.selectedFields = selectedFields;
            this.textFieldKey = textFieldKey;
            this.dateFieldKey = dateFieldKey;
            this.senderFieldKey = senderFieldKey;

            var AppLuceneVersion = LuceneVersion.LUCENE_48;
            analyzer = new StandardAnalyzer(AppLuceneVersion);
            textParser = new QueryParser(AppLuceneVersion, textFieldKey, analyzer);

            var directory = FSDirectory.Open(indexDirectory);

            reader = DirectoryReader.Open(directory);
            searcher = new IndexSearcher(reader);



            columns = new List<OLVColumn>();

            foreach (var key in selectedFields)
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
            searchTable.AllColumns.AddRange(columns);

            searchTable.RebuildColumns();
            
            foreach(var user in userKeys)
            {
                listView1.Items.Add(user);
            }

            searchBox.AutoSize = false;


        }

        
        private void findButton_Click(object sender, EventArgs e)
        {
            searchResults.Clear();
            if (searchBox.Text != "")
            {
                var stringQuery = searchBox.Text;
               

                if (stringQuery != "")
                {
                    if (listView1.CheckedItems.Count != 0)
                    {
                        List<string> users = new List<string>();
                        foreach (ListViewItem item in listView1.CheckedItems)
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
            PhraseQuery textQuery = (PhraseQuery)textParser.Parse(stringQuery + "*");
            FieldCacheTermsFilter userFilter = new FieldCacheTermsFilter(senderFieldKey, users.ToArray());
            var filter = new BooleanFilter();
            filter.Add(new FilterClause(userFilter, Occur.MUST));
            var hits = searcher.Search(textQuery,userFilter,200).ScoreDocs;
            for (int i = 0; i < hits.Length; i++)
            {
                List<string> data = new List<string>();

                //ScoreDoc d = temp.ScoreDocs[i];
                //float score = d.Score;
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
            searchTable.SetObjects(searchResults);
            FormatColumns();
            HighlightQuery();
        }

        private void FormatColumns()
        {
            foreach (var cl in searchTable.AllColumns)
            {
                if (cl.Text != textFieldKey)
                {
                    cl.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    cl.Searchable = false;
                }
                else
                {
                    cl.FillsFreeSpace = true;
                }
            }
            

        }
        private void HighlightQuery()
        {
            List<string> query = new List<string>();
            List<OLVColumn> columns = new List<OLVColumn>();

            query.Add(searchBox.Text);
            //columns.Add(searchTable.AllColumns.Find(x => x.Text == textFieldKey));
            TextMatchFilter highlightingFilter = TextMatchFilter.Contains(searchTable, query.ToArray());
            
            //highlightingFilter.Columns = columns.ToArray();
            
            searchTable.ModelFilter = highlightingFilter;
            searchTable.DefaultRenderer = new HighlightTextRenderer(highlightingFilter);
        }

        private void SearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            reader.Dispose();
        }

        private void searchTable_Resize(object sender, EventArgs e)
        {
            searchTable.Invalidate();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchBox_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
