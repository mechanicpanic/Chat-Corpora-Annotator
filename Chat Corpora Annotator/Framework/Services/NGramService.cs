using CSharpTest.Net.Collections;
using IndexingServices;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.TokenAttributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace Viewer.Framework.Services
{


	public class NGramService : INGramService
	{
		public BTreeDictionary<string, int> NgramIndex { get; set; }

		private string filename = @"C:\Users\voidl\Desktop";

		private void FlushIndexToDisk()
		{
			File.WriteAllText(filename + "SomeFile.Txt", new JavaScriptSerializer().Serialize(NgramIndex));
		}

		private void ReadIndexFromDisk()
		{
			new JavaScriptSerializer()
	.Deserialize<BTreeDictionary<string, int>>(File.ReadAllText(filename + "SomeFile.txt"));
		}
		public void BuildNgramIndex(int maxSize, int minSize, bool ShowUnigrams, string TextFieldKey, string term)
		{

			this.NgramIndex = new BTreeDictionary<string, int>();

			LuceneService.NGrammer.maxGramSize = maxSize;
			LuceneService.NGrammer.minGramSize = minSize;
			LuceneService.NGrammer.ShowUnigrams = ShowUnigrams;
			for (int i = 0; i < LuceneService.DirReader.MaxDoc; i++)
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
		void BuildNgramIndex(int maxSize, int minSize, bool ShowUnigrams, string TextFieldKey, string term);

		BTreeDictionary<string, int> NgramIndex { get; set; }
	}
}
