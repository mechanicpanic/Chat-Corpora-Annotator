using System;
using System.Collections.Generic;

namespace Tagger.Framework.Tagset
{
    public interface ITagsetView : IView
    {
        List<string> CurrentTags { get; set; }
        event EventHandler SaveTagset;
    }

}
