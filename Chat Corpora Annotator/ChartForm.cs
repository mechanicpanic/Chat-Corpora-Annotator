using Viewer.Framework;
using CSharpTest.Net.Collections;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Viewer
{
    public partial class ChartForm : Form, IChartView
    {
        ChartValues<int> chartValues;
        List<string> chartLabels;


        public ChartForm()
        {

            InitializeComponent();
            
           
        }


        public void InitializeChart(List<DateTime> days, List<int> counts)
        {
            chartValues = new ChartValues<int>(counts);
            chartLabels = new List<string>();
            foreach (var day in days)
            {
                chartLabels.Add(day.ToString());
            }
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Day",
                Labels = chartLabels,
            });
            cartesianChart1.Series.Add(new LineSeries
            {
                Values = chartValues,
                LineSmoothness = 1, //straight lines, 1 really smooth lines

            });
        }

    }
}
