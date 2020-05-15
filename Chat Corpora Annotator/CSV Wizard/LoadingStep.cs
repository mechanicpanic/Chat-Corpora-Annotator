using System.Collections.Generic;
using System.Windows.Forms;

namespace Viewer.CSV_Wizard
{
    public partial class LoadingStep : UserControl, IWizardItem
    {
        public LoadingStep()
        {
            InitializeComponent();
        }

        public string HeaderTitle { get { return "Please wait until your corpus is indexed."; } }

        public string StepType { get { return "Loading"; } }

        public List<string> GetValues()
        {
            return null;
        }


    }
}
