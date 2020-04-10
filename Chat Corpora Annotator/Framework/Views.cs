using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Drawing;
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

    public interface IHeatmapView : IView
    {
        float Width { get; set; }
        float Height { get; set; }
        SizeF RectangleSize { get; set; }
        Point RectangleLocation { get; set; }
        List<Color> Colors { get; set; }

        List<RectangleF> Rectangles { get; set; }

        event Action CreateHeatmap;
        
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

        string SenderFieldKey
        {
            get; set;
        }

        string TextFieldKey { get; set; }

        event Action SelectedHeader;
        event Action SelectedMetadata;
        event Action DataLoaded;
        void ShowError(string errorMessage);
    }

    public interface IMainView : IView
    {

    }

}
