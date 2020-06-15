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

            _tagset.SaveTagset += _tagset_SaveTagset;
            _tagset.AddNewTagset += _tagset_AddNewTagset;

        }

        private void _tagset_AddNewTagset(object sender, EventArgs e)
        {
            _service.UpdateTagset
        }

        private void _tagset_SaveTagset(object sender, EventArgs e)
        {
           
        }
    }
}
