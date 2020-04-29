using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Viewer.Framework.Views;

namespace Viewer.UI
{
    public partial class Concordancer : UserControl, IConcordanceView
    {
        public Concordancer()
        {
            InitializeComponent();

        }
        public void DisplayConcordance(string[] con)
        {
            richTextBox1.Lines = con;
            foreach(var line in richTextBox1.Lines)
            {
                
            }
        }
        public string Term { get; set; }
        public int OFFSET { get; set; }

        public event EventHandler ConcordanceClick;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Split().Count() > 1)
            {
                MessageBox.Show("Please enter a single term");
            }
            else
            {
                ConcordanceClick?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
