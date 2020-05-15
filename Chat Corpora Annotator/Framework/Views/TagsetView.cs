using System;
using System.Collections.Generic;


namespace Viewer.Framework.Views
{
    public interface ITagsetView : IView
    {
        List<string> CurrentTags { get; set; }
        event EventHandler SaveTagset;
    }

}
