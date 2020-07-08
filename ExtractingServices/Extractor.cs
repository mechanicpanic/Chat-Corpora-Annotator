using CSharpTest.Net.Collections;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.trees;
using IndexEngine;
using java.io;
using java.util;
using System;
using System.Collections.Generic;
using NounPhraseAlgorithm;
using edu.stanford.nlp.util;
using System.Linq;


namespace ExtractingServices
{
    public static class Extractor
    {
        public static BTreeDictionary<int, string> URLList { get; set; } = new BTreeDictionary<int, string>();
        public static BTreeDictionary<int, string> DateList { get; set; } = new BTreeDictionary<int, string>();
        public static BTreeDictionary<int, string> TimeList { get; set; } = new BTreeDictionary<int, string>();
        public static BTreeDictionary<int, string> OrgList { get; set; } = new BTreeDictionary<int, string>();
        public static BTreeDictionary<int, string> LocList { get; set; } = new BTreeDictionary<int, string>();

        public static List<int> IsQuestionList { get; set; } = new List<int>(); 
        public static BTreeDictionary<int, List<string>> NounPhrases { get; set; } = new BTreeDictionary<int, List<string>>();
        public static CoreAnalyzer _analyzer { get; set; }

        public static List<List<string>> NounList = new List<List<string>>();
        public static StanfordCoreNLP pipe { get; set; }
        static Extractor()
        {
            _analyzer = new CoreAnalyzer();
            
        }

        public static void CreatePipeline()
        {
            pipe = _analyzer.SimplePipeline();
        }
        public static CoreDocument GetAnnotatedDocument(string text)
        {
            if (!String.IsNullOrEmpty(text) && !String.IsNullOrWhiteSpace(text))
            {
                CoreDocument coredoc = new CoreDocument(text);
                pipe.annotate(coredoc);
                return coredoc;
            }
            else
            {
                return null;
            }
        }


        private static void ExtractKeyPhrases(CoreDocument coredoc, int id)
        {
            ArrayList sents = _analyzer.GetSents(coredoc);
            List<string> NP = new List<string>();
            for (int i = 0; i < sents.size(); i++)
            {
                CoreMap sentence = (CoreMap)sents.get(i);
                List<Tree> smallTrees = NPExtractor.getKeyPhrases((Tree)sentence.get(typeof(TreeCoreAnnotations.TreeAnnotation))).ToList();
                foreach(var tree in smallTrees)
                {
                    
                    List leaves = tree.getLeaves();
                    var objarray = leaves.toArray();
                    //foreach (var obj in objarray)
                    //{
                    //    NP.Add(obj.ToString());
                    //}
                    string joinedNP = String.Join(" ", objarray);
                    NP.Add(joinedNP);
                }
            }
            NounPhrases.Add(id,NP);

        }
        public static bool DetectQuestion(CoreDocument coredoc)
        {
            _analyzer.CreateParseTree(coredoc);
            int index = 0;
            while (index < _analyzer.treeArray.Length)
            {
                Constituent constituent = (Constituent)_analyzer.treeArray[index];

                if (constituent.label() != null && (constituent.label().toString().Equals("SQ") || constituent.label().toString().Equals("SBARQ")))
                {
                    return true;
                }
                index++;

            }
            return false;
        }

        private static void ExtractNERTags(CoreDocument coredoc, Lucene.Net.Documents.Document document)
        {
            //I have no clue as to why NER-tagged messages are stored like that. I guess there is some deep idea behind copying the same info over and over again (or, most likely, this is because some documents have more than one sentence. even tho its stil really stupid)
            if (coredoc != null)
            {
                List nerList = coredoc.entityMentions();
                if (nerList.size() > 0)
                {
                    for (int j = 0; j < nerList.size(); j++)
                    {
                        CoreEntityMention em = (CoreEntityMention)nerList.get(j);
                        //Does this need to be a switch case?
                        if (em.entityType() == "DATE")
                        {
                            var datekey = document.GetField("id").GetInt32Value();
                            if (!DateList.ContainsKey((int)datekey))
                            {
                                DateList.Add((int)datekey, em.text());
                            }
                            else
                            {
                                DateList.TryUpdate((int)datekey, DateList[(int)datekey] + ", " + em.text());
                            }
                        }
                        if (em.entityType() == "TIME")
                        {


                            var timekey = document.GetField("id").GetInt32Value();
                            if (!TimeList.ContainsKey((int)timekey))
                            {
                                TimeList.Add((int)timekey, em.text());
                            }
                            else
                            {
                                TimeList.TryUpdate((int)timekey, TimeList[(int)timekey] + ", " + em.text());
                            }
                        }

                        if (em.entityType() == "LOCATION")
                        {
                            var lockey = document.GetField("id").GetInt32Value();
                            if (!LocList.ContainsKey((int)lockey))
                            {
                                LocList.Add((int)lockey, em.text());
                            }
                            else
                            {
                                LocList.TryUpdate((int)lockey, LocList[(int)lockey] + ", " + em.text());
                            }
                        }
                        if (em.entityType() == "ORGANIZATION")
                        {
                            var orgkey = document.GetField("id").GetInt32Value();
                            if (!OrgList.ContainsKey((int)orgkey))
                            {
                                OrgList.Add((int)orgkey, em.text());
                            }
                            else
                            {
                                OrgList.TryUpdate((int)orgkey, OrgList[(int)orgkey] + ", " + em.text());
                            }
                        }

                        if (em.entityType() == "URL")
                        {
                            var urlkey = document.GetField("id").GetInt32Value();
                            if (!URLList.ContainsKey((int)urlkey))
                            {
                                URLList.Add((int)urlkey, em.text());
                            }
                            else
                            {
                                URLList.TryUpdate((int)urlkey, OrgList[(int)urlkey] + ", " + em.text());
                            }
                        }

                    }
                }
            }
        }

        private static void ExtractNouns(CoreDocument coredoc, Lucene.Net.Documents.Document document)
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
            NounPhrases.Add((int)document.GetField("id").GetInt32Value(), nouns);


        }

        public static void Extract()
        {
            if (LuceneService.DirReader != null)
            {
                //This is actually pathetic. Please let me leave and enjoy my shitty code, thank you.
                for (int i = 0; i < LuceneService.DirReader.MaxDoc; i++)
                {
                    Lucene.Net.Documents.Document document = LuceneService.DirReader.Document(i);
                    CoreDocument coredoc = GetAnnotatedDocument(document.GetField(IndexService.TextFieldKey).GetStringValue());
                    ExtractNERTags(coredoc, document);
                    //IsQuestionList.Add(document.GetField("id").GetStringValue(), DetectQuestion(coredoc));
                    if (DetectQuestion(coredoc))
                    {
                        IsQuestionList.Add((int)document.GetField("id").GetInt32Value());
                    }
                    ExtractKeyPhrases(coredoc, (int)document.GetField("id").GetInt32Value());
                    int a = 5;
                }
                

            }

        }

        private static void FlushToDisk() 
        {
            
        }
        private static void ReadFromDisk() { }

        private static bool CheckInfo() { return true; }

    }
}
