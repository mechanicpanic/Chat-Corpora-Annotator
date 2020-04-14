using System.Collections.Generic;
using System.Drawing;

namespace Chat_Corpora_Annotator.Framework
{
    public interface IHeatmapView
    {
        float Width { get; set; }
        float Height { get; set; }
        SizeF RectangleSize { get; set; }
        Point RectangleLocation { get; set; }
        List<Color> Colors { get; set; }
        List<RectangleF> Rectangles { get; set; }



    }
}
