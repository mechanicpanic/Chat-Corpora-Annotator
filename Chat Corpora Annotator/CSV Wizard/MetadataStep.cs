using System.Collections.Generic;
using System.Windows.Forms;

namespace Viewer.CSV_Wizard
{
    public partial class MetadataStep : UserControl, IWizardItem
    {
        public MetadataStep()
        {
            InitializeComponent();

        }

        public void PopulateComboBoxes(List<string> fields)
        {
            dateComboBox.Items.AddRange(fields.ToArray());
            senderComboBox.Items.AddRange(fields.ToArray());
            textComboBox.Items.AddRange(fields.ToArray());
        }

        public string HeaderTitle { get { return "Please select specified keys."; } }

        public string StepType { get { return "Metadata"; } }

        public List<string> GetValues()
        {
            List<string> keys = new List<string>();
            if (dateComboBox.SelectedItem != null && senderComboBox.SelectedItem != null && textComboBox.SelectedItem != null)
            {
                keys.Add(dateComboBox.SelectedItem.ToString());
                keys.Add(senderComboBox.SelectedItem.ToString());
                keys.Add(textComboBox.SelectedItem.ToString());
                return keys;
            }
            else
            {
                MessageBox.Show("Please select keys");
                return null;
            }
        }
    }
}
