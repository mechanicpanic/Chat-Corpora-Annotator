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
using Wintellect.PowerCollections;

namespace Viewer.Framework.Services
{
	public interface IIndexService
	{
		BTreeDictionary<DateTime, int> MessagesPerDay { get; set; } 
		HashSet<string> UserKeys { get; set; }
		void OpenDirectory(string IndexPath);
		void OpenWriter(string textFieldKey);
		int PopulateIndex(string indexPath, string filePath, string[] allFields, List<string> selectedFields);

		void InitLookup(string textFieldKey, string dateFieldKey, string senderFieldKey, List<string> selectedFields, string[] allFields);
		List<DynamicMessage> LoadSomeDocuments(string indexPath,  string dateFieldKey, List<string> selectedFields, int count);

		void OpenIndex(string textFieldKey);

		//event EventHandler FileIndexed;
		//void SaveInfoToDisk(string textFieldKey, string dateFieldKey, string senderFieldKey, List<string> selectedFields, string[] allFields);
		OrderedDictionary<string,string> LoadInfoFromDisk(string CurrentIndexPath);
		List<string> LoadUsersFromDisk(string CurrentIndexPath);
		List<string> LoadFieldsFromDisk(string CurrentIndexPath);
		BTreeDictionary<DateTime, int> LoadStatsFromDisk(string CurrentIndexPath);
	}

	public class IndexService : IIndexService 
	{
		private int readerIndex = 0;
		public BTreeDictionary<DateTime, int> MessagesPerDay { get; set; } = new BTreeDictionary<DateTime, int>();

		private int[] lookup = new int[3];


		public event EventHandler FileIndexed;

		public HashSet<string> UserKeys { get; set; } = new HashSet<string>();


		private void SaveInfoToDisk(string textFieldKey, string senderFieldKey, string dateFieldKey, string CurrentIndexPath) 
		{
			using (System.IO.StreamWriter file =
			new System.IO.StreamWriter(CurrentIndexPath+@"info.txt"))
			{
				file.WriteLine(textFieldKey);
				file.WriteLine(senderFieldKey);
				file.WriteLine(dateFieldKey);
			
			}
		}

		private void SaveUsersToDisk(string CurrentIndexPath)
		{
			using (System.IO.StreamWriter file =
			new System.IO.StreamWriter(CurrentIndexPath + @"users.txt"))
			{
				foreach (var user in UserKeys)
				{
					file.WriteLine(user);
				}
			}
		}

		private void SaveFieldsToDisk(string CurrentIndexPath, List<string> SelectedFields)
		{
			using (System.IO.StreamWriter file =
			new System.IO.StreamWriter(CurrentIndexPath + @"fields.txt"))
			{
				foreach (var field in SelectedFields)
				{
					file.WriteLine(field);
				}
			}
		}
		private void SaveStatsToDisk(string CurrentIndexPath)
		{
			using (System.IO.StreamWriter file =
			new System.IO.StreamWriter(CurrentIndexPath + @"stats.txt"))
			{
				foreach (var kvp in MessagesPerDay)
				{
					file.WriteLine(kvp.Key.ToString() + "#" + kvp.Value);
				}
			}
		}
		public OrderedDictionary<string,string> LoadInfoFromDisk(string CurrentIndexPath)
		{

			OrderedDictionary<string,string> info = new OrderedDictionary<string,string>();
			using (System.IO.StreamReader reader = new System.IO.StreamReader(CurrentIndexPath + @"info.txt"))
			{
				info.Add("TextFieldKey", reader.ReadLine());
				info.Add("SenderFieldKey", reader.ReadLine());
				info.Add("DateFieldKey", reader.ReadLine());
				
			}
			return info;
		}

		public List<string> LoadFieldsFromDisk(string CurrentIndexPath)
		{
			List<string> fields = new List<string>();
			using (System.IO.StreamReader reader = new System.IO.StreamReader(CurrentIndexPath + @"fields.txt"))
			{

				while (!reader.EndOfStream)
				{
					fields.Add(reader.ReadLine());
					
				}

			}
			return fields;
		}

