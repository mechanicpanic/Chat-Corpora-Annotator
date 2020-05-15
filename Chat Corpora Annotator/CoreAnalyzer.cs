using edu.stanford.nlp.ling;
using edu.stanford.nlp.parser.lexparser;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.process;
using edu.stanford.nlp.trees;
using edu.stanford.nlp.util;
using java.util;
using System.Collections.Generic;

namespace Viewer
{
    public class CoreAnalyzer
    {

        LexicalizedParser parser;
        TokenizerFactory tokenizerFactory;

        public string _modelDirectory { get; private set; }
        public string _NERroot { get; private set; }
        public string _NERclassifiers { get; private set; }
        public string _POSdirectory { get; private set; }
        public string _root { get; private set; }



        Tree constituencyParse;
        object[] treeArray;
        public CoreAnalyzer(string root, string NERroot)
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
            //props.setProperty("parse.model", _modelDirectory + @"\edu\stanford\nlp\models\lexparser\englishPCFG.ser.gz");
            props.setProperty("parse.model", _modelDirectory + @"\edu\stanford\nlp\models\srparser\englishSR.ser.gz");

            props.setProperty("ner.useSUTime", "true");
            props.setProperty("ner.applyFineGrained", "false");
            props.setProperty("pos.model", _POSdirectory);
            props.setProperty("sutime.binders", "0");

            var sutimeRules = _root + @"\sutime\defs.sutime.txt,"
                              + _root + @"\sutime\english.holidays.sutime.txt,"
                              + _root + @"\sutime\english.sutime.txt";
            props.setProperty("sutime.rules", sutimeRules);
            props.setProperty("sutime.markTimeRanges", "true");
            props.setProperty("sutime.includeNested", "true");
            StanfordCoreNLP pipeline = new StanfordCoreNLP(props);
            return pipeline;
        }


        public bool DetectQuestion()
        {

            int index = 0;
            while (index < treeArray.Length)
            {
                Constituent constituent = (Constituent)treeArray[index];

                if (constituent.label() != null && (constituent.label().toString().Equals("SQ") || constituent.label().toString().Equals("SBARQ")))
                {
                    return true;
                }
                index++;

            }
            return false;
        }

        //public List<string> DetectNounPhrases()
        //{


        //}
        List<Tree> nps = new List<Tree>();

        //private List<Tree> FoldTree(Tree node)
        //{

        //    if (node.isLeaf()) { return nps; }
        //    else
        //    {
        //        List<Tree> temp = (List<Tree>)node.getChildrenAsList();
        //        temp.Aggregate(nps,();
        //    }
        //}
        private bool IsNPwithNNx(Tree node)
        {
            if (node.label().value().Equals("NP"))
            {
                List<Tree> temp = (List<Tree>)node.getChildrenAsList();
                foreach (Tree sub in temp)
                {
                    if (IsNNx(sub)) return true;

                }
                return false;
            }
            return false;
        }

        private bool IsNNx(Tree node)
        {
            if (node.label().value().Equals("NNP") || node.label().value().Equals("NNPS") || node.label().value().Equals("NN") || node.label().value().Equals("NNS"))
            {
                return true;
            }
            return false;
        }


        public void CreateParseTree(CoreDocument coredoc)
        {
            ArrayList sents = (ArrayList)coredoc.annotation().get(typeof(CoreAnnotations.SentencesAnnotation));
            for (int i = 0; i < sents.size(); i++)
            {
                CoreMap sentence = (CoreMap)sents.get(i);

                this.constituencyParse = (Tree)sentence.get(typeof(TreeCoreAnnotations.TreeAnnotation));

                Set treeConstituents = (Set)constituencyParse.constituents(new LabeledScoredConstituentFactory());
                treeArray = treeConstituents.toArray();

            }
        }



        //public bool DetectQuestion(string message)
        //{

        //    var read = new StringReader(message);
        //        var words = tokenizerFactory.getTokenizer(read).tokenize();
        //        read.close();
        //        Tree tree = parser.apply(words);

        //    //Extract dependencies from lexical tree

        //    var tlp = new PennTreebankLanguagePack();
        //     var gsf = tlp.grammaticalStructureFactory();
        //     var gs = gsf.newGrammaticalStructure(tree);
        //     var tdl = gs.typedDependenciesCCprocessed();
        //     System.Console.WriteLine("\n{0}\n", tdl);

        //    var tp = new TreePrint("penn,typedDependenciesCollapsed");
        //    tp.printTree(tree);
        //    foreach (Tree subtree in tree)
        //        {

        //        if (subtree.label().value().Equals("SBARQ") || subtree.label().value().Equals("SQ")) {
        //            return true;
        //        }

        //    }
        //    return false;

        //}
        //public List<string> ExtractNounPhrases(string message)
        //{
        //    var read = new StringReader(message);
        //    var words = tokenizerFactory.getTokenizer(read).tokenize();
        //    read.close();
        //    Tree tree = parser.apply(words);
        //    List<Tree> phraseList = new List<Tree>();
        //    foreach (Tree subtree in tree)
        //    {

        //        if (subtree.label().value().Equals("NP"))
        //        {
        //            var t = subtree;
        //            foreach (Tree subt in t)
        //            {
        //                if (subt.label().value().Equals("NNP") || subt.label().value().Equals("NNPS") || subt.label().value().Equals("NN") || subt.label().value().Equals("NNS"))
        //                {
        //                    phraseList.Add(subtree);
        //                }
        //            }

        //        }

        //    }
        //    List<string> NPs = new List<string>();
        //    foreach(var t in phraseList)
        //    {
        //        NPs.Add(t.toString());
        //    }
        //    return NPs;
        //}



    }
}
