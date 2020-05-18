using CSharpTest.Net.Collections;
using System;
using System.Collections.Generic;

namespace Viewer.Framework.Services
{
    public interface ITagService
    {
        BTreeDictionary<string, List<string>> TagsetIndex { get; set; }
        List<string> CurrentTagset { get; set; }
        Dictionary<List<string>, Tuple<string, Guid>> SituationIndex { get; set; }

        void UpdateTagset(List<string> tags);
        void AddSituation(List<string> messages, string situation);

    }
    public class TagService : ITagService
    {
        public List<string> CurrentTagset { get; set; }
        public Dictionary<List<string>, Tuple<string, Guid>> SituationIndex { get; set; } = new Dictionary<List<string>, Tuple<string, Guid>>();
        public BTreeDictionary<string, List<string>> TagsetIndex { get; set; } = new BTreeDictionary<string, List<string>>();

        public void AddSituation(List<string> messages, string situation)
        {
            SituationIndex.Add(messages, new Tuple<string, Guid>(situation, Guid.NewGuid()));
        }

        public void UpdateTagset(List<string> tags)
        {
            CurrentTagset.Clear();
            foreach (var tag in tags)
            {
                CurrentTagset.Add(tag);
            }
            
        }

        public void UpdateTagsetIndex(string name, List<string> tags)
        {
            if (TagsetIndex.Keys.Contains(name))
            {
                TagsetIndex.TryUpdate(name, tags);
            }
            else
            {
                TagsetIndex.Add(name, tags);
            }
        }

    }
}
