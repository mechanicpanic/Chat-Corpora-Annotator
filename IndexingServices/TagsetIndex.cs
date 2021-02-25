using CSharpTest.Net.Collections;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IndexEngine
{
    public static class TagsetIndex
    {
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\CCA\tagsets.txt";
        static string colorpath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\CCA\tagsetscolors.txt";
        //Eventually I will phase out Index for ColorIndex altogether.
        static TagsetIndex() 
        {
            
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

        private static string[] ColorValues = {
    
    "#98724c",
    "#908f32",
    "#c8b55b",
    "#af652f",
    "#c3c13d",
    "#70a16c",
    "#e4dc8c",
    "#d3d3d3",
    "#a1d569",
    "#f59335",
    "#4ec2e8",
    "#fec7cd",
    "#95c1c0",
    "#b3b3b3",
    "#ed5466",
    "#afdb80",
    "#d2a4b4",
    "#75a1a0",
    "#a54242",
    "#de935f",
    "#cc6666",
    "#b5bd68",
    "#f0c674",
    "#81a2be",
    "#b294bb",
    "#8abeb7",
    "#c5c8c6"
        };

        public static void AddNewIndexEntry(string name)
        {
            Index.Add(name, new List<string>());
            ColorIndex.Add(name, new Dictionary<string, Color>());
            
        }

        public static Color[] GenerateTagColors(int count)
        {
            //KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            //List<Color> picker = new List<Color>();
            //foreach (KnownColor knowColor in colors)
            //{
            //    Color color = Color.FromKnownColor(knowColor);
            //    if(color.Equals(Color.AntiqueWhite) || color.Equals(Color.Black) || color.Equals(Color.Transparent) || color.Equals(Color.Chartreuse))
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        picker.Add(color);
            //    }
            //}
            Color[] colors = new Color[count];
            int random = rnd.Next(0, ColorValues.Length);
            int mem = -1;
            for (int i = 0; i < count; i++) {
                if (mem == random)
                {
                    random = rnd.Next(0, ColorValues.Length);
                }
                Color color = System.Drawing.ColorTranslator.FromHtml(ColorValues[random]);
                mem = random;
                random = rnd.Next(0, ColorValues.Length);
                colors[i] = color;
            }

            return colors;


        }

        public static void WriteInfoToDisk()
        {
           

            WriteIndexToDisk(path, colorpath);
            
        }
        public static void DeleteIndexEntry(string name) { Index.Remove(name); ColorIndex.Remove(name); }

        public static void UpdateIndexEntry(string name, string tag,int type) { 
            if(type == 1)
            {
                Index[name].Add(tag);
                ColorIndex[name].Add(tag, GenerateTagColors(0)[0]);
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
                    foreach(var kp in kvp.Value)
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
                    if(arr[0].StartsWith("Tagset"))
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
            Color[] colors = GenerateTagColors(6);
            for(int i = 0; i < Index["default"].Count; i++)
            {
                ColorIndex["default"].Add(Index["default"][i], colors[i]);
            }
        }
       
    }
}