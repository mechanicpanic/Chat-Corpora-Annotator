using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.TokenAttributes;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using System;
using System.Collections.Generic;
using System.IO;

namespace IndexEngine
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
		
		public static QueryParser UserParser { get; set; }
		public static IndexSearcher Searcher { get; set; }

		public static IndexSearcher NGramSearcher { get; set; }
		public static FSDirectory NGramDir { get; set; }
		public static NGramAnalyzer NGrammer { get; set; }
		public static DirectoryReader NGramReader { get; set; }
		public static void Dispose()
		{
			Analyzer.Dispose();
			NGrammer.Dispose();
			DirReader.Dispose();
			Writer.Dispose();
		}

		public static Dictionary<int, List<int>> GetTokenDataForDoc(string document)
		{
			Dictionary<int, List<int>> res = new Dictionary<int, List<int>>();
			List<int> list = new List<int>();
			TokenStream stream = LuceneService.Analyzer.GetTokenStream(IndexService.TextFieldKey, new StringReader(document));
			var index = 0;
			var charTermAttribute = stream.AddAttribute<ICharTermAttribute>();
			stream.Reset();

			while (stream.IncrementToken())
			{
				//Token token = new Token();
				//int startOffset = offsetAttribute.StartOffset;
				//int endOffset = offsetAttribute.EndOffset;
				String term = charTermAttribute.ToString();
				index++;
				list.Add(term.Length);

			}
			res.Add(index, list);
			stream.ClearAttributes();
			stream.End();
			stream.Dispose();
			return res;

		}
	}
}
