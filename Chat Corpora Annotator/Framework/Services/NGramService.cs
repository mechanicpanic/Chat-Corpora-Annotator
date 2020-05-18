using CSharpTest.Net.Collections;
using IndexingServices;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.TokenAttributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace Viewer.Framework.Services
{


	public class NGramService : INGramService
	{
		public BTreeDictionary<string, int> BigramIndex { get; set; }

		public BTreeDictionary<string, int> TrigramIndex { get; set; }
		public BTreeDictionary<string, int> FourgramIndex { get; set; }
		public BTreeDictionary<string, int> FivegramIndex { get; set; }


		//private string filename = @"C:\Users\voidl\Desktop";
		public bool CheckIndex() {
			if(File.Exists(IndexService.CurrentIndexPath + @"\info\" + "grams.txt"))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public void ReadIndexFromDisk()
		{
			new JavaScriptSerializer()
	.Deserialize<BTreeDictionary<string, int>>(IndexService.CurrentIndexPath + @"\info\" + "ngrams.txt");
		}
		public void FlushIndexToDisk()
		{
			File.WriteAllText(IndexService.CurrentIndexPath + @"\info\" + "bigrams.txt", new JavaScriptSerializer().Serialize(BigramIndex));
			File.WriteAllText(IndexService.CurrentIndexPath + @"\info\" + "trigrams.txt", new JavaScriptSerializer().Serialize(TrigramIndex));
			File.WriteAllText(IndexService.CurrentIndexPath + @"\info\" + "fourgrams.txt", new JavaScriptSerializer().Serialize(FourgramIndex));
			File.WriteAllText(IndexService.CurrentIndexPath + @"\info\" + "fivegrams.txt", new JavaScriptSerializer().Serialize(FivegramIndex));
		}


		public void BuildNgramIndex(int maxSize, int minSize, bool ShowUnigrams, string TextFieldKey, string term)
		{

			this.BigramIndex = new BTreeDictionary<string, int>();
			this.TrigramIndex = new BTreeDictionary<string, int>();
			this.FourgramIndex = new BTreeDictionary<string, int>();
			this.FivegramIndex = new BTreeDictionary<string, int>();

			LuceneService.NGrammer.maxGramSize = maxSize;
			LuceneService.NGrammer.minGramSize = minSize;
			LuceneService.NGrammer.ShowUnigrams = ShowUnigrams;
			for (int i = 0; i < LuceneService.DirReader.MaxDoc; i++)
			{
				var msg = LuceneService.DirReader.Document(i).GetField(TextFieldKey).GetStringValue();
				foreach (var gram in GetNGrams(TextFieldKey, msg))
				{
					var split = gram.Split(' ');
					switch (split.Length)
					{

						case 2:
							if (split.ToList().Contains(term))
							{
								if (!BigramIndex.Keys.Contains(gram))
								{

									BigramIndex.Add(gram, 1);
								}
								else
								{
									int temp = BigramIndex[gram];
									temp++;
									BigramIndex.TryUpdate(gram, temp);
								}
							}
							break;
						case 3:
							if (split.ToList().Contains(term))
							{
								if (!TrigramIndex.Keys.Contains(gram))
								{

									TrigramIndex.Add(gram, 1);
								}
								else
								{
									int temp = TrigramIndex[gram];
									temp++;
									TrigramIndex.TryUpdate(gram, temp);
								}
							}
							break;
						case 4:
							if (split.ToList().Contains(term))
							{
								if (!FourgramIndex.Keys.Contains(gram))
								{

									FourgramIndex.Add(gram, 1);
								}
								else
								{
									int temp = FourgramIndex[gram];
									temp++;
									FourgramIndex.TryUpdate(gram, temp);
								}
							}
							break;
						case 5:
							if (split.ToList().Contains(term))
							{
								if (!FivegramIndex.Keys.Contains(gram))
								{

									FivegramIndex.Add(gram, 1);
								}
								else
								{
									int temp = FivegramIndex[gram];
									temp++;
									FivegramIndex.TryUpdate(gram, temp);
								}
							}
							break;
						default:
							Console.WriteLine("Default case");
							break;
					}
				}

			}
			FlushIndexToDisk();
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
				stream.ClearAttributes();
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
		BTreeDictionary<string, int> BigramIndex { get; set; }

		BTreeDictionary<string, int> TrigramIndex { get; set; }
		BTreeDictionary<string, int> FourgramIndex { get; set; }
		BTreeDictionary<string, int> FivegramIndex { get; set; }
		List<string> GetNGrams(string TextFieldKey, string document);
		void BuildNgramIndex(int maxSize, int minSize, bool ShowUnigrams, string TextFieldKey, string term);

		void FlushIndexToDisk();
		void ReadIndexFromDisk();
		bool CheckIndex();
	}
}
