using Lucene.Net.Analysis.Standard;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Shingle;
using System.IO;
using Lucene.Net.Analysis.Core;

namespace IndexingServices
{
	public class NGramAnalyzer : Analyzer
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
	public static class LuceneService
	{
		public static LuceneVersion AppLuceneVersion { get { return LuceneVersion.LUCENE_48; } }

		public static FSDirectory Dir { get; set; }
		public static StandardAnalyzer Analyzer { get; set; }
		public static IndexWriterConfig IndexConfig { get; set; }
		public static IndexWriter Writer { get; set; }
		public static DirectoryReader DirReader { get; set; }
		public static QueryParser Parser { get; set; }
		public static IndexSearcher Searcher { get; set; }

		public static NGramAnalyzer NGrammer { get; set; }
		public static void Dispose()
		{
			Analyzer.Dispose();
			DirReader.Dispose();
			Writer.Dispose();
		}
	}
}
