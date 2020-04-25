using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Viewer.Framework.Views
{
    public interface IMainView : IView
    {
        //bool FileLoadState { get; set; }
        List<string> Users { get; set; }
        List<DynamicMessage> Messages { get; set; }

        //List<DynamicMessage> searchResults { get; set; }
        string CurrentPath { get; set; }
        string CurrentIndexPath { get; set; }

        void SetLineCount(int count);
        void DisplayDocuments();

        event EventHandler FileAndIndexSelected;
        event EventHandler OpenIndexedCorpus;

        event EventHandler ChartClick;
        event EventHandler HeatmapClick;
        event EventHandler FindClick;

        event EventHandler LoadMoreClick;
    }
}
