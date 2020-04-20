using CSharpTest.Net.Collections;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Corpora_Annotator.Framework
{
    public interface IChartView
    {
        ChartValues<int> chartValues { get; set; }
        List<string> chartLabels { get; set; }
    }
}
