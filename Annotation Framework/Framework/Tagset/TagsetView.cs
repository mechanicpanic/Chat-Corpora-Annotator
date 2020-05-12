using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Framework.Tagset
{
    public interface ITagsetView
    {
        List<string> CurrentTags { get; set; }
    }
    public class TagsetView : ITagsetView
    {
        public List<string> CurrentTags { get; set; }
    }
}
