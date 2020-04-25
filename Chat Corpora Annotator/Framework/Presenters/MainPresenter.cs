using System;
using System.Collections.Generic;
using System.ComponentModel;

using Viewer.Framework.Views;
using Viewer.Framework.Services;

namespace Viewer.Framework.Presenters
{

    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly IIndexService _reader;
        private readonly ISearchService _searcher;



        public MainPresenter(IMainView view,IIndexService reader,ISearchService searcher)
        {
            this._view = view;
            this._reader = reader;
            this._searcher = searcher;
            _view.HeatmapClick += _view_HeatmapClick;
            _view.ChartClick += _view_ChartClick;
            _view.OpenIndexedCorpus += _view_OpenIndexedCorpus;
            //_view.OnPropertyChanged += _view_OnPropertyChanged;

        }

       

        private void _view_ChartClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            _reader.LoadSomeDocuments(_view.CurrentIndexPath, count);
            _view.DisplayDocuments();
        }

        public void CreateQuery(string query) {
            

        }
        
    }


}
