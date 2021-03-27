using CSharpTest.Net.Collections;
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
        bool InfoExtracted { get; set; }

        void EnsureMessageIsVisible(int id);

        void SetLineCount(int count);
        void DisplayDocuments();
        void DisplaySearchResults();

        void SetTagsetLabel(string tagset);
        void DisplayStatistics(int type, Dictionary<string,double> args);

        IKeywordView CreateKeywordView();
        void ShowKeywordView(IKeywordView key);



        void ShowDates(List<DateTime> dates);

        void ShowSorryMessage();
        void ShowExtractedMessage();

        void DisplayConcordance(string[] con);
        void DisplayNGrams(List<BTreeDictionary<string, int>> grams);
        event EventHandler CheckNgramState;
        void UpdateNgramState(bool state, bool readstate);
        event EventHandler FileAndIndexSelected;
        event EventHandler OpenIndexedCorpus;

        event EventHandler ChartClick;
        event EventHandler HeatmapClick;
        event LuceneQueryEventHandler FindClick;

        event EventHandler LoadMore;

        event ConcordanceEventHandler ConcordanceClick;
        event NgramEventHandler NGramClick;
        event EventHandler BuildIndexClick;
        event EventHandler KeywordClick;
        event EventHandler LoadStatistics;

        event EventHandler ExtractInfoClick;
        //void VisualizeHist(PointPairList list, string name);

    }
}
