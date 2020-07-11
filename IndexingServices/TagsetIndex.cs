using CSharpTest.Net.Collections;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        static Random rnd;
        public static BTreeDictionary<string, List<string>> Index { get; private set; }

        public static BTreeDictionary<string, Dictionary<string,Color>> ColorIndex { get; }
        public static void AddNewIndexEntry(string name)
        {
            Index.Add(name, new List<string>());
            ColorIndex.Add(name, new Dictionary<string, Color>());
            
        }

        public static Color GenerateTagColor()
        {
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        public static void WriteInfoToDisk()
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(IndexService.CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(IndexService.CurrentIndexPath) + @"-tagsets.txt"))
            {
                   
            }
        }
        public static void DeleteIndexEntry(string name) { Index.Remove(name); }

        public static void UpdateIndexEntry(string name, string tag,int type) { 
            if(type == 1)
            {
                Index[name].Add(tag);
                ColorIndex[name].Add(tag, GenerateTagColor());
            }
            if (type == 0)
            {
                Index[name].Remove(tag);
                ColorIndex[name].Remove(tag);
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
            //...
        }
       
    }
}
