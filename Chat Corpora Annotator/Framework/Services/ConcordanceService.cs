﻿using Lucene.Net.Search;
using Lucene.Net.Documents;
using Lucene.Net.Search.Spans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Framework.Services
{
    public interface IConcordanceService
    {
        Query ConQuery { get; set; }
        List<string> Concordance { get; set; }
        void FlushConcordanceToDisk();
        void FindConcordance(string query, string TextFieldKey, int count);
    }
    public class ConcordanceService : IConcordanceService
    {
        public Query ConQuery { get; set; }
        public List<string> Concordance { get; set; }

        public void FindConcordance(string query, string TextFieldKey, int count)
        {
            Concordance = new List<string>();
            TopDocs Hits = LuceneService.Searcher.Search(ConQuery, count);
            for (int i = 0; i < Hits.TotalHits; i++)
            {
                
                ScoreDoc d = Hits.ScoreDocs[i];
                Document idoc = LuceneService.Searcher.Doc(d.Doc);
                Concordance.Add(idoc.GetField(TextFieldKey).GetStringValue());
                
                
            }


        }

        public void FlushConcordanceToDisk()
        {
            throw new NotImplementedException();
        }
    }
}