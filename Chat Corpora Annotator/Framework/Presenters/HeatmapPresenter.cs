using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Corpora_Annotator.Framework.Presenters
{
    public class HeatmapPresenter
    {
        private readonly IMainView _view;
        private readonly IHeatmapView _heat;

        private readonly IHeatmapService _painter;
    }
}
