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
		public BPlusTree<string, int> BigramIndex { get; set; }

		public BPlusTree<string, int> TrigramIndex { get; set; }
		public BPlusTree<string, int> FourgramIndex { get; set; }
		public BPlusTree<string, int> FivegramIndex { get; set; }


		//private string filename = @"C:\Users\voidl\Desktop";
		public bool CheckIndex() {
			if(File.Exists(IndexService.CurrentIndexPath + @"\info\" + "bigrams.txt"))
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
			this.BigramIndex = new JavaScriptSerializer()
	.Deserialize<BPlusTree<string, int>>(IndexService.CurrentIndexPath + @"\info\" + "bigrams.txt");
		}
		public void FlushIndexToDisk()
		{
			
			File.WriteAllText(IndexService.CurrentIndexPath + @"\info\" + "bigrams.txt", new JavaScriptSerializer().Serialize(BigramIndex));
			File.WriteAllText(IndexService.CurrentIndexPath + @"\info\" + "trigrams.txt", new JavaScriptSerializer().Serialize(TrigramIndex));
			File.WriteAllText(IndexService.CurrentIndexPath + @"\info\" + "fourgrams.txt", new JavaScriptSerializer().Serialize(FourgramIndex));
			File.WriteAllText(IndexService.CurrentIndexPath + @"\info\" + "fivegrams.txt", new JavaScriptSerializer().Serialize(FivegramIndex));
		}


		public void BuildNgramIndex(int maxSize, int minSize, bool ShowUnigrams, string TextFieldKey)
		{

			this.BigramIndex = new BPlusTree<string, int>();
			this.TrigramIndex = new BPlusTree<string, int>();
			this.FourgramIndex = new BPlusTree<string, int>();
			this.FivegramIndex = new BPlusTree<string, int>();

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
							//if (split.ToList().Contains(term))
							//{
								if (!BigramIndex.ContainsKey(gram))
								{

									BigramIndex.Add(gram, 1);
								}
								else
								{
									int temp = BigramIndex[gram];
									temp++;
									BigramIndex.TryUpdate(gram, temp);
								}
							//}
							break;
						case 3:
							//if (split.ToList().Contains(term))
							//{
								if (!TrigramIndex.ContainsKey(gram))
								{

									TrigramIndex.Add(gram, 1);
								}
								else
								{
									int temp = TrigramIndex[gram];
									temp++;
									TrigramIndex.TryUpdate(gram, temp);
								}
							//}
							break;
						case 4:
							//if (split.ToList().Contains(term))
							//{
								if (!FourgramIndex.ContainsKey(gram))
								{

									FourgramIndex.Add(gram, 1);
								}
								else
								{
									int temp = FourgramIndex[gram];
									temp++;
									FourgramIndex.TryUpdate(gram, temp);
								}
							//}
							break;
						case 5:
							//if (split.ToList().Contains(term))
							//{
								if (!FivegramIndex.ContainsKey(gram))
								{
								
									FivegramIndex.Add(gram, 1);
								}
								else
								{
									int temp = FivegramIndex[gram];
									temp++;
									FivegramIndex.TryUpdate(gram, temp);
								}
							//}
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

		public BTreeDictionary<string, int> FindTerm(string term)
		{
			foreach(var kvp in BigramIndex)
			{
				if (kvp.Key.Contains(term)) {

				}
			}
		}
	}

	public interface INGramService
	{
		BPlusTree<string, int> BigramIndex { get; set; }

		BPlusTree<string, int> TrigramIndex { get; set; }
		BPlusTree<string, int> FourgramIndex { get; set; }
		BPlusTree<string, int> FivegramIndex { get; set; }
		List<string> GetNGrams(string TextFieldKey, string document);
		void BuildNgramIndex(int maxSize, int minSize, bool ShowUnigrams, string TextFieldKey);

		BTreeDictionary<string, int> FindTerm(string term);
		void FlushIndexToDisk();
		void ReadIndexFromDisk();
		bool CheckIndex();
	}
}
