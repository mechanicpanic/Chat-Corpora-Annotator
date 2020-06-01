using IndexingServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Viewer.Framework.Views;

namespace Viewer.UI
{
    public partial class Suggester : Form, ISuggesterView
    {
        public Suggester()
        {
            InitializeComponent();
        }

        private int icode = 0;
        private int isoft = 0;
        private int ijob = 0;
        private int imeet = 0;
        public List<DynamicMessage> CurrentSoft { get; set; }
        public List<DynamicMessage> CurrentMeet { get; set; }
        public List<DynamicMessage> CurrentJob { get; set; }
        public List<DynamicMessage> CurrentCode { get; set; }

        public event SuggesterMoveEventHandler MoveSituation;
        public void CloseView()
        {
            this.Hide();
        }

        public void DisplaySituation(string type)
        {
            switch (type)
            {
                case "job":
                    jobView.SetObjects(CurrentJob);
                    jobView.Invalidate();
                    break;
                case "meet":
                    meetView.SetObjects(CurrentMeet);
                    meetView.Invalidate();
                    break;
                case "code":
                    codeView.SetObjects(CurrentCode);
                    codeView.Invalidate();
                    break;
                case "soft":
                    codeView.SetObjects(CurrentSoft);
                    codeView.Invalidate();
                    break;

            }
        }

        public void ShowView()
        {
            this.Show();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            TabPage page = tabControl1.SelectedTab;
            var name = page.Name;
            SuggesterMoveEventArgs args = new SuggesterMoveEventArgs();
            switch (name)
            {
                case "job":
                    
                    args.Index = ijob++;
                    args.Type = "job";
                    MoveSituation?.Invoke(this, args);
                    break;
                case "meet":
                    args.Index = imeet++;
                    args.Type = "meet";
                    MoveSituation?.Invoke(this, args);
                    break;
                case "code":
                    args.Index = icode++;
                    args.Type = "code";
                    MoveSituation?.Invoke(this, args);
                    break;
                case "soft":
                    args.Index = isoft++;
                    args.Type = "soft";
                    MoveSituation?.Invoke(this, args);
                    break;
                
            }

        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            TabPage page = tabControl1.SelectedTab;
            var name = page.Name;
            SuggesterMoveEventArgs args = new SuggesterMoveEventArgs();
            switch (name)
            {
                case "job":
                    if (ijob >= 1)
                    {
                        args.Index = ijob--;
                        args.Type = "job";
                        MoveSituation?.Invoke(this, args);
                    }
                    
                    break;
                case "meet":
                    if (imeet >= 1)
                    {
                        args.Index = imeet--;
                        args.Type = "meet";
                        MoveSituation?.Invoke(this, args);
                    }
                    break;
                case "code":
                    if (icode >= 1)
                    {
                        args.Index = icode--;
                        args.Type = "code";
                        MoveSituation?.Invoke(this, args);
                    }
                    break;
                case "soft":
                    if (isoft >= 1)
                    {
                        args.Index = isoft--;
                        args.Type = "soft";
                        MoveSituation?.Invoke(this, args);
                    }
                    break;

            }
        }
    }
}
