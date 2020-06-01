﻿using IndexingServices;
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

        event EventHandler LoadStatistics;
        void DisplayStatistics();
        Dictionary<string,double> Statistics { get; set; }
        IConcordanceView CreateConcordancer();

        INGramView CreateNgramView();

        IKeywordView CreateKeywordView();
        void ShowNgrams(INGramView nGram);
        void ShowConcordance(IConcordanceView con);

        void ShowDates(List<DateTime> dates);
        void ShowKeywordView(IKeywordView key);
        event EventHandler FileAndIndexSelected;
        event EventHandler OpenIndexedCorpus;

        event EventHandler ChartClick;
        event EventHandler HeatmapClick;
        event LuceneQueryEventHandler FindClick;

        event EventHandler LoadMoreClick;

        event EventHandler ConcordanceClick;
        event EventHandler NGramClick;
        event EventHandler KeywordClick;

        event EventHandler TagClick;
        //event PropertyChangedEventHandler PropertyChanged;
        //bool FileLoadState { get; set; }
    }
}
