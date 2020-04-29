using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edu.stanford.nlp.ie.crf;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.time;
using edu.stanford.nlp.parser.lexparser;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.process;
using java.io;
using edu.stanford.nlp.trees;

namespace Viewer
{
    public class NLPAnalyzer
    {
        public string nerRoot = @"C:\Users\voidl\Documents\stanford-ner-2016-10-31";
        public string modelRoot = @"C:\Users\voidl\Documents\stanford-corenlp-full-2016-10-31\stanford-corenlp-3.7.0-models";
        public string classifiersDirecrory;
        CRFClassifier classifier;

        public string modelDirectory;
        public void LoadClassifier()
        {
            classifiersDirecrory = nerRoot + @"\classifiers";

            // Loading 3 class classifier model
            classifier = CRFClassifier.getClassifierNoExceptions(
                classifiersDirecrory + @"\english.all.3class.distsim.crf.ser.gz");
        }
        public string ExtractNamedEntities(string message)
        {

            System.Console.WriteLine("{0}\n", classifier.classifyWithInlineXML(message));

            return classifier.classifyToString(message, "xml", true);
            
        }
        //public AnnotationPipeline buildPipeline()
        //{ 
        //    AnnotationPipeline pl = new AnnotationPipeline();
        //    pl.addAnnotator(new POSTaggerAnnotator());
        //    pl.addAnnotator(new ParserAnnotator(edu.stanford.nlp.parser.common.ParserGrammar.loadModel(), true, 50));

        //    return pl;
        //}
        public void MakeTrees()
        {
            // Path to models extracted from `stanford-parser-3.7.0-models.jar`
            
            modelDirectory = modelRoot + @"\edu\stanford\nlp\models";

            // Loading english PCFG parser from file
            var lp = LexicalizedParser.loadModel(modelDirectory + @"\lexparser\englishPCFG.ser.gz");

            // This sample shows parsing a list of correctly tokenized words
            var sent = new[] { "This", "is", "an", "easy", "sentence", "." };
            var rawWords = SentenceUtils.toCoreLabelList(sent);
            var tree = lp.apply(rawWords);
            tree.pennPrint();

            // This option shows loading and using an explicit tokenizer
            var sent2 = "This is another sentence.";
            var tokenizerFactory = PTBTokenizer.factory(new CoreLabelTokenFactory(), "");
            var sent2Reader = new StringReader(sent2);
            var rawWords2 = tokenizerFactory.getTokenizer(sent2Reader).tokenize();
            sent2Reader.close();
            Tree tree2 = lp.apply(rawWords2);

            // Extract dependencies from lexical tree
            var tlp = new PennTreebankLanguagePack();
            var gsf = tlp.grammaticalStructureFactory();
            var gs = gsf.newGrammaticalStructure(tree2);
            var tdl = gs.typedDependenciesCCprocessed();
            

            // Extract collapsed dependencies from parsed tree
            var tp = new TreePrint("penn,typedDependenciesCollapsed");
            tp.printTree(tree2);
        }
    }
}
