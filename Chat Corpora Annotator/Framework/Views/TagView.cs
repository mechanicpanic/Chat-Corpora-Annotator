﻿using edu.stanford.nlp.util.logging;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Viewer.Framework.Views
{
    public interface ITagView : IView
    {
        event WriteEventHandler WriteToDisk;
        event EventHandler SaveTagged;
        event EventHandler LoadTagged;
        event EventHandler TagsetClick;
        event TaggerEventHandler AddTag;
        event TaggerEventHandler RemoveTag;
        void RefreshTagView();
        
        event TaggerEventHandler DeleteSituation;
        
        event EventHandler LoadMore;

        event EventHandler ShowSuggester;


        Dictionary<string, System.Drawing.Color> TagsetColors { get; set; }
     
        bool SituationsLoaded { get; set; }
        int CurIndex { get; set; }
        void DisplayDocuments();

        void DisplayTagsetColors(Dictionary<string, System.Drawing.Color> dict);

        event TaggerEventHandler LoadTagset;

        void ShowDates(List<DateTime> dates);
        void UpdateTagIndex(List<string> tags);
        void DisplayTagset(List<string> tags);
        void DisplayTagErrorMessage();
        void AddSituationIndexItem(string s);
        void UpdateSituationCount(int count);

     
    }



}
