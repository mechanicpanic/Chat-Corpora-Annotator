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
    public partial class Keyworder : UserControl, IKeywordView
    {
        public Keyworder()
        {
            InitializeComponent();
        }
        public event EventHandler RakeClick;
        public List<string> RakeKeywords { get; set; }
        public Dictionary<List<string>, int> Keyphrases { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            RakeClick?.Invoke(this, EventArgs.Empty);
        }
        public void DisplayRakeKeywords()
        {
            richTextBox1.Lines = this.RakeKeywords.ToArray().;
        }
        public void ShowView()
        {
            this.Show();
        }
        public void CloseView()
        {
            this.Dispose();

        }
    }
}
