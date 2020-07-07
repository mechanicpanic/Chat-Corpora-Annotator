using IndexEngine;
using Lucene.Net.Index;
using System;
using System.Collections.Generic;
using System.Linq;
using Viewer.Framework.Services;
using Viewer.Framework.Views;
using ExtractingServices;


namespace Viewer.Framework.Presenters
{

    public class MainPresenter
    {
        private readonly IMainView _main;
        private readonly ICSVView _csv;
        private readonly ISearchService _searcher;

        private readonly FolderService _folder;


        public MainPresenter(IMainView view, ICSVView csv, ISearchService searcher, FolderService folder)
        {
            this._main = view;
            this._csv = csv;
            this._searcher = searcher;
            this._folder = folder;

            _main.FindClick += _view_FindClick;
            _main.LoadMoreClick += _view_LoadMoreClick;
            _main.OpenIndexedCorpus += _view_OpenIndexedCorpus;
            _main.ConcordanceClick += _main_ConcordanceClick;
            _main.NGramClick += _main_NGramClick;
            _main.KeywordClick += _main_KeywordClick;
            _main.LoadStatistics += _main_LoadStatistics;
            _main.ExtractInfoClick += _main_ExtractInfoClick;
            _folder.CheckFolder();


        }

        private void _main_ExtractInfoClick(object sender, EventArgs e)
        {
            if (!_main.InfoExtracted)
            {
                Extractor.CreatePipeline();
                Extractor.Extract();
                _main.InfoExtracted = true;
            }
            else
            {
                _main.ShowExtractedMessage();
            }
        }

        private void _main_LoadStatistics(object sender, EventArgs e)
        {
                
        }

        private void _main_KeywordClick(object sender, EventArgs e)
        {
            IKeywordView _keyword = _main.CreateKeywordView();
            IKeywordService keywordService = new KeywordService();
            KeywordPresenter pres = new KeywordPresenter(_main, keywordService, _keyword);
            _keyword.ShowView();
            _main.ShowKeywordView(_keyword);
        }

        private void _main_NGramClick(object sender, EventArgs e)
        {
            INGramView _ngram = _main.CreateNgramView();
            INGramService _ngrammer = new NGramService();
            NGramPresenter grampresenter = new NGramPresenter(_main, _searcher, _ngrammer, _ngram);
            _ngram.ShowView();
            _main.ShowNgrams(_ngram);
            if (_ngrammer.CheckIndex()) {
                _ngrammer.ReadIndexFromDisk();
            }
            else
            {
                _ngrammer.BuildFullIndex();

            }
            
        }
        private void _main_ConcordanceClick(object sender, EventArgs e)
        {
            IConcordanceView _concordance = _main.CreateConcordancer();
            IConcordanceService _concordancer = new ConcordanceService();
            ConcordancePresenter presenter = new ConcordancePresenter(_main, _concordancer, _concordance);
            _concordance.ShowView();
            _main.ShowConcordance(_concordance);

        }

        private void _view_OpenIndexedCorpus(object sender, EventArgs e)
        {
            IndexService.CurrentIndexPath = _main.CurrentIndexPath;
            IndexService.OpenDirectory();
            if (DirectoryReader.IndexExists(LuceneService.Dir))
            {
                var info = IndexService.LoadInfoFromDisk(LuceneService.Dir.Directory.FullName);

                IndexService.TextFieldKey = info["TextFieldKey"];
                IndexService.SenderFieldKey = info["SenderFieldKey"];
                IndexService.DateFieldKey = info["DateFieldKey"];
                IndexService.SelectedFields = IndexService.LoadFieldsFromDisk(LuceneService.Dir.Directory.FullName);

                IndexService.MessagesPerDay = IndexService.LoadStatsFromDisk(LuceneService.Dir.Directory.FullName);

                IndexService.UserKeys = IndexService.LoadUsersFromDisk(LuceneService.Dir.Directory.FullName);



                MessageContainer.Messages = new List<DynamicMessage>();
                _main.SetLineCount(Int32.Parse(info["LineCount"]));
                _main.FileLoadState = true;
                IndexService.OpenIndex();

                AddDocumentsToDisplay(200);
                _main.ShowDates(IndexService.MessagesPerDay.Keys.ToList());
            }
        }

        private void _view_LoadMoreClick(object sender, EventArgs e)
        {
            AddDocumentsToDisplay(200);
        }



        public void AddDocumentsToDisplay(int count)
        {
            var list = IndexService.LoadSomeDocuments(count);
            //_main.Messages.AddRange(list);
            MessageContainer.Messages.AddRange(list);
            _main.DisplayDocuments();
        }


        private void _view_FindClick(object sender, LuceneQueryEventArgs e)

        {

            _searcher.UserQuery = LuceneService.Parser.Parse(e.Query);
            if (!e.FilteredByDate && !e.FilteredByUser)
            {
                _searcher.SearchText(e.Count);


            }
            else if (e.FilteredByDate && !e.FilteredByUser)
            {
                _searcher.ConstructDateFilter(IndexService.DateFieldKey, e.Start, e.Finish);
                _searcher.SearchText_DateFilter(e.Count);

            }
            else if (!e.FilteredByDate && e.FilteredByUser)
            {
                _searcher.ConstructUserFilter(IndexService.SenderFieldKey, e.Users);
                _searcher.SearchText_UserFilter(e.Count);
            }
            else if (e.FilteredByDate && e.FilteredByUser)
            {
                _searcher.ConstructDateFilter(IndexService.DateFieldKey, e.Start, e.Finish);
                _searcher.ConstructUserFilter(IndexService.SenderFieldKey, e.Users);
                _searcher.SearchText_UserDateFilter(e.Count);
            }
            var result = _searcher.MakeSearchResultsReadable();

            _main.SearchResults = result;
            _main.DisplaySearchResults();
        }



    }


}
