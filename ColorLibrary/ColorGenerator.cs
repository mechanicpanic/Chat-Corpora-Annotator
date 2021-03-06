using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hsluv;

namespace ColorLibrary
{
    public static class ColorGenerator
    {
        static Random rnd = new Random();

        public static Color[] GenerateColorsFromList(int count)
        {
            Color[] colors;
            HashSet<Color> temp = new HashSet<Color>();
            bool flag;
            int num;
            for (int i = 0; i < count; i++)
            {
                flag = false;
                num = rnd.Next(0, count);
                while (!flag)
                {
                    flag = temp.Add(ColorTranslator.FromHtml(ColorValues[i]));
                }
            }
            colors = temp.ToArray();
           
            return colors;

        }

       private static string[] ColorValues = {

    "#98724c",
    "#908f32",
    "#c8b55b",
    "#af652f",
    "#c3c13d",
    "#70a16c",
    "#e4dc8c",
    "#d3d3d3",
    "#a1d569",
    "#f59335",
    "#4ec2e8",
    "#fec7cd",
    "#95c1c0",
    "#b3b3b3",
    "#ed5466",
    "#afdb80",
    "#d2a4b4",
    "#75a1a0",
    "#a54242",
    "#de935f",
    "#cc6666",
    "#b5bd68",
    "#f0c674",
    "#81a2be",
    "#b294bb",
    "#8abeb7",
    "#c5c8c6"
        };
       public static Color[] GenerateHSVColors(int count)
        {
            Color[] colors;
            double h;
            double s;
            double v;
            double golden_ratio_conjugate = 0.618033988749895;
            bool flag;

            HashSet<Color> temp = new HashSet<Color>();
            for (int i = 0; i < count; i++)
            {
                flag = false;
                h = rnd.NextDouble();
                h += golden_ratio_conjugate;
                h %= 1;

                v = rnd.NextDouble() * (0.99 - 0.75) + 0.75;
                s = rnd.NextDouble() * (0.6 - 0.4) + 0.4;
                while (!flag)
                {
                    flag = temp.Add(HsvToColor(h, s, v));
                }

            }
            colors = temp.ToArray();
            return colors;


        }

        public static Color HsvToColor(double h, double s, double v)
        {

            var hInt = (int)Math.Floor(h * 6.0);
            var f = h * 6 - hInt;
            var p = v * (1 - s);
            var q = v * (1 - f * s);
            var t = v * (1 - (1 - f) * s);
            var r = 256.0;
            var g = 256.0;
            var b = 256.0;

            switch (hInt)
            {
                case 0: r = v; g = t; b = p; break;
                case 1: r = q; g = v; b = p; break;
                case 2: r = p; g = v; b = t; break;
                case 3: r = p; g = q; b = v; break;
                case 4: r = t; g = p; b = v; break;
                case 5: r = v; g = p; b = q; break;
            }
            var c = Color.FromArgb(255,
                                   (byte)Math.Floor(r * 255.0),
                                   (byte)Math.Floor(g * 255.0),
                                   (byte)Math.Floor(b * 255.0));

            return c;
        }

 
    }
}
