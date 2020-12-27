using IndexEngine;
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
            //_tagger.EditSituation += _tagger_EditSituation;

            _tagger.LoadTagset += _tagger_LoadTagset;
            _main.TagClick += _main_TagClick;
            
        }

        private void _tagger_LoadTagset(object sender, TaggerEventArgs e)
        {
            _tagger.DisplayTagset(TagsetIndex.Index[e.Tagset]);
            _tagger.TagsetColors = TagsetIndex.ColorIndex[e.Tagset];
            
        }

        private void _tagger_EditSituation(object sender, EventArgs e)
        {

        }

        private void _tagger_AddTag(object sender, TaggerEventArgs e)
        {
            //SituationIndex.AddSituationToIndex(e.messages,e.Tag);
            bool flag = false;
            foreach(var id in e.messages)
            {
                try { 
                    MessageContainer.Messages[id].Situations.Add(e.Tag, e.Id);
                    
                }
                catch (ArgumentException ex) 
                {
                    //MessageContainer.Messages[id].Situations[e.Tag]
                    _tagger.DisplayTagErrorMessage();
                    flag = true;
                }             
            }
        }

        private void _tagger_WriteToDisk(object sender, EventArgs e)
        {
            _writer.OpenWriter();

            foreach (var kvp in SituationIndex.container)
            {
                List<DynamicMessage> list = new List<DynamicMessage>();
                foreach (var s in kvp.Value)
                {
                    foreach (var id in s.Value)
                        list.Add(IndexService.RetrieveMessageById(id));
                    _writer.WriteSituation(list, kvp.Key, s.Key);
                }

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
