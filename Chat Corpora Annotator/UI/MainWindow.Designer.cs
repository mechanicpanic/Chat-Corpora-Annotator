namespace Viewer
{
    partial class MainWindow
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
            System.Windows.Forms.TabControl tabControl1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Chat = new System.Windows.Forms.TabPage();
            this.chatTable = new BrightIdeasSoftware.FastObjectListView();
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            this.dateView = new System.Windows.Forms.ListView();
            this.Days = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fastSituationView = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.removeTagButton = new System.Windows.Forms.Button();
            this.addTagButton = new System.Windows.Forms.Button();
            this.Statistics = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.statisticsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Concordance = new System.Windows.Forms.TabPage();
            this.concordancePanel = new System.Windows.Forms.Panel();
            this.concordancerButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ngramPanel = new System.Windows.Forms.Panel();
            this.ngramButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.keywordPanel = new System.Windows.Forms.Panel();
            this.keywordButton = new System.Windows.Forms.Button();
            this.csvDialog = new System.Windows.Forms.OpenFileDialog();
            this.indexDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.findButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.datesPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.finishDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateToggle = new System.Windows.Forms.CheckBox();
            this.userPanel = new System.Windows.Forms.Panel();
            this.userList = new System.Windows.Forms.ListView();
            this.Users = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userToggle = new System.Windows.Forms.CheckBox();
            this.queryPanel = new System.Windows.Forms.Panel();
            this.searchBox = new System.Windows.Forms.RichTextBox();
            this.queryButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCorpusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCorpusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heatmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.highlightTextRenderer1 = new BrightIdeasSoftware.HighlightTextRenderer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.messageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tagsetLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.newSituationLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.filterButton = new System.Windows.Forms.ToolStripSplitButton();
            this.chooseTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taggedOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.ToolStripSplitButton();
            this.writeToDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suggesterButton = new System.Windows.Forms.ToolStripSplitButton();
            this.tagsetEditorButton = new System.Windows.Forms.ToolStripSplitButton();
            this.editSituationButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSituationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tagsetView = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            tabControl1 = new System.Windows.Forms.TabControl();
            tabControl1.SuspendLayout();
            this.Chat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chatTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.Panel1.SuspendLayout();
            this.splitContainerRight.Panel2.SuspendLayout();
            this.splitContainerRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastSituationView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.Statistics.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.Concordance.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.keywordPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.datesPanel.SuspendLayout();
            this.userPanel.SuspendLayout();
            this.queryPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tabControl1.Controls.Add(this.Chat);
            tabControl1.Controls.Add(this.Statistics);
            tabControl1.Controls.Add(this.Concordance);
            tabControl1.Controls.Add(this.tabPage1);
            tabControl1.Controls.Add(this.tabPage2);
            tabControl1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            tabControl1.Location = new System.Drawing.Point(227, 35);
            tabControl1.Margin = new System.Windows.Forms.Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new System.Drawing.Point(0, 0);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1087, 752);
            tabControl1.TabIndex = 17;
            tabControl1.TabStop = false;
            // 
            // Chat
            // 
            this.Chat.BackColor = System.Drawing.Color.Lavender;
            this.Chat.Controls.Add(this.chatTable);
            this.Chat.Controls.Add(this.splitContainerRight);
            this.Chat.Controls.Add(this.tableLayoutPanel1);
            this.Chat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Chat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Chat.Location = new System.Drawing.Point(4, 28);
            this.Chat.Margin = new System.Windows.Forms.Padding(2);
            this.Chat.Name = "Chat";
            this.Chat.Padding = new System.Windows.Forms.Padding(2);
            this.Chat.Size = new System.Drawing.Size(1079, 720);
            this.Chat.TabIndex = 0;
            this.Chat.Text = "Chat";
            this.Chat.UseVisualStyleBackColor = true;
            // 
            // chatTable
            // 
            this.chatTable.AllowColumnReorder = true;
            this.chatTable.AutoArrange = false;
            this.chatTable.BackColor = System.Drawing.Color.White;
            this.chatTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatTable.CellEditUseWholeCell = false;
            this.chatTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatTable.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chatTable.FullRowSelect = true;
            this.chatTable.HeaderUsesThemes = true;
            this.chatTable.HideSelection = false;
            this.chatTable.Location = new System.Drawing.Point(2, 54);
            this.chatTable.Margin = new System.Windows.Forms.Padding(2);
            this.chatTable.Name = "chatTable";
            this.chatTable.RowHeight = 52;
            this.chatTable.ShowGroups = false;
            this.chatTable.Size = new System.Drawing.Size(915, 664);
            this.chatTable.TabIndex = 9;
            this.chatTable.TintSortColumn = true;
            this.chatTable.UseCellFormatEvents = true;
            this.chatTable.UseCompatibleStateImageBehavior = false;
            this.chatTable.UseFiltering = true;
            this.chatTable.View = System.Windows.Forms.View.Details;
            this.chatTable.VirtualMode = true;
            this.chatTable.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.chatTable_CellRightClick);
            this.chatTable.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.ChatTable_FormatCell);
            this.chatTable.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.ChatTable_FormatRow);
            this.chatTable.Scroll += new System.EventHandler<System.Windows.Forms.ScrollEventArgs>(this.chatTable_Scroll);
            // 
            // splitContainerRight
            // 
            this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainerRight.Location = new System.Drawing.Point(917, 54);
            this.splitContainerRight.Name = "splitContainerRight";
            this.splitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRight.Panel1
            // 
            this.splitContainerRight.Panel1.Controls.Add(this.dateView);
            this.splitContainerRight.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainerRight.Panel2
            // 
            this.splitContainerRight.Panel2.Controls.Add(this.fastSituationView);
            this.splitContainerRight.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerRight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerRight.Size = new System.Drawing.Size(160, 664);
            this.splitContainerRight.SplitterDistance = 332;
            this.splitContainerRight.SplitterWidth = 20;
            this.splitContainerRight.TabIndex = 19;
            this.splitContainerRight.Visible = false;
            // 
            // dateView
            // 
            this.dateView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dateView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dateView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Days});
            this.dateView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateView.FullRowSelect = true;
            this.dateView.HideSelection = false;
            this.dateView.Location = new System.Drawing.Point(0, 0);
            this.dateView.Margin = new System.Windows.Forms.Padding(2);
            this.dateView.Name = "dateView";
            this.dateView.ShowItemToolTips = true;
            this.dateView.Size = new System.Drawing.Size(160, 332);
            this.dateView.TabIndex = 18;
            this.dateView.UseCompatibleStateImageBehavior = false;
            this.dateView.View = System.Windows.Forms.View.Details;
            this.dateView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.dateView_ColumnWidthChanging);
            this.dateView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dateView_MouseDoubleClick);
            // 
            // Days
            // 
            this.Days.Text = "Active dates";
            this.Days.Width = 155;
            // 
            // fastSituationView
            // 
            this.fastSituationView.AllColumns.Add(this.olvColumn1);
            this.fastSituationView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
            this.fastSituationView.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastSituationView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastSituationView.HideSelection = false;
            this.fastSituationView.Location = new System.Drawing.Point(0, 0);
            this.fastSituationView.Name = "fastSituationView";
            this.fastSituationView.ShowGroups = false;
            this.fastSituationView.Size = new System.Drawing.Size(160, 312);
            this.fastSituationView.TabIndex = 0;
            this.fastSituationView.UseCompatibleStateImageBehavior = false;
            this.fastSituationView.UseHotItem = true;
            this.fastSituationView.View = System.Windows.Forms.View.Details;
            this.fastSituationView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.situationView_ColumnWidthChanging);
            this.fastSituationView.DoubleClick += new System.EventHandler(this.situationView_DoubleClick);
            // 
            // olvColumn1
            // 
            this.olvColumn1.Text = "Situations";
            this.olvColumn1.Width = 154;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.removeTagButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.addTagButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1075, 52);
            this.tableLayoutPanel1.TabIndex = 13;
            this.tableLayoutPanel1.Visible = false;
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
            this.removeTagButton.Size = new System.Drawing.Size(531, 46);
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
            this.addTagButton.Location = new System.Drawing.Point(540, 3);
            this.addTagButton.Name = "addTagButton";
            this.addTagButton.Size = new System.Drawing.Size(532, 46);
            this.addTagButton.TabIndex = 2;
            this.addTagButton.Text = "Add tag";
            this.addTagButton.UseVisualStyleBackColor = false;
            this.addTagButton.Click += new System.EventHandler(this.addTagButton_Click);
            // 
            // Statistics
            // 
            this.Statistics.Controls.Add(this.panel2);
            this.Statistics.Controls.Add(this.richTextBox1);
            this.Statistics.Location = new System.Drawing.Point(4, 28);
            this.Statistics.Margin = new System.Windows.Forms.Padding(2);
            this.Statistics.Name = "Statistics";
            this.Statistics.Padding = new System.Windows.Forms.Padding(2);
            this.Statistics.Size = new System.Drawing.Size(1079, 720);
            this.Statistics.TabIndex = 3;
            this.Statistics.Text = "Statistics";
            this.Statistics.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1075, 716);
            this.panel2.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1075, 716);
            this.panel4.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.statisticsButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.statisticsListView, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.listView1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 674F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1075, 716);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(539, 676);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(534, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Calculate statistics";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // statisticsButton
            // 
            this.statisticsButton.BackColor = System.Drawing.Color.Lavender;
            this.statisticsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statisticsButton.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.statisticsButton.FlatAppearance.BorderSize = 0;
            this.statisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticsButton.Location = new System.Drawing.Point(2, 676);
            this.statisticsButton.Margin = new System.Windows.Forms.Padding(2);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(533, 38);
            this.statisticsButton.TabIndex = 3;
            this.statisticsButton.Text = "Calculate statistics";
            this.statisticsButton.UseVisualStyleBackColor = false;
            this.statisticsButton.Click += new System.EventHandler(this.statistics_Click);
            // 
            // statisticsListView
            // 
            this.statisticsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.statisticsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statisticsListView.HideSelection = false;
            this.statisticsListView.Location = new System.Drawing.Point(2, 2);
            this.statisticsListView.Margin = new System.Windows.Forms.Padding(2);
            this.statisticsListView.Name = "statisticsListView";
            this.statisticsListView.Size = new System.Drawing.Size(533, 670);
            this.statisticsListView.TabIndex = 2;
            this.statisticsListView.UseCompatibleStateImageBehavior = false;
            this.statisticsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 186;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 330;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(539, 2);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(534, 670);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Value";
            this.columnHeader6.Width = 219;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1075, 716);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Concordance
            // 
            this.Concordance.Controls.Add(this.concordancePanel);
            this.Concordance.Controls.Add(this.concordancerButton);
            this.Concordance.Location = new System.Drawing.Point(4, 28);
            this.Concordance.Margin = new System.Windows.Forms.Padding(2);
            this.Concordance.Name = "Concordance";
            this.Concordance.Padding = new System.Windows.Forms.Padding(2);
            this.Concordance.Size = new System.Drawing.Size(1079, 720);
            this.Concordance.TabIndex = 4;
            this.Concordance.Text = "Concordance";
            this.Concordance.UseVisualStyleBackColor = true;
            // 
            // concordancePanel
            // 
            this.concordancePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.concordancePanel.Location = new System.Drawing.Point(2, 2);
            this.concordancePanel.Margin = new System.Windows.Forms.Padding(2);
            this.concordancePanel.Name = "concordancePanel";
            this.concordancePanel.Size = new System.Drawing.Size(1075, 674);
            this.concordancePanel.TabIndex = 3;
            // 
            // concordancerButton
            // 
            this.concordancerButton.BackColor = System.Drawing.Color.Lavender;
            this.concordancerButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.concordancerButton.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.concordancerButton.FlatAppearance.BorderSize = 0;
            this.concordancerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.concordancerButton.Location = new System.Drawing.Point(2, 676);
            this.concordancerButton.Margin = new System.Windows.Forms.Padding(2);
            this.concordancerButton.Name = "concordancerButton";
            this.concordancerButton.Size = new System.Drawing.Size(1075, 42);
            this.concordancerButton.TabIndex = 2;
            this.concordancerButton.Text = "Load concordancer";
            this.concordancerButton.UseVisualStyleBackColor = false;
            this.concordancerButton.Click += new System.EventHandler(this.concordance_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ngramPanel);
            this.tabPage1.Controls.Add(this.ngramButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1079, 720);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "N-gram Search";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ngramPanel
            // 
            this.ngramPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ngramPanel.Location = new System.Drawing.Point(0, 0);
            this.ngramPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ngramPanel.Name = "ngramPanel";
            this.ngramPanel.Size = new System.Drawing.Size(1079, 678);
            this.ngramPanel.TabIndex = 4;
            // 
            // ngramButton
            // 
            this.ngramButton.BackColor = System.Drawing.Color.Lavender;
            this.ngramButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ngramButton.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.ngramButton.FlatAppearance.BorderSize = 0;
            this.ngramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ngramButton.Location = new System.Drawing.Point(0, 678);
            this.ngramButton.Margin = new System.Windows.Forms.Padding(2);
            this.ngramButton.Name = "ngramButton";
            this.ngramButton.Size = new System.Drawing.Size(1079, 42);
            this.ngramButton.TabIndex = 3;
            this.ngramButton.Text = "Load ngrammer";
            this.ngramButton.UseVisualStyleBackColor = false;
            this.ngramButton.Click += new System.EventHandler(this.ngram_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.keywordPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1079, 720);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "Keyword Analysis";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // keywordPanel
            // 
            this.keywordPanel.Controls.Add(this.keywordButton);
            this.keywordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keywordPanel.Location = new System.Drawing.Point(0, 0);
            this.keywordPanel.Margin = new System.Windows.Forms.Padding(2);
            this.keywordPanel.Name = "keywordPanel";
            this.keywordPanel.Size = new System.Drawing.Size(1079, 720);
            this.keywordPanel.TabIndex = 1;
            // 
            // keywordButton
            // 
            this.keywordButton.BackColor = System.Drawing.Color.Lavender;
            this.keywordButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.keywordButton.FlatAppearance.BorderSize = 0;
            this.keywordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keywordButton.Location = new System.Drawing.Point(0, 676);
            this.keywordButton.Margin = new System.Windows.Forms.Padding(2);
            this.keywordButton.Name = "keywordButton";
            this.keywordButton.Size = new System.Drawing.Size(1079, 44);
            this.keywordButton.TabIndex = 0;
            this.keywordButton.Text = "Load keyworder";
            this.keywordButton.UseVisualStyleBackColor = false;
            this.keywordButton.Click += new System.EventHandler(this.keyword_Click);
            // 
            // csvDialog
            // 
            this.csvDialog.FileName = "csvDialog";
            this.csvDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.csvDialog_FileOk);
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.findButton);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.datesPanel);
            this.searchPanel.Controls.Add(this.dateToggle);
            this.searchPanel.Controls.Add(this.userPanel);
            this.searchPanel.Controls.Add(this.userToggle);
            this.searchPanel.Controls.Add(this.queryPanel);
            this.searchPanel.Controls.Add(this.queryButton);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(228, 493);
            this.searchPanel.TabIndex = 16;
            // 
            // findButton
            // 
            this.findButton.BackColor = System.Drawing.Color.Lavender;
            this.findButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.findButton.Enabled = false;
            this.findButton.FlatAppearance.BorderSize = 0;
            this.findButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.findButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findButton.Location = new System.Drawing.Point(0, 455);
            this.findButton.Margin = new System.Windows.Forms.Padding(2);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(228, 32);
            this.findButton.TabIndex = 15;
            this.findButton.Text = "Find";
            this.findButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.findButton.UseVisualStyleBackColor = false;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Lavender;
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.clearButton.Enabled = false;
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.Location = new System.Drawing.Point(0, 423);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(228, 32);
            this.clearButton.TabIndex = 26;
            this.clearButton.Text = "Clear";
            this.clearButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // datesPanel
            // 
            this.datesPanel.ColumnCount = 2;
            this.datesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.91909F));
            this.datesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.08091F));
            this.datesPanel.Controls.Add(this.label2);
            this.datesPanel.Controls.Add(this.startDate, 1, 0);
            this.datesPanel.Controls.Add(this.finishDate, 1, 1);
            this.datesPanel.Controls.Add(this.label1);
            this.datesPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.datesPanel.Location = new System.Drawing.Point(0, 364);
            this.datesPanel.Margin = new System.Windows.Forms.Padding(2);
            this.datesPanel.Name = "datesPanel";
            this.datesPanel.RowCount = 2;
            this.datesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.datesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.datesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.datesPanel.Size = new System.Drawing.Size(228, 59);
            this.datesPanel.TabIndex = 23;
            this.datesPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.MinimumSize = new System.Drawing.Size(45, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 29);
            this.label2.TabIndex = 20;
            this.label2.Text = "from";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startDate
            // 
            this.startDate.Checked = false;
            this.startDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(58, 2);
            this.startDate.Margin = new System.Windows.Forms.Padding(2);
            this.startDate.MaxDate = new System.DateTime(9998, 1, 1, 0, 0, 0, 0);
            this.startDate.Name = "startDate";
            this.startDate.ShowCheckBox = true;
            this.startDate.Size = new System.Drawing.Size(168, 25);
            this.startDate.TabIndex = 17;
            this.startDate.Value = new System.DateTime(2020, 4, 28, 0, 0, 0, 0);
            // 
            // finishDate
            // 
            this.finishDate.Checked = false;
            this.finishDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.finishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.finishDate.Location = new System.Drawing.Point(58, 31);
            this.finishDate.Margin = new System.Windows.Forms.Padding(2);
            this.finishDate.Name = "finishDate";
            this.finishDate.ShowCheckBox = true;
            this.finishDate.Size = new System.Drawing.Size(168, 25);
            this.finishDate.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(2, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.MinimumSize = new System.Drawing.Size(30, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 29);
            this.label1.TabIndex = 19;
            this.label1.Text = "to";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateToggle
            // 
            this.dateToggle.Appearance = System.Windows.Forms.Appearance.Button;
            this.dateToggle.AutoSize = true;
            this.dateToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateToggle.Enabled = false;
            this.dateToggle.FlatAppearance.BorderSize = 0;
            this.dateToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dateToggle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateToggle.Location = new System.Drawing.Point(0, 332);
            this.dateToggle.Margin = new System.Windows.Forms.Padding(2);
            this.dateToggle.MinimumSize = new System.Drawing.Size(0, 32);
            this.dateToggle.Name = "dateToggle";
            this.dateToggle.Size = new System.Drawing.Size(228, 32);
            this.dateToggle.TabIndex = 28;
            this.dateToggle.Text = "Select Dates Toggle";
            this.dateToggle.UseVisualStyleBackColor = true;
            this.dateToggle.CheckedChanged += new System.EventHandler(this.datesToggle_CheckedChanged);
            // 
            // userPanel
            // 
            this.userPanel.Controls.Add(this.userList);
            this.userPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.userPanel.Location = new System.Drawing.Point(0, 103);
            this.userPanel.Margin = new System.Windows.Forms.Padding(2);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(228, 229);
            this.userPanel.TabIndex = 21;
            this.userPanel.Visible = false;
            // 
            // userList
            // 
            this.userList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userList.CheckBoxes = true;
            this.userList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Users});
            this.userList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userList.FullRowSelect = true;
            this.userList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.userList.HideSelection = false;
            this.userList.Location = new System.Drawing.Point(0, 0);
            this.userList.Margin = new System.Windows.Forms.Padding(2);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(228, 229);
            this.userList.TabIndex = 16;
            this.userList.UseCompatibleStateImageBehavior = false;
            this.userList.View = System.Windows.Forms.View.Details;
            // 
            // Users
            // 
            this.Users.Text = "Users";
            this.Users.Width = 213;
            // 
            // userToggle
            // 
            this.userToggle.Appearance = System.Windows.Forms.Appearance.Button;
            this.userToggle.AutoSize = true;
            this.userToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.userToggle.Enabled = false;
            this.userToggle.FlatAppearance.BorderSize = 0;
            this.userToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userToggle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userToggle.Location = new System.Drawing.Point(0, 71);
            this.userToggle.Margin = new System.Windows.Forms.Padding(2);
            this.userToggle.MinimumSize = new System.Drawing.Size(0, 32);
            this.userToggle.Name = "userToggle";
            this.userToggle.Size = new System.Drawing.Size(228, 32);
            this.userToggle.TabIndex = 27;
            this.userToggle.Text = "Select Users Toggle";
            this.userToggle.UseVisualStyleBackColor = true;
            this.userToggle.CheckedChanged += new System.EventHandler(this.userToggle_CheckedChanged);
            // 
            // queryPanel
            // 
            this.queryPanel.Controls.Add(this.searchBox);
            this.queryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.queryPanel.Location = new System.Drawing.Point(0, 32);
            this.queryPanel.Margin = new System.Windows.Forms.Padding(2);
            this.queryPanel.Name = "queryPanel";
            this.queryPanel.Size = new System.Drawing.Size(228, 39);
            this.queryPanel.TabIndex = 20;
            this.queryPanel.Visible = false;
            // 
            // searchBox
            // 
            this.searchBox.AutoWordSelection = true;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBox.Font = new System.Drawing.Font("Segoe UI", 10.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchBox.Location = new System.Drawing.Point(0, 0);
            this.searchBox.Margin = new System.Windows.Forms.Padding(2);
            this.searchBox.Multiline = false;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(228, 40);
            this.searchBox.TabIndex = 15;
            this.searchBox.Text = "Enter query...";
            this.searchBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseClick);
            // 
            // queryButton
            // 
            this.queryButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.queryButton.Enabled = false;
            this.queryButton.FlatAppearance.BorderSize = 0;
            this.queryButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.queryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.queryButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.queryButton.Location = new System.Drawing.Point(0, 0);
            this.queryButton.Margin = new System.Windows.Forms.Padding(2);
            this.queryButton.MinimumSize = new System.Drawing.Size(0, 32);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(228, 32);
            this.queryButton.TabIndex = 19;
            this.queryButton.Text = "Query";
            this.queryButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.vizToolStripMenuItem,
            this.extractToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MinimumSize = new System.Drawing.Size(0, 22);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1314, 22);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadCorpusToolStripMenuItem,
            this.openCorpusToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 18);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // loadCorpusToolStripMenuItem
            // 
            this.loadCorpusToolStripMenuItem.Name = "loadCorpusToolStripMenuItem";
            this.loadCorpusToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.loadCorpusToolStripMenuItem.Text = "Index new file";
            this.loadCorpusToolStripMenuItem.Click += new System.EventHandler(this.loadCorpusToolStripMenuItem_Click);
            // 
            // openCorpusToolStripMenuItem
            // 
            this.openCorpusToolStripMenuItem.Name = "openCorpusToolStripMenuItem";
            this.openCorpusToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.openCorpusToolStripMenuItem.Text = "Open corpus";
            this.openCorpusToolStripMenuItem.Click += new System.EventHandler(this.openCorpusToolStripMenuItem_Click);
            // 
            // vizToolStripMenuItem
            // 
            this.vizToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plotToolStripMenuItem,
            this.heatmapToolStripMenuItem});
            this.vizToolStripMenuItem.Name = "vizToolStripMenuItem";
            this.vizToolStripMenuItem.Size = new System.Drawing.Size(64, 18);
            this.vizToolStripMenuItem.Text = "Visualize";
            // 
            // plotToolStripMenuItem
            // 
            this.plotToolStripMenuItem.Name = "plotToolStripMenuItem";
            this.plotToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.plotToolStripMenuItem.Text = "Plot";
            this.plotToolStripMenuItem.Click += new System.EventHandler(this.plotToolStripMenuItem_Click);
            // 
            // heatmapToolStripMenuItem
            // 
            this.heatmapToolStripMenuItem.Name = "heatmapToolStripMenuItem";
            this.heatmapToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.heatmapToolStripMenuItem.Text = "Heatmap";
            this.heatmapToolStripMenuItem.Click += new System.EventHandler(this.heatmapToolStripMenuItem_Click);
            // 
            // extractToolStripMenuItem1
            // 
            this.extractToolStripMenuItem1.Name = "extractToolStripMenuItem1";
            this.extractToolStripMenuItem1.Size = new System.Drawing.Size(55, 18);
            this.extractToolStripMenuItem1.Text = "Extract";
            this.extractToolStripMenuItem1.Click += new System.EventHandler(this.extractToolStripMenuItem_Click);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(547, 175);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Lavender;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageLabel,
            this.tagsetLabel,
            this.newSituationLabel,
            this.filterButton,
            this.saveButton,
            this.suggesterButton,
            this.tagsetEditorButton,
            this.editSituationButton});
            this.statusStrip1.Location = new System.Drawing.Point(0, 789);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1314, 22);
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // messageLabel
            // 
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(66, 17);
            this.messageLabel.Text = "Not loaded";
            // 
            // tagsetLabel
            // 
            this.tagsetLabel.Name = "tagsetLabel";
            this.tagsetLabel.Size = new System.Drawing.Size(58, 17);
            this.tagsetLabel.Text = "No tagset";
            // 
            // newSituationLabel
            // 
            this.newSituationLabel.Name = "newSituationLabel";
            this.newSituationLabel.Size = new System.Drawing.Size(67, 17);
            this.newSituationLabel.Text = "0 situations";
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
            this.filterButton.Visible = false;
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
            this.saveButton.Visible = false;
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
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // suggesterButton
            // 
            this.suggesterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.suggesterButton.Image = ((System.Drawing.Image)(resources.GetObject("suggesterButton.Image")));
            this.suggesterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.suggesterButton.Name = "suggesterButton";
            this.suggesterButton.Size = new System.Drawing.Size(75, 20);
            this.suggesterButton.Text = "Suggester";
            this.suggesterButton.Visible = false;
            this.suggesterButton.Click += new System.EventHandler(this.suggester_Click);
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
            this.tagsetEditorButton.Visible = false;
            this.tagsetEditorButton.ButtonClick += new System.EventHandler(this.tagsetEditorButton_ButtonClick);
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
            // mergeToolStripMenuItem
            // 
            this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
            this.mergeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.mergeToolStripMenuItem.Text = "Merge...";
            // 
            // deleteSituationToolStripMenuItem
            // 
            this.deleteSituationToolStripMenuItem.Name = "deleteSituationToolStripMenuItem";
            this.deleteSituationToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.deleteSituationToolStripMenuItem.Text = "Delete situation";
            // 
            // changeTagToolStripMenuItem
            // 
            this.changeTagToolStripMenuItem.Name = "changeTagToolStripMenuItem";
            this.changeTagToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.changeTagToolStripMenuItem.Text = "Change tag";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer1.Location = new System.Drawing.Point(0, 22);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.searchPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tagsetView);
            this.splitContainer1.Size = new System.Drawing.Size(228, 767);
            this.splitContainer1.SplitterDistance = 493;
            this.splitContainer1.TabIndex = 29;
            // 
            // tagsetView
            // 
            this.tagsetView.BackColor = System.Drawing.Color.Lavender;
            this.tagsetView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tagsetView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.tagsetView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsetView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tagsetView.FullRowSelect = true;
            this.tagsetView.HideSelection = false;
            this.tagsetView.Location = new System.Drawing.Point(0, 0);
            this.tagsetView.MultiSelect = false;
            this.tagsetView.Name = "tagsetView";
            this.tagsetView.Size = new System.Drawing.Size(228, 270);
            this.tagsetView.TabIndex = 5;
            this.tagsetView.UseCompatibleStateImageBehavior = false;
            this.tagsetView.View = System.Windows.Forms.View.Details;
            this.tagsetView.Visible = false;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tagset";
            this.columnHeader4.Width = 223;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1314, 811);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1330, 850);
            this.Name = "MainWindow";
            this.Text = "Chat Corpora Annotator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            tabControl1.ResumeLayout(false);
            this.Chat.ResumeLayout(false);
            this.Chat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chatTable)).EndInit();
            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastSituationView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Statistics.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.Concordance.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.keywordPanel.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.datesPanel.ResumeLayout(false);
            this.datesPanel.PerformLayout();
            this.userPanel.ResumeLayout(false);
            this.queryPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog csvDialog;
        private System.Windows.Forms.FolderBrowserDialog indexDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heatmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCorpusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCorpusToolStripMenuItem;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.RichTextBox searchBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.TableLayoutPanel datesPanel;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.DateTimePicker finishDate;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Panel queryPanel;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.TabPage Chat;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.TabPage Statistics;
        private System.Windows.Forms.TabPage Concordance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.CheckBox dateToggle;
        private System.Windows.Forms.CheckBox userToggle;
        private System.Windows.Forms.ListView userList;
        private System.Windows.Forms.ColumnHeader Users;
        private BrightIdeasSoftware.HighlightTextRenderer highlightTextRenderer1;
        private System.Windows.Forms.Button concordancerButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button ngramButton;
        private System.Windows.Forms.Panel concordancePanel;
        private System.Windows.Forms.Panel ngramPanel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button keywordButton;
        private System.Windows.Forms.Panel keywordPanel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel messageLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button removeTagButton;
        private System.Windows.Forms.Button addTagButton;
        private System.Windows.Forms.ToolStripStatusLabel tagsetLabel;
        private System.Windows.Forms.ToolStripStatusLabel newSituationLabel;
        private System.Windows.Forms.ToolStripSplitButton filterButton;
        private System.Windows.Forms.ToolStripMenuItem chooseTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taggedOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton saveButton;
        private System.Windows.Forms.ToolStripMenuItem writeToDiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton suggesterButton;
        private System.Windows.Forms.ToolStripSplitButton tagsetEditorButton;
        private System.Windows.Forms.ToolStripDropDownButton editSituationButton;
        private System.Windows.Forms.ToolStripMenuItem mergeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSituationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeTagToolStripMenuItem;
        private BrightIdeasSoftware.FastObjectListView chatTable;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainerRight;
        private System.Windows.Forms.ListView tagsetView;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.ListView statisticsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem1;
        private BrightIdeasSoftware.ObjectListView fastSituationView;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private System.Windows.Forms.ListView dateView;
        private System.Windows.Forms.ColumnHeader Days;
    }
}

