using IndexEngine;
using Lucene.Net.Index;
using System;
using System.Collections.Generic;
using System.Linq;
using Viewer.Framework.Services;
using Viewer.Framework.Views;
using ExtractingServices;
using ZedGraph;
using System.Threading;

namespace Viewer.Framework.Presenters
{

    public class MainPresenter
    {
        private readonly IMainView _main;
        private readonly ICSVView _csv;
        private readonly ISearchService _searcher;
        private readonly ITagView _tagger;
        private readonly ITagService _service;
        private readonly FolderService _folder;
        private readonly IStatisticsService _dataset;
        private readonly ITaggedStatisticsService _corpus;
        public MainPresenter(IMainView view, ITagView tagger, ITagService service, ICSVView csv, ISearchService searcher, FolderService folder, IStatisticsService dataset, ITaggedStatisticsService corpus)
        {                                                                                                                                       
            this._tagger = tagger;
            this._service = service;
            this._main = view;
            this._csv = csv;
            this._searcher = searcher;
            this._folder = folder;
            this._dataset = dataset;
            this._corpus = corpus;

            _main.FindClick += _view_FindClick;
            _main.LoadMore += _view_LoadMoreClick;
            _main.OpenIndexedCorpus += _view_OpenIndexedCorpus;
            _main.ConcordanceClick += _main_ConcordanceClick;
            _main.NGramClick += _main_NGramClick;
            _main.KeywordClick += _main_KeywordClick;
            _main.LoadStatistics += _main_LoadStatistics;
            _main.ExtractInfoClick += _main_ExtractInfoClick;
            
            _main.VisualizeLengths += _main_VisualizeLengths;
            _main.VisualizeTokens += _main_VisualizeTokens;
            _main.VisualizeTokenLengths += _main_VisualizeTokenLengths;

            
            _folder.CheckFolder();


        }

       

        private void _main_VisualizeTokenLengths(object sender, EventArgs e)
        {
            //var numberOfBuckets = 3;
            //PointPairList list = new PointPairList();
            //if (stats != null)
            //{
            //    var cleandata = HistogramHelper.RemoveOutliers(stats.AllTokenLengths, 20);
            //    var hist = HistogramHelper.Bucketize(cleandata, numberOfBuckets);

            //    for (int i = 0; i < numberOfBuckets; i++)
            //    {
            //        list.Add(i, hist[i]);
            //    }
            //    _main.VisualizeHist(list, "Token lengths in symbols");
            //}
        }

        // Yeah this is 1000000000000% duplicate code. Sorry its 24hrs to the deadline
        private void _main_VisualizeTokens(object sender, EventArgs e)
        {
            //var numberOfBuckets = 3;
            //PointPairList list = new PointPairList();
            //if (stats != null)
            //{
            //    var cleandata = HistogramHelper.RemoveOutliers(stats.AllTokenNumbers, 20);
            //    var hist = HistogramHelper.Bucketize(cleandata, numberOfBuckets);
                

            //    for (int i = 0; i < numberOfBuckets; i++)
            //    {
            //        list.Add(i, hist[i]);
            //    }
            //    _main.VisualizeHist(list, "Token number");
            //}
        }

        private void _main_VisualizeLengths(object sender, EventArgs e)
        {
            //var numberOfBuckets = 3;
            //PointPairList list = new PointPairList();
            //if (stats != null)
            //{
            //    var cleandata = HistogramHelper.RemoveOutliers(stats.AllLengths, 100);
            //    var hist = HistogramHelper.Bucketize(cleandata, numberOfBuckets);

            //    for (int i = 0; i < numberOfBuckets; i++)
            //    {
            //        list.Add(i, hist[i]);
            //    }
            //    _main.VisualizeHist(list, "Message lengths in symbols");
            //}
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
            _corpus.CalculateAll();
            _dataset.CalculateAll();

            _main.DisplayStatistics(0, _dataset.AllFields);
            _main.DisplayStatistics(1, _corpus.AllFields);
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
                
                
                Thread t = new Thread(_ngrammer.BuildFullIndex);
                t.Start();
                
                

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

                _view_LoadMoreClick(null, null);

            }
        }

        private void _view_LoadMoreClick(object sender, EventArgs e)
        {
            AddDocumentsToDisplay(2000);
            _main.ShowDates(IndexService.MessagesPerDay.Keys.ToList());
        }



        public void AddDocumentsToDisplay(int count)
        {
            var list = IndexService.LoadSomeDocuments(count);
            MessageContainer.Messages.AddRange(list);
            _main.DisplayDocuments();
            ShowTags(count);
            
        }

        private void ShowTags(int count)
        {
            for (int i = _tagger.CurIndex; i < _tagger.CurIndex + count; i++)
            {
                if (_service.TaggedIds.Contains(i))
                {
                    InsertTagsInDynamicMessage(i,count);
                }
            }
            _tagger.CurIndex += count;
        }

        private void InsertTagsInDynamicMessage(int id, int offset)
        {
            var arr = _service.SituationContainer[id].Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in arr)
            {
                var s = item.Split('-');
                if (id <= MessageContainer.Messages.Count+offset)
                {
                    if (!MessageContainer.Messages[id].Situations.ContainsKey(s[0]))
                    {
                        MessageContainer.Messages[id].Situations.Add(s[0], Int32.Parse(s[1]));
                        SituationIndex.RetrieveDictFromMessageContainer(MessageContainer.Messages[id]);

                    }
                }

            }
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
