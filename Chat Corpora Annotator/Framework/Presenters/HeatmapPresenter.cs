using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndexingServices;
using Viewer.Framework.Services;
using Viewer.Framework.Views;
namespace Viewer.Framework.Presenters
{
	public class HeatmapPresenter
	{
		private readonly IMainView _view;
		private readonly IHeatmapView _heat;

		private readonly IHeatmapService _painter;
		private readonly IIndexService _indexer;

		public HeatmapPresenter(IMainView view, IHeatmapView heat, IHeatmapService painter, IIndexService indexer)
		{
			_view = view;
			_heat = heat;
			_painter = painter;
			_indexer = indexer;

			_view.HeatmapClick += _view_HeatmapClick;
		}

		private void _view_HeatmapClick(object sender, EventArgs e)
		{
			_heat.Colors = _painter.PopulateHeatmap(_view.MessagesPerDay);
			_heat.ShowView();
			_heat.DrawHeatmap();
			_heat.FillDates(_view.MessagesPerDay.Keys.ToList());
		}

		


	}
}
