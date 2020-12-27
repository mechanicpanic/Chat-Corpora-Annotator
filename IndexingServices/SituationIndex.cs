using CSharpTest.Net.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IndexEngine
{
    
    public static class SituationIndex
    {
        public static Dictionary<string, Dictionary<int, List<int>>> container { get; set; } 
        private static Dictionary<string, int> TagsetCounter { get; set; }
        static SituationIndex()
        {
            if(File.Exists(IndexService.CurrentIndexPath + @"\info"+"situations.txt"))
            {
                LoadIndexFromDisk(IndexService.CurrentIndexPath + @"\info" + @"\situations.txt");
            }
            else
            {
                container = new Dictionary<string, Dictionary<int, List<int>>>();
            }
        }
        private static void LoadIndexFromDisk(string file)
        {
            var jsonString = File.ReadAllText(file);
            container = JsonSerializer.Deserialize<Dictionary<string, Dictionary<int, List<int>>>>(jsonString);
        }

        private static void WriteIndexToDisk(string file)
        {
            var jsonString = JsonSerializer.Serialize(container);
            File.WriteAllText(file, jsonString);
        }
        public static void AddSituationToIndex(List<int> messages, int id, string situation)
        {
            if (!container.ContainsKey(situation)) {
                container.Add(situation, new Dictionary<int, List<int>>());
                container[situation].Add(id, messages);
                    }
            else
            {
                if (!container[situation].ContainsKey(id))
                {
                    
                    container[situation].Add(id, messages);
                }
                else
                {
                    
                }
            }
        }
        public static void RemoveSituationFromIndex(int id, string situation)
        {
            
            if(container.ContainsKey(situation) && container[situation].ContainsKey(id))
            {
                foreach(var i in container[situation][id])
                {
                    MessageContainer.Messages[i].Situations.Remove(situation);
                }
                container[situation].Remove(id);
            }
            
        }

        public static void RemoveMessageFromSituation(string situation, int id, int message)
        {
            if (container.ContainsKey(situation))
            {
                container[situation][id].Remove(message);
            }
            MessageContainer.Messages[message].Situations.Remove(situation);
        }

    }
}
