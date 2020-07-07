
using edu.stanford.nlp.util;
using IndexEngine;
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

        private readonly DelimiterStep _delim;


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

        private void _view_FileAndIndexSelected(object sender, EventArgs e)
        {

            IndexService.CurrentIndexPath = _main.CurrentIndexPath;
            _delim.ShowView();

        }

        private void _delim_DelimiterSelected(object sender, EventArgs e)
        {
            _csv.AllFields = _reader.GetFields(_main.CurrentPath, _delim.ReturnDelimiter());
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


            int temp = (LuceneService.Writer.MaxDoc) / 5;
            var list = IndexService.LoadSomeDocuments(temp);
            //_main.Messages = list;
            MessageContainer.Messages = list;

            IndexService.DateFieldKey = _csv.DateFieldKey;
            IndexService.TextFieldKey = _csv.TextFieldKey;
            IndexService.SenderFieldKey = _csv.SenderFieldKey;



            _main.DisplayDocuments();
            _main.ShowDates(IndexService.MessagesPerDay.Keys.ToList());
            _main.SetLineCount(LuceneService.DirReader.NumDocs);
            _main.FileLoadState = true;
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
            _reader.GetLineCount(_main.CurrentPath, _csv.Header);
            var result = IndexService.PopulateIndex(_main.CurrentPath, _csv.AllFields, _csv.Header);
            if (result == 1)
            {
                _csv.CorpusIndexed();
            }
        }

    }
}
