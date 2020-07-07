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
        public static BTreeDictionary<Guid, List<string>> Index { get; private set; }
        public static Dictionary<Guid, string> NameLookup { get; private set; }

        static SituationIndex()
        {
            if(File.Exists(IndexService.CurrentIndexPath + @"\info"+"situations.txt"))
            {
                LoadIndexFromDisk(IndexService.CurrentIndexPath + @"\info" + @"\situations.txt");
            }
            else
            {
                Index = new BTreeDictionary<Guid, List<string>>();
                NameLookup = new Dictionary<Guid, string>();

                //File.Create(IndexService.CurrentIndexPath + @"\info" + @"\situations.txt");
            }
        }
        private static void LoadIndexFromDisk(string file)
        {
            var jsonString = File.ReadAllText(file);
            Index = JsonSerializer.Deserialize<BTreeDictionary<Guid, List<string>>>(jsonString);
        }

        private static void WriteIndexToDisk(string file)
        {
            var jsonString = JsonSerializer.Serialize(Index);
            File.WriteAllText(file, jsonString);
        }
        public static void AddSituationToIndex(List<string> messages, string situation)
        {
            Guid guid = Guid.NewGuid();
            Index.Add(guid, messages);
            NameLookup.Add(guid, situation);
        }

    }
}
