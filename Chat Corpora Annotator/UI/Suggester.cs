using BrightIdeasSoftware;
using IndexEngine;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Viewer.Framework.Views;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace Viewer.UI
{
    public partial class Suggester : Form, ISuggesterView
    {
        private bool IsLockedMode = true;
        public Suggester()
        {
            InitializeComponent();
            suggesterView.FormatRow += FastObjectListView1_FormatRow;
            queryBox.Parent = this.panel2;
        }

        public List<DynamicMessage> CurrentSituation { get; set; } = new List<DynamicMessage>();
        public string QueryString { get; set; }
        public List<List<List<int>>> QueryResult { get; set; } = new List<List<List<int>>>();
        public int DisplayIndex { get; set; } = 0;
        public int GroupIndex { get; set; } = 0;
        public event EventHandler RunQuery;
        public event UserDictsEventHandler AddUserDict;
        public event UserDictsEventHandler DeleteUserDict;
        public event FindEventHandler ShowMessageInMainWindow;

        private List<int> Hits;

        private void FastObjectListView1_FormatRow(object sender, FormatRowEventArgs e)
        {
            DynamicMessage dyn = (DynamicMessage)e.Item.RowObject;
            if (Hits.Contains(dyn.Id))
            {
                e.Item.BackColor = Color.Pink;
            }
        }
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

        private void findButton_Click(object sender, EventArgs e)
        {
            if (!IsLockedMode)
            {
                if (!String.IsNullOrEmpty(queryBox.Text))
                {
                    this.QueryString = queryBox.Text;
                    RunQuery?.Invoke(this, EventArgs.Empty);
                }
            }
            else
            {
                this.QueryString = CreateQueryString();
                MessageBox.Show(QueryString);
                //RunQuery?.Invoke(this, EventArgs.Empty);
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
                foreach(var control in queryPanel.Controls)
                {
                    var button = control as Button;
                    if(button.Text == "haswordofdict()")
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem(la.CurName);
                        item.Click += MenuStripItem_Click;
                        button.ContextMenuStrip.Items.Add(item);
                    }
                }
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
            if(b.Text == ",")
            {
                queryBox.Text = queryBox.Text + ";";
            }
            if (b.Text == ",")
            {
                queryBox.Text = queryBox.Text + ",";
            }
            else
            {
                queryBox.Text = queryBox.Text + " " + b.Text;
            }
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

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void operator_MouseDown(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
         
            this.DoDragDrop(control.Name, DragDropEffects.Copy);
        }

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault() as Button;
            if (control != null)
            {
                var panel = sender as FlowLayoutPanel;
                var clone = control.Clone();
                clone.Dock = DockStyle.None;
                clone.AutoSize = true;
                clone.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                clone.AllowDrop = false;
                clone.KeyDown += Clone_KeyDown;

                if (clone.Text == "haswordofdict()") {
                    clone.ContextMenuStrip = new ContextMenuStrip();
                    clone.MouseClick += operator_MouseClick;
                    foreach (var kvp in UserDictsContainer.UserDicts) {
                        ToolStripMenuItem item = new ToolStripMenuItem(kvp.Key);
                        item.Click += MenuStripItem_Click;
                        clone.ContextMenuStrip.Items.Add(item);
                    }
                }
                else if (clone.Text == "hasusermentioned()" || clone.Text == "byuser()" || clone.Text == "num") 
                {
                    clone.ContextMenuStrip = new ContextMenuStrip();
                    clone.MouseClick += operator_MouseClick;
                    ToolStripTextBox item = new ToolStripTextBox();
                    clone.ContextMenuStrip.Items.Add(item);
                    item.TextBox.KeyDown += TextBox_KeyDown;
                    
                }
              

                //cp.Location = this.flowLayoutPanel1.PointToClient(new Point(e.X, e.Y));
                ((FlowLayoutPanel)sender).Controls.Add(clone);
            }
        }

        private void Clone_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                var control = sender as Control;
                var parent = control.Parent as FlowLayoutPanel;
                parent.Controls.Remove(control);
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            int res;
            var box = sender as TextBox;
            if (e.KeyCode == Keys.Enter && box.TextLength > 0)
            {
                
                var strip = box.Parent as ContextMenuStrip;
                var button = strip.SourceControl as Button;
                if (button.Text.Contains("by"))
                {
                    button.Text = "byuser(" + box.Text + ")";
                }
                else if(button.Text.Contains("hasuser"))
                {
                    button.Text = "hasusermentioned(" + box.Text + ")";
                }
                else if(button.Text.Contains("num") ||  int.TryParse(button.Text,out res))
                {
                    button.Text = box.Text;
                }
            }
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void MenuStripItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (sender as ToolStripItem);
            if (item != null)
            {
                ContextMenuStrip owner = item.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    Button button = owner.SourceControl as Button;
                    if(button.Text.Contains("haswordofdict"))
                    {
                        button.Text = "haswordofdict(" + item.Text + ")";
                    }
                }
            }
        }


        private void operator_MouseClick(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if(e.Button == MouseButtons.Right)
            {
                button.ContextMenuStrip.Show();
            }
        }


        private string CreateQueryString()
        {
            StringBuilder builder = new StringBuilder();
            if (IsLockedMode)
            {
                foreach (var control in queryPanel.Controls)
                {
                    var button = control as Button;

                    if (button.Text == "," || button.Text == ";" || button.Text == "(" || button.Text == ")"  || button.Text == "select")
                    {
                        builder.Append(button.Text);
                    }
                    else
                    {
                        builder.Append(" ");
                        builder.Append(button.Text);
                        
                    }
                }
            }
            return builder.ToString();
        }

        private void SwitchMode()
        {
            if (IsLockedMode)
            {
                foreach (var control in boolPanel.Controls)
                {
                    var button = control as Button;
                    button.MouseDown -= operator_MouseDown;
                    button.Click += operator_Click;
                }
                foreach (var control in operatorPanel.Controls)
                {
                    var button = control as Button;
                    button.MouseDown -= operator_MouseDown;
                    button.Click += operator_Click;
                }
            }
            else
            {
                foreach (var control in boolPanel.Controls)
                {
                    var button = control as Button;
                    button.MouseDown += operator_MouseDown;
                    button.Click -= operator_Click;
                }
                foreach (var control in operatorPanel.Controls)
                {
                    var button = control as Button;
                    button.MouseDown += operator_MouseDown;
                    button.Click -= operator_Click;
                }
            }
        }

        private void switchModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsLockedMode)
            {
                SwitchMode();
                IsLockedMode = false;
                queryBox.Visible = true;
                queryPanel.Visible = false;
                queryBox.Invalidate();

            }
            else
            {
                SwitchMode();
                IsLockedMode = true;
                queryPanel.Visible = true;
                queryBox.Visible = false;
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


    public static class ControlExtensions
    {
        public static T Clone<T>(this T controlToClone)
            where T : Control
        {
            PropertyInfo[] controlProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            T instance = Activator.CreateInstance<T>();

            foreach (PropertyInfo propInfo in controlProperties)
            {
                if (propInfo.CanWrite)
                {
                    if (propInfo.Name != "WindowTarget")
                        propInfo.SetValue(instance, propInfo.GetValue(controlToClone, null), null);
                }
            }

            return instance;
        }
    }
}
