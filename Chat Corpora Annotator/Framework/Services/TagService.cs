using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Framework.Services
{
    public interface ITagService
    {
        List<string> Tagset { get; set; }
        Dictionary<List<string>,Guid> SituationIndex { get; set; }

        void UpdateTagset(List<string> tags);
        void AddSituation(List<string> messages);

    }
    public class TagService: ITagService
    {
        public List<string> Tagset { get; set; }
        public Dictionary<List<string>,Guid> SituationIndex { get; set; } = new Dictionary<List<string>, Guid>();

        public void AddSituation(List<string> messages)
        {
            SituationIndex.Add(messages, Guid.NewGuid());
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
