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
using Lucene.Net.Analysis.TokenAttributes;
using CSharpTest.Net.Collections;
using Lucene.Net.Search;

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
		public BTreeDictionary<string,int> NgramIndex { get; set; }
		public void BuildNgramIndex(int maxSize,int minSize,bool ShowUnigrams, string TextFieldKey, string term)
		{

			this.NgramIndex = new BTreeDictionary<string, int>();
			LuceneService.NGrammer.maxGramSize = maxSize;
			LuceneService.NGrammer.minGramSize = minSize;
			LuceneService.NGrammer.ShowUnigrams = ShowUnigrams;
			for(int i = 0; i < LuceneService.DirReader.MaxDoc; i++)
			{
				var msg = LuceneService.DirReader.Document(i).GetField(TextFieldKey).GetStringValue();
				foreach (var gram in GetNGrams(TextFieldKey, msg))
				{
					if (gram.Contains(term))
					{
						if (!NgramIndex.Keys.Contains(gram))
						{

							NgramIndex.Add(gram, 1);
						}
						else
						{
							int temp = NgramIndex[gram];
							temp++;
							NgramIndex.TryUpdate(gram, temp);
						}
					}

				}
			}
			
		}



		public List<string> GetNGrams(string TextFieldKey, string document)
		{
			List<string> ngrams = new List<string>();
			if (LuceneService.NGrammer != null)
			{
				TokenStream stream = LuceneService.NGrammer.GetTokenStream(TextFieldKey, new StringReader(document));
				//AttributeSource source = new AttributeSource();
				//OffsetAttribute offsetAttribute = stream.AddAttribute<OffsetAttribute>();
				var charTermAttribute = stream.AddAttribute<ICharTermAttribute>();
				stream.Reset();
				while (stream.IncrementToken())
				{
					//Token token = new Token();
					//int startOffset = offsetAttribute.StartOffset;
					//int endOffset = offsetAttribute.EndOffset;
					String term = charTermAttribute.ToString();
					ngrams.Add(term);

				}
				stream.End();
				stream.Dispose();
				return ngrams;
			}
			else
			{
				throw new Exception("No ngrammer");
			}

		}


	}

	public interface INGramService
	{
		List<string> GetNGrams(string TextFieldKey, string document);
		void BuildNgramIndex(int maxSize, int minSize, bool ShowUnigrams, string TextFieldKey,string term);
		
		BTreeDictionary<string, int> NgramIndex { get; set; }
	}
}
