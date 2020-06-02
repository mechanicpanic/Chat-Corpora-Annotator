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
        public static BTreeDictionary<int,List<DynamicMessage>> FindMeetSituations()
        {
            int index = 0;
            BTreeDictionary<int,List<DynamicMessage>> result = new BTreeDictionary<int,List<DynamicMessage>>();
            for (int i = 0; i <= LuceneService.DirReader.MaxDoc - 25; i++) 
            {
                var quest = LuceneService.DirReader.Document(i).GetField("id").GetStringValue();
                if (Extractor.IsQuestionList[quest])
                {
                    var text = LuceneService.DirReader.Document(i).GetField(IndexService.TextFieldKey).GetStringValue();
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
                            result.Add(index,list);
                            index++;
                            break;
                        }
                        if(Extractor.TimeList.ContainsKey(loc))
                        {
                            List<DynamicMessage> list = new List<DynamicMessage>();
                            for (int add = i; add < i + 25; add++)
                            {
                                list.Add(IndexService.RetrieveMessageById(loc));
                            }
                            result.Add(index,list);
                            index++;
                            break;
                        }
                    }
                }
            }
            return result;
        }


    }
}
