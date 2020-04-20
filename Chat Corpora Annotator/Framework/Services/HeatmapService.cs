using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Corpora_Annotator.Framework
{

    public interface IHeatmapService
    {
        void DrawHeatmap();
        void CalculateData();



    }
    public class HeatmapService : IHeatmapService
    {
        public void DrawHeatmap() { }
        public void CalculateData() { }
    }
}
