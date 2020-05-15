using IndexingServices;
using System;
using System.Collections.Generic;

namespace Tagger.Framework.Main
{
    public interface ITagView : IView
    {
        List<DynamicMessage> Messages { get; set; }
        event EventHandler WriteToDisk;
        event EventHandler TagsetClick;
        event EventHandler AddTag;
        event EventHandler RemoveTag;
        event EventHandler EditSituation;
        event EventHandler LoadMore;
        void UpdateTagset(List<string> tags);
        void DisplayDocuments();

    }



}
