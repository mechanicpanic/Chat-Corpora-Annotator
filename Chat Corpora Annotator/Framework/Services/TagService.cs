using CSharpTest.Net.Collections;
using System;
using System.Collections.Generic;

namespace Viewer.Framework.Services
{
    public interface ITagService
    {
        BTreeDictionary<string, List<string>> TagsetIndex { get; set; }
        Dictionary<List<string>, Tuple<string, Guid>> SituationIndex { get; set; }

        void AddSituation(List<string> messages, string situation);
        void UpdateTagsetIndex(string name, List<string> tags);

        void FlushTagsetToDisk();

    }
    public class TagService : ITagService
    {
        public Dictionary<List<string>, Tuple<string, Guid>> SituationIndex { get; set; } = new Dictionary<List<string>, Tuple<string, Guid>>();
        public BTreeDictionary<string, List<string>> TagsetIndex { get; set; } = new BTreeDictionary<string, List<string>>();

        public void AddSituation(List<string> messages, string situation)
        {
            SituationIndex.Add(messages, new Tuple<string, Guid>(situation, Guid.NewGuid()));
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
        public void FlushTagsetToDisk()
        {

        }
    }
}
