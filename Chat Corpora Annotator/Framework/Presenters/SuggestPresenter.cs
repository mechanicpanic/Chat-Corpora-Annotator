using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Framework.Services;
using Viewer.Framework.Views;

namespace Viewer.Framework.Presenters
{
    public class SuggestPresenter
    {
        private readonly ISuggesterView _sugg;
        private readonly ISuggestService _service;
        private readonly ITagView _tagger;
        public SuggestPresenter(ISuggesterView sugg,
                               ISuggestService service, ITagView tagger)
        {
            this._sugg = sugg;
            this._service = service;
            this._tagger = tagger;

            _tagger.ShowSuggester += _tagger_ShowSuggester;

            _sugg.MoveSituation += _sugg_MoveSituation;
        }

        private void _tagger_ShowSuggester(object sender, EventArgs e)
        {
            _sugg.ShowView();
        }

        private void _sugg_MoveSituation(object sender, SuggesterMoveEventArgs args)
        {
            switch (args.Type)
            {
                case "job":
                    _sugg.CurrentJob = _service.JobIndex[args.Index];
                    _sugg.DisplaySituation("job");
                    break;
                case "meet":
                    _sugg.CurrentMeet = _service.MeetIndex[args.Index];
                    _sugg.DisplaySituation("meet");
                    break;
                case "code":
                    _sugg.CurrentCode = _service.CodeIndex[args.Index];
                    _sugg.DisplaySituation("code");
                    break;
                case "soft":
                    _sugg.CurrentSoft = _service.SoftIndex[args.Index];
                    _sugg.DisplaySituation("soft");
                    break;

            }
        }

        
    }
}
