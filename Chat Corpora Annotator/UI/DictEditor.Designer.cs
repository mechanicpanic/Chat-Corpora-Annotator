
namespace Viewer.UI
{
    partial class DictEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DictEditor));
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.dictList = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.deleteDictButton = new System.Windows.Forms.ToolStripButton();
            this.clearDictButton = new System.Windows.Forms.ToolStripButton();
            this.addDictItem = new System.Windows.Forms.ToolStripSplitButton();
            this.importFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dictTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.wordList = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.deleteWordButton = new System.Windows.Forms.ToolStripButton();
            this.addWordButton = new System.Windows.Forms.ToolStripButton();
            this.wordTextBox = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dictList)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordList)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.dictList);
            this.mainSplit.Panel1.Controls.Add(this.toolStrip2);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.wordList);
            this.mainSplit.Panel2.Controls.Add(this.toolStrip1);
            this.mainSplit.Size = new System.Drawing.Size(732, 559);
            this.mainSplit.SplitterDistance = 209;
            this.mainSplit.SplitterWidth = 5;
            this.mainSplit.TabIndex = 0;
            // 
            // dictList
            // 
            this.dictList.AllColumns.Add(this.olvColumn1);
            this.dictList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
            this.dictList.Cursor = System.Windows.Forms.Cursors.Default;
            this.dictList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dictList.FullRowSelect = true;
            this.dictList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.dictList.HideSelection = false;
            this.dictList.Location = new System.Drawing.Point(0, 0);
            this.dictList.MultiSelect = false;
            this.dictList.Name = "dictList";
            this.dictList.ShowGroups = false;
            this.dictList.Size = new System.Drawing.Size(209, 534);
            this.dictList.TabIndex = 0;
            this.dictList.UseCompatibleStateImageBehavior = false;
            this.dictList.View = System.Windows.Forms.View.Details;
            this.dictList.VirtualMode = true;
            this.dictList.ItemActivate += new System.EventHandler(this.dictList_ItemActivate);
            this.dictList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dictList_MouseDoubleClick);
            // 
            // olvColumn1
            // 
            this.olvColumn1.Text = "Dictionaries";
            this.olvColumn1.Width = 224;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteDictButton,
            this.clearDictButton,
            this.addDictItem,
            this.dictTextBox});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 534);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(209, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // deleteDictButton
            // 
            this.deleteDictButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteDictButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteDictButton.Image")));
            this.deleteDictButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteDictButton.Name = "deleteDictButton";
            this.deleteDictButton.Size = new System.Drawing.Size(53, 22);
            this.deleteDictButton.Text = "Delete";
            this.deleteDictButton.Click += new System.EventHandler(this.deleteDictButton_Click);
            // 
            // clearDictButton
            // 
            this.clearDictButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearDictButton.Image = ((System.Drawing.Image)(resources.GetObject("clearDictButton.Image")));
            this.clearDictButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearDictButton.Name = "clearDictButton";
            this.clearDictButton.Size = new System.Drawing.Size(46, 22);
            this.clearDictButton.Text = "Clear";
            this.clearDictButton.Click += new System.EventHandler(this.clearDictButton_Click);
            // 
            // addDictItem
            // 
            this.addDictItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addDictItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFileToolStripMenuItem,
            this.createNewToolStripMenuItem});
            this.addDictItem.Image = ((System.Drawing.Image)(resources.GetObject("addDictItem.Image")));
            this.addDictItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addDictItem.Name = "addDictItem";
            this.addDictItem.Size = new System.Drawing.Size(72, 22);
            this.addDictItem.Text = "Add new";
            // 
            // importFileToolStripMenuItem
            // 
            this.importFileToolStripMenuItem.Name = "importFileToolStripMenuItem";
            this.importFileToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.importFileToolStripMenuItem.Text = "Import file";
            this.importFileToolStripMenuItem.Click += new System.EventHandler(this.importFileToolStripMenuItem_Click);
            // 
            // createNewToolStripMenuItem
            // 
            this.createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
            this.createNewToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.createNewToolStripMenuItem.Text = "Create new";
            this.createNewToolStripMenuItem.Click += new System.EventHandler(this.createNewToolStripMenuItem_Click);
            // 
            // dictTextBox
            // 
            this.dictTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dictTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dictTextBox.Name = "dictTextBox";
            this.dictTextBox.Size = new System.Drawing.Size(130, 23);
            // 
            // wordList
            // 
            this.wordList.AllColumns.Add(this.olvColumn2);
            this.wordList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn2});
            this.wordList.Cursor = System.Windows.Forms.Cursors.Default;
            this.wordList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wordList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.wordList.HideSelection = false;
            this.wordList.Location = new System.Drawing.Point(0, 0);
            this.wordList.Name = "wordList";
            this.wordList.ShowGroups = false;
            this.wordList.Size = new System.Drawing.Size(518, 534);
            this.wordList.TabIndex = 1;
            this.wordList.UseCompatibleStateImageBehavior = false;
            this.wordList.View = System.Windows.Forms.View.Details;
            this.wordList.VirtualMode = true;
            // 
            // olvColumn2
            // 
            this.olvColumn2.Text = "Words";
            this.olvColumn2.Width = 433;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteWordButton,
            this.addWordButton,
            this.wordTextBox});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 534);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(518, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // deleteWordButton
            // 
            this.deleteWordButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.deleteWordButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteWordButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteWordButton.Image")));
            this.deleteWordButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteWordButton.Name = "deleteWordButton";
            this.deleteWordButton.Size = new System.Drawing.Size(53, 22);
            this.deleteWordButton.Text = "Delete";
            this.deleteWordButton.Click += new System.EventHandler(this.deleteWordButton_Click);
            // 
            // addWordButton
            // 
            this.addWordButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.addWordButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addWordButton.Image = ((System.Drawing.Image)(resources.GetObject("addWordButton.Image")));
            this.addWordButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addWordButton.Name = "addWordButton";
            this.addWordButton.Size = new System.Drawing.Size(32, 22);
            this.addWordButton.Text = "Add";
            this.addWordButton.Click += new System.EventHandler(this.addWordButton_Click);
            // 
            // wordTextBox
            // 
            this.wordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wordTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.wordTextBox.Name = "wordTextBox";
            this.wordTextBox.Size = new System.Drawing.Size(280, 25);
            // 
            // DictEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 559);
            this.Controls.Add(this.mainSplit);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DictEditor";
            this.Text = "Dictionary Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DictEditor_FormClosing);
            this.Load += new System.EventHandler(this.DictEditor_Load);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel1.PerformLayout();
            this.mainSplit.Panel2.ResumeLayout(false);
            this.mainSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dictList)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordList)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplit;
        private BrightIdeasSoftware.FastObjectListView dictList;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.FastObjectListView wordList;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton deleteDictButton;
        private System.Windows.Forms.ToolStripButton clearDictButton;
        private System.Windows.Forms.ToolStripSplitButton addDictItem;
        private System.Windows.Forms.ToolStripMenuItem importFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox dictTextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton deleteWordButton;
        private System.Windows.Forms.ToolStripButton addWordButton;
        private System.Windows.Forms.ToolStripTextBox wordTextBox;
    }
}