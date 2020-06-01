using System;
using System.Windows.Forms;
using Viewer.CSV_Wizard;
using Viewer.Framework.Presenters;
using Viewer.Framework.Services;
using Viewer.UI;

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
            DelimiterStep delim = new DelimiterStep();
            ChartForm chart = new ChartForm();

            CSVReadService fileReader = new CSVReadService();
            SearchService searcher = new SearchService();
            HeatmapService heater = new HeatmapService();
            FolderService folder = new FolderService();

            TagWindow tagger = new TagWindow();
            TagService service = new TagService();
            TagsetEditor editor = new TagsetEditor();
            TagFileWriter writer = new TagFileWriter();
            TagPresenter tagPresenter = new TagPresenter(main, tagger, service, editor, writer);

            MainPresenter presenter = new MainPresenter(main, loader, searcher, folder);

            CSVPresenter csv = new CSVPresenter(main, loader, fileReader, delim);
            HeatmapPresenter heatmapPresenter = new HeatmapPresenter(main, heatmap, heater);
            ChartPresenter chartPresenter = new ChartPresenter(main, chart);
            main.AddOwnedForm(delim);
            Application.Run(main);
        }
    }
}
