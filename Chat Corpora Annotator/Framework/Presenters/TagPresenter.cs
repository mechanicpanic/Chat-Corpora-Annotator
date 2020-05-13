using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndexingServices;
using Viewer.Framework.Services;
using Viewer.Framework.Views;


namespace Viewer.Framework.Presenters
{
    public class TagPresenter
    {
        private readonly ITagView _tagger;
        private readonly ITagService _service;
        private readonly ITagsetView _tagset;
        private readonly IMainView _main;
        private readonly ITagFileWriter _writer;
        public TagPresenter(IMainView main, ITagView tagger, ITagService service, ITagsetView tagset, ITagFileWriter writer)
        {
            this._main = main;
            this._tagger = tagger;
            this._service = service;
            this._tagset = tagset;
            this._writer = writer;

            _tagger.TagsetClick += _tagger_TagsetClick;
            _tagger.LoadMore += _tagger_LoadMore;
            _tagger.WriteToDisk += _tagger_WriteToDisk;
            _tagger.AddTag += _tagger_AddTag;
            _tagset.SaveTagset += _tagset_SaveTagset;
            _main.TagClick += _main_TagClick;
        }

        private void _tagger_AddTag(object sender, EventArgs e)
        {
            _service.AddSituation(_tagger.CurrentSituation);
        }

        private void _tagger_WriteToDisk(object sender, EventArgs e)
        {
            foreach (var VARIABLE in _tagger.SituationIndex)
            {
                
            }
        }

        private void _main_TagClick(object sender, EventArgs e)
        {
            _tagger.ShowView();
        }

        private void _tagger_LoadMore(object sender, EventArgs e)
        {
            AddDocumentsToDisplay(50);
        }

        private void AddDocumentsToDisplay(int count)
        {
            var list = IndexService.LoadSomeDocuments(count);
            MessageContainer.Messages.AddRange(list);
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
