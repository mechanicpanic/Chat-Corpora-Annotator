using IndexEngine.Indexes;
using IndexEngine.Paths;
using System;
using System.IO;
using Viewer.Framework.MyEventArgs;
using Viewer.Framework.Views;
using System.Collections;
using System.Linq;

namespace Viewer.Framework.Presenters
{
    public class SuggestPresenter
    {
        private readonly ISuggesterView _sugg;
        private readonly ITagView _tagger;
        private readonly IMainView _main;
        public SuggestPresenter(ISuggesterView sugg, ITagView tagger, IMainView main)
        {
            this._sugg = sugg;
            this._tagger = tagger;
            this._main = main;

            _tagger.ShowSuggester += _tagger_ShowSuggester;
            _sugg.RunQuery += _sugg_RunQuery;
            _sugg.ShowMessageInMainWindow += _sugg_ShowMessageInMainWindow;
            _sugg.ImportQueryFile += _sugg_ImportQueryFile;



            

        }

        private void _sugg_ImportQueryFile(object sender, OpenEventArgs args)
        {
            _sugg.ImportedQueries = File.ReadAllLines(args.FilePath).ToList();
            _sugg.SetImportLabel(_sugg.ImportedQueries.Count);
        }

        private void _sugg_ShowMessageInMainWindow(object sender, FindEventArgs args)
        {
            bool flag = false;
            _main.EnsureMessageIsVisible(args.id);

        }



        private void _sugg_RunQuery(object sender, EventArgs e)
        {
            //_service.Parse(_sugg.QueryString);
            //Run Parser from here
            _sugg.DisplayIndex = 0;
            //_sugg.GroupIndex = 0;
            if (_sugg.QueryResult != null)
            {
                _sugg.QueryResult.Clear();
            }
            _sugg.QueryResult = Parser.Parser.parse(_sugg.QueryString);
            _sugg.SetCounts();
            _sugg.DisplaySituation();

        }

        private void _tagger_ShowSuggester(object sender, EventArgs e)
        {
            //if(_main.InfoExtracted)
            //{
            //    _sugg.ShowView();
            //}
            //else
            //{
            //    _main.ShowSorryMessage();
            //}

            //Testing the window!!!
            _sugg.ShowView();
        }
    }
}
