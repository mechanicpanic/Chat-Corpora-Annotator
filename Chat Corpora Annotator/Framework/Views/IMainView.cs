using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Corpora_Annotator.Framework
{
    public interface IMainView
    {
        bool FileLoadState { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
        string CsvPath { get; set; }
        string IndexPath { get; set; }

        void SetLineCount(int count);
        void DisplayDocuments();
        event EventHandler NewFileClick;
        event EventHandler CSVLoad;
        event EventHandler OpenIndex;
        event EventHandler ChartClick;
        event EventHandler HeatmapClick;

    }
}
