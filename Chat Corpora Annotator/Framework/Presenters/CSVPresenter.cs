using IndexEngine;
using IndexEngine.Paths;
using System;
using System.Linq;
using Viewer.CSV_Wizard;
using Viewer.Framework.MyEventArgs;
using Viewer.Framework.Services;
using Viewer.Framework.Views;

namespace Viewer.Framework.Presenters
{
    public class CSVPresenter
    {
        private readonly IMainView _main;
        private readonly ICSVView _csv;
        private readonly ICSVReadService _reader;

        private readonly DelimiterStep _delim;

        private string _path; //big bad
        private string _filepath;
        public CSVPresenter(IMainView main, ICSVView csv, ICSVReadService reader, DelimiterStep delim)
        {
            _main = main;
            _csv = csv;
            _reader = reader;
            _delim = delim;

            _csv.HeaderSelected += _csv_HeaderSelected;
            _csv.MetadataAdded += _csv_MetadataAdded;
            _csv.ReadyToShow += _csv_ReadyToShow;

            _delim.DelimiterSelected += _delim_DelimiterSelected;


            _main.FileAndIndexSelected += _view_FileAndIndexSelected;

            //IndexService.FileIndexed += IndexService_FileIndexed;


        }

        private void _view_FileAndIndexSelected(object sender, OpenEventArgs e)
        {

            this._path = e.Path;
            this._filepath = e.FilePath;
            _delim.ShowView();

        }

        private void _delim_DelimiterSelected(object sender, EventArgs e)
        {
            _csv.AllFields = _reader.GetFields(this._filepath, _delim.ReturnDelimiter());
            ProjectInfo.UnloadData();
            _delim.CloseView();
            LaunchWizard();

        }
        private void LaunchWizard()
        {


            _csv.AddStep(new HeaderStep(_csv.AllFields));
            _csv.AddStep(new MetadataStep());
            _csv.AddStep(new LoadingStep());
            _csv.AddStep(new DataLoadedStep());
            _csv.ShowView();

        }


        private void _csv_ReadyToShow(object sender, EventArgs e)
        {



            var list = IndexHelper.LoadNDocumentsFromIndex(2000);
            //_main.Messages = list;
            MessageContainer.Messages = list;




            _main.DisplayDocuments();
            _main.ShowDates(ProjectInfo.Data.MessagesPerDay.Keys.ToList());
            _main.SetLineCount(ProjectInfo.Data.LineCount);
            _main.FileLoadState = true;

        }


        private void _csv_HeaderSelected(object sender, EventArgs e)
        {
            ProjectInfo.Data.SelectedFields = _csv.SelectedFields;
            _csv.Steps.OfType<MetadataStep>().First().PopulateComboBoxes(ProjectInfo.Data.SelectedFields);

        }

        private void _csv_MetadataAdded(object sender, EventArgs e)
        {
            ProjectInfo.CreateNewProject(this._path, _csv.DateFieldKey, _csv.SenderFieldKey, _csv.TextFieldKey);
            LuceneService.OpenNewIndex();
            _reader.GetLineCount(this._filepath, _csv.Header); //i have no fucking clue what this does
            var result = IndexHelper.PopulateIndex(this._filepath, _csv.AllFields, _csv.Header);
            LuceneService.OpenReader();
            if (result == 1)
            {
                _csv.CorpusIndexed();
            }
        }

    }
}
