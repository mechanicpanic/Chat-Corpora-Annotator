﻿using LiveCharts;
using System;
using System.Collections.Generic;

namespace Viewer.Framework.Views
{
    public interface IChartView : IView
    {
        ChartValues<int> ChartValues { get; set; }
        void DrawChart(List<DateTime> days, List<int> counts);
        //List<string> ChartLabels { get; set; }
    }
}
