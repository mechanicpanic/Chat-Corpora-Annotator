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

        public int minGramSize { get; set; } = 2;
        public int maxGramSize { get; set; } = 2;

        public bool ShowUnigrams { get; set; } = false;
        protected override TokenStreamComponents CreateComponents(string fieldName, TextReader reader)
        {
            var tokenizer = new StandardTokenizer(version, reader);
            var shingler = new ShingleFilter(tokenizer, minGramSize, maxGramSize);
            if (!this.ShowUnigrams)
            {
                shingler.SetOutputUnigrams(false);
            }
            else
            {
                shingler.SetOutputUnigrams(true);
            }
            var filter = new StopFilter(version, new LowerCaseFilter(version, shingler),
            StopAnalyzer.ENGLISH_STOP_WORDS_SET);
            return new TokenStreamComponents(tokenizer, filter);
        }


    }

    public class NGramService : INGramService {


    }

    public interface INGramService
    {
    }
}
