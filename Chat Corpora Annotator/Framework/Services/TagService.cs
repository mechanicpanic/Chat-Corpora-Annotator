using CSharpTest.Net.Collections;
using System;
using System.Collections.Generic;
using IndexEngine;
using edu.stanford.nlp.util;

namespace Viewer.Framework.Services
{
    public interface ITagService
    {
        void AddSituation(List<string> messages, string situation);
        void UpdateSituation();
        void DeleteSituation();

        void UpdateTagsetIndex(string name, List<string> tags);
        void EditTagset(string name, string type, int op);
        void ChangeProjectTagset();
    }
    public class TagService : ITagService
    {
        public TagService()
        {
            
        }

        public void ChangeProjectTagset() { }

        public void AddSituation(List<string> messages, string situation)
        {
            IndexEngine.SituationIndex.AddSituationToIndex(messages, situation);
        }

        public void UpdateTagsetIndex(string name, List<string> tags)
        {
            
        }

        public void UpdateSituation()
        {
            throw new NotImplementedException();
        }

        public void DeleteSituation()
        {
            throw new NotImplementedException();
        }

        public void EditTagset(string name, string tag, int op)
        {
            if (IndexEngine.TagsetIndex.Index.ContainsKey(name))
            {

                TagsetIndex.UpdateIndexEntry(name, tag, op);
                
            }
        }


    }
}
