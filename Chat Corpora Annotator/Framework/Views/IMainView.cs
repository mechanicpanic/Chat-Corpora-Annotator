using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Chat_Corpora_Annotator.Framework
{
    public interface IMainView : IView
    {
        //bool FileLoadState { get; set; }

        List<DynamicMessage> messages { get; set; }
        string CurrentPath { get; set; }
        string CurrentIndexPath { get; set; }

        void SetLineCount(int count);
        void DisplayDocuments();

        event EventHandler FileAndIndexSelected;
        event EventHandler OpenIndexedCorpus;

        event EventHandler ChartClick;
        event EventHandler HeatmapClick;

        //event PropertyChangedEventHandler OnPropertyChanged;
    }
}
