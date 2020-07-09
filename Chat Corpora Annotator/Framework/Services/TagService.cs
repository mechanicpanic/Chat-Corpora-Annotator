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

        void AddSituation(List<string> messages, string situation);
        void UpdateSituation(Guid key, string tag);
        void DeleteSituation(string key);



    }
    public class TagService : ITagService
    {
        public string ProjectTagset { get; set; }
        public TagService()
        {
            
        }

        public void AddSituation(List<string> messages, string situation)
        {
            SituationIndex.AddSituationToIndex(messages, situation);
        }

        public void UpdateSituation(Guid key, string tag)
        {
            SituationIndex.Index[key].Remove(tag);
        }

        public void DeleteSituation(string key)
        {
            throw new NotImplementedException();
        }


        public void UpdateTagsetIndex(string name)
        {
            if (!TagsetIndex.Index.ContainsKey(name))
            {
                TagsetIndex.AddNewIndexEntry(name, new List<string>());
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
