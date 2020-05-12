using System;
using System.Collections.Generic;
using IndexingServices;
using Viewer.Framework.Views;
using Viewer.Framework.Services;
using Lucene.Net.Index;

namespace Viewer.Framework.Presenters
{

    public class MainPresenter
    {
        private readonly IMainView _main;
        private readonly ICSVView _csv;
        //private readonly IChartView _chart;
        //private readonly IHeatmapView _heatmap;
        private readonly IIndexService _reader;
        private readonly ISearchService _searcher;
        
        //private readonly INGramView _grams;
       


        public MainPresenter(IMainView view,ICSVView csv, IIndexService reader,ISearchService searcher, IHeatmapView heatmap)
        {
            this._main = view;
            this._csv = csv;
            //this._chart = chart;
            //this._heatmap = heatmap;
            this._reader = reader;
            this._searcher = searcher;
            //this._grams = grams;
            

            //_view.HeatmapClick += _view_HeatmapClick;
            //_view.ChartClick += _view_ChartClick;
            
            _main.FindClick += _view_FindClick;
            _main.LoadMoreClick += _view_LoadMoreClick;
            _main.OpenIndexedCorpus += _view_OpenIndexedCorpus;
            _main.ConcordanceClick += _main_ConcordanceClick;
            _main.NGramClick += _main_NGramClick;


        }
        private void _main_NGramClick(object sender, EventArgs e)
        {
            INGramView _ngram = _main.CreateNgramView();
            INGramService _ngrammer = new NGramService();
            NGramPresenter grampresenter = new NGramPresenter(_main, _reader, _searcher, _ngrammer, _ngram);
            _ngram.ShowView();
            _main.ShowNgrams(_ngram);
        }
        private void _main_ConcordanceClick(object sender, EventArgs e)
        {
            IConcordanceView _concordance = _main.CreateConcordancer();
            IConcordanceService _concordancer = new ConcordanceService();
            ConcordancePresenter presenter = new ConcordancePresenter(_main, _reader, _concordancer, _concordance);
            _concordance.ShowView();
            _main.ShowConcordance(_concordance);

        }

        private void _view_OpenIndexedCorpus(object sender, EventArgs e)
        {
            _reader.OpenDirectory(_main.CurrentIndexPath);
            if(DirectoryReader.IndexExists(LuceneService.Dir))
            {
                var info = _reader.LoadInfoFromDisk(LuceneService.Dir.Directory.FullName);

                _main.TextFieldKey = info["TextFieldKey"];
                _main.SenderFieldKey = info["SenderFieldKey"];
                _main.DateFieldKey = info["DateFieldKey"];
                _csv.SelectedFields = _reader.LoadFieldsFromDisk(LuceneService.Dir.Directory.FullName);
                _main.Usernames = _reader.LoadUsersFromDisk(LuceneService.Dir.Directory.FullName);
                _main.MessagesPerDay = _reader.LoadStatsFromDisk(LuceneService.Dir.Directory.FullName);
                _main.Messages = new List<DynamicMessage>();
                _main.SetLineCount(Int32.Parse(info["LineCount"]));
                _main.FileLoadState = true;
                _reader.OpenIndex(_main.TextFieldKey);
               
                AddDocumentsToDisplay(200);
            }
        }

        private void _view_LoadMoreClick(object sender, EventArgs e)
        {
            AddDocumentsToDisplay(200);
        }



        public void AddDocumentsToDisplay(int count)
        {
            var list = _reader.LoadSomeDocuments(_main.CurrentIndexPath,_main.DateFieldKey, _csv.SelectedFields, count);
            _main.Messages.AddRange(list);
            _main.DisplayDocuments();
        }


        private void _view_FindClick(object sender, LuceneQueryEventArgs e)

        {

            _searcher.UserQuery = LuceneService.Parser.Parse(e.Query);
            if (!e.FilteredByDate && !e.FilteredByUser) {
               _searcher.SearchText(e.Count);
                
                
            }
            else if (e.FilteredByDate && !e.FilteredByUser)
            {
                _searcher.ConstructDateFilter(_csv.DateFieldKey, e.Start,e.Finish);
                _searcher.SearchText_DateFilter(e.Count);

            }
            else if (!e.FilteredByDate && e.FilteredByUser)
            {
                _searcher.ConstructUserFilter(_csv.SenderFieldKey, e.Users);
               _searcher.SearchText_UserFilter(e.Count);
            }
            else if (e.FilteredByDate && e.FilteredByUser)
            {
                _searcher.ConstructDateFilter(_csv.DateFieldKey, e.Start, e.Finish);
                _searcher.ConstructUserFilter(_csv.SenderFieldKey, e.Users);
                _searcher.SearchText_UserDateFilter(e.Count);
            }
            var result = _searcher.MakeSearchResultsReadable(_csv.SelectedFields, _csv.DateFieldKey);
            
            _main.SearchResults = result;
            _main.DisplaySearchResults();
        }

       
        
    }


}
