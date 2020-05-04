using Lucene.Net.Analysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis.Shingle;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.Core;
using Lucene.Net.Util;

namespace Viewer.Framework.Services
{
    public class NGramAnalyzer: Analyzer
    {
        LuceneVersion version = LuceneService.AppLuceneVersion;
    //public TokenStream tokenStream(String fieldName, TextReader reader)
    //{
    //    return new StopFilter(version,new LowerCaseFilter(version,new ShingleFilter(new StandardTokenizer(version, reader), 2, 2)),
    //        StopAnalyzer.ENGLISH_STOP_WORDS_SET);
    //}

        protected override TokenStreamComponents CreateComponents(string fieldName, TextReader reader)
        {
            var tokenizer = new StandardTokenizer(version, reader);
            var shingler = new ShingleFilter(tokenizer, 2, 2);
            shingler.SetOutputUnigrams(false);
            var filter = new StopFilter(version, new LowerCaseFilter(version, shingler),
            StopAnalyzer.ENGLISH_STOP_WORDS_SET);
            return new TokenStreamComponents(tokenizer, filter);
        }
    }


}
