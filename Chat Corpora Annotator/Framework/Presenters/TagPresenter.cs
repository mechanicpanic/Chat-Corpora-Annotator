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
using System.Diagnostics;

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
            _tagger.WriteToDisk += _tagger_WriteToDisk;
            _tagger.AddTag += _tagger_AddTag;
            _tagger.DeleteSituation += _tagger_DeleteSituation;
            _tagger.EditSituation += _tagger_EditSituation;
            _tagger.MergeSituations += _tagger_MergeSituations;
            _tagger.LoadTagset += _tagger_LoadTagset;
            _tagger.SaveTagged += _tagger_SaveTagged;
            _tagger.LoadTagged += LoadTagged;
            //_main.TagClick += _main_TagClick;
            

    }

        private void _tagger_MergeSituations(object sender, TaggerEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void _tagger_EditSituation(object sender, TaggerEventArgs e)
        {
            DeleteOrEditTag(e, false);
        }

        private void _tagger_DeleteSituation(object sender, TaggerEventArgs args)
        {
            DeleteOrEditTag(args, true);
                       

        }

        private void DeleteOrEditTag(TaggerEventArgs args, bool type)
        {
            foreach (var id in SituationIndex.Index[args.Tag][args.Id])
            {
                MessageContainer.Messages[id].Situations.Remove(args.Tag);
            }

            if (type)
            {
                _tagger.UpdateSituationCount(SituationIndex.SituationCount());
            }
            else
            {
                var tag = args.AdditionalInfo["Change"].ToString();
                
                var count = SituationIndex.TagsetCounter[tag];
                var list = SituationIndex.Index[args.Tag][args.Id];

                SituationIndex.TagsetCounter[tag]++;
                SituationIndex.AddSituationToIndex(list,count,tag);
                foreach (var id in list)
                {
                    MessageContainer.Messages[id].Situations.Add(tag,count);
                }
                _tagger.AddSituationIndexItem(tag + " " + count);

            }

            SituationIndex.RemoveSituationFromIndex(args.Id, args.Tag);
            SituationIndex.TagsetCounter[args.Tag]--;

            _tagger.DeleteSituationIndexItem(args.Tag + " " + args.Id.ToString());
            



            if (args.Id < SituationIndex.Index[args.Tag].Count + 1)
            {
                for (int i = args.Id + 1; i <= SituationIndex.Index[args.Tag].Count; i++)
                {
                    var list = SituationIndex.Index[args.Tag][i];
                    foreach (var id in list)
                    {
                        MessageContainer.Messages[id].Situations[args.Tag]--;
                    }

                    SituationIndex.RemoveSituationFromIndex(i, args.Tag);
                    SituationIndex.AddSituationToIndex(list, i - 1, args.Tag);

                    _tagger.DeleteSituationIndexItem(args.Tag + " " + i.ToString());
                    _tagger.AddSituationIndexItem(args.Tag + " " + (i - 1).ToString());
                }
            }
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
                            var MessageIdAndSituations = line.Split(' ');
                            _service.SituationContainer.Add(Int32.Parse(MessageIdAndSituations[0]), MessageIdAndSituations[1]);

                           var situationsSet = MessageIdAndSituations[1].Split(new char[] { '+' },StringSplitOptions.RemoveEmptyEntries);

                            foreach (var situation in situationsSet)
                            {
                                var splitSituation = situation.Split('-');
                                int sitId = int.Parse(splitSituation[1]);
                                if (SituationIndex.Index.ContainsKey(splitSituation[0]))
                                {
                                    if (!SituationIndex.Index[splitSituation[0]].ContainsKey(sitId))
                                        {
                                        SituationIndex.Index[splitSituation[0]].Add(sitId, new List<int>());
                                        SituationIndex.Index[splitSituation[0]][sitId].Add(int.Parse(MessageIdAndSituations[0]));
                                            }
                                    else
                                    {
                                        SituationIndex.Index[splitSituation[0]][sitId].Add(int.Parse(MessageIdAndSituations[0]));
                                    }
                                }
                                else
                                {
                                    SituationIndex.Index.Add(splitSituation[0], new Dictionary<int, List<int>>());
                                    SituationIndex.Index[splitSituation[0]].Add(sitId, new List<int>());
                                    SituationIndex.Index[splitSituation[0]][sitId].Add(int.Parse(MessageIdAndSituations[0]));

                                }

                                //TODO: Revise and add a wrapper ASAP
                                _tagger.AddSituationIndexItem(splitSituation[0] + " " + splitSituation[1]);
                            }
                        }
                    }
                    _service.TaggedIds = _service.SituationContainer.Keys.ToList();
                    _service.TaggedIds.Sort();
                    _tagger.UpdateSituationCount(SituationIndex.SituationCount());
                }
            }
        }
    


        private void _tagger_SaveTagged(object sender, EventArgs e)

        {

            if (_main.FileLoadState)
            {
                using (StreamWriter counts = new StreamWriter(pathcounts))
                {
                    foreach (var kvp in SituationIndex.TagsetCounter)
                    {
                        counts.WriteLine(kvp.Key + " " + kvp.Value.ToString());
                    }
                }
                using (StreamWriter file = File.AppendText(savedpath))
                {

                    foreach (var msg in MessageContainer.Messages)
                    {
                        if (msg.Situations.Count != 0 && !_service.SituationContainer.ContainsKey(msg.Id))
                        {
                            file.Write(msg.Id.ToString() + " ");
                            foreach (var kvp in msg.Situations)
                            {
                                file.Write(kvp.Key + "-" + kvp.Value.ToString() + "+");
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
                _main.SetTagsetLabel(_service.ProjectTagset);
                _tagger.DisplayTagsetColors(TagsetIndex.ColorIndex[_service.ProjectTagset]);
            }
            
            
            
        }


        
        private void _tagger_AddTag(object sender, TaggerEventArgs e)
        {
            //Stopwatch.StartNew();
            if (SituationIndex.TagsetCounter.Count != 0) {
                SituationIndex.AddSituationToIndex(e.messages,e.Id, e.Tag);
                
                foreach (var id in e.messages)
                {
                    if (!MessageContainer.Messages[id].Situations.ContainsKey(e.Tag)) 
                    { 
                        MessageContainer.Messages[id].Situations.Add(e.Tag, SituationIndex.TagsetCounter[e.Tag]);

                    }
                    else
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
            _tagger.UpdateSituationCount(SituationIndex.SituationCount());
           
        }


        private void _tagger_WriteToDisk(object sender, WriteEventArgs e)
        {
            _writer.OpenWriter();
            foreach(var kvp in SituationIndex.Index)
            {
                foreach(var pair in kvp.Value)
                {
                    _writer.WriteSituation(pair.Value, kvp.Key, pair.Key); //was this hard?
                }
            }
            _writer.CloseWriter();
        }


        //private void _main_TagClick(object sender, EventArgs e)
        //{
        //    if (!_tagger.SituationsLoaded)
        //    {
        //        LoadTagged(null, null);
        //        _tagger.SituationsLoaded = true;
        //    }
        //    ShowTags(MessageContainer.Messages.Count);
        //    _tagger.ShowView();
        //    _tagger.ShowDates(IndexService.MessagesPerDay.Keys.ToList());
        //}

        //private void _tagger_LoadMore(object sender, EventArgs e)
        //{          
        //    AddDocumentsToDisplay(2000);
        //    _tagger.ShowDates(IndexService.MessagesPerDay.Keys.ToList());

        //}



        //private void AddDocumentsTagsToDisplay(int count)
        //{
        //    var list = IndexService.LoadSomeDocuments(count);
        //    MessageContainer.Messages.AddRange(list);
        //    ShowTags(count);
            

        //}



        private void _tagger_TagsetClick(object sender, EventArgs e)
        {
            _tagset.ShowView();
        }

    }
}
