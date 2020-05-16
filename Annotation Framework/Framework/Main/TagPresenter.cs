using IndexingServices;
using System;
using Tagger.Framework.Tagset;

namespace Tagger.Framework.Main
{
    public class TagPresenter
    {
        private readonly ITagView _tagger;
        private readonly ITagService _service;
        private readonly ITagsetView _tagset;

        public TagPresenter(ITagView tagger, ITagService service, ITagsetView tagset)
        {
            this._tagger = tagger;
            this._service = service;
            this._tagset = tagset;

            _tagger.TagsetClick += _tagger_TagsetClick;
            _tagger.LoadMore += _tagger_LoadMore;
            _tagset.SaveTagset += _tagset_SaveTagset;
        }

        private void _tagger_LoadMore(object sender, EventArgs e)
        {
            AddDocumentsToDisplay(50);
        }

        private void AddDocumentsToDisplay(int count)
        {
            var list = IndexService.LoadSomeDocuments(count);
            _tagger.Messages.AddRange(list);
            _tagger.DisplayDocuments();
        }
        private void _tagset_SaveTagset(object sender, EventArgs e)
        {
            _service.UpdateTagset(_tagset.CurrentTags);
            _tagger.UpdateTagset(_service.Tagset);
            _tagset.CloseView();
        }

        private void _tagger_TagsetClick(object sender, EventArgs e)
        {
            _tagset.ShowView();
        }

    }
}
