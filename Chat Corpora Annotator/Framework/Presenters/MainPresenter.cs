using System;
using System.Collections.Generic;
using System.Linq;
using IndexingServices;
using Viewer.Framework.Views;
using Viewer.Framework.Services;
using Lucene.Net.Index;
using SD.Tools.BCLExtensions.CollectionsRelated;

namespace Viewer.Framework.Presenters
{

    public class MainPresenter
    {
        private readonly IMainView _main;
        private readonly ICSVView _csv;
        private readonly ISearchService _searcher;
        
       


        public MainPresenter(IMainView view,ICSVView csv, ISearchService searcher, IHeatmapView heatmap)
        {
            this._main = view;
            this._csv = csv;
            //this._chart = chart;
            //this._heatmap = heatmap;
            this._searcher = searcher;
            //this._grams = grams;
            

            //_view.HeatmapClick += _view_HeatmapClick;
            //_view.ChartClick += _view_ChartClick;
            
            _main.FindClick += _view_FindClick;
            _main.LoadMoreClick += _view_LoadMoreClick;
            _main.OpenIndexedCorpus += _view_OpenIndexedCorpus;
            _main.ConcordanceClick += _main_ConcordanceClick;
            _main.NGramClick += _main_NGramClick;


        }
        private void _main_NGramClick(object sender, EventArgs e)
        {
            INGramView _ngram = _main.CreateNgramView();
            INGramService _ngrammer = new NGramService();
            NGramPresenter grampresenter = new NGramPresenter(_main, _searcher, _ngrammer, _ngram);
            _ngram.ShowView();
            _main.ShowNgrams(_ngram);
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
            if(DirectoryReader.IndexExists(LuceneService.Dir))
            {
                var info = IndexService.LoadInfoFromDisk(LuceneService.Dir.Directory.FullName);

                IndexService.TextFieldKey = info["TextFieldKey"];
                IndexService.SenderFieldKey = info["SenderFieldKey"];
                IndexService.DateFieldKey = info["DateFieldKey"];
                IndexService.SelectedFields = IndexService.LoadFieldsFromDisk(LuceneService.Dir.Directory.FullName);
                
                IndexService.MessagesPerDay = IndexService.LoadStatsFromDisk(LuceneService.Dir.Directory.FullName);

                IndexService.UserKeys = IEnumerableExtensionMethods.ToHashSet(IndexService.LoadUsersFromDisk(LuceneService.Dir.Directory.FullName));
                _main.Usernames = Enumerable.ToList(IndexService.UserKeys);

                //_main.Messages = new List<DynamicMessage>();
                MessageContainer.Messages = new List<DynamicMessage>();
                _main.SetLineCount(Int32.Parse(info["LineCount"]));
                _main.FileLoadState = true;
                IndexService.OpenIndex();
               
                AddDocumentsToDisplay(200);
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
            if (!e.FilteredByDate && !e.FilteredByUser) {
               _searcher.SearchText(e.Count);
                
                
            }
            else if (e.FilteredByDate && !e.FilteredByUser)
            {
                _searcher.ConstructDateFilter(_csv.DateFieldKey, e.Start,e.Finish);
                _searcher.SearchText_DateFilter(e.Count);

            }
            else if (!e.FilteredByDate && e.FilteredByUser)
            {
                _searcher.ConstructUserFilter(_csv.SenderFieldKey, e.Users);
               _searcher.SearchText_UserFilter(e.Count);
            }
            else if (e.FilteredByDate && e.FilteredByUser)
            {
                _searcher.ConstructDateFilter(_csv.DateFieldKey, e.Start, e.Finish);
                _searcher.ConstructUserFilter(_csv.SenderFieldKey, e.Users);
                _searcher.SearchText_UserDateFilter(e.Count);
            }
            var result = _searcher.MakeSearchResultsReadable();
            
            _main.SearchResults = result;
            _main.DisplaySearchResults();
        }

       
        
    }


}
