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
            _tagset.SetProjectTagset += _tagset_SetProjectTagset;
            //_tagset.DeleteTagset += _tagset_DeleteTagset;

            _tagset.DisplayTagsetNames(TagsetIndex.Index.Keys.ToList());
        }

        private void _tagset_SetProjectTagset(object sender, TagsetUpdateEventArgs args)
        {
            _service.ProjectTagset = args.Name;
            _tagset.DisplayProjectTagsetName(_service.ProjectTagset);
            _main.TagsetColors = TagsetIndex.ColorIndex[args.Name];
            _main.DisplayTagset(TagsetIndex.Index[args.Name]);
            _main.ClearData();
            _main.SetData(TagsetIndex.Index[args.Name]);
        }

        private void _tagset_UpdateTagset(object sender, TagsetUpdateEventArgs args)
        {
            _service.EditTagset(args.Name, args.Tag, args.Type);
        }

        private void _tagset_LoadExistingTagset(object sender, TagsetUpdateEventArgs args)
        {
            _tagset.DisplayTagset(TagsetIndex.Index[args.Name]);
        }

        private void _tagset_AddNewTagset(object sender, TagsetUpdateEventArgs e)
        {
            _service.UpdateTagsetIndex(e.Name);
            _tagset.DisplayTagsetNames(TagsetIndex.Index.Keys.ToList());
        }

    }
}
