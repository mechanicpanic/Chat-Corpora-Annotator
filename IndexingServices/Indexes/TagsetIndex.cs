using ColorLibrary;
using CSharpTest.Net.Collections;
using IndexEngine.Paths;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace IndexEngine
{
    public static class TagsetIndex
    {


        static TagsetIndex()
        {

            if (!File.Exists(ToolInfo.TagsetIndexPath))
            {
                AddDefaultTagset();
            }
            else
            {
                ReadIndexFromDisk(ToolInfo.TagsetIndexPath, ToolInfo.TagsetColorIndexPath);
            }
        }
        static Random rnd = new Random();
        public static BTreeDictionary<string, List<string>> Index { get; private set; }

        public static BTreeDictionary<string, Dictionary<string, Color>> ColorIndex { get; set; }



        public static void AddNewIndexEntry(string name)
        {
            Index.Add(name, new List<string>());
            ColorIndex.Add(name, new Dictionary<string, Color>());

        }



        public static void WriteInfoToDisk()
        {


            WriteIndexToDisk(ToolInfo.TagsetIndexPath, ToolInfo.TagsetColorIndexPath);

        }
        public static void DeleteIndexEntry(string name) { Index.Remove(name); ColorIndex.Remove(name); }

        public static void UpdateIndexEntry(string name, string tag, int type)
        {
            if (type == 1)
            {
                Index[name].Add(tag);
                ColorIndex[name].Add(tag, ColorGenerator.GenerateHSVColors(0)[0]);
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
            //var jsonString2 = JsonSerializer.Serialize(ColorIndex);
            File.WriteAllText(file, jsonString);
            //File.WriteAllText(colorfile, jsonString2);
            using (StreamWriter sw = new StreamWriter(colorfile))
            {
                foreach (var kvp in ColorIndex)
                {
                    sw.WriteLine("Tagset: " + kvp.Key);
                    foreach (var kp in kvp.Value)
                    {
                        sw.WriteLine(kp.Key + " " + kp.Value.Name);
                    }
                    sw.WriteLine("End of Tagset");
                }
            }
        }


        public static void ReadIndexFromDisk(string file, string colorfile)
        {
            var jsonString = File.ReadAllText(file);
            var jsonString2 = File.ReadAllText(colorfile);
            Index = JsonSerializer.Deserialize<BTreeDictionary<string, List<string>>>(jsonString);
            //ColorIndex = JsonSerializer.Deserialize<BTreeDictionary<string,Dictionary<string, Color>>>(jsonString2);

            ColorIndex = new BTreeDictionary<string, Dictionary<string, Color>>();
            using (StreamReader sr = new StreamReader(colorfile))
            {
                ColorConverter colorConverter = new ColorConverter();
                Dictionary<string, Color> val = new Dictionary<string, Color>();
                string tagset = sr.ReadLine().Split(' ')[1];
                while (!sr.EndOfStream)
                {


                    string line = sr.ReadLine();
                    var arr = line.Split(' ');
                    if (!arr[0].StartsWith("Tagset") && !arr[0].StartsWith("End"))
                    {
                        int argb = Int32.Parse(arr[1], NumberStyles.HexNumber);
                        Color clr = Color.FromArgb(argb);

                        val.Add(arr[0], clr);
                    }
                    if (arr[0].StartsWith("Tagset"))
                    {
                        tagset = arr[1];
                    }
                    if (arr[0].StartsWith("End"))
                    {
                        ColorIndex.Add(tagset, val);
                        val = new Dictionary<string, Color>();
                    }
                }

            }
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
            Index.Add("default", new List<string> { "JobSearch", "CodeHelp", "FCCBug", "SoftwareSupport", "OSSelection", "Meeting" });
            ColorIndex = new BTreeDictionary<string, Dictionary<string, Color>>();
            ColorIndex.Add("default", new Dictionary<string, Color>());
            Color[] colors = ColorGenerator.GenerateHSLuvColors(6);



            for (int i = 0; i < Index["default"].Count; i++)
            {
                ColorIndex["default"].Add(Index["default"][i], colors[i]);
            }
        }
    }
}