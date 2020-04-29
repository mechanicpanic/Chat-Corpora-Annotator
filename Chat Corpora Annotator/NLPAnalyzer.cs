using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edu.stanford.nlp.ie.crf;

namespace Viewer
{
    public class NLPAnalyzer
    {
        public string jarRoot;
        public string classifiersDirecrory;
        CRFClassifier classifier;
        public void LoadClassifier()
        {
            jarRoot = @"C:\Users\voidl\Documents\stanford-ner-2016-10-31";
            classifiersDirecrory = jarRoot + @"\classifiers";

            // Loading 3 class classifier model
            classifier = CRFClassifier.getClassifierNoExceptions(
                classifiersDirecrory + @"\english.all.3class.distsim.crf.ser.gz");
        }
        public string ExtractNamedEntities(string message)
        {
            //var s1 = "Good afternoon Rajat Raina, how are you today?";
            //Console.WriteLine("{0}\n", classifier.classifyToString(s1));

            //var s2 = "I go to school at Stanford University, which is located in California.";
            Console.WriteLine("{0}\n", classifier.classifyWithInlineXML(message));

            //Console.WriteLine("{0}\n", classifier.classifyToString(s2, "xml", true));

            return classifier.classifyToString(message, "xml", true);
        }
    }
}
