using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Framework.Main
{
    public interface ITagService
    {
        List<string> Tagset { get; set; }
        Dictionary<string, int> SituationIndex { get; set; }

        void UpdateTagset(List<string> tags);

    }
    public class TagService: ITagService
    {
        public List<string> Tagset { get; set; }
        public Dictionary<string, int> SituationIndex { get; set; }
        public void UpdateTagset(List<string> tags)
        {
            Tagset = tags;
        }
        public TagService()
        {

        }
    }
}
