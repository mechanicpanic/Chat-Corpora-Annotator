using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Chat_Corpora_Annotator
{
    public partial class ChartForm : Form
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
            foreach(var day in days)
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
