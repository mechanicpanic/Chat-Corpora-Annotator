using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Corpora_Annotator.Framework
{
    public interface ICSVView : IView
    {

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

        event Action HeaderFinished;
        event Action DataLoaded;



    }
}
