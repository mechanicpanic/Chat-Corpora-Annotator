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
        public string nerRoot = @"C:\Users\voidl\Documents\stanford-ner-2016-10-31";
        public string modelRoot = @"C:\Users\voidl\Documents\stanford-corenlp-full-2016-10-31\stanford-corenlp-3.7.0-models";
        public string classifiersDirectory;
        CRFClassifier classifier;
        LexicalizedParser parser;
        TokenizerFactory tokenizerFactory;

        public string modelDirectory;
        public void LoadClassifier()
        {
            classifiersDirectory = nerRoot + @"\classifiers";

            // Loading 3 class classifier model
            classifier = CRFClassifier.getClassifierNoExceptions(
                classifiersDirectory + @"\english.muc.7class.distsim.crf.ser.gz");
            
        }
        public string ExtractNamedEntities(string message)
        {

            System.Console.WriteLine("{0}\n", classifier.classifyWithInlineXML(message));
            return classifier.classifyToString(message, "xml", true);
            
        }

        //public List<string> ExtractLocation(string classified) { }
        //public List<string> ExtractTime(string classified) { }

        
        public void LoadParserModels()
        {
            modelDirectory = modelRoot + @"\edu\stanford\nlp\models";
            parser = LexicalizedParser.loadModel(modelDirectory + @"\lexparser\englishPCFG.ser.gz");
            tokenizerFactory = PTBTokenizer.factory(new CoreLabelTokenFactory(), "");
        }
       
        public bool DetectQuestion(string message)
        {

            var read = new StringReader(message);
                var words = tokenizerFactory.getTokenizer(read).tokenize();
                read.close();
                Tree tree = parser.apply(words);

            //Extract dependencies from lexical tree

            //var tlp = new PennTreebankLanguagePack();
            // var gsf = tlp.grammaticalStructureFactory();
            // var gs = gsf.newGrammaticalStructure(tree);
            // var tdl = gs.typedDependenciesCCprocessed();
            // System.Console.WriteLine("\n{0}\n", tdl);

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

        //public AnnotationPipeline buildPipeline()
        //{
        //    Annotation document = new Annotation("Barack Obama was born in Hawaii.  He is the president. Obama was elected in 2008.");
        //    AnnotationPipeline pl = new AnnotationPipeline();

        //    pl.addAnnotator(new ParserAnnotator(edu.stanford.nlp.parser.common.ParserGrammar.loadModel(), true, 50));

        //    return pl;
        //}


    }
}
