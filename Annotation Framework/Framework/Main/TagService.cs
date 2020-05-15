using System.Collections.Generic;

namespace Tagger.Framework.Main
{
    public interface ITagService
    {
        List<string> Tagset { get; set; }
        Dictionary<string, int> SituationIndex { get; set; }

        void UpdateTagset(List<string> tags);

    }
    public class TagService : ITagService
    {
        public List<string> Tagset { get; set; }
        public Dictionary<string, int> SituationIndex { get; set; }
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
