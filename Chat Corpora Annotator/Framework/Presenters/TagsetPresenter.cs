using System;
using System.Linq;
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
            _tagset.LoadExistingTagset += _tagset_LoadExistingTagset;
            _service.LoadTagsetsFromDisk();

            _tagset.DisplayTagsetNames(_service.TagsetIndex.Keys.ToList());
        }

        private void _tagset_LoadExistingTagset(object sender, TagsetUpdateEventArgs args)
        {
            _tagset.DisplayTagset(_service.TagsetIndex[args.Name]);
        }

        private void _tagset_AddNewTagset(object sender, TagsetUpdateEventArgs e)
        {
            _service.UpdateTagsetIndex(e.Name, e.Tags);
        }

        private void _tagset_SaveTagset(object sender, EventArgs e)
        {
           
        }
    }
}
