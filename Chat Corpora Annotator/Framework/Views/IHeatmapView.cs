using System.Collections.Generic;
using System.Drawing;

namespace Viewer.Framework.Views
{
    public interface IHeatmapView : IView
    {

        List<Color> Colors { get; set; }

        void DrawHeatmap();

    }
}
