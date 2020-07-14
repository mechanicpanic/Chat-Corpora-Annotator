
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;

using System.Windows.Forms;
using Viewer.Framework.Views;

namespace Viewer
{
    public partial class ChartForm : Form, IChartView
    {

        public ChartForm()
        {

            InitializeComponent();


        }

        public ChartValues<int> ChartValues { get; set; }
        public List<string> ChartLabels { get; set; }

        public void CloseView()
        {
            this.Hide();
        }

        public void DrawChart(List<DateTime> days, List<int> counts)
        {
            ChartValues = new ChartValues<int>(counts);
            ChartLabels = new List<string>();
            foreach (var day in days)
            {
                ChartLabels.Add(day.ToString());
            }
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Day",
                Labels = ChartLabels,
            });
            cartesianChart1.Series.Add(new LineSeries
            {
                Values = ChartValues,
                LineSmoothness = 1, //straight lines, 1 really smooth lines

            });
        }

        public void ShowView()
        {
            this.Show();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {

        }

        private void ChartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
