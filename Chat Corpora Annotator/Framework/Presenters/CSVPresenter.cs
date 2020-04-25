using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.CSV_Wizard;
using Viewer.Framework.Services;
using Viewer.Framework.Views;

namespace Viewer.Framework.Presenters
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

            _csv.HeaderSelected += _csv_HeaderSelected;
            _csv.MetadataAdded += _csv_MetadataAdded;
            _csv.DataLoaded += _csv_DataLoaded;

            
            _view.FileAndIndexSelected += _view_FileAndIndexSelected;
            

        }

        private void _csv_HeaderSelected()
        {
            
            _csv.Steps.OfType<MetadataStep>().First().PopulateComboBoxes(_csv.SelectedFields);

        }

        private void _view_FileAndIndexSelected(object sender, EventArgs e)
        {
            string path = _view.CurrentPath;
            string[] allFields = _reader.GetFields(path);
            int count = _reader.GetLineCount(path);
            _view.SetLineCount(count);

            _csv.AllFields = allFields;
            _csv.AddStep(new HeaderStep(_csv.AllFields));
            _csv.AddStep(new MetadataStep());
            _csv.AddStep(new LoadingStep());
            _csv.AddStep(new DataLoadedStep());
            _csv.Show();
            
        }


        private void _csv_MetadataAdded()
        {
            _indexer.SetUpIndex(_view.CurrentIndexPath, _csv.TextFieldKey);
            _indexer.InitLookup(_csv.TextFieldKey, _csv.DateFieldKey, _csv.SenderFieldKey, _csv.SelectedFields, _csv.AllFields);
            _indexer.PopulateIndex(_view.CurrentIndexPath,_view.CurrentPath,_csv.AllFields);
        }

        private void _csv_DataLoaded()
        {
            //_view.FileLoadState = true;
            _view.Users = _indexer.UserKeys.ToList();
            _csv.Close();
        }

        private void SetUsers()
        {
            
        }


    }
}
