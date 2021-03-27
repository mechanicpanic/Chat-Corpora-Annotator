using CSharpTest.Net.Collections;
using CSharpTest.Net.Serialization;
using IndexEngine;
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

		private BPlusTree<string, int> FullIndex { get; set; } 

		private BPlusTree<string, int>.OptionsV2 Options { get; set; }

		private BulkInsertOptions bulkOptions { get; set; }

		public bool IndexExists { get; private set; }
		public bool IndexIsRead { get; private set; } = false;


		public void CheckIndex()
		{
			if (File.Exists(IndexService.CurrentIndexPath + @"\info\" + "index"))
			{
				this.IndexExists = true;
			}
			else
			{
				this.IndexExists = false;
				this.IndexIsRead = false;
			}
			if(IndexExists)
            {
				if(FullIndex != null)
				IndexIsRead = true;
            }
			else
            {
				IndexIsRead = false;
            }
		}
		public void ReadIndexFromDisk()
		{
			SetTreeOptions();
			this.FullIndex = new BPlusTree<string, int>(Options);
			this.IndexExists = true;
			this.IndexIsRead = true;

		}

		private void SetTreeOptions()
		{
			this.Options = new BPlusTree<string, int>.OptionsV2(PrimitiveSerializer.String, PrimitiveSerializer.Int32);
			this.bulkOptions = new BulkInsertOptions();
			bulkOptions.DuplicateHandling = DuplicateHandling.FirstValueWins;
			Options.CalcBTreeOrder(48, 4);
			Options.CreateFile = CreatePolicy.IfNeeded;
			Options.StoragePerformance = StoragePerformance.Fastest;
			Options.FileName = IndexService.CurrentIndexPath + @"\info\" + "index";

		}

		public void BuildFullIndex()
		{

			SetTreeOptions();
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
			this.IndexExists = true;
			this.IndexIsRead = true;
			GC.Collect();
			GC.WaitForPendingFinalizers();
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

		public List<BTreeDictionary<string, int>> GetReadableResultsForTerm(string term)
		{
			BTreeDictionary<string, int> bi = new BTreeDictionary<string, int>();
			BTreeDictionary<string, int> tri = new BTreeDictionary<string, int>();
			BTreeDictionary<string, int> four = new BTreeDictionary<string, int>();
			BTreeDictionary<string, int> five = new BTreeDictionary<string, int>();

			foreach(var kvp in FullIndex)
			{
				var arr = kvp.Key.Split(' ');
				if (arr.Contains(term))
				{
					switch (arr.Length)
					{
						case 2:
							bi.Add(kvp);
							break;
						case 3:
							tri.Add(kvp);
							break;
						case 4:
							four.Add(kvp);
							break;
						case 5:
							five.Add(kvp);
							break;
						default:
							Console.WriteLine("Whoops");
							break;
					}
				}
			}

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


		//List<string> GetNGrams(string TextFieldKey, string document);
		//void BuildNgramTermIndex(int maxSize, int minSize, bool ShowUnigrams, string TextFieldKey, string term);

		
		List<BTreeDictionary<string, int>> GetReadableResultsForTerm(string term);
		void ReadIndexFromDisk();

		void BuildFullIndex();
		void CheckIndex();
		bool IndexExists { get; }
		bool IndexIsRead { get; }
	}
}


