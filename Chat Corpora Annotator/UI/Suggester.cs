using BrightIdeasSoftware;
using IndexEngine;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Viewer.Framework.Views;
using System.Drawing;

namespace Viewer.UI
{
    public partial class Suggester : Form, ISuggesterView
    {
        public Suggester()
        {
            InitializeComponent();
            suggesterView.FormatRow += FastObjectListView1_FormatRow;
            //this.suggesterView.HotItemStyle = new HotItemStyle();
            //suggesterView.HotItemStyle.BackColor = SystemColors.MenuHighlight;
        }

        private void FastObjectListView1_FormatRow(object sender, FormatRowEventArgs e)
        {
            DynamicMessage dyn = (DynamicMessage)e.Item.RowObject;
            if (Hits.Contains(dyn.Id))
            {
                e.Item.BackColor = Color.Pink;
            }
        }

        public List<DynamicMessage> CurrentSituation { get; set; } = new List<DynamicMessage>();

        //public Dictionary<string, List<string>> UserDicts { get; set; } = new Dictionary<string, List<string>>();
        public string QueryString { get; set; }
        public List<List<List<int>>> QueryResult { get; set; } = new List<List<List<int>>>();
        public int DisplayIndex { get; set; } = 0;
        public int GroupIndex { get; set; } = 0;
        public event EventHandler RunQuery;
        public event UserDictsEventHandler AddUserDict;
        public event UserDictsEventHandler DeleteUserDict;
        public event FindEventHandler ShowMessageInMainWindow;

        private List<int> Hits;
        public void CloseView()
        {
            this.Hide();
        }

        public void SetCounts()
        {
            if (QueryResult != null)
            {
                groupsLabel.Text = "Found groups: " + QueryResult.Count.ToString();
                //label4.Text = QueryResult.Sum(x => x.Count).ToString();
                int count = 0;
                foreach (var list in QueryResult)
                {
                    foreach (var res in list)
                    {
                        count += res.Count;
                    }
                }
                suggLabel.Text= "Found suggestions: " + count.ToString();
            }
        }
        public void DisplaySituation()
        {
            
            CurrentSituation.Clear();
            List<int> temp = new List<int>();
            if (QueryResult != null || QueryResult.Count != 0)
            {
                foreach (var list in QueryResult[DisplayIndex])
                {

                    temp.AddRange(list);
                }
                //temp.Add();
                //temp.Add(temp.Min() - 2);
                //temp.Add(temp.Max() + 1);
                //temp.Add(temp.Max() + 2);
                ////bleh
                temp.Sort();
                Hits = temp;
                CurrentSituation.Add(IndexService.RetrieveMessageById(temp.Min() - 2));
                CurrentSituation.Add(IndexService.RetrieveMessageById(temp.Min() - 1));

                for (int i = temp[0]; i <= temp[temp.Count - 1]; i++)
                {
                    CurrentSituation.Add(IndexEngine.IndexService.RetrieveMessageById(i));
                }
                CurrentSituation.Add(IndexService.RetrieveMessageById(temp.Max() + 1));
                CurrentSituation.Add(IndexService.RetrieveMessageById(temp.Max() + 2));

                suggesterView.SetObjects(CurrentSituation);
                SetUpChatView();
                suggesterView.Sort(suggesterView.AllColumns.Find(x => x.Text.Equals(IndexService.DateFieldKey)), SortOrder.Ascending);
            }
            else
            {
                MessageBox.Show("Nothing found");
            }
        }
        private void SetUpChatView()
        {
            List<OLVColumn> columns = new List<OLVColumn>();

            foreach (var key in IndexService.SelectedFields)
            {
                OLVColumn cl = new OLVColumn();
                cl.AspectGetter = delegate (object x)
                {
                    DynamicMessage message = (DynamicMessage)x;
                    return message.Contents[key];
                };
                cl.Text = key;
                cl.WordWrap = true;


                columns.Add(cl);


            }
            suggesterView.AllColumns.Clear();
            suggesterView.AllColumns.AddRange(columns);

            foreach (var cl in suggesterView.AllColumns)
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
            
            suggesterView.RebuildColumns();
            suggesterView.Refresh();
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
            if(DisplayIndex < QueryResult.Count - 1)
            {
                DisplayIndex++;
                DisplaySituation();
            }
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
            richTextBox1.Text = richTextBox1.Text + " " + b.Text;
        }

        private void Suggester_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
           
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void fastObjectListView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void fastObjectListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void fastObjectListView1_ItemActivate(object sender, EventArgs e)
        {
            var item = suggesterView.GetModelObject(suggesterView.SelectedIndex) as DynamicMessage;
            var arg = new FindEventArgs();
            arg.id = item.Id;
            ShowMessageInMainWindow?.Invoke(this, arg);
            
        }
    }
}
