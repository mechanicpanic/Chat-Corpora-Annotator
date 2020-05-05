using System.Collections.Generic;
using edu.stanford.nlp.ie.crf;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.time;
using edu.stanford.nlp.parser.lexparser;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.process;
using java.io;

using edu.stanford.nlp.trees;
using Viewer.Framework.Services;

namespace Viewer
{
    public class NLPAnalyzer
    {
        //public string nerRoot = @"C:\Users\voidl\Documents\stanford-ner-2016-10-31";
        //public string modelRoot = @"C:\Users\voidl\Documents\stanford-corenlp-full-2016-10-31\stanford-corenlp-3.7.0-models";
        //public string classifiersDirectory = @"C:\Users\voidl\Documents\stanford-ner-2016-10-31" + @"\classifiers";
        //CRFClassifier classifier;
        LexicalizedParser parser;
        TokenizerFactory tokenizerFactory;

        public string _modelDirectory { get; private set; }
        public string _NERroot { get; private set; }
        public string _NERclassifiers { get; private set; }
        public string _POSdirectory { get; private set; }
        public string _root { get; private set; }
        public NLPAnalyzer(string root, string NERroot)
        {
            this._root = root;
            this._NERroot = NERroot;
            this._NERclassifiers = _NERroot + @"\classifiers";
            this._modelDirectory = root + @"\stanford-corenlp-3.7.0-models";
            this._POSdirectory = _modelDirectory + @"\edu\stanford\nlp\models\pos-tagger\english-left3words\english-left3words-distsim.tagger";
        }


        public StanfordCoreNLP SimplePipeline()
        {
            java.util.Properties props = new java.util.Properties();

            props.setProperty("annotators", "tokenize,ssplit,pos,lemma,ner,parse");
            props.setProperty("ner.model", _NERclassifiers + @"\english.muc.7class.distsim.crf.ser.gz");
            props.setProperty("parse.model", _modelDirectory + @"\edu\stanford\nlp\models\lexparser\englishPCFG.ser.gz");
            props.setProperty("ner.useSUTime", "true");
            props.setProperty("ner.applyFineGrained", "false");
            props.setProperty("pos.model", _POSdirectory);
            props.setProperty("sutime.binders", "0");

            var sutimeRules = _root+ @"\sutime\defs.sutime.txt,"
                              +_root  + @"\sutime\english.holidays.sutime.txt,"
                              +_root  + @"\sutime\english.sutime.txt";
            props.setProperty("sutime.rules", sutimeRules);
            props.setProperty("sutime.markTimeRanges", "true");
            props.setProperty("sutime.includeNested", "true");
            StanfordCoreNLP pipeline = new StanfordCoreNLP(props);
            return pipeline;
        }


        //public void LoadParserModels()
        //{
            
        //    parser = LexicalizedParser.loadModel(_modelDirectory + @"\lexparser\englishPCFG.ser.gz");
        //    tokenizerFactory = PTBTokenizer.factory(new CoreLabelTokenFactory(), "");
        //}
       
        public bool DetectQuestion(string message)
        {

            var read = new StringReader(message);
                var words = tokenizerFactory.getTokenizer(read).tokenize();
                read.close();
                Tree tree = parser.apply(words);

            //Extract dependencies from lexical tree

            var tlp = new PennTreebankLanguagePack();
             var gsf = tlp.grammaticalStructureFactory();
             var gs = gsf.newGrammaticalStructure(tree);
             var tdl = gs.typedDependenciesCCprocessed();
             System.Console.WriteLine("\n{0}\n", tdl);

            var tp = new TreePrint("penn,typedDependenciesCollapsed");
            tp.printTree(tree);
            foreach (Tree subtree in tree)
                {

                if (subtree.label().value().Equals("SBARQ") || subtree.label().value().Equals("SQ")) {
                    return true;
                }
                
            }
            return false;

        }

        public List<string> ExtractNounPhrases(string message)
        {
            var read = new StringReader(message);
            var words = tokenizerFactory.getTokenizer(read).tokenize();
            read.close();
            Tree tree = parser.apply(words);
            List<Tree> phraseList = new List<Tree>();
            foreach (Tree subtree in tree)
            {

                if (subtree.label().value().Equals("NP"))
                {
                    var t = subtree;
                    foreach (Tree subt in t)
                    {
                        if (subt.label().value().Equals("NNP") || subt.label().value().Equals("NNPS") || subt.label().value().Equals("NN") || subt.label().value().Equals("NNS"))
                        {
                            phraseList.Add(subtree);
                        }
                    }

                }

            }
            List<string> NPs = new List<string>();
            foreach(var t in phraseList)
            {
                NPs.Add(t.toString());
            }
            return NPs;
        }



    }
}
