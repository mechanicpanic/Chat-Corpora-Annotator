using System;
using System.Collections.Generic;

namespace Viewer.Framework.Services
{
    public interface ITagService
    {
        List<string> Tagset { get; set; }
        Dictionary<List<string>, Tuple<string, Guid>> SituationIndex { get; set; }

        void UpdateTagset(List<string> tags);
        void AddSituation(List<string> messages, string situation);

    }
    public class TagService : ITagService
    {
        public List<string> Tagset { get; set; }
        public Dictionary<List<string>, Tuple<string, Guid>> SituationIndex { get; set; } = new Dictionary<List<string>, Tuple<string, Guid>>();

        public void AddSituation(List<string> messages, string situation)
        {
            SituationIndex.Add(messages, new Tuple<string, Guid>(situation, Guid.NewGuid()));
        }

        public void UpdateTagset(List<string> tags)
        {
            Tagset.Clear();
            foreach (var tag in tags)
            {
                Tagset.Add(tag);
            }
        }

    }
}
