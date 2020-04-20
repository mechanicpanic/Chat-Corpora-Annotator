using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace Chat_Corpora_Annotator.Framework
{

    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly IIndexService _reader;

        

        public MainPresenter(IMainView view,IIndexService reader)
        {
            this._view = view;
            this._reader = reader;

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

    }


}
