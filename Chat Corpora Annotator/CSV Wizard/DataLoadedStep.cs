using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Viewer.CSV_Wizard
{
    public partial class DataLoadedStep : UserControl, IWizardItem
    {
        public DataLoadedStep()
        {
            InitializeComponent();
        }

        string IWizardItem.HeaderTitle { get { return "Done."; } }

        string IWizardItem.StepType { get { return "DataLoaded"; } }

        List<string> IWizardItem.GetValues()
        {
            throw new NotImplementedException();
        }
    }
}
