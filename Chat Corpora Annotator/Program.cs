﻿using System;
using System.Windows.Forms;
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
            Concordancer conview = new Concordancer();
            //ChartForm chart = new ChartForm();

            CSVReadService fileReader = new CSVReadService();
            SearchService searcher = new SearchService();
            IndexService indexer = new IndexService();
            HeatmapService heater = new HeatmapService();
            ConcordanceService concordancer = new ConcordanceService();

            MainPresenter presenter = new MainPresenter(main, loader, conview, indexer, searcher,heatmap);
            CSVPresenter csv = new CSVPresenter(main, loader, fileReader, indexer);
            HeatmapPresenter heatmapPresenter = new HeatmapPresenter(main, heatmap, heater, indexer);
            ConcordancePresenter conPresenter = new ConcordancePresenter(main, indexer, concordancer, conview);
            //ChartPresenter chartPresenter = new ChartPresenter(main, chart, indexer);
            Application.Run(main);
            
           
        }
    }
}
