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
    public partial class Concordancer : Form, IConcordanceView
    {
        public Concordancer()
        {
            InitializeComponent();

        }
     
        private string PadString(string line, string term)
         {
            string left;
            string center;
            string right;
            int index = line.ToLower().IndexOf(term);
            if(index != -1)
            {
                left = line.Substring(0, index);
                center = line.Substring(index, term.Length);
                right = line.Substring(index + term.Length);
            }
            else
            {
                //left = null;
                //center = null;
                //right = null;
                return null;

            }

            if (!String.IsNullOrEmpty(left))
            {
                if (left.Length < 20)
                {
                    left = left.PadLeft(23);

                }
                else
                {
                    left = left.Remove(0, left.Length - 20);
                    left = "..." + left;
                }
            }
            else
            {
                left = " ";
                left = left.PadLeft(23);
            }

            if (!String.IsNullOrEmpty(right))
            {
                if (right.Length < 20)
                {
                    right = right.PadRight(23);
                }
                else
                {
                    var temp = right.Length - 20;
                    right = right.Remove(right.Length - temp, temp);
                    right = right + "...";
                }
            }
            else
            {
                right = " ";
                
                right = right.PadRight(23);
            }
            
            return left + center + right;
        }
        public void DisplayConcordance(string[] con)
        {
            //richTextBox1.Lines = con;
            List<string> newlines = new List<string>();
            foreach(var line in con)
            {
                var newline = PadString(line, Term);
                newlines.Add(newline);
            }
            richTextBox1.Lines = newlines.ToArray();
            
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
                this.Term = textBox1.Text;
                ConcordanceClick?.Invoke(this, EventArgs.Empty);
            }
        }

        public void ShowView()
        {
            this.Show();
        }

        public void CloseView()
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
