using Lucene.Net.Documents;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using SoftCircuits.CsvParser;
using Lucene.Net.Util;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Analysis.Standard;

namespace Chat_Corpora_Annotator.Framework
{
    public interface IHeatmapService
    {
        void DrawHeatmap();
        void CalculateData();

    }
    public interface ICSVReadService
    {
        string[] GetFields(string path);
        int GetLineCount(string path);

        
    }

    public interface IIndexService
    {
        LuceneVersion AppLuceneVersion { get; }
        FSDirectory Dir { get; set; }
        IndexWriterConfig IndexConfig { get; set; }
        IndexWriter Writer { get; set; }
        DirectoryReader DirReader { get; set; }

       StandardAnalyzer Analyzer { get; set; }
        void SetUpIndex(string indexPath);
        void PopulateIndex(string indexPath);

        void LoadSomeDocuments(string indexPath, int count);
        
    }
    public interface ISearchService
    {
        
        List<DynamicMessage> SearchText(string query, QueryParser parser, IndexSearcher searcher);
        List<DynamicMessage> SearchText_UserFilter(string query, string[] users);
        List<DynamicMessage> SearchText_DateFilter(string query, string start, string finish);
    }

    public class HeatmapService: IHeatmapService
    {
        public void DrawHeatmap() { }
        public void CalculateData() { }
    }

    public class SearchService : ISearchService
    {

        public List<DynamicMessage> SearchText(string query, QueryParser parser, IndexSearcher searcher)
        {
            throw new NotImplementedException();
        }

        public List<DynamicMessage> SearchText_DateFilter(string query, string start, string finish)
        {
            throw new NotImplementedException();
        }

        public List<DynamicMessage> SearchText_UserFilter(string query, string[] users)
        {
            throw new NotImplementedException();
        }
    }

    public class CSVReadService : ICSVReadService
    {
        public string[] GetFields(string path)
        {
            string[] allFields;
            using (var parser = new TextFieldParser(path))
            {
                parser.SetDelimiters(","); //TODO: Delimiter select

                allFields = parser.ReadFields();
            }
            return allFields;
        }

        public int GetLineCount(string path)
        {
            string[] row = null;
            int count = 0;
            using (var csv = new CsvReader(path))
            {
                csv.ReadRow(ref row); //header read;
                while (csv.ReadRow(ref row))
                {
                    count++;
                }
            }
            return count;
        }

       
    }
}
