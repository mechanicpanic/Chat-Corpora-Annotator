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
        //Eventually I will phase out Index for ColorIndex altogether.
        static TagsetIndex() 
        {
            string path = IndexService.CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(IndexService.CurrentIndexPath) + @"-tagsets.txt";
            string colorpath = IndexService.CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(IndexService.CurrentIndexPath) + @"-tagsetscolors.txt";
            if (!File.Exists(path))
            {
                AddDefaultTagset();
            }
            else
            {
                ReadIndexFromDisk(path, colorpath);
            }
        }
        static Random rnd = new Random();
        public static BTreeDictionary<string, List<string>> Index { get; private set; }

        public static BTreeDictionary<string, Dictionary<string,Color>> ColorIndex { get; set; }
        public static void AddNewIndexEntry(string name)
        {
            Index.Add(name, new List<string>());
            ColorIndex.Add(name, new Dictionary<string, Color>());
            
        }

        public static Color GenerateTagColor()
        {
            KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            List<Color> picker = new List<Color>();
            foreach (KnownColor knowColor in colors)
            {
                Color color = Color.FromKnownColor(knowColor);
                if(color.Equals(Color.AntiqueWhite) || color.Equals(Color.Black) || color.Equals(Color.Transparent) || color.Equals(Color.Chartreuse))
                {
                    continue;
                }
                else
                {
                    picker.Add(color);
                }
            }
            int random = rnd.Next(0, picker.Count);
            return picker[random];
        }

        public static void WriteInfoToDisk()
        {
            string path = IndexService.CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(IndexService.CurrentIndexPath) + @"-tagsets.txt";
            string colorpath = IndexService.CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(IndexService.CurrentIndexPath) + @"-tagsetscolors.txt";

            WriteIndexToDisk(path, colorpath);
            
        }
        public static void DeleteIndexEntry(string name) { Index.Remove(name); ColorIndex.Remove(name); }

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


        public static void WriteIndexToDisk(string file, string colorfile)
        {
            var jsonString = JsonSerializer.Serialize(Index);
            var jsonString2 = JsonSerializer.Serialize(ColorIndex);
            File.WriteAllText(file, jsonString);
            File.WriteAllText(colorfile, jsonString2);
        }
        public static void ReadIndexFromDisk(string file, string colorfile)
        {
            var jsonString = File.ReadAllText(file);
            var jsonString2 = File.ReadAllText(colorfile);
            Index = JsonSerializer.Deserialize<BTreeDictionary<string,List<string>>>(jsonString);
            ColorIndex = JsonSerializer.Deserialize<BTreeDictionary<string,Dictionary<string, Color>>>(jsonString2);
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
            Index.Add("default", new List<string> { "JobDiscussion", "Meeting", "CodeAssistance", "SoftwareSupport" });
            ColorIndex = new BTreeDictionary<string, Dictionary<string, Color>>();
            ColorIndex.Add("default", new Dictionary<string, Color>());
            foreach(var tag in Index["default"])
            {
                ColorIndex["default"].Add(tag, GenerateTagColor());
            }
        }
       
    }
}