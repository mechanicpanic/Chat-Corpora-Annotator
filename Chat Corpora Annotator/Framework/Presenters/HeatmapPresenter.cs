﻿using IndexEngine.Paths;
using System;
using System.Linq;
using Viewer.Framework.Services;
using Viewer.Framework.Views;
namespace Viewer.Framework.Presenters
{
    public class HeatmapPresenter
    {
        private readonly IMainView _view;
        private readonly IHeatmapView _heat;

        private readonly IHeatmapService _painter;


        public HeatmapPresenter(IMainView view, IHeatmapView heat, IHeatmapService painter)
        {
            _view = view;
            _heat = heat;
            _painter = painter;


            _view.HeatmapClick += _view_HeatmapClick;
        }

        private void _view_HeatmapClick(object sender, EventArgs e)
        {
            _heat.Colors = _painter.PopulateHeatmap(ProjectInfo.Data.MessagesPerDay);
            _heat.ShowView();
            _heat.DrawHeatmap(_painter.DateBlocks);
            _heat.FillDates(ProjectInfo.Data.MessagesPerDay.Keys.ToList());
        }




    }
}
