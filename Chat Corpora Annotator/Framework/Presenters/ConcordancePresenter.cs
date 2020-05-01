using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Framework.Views;
using Viewer.Framework.Services;
namespace Viewer.Framework.Presenters
{
    public class ConcordancePresenter
    {
        private readonly IMainView _main;
        private readonly IConcordanceView _conview;
       
        private readonly IIndexService _indexer;
        private readonly IConcordanceService _concordancer;

        public ConcordancePresenter(IMainView main,IIndexService indexer, IConcordanceService concordancer,IConcordanceView conview)
        {
            this._main = main;
            this._conview = conview;
            this._indexer = indexer;
            this._concordancer = concordancer;

            _conview.ConcordanceClick += Conview_ConcordanceClick;
            _main.ConcordanceClick += _main_ConcordanceClick;
        }

        private void _main_ConcordanceClick(object sender, EventArgs e)
        {
            _conview.ShowView();
        }

        private void Conview_ConcordanceClick(object sender, EventArgs e)
        {
            _concordancer.ConQuery = LuceneService.Parser.Parse(_conview.Term);
            _concordancer.FindConcordance(_conview.Term, _main.TextFieldKey, 20);
            
            _conview.DisplayConcordance(_concordancer.Concordance.ToArray());
        }
    }
}
