using BrightIdeasSoftware;
using IndexEngine;
using IndexEngine.Indexes;
using IndexEngine.Paths;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Viewer.Framework.MyEventArgs;
using Viewer.Framework.Views;

namespace Viewer.UI
{
    public partial class Suggester : Form, ISuggesterView
    {
        private bool IsLockedMode = false;
        private string lastOperator;
        private List<int> Hits;

        public event EventHandler ShowDictEditor;
        public event EventHandler RunQuery;
        public event UserDictsEventHandler AddUserDict;
        public event UserDictsEventHandler DeleteUserDict;
        public event FindEventHandler ShowMessageInMainWindow;

        public List<DynamicMessage> CurrentSituation { get; set; } = new List<DynamicMessage>();
        public List<List<List<int>>> QueryResult { get; set; } = new List<List<List<int>>>();
        public string QueryString { get; set; }
        public int DisplayIndex { get; set; } = 0;
        public int GroupIndex { get; set; } = 0;



        public Suggester()
        {
            InitializeComponent();
            suggesterView.FormatRow += FastObjectListView1_FormatRow;
            //queryBox.Parent = this.panel2;
            //SwitchMode();
            foreach (var control in boolPanel.Controls)
            {
                var button = control as Button;
                button.Click += operator_Click;
                button.Tag = new ButtonTag(boolPanel.Controls.GetChildIndex(button), button.Text);
               

            }
            foreach (var control in operatorPanel.Controls)
            {
                var button = control as Button;
                button.Click += operator_Click;
                button.Tag = new ButtonTag(operatorPanel.Controls.GetChildIndex(button) + 9, button.Text);
                

            }
            foreach (var margin in queryBox.Margins)
                margin.Width = 0;
            this.LastElementChanged += Suggester_LastElementChanged;
        }


