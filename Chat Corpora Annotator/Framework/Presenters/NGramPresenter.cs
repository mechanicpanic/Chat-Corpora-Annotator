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

namespace Viewer.Framework.Presenters
{
    public class NGramPresenter
    {
        private readonly IMainView _main;
        private readonly INGramView _grams;

        private readonly IIndexService _indexer;
        private readonly ISearchService _searcher;

        public NGramPresenter(IMainView main, IIndexService indexer, ISearchService searcher, INGramView grams)
        {
            this._main = main;
            this._grams = grams;
            this._indexer = indexer;
            this._searcher = searcher;

            _grams.NGramClick += _grams_NGramClick;
            _main.NGramClick += _main_NGramClick;
        }

        private void _main_NGramClick(object sender, EventArgs e)
        {
            _grams.ShowView();
        }

        private void _grams_NGramClick(object sender, EventArgs e)
        {

            //TODO: Move to NGramService!!!
            List<string> result = new List<string>();
            BTreeDictionary<string, int> countedGrams = new BTreeDictionary<string, int>();
            TopDocs Hits = LuceneService.Searcher.Search(LuceneService.Parser.Parse(_grams.Term), 50);
            for (int i = 0; i < Hits.TotalHits; i++)
            {

                ScoreDoc d = Hits.ScoreDocs[i];
                Document idoc = LuceneService.Searcher.Doc(d.Doc);
                result.Add(idoc.GetField(_main.TextFieldKey).GetStringValue());


            }
            foreach(var msg in result)
            {
                LuceneService.NGrammer.maxGramSize = _grams.maxSize;
                LuceneService.NGrammer.minGramSize = _grams.minSize;
                LuceneService.NGrammer.ShowUnigrams = _grams.ShowUnigrams;
                foreach(var gram in _searcher.GetNGrams(_main.TextFieldKey, msg))
                {
                    if (!countedGrams.Keys.Contains(gram))
                    {
                        countedGrams.Add(gram, 1);
                    }
                    else
                    {
                        int temp = countedGrams[gram];
                        temp++;
                        countedGrams.TryUpdate(gram, temp);
                    }

                }
            }
            _grams.DisplayNGrams(countedGrams.Keys.ToList());

           
            
        }
    }
}
