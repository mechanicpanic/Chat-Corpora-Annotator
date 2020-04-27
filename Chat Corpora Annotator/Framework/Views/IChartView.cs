using CSharpTest.Net.Collections;
using LiveCharts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Framework.Views
{
    public interface IChartView: IView
    {
        ChartValues<int> ChartValues { get; set; }
        void DrawChart(List<DateTime> days, List<int> counts);
        //List<string> ChartLabels { get; set; }
    }
}
