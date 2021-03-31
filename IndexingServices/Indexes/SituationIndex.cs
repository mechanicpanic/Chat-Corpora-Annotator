using IndexEngine.Paths;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace IndexEngine
{
    public class SituationIndexNew : Index<string, Dictionary<int, List<int>>>
    {
        private static readonly Lazy<SituationIndexNew> lazy = new Lazy<SituationIndexNew>(() => new SituationIndexNew());

        public static SituationIndexNew GetInstance()
        {
            return lazy.Value;
        }

        private SituationIndexNew() { }

        public override Dictionary<string, Dictionary<int, List<int>>> IndexCollection { get; set; } = new Dictionary<string, Dictionary<int, List<int>>>();

        public override void AddIndexEntry(string key, Dictionary<int, List<int>> value)
        {
            IndexCollection.Add(key, value);
        }

        public override void DeleteIndexEntry(string key)
        {
            IndexCollection.Remove(key);
        }

        public override void FlushIndexToDisk()
        {
            var jsonString = JsonSerializer.Serialize(IndexCollection);
            File.WriteAllText(ProjectInfo.SituationsPath, jsonString);
        }

        public override void ReadIndexFromDisk()
        {
            var jsonString = File.ReadAllText(ProjectInfo.SituationsPath);

            IndexCollection = JsonSerializer.Deserialize<Dictionary<string, Dictionary<int,List<int>>>>(jsonString);
        }

        public override void UnloadData()
        {
            IndexCollection.Clear();
        }

        public override void UpdateIndexEntry(string key, Dictionary<int, List<int>> value)
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
