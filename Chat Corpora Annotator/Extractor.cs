using CSharpTest.Net.Collections;
using edu.stanford.nlp.pipeline;
using IndexingServices;
using java.io;
using java.util;
using System;
using System.Collections.Generic;

namespace Viewer
{
    public class Extractor
    {
        BTreeDictionary<string, bool> CodeStopWords { get; set; }
        BTreeDictionary<string, string> DateList { get; set; } = new BTreeDictionary<string, string>();
        BTreeDictionary<string, string> TimeList { get; set; } = new BTreeDictionary<string, string>();
        BTreeDictionary<string, string> OrgList { get; set; } = new BTreeDictionary<string, string>();
        BTreeDictionary<string, string> LocList { get; set; } = new BTreeDictionary<string, string>();

        BTreeDictionary<string, List<string>> NounList { get; set; } = new BTreeDictionary<string, List<string>>();
        public CoreAnalyzer _analyzer { get; set; }
        public StanfordCoreNLP pipe { get; set; }
        public Extractor(CoreAnalyzer analyzer)
        {
            this._analyzer = analyzer;
            pipe = _analyzer.SimplePipeline();

        }

        private CoreDocument GetAnnotatedDocument(string text)
        {
            CoreDocument coredoc = new CoreDocument(text);
            pipe.annotate(coredoc);
            return coredoc;
        }
        //public bool DetectMeeting()
        //{

        //}
        //public bool DetectCodeHelp()
        //{

        //}
        //public bool DetectAssistance() { }

        private void ExtractNERTags(CoreDocument coredoc, Lucene.Net.Documents.Document document)
        {
            List nerList = coredoc.entityMentions();
            for (int j = 0; j < nerList.size(); j++)
            {
                CoreEntityMention em = (CoreEntityMention)nerList.get(j);
                if (em.entityType() == "DATE")
                {
                    var datekey = document.GetField("id").GetStringValue();
                    if (!DateList.ContainsKey(datekey))
                    {
                        DateList.Add(datekey, em.text());
                    }
                    else
                    {
                        DateList.TryUpdate(datekey, DateList[datekey] + ", " + em.text());
                    }
                }
                if (em.entityType() == "TIME")
                {


                    var timekey = document.GetField("id").GetStringValue();
                    if (!TimeList.ContainsKey(timekey))
                    {
                        TimeList.Add(timekey, em.text());
                    }
                    else
                    {
                        TimeList.TryUpdate(timekey, TimeList[timekey] + ", " + em.text());
                    }
                }

                if (em.entityType() == "LOCATION")
                {
                    var lockey = document.GetField("id").GetStringValue();
                    if (!LocList.ContainsKey(lockey))
                    {
                        LocList.Add(lockey, em.text());
                    }
                    else
                    {
                        LocList.TryUpdate(lockey, LocList[lockey] + ", " + em.text());
                    }
                }
                if (em.entityType() == "ORGANIZATION")
                {
                    var orgkey = document.GetField("id").GetStringValue();
                    if (!OrgList.ContainsKey(orgkey))
                    {
                        OrgList.Add(orgkey, em.text());
                    }
                    else
                    {
                        OrgList.TryUpdate(orgkey, OrgList[orgkey] + ", " + em.text());
                    }
                }

            }
        }

        private void ExtractNouns(CoreDocument coredoc, Lucene.Net.Documents.Document document)
        {
            List<string> nouns = new List<string>();
            for (int i = 0; i < coredoc.sentences().size(); i++)
            {
                CoreSentence sent = (CoreSentence)coredoc.sentences().get(i);
                for (int j = 0; j < sent.tokens().size(); j++)
                {
                    // Condition: if the word is a noun (posTag starts with "NN")
                    if (sent.posTags() != null && sent.posTags().get(j) != null)
                    {
                        string posTags = sent.posTags().get(j).ToString();
                        if (posTags.Contains("NN"))
                        {
                            var noun = sent.tokens().get(j).ToString();
                            noun = noun.Remove(noun.Length - 2);
                            nouns.Add(noun);
                        }
                    }

                }
            }
            NounList.Add(document.GetField("id").GetStringValue(), nouns);


        }


        public void Extract()
        {
            if (LuceneService.DirReader != null)
            {
                //using (var stream = new ByteArrayOutputStream())
                //{
                    for (int i = 0; i < 50; i++)
                    {
                        Lucene.Net.Documents.Document document = LuceneService.DirReader.Document(i);
                        CoreDocument coredoc = GetAnnotatedDocument(document.GetField("text").GetStringValue());
                    //ExtractNERTags(coredoc, document);
                    //ExtractNouns(coredoc, document);
                    _analyzer.CreateParseTree(coredoc);
                    //var q = _analyzer.DetectQuestion();
                    //Console.WriteLine(q.ToString());
                    //foreach (var a in this.NounList[document.GetField("id").GetStringValue()])
                    //{
                    //    Console.Write(a + " ");
                    //}

                    //pipe.prettyPrint(coredoc.annotation(), new PrintWriter(stream));
                    //System.Console.WriteLine(stream.toString());
                    //System.Console.WriteLine(_analyzer.Twokenize(document.GetField("text").GetStringValue()));
                }
                    //stream.close();

                //}
                
            }
                
            }

        }
    
}
