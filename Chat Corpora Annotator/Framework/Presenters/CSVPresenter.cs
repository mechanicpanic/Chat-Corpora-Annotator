
using System;
using System.Linq;

using IndexingServices;
using Viewer.CSV_Wizard;
using Viewer.Framework.Services;
using Viewer.Framework.Views;

namespace Viewer.Framework.Presenters
{
    public class CSVPresenter
    {
        private readonly IMainView _main;
        private readonly ICSVView _csv;
        private readonly ICSVReadService _reader;
        private readonly IIndexService _indexer;

        public CSVPresenter(IMainView main, ICSVView csv, ICSVReadService reader, IIndexService indexer)
        {
            _main = main;
            _csv = csv;
            _reader = reader;
            _indexer = indexer;

            _csv.HeaderSelected += _csv_HeaderSelected;
            _csv.MetadataAdded += _csv_MetadataAdded;
            _csv.ReadyToShow += _csv_ReadyToShow;

            
            _main.FileAndIndexSelected += _view_FileAndIndexSelected;
            
            //_indexer.FileIndexed += _indexer_FileIndexed;
            
            
        }

        private void _csv_ReadyToShow(object sender, EventArgs e)
        {
            
            _main.Usernames = _indexer.UserKeys.ToList();
            _main.MessagesPerDay = _indexer.MessagesPerDay;
            int temp = (LuceneService.Writer.MaxDoc) / 5;
            var list = _indexer.LoadSomeDocuments(_main.CurrentIndexPath, _csv.DateFieldKey, _csv.SelectedFields, temp);
            _main.Messages = list;
            _main.DateFieldKey = _csv.DateFieldKey;
            _main.TextFieldKey = _csv.TextFieldKey;
            _main.SenderFieldKey = _csv.SenderFieldKey;
            _main.DisplayDocuments();
            _main.FileLoadState = true;
        }


        

        private void _csv_HeaderSelected(object sender, EventArgs e)
        {
            
            _csv.Steps.OfType<MetadataStep>().First().PopulateComboBoxes(_csv.SelectedFields);

        }

        private void _view_FileAndIndexSelected(object sender, EventArgs e)
        {

            string path = _main.CurrentPath;
            string[] allFields = _reader.GetFields(path);
            int count = _reader.GetLineCount(path);
            _main.SetLineCount(count);

            _csv.AllFields = allFields;
            _csv.AddStep(new HeaderStep(_csv.AllFields));
            _csv.AddStep(new MetadataStep());
            _csv.AddStep(new LoadingStep());
            _csv.AddStep(new DataLoadedStep());
            _csv.ShowView();
            
        }


        private void _csv_MetadataAdded(object sender, EventArgs e)
        {
            _indexer.OpenDirectory(_main.CurrentIndexPath);
            _indexer.OpenWriter(_csv.TextFieldKey);
            _indexer.InitLookup(_csv.TextFieldKey, _csv.DateFieldKey, _csv.SenderFieldKey, _csv.SelectedFields, _csv.AllFields);
            var result =  _indexer.PopulateIndex(_main.CurrentIndexPath,_main.CurrentPath,_csv.AllFields, _csv.SelectedFields);
           if (result == 1)
            {
                _csv.CorpusIndexed();
            }
        }

    }
}
