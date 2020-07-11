using edu.stanford.nlp.util.logging;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Viewer.Framework.Views
{
    public interface ITagView : IView
    {
        event EventHandler WriteToDisk;
        event EventHandler TagsetClick;

        event EventHandler AddTag;
        event EventHandler RemoveTag;

        event EventHandler EditSituation;
        event EventHandler LoadMore;

        event EventHandler ShowSuggester;

        Dictionary<string, System.Drawing.Color> TagsetColors { get; set; }
     
        void UpdateTagset(List<string> tags);
        void DisplayDocuments();

        void DisplayTagsetColors(Dictionary<string, System.Drawing.Color> dict);
        event EventHandler DisplayColors;

        void UpdateTagIndex(List<string> tags);
        void DisplayTagset(List<string> tags);
    }



}
