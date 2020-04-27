using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Viewer.Framework.Services;
using Viewer.Framework.Views;

namespace Viewer.Framework.Presenters
{
    public class ChartPresenter
    {
        private readonly IMainView _main;
        private readonly IChartView _chart;
        private readonly IIndexService _indexer;
       public ChartPresenter(IMainView main, IChartView chart, IIndexService indexer)
        {
            this._main = main;
            this._chart = chart;
            this._indexer = indexer;
            _main.ChartClick += _main_ChartClick;
        }

        private void _main_ChartClick(object sender, EventArgs e)
        {
            _chart.DrawChart(_indexer.MessagesPerDay.Keys.ToList(), _indexer.MessagesPerDay.Values.ToList());
            _chart.ShowView();
        }
    }
}
