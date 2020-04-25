using CSharpTest.Net.Collections;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Framework.Views
{
    public interface IChartView
    {
        ChartValues<int> ChartValues { get; set; }
        List<string> ChartLabels { get; set; }
    }
}
