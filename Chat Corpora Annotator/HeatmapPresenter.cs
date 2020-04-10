using Chat_Corpora_Annotator.Framework;
using System;

namespace Chat_Corpora_Annotator
{
    public class HeatmapPresenter: BasePresenter<IHeatmapView>
    {
        private readonly IHeatmapService _service;

        public HeatmapPresenter(IApplicationController controller, IHeatmapView view, IHeatmapService service)
            : base(controller, view)
        {
            _service = service;

            View.CreateHeatmap += () => CreateHeatmap();
        }

        private void CreateHeatmap()
        {
            
        }
    }
}
