using IndexEngine.Paths;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace IndexEngine
{
    public class SituationIndexNew : Index<string, Dictionary<int, List<int>>, int, List<int>>
    {
        private static readonly Lazy<SituationIndexNew> lazy = new Lazy<SituationIndexNew>(() => new SituationIndexNew());

        public static SituationIndexNew GetInstance()
        {
            return lazy.Value;
        }

        private SituationIndexNew() { }

        public override Dictionary<string, Dictionary<int, List<int>>> IndexCollection { get; set; } = new Dictionary<string, Dictionary<int, List<int>>>();

        public Dictionary<int, Dictionary<string, int>> InvertedIndex { get; set; } = new Dictionary<int, Dictionary<string, int>>();

        public override void AddOuterIndexEntry(string key, Dictionary<int, List<int>> value)
        {
            if (!IndexCollection.ContainsKey(key))
            {
                IndexCollection.Add(key, value);
            }
            else
            {
                foreach(var kvp in value)
                {
                    AddInnerIndexEntry(key, kvp.Key, kvp.Value);
                }
            }
            foreach(var kvp in value)
            {
                foreach(var id in kvp.Value)
                {
                    if (!InvertedIndex.ContainsKey(id)) {
                        InvertedIndex.Add(id, new Dictionary<string, int>());
                        InvertedIndex[id].Add(key, kvp.Key);
                        }
                    else
                    {
                        InvertedIndex[id].Add(key, kvp.Key);
                    }
                }
            }
        }
        public override void AddInnerIndexEntry(string key, int sid, List<int> messages)
        {
            if (IndexCollection.ContainsKey(key))
            {
                IndexCollection[key].Add(sid, messages);
            }
            else
            {
                IndexCollection.Add(key, new Dictionary<int, List<int>>());
                IndexCollection[key].Add(sid, messages);
            }

            foreach (var id in messages)
            {
                if (!InvertedIndex.ContainsKey(id))
                {
                    InvertedIndex.Add(id, new Dictionary<string, int>());
                    InvertedIndex[id].Add(key, sid);
                }
                else
                {
                    InvertedIndex[id].Add(key, sid);
                }
            }
        }


        public override void DeleteOuterIndexEntry(string key)
        {
            IndexCollection.Remove(key);
            foreach(var kvp in InvertedIndex)
            {
                if (kvp.Value.ContainsKey(key))
                {
                    kvp.Value.Remove(key);
                }
            }

        }

        public override void DeleteInnerIndexEntry(string key, int sid)
        {
            IndexCollection[key].Remove(sid);
            foreach(var kvp in InvertedIndex)
            {
                if (kvp.Value.ContainsKey(key)){
                    if(kvp.Value[key] == sid)
                    {
                        kvp.Value.Remove(key);
                    }
                }
            }
        }


        public override void FlushIndexToDisk()
        {
            
        }

        public override void ReadIndexFromDisk()
        {
            
        }

        public override void UnloadData()
        {
            IndexCollection.Clear();
            InvertedIndex.Clear();
        }

        public override void UpdateOuterIndexEntry(string key, Dictionary<int, List<int>> value)
        {
            throw new System.NotImplementedException();
        }

        internal override bool CheckDirectory()
        {
            return false;
        }

        internal override bool CheckFiles()
        {
            return false;
        }



        public override void InitializeIndex(List<string> list)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessageFromSituation() { }
    }

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
                LoadIndexFromDisk();
            }
            else
            {
                Index = new Dictionary<string, Dictionary<int, List<int>>>();
            }
        }

        private static void LoadIndexFromDisk()
        {
            var jsonString = File.ReadAllText(ProjectInfo.SituationsPath);
            Index = (Dictionary<string, Dictionary<int, List<int>>>)JsonConvert.DeserializeObject(jsonString);
        }

        public static void WriteIndexToDisk()
        {

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(Index);

            File.WriteAllText(ProjectInfo.SituationsPath, jsonString);
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
