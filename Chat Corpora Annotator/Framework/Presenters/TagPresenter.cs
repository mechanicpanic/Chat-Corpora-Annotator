using IndexingServices;
using System;
using System.Collections.Generic;
using Viewer.Framework.Services;
using Viewer.Framework.Views;
using ExtractingServices;

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
            _tagger.EditSituation += _tagger_EditSituation;

            _tagger.ShowSuggester += _tagger_ShowSuggester;
            _main.TagClick += _main_TagClick;
            
        }

        private void _tagger_ShowSuggester(object sender, EventArgs e)
        {
            Extractor.CreatePipeline();
            Extractor.Extract();

        }

        private void _tagger_EditSituation(object sender, EventArgs e)
        {
            _tagger.CurrentSituation = null;
            
        }

        private void _tagger_AddTag(object sender, EventArgs e)
        {
            _service.AddSituation(_tagger.CurrentSituation.Item1, _tagger.CurrentSituation.Item2);
        }

        private void _tagger_WriteToDisk(object sender, EventArgs e)
        {
            _writer.OpenWriter();
            foreach (var list in _service.SituationIndex.Keys)
            {
                List<DynamicMessage> messages = new List<DynamicMessage>();
                foreach (var id in list)
                {
                    var message = IndexService.RetrieveMessageById(id);
                    messages.Add(message);
                }
                _writer.WriteSituation(messages, _service.SituationIndex[list].Item1);
            }
            _writer.CloseWriter();
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


        private void _tagger_TagsetClick(object sender, EventArgs e)
        {
            _tagset.ShowView();
        }

    }
}
