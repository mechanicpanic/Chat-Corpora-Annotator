using System;
using System.Windows.Forms;
using Viewer.Framework.Views;
using IndexEngine.Indexes;
using System.Linq;
using System.Collections.Generic;
using Viewer.Framework.MyEventArgs;

namespace Viewer.UI
{
    public partial class DictEditor : Form, IDictEditorView
    {
        private string curdict;
        public DictEditor()
        {
            InitializeComponent();
            wordList.AllColumns[0].AspectGetter = delegate (object x) { return x.ToString(); };
            dictList.AllColumns[0].AspectGetter = delegate (object x) { return x.ToString(); };
        }

        public event UserDictsEventHandler AddWord;
        public event UserDictsEventHandler DeleteWord;
        public event UserDictsEventHandler ClearDict;
        public event UserDictsEventHandler DeleteDict;
        public event UserDictsEventHandler DictDoubleClick;
        public event UserDictsEventHandler AddDict;
        public event OpenEventHandler ImportDict;
        public event EventHandler EditorClosing;
        public void CloseView()
        {
            this.Hide();
                       
        }

        public void LoadDict(List<string> dict)
        {
            wordList.SetObjects(dict);
            
            wordList.RebuildColumns();
        }

        public void LoadDicts(List<string> keys)
        {
            dictList.SetObjects(keys);
            
            dictList.RebuildColumns();
        }

        public void ShowView()
        {
            this.Show();
        }

        public void ClearDictPane()
        {
            wordList.Clear();
        }
        private void DictEditor_Load(object sender, EventArgs e)
        {
            
        }


        private void DictEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            EditorClosing?.Invoke(this, null);
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            CloseView();
        }

        private void importFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEventArgs args = new OpenEventArgs();
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Text files|*.txt";
            DialogResult res = d.ShowDialog();
            if (res == DialogResult.OK) {
                args.FilePath = d.FileName;
                ImportDict?.Invoke(this, args);
            }
        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dictTextBox.Text != "")
            {
                UserDictsEventArgs args = new UserDictsEventArgs();
                args.Name = dictTextBox.Text;
                AddDict?.Invoke(this, args);
                dictList.Update();
            }
        }

        private void deleteDictButton_Click(object sender, EventArgs e)
        {
            if(dictList.SelectedObjects.Count != 0)
            {
                UserDictsEventArgs args = new UserDictsEventArgs();
                args.Name = dictList.SelectedObjects[0].ToString();
                DeleteDict?.Invoke(this, args);
                dictList.RemoveObject(dictList.SelectedObjects[0]);
            }
        }

        private void clearDictButton_Click(object sender, EventArgs e)
        {
            if(dictList.SelectedObjects.Count != 0)
            {
                UserDictsEventArgs args = new UserDictsEventArgs();
                args.Name = dictList.SelectedObjects[0].ToString();
                ClearDict?.Invoke(this, args);
            }
        }

        public void UpdateDictView(string key)
        {
            dictList.UpdateObject(key);
        }

        public void UpdateWordView(string key)
        {
            wordList.UpdateObject(key);
        }

        private void dictList_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dictList_ItemActivate(object sender, EventArgs e)
        {
            var item = dictList.GetItem(dictList.SelectedIndex).RowObject;
            UserDictsEventArgs args = new UserDictsEventArgs();
            args.Name = item.ToString();
            curdict = args.Name;
            DictDoubleClick?.Invoke(this, args);
            
        }

        private void addWordButton_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(wordTextBox.Text))
            {
                UserDictsEventArgs args = new UserDictsEventArgs();
                args.Word = wordTextBox.Text;
                args.Name = curdict;
                AddWord?.Invoke(this, args);
            }
        }

        private void deleteWordButton_Click(object sender, EventArgs e)
        {
            if(wordList.SelectedObjects.Count > 0)
            {
                UserDictsEventArgs args = new UserDictsEventArgs();
                args.Name = curdict;
                args.Word = wordList.SelectedObjects[0].ToString();
                DeleteWord?.Invoke(this, args);
                
            }
        }

        public void UpdateWordViewList(List<string> keys)
        {
            wordList.SetObjects(keys);
        }

        public void UpdateDictViewList(List<string> keys)
        {
            dictList.SetObjects(keys);
        }
    }
}
