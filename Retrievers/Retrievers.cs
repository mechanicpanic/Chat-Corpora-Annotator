﻿using ExtractingServices;
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

        public static List<int> HasWordOfList(List<string> words)
        {
            HashSet<int> results = new HashSet<int>();
            foreach (var word in words)
            {
                TermQuery query = new TermQuery(new Lucene.Net.Index.Term(word));
                BooleanQuery boolquery = new BooleanQuery();
                boolquery.Add(query, Occur.MUST);
                TopDocs docs = LuceneService.Searcher.Search(boolquery, LuceneService.DirReader.MaxDoc);
                foreach (var doc in docs.ScoreDocs)
                {
                    Document idoc = LuceneService.Searcher.IndexReader.Document(doc.Doc);
                    results.Add(idoc.GetField("id").GetInt32Value().Value);
                }


            }
            List<int> ret = results.ToList();
            return ret;

        }
        public static List<int> HasNERTag(NER tag)
        {
            //Syntactic sugar for the B-trees in the Extractor class. 
            List<int> result = new List<int>();
            switch (tag)
            {
                case NER.ORG:
                    if(Extractor.OrgList.Keys.Count != 0)
                    {
                        foreach(var temp in Extractor.OrgList.Keys.ToList())
                        {
                            result.Add(temp);
                        }
                        return result;
                        
                    }
                    else
                    {
                        result.Add(-1);
                        return result;
                        //
                    }
                case NER.LOC:
                    if (Extractor.LocList.Keys.Count != 0)
                    {
                        foreach(var temp in Extractor.LocList.Keys.ToList())
                        {
                            result.Add(temp);
                        }
                        return result;
                    }
                    else
                    {
                        result.Add(-1);
                        return result;
                        //
                    }
                case NER.TIME:
                    if (Extractor.TimeList.Keys.Count != 0)
                    {
                        foreach (var temp in Extractor.TimeList.Keys.ToList())
                        {

                        }
                            return result;
                    }
                    else
                    {
                        result.Add(-1);
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
                        result.Add(-1);
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
                        result.Add(-1);
                        return result;
                        
                    }
            }
            throw new ArgumentException();

        }
                          
        public static List<int> HasQuestion()
        {
            List<int> result = new List<int>();
            if(Extractor.IsQuestionList.Count != 0)
            {
                return Extractor.IsQuestionList;
            }
            else
            {
                result.Add(-1);
                return result;
            }
        }
                          
        public static List<int> HasUser(string user)
        {
            user = user.Remove(0, 1);
            user = user.Remove(user.Length - 1, 1);
            //Love duplicate code
            HashSet<int> results = new HashSet<int>();
            TermQuery query = new TermQuery(new Lucene.Net.Index.Term(IndexService.SenderFieldKey,user));
            BooleanQuery boolquery = new BooleanQuery();
            boolquery.Add(query, Occur.MUST);
            TopDocs docs = LuceneService.Searcher.Search(boolquery, LuceneService.DirReader.MaxDoc);
            foreach (var doc in docs.ScoreDocs)
            {
                Document idoc = LuceneService.Searcher.IndexReader.Document(doc.Doc);
                results.Add(idoc.GetField("id").GetInt32Value().Value);
            }
            List<int> ret = results.ToList();
            return ret;
        }
                          
        public static List<int> HasUserMentioned(string user)
        {
            //Or I can check each and every message out of millions for a substring occurence :^)
            user = user.Remove(0, 1);
            user = user.Remove(user.Length - 1, 1);
            HashSet<int> results = new HashSet<int>();
            Query query = LuceneService.Parser.Parse(user);
            TopDocs docs = LuceneService.Searcher.Search(query, LuceneService.DirReader.MaxDoc);
            foreach (var doc in docs.ScoreDocs)
            {
                Document idoc = LuceneService.Searcher.IndexReader.Document(doc.Doc);
                results.Add(idoc.GetField("id").GetInt32Value().Value);
            }
            List<int> ret = results.ToList();
            return ret;
        }


    }
}