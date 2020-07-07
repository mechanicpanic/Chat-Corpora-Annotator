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
    public static class TagsetIndex
    {
        static TagsetIndex() { }
        public static BTreeDictionary<string, List<string>> Index { get; private set; }

        //private static BTreeDictionary<string, Color> ColorIndex;
        public static void AddNewIndexEntry(string name, List<string> tags)
        {
            Index.Add(name, tags);
        }

        public static void DeleteIndexEntry(string name) { Index.Remove(name); }

        public static void UpdateIndexEntry(string name, string tag,int type) { 
            if(type == 1)
            {
                Index[name].Add(tag);
            }
            if (type == 0)
            {
                Index[name].Remove(tag);
            }

        }


        public static void WriteIndexToDisk(string file)
        {
            var jsonString = JsonSerializer.Serialize(Index);
            File.WriteAllText(file, jsonString);
        }
        public static void ReadIndexFromDisk(string file)
        {
            var jsonString = File.ReadAllText(file);
            Index = JsonSerializer.Deserialize<BTreeDictionary<string,List<string>>>(jsonString);
        }
        public static List<string> RetrieveStoredTagset(string name)
        {
            List<string> tagset = new List<string>();
            tagset.Add(name);
            tagset.AddRange(Index[name]);

            return tagset;
        }

        private static void AddDefaultTagset()
        {
            Index = new BTreeDictionary<string, List<string>>();
            List<string> tags = {""}
            AddNewIndexEntry("default",)
        }
       
    }
}
