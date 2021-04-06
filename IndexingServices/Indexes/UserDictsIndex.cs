using CSharpTest.Net.Collections;
using IndexEngine.Paths;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexEngine.Indexes
{
    public class UserDictsIndex : IIndex<string, List<string>>
    {
        public IDictionary<string, List<string>> IndexCollection { get; private set; } = new Dictionary<string, List<string>>();

        public int ItemCount { get { return IndexCollection.Count; } }

        public void AddIndexEntry(string key, List<string> value)
        {
            if (!IndexCollection.ContainsKey(key))
            {
                IndexCollection.Add(key, value);
            }
        }

        public bool CheckDirectory()
        {
            return (Directory.Exists(ProjectInfo.InfoPath));
        }

        public bool CheckFiles()
        {
            return (File.Exists(ToolInfo.UserDictsPath));
        }

        public void DeleteIndexEntry(string key)
        {
            if (IndexCollection.ContainsKey(key))
            {

            }
        }

        public void FlushIndexToDisk()
        {
            throw new NotImplementedException();
        }

        public int GetValueCount(string key)
        {
            throw new NotImplementedException();
        }

        public void ReadIndexFromDisk()
        {
            throw new NotImplementedException();
        }

        public void UnloadData()
        {
            throw new NotImplementedException();
        }

        public void UpdateIndexEntry(string key, List<string> value)
        {
            throw new NotImplementedException();
        }

        public void ImportNewDictFromFile(string path) 
        {
            if (File.Exists(path))
            {
                var arr = File.ReadAllLines(path);
                var value = arr.Skip(1);
                AddIndexEntry(arr[0], value.ToList());
            }
        }
    }
}
