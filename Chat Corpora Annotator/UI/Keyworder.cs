using CSharpTest.Net.Collections;
using System;
using System.Collections.Generic;
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
        public BTreeDictionary<string, double> RakeKeywords { get; set; } = new BTreeDictionary<string, double>();
        public Dictionary<List<string>, int> Keyphrases { get; set; }
        public int RakeWordCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void button1_Click(object sender, EventArgs e)
        {
            RakeClick?.Invoke(this, EventArgs.Empty);
        }
        public void DisplayRakeKeywords()
        {
            foreach (var kvp in RakeKeywords)
            {
                fastObjectListView1.AddObject(kvp);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panel2.Visible)
            {
                panel2.Visible = false;

            }
            else
            {
                panel2.Visible = true;

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel3.Visible)
            {
                panel3.Visible = false;

            }
            else
            {
                panel3.Visible = true;

            }
        }
    }
}
