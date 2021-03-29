using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Viewer.Framework.Views;

namespace Viewer.CSV_Wizard
{
    public partial class DelimiterStep : Form, IView
    {
        public readonly Dictionary<string, string> Delimiters = new Dictionary<string, string>();

        public event EventHandler DelimiterSelected;
        public DelimiterStep()
        {
            Delimiters.Add("Comma", ",");
            Delimiters.Add("Tab", @"    ");
            Delimiters.Add("Pipe", "|");
            Delimiters.Add("Colon", ";");
            InitializeComponent();
        }

        public string ReturnDelimiter()

        {
            return Delimiters[comboBox1.SelectedItem.ToString()];

        }

        public void ShowView()
        {
            this.Show();
        }
        public void CloseView()
        {
            comboBox1.SelectedItem = null;
            button1.Invalidate();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DelimiterSelected?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Please select item");

            }
        }
    }
}
