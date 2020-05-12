using Lucene.Net.Search;
using Lucene.Net.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Framework.Services;
using Viewer.Framework.Views;
using CSharpTest.Net.Collections;
using IndexingServices;

namespace Viewer.Framework.Presenters
{
    public class NGramPresenter
    {
        private readonly IMainView _main;
        private readonly INGramView _grams;

        private readonly IIndexService _indexer;
        private readonly ISearchService _searcher;
        private readonly INGramService _ngrammer;
        public NGramPresenter(IMainView main, IIndexService indexer, ISearchService searcher, INGramService ngrammer, INGramView grams)
        {
            this._main = main;
            this._grams = grams;
            this._indexer = indexer;
            this._searcher = searcher;
            this._ngrammer = ngrammer;

            _grams.NGramClick += _grams_NGramClick;
            
        }

        

        private void _grams_NGramClick(object sender, EventArgs e)
        {


            _ngrammer.BuildNgramIndex(_grams.maxSize, _grams.minSize, _grams.ShowUnigrams, _indexer.TextFieldKey,_grams.Term);
            
            _grams.DisplayNGrams(_ngrammer.NgramIndex.Keys.ToList());


           
            
        }
    }
}
