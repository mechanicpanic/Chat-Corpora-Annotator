using System;
using Viewer.Framework.Services;
using Viewer.Framework.Views;


namespace Viewer.Framework.Presenters
{
    public class TagsetPresenter
    {
        private readonly ITagsetView _tagset;
        private readonly ITagService _service;
        private readonly ITagView _main;

        public TagsetPresenter(ITagsetView tagset, ITagService service, ITagView main)
        {
            this._tagset = tagset;
            this._service = service;
            this._main = main;

            _main.TagsetClick += _main_TagsetClick;

        }

        private void _main_TagsetClick(object sender, EventArgs e)
        {

        }
    }
}
