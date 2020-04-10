﻿using BrightIdeasSoftware;
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
        private QueryParser textParser;
        private QueryParser userParser;
        private StandardAnalyzer analyzer;
        private IndexReader reader;
        public SearchForm(List<string> selectedFields, string textFieldKey, string dateFieldKey, string indexDirectory, HashSet<string> userKeys)
        {

            InitializeComponent();
            this.selectedFields = selectedFields;
            this.textFieldKey = textFieldKey;
            this.dateFieldKey = dateFieldKey;

            var AppLuceneVersion = LuceneVersion.LUCENE_48;
            analyzer = new StandardAnalyzer(AppLuceneVersion);
            textParser = new QueryParser(AppLuceneVersion, textFieldKey, analyzer);

            var directory = FSDirectory.Open(indexDirectory);

            reader = DirectoryReader.Open(directory);
            searcher = new IndexSearcher(reader);

            

        }

        
        private void findButton_Click(object sender, EventArgs e)
        {
            
            if (searchBox.Text != "")
            {
                var stringQuery = searchBox.Text;
               

                if (stringQuery != "")
                {
                    Query textQuery = textParser.Parse(stringQuery + "*");
                    TopDocs temp = searcher.Search(textQuery, 50);
                    for (int i = 0; i < temp.TotalHits; i++)
                    {
                        List<string> data = new List<string>();
                        ScoreDoc d = temp.ScoreDocs[i];
                        float score = d.Score;
                        Document idoc = searcher.Doc(d.Doc);
                        foreach (var field in selectedFields)
                        {
                            data.Add(idoc.GetField(field).GetStringValue());
                        }
                        DynamicMessage message = new DynamicMessage(data, selectedFields, dateFieldKey);
                        searchResults.Add(message);
                    }
                    MessageBox.Show("Found " + temp.TotalHits + " results.");
                    DisplayResults();
                }
            }
        }

        private void FindMsgByUser(Query userQuery)
        {

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
                if (cl.Text != textFieldKey)
                {
                    cl.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                else
                {
                    cl.FillsFreeSpace = true;
                }
            }
            searchTable.RebuildColumns();
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
    }
}
