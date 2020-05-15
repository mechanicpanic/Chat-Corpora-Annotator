using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;


namespace IndexingServices
{

	public static class LuceneService
	{
		static LuceneService()
		{
			AppLuceneVersion = LuceneVersion.LUCENE_48;
		}

		public static LuceneVersion AppLuceneVersion;

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
