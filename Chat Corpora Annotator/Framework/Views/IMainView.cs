using IndexingServices;
using System;
using System.Collections.Generic;

namespace Viewer.Framework.Views
{
    public interface IMainView : IView
    {
        //TODO: R e t h i n c c
        bool FileLoadState { get; set; }

        List<DynamicMessage> SearchResults { get; set; }
        string CurrentPath { get; set; }
        string CurrentIndexPath { get; set; }

        void SetLineCount(int count);
        void DisplayDocuments();
        void DisplaySearchResults();


        IConcordanceView CreateConcordancer();

        INGramView CreateNgramView();
        void ShowNgrams(INGramView nGram);
        void ShowConcordance(IConcordanceView con);
        event EventHandler FileAndIndexSelected;
        event EventHandler OpenIndexedCorpus;

        event EventHandler ChartClick;
        event EventHandler HeatmapClick;
        event LuceneQueryEventHandler FindClick;

        event EventHandler LoadMoreClick;

        event EventHandler ConcordanceClick;
        event EventHandler NGramClick;

        event EventHandler TagClick;
        //event PropertyChangedEventHandler PropertyChanged;
        //bool FileLoadState { get; set; }
    }
}
