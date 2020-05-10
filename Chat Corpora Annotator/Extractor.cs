using edu.stanford.nlp.ling;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.trees;
using edu.stanford.nlp.util;
using java.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Framework.Services;

namespace Viewer
{
    public class Extractor
    {
        Dictionary<string,bool> CodeStopWords { get; set; }
        Dictionary<string, string> DateList { get; set; }
        public NLPAnalyzer _analyzer { get; set; }
        public StanfordCoreNLP pipe { get; set; }
        public Extractor(NLPAnalyzer analyzer)
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
        public bool DetectMeeting()
        {
            
        }
        public static bool DetectCodeHelp()
        {
            
        }
        public static bool DetectAssistance() { }

        
        private void ExtractNER()
        {
            if(LuceneService.DirReader!=null)
            {
                for(int i = 0; i < LuceneService.DirReader.MaxDoc; i++)
                {
                    Lucene.Net.Documents.Document document = LuceneService.DirReader.Document(i);
                    CoreDocument coredoc = GetAnnotatedDocument(document.GetField("text").GetStringValue());
                    List nerList = coredoc.entityMentions();
                    if (nerList.contains("DATE"))
                    {
                        DateList.Add(document.)
                    }

                }
            }

        }
    }
}
