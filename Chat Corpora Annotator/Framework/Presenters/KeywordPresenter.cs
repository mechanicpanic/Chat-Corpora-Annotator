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
    public class KeywordPresenter
    {
        private readonly IMainView _main;
        private readonly IKeywordService _service;
        private readonly IKeywordView _view;

        public KeywordPresenter(IMainView main, IKeywordService service, IKeywordView view)
        {
            this._main = main;
            this._service = service;
            this._view = view;

            _view.RakeClick += _view_RakeClick;
            _view.StanfordClick += _view_StanfordClick;
        }

        private void _view_StanfordClick(object sender, EventArgs e)
        {
            if (_main.InfoExtracted)
            {
                _view.NounPhrases = new List<string>();
                foreach (var np in Extractor.NounPhrases)
                {
                    _view.NounPhrases.AddRange(np.Value);
                }
                
                _view.DisplayKeyPhrases();
            }
            else
            {
                _main.ShowSorryMessage();
            }
        }

        private void _view_RakeClick(object sender, EventArgs e)
        {
            _view.RakeKeywords.Clear();
            var rawKeywords = _service.GetRakeKeywords(_view.RakeLength);
            var keywords = _service.ProcessKeywordList(rawKeywords.Keys.ToList());
            foreach(var key in keywords)
            {
                if (rawKeywords[key] > 1)
                {
                    _view.RakeKeywords.Add(key, rawKeywords[key]);
                }
            }
            _view.DisplayRakeKeywords();
            
        }
    }
}
