namespace Viewer.UI
{
    partial class TagWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagWindow));
            this.menuBackPanel = new System.Windows.Forms.Panel();
            this.splitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.tagsetView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.removeTagButton = new System.Windows.Forms.Button();
            this.addTagButton = new System.Windows.Forms.Button();
            this.InterfaceBackPanel = new System.Windows.Forms.Panel();
            this.tagTable = new BrightIdeasSoftware.FastObjectListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            this.situationView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.newSituationLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tagsetLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tagsetEditorButton = new System.Windows.Forms.ToolStripSplitButton();
            this.suggesterButton = new System.Windows.Forms.ToolStripSplitButton();
            this.filterButton = new System.Windows.Forms.ToolStripSplitButton();
            this.chooseTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taggedOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.ToolStripSplitButton();
            this.writeToDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagsetToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.editSituationButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.changeTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSituationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).BeginInit();
            this.splitContainerLeft.Panel1.SuspendLayout();
            this.splitContainerLeft.SuspendLayout();
            this.InterfaceBackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagTable)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.Panel1.SuspendLayout();
            this.splitContainerRight.Panel2.SuspendLayout();
            this.splitContainerRight.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBackPanel
            // 
            this.menuBackPanel.BackColor = System.Drawing.Color.Lavender;
            this.menuBackPanel.Controls.Add(this.splitContainerLeft);
            this.menuBackPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuBackPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuBackPanel.Location = new System.Drawing.Point(0, 0);
            this.menuBackPanel.Name = "menuBackPanel";
            this.menuBackPanel.Size = new System.Drawing.Size(209, 653);
            this.menuBackPanel.TabIndex = 1;
            // 
            // splitContainerLeft
            // 
            this.splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLeft.Name = "splitContainerLeft";
            this.splitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLeft.Panel1
            // 
            this.splitContainerLeft.Panel1.Controls.Add(this.tagsetView);
            this.splitContainerLeft.Size = new System.Drawing.Size(209, 653);
            this.splitContainerLeft.SplitterDistance = 279;
            this.splitContainerLeft.TabIndex = 0;
            // 
            // tagsetView
            // 
            this.tagsetView.BackColor = System.Drawing.Color.Lavender;
            this.tagsetView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagsetView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.tagsetView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsetView.FullRowSelect = true;
            this.tagsetView.HideSelection = false;
            this.tagsetView.Location = new System.Drawing.Point(0, 0);
            this.tagsetView.MultiSelect = false;
            this.tagsetView.Name = "tagsetView";
            this.tagsetView.Size = new System.Drawing.Size(209, 279);
            this.tagsetView.TabIndex = 4;
            this.tagsetView.UseCompatibleStateImageBehavior = false;
            this.tagsetView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tagset";
            this.columnHeader2.Width = 208;
            // 
            // dateView
            // 
            this.dateView.BackColor = System.Drawing.Color.Lavender;
            this.dateView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.dateView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateView.HideSelection = false;
            this.dateView.Location = new System.Drawing.Point(0, 0);
            this.dateView.Name = "dateView";
            this.dateView.Size = new System.Drawing.Size(176, 265);
            this.dateView.TabIndex = 0;
            this.dateView.UseCompatibleStateImageBehavior = false;
            this.dateView.View = System.Windows.Forms.View.Details;
            this.dateView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dateView_MouseDoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Dates";
            this.columnHeader3.Width = 169;
            // 
            // removeTagButton
            // 
            this.removeTagButton.BackColor = System.Drawing.Color.LightSalmon;
            this.removeTagButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeTagButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.removeTagButton.FlatAppearance.BorderSize = 0;
            this.removeTagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeTagButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeTagButton.Location = new System.Drawing.Point(3, 3);
            this.removeTagButton.Name = "removeTagButton";
            this.removeTagButton.Size = new System.Drawing.Size(533, 46);
            this.removeTagButton.TabIndex = 3;
            this.removeTagButton.Text = "Remove tag";
            this.removeTagButton.UseVisualStyleBackColor = false;
            this.removeTagButton.Click += new System.EventHandler(this.removeTagButton_Click);
            // 
            // addTagButton
            // 
            this.addTagButton.BackColor = System.Drawing.Color.MediumAquamarine;
            this.addTagButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addTagButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.addTagButton.FlatAppearance.BorderSize = 0;
            this.addTagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTagButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addTagButton.Location = new System.Drawing.Point(542, 3);
            this.addTagButton.Name = "addTagButton";
            this.addTagButton.Size = new System.Drawing.Size(534, 46);
            this.addTagButton.TabIndex = 2;
            this.addTagButton.Text = "Add tag";
            this.addTagButton.UseVisualStyleBackColor = false;
            this.addTagButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // InterfaceBackPanel
            // 
            this.InterfaceBackPanel.Controls.Add(this.tagTable);
            this.InterfaceBackPanel.Controls.Add(this.panel3);
            this.InterfaceBackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InterfaceBackPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InterfaceBackPanel.Location = new System.Drawing.Point(209, 52);
            this.InterfaceBackPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InterfaceBackPanel.Name = "InterfaceBackPanel";
            this.InterfaceBackPanel.Size = new System.Drawing.Size(1079, 601);
            this.InterfaceBackPanel.TabIndex = 1;
            // 
            // tagTable
            // 
            this.tagTable.CellEditUseWholeCell = false;
            this.tagTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagTable.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tagTable.FullRowSelect = true;
            this.tagTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.tagTable.HideSelection = false;
            this.tagTable.Location = new System.Drawing.Point(0, 0);
            this.tagTable.Name = "tagTable";
            this.tagTable.RowHeight = 52;
            this.tagTable.ShowGroups = false;
            this.tagTable.Size = new System.Drawing.Size(901, 601);
            this.tagTable.TabIndex = 25;
            this.tagTable.UseCompatibleStateImageBehavior = false;
            this.tagTable.View = System.Windows.Forms.View.Details;
            this.tagTable.VirtualMode = true;
            this.tagTable.Scroll += new System.EventHandler<System.Windows.Forms.ScrollEventArgs>(this.tagTable_Scroll);
            this.tagTable.SelectedIndexChanged += new System.EventHandler(this.tagTable_SelectedIndexChanged_1);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.splitContainerRight);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(901, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(178, 601);
            this.panel3.TabIndex = 17;
            // 
            // splitContainerRight
            // 
            this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRight.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRight.Name = "splitContainerRight";
            this.splitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRight.Panel1
            // 
            this.splitContainerRight.Panel1.Controls.Add(this.dateView);
            // 
            // splitContainerRight.Panel2
            // 
            this.splitContainerRight.Panel2.Controls.Add(this.situationView);
            this.splitContainerRight.Size = new System.Drawing.Size(176, 599);
            this.splitContainerRight.SplitterDistance = 265;
            this.splitContainerRight.TabIndex = 0;
            // 
            // situationView
            // 
            this.situationView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.situationView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.situationView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.situationView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.situationView.FullRowSelect = true;
            this.situationView.HideSelection = false;
            this.situationView.Location = new System.Drawing.Point(0, 0);
            this.situationView.MultiSelect = false;
            this.situationView.Name = "situationView";
            this.situationView.Size = new System.Drawing.Size(176, 330);
            this.situationView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.situationView.TabIndex = 16;
            this.situationView.UseCompatibleStateImageBehavior = false;
            this.situationView.View = System.Windows.Forms.View.Details;
            this.situationView.SelectedIndexChanged += new System.EventHandler(this.situationView_SelectedIndexChanged);
            this.situationView.DoubleClick += new System.EventHandler(this.situationView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Situations";
            this.columnHeader1.Width = 169;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.removeTagButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.addTagButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(209, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1079, 52);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.Lavender;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSituationLabel,
            this.tagsetLabel,
            this.tagsetEditorButton,
            this.suggesterButton,
            this.filterButton,
            this.saveButton,
            this.editSituationButton});
            this.statusStrip.Location = new System.Drawing.Point(0, 653);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip.Size = new System.Drawing.Size(1288, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // newSituationLabel
            // 
            this.newSituationLabel.Name = "newSituationLabel";
            this.newSituationLabel.Size = new System.Drawing.Size(67, 17);
            this.newSituationLabel.Text = "0 situations";
            this.newSituationLabel.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // tagsetLabel
            // 
            this.tagsetLabel.Name = "tagsetLabel";
            this.tagsetLabel.Size = new System.Drawing.Size(40, 17);
            this.tagsetLabel.Text = "Tagset";
            // 
            // tagsetEditorButton
            // 
            this.tagsetEditorButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tagsetEditorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tagsetEditorButton.Image = ((System.Drawing.Image)(resources.GetObject("tagsetEditorButton.Image")));
            this.tagsetEditorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tagsetEditorButton.Name = "tagsetEditorButton";
            this.tagsetEditorButton.Size = new System.Drawing.Size(90, 20);
            this.tagsetEditorButton.Text = "Tagset Editor";
            // 
            // suggesterButton
            // 
            this.suggesterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.suggesterButton.Image = ((System.Drawing.Image)(resources.GetObject("suggesterButton.Image")));
            this.suggesterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.suggesterButton.Name = "suggesterButton";
            this.suggesterButton.Size = new System.Drawing.Size(75, 20);
            this.suggesterButton.Text = "Suggester";
            this.suggesterButton.Click += new System.EventHandler(this.suggester_Click);
            // 
            // filterButton
            // 
            this.filterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.filterButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseTagToolStripMenuItem,
            this.taggedOnlyToolStripMenuItem});
            this.filterButton.Image = ((System.Drawing.Image)(resources.GetObject("filterButton.Image")));
            this.filterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(94, 20);
            this.filterButton.Text = "Filter by tag...";
            this.filterButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // chooseTagToolStripMenuItem
            // 
            this.chooseTagToolStripMenuItem.Name = "chooseTagToolStripMenuItem";
            this.chooseTagToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.chooseTagToolStripMenuItem.Text = "Choose tag...";
            // 
            // taggedOnlyToolStripMenuItem
            // 
            this.taggedOnlyToolStripMenuItem.Name = "taggedOnlyToolStripMenuItem";
            this.taggedOnlyToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.taggedOnlyToolStripMenuItem.Text = "Tagged only";
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.writeToDiskToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(56, 20);
            this.saveButton.Text = "Save...";
            this.saveButton.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            // 
            // writeToDiskToolStripMenuItem
            // 
            this.writeToDiskToolStripMenuItem.Name = "writeToDiskToolStripMenuItem";
            this.writeToDiskToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.writeToDiskToolStripMenuItem.Text = "Write to disk";
            this.writeToDiskToolStripMenuItem.Click += new System.EventHandler(this.writeToDiskToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveToolStripMenuItem.Text = "Save ";
            // 
            // tagsetToolTip
            // 
            this.tagsetToolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // editSituationButton
            // 
            this.editSituationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editSituationButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mergeToolStripMenuItem,
            this.deleteSituationToolStripMenuItem,
            this.changeTagToolStripMenuItem});
            this.editSituationButton.Image = ((System.Drawing.Image)(resources.GetObject("editSituationButton.Image")));
            this.editSituationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editSituationButton.Name = "editSituationButton";
            this.editSituationButton.Size = new System.Drawing.Size(90, 20);
            this.editSituationButton.Text = "Edit Situation";
            this.editSituationButton.Visible = false;
            // 
            // changeTagToolStripMenuItem
            // 
            this.changeTagToolStripMenuItem.Name = "changeTagToolStripMenuItem";
            this.changeTagToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changeTagToolStripMenuItem.Text = "Change tag";
            // 
            // deleteSituationToolStripMenuItem
            // 
            this.deleteSituationToolStripMenuItem.Name = "deleteSituationToolStripMenuItem";
            this.deleteSituationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteSituationToolStripMenuItem.Text = "Delete situation";
            // 
            // mergeToolStripMenuItem
            // 
            this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
            this.mergeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mergeToolStripMenuItem.Text = "Merge...";
            // 
            // TagWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1288, 675);
            this.Controls.Add(this.InterfaceBackPanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuBackPanel);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TagWindow";
            this.Text = "Tagger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TagWindow_FormClosing);
            this.menuBackPanel.ResumeLayout(false);
            this.splitContainerLeft.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).EndInit();
            this.splitContainerLeft.ResumeLayout(false);
            this.InterfaceBackPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tagTable)).EndInit();
            this.panel3.ResumeLayout(false);
            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel menuBackPanel;
        private System.Windows.Forms.Button removeTagButton;
        private System.Windows.Forms.Button addTagButton;
        private System.Windows.Forms.Panel InterfaceBackPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView tagsetView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private BrightIdeasSoftware.FastObjectListView tagTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView dateView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel newSituationLabel;
        private System.Windows.Forms.ToolStripSplitButton saveButton;
        private System.Windows.Forms.ToolStripMenuItem writeToDiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton filterButton;
        private System.Windows.Forms.ToolStripMenuItem chooseTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taggedOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton suggesterButton;
        private System.Windows.Forms.ToolStripSplitButton tagsetEditorButton;
        private System.Windows.Forms.ListView situationView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripStatusLabel tagsetLabel;
        private System.Windows.Forms.ToolTip tagsetToolTip;
        private System.Windows.Forms.SplitContainer splitContainerRight;
        private System.Windows.Forms.SplitContainer splitContainerLeft;
        private System.Windows.Forms.ToolStripDropDownButton editSituationButton;
        private System.Windows.Forms.ToolStripMenuItem mergeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSituationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeTagToolStripMenuItem;
    }
}