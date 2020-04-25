using CSharpTest.Net.Collections;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using SoftCircuits.CsvParser;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Viewer.Framework.Services
{
	public interface IIndexService
	{
		BTreeDictionary<DateTime, int> MessagesPerDay { get; set; } 
		HashSet<string> UserKeys { get; set; }
		void SetUpIndex(string indexPath, string textFieldKey);
		void PopulateIndex(string indexPath, string filePath, string[] allFields);

		void InitLookup(string textFieldKey, string dateFieldKey, string senderFieldKey, List<string> selectedFields, string[] allFields);
		List<DynamicMessage> LoadSomeDocuments(string indexPath,  string dateFieldKey, List<string> selectedFields, int count);

		event EventHandler FileIndexed;


	}

	public class IndexService : IIndexService 
	{
		private int readerIndex = 0;
		public BTreeDictionary<DateTime, int> MessagesPerDay { get; set; } = new BTreeDictionary<DateTime, int>();

		private int[] lookup = new int[3];

		public event EventHandler FileIndexed;

		public HashSet<string> UserKeys { get; set; } = new HashSet<string>();



		public void InitLookup(string textFieldKey,string dateFieldKey, string senderFieldKey, List<string> selectedFields,string[] allFields)
		{
			lookup = new int[3];
			foreach (var field in selectedFields)
			{
				if (field == dateFieldKey)
				{
					lookup[0] = Array.IndexOf(allFields, dateFieldKey);
				}
				if (field == senderFieldKey)
				{
					lookup[1] = Array.IndexOf(allFields, senderFieldKey);
				}
				if (field == textFieldKey)
				{
					lookup[2] = Array.IndexOf(allFields, textFieldKey);
				}
			}
		}
		public List<DynamicMessage> LoadSomeDocuments(string indexPath, string dateFieldKey, List<string> selectedFields, int count)
		{
			List<DynamicMessage> messages = new List<DynamicMessage>();
			
			for (int i = readerIndex; i < count + readerIndex; i++)
			{
				Document document;
				List<string> temp = new List<string>();
				if (i < LuceneService.DirReader.MaxDoc)
				{
					document = LuceneService.DirReader.Document(i);
				}
				else
				{
					break;
				}
				foreach (var field in selectedFields)
				{

					temp.Add(document.GetField(field).GetStringValue());
				}
				DynamicMessage message = new DynamicMessage(temp, selectedFields, dateFieldKey);
				messages.Add(message);


			}
			readerIndex = count + readerIndex;
			return messages;
		}

		public void PopulateIndex(string indexPath, string filePath, string[] allFields)
		{
			if (lookup != null)
			{
				string[] row = null;
				DateTime date;
				using (var fileReader = new CsvReader(filePath))
				{
					fileReader.ReadRow(ref row); //header read;


					while (fileReader.ReadRow(ref row))

					{

						date = DateTime.Parse(row[lookup[0]]);
						UserKeys.Add(row[lookup[1]]);


						var day = date.Date;
						if (!MessagesPerDay.Keys.Contains(day))
						{
							MessagesPerDay.Add(day, 1);
						}
						else
						{
							int temp = MessagesPerDay[day];
							temp++;
							MessagesPerDay.TryUpdate(day, temp);
						}
						Document document = new Document();
						for (int i = 0; i < row.Length; i++)
						{
							if (lookup.Contains(i))
							{
								if (i == lookup[0])
								{
									var temp = DateTools.DateToString(date, DateTools.Resolution.MINUTE);
									document.Add(new StringField(allFields[i], temp, Field.Store.YES));
								}
								if (i == lookup[1])
								{
									document.Add(new StringField(allFields[i], row[i], Field.Store.YES));
								}
								if (i == lookup[2])
								{

									document.Add(new TextField(allFields[i], row[i], Field.Store.YES));
								}
							}
							else
							{
								document.Add(new StringField(allFields[i], row[i], Field.Store.YES));
							}
							//TODO: Still need to redesign this. Rework storing/indexing paradigm.

						}

						LuceneService.Writer.AddDocument(document);
					}
					FileIndexed?.Invoke(this, EventArgs.Empty);

				}
			}
		}

		public void SetUpIndex(string indexPath, string textFieldKey)
		{
			LuceneService.Dir = FSDirectory.Open(indexPath);
			LuceneService.Analyzer = new StandardAnalyzer(LuceneService.AppLuceneVersion);
			LuceneService.IndexConfig = new IndexWriterConfig(LuceneService.AppLuceneVersion, LuceneService.Analyzer);
			LuceneService.Writer = new IndexWriter(LuceneService.Dir, LuceneService.IndexConfig);
			LuceneService.DirReader = DirectoryReader.Open(LuceneService.Dir);
			LuceneService.Searcher = new IndexSearcher(LuceneService.DirReader);
			LuceneService.Parser = new QueryParser(LuceneService.AppLuceneVersion, textFieldKey, LuceneService.Analyzer);

			LuceneService.Writer.DeleteAll();
			LuceneService.Writer.Commit();

		}
	}
}
