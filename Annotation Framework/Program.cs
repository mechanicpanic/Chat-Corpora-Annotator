﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using Tagger.Framework.Main;
using Viewer;

namespace Tagger
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
            //Application.Run(new Form1());
            MainWindow main = new MainWindow();
            TagService service = new TagService();
            TagsetEditor editor = new TagsetEditor();
            TagPresenter presenter = new TagPresenter(main,service, editor);
            Application.Run(main);
            Debugger.Launch();
        }
    }
}
