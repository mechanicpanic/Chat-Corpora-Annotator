using ColorLibrary;
using CSharpTest.Net.Collections;
using IndexEngine.Paths;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace IndexEngine.Indexes
{
    public class TagsetIndex: INestedIndex<string,Dictionary<string,Color>, string, Color>
    {
        private static readonly Lazy<TagsetIndex> lazy = new Lazy<TagsetIndex>(() => new TagsetIndex());

        public static TagsetIndex GetInstance()
        {
            return lazy.Value;
        }

        private TagsetIndex() 
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
        public static BTreeDictionary<string, List<string>> Index { get; private set; }

        public static BTreeDictionary<string, Dictionary<string, Color>> ColorIndex { get; set; }

        public IDictionary<string, Dictionary<string, Color>> IndexCollection { get; private set; } = new BTreeDictionary<string, Dictionary<string, Color>>();

        public int ItemCount => throw new NotImplementedException();

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

        public bool CheckFiles()
        {
            throw new NotImplementedException();
        }

        public bool CheckDirectory()
        {
            throw new NotImplementedException();
        }

        public void ReadIndexFromDisk()
        {
            if (CheckFiles())
            {
                var jsonString = File.ReadAllText(ToolInfo.TagsetColorIndexPath);
                IndexCollection = JsonConvert.DeserializeObject<BTreeDictionary<string, >>(jsonString);
            }
        }

        public void FlushIndexToDisk()
        {
            var jsonString = JsonConvert.SerializeObject(IndexCollection);
            File.WriteAllText(ToolInfo.TagsetColorIndexPath, jsonString);
        }

        public void AddIndexEntry(string key, Dictionary<string, Color> value)
        {
            if (!IndexCollection.ContainsKey(key) && value == null)
            {
                IndexCollection.Add(key, new Dictionary<string, Color>());
            }
            if(!IndexCollection.ContainsKey(key) && value != null)
            {
                IndexCollection.Add(key, value);
            }
        }

        public void AddInnerIndexEntry(string key, string inkey, Color invalue)
        {
            if (IndexCollection.ContainsKey(key))
            {
                if (!IndexCollection[key].ContainsKey(inkey))
                {
                    IndexCollection[key].Add(inkey, invalue);
                }
            }
        }


        public void AddInnerIndexEntry(string key, string inkey)
        {
            if (IndexCollection.ContainsKey(key))
            {
                if (!IndexCollection[key].ContainsKey(inkey))
                {
                    IndexCollection[key].Add(inkey, ColorGenerator.GenerateHSVColors(0)[0]);
                }
            }
        }
        public void DeleteIndexEntry(string key)
        {
            if (IndexCollection.ContainsKey(key))
            {
                IndexCollection.Remove(key);
            }
        }

        public void DeleteInnerIndexEntry(string key, string inkey)
        {
            if (IndexCollection.ContainsKey(key))
            {
                if (!IndexCollection[key].ContainsKey(inkey))
                {
                    IndexCollection[key].Remove(inkey);
                }
            }
        }

        public void InitializeIndex(List<string> list)
        {
            foreach(var tag in list)
            {
                AddIndexEntry(tag, null);
            }
        }

        public void UpdateIndexEntry(string key, Dictionary<string, Color> value)
        {
            throw new NotImplementedException();
        }

        public int GetValueCount(string key)
        {
            if (IndexCollection.ContainsKey(key))
            {
                return IndexCollection[key].Count;
            }
            else
            {
                return -1;
            }
        }

        public int GetInnerValueCount(string key, string inkey)
        {
            throw new NotImplementedException();
        }

        public void UnloadData()
        {
            IndexCollection.Clear();
        }
    }
}