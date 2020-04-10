using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using Wintellect.PowerCollections;

namespace Chat_Corpora_Annotator
{
    public partial class LinearHeatmapForm : Form
    {

        float width;
        float height;
        SizeF rectangleSize;
        Point rectangleLocation;
        List<Color> colors;
        List<RectangleF> rectangles = new List<RectangleF>();


        public LinearHeatmapForm()
        {
            InitializeComponent();
            panel1.Paint += panel1_Paint;
        }


        public void InitializeHeatMap(List<Color> colors)
        {

            width = panel1.Width / colors.Count;
            height = panel1.Height;


            rectangleSize = new SizeF(width, height);
            rectangleLocation = new Point(0, 0);
            this.colors = colors;

        }
    



        
        public void DrawHeatMap()
        {
            for (int i = 0; i < colors.Count; i++)
            {
                RectangleF rectangle = new RectangleF(rectangleLocation, rectangleSize);
                rectangles.Add(rectangle);
                rectangleLocation += new Size((int)width, 0);

            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;
            
            for(int i = 0; i < rectangles.Count; i++)
            {
                using (SolidBrush heatBrush = new SolidBrush(colors[i]))
                {
                    g.FillRectangle(heatBrush, rectangles[i]);
                }
                
                
            }

            


        }
        public void Draw()
        {
            panel1.Invalidate();
            panel1.Update();

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
