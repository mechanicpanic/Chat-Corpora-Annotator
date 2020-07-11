using CSharpTest.Net.Collections;
using System;
using System.Collections.Generic;
using IndexEngine;
using edu.stanford.nlp.util;

namespace Viewer.Framework.Services
{
    public interface ITagService
    {
        string ProjectTagset { get; set; }
        void UpdateTagsetIndex(string name);
        void EditTagset(string name, string keys, int op);

        void AddSituation(List<int> messages, string situation);
        void UpdateSituation(Guid key, int message);
        void DeleteSituation(Guid key);



    }
    public class TagService : ITagService
    {
        public string ProjectTagset { get; set; }
        public TagService()
        {
            
        }

        public void AddSituation(List<int> messages, string situation)
        {
            SituationIndex.AddSituationToIndex(messages, situation);
        }

        public void UpdateSituation(Guid key, int message)
        {
            SituationIndex.Index[key].Remove(message);
        }

        public void DeleteSituation(Guid key)
        {
            SituationIndex.Index.Remove(key);
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
    }
}
