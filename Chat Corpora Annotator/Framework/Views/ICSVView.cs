using Viewer.CSV_Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Viewer.Framework.Views
{
    public interface ICSVView : IView
    {
        void AddStep(IWizardItem step);
        List<IWizardItem> Steps { get; }
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
        
        event EventHandler HeaderSelected;
        event EventHandler MetadataAdded;
        event EventHandler ReadyToShow;
        void CorpusIndexed();
        //int FileLoadState { get; set; }

    }
}
