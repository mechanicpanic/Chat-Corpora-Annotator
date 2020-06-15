using System;
using System.Collections.Generic;


namespace Viewer.Framework.Views
{
    public interface ITagsetView : IView
    {
        List<string> CurrentTags { get; set; }

        List<string> SelectedTagset { get; set; }
        void DisplayTagset(List<string> tags);
        event EventHandler AddNewTagset;
        event EventHandler DeleteTagset;
        event EventHandler SaveTagset;

        event EventHandler SaveEditedTagset;


    }

}
