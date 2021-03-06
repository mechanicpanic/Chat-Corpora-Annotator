using CSharpTest.Net.Collections;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;

using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using SoftCircuits.CsvParser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;

namespace IndexEngine
{


    

    public static class IndexService
    {

        #region fields
        private static int viewerReadIndex = 0;

        public static BTreeDictionary<DateTime, int> MessagesPerDay { get; set; } = new BTreeDictionary<DateTime, int>();

        private static int[] lookup = new int[3];


        public static HashSet<string> UserKeys { get; set; } = new HashSet<string>();

        public static Dictionary<string, Color> UserColors { get; set; } = new Dictionary<string, Color>();
        public static string DateFieldKey { get; set; }
        public static string TextFieldKey { get; set; }
        public static string SenderFieldKey { get; set; }
        public static List<string> SelectedFields { get; set; }
        public static string CurrentIndexPath { get; set; }

        
        #endregion
        #region save info
        private static void CheckDir()
        {
            if (!System.IO.Directory.Exists(CurrentIndexPath + "\\info"))
            {
                System.IO.Directory.CreateDirectory(CurrentIndexPath + "\\info");

            }
            else
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(CurrentIndexPath + "\\info");

                foreach (System.IO.FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
        }
        private static void SaveInfoToDisk(int linecount)
        {


            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(CurrentIndexPath) + @"-info.txt"))
            {
                file.WriteLine(TextFieldKey);
                file.WriteLine(SenderFieldKey);
                file.WriteLine(DateFieldKey);
                file.WriteLine(linecount.ToString());

            }
        }

