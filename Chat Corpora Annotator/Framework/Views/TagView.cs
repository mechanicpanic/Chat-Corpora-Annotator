using edu.stanford.nlp.util.logging;
using System;
using System.Collections.Generic;

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

        Dictionary<string, Color> TagsetColors { get; set; }
        void SetTagsetColors(); //Will be automatic for now
        void UpdateTagset(List<string> tags);
        void DisplayDocuments();

        void UpdateTagIndex(List<string> tags);
        void DisplayTagset(List<string> tags);
    }



}
