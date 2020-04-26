﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

using Viewer.Framework.Views;
using Viewer.Framework.Services;

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



        public MainPresenter(IMainView view,ICSVView csv,IIndexService reader,ISearchService searcher)
        {
            this._view = view;
            this._csv = csv;
            //this._chart = chart;
            //this._heatmap = heatmap;
            this._reader = reader;
            this._searcher = searcher;


            _view.HeatmapClick += _view_HeatmapClick;
            _view.ChartClick += _view_ChartClick;
            _view.OpenIndexedCorpus += _view_OpenIndexedCorpus;
            _view.FindClick += _view_FindClick;
            _view.LoadMoreClick += _view_LoadMoreClick;
           

        }




        private void _view_LoadMoreClick(object sender, EventArgs e)
        {
            AddDocumentsToDisplay(200);
        }




        private void _view_ChartClick(object sender, EventArgs e)
        {
            
        }

        private void _view_OpenIndexedCorpus(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _view_HeatmapClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void AddDocumentsToDisplay(int count)
        {
            var list = _reader.LoadSomeDocuments(_view.CurrentIndexPath,_csv.DateFieldKey, _csv.SelectedFields, count);
            _view.Messages.AddRange(list);
        }


        private void _view_FindClick(object sender, LuceneQueryEventArgs e)
        {
            _searcher.UserQuery = LuceneService.Parser.Parse(e.Query + "*");
            _searcher.SearchText();
        }

       
        
    }


}
