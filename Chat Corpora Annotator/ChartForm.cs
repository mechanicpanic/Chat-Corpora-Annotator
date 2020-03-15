using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chat_Corpora_Annotator
{
    public partial class ChartForm : Form
    {
        ChartValues<int> chartValues;
        List<string> chartLabels;

        float width;
        float height;
        SizeF rectangleSize;
        Point rectangleLocation;
        Dictionary<DateTime,Color> colors;
        List<RectangleF> rectangles;
        public ChartForm()
        {

            InitializeComponent();
            
            panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
        public void InitializeHeatMap(Dictionary<DateTime,Color> colors)
        {
            
            width = panel1.Width / colors.Keys.Count;
            height = panel1.Height;
            rectangleSize = new SizeF(40, 40);
            rectangleLocation = new Point(13, 477);
            this.colors = colors;


                
            



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;
            RectangleF rectangle = new RectangleF(rectangleLocation, rectangleSize);
            
            


            SolidBrush heatBrush = new SolidBrush(Color.Black);
            g.FillRectangle(heatBrush, rectangle);
                
            heatBrush.Dispose();

            
        }
        public void DrawHeatMap()
        {
            panel1.Invalidate();
            panel1.Update();
            
        }

    }
}
