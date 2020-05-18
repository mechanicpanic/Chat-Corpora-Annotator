using System;
using System.Collections.Generic;


namespace Viewer.Framework.Views
{
    public interface ITagsetView : IView
    {
        List<string> CurrentTags { get; set; }
        void DisplayTagset();
        event EventHandler AddNewTagset;
        event EventHandler DeleteTagset;
        event EventHandler SaveTagset;


    }

}
