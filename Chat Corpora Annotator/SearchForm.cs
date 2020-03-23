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
        

        private string indexDirectory;
        private IndexSearcher searcher;
        private QueryParser parser;
        private StandardAnalyzer analyzer;
        private IndexReader reader;
        public SearchForm(List<string> selectedFields, string textFieldKey, string dateFieldKey, string indexDirectory)
        {

            InitializeComponent();
            this.selectedFields = selectedFields;
            this.textFieldKey = textFieldKey;
            this.dateFieldKey = dateFieldKey;

            var AppLuceneVersion = LuceneVersion.LUCENE_48;
            analyzer = new StandardAnalyzer(AppLuceneVersion);
            parser = new QueryParser(AppLuceneVersion, textFieldKey, analyzer);
            var directory = FSDirectory.Open(indexDirectory);

            reader = DirectoryReader.Open(directory);
            searcher = new IndexSearcher(reader);

        }

        private void findButton_Click(object sender, EventArgs e)
        {
            
            if (searchBox.Text != "")
            {
                var query = searchBox.Text;
                
                Query searchQuery = parser.Parse(query + "*");
                TopDocs temp = searcher.Search(searchQuery, 50);
                for(int i = 0; i < temp.TotalHits; i++)
                {
                    List<string> data = new List<string>();
                    ScoreDoc d = temp.ScoreDocs[i];
                    float score = d.Score;
                    Document idoc = searcher.Doc(d.Doc);
                    foreach(var field in selectedFields)
                    {
                        data.Add(idoc.GetField(field).GetStringValue());
                    }
                    DynamicMessage message = new DynamicMessage(data, selectedFields,  dateFieldKey);
                    searchResults.Add(message);
                }
                MessageBox.Show("Found " + temp.TotalHits + " results.");
                DisplayResults();
            }
        }

        private void DisplayResults()
        {
            searchTable.SetObjects(searchResults);
            List<OLVColumn> columns = new List<OLVColumn>();
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
            foreach(var cl in searchTable.AllColumns)
            {
                cl.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            searchTable.RebuildColumns();
        }

        private void SearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            reader.Dispose();
        }
    }
}
