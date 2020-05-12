using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Framework.Views;
using Viewer.Framework.Services;
using Lucene.Net.Search;
using IndexingServices;

namespace Viewer.Framework.Presenters
{
    public class ConcordancePresenter
    {
        private readonly IMainView _main;
        private readonly IConcordanceView _conview;
       
        
        private readonly IConcordanceService _concordancer;

        public ConcordancePresenter(IMainView main, IConcordanceService concordancer,IConcordanceView conview)
        {
            this._main = main;
            this._conview = conview;
            this._concordancer = concordancer;

            _conview.ConcordanceClick += Conview_ConcordanceClick;
            
        }

        

        private void Conview_ConcordanceClick(object sender, EventArgs e)
        {
            
            _concordancer.ConQuery = LuceneService.Parser.Parse(_conview.Term);
            _concordancer.FindConcordance(_conview.Term, IndexService.TextFieldKey, 20);
            
            _conview.DisplayConcordance(_concordancer.Concordance.ToArray());
        }
    }
}
