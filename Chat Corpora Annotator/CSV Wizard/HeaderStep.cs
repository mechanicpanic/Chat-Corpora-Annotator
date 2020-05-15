using System.Collections.Generic;
using System.Windows.Forms;

namespace Viewer.CSV_Wizard
{
    public partial class HeaderStep : UserControl, IWizardItem
    {

        public string StepType { get { return "Header"; } }
        public HeaderStep(string[] fields)
        {
            InitializeComponent();
            foreach (var field in fields)
            {
                listView1.Items.Add(new ListViewItem(field));
            }
            listView1.Invalidate();
        }

        public string HeaderTitle { get { return "Select the columns to be uploaded."; } }

        public List<string> GetValues()
        {
            List<string> selectedFields = new List<string>();
            foreach (ListViewItem item in listView1.CheckedItems)
            {
                selectedFields.Add(item.Text);
            }
            return selectedFields;
        }
    }
}
