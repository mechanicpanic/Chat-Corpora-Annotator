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

        event TaggerEventHandler AddTag;
        event TaggerEventHandler RemoveTag;

        event EventHandler EditSituation;
        event EventHandler LoadMore;

        event EventHandler ShowSuggester;

        Dictionary<string, System.Drawing.Color> TagsetColors { get; set; }
     
        void UpdateTagset(List<string> tags);
        void DisplayDocuments();

        void DisplayTagsetColors(Dictionary<string, System.Drawing.Color> dict);

        event TaggerEventHandler LoadTagset;

        void UpdateTagIndex(List<string> tags);
        void DisplayTagset(List<string> tags);

        void ClearData();
        void SetData(List<string> tags);
    }



}
