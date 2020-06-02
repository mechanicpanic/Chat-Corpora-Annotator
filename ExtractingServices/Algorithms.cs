using IndexingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpTest.Net.Collections;
namespace ExtractingServices
{
    public static class Algorithms
    {
        private static List<string> codeKeywords;
        private static List<string> softKeywords;
        private static List<string> langKeywords;
        private static List<string> compKeywords;
        private static List<string> meetKeywords;

        static Algorithms()
        {
            codeKeywords = new List<string> { };
            softKeywords = new List<string> { };
            langKeywords = new List<string> { };
            compKeywords = new List<string> { };
            meetKeywords = new List<string> { "meet", "arrive", "host", "join", "drive" };

        }
        public static BTreeDictionary<int,List<DynamicMessage>> FindMeetSituations()
        {
            int index = 0;
            BTreeDictionary<int,List<DynamicMessage>> result = new BTreeDictionary<int,List<DynamicMessage>>();
            for (int i = 0; i <= LuceneService.DirReader.MaxDoc - 25; i++) 
            {
                var quest = LuceneService.DirReader.Document(i).GetField("id").GetStringValue();
                bool check = false;
                if (Extractor.IsQuestionList[quest])
                {
                    var text = LuceneService.DirReader.Document(i).GetField(IndexService.TextFieldKey).GetStringValue();

                    foreach (var word in meetKeywords)
                    {
                        if (text.Contains(word))
                        {
                            check = true;
                            break;
                        }

                    }
                }
                    if (check)
                    {
                        for (int j = i; j < i + 25; j++)
                        {
                            var loc = LuceneService.DirReader.Document(j).GetField("id").GetStringValue();
                            if (Extractor.LocList.ContainsKey(loc))
                            {
                                List<DynamicMessage> list = new List<DynamicMessage>();
                                for (int add = i; add < i + 25; add++)
                                {
                                    list.Add(IndexService.RetrieveMessageById(loc));
                                }
                                result.Add(index, list);
                                index++;
                                i = i + 25;
                                break;
                            }
                            if (Extractor.TimeList.ContainsKey(loc))
                            {
                                List<DynamicMessage> list = new List<DynamicMessage>();
                                for (int add = i; add < i + 25; add++)
                                {
                                    list.Add(IndexService.RetrieveMessageById(loc));
                                }
                                result.Add(index, list);
                                index++;
                                i = i + 25;
                                break;
                            }
                        }
                    }
                }
            
            return result;
        }

        public static BTreeDictionary<int, List<DynamicMessage>> FindCodeSituations()
        {
            BTreeDictionary<int, List<DynamicMessage>> result = new BTreeDictionary<int, List<DynamicMessage>>();
            for (int i = 0; i <= LuceneService.DirReader.MaxDoc - 10; i++)
            {
                var quest = LuceneService.DirReader.Document(i).GetField("id").GetStringValue();
                bool check = false;
                if (Extractor.URLList.ContainsKey(quest))
                {
                    var url = Extractor.URLList[quest];
                    
                    foreach (var word in codeKeywords)
                    {
                        if (url.Contains(word))
                        {
                            check = true;
                            break;
                        }
                    }
                    
                }
            }
            return result;
        }

        public static BTreeDictionary<int, List<DynamicMessage>> FindSoftSituations()
        {
            BTreeDictionary<int, List<DynamicMessage>> result = new BTreeDictionary<int, List<DynamicMessage>>();
            for (int i = 0; i <= LuceneService.DirReader.MaxDoc - 25; i++)
            {

            }
            return result;
        }

        public static BTreeDictionary<int, List<DynamicMessage>> FindJobSituations()
        {
            BTreeDictionary<int, List<DynamicMessage>> result = new BTreeDictionary<int, List<DynamicMessage>>();
            for (int i = 0; i <= LuceneService.DirReader.MaxDoc - 25; i++)
            {

            }
            return result;
        }
    }
}
