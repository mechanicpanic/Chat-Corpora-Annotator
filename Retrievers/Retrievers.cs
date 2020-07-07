using ExtractingServices;
using IndexEngine;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrievers
{
    public enum NER
    {
        ORG,
        LOC,
        TIME,
        URL,
        DATE
    }
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
        public static List<string> HasNERTag(NER tag)
        {
            //Syntactic sugar for the B-trees in the Extractor class. 
            List<string> result = new List<string>();
            switch (tag)
            {
                case NER.ORG:
                    if(Extractor.OrgList.Keys.Count != 0)
                    {
                        return Extractor.OrgList.Keys.ToList();
                    }
                    else
                    {
                        result.Add("-1");
                        return result;
                        //
                    }
                case NER.LOC:
                    if (Extractor.LocList.Keys.Count != 0)
                    {
                        
                        return Extractor.LocList.Keys.ToList();
                    }
                    else
                    {
                        result.Add("-1");
                        return result;
                        //
                    }
                case NER.TIME:
                    if (Extractor.TimeList.Keys.Count != 0)
                    {
                        
                        return Extractor.TimeList.Keys.ToList();
                    }
                    else
                    {
                        result.Add("-1");
                        return result;
                        //
                    }
                case NER.URL:
                    if (Extractor.URLList.Keys.Count != 0)
                    {

                        return Extractor.URLList.Keys.ToList();
                    }
                    else
                    {
                        result.Add("-1");
                        return result;
                        //
                    }
                case NER.DATE:
                    if (Extractor.DateList.Keys.Count != 0)
                    {
                        return Extractor.DateList.Keys.ToList();
                         
                    }
                    else
                    {
                        result.Add("-1");
                        return result;
                        
                    }
            }
            throw new ArgumentException();

        }

        public static List<string> HasQuestion()
        {
            List<string> result = new List<string>();
            if(Extractor.IsQuestionList.Count != 0)
            {
                return Extractor.IsQuestionList;
            }
            else
            {
                result.Add("-1");
                return result;
            }
        }

        public static List<string> HasUser(string user)
        {
            return null;
            
        }

    }
}
