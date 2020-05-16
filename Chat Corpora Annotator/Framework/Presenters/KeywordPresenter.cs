using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Framework.Services;
using Viewer.Framework.Views;

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
        }

        private void _view_RakeClick(object sender, EventArgs e)
        {
            _view.RakeKeywords = _service.ProcessKeywordList(_service.GetRakeKeywords().Keys.ToList());
            _view.DisplayRakeKeywords();
            
        }
    }
}
