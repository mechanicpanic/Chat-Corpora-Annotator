using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Framework.Services;
using Viewer.Framework.Views;
using ExtractingServices;

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

        }

        private void _sugg_RunQuery(object sender, EventArgs e)
        {
            _service.Parse(_sugg.QueryString);
            //Run Parser from here
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
