using IndexingServices;
using System;
using System.Linq;
using Viewer.Framework.Services;
using Viewer.Framework.Views;

namespace Viewer.Framework.Presenters
{
    public class NGramPresenter
    {
        private readonly IMainView _main;
        private readonly INGramView _grams;


        private readonly ISearchService _searcher;
        private readonly INGramService _ngrammer;
        public NGramPresenter(IMainView main, ISearchService searcher, INGramService ngrammer, INGramView grams)
        {
            this._main = main;
            this._grams = grams;

            this._searcher = searcher;
            this._ngrammer = ngrammer;

            _grams.NGramClick += _grams_NGramClick;

        }



        private void _grams_NGramClick(object sender, EventArgs e)
        {

            _grams.DisplayNGrams(_ngrammer.BigramIndex,_ngrammer.TrigramIndex,_ngrammer.FourgramIndex,_ngrammer.FivegramIndex);

        }
    }
}
