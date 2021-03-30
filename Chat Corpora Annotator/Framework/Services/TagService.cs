using IndexEngine;
using IndexEngine.Paths;
using System;
using System.Collections.Generic;
using System.IO;

namespace Viewer.Framework.Services
{

    public interface ITagService
    {
        bool TagsetSet { get; set; }
        List<int> TaggedIds { get; set; }
        Dictionary<int, string> SituationContainer { get; set; }
        string ProjectTagset { get; set; }
        void UpdateTagsetIndex(string name);
        void EditTagset(string name, string keys, int op);

        void AddSituation(List<int> messages, int id, string situation);

        void DeleteSituation(int id, string situation);
        void UpdateSituation_Removed(int message, int id, string situation);
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
                TagsetSet = true;
            }
            else
            {
                TagsetSet = false;
            }
        }
        public Dictionary<int, string> SituationContainer { get; set; } = new Dictionary<int, string>();
        public string ProjectTagset { get; set; }
        public List<int> TaggedIds { get; set; } = new List<int>();

        public void AddSituation(List<int> messages, int id, string situation)
        {
            SituationIndex.AddSituationToIndex(messages, id, situation);
        }



        public void UpdateTagsetIndex(string name)
        {
            if (!TagsetIndex.Index.ContainsKey(name))
            {
                TagsetIndex.AddNewIndexEntry(name);
            }
        }


        public void EditTagset(string name, string tag, int op)
        {
            if (TagsetIndex.Index.ContainsKey(name))
            {
                TagsetIndex.UpdateIndexEntry(name, tag, op);
            }
        }

        public void DeleteSituation(int id, string situation)
        {
            throw new NotImplementedException();
        }

        public void UpdateSituation_Removed(int message, int id, string situation)
        {
            throw new NotImplementedException();
        }
    }
}
