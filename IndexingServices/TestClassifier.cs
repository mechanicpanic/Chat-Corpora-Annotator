using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Classification;

namespace IndexingServices
{
    public class TestClassifier
    {
        KNearestNeighborClassifier classifier;
        //SimpleNaiveBayesClassifier simpleClassifier;

        public TestClassifier(int k)
        {
            classifier = new KNearestNeighborClassifier(k);
            //classifier.Train(LuceneService.TaggedDirReader,IndexService.TextFieldKey,)

            
        }
    }
}
