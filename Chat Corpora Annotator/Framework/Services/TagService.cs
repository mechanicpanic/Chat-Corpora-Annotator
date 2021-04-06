using IndexEngine;
using IndexEngine.Indexes;
using IndexEngine.Paths;
using System;
using System.Collections.Generic;
using System.IO;

namespace Viewer.Framework.Services
{

    public interface ITagService : IUnloadable
    {
        bool TagsetSet { get; set; }
        List<int> TaggedIds { get; set; }
        Dictionary<int, string> SituationContainer { get; set; }
        string ProjectTagset { get; set; }
        void EditTagset(string name, string keys, int op);

          void CheckTagset();

        void UnloadData();

    }


    public class TagService : ITagService
    {
        public bool TagsetSet { get; set; } = false;


        public void UnloadData()
        {
            TagsetSet = false;
            TaggedIds.Clear();
            SituationContainer.Clear();

        }
        public TagService()
        {

        }
        public void CheckTagset()
        {

            if (File.Exists(ProjectInfo.TagsetPath))
            {
                ProjectInfo.TagsetSet = true;
            }
            else
            {
                ProjectInfo.TagsetSet = false;
            }
        }
        public Dictionary<int, string> SituationContainer { get; set; } = new Dictionary<int, string>();
        public string ProjectTagset { get; set; }
        public List<int> TaggedIds { get; set; } = new List<int>();


        public void EditTagset(string name, string tag, int op)
        {
            
        }
    }
}
