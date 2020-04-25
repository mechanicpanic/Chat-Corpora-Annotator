using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using Wintellect.PowerCollections;
using Viewer.Framework;

namespace Viewer
{
    public partial class LinearHeatmapForm : Form, IHeatmapView
    {

        float IHeatmapView.Width { get; set; }
        float IHeatmapView.Height { get; set; }
        public SizeF RectangleSize { get; set; }
        public Point RectangleLocation { get; set; }
        public List<Color> Colors { get; set; }
        public List<RectangleF> Rectangles { get; set; }

        public LinearHeatmapForm()
        {
            InitializeComponent();
            panel1.Paint += panel1_Paint;
        }


        public void InitializeHeatMap(List<Color> colors)
        {

            Width = panel1.Width / colors.Count;
            Height = panel1.Height;


            RectangleSize = new SizeF(Width, Height);
            RectangleLocation = new Point(0, 0);
            this.Colors = colors;

        }
    



        
        public void DrawHeatMap()
        {
            for (int i = 0; i < Colors.Count; i++)
            {
                RectangleF rectangle = new RectangleF(RectangleLocation, RectangleSize);
                Rectangles.Add(rectangle);
                RectangleLocation += new Size((int)Width, 0);

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
        public void Draw()
        {
            panel1.Invalidate();
            panel1.Update();

        }

        private void FillDates(List<DateTime> dates)
        {
            
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
