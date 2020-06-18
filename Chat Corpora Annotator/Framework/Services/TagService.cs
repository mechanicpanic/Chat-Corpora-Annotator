using CSharpTest.Net.Collections;
using System;
using System.Collections.Generic;
using IndexEngine;
namespace Viewer.Framework.Services
{
    public interface ITagService
    {
        
        void AddSituation(List<string> messages, string situation);
        void UpdateSituation();
        void DeleteSituation();

        void UpdateTagsetIndex(string name, List<string> tags);

    }
    public class TagService : ITagService
    {
        public TagService()
        {
            
        }
        public Dictionary<List<string>, Tuple<string, Guid>> SituationIndex { get; set; } = new Dictionary<List<string>, Tuple<string, Guid>>();
        //public BTreeDictionary<string, List<string>> TagsetIndex { get; set; } = new BTreeDictionary<string, List<string>>();

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
    }
}