        private void Suggester_LastElementChanged(object sender, EventArgs e)
        {
            if (queryPanel.Controls.Count > 0)
            {
                this.lastOperator = (queryPanel.Controls[queryPanel.Controls.Count - 1].Tag as ButtonTag).Name;
                for (int i = 0; i < rules[lastOperator].Length; i++)
                {
                    if (i < 9)
                    {
                        if (rules[lastOperator][i] == 1)
                        {
                            boolPanel.Controls[i].BackColor = Color.BlanchedAlmond;
                        }
                        if (rules[lastOperator][i] == 0)
                        {
                            boolPanel.Controls[i].BackColor = Color.Lavender;
                        }
                    }


                    else
                    {
                        if (rules[lastOperator][i] == 1)
                        {
                            operatorPanel.Controls[i - 9].BackColor = Color.BlanchedAlmond;
                        }
                        else
                        {
                            operatorPanel.Controls[i - 9].BackColor = Color.Lavender;
                        }
                    }


                }
            }
            else
            {
                foreach (var control in boolPanel.Controls)
                {
                    (control as Button).BackColor = Color.Lavender;
                }
                foreach (var control in operatorPanel.Controls)
                {
                    (control as Button).BackColor = Color.Lavender;
                }
            }
        }

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
                suggLabel.Text = "Found suggestions: " + count.ToString();
            }
        }
        public void DisplaySituation()
        {

            CurrentSituation.Clear();
            List<int> temp = new List<int>();
            if (QueryResult != null && QueryResult.Count != 0)
            {
                counterLabel.Text = DisplayIndex.ToString() + "/" + QueryResult.Count.ToString();
                foreach (var list in QueryResult[DisplayIndex])
                {

                    temp.AddRange(list);
                }
                temp.Sort();
                Hits = temp;
                CurrentSituation.Add(LuceneService.RetrieveMessageById(temp.Min() - 2));
                CurrentSituation.Add(LuceneService.RetrieveMessageById(temp.Min() - 1));

                for (int i = temp[0]; i <= temp[temp.Count - 1]; i++)
                {
                    CurrentSituation.Add(LuceneService.RetrieveMessageById(i));
                }
                CurrentSituation.Add(LuceneService.RetrieveMessageById(temp.Max() + 1));
                CurrentSituation.Add(LuceneService.RetrieveMessageById(temp.Max() + 2));

                suggesterView.SetObjects(CurrentSituation);
                SetUpChatView();
                suggesterView.Sort(suggesterView.AllColumns.Find(x => x.Text.Equals(ProjectInfo.DateFieldKey)), SortOrder.Ascending);
            }
            if (QueryResult == null)
            {
                MessageBox.Show("Incorrect query");
            }
            if (QueryResult != null && QueryResult.Count == 0)
            {
                MessageBox.Show("Nothing found");
            }
        }
        private void SetUpChatView()
        {
            List<OLVColumn> columns = new List<OLVColumn>();

            foreach (var key in ProjectInfo.Data.SelectedFields)
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
                if (cl.Text != ProjectInfo.TextFieldKey)
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
            if (DisplayIndex > 0)
            {
                DisplayIndex--;
                DisplaySituation();
            }
            counterLabel.Text = DisplayIndex.ToString() + "/" + QueryResult.Count.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DisplayIndex < QueryResult.Count - 1)
            {
                DisplayIndex++;
                DisplaySituation();
            }
            counterLabel.Text = DisplayIndex.ToString() + "/" + QueryResult.Count.ToString();
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
                //MessageBox.Show(QueryString);
                RunQuery?.Invoke(this, EventArgs.Empty);
            }
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            //ListAdder la = new ListAdder();
            //la.SaveList += new EventHandler(SaveListHandler);
            //la.Show();
            ShowDictEditor?.Invoke(this, null);
            
        }
        //private void SaveListHandler(object sender, EventArgs e)
        //{
        //    ListAdder la = sender as ListAdder;
        //    if (la != null)
        //    {
        //        UserDictsEventArgs dictargs = new UserDictsEventArgs();
        //        dictargs.Name = la.CurName;
        //        dictargs.Words = la.CurList;
        //        AddUserDict?.Invoke(this, dictargs);
                
        //        DisplayUserDict(la.CurName, la.CurList);

        //    }
        //    la.Close();
        //}

        public void DisplayUserDict(string key, List<string> value)
        {
            var temp = new ListViewItem(key);
            temp.Name = key;
            temp.SubItems.Add(String.Join(", ", value.ToArray()));
            listView1.Items.Add(temp);
            AddListNameToOp(key);
        }

        private void AddListNameToOp(string name)
        {
            foreach (var control in queryPanel.Controls)
            {
                var button = control as Button;
                if (button.Text.Contains("haswordofdict"))
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(name);
                    item.Name = name;
                    item.Click += MenuStripItem_Click;
                    button.ContextMenuStrip.Items.Add(item);
                }
            }
        }

        public void DeleteUserDictFromPreview(string key)
        {
            var search = listView1.Items.Find(key, false);
                    foreach (var control in queryPanel.Controls)
                    {
                        if ((control as Button).Text.Contains("haswordofdict"))
                        {

                            (control as Button).ContextMenuStrip.Items.RemoveByKey(search[0].Text);
                        }

                    }
                    listView1.Items.Remove(search[0]);         
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Text == ";")
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
                clone.AllowDrop = true;
                clone.KeyDown += Clone_KeyDown;
                clone.DragOver += clone_DragOver;
                clone.MouseDown += clone_MouseDown;
                clone.DragEnter += clone_DragEnter;
                clone.BackColor = Color.Lavender;
                if (clone.Text == "haswordofdict()")
                {

                    clone.ContextMenuStrip = new ContextMenuStrip();
                    clone.MouseUp += operator_MouseUp;
                    foreach (var kvp in UserDictsIndex.GetInstance().IndexCollection)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem(kvp.Key);
                        item.Click += MenuStripItem_Click;
                        clone.ContextMenuStrip.Items.Add(item);
                    }
                }
                else if (clone.Text == "hasusermentioned()" || clone.Text == "byuser()" || clone.Text == "num")
                {
                    clone.ContextMenuStrip = new ContextMenuStrip();
                    clone.MouseUp += operator_MouseUp;
                    ToolStripTextBox item = new ToolStripTextBox();
                    clone.ContextMenuStrip.Items.Add(item);
                    item.TextBox.KeyDown += TextBox_KeyDown;

                }


                //cp.Location = this.flowLayoutPanel1.PointToClient(new Point(e.X, e.Y));
                ((FlowLayoutPanel)sender).Controls.Add(clone);
                LastElementChanged?.Invoke(this, null);
            }
        }

        private void Clone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
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
                else if (button.Text.Contains("hasuser"))
                {
                    button.Text = "hasusermentioned(" + box.Text + ")";
                }
                else if (button.Text.Contains("num") || int.TryParse(button.Text, out res))
                {
                    button.Text = box.Text;
                }
            }
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
                    if (button.Text.Contains("haswordofdict"))
                    {
                        button.Text = "haswordofdict(" + item.Text + ")";
                    }
                }
            }
        }

        private void operator_MouseUp(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (e.Button == MouseButtons.Right)
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

                    if (button.Text == "," || button.Text == ";" || button.Text == "(" || button.Text == ")" || button.Text == "select")
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

        private void switchMode_Click(object sender, EventArgs e)
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

        void clone_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Clicks == 1 && e.Button == MouseButtons.Left)
            {
                base.OnMouseDown(e);
                DoDragDrop(sender, DragDropEffects.All);
            }
            else if (e.Clicks > 1 && e.Button == MouseButtons.Left)
            {
                var control = sender as Control;
                var parent = control.Parent as FlowLayoutPanel;
                parent.Controls.Remove(control);

            }
            LastElementChanged?.Invoke(this, null);
        }

        void clone_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void clone_DragOver(object sender, DragEventArgs e)
        {
            base.OnDragOver(e);
            // is another dragable
            if (e.Data.GetData(typeof(Button)) != null)
            {
                FlowLayoutPanel p = (FlowLayoutPanel)(sender as Button).Parent;
                //Current Position             
                int myIndex = p.Controls.GetChildIndex((sender as Button));

                //Dragged to control to location of next button
                Button q = (Button)e.Data.GetData(typeof(Button));
                p.Controls.SetChildIndex(q, myIndex);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (IsLockedMode)
            {
                queryPanel.Controls.Clear();
            }
            else
            {
                queryBox.Text = "";
            }
        }

        private readonly Dictionary<string, int[]> rules = new Dictionary<string, int[]>()
        {
            //                               ;  ,  )  (  n  && st ! ||  i org dt tm us lc bs dc
            {";",                 new int[] {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}},
            {",",                 new int[] {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1}},
            {")",                 new int[] {1, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0}},
            {"(",                 new int[] {0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1}},
            {"num",               new int[] {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}},
            {"and",               new int[] {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1}},
            {"select",            new int[] {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1}},
            {"not",               new int[] {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1}},
            {"or",                new int[] {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1}},
            {"inwin",             new int[] {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}},
            {"hasorganization()", new int[] {0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0}},
            {"hasdate()",         new int[] {0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0}},
            {"hastime()",         new int[] {0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0}},
            {"hasusermentioned()",new int[] {0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0}},
            {"haslocation()",     new int[] {0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0}},
            {"byuser()",          new int[] {0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0}},
            {"haswordofdict()",   new int[] {0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0}},

        };

        private event EventHandler LastElementChanged;
        public event OpenEventHandler ImportUserDict;

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Text files (*.txt)|*.txt";
            
            d.FileOk += D_FileOk;
            d.ShowDialog();

        }

        private void D_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OpenEventArgs args = new OpenEventArgs();
            args.FilePath = (sender as OpenFileDialog).FileName;
            ImportUserDict?.Invoke(this, args);
            
        }

        public void UpdateUserDict(string key, List<string> value)
        {
            DeleteUserDictFromPreview(key);
            DisplayUserDict(key, value);
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

    internal class ButtonTag
    {
        public int Index { get; private set; }
        public string Name { get; private set; }
        public ButtonTag(int i, string n)
        {
            this.Index = i;
            this.Name = n;
        }

    }
}
