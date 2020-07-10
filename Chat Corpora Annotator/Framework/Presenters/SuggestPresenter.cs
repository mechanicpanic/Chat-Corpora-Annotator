using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Framework.Services;
using Viewer.Framework.Views;
using ExtractingServices;
using Viewer.Framework.Presenters.Parser;

namespace Viewer.Framework.Presenters
{
    public class SuggestPresenter
    {
        private readonly ISuggesterView _sugg;
        private readonly ISuggestService _service;
        private readonly ITagView _tagger;
        private readonly IMainView _main;
        public SuggestPresenter(ISuggesterView sugg,
                               ISuggestService service, ITagView tagger, IMainView main)
        {
            this._sugg = sugg;
            this._service = service;
            this._tagger = tagger;
            this._main = main;

            _tagger.ShowSuggester += _tagger_ShowSuggester;
            _sugg.RunQuery += _sugg_RunQuery;
            _sugg.DeleteUserDict += _sugg_DeleteUserDict;
            _sugg.AddUserDict += _sugg_AddUserDict;

        }

        private void _sugg_AddUserDict(object sender, UserDictsEventArgs args)
        {
            UserDictsContainer.UserDicts.Add(args.Name, args.Words);
            var a = "a";
        }

        private void _sugg_DeleteUserDict(object sender, UserDictsEventArgs args)
        {
            UserDictsContainer.UserDicts.Remove(args.Name);
        }

        private void _sugg_RunQuery(object sender, EventArgs e)
        {
            //_service.Parse(_sugg.QueryString);
            //Run Parser from here
            foreach(var id in Parser.Parser.parse(_sugg.QueryString, _sugg.UserDicts))
            {
                _sugg.CurrentSituation.Add(IndexEngine.IndexService.RetrieveMessageById(id));
            }
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
