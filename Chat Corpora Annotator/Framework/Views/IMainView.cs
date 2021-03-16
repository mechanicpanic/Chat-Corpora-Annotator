using IndexEngine;
using System;
using System.Collections.Generic;
using System.Reflection;
using ZedGraph;

namespace Viewer.Framework.Views
{
    public interface IMainView : IView
    {
        //TODO: R e t h i n c c
        bool FileLoadState { get; set; }
        List<DynamicMessage> SearchResults { get; set; }
        string CurrentPath { get; set; }
        string CurrentIndexPath { get; set; }

        void EnsureMessageIsVisible(int id);
        bool InfoExtracted { get; set; }
        void SetLineCount(int count);
        void DisplayDocuments();
        void DisplaySearchResults();

        void SetTagsetLabel(string tagset);
        void DisplayStatistics(int type, Dictionary<string,double> args);
        IConcordanceView CreateConcordancer();

        INGramView CreateNgramView();

        IKeywordView CreateKeywordView();
        void ShowNgrams(INGramView nGram);
        void ShowConcordance(IConcordanceView con);

        void ShowDates(List<DateTime> dates);
        void ShowKeywordView(IKeywordView key);
        void ShowSorryMessage();
        void ShowExtractedMessage();
        event EventHandler FileAndIndexSelected;
        event EventHandler OpenIndexedCorpus;

        event EventHandler ChartClick;
        event EventHandler HeatmapClick;
        event LuceneQueryEventHandler FindClick;

        event EventHandler LoadMore;

        event EventHandler ConcordanceClick;
        event EventHandler NGramClick;
        event EventHandler KeywordClick;
        event EventHandler LoadStatistics;

        event EventHandler ExtractInfoClick;

        event EventHandler VisualizeLengths;
        event EventHandler VisualizeTokens;
        event EventHandler VisualizeTokenLengths;

        //void VisualizeHist(PointPairList list, string name);

    }
}
