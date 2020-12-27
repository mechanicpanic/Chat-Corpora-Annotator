using CSharpTest.Net.Collections;
using System;
using System.Collections.Generic;
using IndexEngine;
using edu.stanford.nlp.util;
using System.Collections.ObjectModel;

namespace Viewer.Framework.Services
{

    public interface ITagService
    {

        string ProjectTagset { get; set; }
        void UpdateTagsetIndex(string name);
        void EditTagset(string name, string keys, int op);

        void AddSituation(List<int> messages, int id, string situation);

        void DeleteSituation(int id, string situation);
        void UpdateSituation_Removed(int message, int id, string situation);

    }


    public class TagService : ITagService
    {
        public string ProjectTagset { get; set; }

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
