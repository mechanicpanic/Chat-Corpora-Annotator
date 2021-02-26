using IndexEngine;
using System;
using System.Collections.Generic;
using Viewer.Framework.Services;
using Viewer.Framework.Views;
using ExtractingServices;
using System.IO;
using System.Text.Json;
using Wintellect.PowerCollections;
using System.Linq;
using System.Windows;

namespace Viewer.Framework.Presenters
{
    public class TagPresenter
    {
        private readonly ITagView _tagger;
        private readonly ITagService _service;
        private readonly ITagsetView _tagset;
        private readonly IMainView _main;
        private readonly ITagFileWriter _writer;

        private string savedpath;
        private string pathcounts;
        private string tagsetpath;
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
            _tagger.SaveTagged += _tagger_SaveTagged;
            _tagger.LoadTagged += LoadTagged;
            _main.TagClick += _main_TagClick;
            

    }

        private void SetPaths()
        {
            savedpath = IndexService.CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(IndexService.CurrentIndexPath) + @"-savedtags.txt";
            pathcounts = IndexService.CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(IndexService.CurrentIndexPath) + @"-tagcounts.txt";
            tagsetpath = IndexService.CurrentIndexPath + "\\info\\" + Path.GetFileNameWithoutExtension(IndexService.CurrentIndexPath) + @"-tagset.txt";
        }
        
        private void LoadTagged(object sender, EventArgs e)
        {
            SetPaths();
            if (_service.SituationContainer.Count == 0)
            {
                if (File.Exists(savedpath))
                {
                    using (StreamReader reader = new StreamReader(savedpath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            
                            var arr = line.Split(' ');

                            _service.SituationContainer.Add(Int32.Parse(arr[0]), arr[1]);
                            

                        }
                        
                    }
                    AddTags();
                }
            }
            else
            {
                AddTags();
            }
            _tagger.RefreshTagView();
            
        }

        private void AddTags()
        {
            //List<int> mem = new List<int>();
            foreach (var id in _service.SituationContainer.Keys)
            {
                if (id < MessageContainer.Messages.Count)
                {
                    var arr = _service.SituationContainer[id].Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
                    //mem.Add(id);
                    foreach (var item in arr)
                    {
                        var s = item.Split('-');
                        if (!MessageContainer.Messages[id].Situations.ContainsKey(s[0]))
                        {
                            MessageContainer.Messages[id].Situations.Add(s[0], Int32.Parse(s[1]));
                            SituationIndex.RetrieveDictFromMessageContainer(MessageContainer.Messages[id]);
                            _tagger.AddSituationIndexItem(s[0] + " " + s[1]);
                        }
                        

                    }

                }

            }
            //foreach (var id in mem)
            //{
            //    _service.SituationContainer.Remove(id);
            //}
        }

        private void _tagger_SaveTagged(object sender, EventArgs e)

        {

            
            using (StreamWriter counts = new StreamWriter(pathcounts))
            {
                foreach (var kvp in SituationIndex.TagsetCounter)
                {
                    counts.WriteLine(kvp.Key + " " + kvp.Value.ToString());
                }
            }
            using (StreamWriter file =
                File.AppendText(savedpath))
            {
                
                foreach (var msg in MessageContainer.Messages)
                {
                    if (msg.Situations.Count != 0 && !_service.SituationContainer.ContainsKey(msg.Id))
                    {
                        file.Write(msg.Id.ToString());
                        foreach (var kvp in msg.Situations) {
                              file.Write(" " + kvp.Key + "-" + kvp.Value.ToString() + "+");
                            if (!_service.SituationContainer.ContainsKey(msg.Id))
                            {
                                _service.SituationContainer.Add(msg.Id, kvp.Key + "-" + kvp.Value.ToString() + "+");
                            }
                            else
                            {
                                _service.SituationContainer[msg.Id] = _service.SituationContainer[msg.Id] + kvp.Key + "-" + kvp.Value.ToString() + "+"; //very bad but i will change this to stringbuilder asap
                            }
                        }
                        file.WriteLine();
                        

                    } 
                }
                

            }   
            
        }

        private void _tagger_LoadTagset(object sender, TaggerEventArgs e)
        {
           
            _service.CheckTagset();
            if (_service.TagsetSet)
            {
                _service.ProjectTagset = File.ReadAllText(tagsetpath);
                string line = File.ReadAllText(pathcounts);
                string[] lines = line.Split(new char[] { '\n','\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(var item in lines)
                {
                    var temp = item.Split(' ');
                    SituationIndex.TagsetCounter.Add(temp[0], int.Parse(temp[1]));
                }
                
                _tagger.DisplayTagset(TagsetIndex.Index[_service.ProjectTagset]);
                _tagger.DisplayTagsetColors(TagsetIndex.ColorIndex[_service.ProjectTagset]);
            }
            
            
            
        }

        private void _tagger_EditSituation(object sender, EventArgs e)
        {

        }
        
        private void _tagger_AddTag(object sender, TaggerEventArgs e)
        {
            if (SituationIndex.TagsetCounter.Count != 0) {
                SituationIndex.AddSituationToIndex(e.messages,e.Id, e.Tag);
                
                foreach (var id in e.messages)
                {
                    try {
                        MessageContainer.Messages[id].Situations.Add(e.Tag, SituationIndex.TagsetCounter[e.Tag]);
                        

                    }
                    catch (ArgumentException ex)
                    {
                        //MessageContainer.Messages[id].Situations[e.Tag]
                        _tagger.DisplayTagErrorMessage();
                        
                    }

                }
                _tagger.AddSituationIndexItem(e.Tag + " " + SituationIndex.TagsetCounter[e.Tag].ToString());
                
                SituationIndex.TagsetCounter[e.Tag]++;
            }
            else
            {
                foreach(var str in TagsetIndex.Index[_service.ProjectTagset])
                {
                    SituationIndex.TagsetCounter.Add(str,0);
                    _tagger.AddSituationIndexItem(e.Tag + " " + SituationIndex.TagsetCounter[e.Tag].ToString());

                }
            }
           
        }


        private void _tagger_WriteToDisk(object sender, WriteEventArgs e)
        {
            _writer.OpenWriter();

            SituationIndex.RetrieveDictFromMessageContainer(e.ids);
            foreach(var kvp in SituationIndex.Index)
            {
                
                foreach(var pair in kvp.Value.Values)
                {
                    List<DynamicMessage> list = new List<DynamicMessage>();
                    foreach (int id in pair)
                    {
                        list.Add(e.ids.Find(x => x.Id == id)); //currently does not support multiple tags
                    }
                    _writer.WriteSituation(list, kvp.Key, list[0].Situations[kvp.Key]);
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
            
            AddDocumentsToDisplay(2000);


        }

        private void AddDocumentsToDisplay(int count)
        {
            var list = IndexService.LoadSomeDocuments(count);
            MessageContainer.Messages.AddRange(list);
            LoadTagged(null,null);
            _tagger.DisplayDocuments();
        }


        private void _tagger_TagsetClick(object sender, EventArgs e)
        {
            _tagset.ShowView();
        }

    }
}
