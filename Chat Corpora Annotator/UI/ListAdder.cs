using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewer.UI
{
    public partial class ListAdder : Form
    {
        public string CurName { get; set; } 
        public List<string> CurList { get; set; }  

        public event EventHandler SaveList;
        public ListAdder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                this.CurName = textBox1.Text;
                if(!String.IsNullOrEmpty(richTextBox1.Text))
                {
                    this.CurList = new List<string>();
                    foreach (var line in richTextBox1.Lines)
                    {
                        CurList.Add(line);
                    }
                    SaveList?.Invoke(this, EventArgs.Empty);
                }
                

            }

            
        }
    }
}
