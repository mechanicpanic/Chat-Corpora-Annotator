using System;
using System.Windows.Forms;

namespace Viewer.UI
{
    public partial class TagsetName : Form
    {
        public string Tagset { get; set; }
        public event EventHandler NameButtonClicked;
        public TagsetName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                this.Tagset = textBox1.Text;

            }
            NameButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}