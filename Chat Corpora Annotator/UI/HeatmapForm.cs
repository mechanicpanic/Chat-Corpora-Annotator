using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            //panel1.Paint += panel1_Paint;

        }

        private List<string> DateBlocks;

        public void DrawHeatmap(List<string> DateBlocks)
        {
            this.DateBlocks = DateBlocks;
            RectangleWidth = this.Width / Colors.Count;
            RectangleHeight = this.Height - panel2.Height;

            
            RectangleSize = new SizeF(RectangleWidth, RectangleHeight);
            RectangleLocation = new Point(0, 0);

            for (int i = 0; i < Colors.Count; i++)
            {
                //RectangleF rectangle = new RectangleF(RectangleLocation, RectangleSize);
                //Rectangles.Add(rectangle);
                

                
                Panel panel = new Panel();
                panel.Size = RectangleSize.ToSize();
                panel.Location = RectangleLocation;
                panel.BringToFront();
                panel.BackColor = Colors[i];
                panel.Enabled = true;
                panel.Visible = true;
                panel.Paint += Panel_Paint;
                this.Controls.Add(panel);
                panels.Add(panel);

                ToolTip tt = new ToolTip();

                var split = DateBlocks[i].Split(' ');
                var date = split.ToList();

                date.RemoveAll(x => String.IsNullOrEmpty(x));
                if (date.Count == 1)
                {
                    tt.SetToolTip(panel, date[0]);
                }
                else
                {
                    tt.SetToolTip(panel, date[0] + " - " + date[date.Count-2]);
                }
                
                tooltips.Add(tt);

                RectangleLocation += new Size((int)RectangleWidth, 0);

            }
            
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int i = Array.IndexOf(panels.ToArray(), panel);
            using (Graphics g = e.Graphics)
            {
                using (SolidBrush heatBrush = new SolidBrush(Colors[i]))
                {
                    g.FillRectangle(heatBrush, panel.ClientRectangle);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;

            for (int i = 0; i < panels.Count; i++)
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



        public void ShowView()
        {
            this.Show();
        }

        public void CloseView()
        {
            this.Hide();
        }

       
    }
}
