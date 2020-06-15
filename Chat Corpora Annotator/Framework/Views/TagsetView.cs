using System;
using System.Collections.Generic;


namespace Viewer.Framework.Views
{
    public interface ITagsetView : IView
    {
        List<string> CurrentTags { get; set; }

        List<string> SelectedTagset { get; set; }

        event TagsetUpdateEventHandler AddNewTagset;
        event TagsetUpdateEventHandler DeleteTagset;
        event TagsetUpdateEventHandler SaveTagset;

        event TagsetUpdateEventHandler SaveEditedTagset;
        event TagsetUpdateEventHandler LoadExistingTagset;
        void DisplayTagsetNames(List<string> names);
        void DisplayTagset(List<string> tags);
    }

}
