
using IndexingServices;
using System;
using System.Linq;
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


        public CSVPresenter(IMainView main, ICSVView csv, ICSVReadService reader)
        {
            _main = main;
            _csv = csv;
            _reader = reader;


            _csv.HeaderSelected += _csv_HeaderSelected;
            _csv.MetadataAdded += _csv_MetadataAdded;
            _csv.ReadyToShow += _csv_ReadyToShow;


            _main.FileAndIndexSelected += _view_FileAndIndexSelected;

            //IndexService.FileIndexed += IndexService_FileIndexed;


        }

        private void _csv_ReadyToShow(object sender, EventArgs e)
        {


            int temp = (LuceneService.Writer.MaxDoc) / 5;
            var list = IndexService.LoadSomeDocuments(temp);
            //_main.Messages = list;
            MessageContainer.Messages = list;

            IndexService.DateFieldKey = _csv.DateFieldKey;
            IndexService.TextFieldKey = _csv.TextFieldKey;
            IndexService.SenderFieldKey = _csv.SenderFieldKey;



            _main.DisplayDocuments();
            _main.FileLoadState = true;
        }






        private void _view_FileAndIndexSelected(object sender, EventArgs e)
        {

            string path = _main.CurrentPath;
            IndexService.CurrentIndexPath = _main.CurrentIndexPath;

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

        private void _csv_HeaderSelected(object sender, EventArgs e)
        {
            IndexService.SelectedFields = _csv.SelectedFields;
            _csv.Steps.OfType<MetadataStep>().First().PopulateComboBoxes(IndexService.SelectedFields);

        }

        private void _csv_MetadataAdded(object sender, EventArgs e)
        {
            IndexService.OpenDirectory();
            IndexService.TextFieldKey = _csv.TextFieldKey;
            IndexService.SenderFieldKey = _csv.SenderFieldKey;
            IndexService.DateFieldKey = _csv.DateFieldKey;

            IndexService.OpenWriter();
            IndexService.InitLookup(_csv.AllFields);
            var result = IndexService.PopulateIndex(_main.CurrentPath, _csv.AllFields);
            if (result == 1)
            {
                _csv.CorpusIndexed();
            }
        }

    }
}
