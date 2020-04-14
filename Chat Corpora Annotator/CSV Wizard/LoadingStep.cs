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
