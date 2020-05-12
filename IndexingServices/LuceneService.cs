using Lucene.Net.Analysis.Standard;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Analysis;

namespace Viewer.Framework.Services
{
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