        private static void SaveUsersToDisk()
        {

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(CurrentIndexPath) + @"-users.txt"))
            {
                foreach (var kvp in UserColors)
                {
                    file.WriteLine(kvp.Key+"+"+kvp.Value.ToArgb().ToString()); ;
                }
            }
        }

        private static void SaveFieldsToDisk()
        {

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(CurrentIndexPath) + @"-fields.txt"))
            {
                foreach (var field in SelectedFields)
                {
                    file.WriteLine(field);
                }
            }
        }
        private static void SaveStatsToDisk()
        {

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(CurrentIndexPath) + @"-stats.txt"))
            {
                foreach (var kvp in MessagesPerDay)
                {
                    file.WriteLine(kvp.Key.ToString() + "#" + kvp.Value);
                }
            }
        }
        #endregion
        #region load info
        public static OrderedDictionary<string, string> LoadInfoFromDisk(string CurrentIndexPath)
        {

            OrderedDictionary<string, string> info = new OrderedDictionary<string, string>();
            using (System.IO.StreamReader reader = new System.IO.StreamReader(CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(CurrentIndexPath) + @"-info.txt"))
            {
                info.Add("TextFieldKey", reader.ReadLine());
                info.Add("SenderFieldKey", reader.ReadLine());
                info.Add("DateFieldKey", reader.ReadLine());
                info.Add("LineCount", reader.ReadLine());

            }
            return info;
        }

        public static List<string> LoadFieldsFromDisk(string CurrentIndexPath)
        {
            List<string> fields = new List<string>();
            using (System.IO.StreamReader reader = new System.IO.StreamReader(CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(CurrentIndexPath) + @"-fields.txt"))
            {

                while (!reader.EndOfStream)
                {
                    fields.Add(reader.ReadLine());

                }

            }
            return fields;
        }

        public static HashSet<string> LoadUsersFromDisk(string CurrentIndexPath)
        {
            HashSet<string> users = new HashSet<string>();
            using (System.IO.StreamReader reader = new System.IO.StreamReader(CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(CurrentIndexPath) + @"-users.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var kvp = reader.ReadLine().Split('+');
                    
                    users.Add(kvp[0]);
                    UserColors.Add(kvp[0], Color.FromArgb(int.Parse(kvp[1]))); //bad practice!
                }
            }

            return users;
        }

        public static BTreeDictionary<DateTime, int> LoadStatsFromDisk(string CurrentIndexPath)
        {
            BTreeDictionary<DateTime, int> stats = new BTreeDictionary<DateTime, int>();
            using (System.IO.StreamReader reader = new System.IO.StreamReader(CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(CurrentIndexPath) + @"-stats.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] kvp = line.Split('#');
                    stats.Add(DateTime.Parse(kvp[0]), Int32.Parse(kvp[1]));
                }
            }
            return stats;
        }
        #endregion
        public static void InitLookup(string[] allFields)
        {
            lookup = new int[3];
            foreach (var field in SelectedFields)
            {
                if (field == DateFieldKey)
                {
                    lookup[0] = Array.IndexOf(allFields, DateFieldKey);
                }
                if (field == SenderFieldKey)
                {
                    lookup[1] = Array.IndexOf(allFields, SenderFieldKey);
                }
                if (field == TextFieldKey)
                {
                    lookup[2] = Array.IndexOf(allFields, TextFieldKey);
                }
            }
        }
        public static List<DynamicMessage> LoadSomeDocuments(int count)
        {
            List<DynamicMessage> messages = new List<DynamicMessage>();


            for (int i = viewerReadIndex; i < count + viewerReadIndex; i++)
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

                foreach (var field in SelectedFields)
                {


                    temp.Add(document.GetField(field).GetStringValue());


                }

                DynamicMessage message = new DynamicMessage(temp, SelectedFields, DateFieldKey, document.GetField("id").GetInt32Value().Value);
                messages.Add(message);


            }

            viewerReadIndex = count + viewerReadIndex;
            return messages;
        }

        public static int PopulateIndex(string filePath, string[] allFields, bool header)
        {

            int result = 0;
            int count = 0;

            int indexingValue = 0;
            if (lookup != null)
            {
                string[] row = null;
                DateTime date;
                using (var fileReader = new CsvReader(filePath))
                {
                    if (!header)
                    {
                        fileReader.ReadRow(ref row); //header read;
                    }

                    while (fileReader.ReadRow(ref row))

                    {
                        count++;
                        var t = row[lookup[0]];
                        date = DateTime.Parse(t);
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
                        document.Add(new Int32Field("id", indexingValue, Field.Store.YES));
                        
                        indexingValue++;

                        for (int i = 0; i < row.Length; i++)
                        {
                            if (lookup.Contains(i))
                            {
                                if (i == lookup[0])
                                {
                                    var temp = DateTools.DateToString(date, DateTools.Resolution.SECOND); //just in case
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
                                if (SelectedFields.Contains(allFields[i]))
                                {
                                    document.Add(new StringField(allFields[i], row[i], Field.Store.YES));
                                }

                            }
                            //TODO: Still need to redesign this. Rework storing/indexing paradigm.

                        }
                        LuceneService.Writer.AddDocument(document);
                    }
                    LuceneService.Writer.Commit();
                    LuceneService.Writer.Flush(triggerMerge: false, applyAllDeletes: false);
                    CheckDir();
                    PopulateUserColors();
                    SaveInfoToDisk(count);
                    SaveFieldsToDisk();
                    SaveUsersToDisk();
                    SaveStatsToDisk();
                    
                    OpenReader();
                    result = 1;
                    return result;

                }
            }
            return result;
        }


        public static void PopulateUserColors()
        {
            var colors = ColorLibrary.ColorGenerator.GenerateHSLuvColors(UserKeys.Count, false);
            int i = 0;
            foreach(var user in UserKeys)
            {
                UserColors.Add(user, colors[i]);
                i++;
            }

        }
        private static void OpenParser()
        {
            if (LuceneService.Analyzer != null)
            {
                LuceneService.Parser = new QueryParser(LuceneService.AppLuceneVersion, IndexService.TextFieldKey, LuceneService.Analyzer);
                LuceneService.UserParser = new QueryParser(LuceneService.AppLuceneVersion, IndexService.SenderFieldKey, LuceneService.Analyzer);
            }
        }

        private static void OpenAnalyzers()
        {

            LuceneService.Analyzer = new StandardAnalyzer(LuceneService.AppLuceneVersion);
            LuceneService.NGrammer = new NGramAnalyzer(Analyzer.PER_FIELD_REUSE_STRATEGY);
        }
        public static void OpenWriter()
        {

            OpenAnalyzers();
            LuceneService.IndexConfig = new IndexWriterConfig(LuceneService.AppLuceneVersion, LuceneService.Analyzer);
            LuceneService.IndexConfig.MaxBufferedDocs = IndexWriterConfig.DISABLE_AUTO_FLUSH;
            LuceneService.IndexConfig.RAMBufferSizeMB = 50.0;
            LuceneService.IndexConfig.OpenMode = OpenMode.CREATE;
            LuceneService.Writer = new IndexWriter(LuceneService.Dir, LuceneService.IndexConfig);
            OpenParser();




        }

        private static void OpenReader()
        {

            LuceneService.DirReader = DirectoryReader.Open(LuceneService.Dir);
            LuceneService.Searcher = new IndexSearcher(LuceneService.DirReader);
        }

        public static void OpenDirectory()
        {
            LuceneService.Dir = FSDirectory.Open(CurrentIndexPath);
        }

        public static void OpenIndex()
        {
            if (LuceneService.Dir != null)
            {
                if (DirectoryReader.IndexExists(LuceneService.Dir))
                {
                    OpenAnalyzers();
                    OpenReader();
                    OpenParser();
                    //LoadInfoFromDisk(LuceneService.Dir.Directory.FullName);

                }
                else
                {
                    throw new Exception("No index here");
                }
            }
        }

        public static DynamicMessage RetrieveMessageById(int id)
        {

            var query = NumericRangeQuery.NewInt32Range("id", id, id, true, true);
            ScoreDoc doc = LuceneService.Searcher.Search(query, 1).ScoreDocs.FirstOrDefault();
            List<string> data = new List<string>();
            Document idoc = LuceneService.Searcher.Doc(doc.Doc);
            foreach (var field in SelectedFields)
            {
                data.Add(idoc.GetField(field).GetStringValue());
            }

            return new DynamicMessage(data, SelectedFields, DateFieldKey, idoc.GetField("id").GetInt32Value().Value);

        }


    }
}
