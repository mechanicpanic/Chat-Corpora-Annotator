using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Viewer.Framework.Views;

namespace Viewer.UI
{
    public partial class TagsetEditor : Form, ITagsetView
    {
        public TagsetEditor()
        {
            InitializeComponent();
        }

        public List<string> CurrentTags { get; set; } = new List<string>();

        public event EventHandler SaveTagset;

        public void CloseView()
        {
            this.Hide();
        }

        public void ShowView()
        {
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text) && !listBox1.Items.Contains(textBox1.Text))
            {
                listBox1.Items.Add(textBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                foreach (int index in listBox1.SelectedIndices)
                {
                    
                    listBox1.Items.RemoveAt(index);
                }
                listBox1.SelectedItems.Clear();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                foreach (var item in listBox1.Items)
                {
                    CurrentTags.Add(item.ToString());
                }
            }
            SaveTagset?.Invoke(this,EventArgs.Empty);
        }
    }
}