		public List<string> LoadUsersFromDisk(string CurrentIndexPath)
		{
			List<string> users = new List<string>();
			using (System.IO.StreamReader reader = new System.IO.StreamReader(CurrentIndexPath + @"users.txt"))
			{
				while (!reader.EndOfStream)
				{
					users.Add(reader.ReadLine());
				}
			}
			return users;
		}

		public BTreeDictionary<DateTime, int> LoadStatsFromDisk(string CurrentIndexPath)
		{
			BTreeDictionary<DateTime, int> stats = new BTreeDictionary<DateTime, int>();
			using (System.IO.StreamReader reader = new System.IO.StreamReader(CurrentIndexPath + @"stats.txt"))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					string[] kvp = line.Split('#');
					stats.Add(DateTime.Parse(kvp[0]),Int32.Parse(kvp[1]));
				}
			}
			return stats;
		}
		public void InitLookup(string textFieldKey, string dateFieldKey, string senderFieldKey, List<string> selectedFields,string[] allFields)
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

		public int PopulateIndex(string indexPath, string filePath, string[] allFields, List<string> selectedFields)
		{
			List<Document> documentBlock = new List<Document>();
			int result = 0;
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
								if (selectedFields.Contains(allFields[i]))
								{
									document.Add(new StringField(allFields[i], row[i], Field.Store.YES));
								}

							}
							//TODO: Still need to redesign this. Rework storing/indexing paradigm.

						}
						//documentBlock.Add(document);
						LuceneService.Writer.AddDocument(document);
					}
					//LuceneService.Writer.AddDocuments(documentBlock);
					LuceneService.Writer.Commit();
					LuceneService.Writer.Flush(triggerMerge: false, applyAllDeletes: false);
					SaveInfoToDisk(allFields[lookup[2]],allFields[lookup[1]],allFields[lookup[0]], indexPath);
					SaveFieldsToDisk(indexPath, selectedFields);
					SaveUsersToDisk(indexPath);
					SaveStatsToDisk(indexPath);
					OpenReader();
					result = 1;
					
					return result;

				}
			}
			return result;
		}

		private void OpenParser(string textFieldKey)
		{
			LuceneService.Parser = new QueryParser(LuceneService.AppLuceneVersion, textFieldKey, LuceneService.Analyzer);
		}
		public void OpenWriter(string textFieldKey)
		{
			
			LuceneService.Analyzer = new StandardAnalyzer(LuceneService.AppLuceneVersion);
			LuceneService.IndexConfig = new IndexWriterConfig(LuceneService.AppLuceneVersion, LuceneService.Analyzer);
			LuceneService.IndexConfig.MaxBufferedDocs = IndexWriterConfig.DISABLE_AUTO_FLUSH;
			LuceneService.IndexConfig.RAMBufferSizeMB = 50.0;
			LuceneService.IndexConfig.OpenMode = OpenMode.CREATE;
			LuceneService.Writer = new IndexWriter(LuceneService.Dir, LuceneService.IndexConfig);


			OpenParser(textFieldKey);

			
			

		}

		private void OpenReader()
		{
			
			LuceneService.DirReader = DirectoryReader.Open(LuceneService.Dir);
			LuceneService.Searcher = new IndexSearcher(LuceneService.DirReader);
		}

		public void OpenDirectory(string IndexPath)
		{
			LuceneService.Dir = FSDirectory.Open(IndexPath);
		}

		public void OpenIndex(string textFieldKey)
		{
			if (LuceneService.Dir != null)
			{
				if (DirectoryReader.IndexExists(LuceneService.Dir))
				{
					OpenReader();
					OpenParser(textFieldKey);
					//LoadInfoFromDisk(LuceneService.Dir.Directory.FullName);

				}
				else
				{
					throw new Exception("No index here");
				}
			}
		}


	}
}
