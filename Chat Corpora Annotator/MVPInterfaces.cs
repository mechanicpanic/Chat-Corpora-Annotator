using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Corpora_Annotator
{
    public interface IView
    {
        void Show();
        void Close();
    }
    
    public interface ICSVView : IView
    {
        string CsvPath { get; set; }
        string[] AllFields { get; set; }
        List<string> SelectedFields { get; set; }

        string DateFieldKey
        {
            get; set;
        }

        string senderFieldKey
        {
            get; set;
        }
        event Action SelectedHeader;
        event Action SelectedMetadata;
        void ShowError(string errorMessage);
    }
    public interface IPresenter
    {
        void Run();
    }

    public interface ICSVService
    {
        bool SelectedHeader(string[] allFields); // true - не нулевой массив
        bool SelectedMetadata(List<string> selectedFields);
    }
}
