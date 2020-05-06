using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using Wintellect.PowerCollections;
using Viewer.Framework.Views;

namespace Viewer
{
    public partial class LinearHeatmapForm : Form, IHeatmapView
    {

        float RectangleWidth { get; set; }
        float RectangleHeight { get; set; }
        public SizeF RectangleSize { get; set; }
        public Point RectangleLocation { get; set; }
        public List<Color> Colors { get; set; }
        public List<RectangleF> Rectangles { get; set; } = new List<RectangleF>();

        public LinearHeatmapForm()
        {
            InitializeComponent();
            panel1.Paint += panel1_Paint;
            
        }


       
        public void DrawHeatmap()
        {
            RectangleWidth = panel1.Width / Colors.Count;
            RectangleHeight = panel1.Height;


            RectangleSize = new SizeF(RectangleWidth, RectangleHeight);
            RectangleLocation = new Point(0, 0);
            for (int i = 0; i < Colors.Count; i++)
            {
                RectangleF rectangle = new RectangleF(RectangleLocation, RectangleSize);
                Rectangles.Add(rectangle);
                RectangleLocation += new Size((int)RectangleWidth, 0);

            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;
            
            for(int i = 0; i < Rectangles.Count; i++)
            {
                using (SolidBrush heatBrush = new SolidBrush(Colors[i]))
                {
                    g.FillRectangle(heatBrush, Rectangles[i]);
                }
                
                
            }

            


        }

        public void FillDates(List<DateTime> dates)
        {
            label1.Text = dates[0].Date.ToString("dd/MM/yyyy");
            label3.Text = dates[dates.Count-1].Date.ToString("dd/MM/yyyy");
            label2.Text = dates[(dates.Count - 1)/2].Date.ToString("dd/MM/yyyy");

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        public void ShowView()
        {
            this.Show();
        }

        public void CloseView()
        {
            this.Close();
        }
    }
}
