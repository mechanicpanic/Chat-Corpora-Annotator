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
            comboBox1.SelectedItem = "20";
            comboBox1.SelectedText = "20";

        }
     
        private string PadString(string line, string term, int count)
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
                if (left.Length < count)
                {
                    left = left.PadLeft(count+3);

                }
                else
                {
                    left = left.Remove(0, left.Length - count);
                    left = "..." + left;
                }
            }
            else
            {
                left = " ";
                left = left.PadLeft(count+3);
            }

            if (!String.IsNullOrEmpty(right))
            {
                if (right.Length < count)
                {
                    right = right.PadRight(count+3);
                }
                else
                {
                    var temp = right.Length - count;
                    right = right.Remove(right.Length - temp, temp);
                    right = right + "...";
                }
            }
            else
            {
                right = " ";
                
                right = right.PadRight(count);
            }
            
            return left + center + right;
        }
        public void DisplayConcordance(string[] con)
        {
            //richTextBox1.Lines = con;
            List<string> newlines = new List<string>();
            newlines.Add("Displaying "+con.Length.ToString()+" matches:");
            foreach(var line in con)
            {
                var newline = PadString(line, Term,Int32.Parse(comboBox1.SelectedItem.ToString()));
                newlines.Add(newline);
            }
            richTextBox1.Lines = newlines.ToArray();
            
            
        }
        public string Term { get; set; }
        public bool IsControl { get { return true; } }

        public event EventHandler ConcordanceClick;


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Split().Length > 1 || String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrWhiteSpace(textBox1.Text))
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
            this.Dispose();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
