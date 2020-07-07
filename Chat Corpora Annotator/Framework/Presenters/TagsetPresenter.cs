using com.fasterxml.jackson.core.sym;
using IndexEngine;
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

            _tagset.UpdateTagset += _tagset_UpdateTagset;
            _tagset.AddNewTagset += _tagset_AddNewTagset;
            _tagset.LoadExistingTagset += _tagset_LoadExistingTagset;
            _tagset.DeleteTagset += _tagset_DeleteTagset;

            _tagset.DisplayTagsetNames(TagsetIndex.Index.Keys.ToList());
        }

        private void _tagset_DeleteTagset(object sender, TagsetUpdateEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void _tagset_UpdateTagset(object sender, TagsetUpdateEventArgs args)
        {
            _service.UpdateTagsetIndex(args.Name, args.Tags);
        }

        private void _tagset_LoadExistingTagset(object sender, TagsetUpdateEventArgs args)
        {
            _tagset.DisplayTagset(TagsetIndex.Index[args.Name]);
        }

        private void _tagset_AddNewTagset(object sender, TagsetUpdateEventArgs e)
        {
            _service.UpdateTagsetIndex(e.Name, null);
        }

    }
}
