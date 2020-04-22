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

    public interface ICSVReadService
    {
        //Dictionary<string, int> MessagesPerDay { get; set; }
        string[] GetFields(string path);
        int GetLineCount(string path);


        
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
