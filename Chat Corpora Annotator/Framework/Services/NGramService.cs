using CSharpTest.Net.Collections;
using CSharpTest.Net.Serialization;
using IndexingServices;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.TokenAttributes;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace Viewer.Framework.Services
{


	public class NGramService : INGramService
	{
		public BPlusTree<string, int> Index { get; set; }

		private BPlusTree<string,int> FullIndex { get; set; }

		//private string filename = @"C:\Users\voidl\Desktop";
		public bool CheckIndex()
		{
			if (File.Exists(IndexService.CurrentIndexPath + @"\info\" + "bigrams.txt"))
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

		}
		public void FlushIndexToDisk()
		{

			//File.WriteAllText(IndexService.CurrentIndexPath + @"\info\" + "bigrams.txt", new JavaScriptSerializer().Serialize(BigramIndex));
			//File.WriteAllText(IndexService.CurrentIndexPath + @"\info\" + "trigrams.txt", new JavaScriptSerializer().Serialize(TrigramIndex));
			//File.WriteAllText(IndexService.CurrentIndexPath + @"\info\" + "fourgrams.txt", new JavaScriptSerializer().Serialize(FourgramIndex));
			//File.WriteAllText(IndexService.CurrentIndexPath + @"\info\" + "fivegrams.txt", new JavaScriptSerializer().Serialize(FivegramIndex));
		}

		private void BuildFullIndex()
		{
			BPlusTree<string, int>.OptionsV2 Options = new BPlusTree<string, int>.OptionsV2(PrimitiveSerializer.String, PrimitiveSerializer.Int32);
			BulkInsertOptions bulkOptions = new BulkInsertOptions();
			bulkOptions.DuplicateHandling = DuplicateHandling.FirstValueWins;
			Options.CalcBTreeOrder(48, 4);
			Options.CreateFile = CreatePolicy.IfNeeded;
			Options.StoragePerformance = StoragePerformance.Fastest;
			Options.FileName = IndexService.CurrentIndexPath + @"\info\" + "index";

			this.FullIndex = new BPlusTree<string, int>(Options);
			Dictionary<string, int> grams = new Dictionary<string, int>();
			
				for (int i = 0; i < LuceneService.DirReader.MaxDoc; i++)
				{
				
					var msg = LuceneService.DirReader.Document(i).GetField(IndexService.TextFieldKey).GetStringValue();
					int value;
					foreach (var gram in GetNGrams(IndexService.TextFieldKey, msg))
					{
						if (!grams.TryGetValue(gram, out value))
						{
							grams.Add(gram, 1);
						}
						else
						{
							grams[gram]++;
						}
					}


				}
			
			FullIndex.BulkInsert(grams,bulkOptions);
			grams = null;
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}


		private void BuildNgramTermIndex(int maxSize, int minSize, bool ShowUnigrams, string TextFieldKey, string term)
		{
			BPlusTree<string, int>.OptionsV2 Options = new BPlusTree<string, int>.OptionsV2(PrimitiveSerializer.String, PrimitiveSerializer.Int32);
			Options.CalcBTreeOrder(48, 4);
			Options.CreateFile = CreatePolicy.IfNeeded;
			//Options.FileName = IndexService.CurrentIndexPath + @"\info\" + "index";

			this.Index = new BPlusTree<string, int>(Options);

			LuceneService.NGrammer.maxGramSize = maxSize;
			LuceneService.NGrammer.minGramSize = minSize;
			LuceneService.NGrammer.ShowUnigrams = ShowUnigrams;
			BuildFullIndex();
			//TermQuery query = new TermQuery(new Lucene.Net.Index.Term(IndexService.TextFieldKey, term));
			//var docs = LuceneService.Searcher.Search(query, LuceneService.DirReader.MaxDoc);


			//for (int i = 0; i < docs.ScoreDocs.Length; i++)
			//{
			//	var msg = LuceneService.Searcher.Doc(docs.ScoreDocs[i].Doc).GetField(TextFieldKey).GetStringValue();
			//	foreach (var gram in GetNGrams(TextFieldKey, msg))
			//	{

			//		if (gram.Split(' ').Contains(term))
			//		{

			//			if (!Index.ContainsKey(gram))
			//			{

			//				Index.Add(gram, 1);
			//			}
			//			else
			//			{
			//				int temp = Index[gram];
			//				temp++;
			//				Index.TryUpdate(gram, temp);
			//			}
			//		}


			//	}

			//}
			Console.WriteLine("Done!");
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

		public List<BTreeDictionary<string, int>> MakeResultsReadable(string term)
		{
			BTreeDictionary<string, int> bi = new BTreeDictionary<string, int>();
			BTreeDictionary<string, int> tri = new BTreeDictionary<string, int>();
			BTreeDictionary<string, int> four = new BTreeDictionary<string, int>();
			BTreeDictionary<string, int> five = new BTreeDictionary<string, int>();
			BuildNgramTermIndex(5, 2, false, IndexService.TextFieldKey, term);
			//foreach (var kvp in Index)
			//{

			//	switch (kvp.Key.Split(' ').Length)
			//	{
			//		case 2:
			//			bi.Add(kvp.Key, kvp.Value);
			//			break;
			//		case 3:
			//			tri.Add(kvp.Key, kvp.Value);
			//			break;
			//		case 4:
			//			four.Add(kvp.Key, kvp.Value);
			//			break;
			//		case 5:
			//			five.Add(kvp.Key, kvp.Value);
			//			break;
			//		default:
			//			break;
			//	}


				
			//}
			var ret = new List<BTreeDictionary<string, int>>();
			ret.Add(bi);
			ret.Add(tri);
			ret.Add(four);
			ret.Add(five);
			return ret;
		}
	}

	public interface INGramService
	{
		BPlusTree<string, int> Index { get; set; }


		List<string> GetNGrams(string TextFieldKey, string document);
		//void BuildNgramTermIndex(int maxSize, int minSize, bool ShowUnigrams, string TextFieldKey, string term);

		List<BTreeDictionary<string, int>> MakeResultsReadable(string term);
		void ReadIndexFromDisk();
		bool CheckIndex();
	}
}


