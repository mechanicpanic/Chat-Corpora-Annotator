using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Corpora_Annotator.CSV_Wizard
{
    public partial class DataLoadedStep : UserControl, IWizardItem
    {
        public DataLoadedStep()
        {
            InitializeComponent();
        }

        string IWizardItem.HeaderTitle { get { return "Done."} }

        string IWizardItem.StepType { get { return "DataLoaded"} };

        List<string> IWizardItem.GetValues()
        {
            throw new NotImplementedException();
        }
    }
}
