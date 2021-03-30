using IndexEngine.Paths;
using System.Collections.Generic;
using System.IO;

namespace IndexEngine
{

    public static class SituationIndex
    {
        public static Dictionary<string, Dictionary<int, List<int>>> Index { get; set; }
        public static Dictionary<string, int> TagsetCounter = new Dictionary<string, int>();

        public static void UnloadData()
        {
            Index.Clear();
            TagsetCounter.Clear();
        }

        static SituationIndex()
        {
            if (File.Exists(ProjectInfo.SituationsPath))
            {
                LoadIndexFromDisk(ProjectInfo.SituationsPath);
            }
            else
            {
                Index = new Dictionary<string, Dictionary<int, List<int>>>();
            }
        }

        private static void LoadIndexFromDisk(string path)
        {

        }

        public static int SituationCount()
        {
            int count = 0;
            foreach (var kvp in Index)
            {
                count += kvp.Value.Count;
            }
            return count;
        }

        public static void RetrieveDictFromMessageContainer(List<DynamicMessage> msg)
        {
            foreach (var m in msg)
            {
                //if (!Index.ContainsKey(m.Situations.ElementAt(0).Key))
                {
                    //;
                    foreach (var kvp in m.Situations)
                    {
                        if (!Index.ContainsKey(kvp.Key))
                        {
                            Index.Add(kvp.Key, new Dictionary<int, List<int>>());
                        }
                        if (!Index[kvp.Key].ContainsKey(kvp.Value))
                        {
                            Index[kvp.Key].Add(kvp.Value, new List<int>());
                            Index[kvp.Key][kvp.Value].Add(m.Id);
                        }
                        else
                        {
                            Index[kvp.Key][kvp.Value].Add(m.Id);
                        }

                    }

                }
            }
        }

        public static void RetrieveDictFromMessageContainer(DynamicMessage m)
        {
            foreach (var kvp in m.Situations)
            {
                if (!Index.ContainsKey(kvp.Key))
                {
                    Index.Add(kvp.Key, new Dictionary<int, List<int>>());
                }
                if (!Index[kvp.Key].ContainsKey(kvp.Value))
                {
                    Index[kvp.Key].Add(kvp.Value, new List<int>());
                    Index[kvp.Key][kvp.Value].Add(m.Id);
                }
                else
                {
                    Index[kvp.Key][kvp.Value].Add(m.Id);
                }

            }
        }


        public static void AddSituationToIndex(List<int> messages, int id, string situation)
        {
            if (!Index.ContainsKey(situation))
            {
                Index.Add(situation, new Dictionary<int, List<int>>());
                Index[situation].Add(id, messages);
            }
            else
            {
                if (!Index[situation].ContainsKey(id))
                {

                    Index[situation].Add(id, messages);
                }
            }
        }
        public static void RemoveSituationFromIndex(int id, string situation)
        {

            if (Index.ContainsKey(situation) && Index[situation].ContainsKey(id))
            {
                //foreach(var i in Index[situation][id])
                //{
                //    MessageContainer.Messages[i].Situations.Remove(situation);
                //}
                Index[situation].Remove(id);
            }

        }

        public static void RemoveMessageFromSituation(string situation, int id, int message)
        {
            if (Index.ContainsKey(situation))
            {
                Index[situation][id].Remove(message);
            }
            MessageContainer.Messages[message].Situations.Remove(situation);
        }

    }
}
