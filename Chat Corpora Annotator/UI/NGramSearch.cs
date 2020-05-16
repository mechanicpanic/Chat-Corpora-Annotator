
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Viewer.Framework.Views;

namespace Viewer.UI
{
    public partial class NGramSearch : UserControl, INGramView
    {
        public NGramSearch()
        {
            InitializeComponent();
            //comboBox1.SelectedItem = "2";
            //comboBox1.SelectedText = "2";
            //comboBox2.SelectedItem = "2";
            //comboBox2.SelectedText = "2";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text.Split().Length > 1)
            //{
            //    MessageBox.Show("Please enter a single term");
            //}
            //else
            //{}
            this.Term = textBox1.Text;
            this.maxSize = 2;
            this.minSize = 3;
            this.ShowUnigrams = false;
            NGramClick?.Invoke(this, EventArgs.Empty);

        }

        public string Term { get; set; }
        //public int Size { get; set; }
        public int minSize { get; set; }
        public int maxSize { get; set; }
        public bool ShowUnigrams { get; set; }

        public event EventHandler NGramClick;

        public void CloseView()
        {
            this.Dispose();

        }

        public void DisplayNGrams(List<string> grams)
        {
            richTextBox1.Clear();
            richTextBox1.Lines = grams.ToArray();
            richTextBox1.Invalidate();
        }

        public void ShowView()
        {
            this.Show();
        }

        public void DisplayNGramCounts(List<int> counts)
        {
            throw new NotImplementedException();
        }
    }
}
