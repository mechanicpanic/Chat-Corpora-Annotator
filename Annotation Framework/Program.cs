using System;
using System.Diagnostics;
using System.Windows.Forms;
using Tagger.Framework.Main;

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
            TagWindow main = new TagWindow();
            TagService service = new TagService();
            TagsetEditor editor = new TagsetEditor();
            TagPresenter presenter = new TagPresenter(main, service, editor);
            Application.Run(main);
            Debugger.Launch();
        }
    }
}
