using CSharpTest.Net.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexEngine
{
    public static class TagsetIndex
    {
        static TagsetIndex() { }
        public static BTreeDictionary<string, List<string>> Index { get; private set; }

        public static void AddNewIndexEntry(string name, List<string> tags)
        {
            Index.Add(name, tags);
        }

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

        public static void DeleteIndexEntry(string name) { Index.Remove(name); }

        public static void WriteIndexToDisk()
        {

        }
        public static void ReadIndexFromDisk()
        {

        }
        public static List<string> RetrieveStoredTagset(string name)
        {
            List<string> tagset = new List<string>();
            tagset.Add(name);
            tagset.AddRange(Index[name]);
        }
       
    }
}
