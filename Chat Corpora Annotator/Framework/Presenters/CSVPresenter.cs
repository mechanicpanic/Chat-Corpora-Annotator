using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Corpora_Annotator.Framework
{
    public class CSVPresenter
    {
        private readonly IMainView _view;
        private readonly ICSVView _csv;
        private readonly ICSVReadService _reader;
        private readonly IIndexService _indexer;

        public CSVPresenter(IMainView view, ICSVView csv, ICSVReadService reader, IIndexService indexer)
        {
            _view = view;
            _csv = csv;
            _reader = reader;
            _indexer = indexer;

            _csv.HeaderFinished += _csv_HeaderFinished;
            _csv.DataLoaded += _csv_DataLoaded;

            _view.CSVLoad += _view_CSVLoad;
            _view.NewFileClick += _view_NewFileClick;

        }

        private void _view_NewFileClick(object sender, EventArgs e)
        {
            
        }

        private void _view_CSVLoad(object sender, EventArgs e)
        {
            string path = _view.CsvPath;
            string[] allFields = _reader.GetFields(path);
            int count = _reader.GetLineCount(path);
            _csv.AllFields = allFields;
            _view.SetLineCount(count);
        }

        private void _csv_HeaderFinished()
        {
            _indexer.SetUpIndex(_view.IndexPath);
            _indexer.PopulateIndex(_view.IndexPath);
        }

        private void _csv_DataLoaded()
        {
            _view.FileLoadState = true;
            _csv.Close();
        }



    }
}
