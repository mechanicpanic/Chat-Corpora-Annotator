using System;
using System.Collections.Generic;
using System.ComponentModel;

using Viewer.Framework.Views;
using Viewer.Framework.Services;
using Lucene.Net.Index;

namespace Viewer.Framework.Presenters
{

    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly ICSVView _csv;
        private readonly IChartView _chart;
        private readonly IHeatmapView _heatmap;
        private readonly IIndexService _reader;
        private readonly ISearchService _searcher;
       


        public MainPresenter(IMainView view,ICSVView csv,IIndexService reader,ISearchService searcher, IHeatmapView heatmap)
        {
            this._view = view;
            this._csv = csv;
            //this._chart = chart;
            this._heatmap = heatmap;
            this._reader = reader;
            this._searcher = searcher;


            //_view.HeatmapClick += _view_HeatmapClick;
            //_view.ChartClick += _view_ChartClick;
            
            _view.FindClick += _view_FindClick;
            _view.LoadMoreClick += _view_LoadMoreClick;
            _view.OpenIndexedCorpus += _view_OpenIndexedCorpus;

        }

        private void _view_OpenIndexedCorpus(object sender, EventArgs e)
        {
            _reader.OpenDirectory(_view.CurrentIndexPath);
            if(DirectoryReader.IndexExists(LuceneService.Dir))
            {
                var info = _reader.LoadInfoFromDisk(LuceneService.Dir.Directory.FullName);

                _view.TextFieldKey = info["TextFieldKey"];
                _view.SenderFieldKey = info["SenderFieldKey"];
                _view.DateFieldKey = info["DateFieldKey"];
                _csv.SelectedFields = _reader.LoadFieldsFromDisk(LuceneService.Dir.Directory.FullName);
                _view.Usernames = _reader.LoadUsersFromDisk(LuceneService.Dir.Directory.FullName);
                _view.MessagesPerDay = _reader.LoadStatsFromDisk(LuceneService.Dir.Directory.FullName);
                _view.Messages = new List<DynamicMessage>();
                _reader.OpenIndex();
               
                AddDocumentsToDisplay(200);
            }
        }

        private void _view_LoadMoreClick(object sender, EventArgs e)
        {
            AddDocumentsToDisplay(200);
        }



        public void AddDocumentsToDisplay(int count)
        {
            var list = _reader.LoadSomeDocuments(_view.CurrentIndexPath,_view.DateFieldKey, _csv.SelectedFields, count);
            _view.Messages.AddRange(list);
            _view.DisplayDocuments();
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
            _view.SearchResults = result;
            _view.DisplaySearchResults();
        }

       
        
    }


}
