using IndexEngine;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Index;

namespace IndexEngine
{
    public static class Retrievers
    {
        public static List<string> HasWordOfList(List<string> words)
        {
            HashSet<string> results = new HashSet<string>();
            foreach (var word in words)
            {
                TermQuery query = new TermQuery(new Lucene.Net.Index.Term(word));
                BooleanQuery boolquery = new BooleanQuery();
                boolquery.Add(query, Occur.MUST);
                TopDocs docs = LuceneService.Searcher.Search(boolquery, LuceneService.DirReader.MaxDoc);
                foreach (var doc in docs.ScoreDocs)
                {
                    Document idoc = LuceneService.Searcher.IndexReader.Document(doc.Doc);
                    results.Add(idoc.GetField("id").GetStringValue());
                }


            }
            List<string> ret = results.ToList();
            return ret;

        }

    }
}
