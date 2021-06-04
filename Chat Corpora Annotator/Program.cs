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

            NGramService ngrammer = new NGramService();
            ConcordanceService concordancer = new ConcordanceService();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainWindow main = new MainWindow();
            CSVLoader loader = new CSVLoader();
            LinearHeatmapForm heatmap = new LinearHeatmapForm();
            DelimiterStep delim = new DelimiterStep();
            ChartForm chart = new ChartForm();
            Suggester suggester = new Suggester();

            CSVReadService fileReader = new CSVReadService();
            SearchService searcher = new SearchService();
            HeatmapService heater = new HeatmapService();
            FolderService folder = new FolderService();
            DatasetStatisticsService dataset = new DatasetStatisticsService();
            TaggedCollectionStatisticsService corpus = new TaggedCollectionStatisticsService();

            //var tagger = main;
            TagService service = new TagService();
            TagsetEditor editor = new TagsetEditor();
            TagFileWriter writer = new TagFileWriter();
            DictEditor dictEditor = new DictEditor();
            DictEditorPresenter de = new DictEditorPresenter(dictEditor, suggester);
            TagPresenter tagPresenter = new TagPresenter(main, main, service, editor, writer);
            TagsetPresenter tagsetPresenter = new TagsetPresenter(editor, service, main);
            SuggestPresenter suggestPresenter = new SuggestPresenter(suggester, main, main);
            MainPresenter presenter = new MainPresenter(main, main, service, loader, searcher, folder, dataset, corpus, concordancer, ngrammer);

            CSVPresenter csv = new CSVPresenter(main, loader, fileReader, delim);
            HeatmapPresenter heatmapPresenter = new HeatmapPresenter(main, heatmap, heater);
            ChartPresenter chartPresenter = new ChartPresenter(main, chart);
            main.AddOwnedForm(delim);
            Application.Run(main);

        }
    }
}
