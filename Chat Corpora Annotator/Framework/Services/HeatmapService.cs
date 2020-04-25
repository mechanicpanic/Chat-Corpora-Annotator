using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Framework.Services
{

    public interface IHeatmapService
    {


        Color HeatMapColor(double value, double min, double max);



    }
    public class HeatmapService : IHeatmapService
    {
        public Color HeatMapColor(double value, double min, double max)
        {
            double val = (value - min) / (max - min);
            int r = Convert.ToByte(255 * val);
            int g = Convert.ToByte(255 * (1 - val));
            int b = 10;

            return Color.FromArgb(255, r, g, b);
        }
    }
}
