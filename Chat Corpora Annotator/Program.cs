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

            //MainWindow main = new MainWindow();
            //CSVLoader loader = new CSVLoader();

            //CSVReadService fileReader = new CSVReadService();
            //SearchService searcher = new SearchService();
            //IndexService indexer = new IndexService();

            //MainPresenter presenter = new MainPresenter(main, indexer, searcher);
            //CSVPresenter csv = new CSVPresenter(main, loader, fileReader, indexer);
            //HeatmapPresenter heatmap = new HeatmapPresenter(main,)
            //ChartPresenter chart = new ChartPresenter()
            //Application.Run(main);
            Application.Run(new MainWindow());
           
        }
    }
}
