using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
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

        List<Panel> panels = new List<Panel>();
        List<ToolTip> tooltips = new List<ToolTip>();

        Dictionary<Panel, string> captions = new Dictionary<Panel, string>();
        public LinearHeatmapForm()
        {
            InitializeComponent();
            panel1.Paint += panel1_Paint;

        }



        public void DrawHeatmap(List<string> DateBlocks)
        {
            RectangleWidth = panel1.Width / Colors.Count;
            RectangleHeight = panel1.Height;

            
            RectangleSize = new SizeF(RectangleWidth, RectangleHeight);
            RectangleLocation = new Point(0, 0);

            for (int i = 0; i < Colors.Count; i++)
            {
                RectangleF rectangle = new RectangleF(RectangleLocation, RectangleSize);
                Rectangles.Add(rectangle);
                

                
                Panel panel = new Panel();
                panel.Size = RectangleSize.ToSize();
                panel.Location = RectangleLocation;
                //panel.MouseHover += Panel_MouseHover;
                panel.MouseClick += Panel_MouseClick;
                panel.BringToFront();
                panel.Enabled = true;
                panels.Add(panel);
                captions.Add(panel, DateBlocks[i]);
                //ToolTip tt = new ToolTip();
                //tt.SetToolTip(panel,DateBlocks[i]);
                //tooltips.Add(tt);
               
                RectangleLocation += new Size((int)RectangleWidth, 0);

            }
            
        }

        private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            richTextBox1.Text = captions[panel];
        }

        private void Panel_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;

            for (int i = 0; i < Rectangles.Count; i++)
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
            label3.Text = dates[dates.Count - 1].Date.ToString("dd/MM/yyyy");
            label2.Text = dates[(dates.Count - 1) / 2].Date.ToString("dd/MM/yyyy");

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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
