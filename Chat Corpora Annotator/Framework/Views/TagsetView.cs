using System.Collections.Generic;
using Viewer.Framework.MyEventArgs;

namespace Viewer.Framework.Views
{
    public interface ITagsetView : IView
    {
        event TagsetUpdateEventHandler AddNewTagset;
        event TagsetUpdateEventHandler DeleteTagset;
        event TagsetUpdateEventHandler UpdateTagset;
        event TagsetUpdateEventHandler LoadExistingTagset;

        event TagsetUpdateEventHandler SetProjectTagset;
        void DisplayTagsetNames(List<string> names);
        void DisplayTagset(List<string> tags);
        void DisplayProjectTagsetName(string name);
    }

}
