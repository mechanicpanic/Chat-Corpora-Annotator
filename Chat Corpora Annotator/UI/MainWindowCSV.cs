using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Viewer.Framework.Views;

namespace Viewer
{
    public partial class MainWindow : Form, IMainView, ITagView, INotifyPropertyChanged
    {
        private void openCsvDialog()
        {
            csvDialog = new OpenFileDialog();
            csvDialog.Filter = "CSV files (*.csv)|*.csv|TSV files (*.tsv)|*.tsv";
            csvDialog.Title = "Open a separated-value file";
            csvDialog.FileOk += csvDialog_FileOk;
        }
        private void csvDialog_FileOk(object sender, CancelEventArgs e)
        {

            this.CurrentPath = csvDialog.FileName;
            string name = Path.GetFileNameWithoutExtension(CurrentPath);
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            if (Directory.Exists(folderPath + "\\CCA"))
            {
                Directory.CreateDirectory(folderPath + "\\CCA" + "\\" + name);
            }
            else
            {
                MessageBox.Show("Something went wrong. Please restart");
            }

            this.CurrentIndexPath = folderPath + "\\CCA" + "\\" + name;
            FileAndIndexSelected?.Invoke(this, EventArgs.Empty);

        }

    }
}
