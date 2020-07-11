using BrightIdeasSoftware;
using IndexEngine;
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


        public List<DynamicMessage> CurrentSituation { get; set; } = new List<DynamicMessage>();

        //public Dictionary<string, List<string>> UserDicts { get; set; } = new Dictionary<string, List<string>>();
        public string QueryString { get; set; }
        public List<List<int>> QueryResult { get; set; } = new List<List<int>>();
        public int DisplayIndex { get; set; } = 0;

        public event EventHandler RunQuery;
        public event UserDictsEventHandler AddUserDict;
        public event UserDictsEventHandler DeleteUserDict;

        public void CloseView()
        {
            this.Hide();
        }

        public void DisplaySituation()
        {
            SetUpChatView();
            CurrentSituation.Clear();
            foreach (var i in QueryResult[DisplayIndex])
            {
                CurrentSituation.Add(IndexEngine.IndexService.RetrieveMessageById(i));
            }
            fastObjectListView1.SetObjects(CurrentSituation);
        }
        private void SetUpChatView()
        {
            List<OLVColumn> columns = new List<OLVColumn>();

            foreach (var key in MessageContainer.Messages[0].contents.Keys)
            {
                OLVColumn cl = new OLVColumn();
                cl.AspectGetter = delegate (object x)
                {
                    DynamicMessage message = (DynamicMessage)x;
                    return message.contents[key];
                };
                cl.Text = key;
                cl.WordWrap = true;


                columns.Add(cl);


            }
            fastObjectListView1.AllColumns.Clear();
            fastObjectListView1.AllColumns.AddRange(columns);

            foreach (var cl in fastObjectListView1.AllColumns)
            {
                if (cl.Text != IndexService.TextFieldKey)
                {
                    cl.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                else
                {
                    cl.FillsFreeSpace = true;

                }
            }
            
            fastObjectListView1.RebuildColumns();
        }

        public void ShowView()
        {
            this.Show();
        }
        //Buttons 1 and 2 are for seeing next/prev suggestion
        private void button1_Click(object sender, System.EventArgs e)
        {
            if(DisplayIndex > 0)
            {
                DisplayIndex--;
                DisplaySituation();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(DisplayIndex < QueryResult.Count)
            {
                DisplayIndex++;
                DisplaySituation();
            }
        }

        // This one is for running our pre-cooked queries
        private void preCooked_Click(object sender, EventArgs e)
        {
            this.QueryString = "";
            RunQuery?.Invoke(this, EventArgs.Empty);
        }

        //This is the Find button

        private void button7_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(richTextBox1.Text))
            {
                this.QueryString = richTextBox1.Text;
                RunQuery?.Invoke(this, EventArgs.Empty);
            }
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            ListAdder la = new ListAdder();
            
            la.SaveList += new EventHandler(SaveListHandler);
            la.Show();
        }
        private void SaveListHandler(object sender, EventArgs e)
        {
            ListAdder la = sender as ListAdder;
            if (la != null)
            {
                UserDictsEventArgs dictargs = new UserDictsEventArgs();
                dictargs.Name = la.CurName;
                dictargs.Words = la.CurList;
                //UserDicts.Add(la.CurName, la.CurList);
                AddUserDict?.Invoke(this, dictargs);

                var temp = new ListViewItem(la.CurName);
                temp.SubItems.Add(String.Join(", ", la.CurList.ToArray()));
                listView1.Items.Add(temp);

            }
            la.Close();
        }

        private void deleteListButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                foreach(ListViewItem item in listView1.SelectedItems)
                {
                    //UserDicts.Remove(item.Text);
                    UserDictsEventArgs dictargs = new UserDictsEventArgs();
                    dictargs.Name = item.Text;
                    DeleteUserDict?.Invoke(this, dictargs);
                    listView1.Items.Remove(item);
                }
            }
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            richTextBox1.Text = b.Text;
        }
    }
}
