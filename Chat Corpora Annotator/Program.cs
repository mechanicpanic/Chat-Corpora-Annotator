using System;
using System.Windows.Forms;
using Viewer.Framework.Presenters;
using Viewer.Framework.Services;

namespace Viewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainWindow main = new MainWindow();
            CSVLoader loader = new CSVLoader();
            LinearHeatmapForm heatmap = new LinearHeatmapForm();
            //ChartForm chart = new ChartForm();

            CSVReadService fileReader = new CSVReadService();
            SearchService searcher = new SearchService();
            IndexService indexer = new IndexService();
            HeatmapService heater = new HeatmapService();
            

            MainPresenter presenter = new MainPresenter(main, loader, indexer, searcher,heatmap);
            CSVPresenter csv = new CSVPresenter(main, loader, fileReader, indexer);
            HeatmapPresenter heatmapPresenter = new HeatmapPresenter(main, heatmap, heater, indexer);
            //ChartPresenter chartPresenter = new ChartPresenter(main, chart, indexer);
            Application.Run(main);
            
           
        }
    }
}
