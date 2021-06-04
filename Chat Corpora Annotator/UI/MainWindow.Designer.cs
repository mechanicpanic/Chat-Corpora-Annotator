

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
            System.Windows.Forms.TabControl mainTabControl;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Chat = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chatTable = new BrightIdeasSoftware.FastObjectListView();
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            this.dateView = new System.Windows.Forms.ListView();
            this.Days = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fastSituationView = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
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
            this.corpusStatisticsView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Concordance = new System.Windows.Forms.TabPage();
            this.concordancePanel = new System.Windows.Forms.Panel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.concordancerButton = new System.Windows.Forms.Button();
            this.charSelectionBox = new System.Windows.Forms.ComboBox();
            this.concordanceBox = new System.Windows.Forms.TextBox();
            this.concordanceView = new EasyScintilla.SimpleEditor();
            this.ngramPage = new System.Windows.Forms.TabPage();
            this.ngramPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ngramIndexButton = new System.Windows.Forms.Button();
            this.ngramSearchButton = new System.Windows.Forms.Button();
            this.ngramSearchBox = new System.Windows.Forms.TextBox();
            this.ngramTabs = new System.Windows.Forms.TabControl();
            this.bi = new System.Windows.Forms.TabPage();
            this.bigramView = new BrightIdeasSoftware.FastObjectListView();
            this.phrase2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.count2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.trigramPage = new System.Windows.Forms.TabPage();
            this.trigramView = new BrightIdeasSoftware.FastObjectListView();
            this.phrase3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.count3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.four = new System.Windows.Forms.TabPage();
            this.fourgramView = new BrightIdeasSoftware.FastObjectListView();
            this.phrase4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.count4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.five = new System.Windows.Forms.TabPage();
            this.fivegramView = new BrightIdeasSoftware.FastObjectListView();
            this.phrase = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.count = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.keywordPanel = new System.Windows.Forms.Panel();
            this.keywordSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.button6 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.keywordTabs = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.fastObjectListView5 = new BrightIdeasSoftware.FastObjectListView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.csvDialog = new System.Windows.Forms.OpenFileDialog();
            this.indexDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
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
            this.topMenuStrip = new System.Windows.Forms.MenuStrip();
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
            this.bottomStrip = new System.Windows.Forms.StatusStrip();
            this.messageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tagsetLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.newSituationLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.filterButton = new System.Windows.Forms.ToolStripSplitButton();
            this.chooseTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taggedOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.ToolStripSplitButton();
            this.writeToDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSituationButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSituationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagsetEditorButton = new System.Windows.Forms.ToolStripSplitButton();
            this.suggesterButton = new System.Windows.Forms.ToolStripSplitButton();
            this.splitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.tagsetView = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            mainTabControl = new System.Windows.Forms.TabControl();
            mainTabControl.SuspendLayout();
            this.Chat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chatTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.Panel1.SuspendLayout();
            this.splitContainerRight.Panel2.SuspendLayout();
            this.splitContainerRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastSituationView)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.Statistics.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.Concordance.SuspendLayout();
            this.concordancePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.ngramPage.SuspendLayout();
            this.ngramPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ngramTabs.SuspendLayout();
            this.bi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bigramView)).BeginInit();
            this.trigramPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trigramView)).BeginInit();
            this.four.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fourgramView)).BeginInit();
            this.five.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fivegramView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.keywordPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keywordSplitContainer)).BeginInit();
            this.keywordSplitContainer.Panel1.SuspendLayout();
            this.keywordSplitContainer.Panel2.SuspendLayout();
            this.keywordSplitContainer.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.keywordTabs.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView5)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.datesPanel.SuspendLayout();
            this.userPanel.SuspendLayout();
            this.queryPanel.SuspendLayout();
            this.topMenuStrip.SuspendLayout();
            this.bottomStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).BeginInit();
            this.splitContainerLeft.Panel1.SuspendLayout();
            this.splitContainerLeft.Panel2.SuspendLayout();
            this.splitContainerLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            mainTabControl.Controls.Add(this.Chat);
            mainTabControl.Controls.Add(this.Statistics);
            mainTabControl.Controls.Add(this.Concordance);
            mainTabControl.Controls.Add(this.ngramPage);
            mainTabControl.Controls.Add(this.tabPage2);
            mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            mainTabControl.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            mainTabControl.Location = new System.Drawing.Point(0, 0);
            mainTabControl.Margin = new System.Windows.Forms.Padding(2);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.Padding = new System.Drawing.Point(0, 0);
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new System.Drawing.Size(1101, 806);
            mainTabControl.TabIndex = 17;
            mainTabControl.TabStop = false;
            // 
            // Chat
            // 
            this.Chat.BackColor = System.Drawing.Color.Lavender;
            this.Chat.Controls.Add(this.splitContainer2);
            this.Chat.Controls.Add(this.tableLayoutPanel1);
            this.Chat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Chat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Chat.Location = new System.Drawing.Point(4, 27);
            this.Chat.Margin = new System.Windows.Forms.Padding(2);
            this.Chat.Name = "Chat";
            this.Chat.Padding = new System.Windows.Forms.Padding(2);
            this.Chat.Size = new System.Drawing.Size(1093, 775);
            this.Chat.TabIndex = 0;
            this.Chat.Text = "Chat";
            this.Chat.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(2, 54);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chatTable);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainerRight);
            this.splitContainer2.Size = new System.Drawing.Size(1089, 719);
            this.splitContainer2.SplitterDistance = 870;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 14;
            // 
            // chatTable
            // 
            this.chatTable.AllowColumnReorder = true;
            this.chatTable.AutoArrange = false;
            this.chatTable.BackColor = System.Drawing.Color.White;
            this.chatTable.CellEditUseWholeCell = false;
            this.chatTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatTable.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chatTable.FullRowSelect = true;
            this.chatTable.HeaderUsesThemes = true;
            this.chatTable.HideSelection = false;
            this.chatTable.Location = new System.Drawing.Point(0, 0);
            this.chatTable.Margin = new System.Windows.Forms.Padding(2);
            this.chatTable.Name = "chatTable";
            this.chatTable.RowHeight = 52;
            this.chatTable.ShowGroups = false;
            this.chatTable.Size = new System.Drawing.Size(870, 719);
            this.chatTable.TabIndex = 9;
            this.chatTable.TintSortColumn = true;
            this.chatTable.UseCellFormatEvents = true;
            this.chatTable.UseCompatibleStateImageBehavior = false;
            this.chatTable.UseFiltering = true;
            this.chatTable.View = System.Windows.Forms.View.Details;
            this.chatTable.VirtualMode = true;
            this.chatTable.Visible = false;
            this.chatTable.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.chatTable_CellRightClick);
            this.chatTable.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.ChatTable_FormatCell);
            this.chatTable.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.ChatTable_FormatRow);
            this.chatTable.Scroll += new System.EventHandler<System.Windows.Forms.ScrollEventArgs>(this.chatTable_Scroll);
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
            this.splitContainerRight.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainerRight.Panel2
            // 
            this.splitContainerRight.Panel2.Controls.Add(this.fastSituationView);
            this.splitContainerRight.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainerRight.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerRight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerRight.Size = new System.Drawing.Size(213, 719);
            this.splitContainerRight.SplitterDistance = 253;
            this.splitContainerRight.SplitterWidth = 10;
            this.splitContainerRight.TabIndex = 19;
            this.splitContainerRight.Visible = false;
            // 
            // dateView
            // 
            this.dateView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dateView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Days});
            this.dateView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateView.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateView.FullRowSelect = true;
            this.dateView.HideSelection = false;
            this.dateView.Location = new System.Drawing.Point(0, 0);
            this.dateView.Margin = new System.Windows.Forms.Padding(2);
            this.dateView.Name = "dateView";
            this.dateView.ShowItemToolTips = true;
            this.dateView.Size = new System.Drawing.Size(213, 253);
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
            this.fastSituationView.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fastSituationView.FullRowSelect = true;
            this.fastSituationView.HideSelection = false;
            this.fastSituationView.Location = new System.Drawing.Point(0, 0);
            this.fastSituationView.Name = "fastSituationView";
            this.fastSituationView.ShowGroups = false;
            this.fastSituationView.Size = new System.Drawing.Size(213, 386);
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
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.button3, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.button5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.button4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 386);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(213, 70);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lavender;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(108, 2);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 31);
            this.button3.TabIndex = 21;
            this.button3.Text = "Edit tag";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Lavender;
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Enabled = false;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(2, 37);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 31);
            this.button5.TabIndex = 20;
            this.button5.Text = "Merge";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lavender;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(108, 37);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 31);
            this.button2.TabIndex = 19;
            this.button2.Text = "Cross-merge";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Lavender;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(2, 2);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 31);
            this.button4.TabIndex = 18;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1089, 52);
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
            this.removeTagButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeTagButton.Location = new System.Drawing.Point(3, 3);
            this.removeTagButton.Name = "removeTagButton";
            this.removeTagButton.Size = new System.Drawing.Size(538, 46);
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
            this.addTagButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addTagButton.Location = new System.Drawing.Point(547, 3);
            this.addTagButton.Name = "addTagButton";
            this.addTagButton.Size = new System.Drawing.Size(539, 46);
            this.addTagButton.TabIndex = 2;
            this.addTagButton.Text = "Add tag";
            this.addTagButton.UseVisualStyleBackColor = false;
            this.addTagButton.Click += new System.EventHandler(this.addTagButton_Click);
            // 
            // Statistics
            // 
            this.Statistics.Controls.Add(this.panel2);
            this.Statistics.Controls.Add(this.richTextBox1);
            this.Statistics.Location = new System.Drawing.Point(4, 27);
            this.Statistics.Margin = new System.Windows.Forms.Padding(2);
            this.Statistics.Name = "Statistics";
            this.Statistics.Padding = new System.Windows.Forms.Padding(2);
            this.Statistics.Size = new System.Drawing.Size(1093, 797);
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
            this.panel2.Size = new System.Drawing.Size(1089, 793);
            this.panel2.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1089, 793);
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
            this.tableLayoutPanel2.Controls.Add(this.corpusStatisticsView, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 674F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1089, 793);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(546, 676);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(541, 115);
            this.button1.TabIndex = 4;
            this.button1.Text = "Calculate statistics";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // statisticsButton
            // 
            this.statisticsButton.BackColor = System.Drawing.Color.Lavender;
            this.statisticsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statisticsButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.statisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticsButton.Location = new System.Drawing.Point(2, 676);
            this.statisticsButton.Margin = new System.Windows.Forms.Padding(2);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(540, 115);
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
            this.statisticsListView.Size = new System.Drawing.Size(540, 670);
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
            this.columnHeader2.Width = 343;
            // 
            // corpusStatisticsView
            // 
            this.corpusStatisticsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.corpusStatisticsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.corpusStatisticsView.HideSelection = false;
            this.corpusStatisticsView.Location = new System.Drawing.Point(546, 2);
            this.corpusStatisticsView.Margin = new System.Windows.Forms.Padding(2);
            this.corpusStatisticsView.Name = "corpusStatisticsView";
            this.corpusStatisticsView.Size = new System.Drawing.Size(541, 670);
            this.corpusStatisticsView.TabIndex = 3;
            this.corpusStatisticsView.UseCompatibleStateImageBehavior = false;
            this.corpusStatisticsView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 175;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Value";
            this.columnHeader6.Width = 470;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1089, 793);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Concordance
            // 
            this.Concordance.Controls.Add(this.concordancePanel);
            this.Concordance.Location = new System.Drawing.Point(4, 27);
            this.Concordance.Margin = new System.Windows.Forms.Padding(2);
            this.Concordance.Name = "Concordance";
            this.Concordance.Padding = new System.Windows.Forms.Padding(2);
            this.Concordance.Size = new System.Drawing.Size(1093, 797);
            this.Concordance.TabIndex = 4;
            this.Concordance.Text = "Concordance";
            this.Concordance.UseVisualStyleBackColor = true;
            // 
            // concordancePanel
            // 
            this.concordancePanel.Controls.Add(this.splitContainer4);
            this.concordancePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.concordancePanel.Location = new System.Drawing.Point(2, 2);
            this.concordancePanel.Margin = new System.Windows.Forms.Padding(2);
            this.concordancePanel.Name = "concordancePanel";
            this.concordancePanel.Size = new System.Drawing.Size(1089, 793);
            this.concordancePanel.TabIndex = 3;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.Lavender;
            this.splitContainer4.Panel1.Controls.Add(this.concordancerButton);
            this.splitContainer4.Panel1.Controls.Add(this.charSelectionBox);
            this.splitContainer4.Panel1.Controls.Add(this.concordanceBox);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.concordanceView);
            this.splitContainer4.Size = new System.Drawing.Size(1089, 793);
            this.splitContainer4.SplitterDistance = 362;
            this.splitContainer4.TabIndex = 3;
            // 
            // concordancerButton
            // 
            this.concordancerButton.BackColor = System.Drawing.Color.Lavender;
            this.concordancerButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.concordancerButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.concordancerButton.FlatAppearance.BorderSize = 0;
            this.concordancerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.concordancerButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.concordancerButton.Location = new System.Drawing.Point(0, 46);
            this.concordancerButton.Margin = new System.Windows.Forms.Padding(2);
            this.concordancerButton.Name = "concordancerButton";
            this.concordancerButton.Size = new System.Drawing.Size(362, 46);
            this.concordancerButton.TabIndex = 9;
            this.concordancerButton.Text = "Show concordance";
            this.concordancerButton.UseVisualStyleBackColor = false;
            this.concordancerButton.Click += new System.EventHandler(this.concordance_Click);
            // 
            // charSelectionBox
            // 
            this.charSelectionBox.BackColor = System.Drawing.Color.AliceBlue;
            this.charSelectionBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.charSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.charSelectionBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.charSelectionBox.FormattingEnabled = true;
            this.charSelectionBox.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.charSelectionBox.Location = new System.Drawing.Point(0, 23);
            this.charSelectionBox.Margin = new System.Windows.Forms.Padding(2);
            this.charSelectionBox.Name = "charSelectionBox";
            this.charSelectionBox.Size = new System.Drawing.Size(362, 23);
            this.charSelectionBox.TabIndex = 10;
            // 
            // concordanceBox
            // 
            this.concordanceBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.concordanceBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.concordanceBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.concordanceBox.Location = new System.Drawing.Point(0, 0);
            this.concordanceBox.Margin = new System.Windows.Forms.Padding(2);
            this.concordanceBox.MinimumSize = new System.Drawing.Size(76, 60);
            this.concordanceBox.Name = "concordanceBox";
            this.concordanceBox.Size = new System.Drawing.Size(362, 23);
            this.concordanceBox.TabIndex = 8;
            // 
            // concordanceView
            // 
            this.concordanceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.concordanceView.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.concordanceView.Location = new System.Drawing.Point(0, 0);
            this.concordanceView.Name = "concordanceView";
            this.concordanceView.Size = new System.Drawing.Size(723, 793);
            this.concordanceView.Styler = null;
            this.concordanceView.TabIndex = 1;
            // 
            // ngramPage
            // 
            this.ngramPage.Controls.Add(this.ngramPanel);
            this.ngramPage.Location = new System.Drawing.Point(4, 27);
            this.ngramPage.Margin = new System.Windows.Forms.Padding(2);
            this.ngramPage.Name = "ngramPage";
            this.ngramPage.Size = new System.Drawing.Size(1093, 797);
            this.ngramPage.TabIndex = 5;
            this.ngramPage.Text = "N-gram Search";
            this.ngramPage.UseVisualStyleBackColor = true;
            // 
            // ngramPanel
            // 
            this.ngramPanel.Controls.Add(this.splitContainer1);
            this.ngramPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ngramPanel.Location = new System.Drawing.Point(0, 0);
            this.ngramPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ngramPanel.Name = "ngramPanel";
            this.ngramPanel.Size = new System.Drawing.Size(1093, 797);
            this.ngramPanel.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Lavender;
            this.splitContainer1.Panel1.Controls.Add(this.ngramIndexButton);
            this.splitContainer1.Panel1.Controls.Add(this.ngramSearchButton);
            this.splitContainer1.Panel1.Controls.Add(this.ngramSearchBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ngramTabs);
            this.splitContainer1.Size = new System.Drawing.Size(1093, 797);
            this.splitContainer1.SplitterDistance = 363;
            this.splitContainer1.TabIndex = 0;
            // 
            // ngramIndexButton
            // 
            this.ngramIndexButton.BackColor = System.Drawing.Color.Lavender;
            this.ngramIndexButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ngramIndexButton.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.ngramIndexButton.FlatAppearance.BorderSize = 0;
            this.ngramIndexButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ngramIndexButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ngramIndexButton.Location = new System.Drawing.Point(0, 72);
            this.ngramIndexButton.Margin = new System.Windows.Forms.Padding(2);
            this.ngramIndexButton.Name = "ngramIndexButton";
            this.ngramIndexButton.Size = new System.Drawing.Size(363, 42);
            this.ngramIndexButton.TabIndex = 3;
            this.ngramIndexButton.Text = "Get index";
            this.ngramIndexButton.UseVisualStyleBackColor = false;
            this.ngramIndexButton.Visible = false;
            this.ngramIndexButton.Click += new System.EventHandler(this.ngramIndexButton_Click);
            // 
            // ngramSearchButton
            // 
            this.ngramSearchButton.BackColor = System.Drawing.Color.Lavender;
            this.ngramSearchButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ngramSearchButton.Enabled = false;
            this.ngramSearchButton.FlatAppearance.BorderSize = 0;
            this.ngramSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ngramSearchButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ngramSearchButton.Location = new System.Drawing.Point(0, 23);
            this.ngramSearchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ngramSearchButton.Name = "ngramSearchButton";
            this.ngramSearchButton.Size = new System.Drawing.Size(363, 49);
            this.ngramSearchButton.TabIndex = 16;
            this.ngramSearchButton.Text = "Search for n-grams";
            this.ngramSearchButton.UseVisualStyleBackColor = false;
            this.ngramSearchButton.Visible = false;
            this.ngramSearchButton.Click += new System.EventHandler(this.ngram_Click);
            // 
            // ngramSearchBox
            // 
            this.ngramSearchBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ngramSearchBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ngramSearchBox.Location = new System.Drawing.Point(0, 0);
            this.ngramSearchBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ngramSearchBox.MaximumSize = new System.Drawing.Size(400, 200);
            this.ngramSearchBox.MinimumSize = new System.Drawing.Size(100, 60);
            this.ngramSearchBox.Name = "ngramSearchBox";
            this.ngramSearchBox.Size = new System.Drawing.Size(363, 23);
            this.ngramSearchBox.TabIndex = 15;
            this.ngramSearchBox.Visible = false;
            // 
            // ngramTabs
            // 
            this.ngramTabs.Controls.Add(this.bi);
            this.ngramTabs.Controls.Add(this.trigramPage);
            this.ngramTabs.Controls.Add(this.four);
            this.ngramTabs.Controls.Add(this.five);
            this.ngramTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ngramTabs.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ngramTabs.Location = new System.Drawing.Point(0, 0);
            this.ngramTabs.Margin = new System.Windows.Forms.Padding(4);
            this.ngramTabs.Name = "ngramTabs";
            this.ngramTabs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ngramTabs.SelectedIndex = 0;
            this.ngramTabs.Size = new System.Drawing.Size(726, 797);
            this.ngramTabs.TabIndex = 14;
            this.ngramTabs.Visible = false;
            // 
            // bi
            // 
            this.bi.Controls.Add(this.bigramView);
            this.bi.Location = new System.Drawing.Point(4, 24);
            this.bi.Margin = new System.Windows.Forms.Padding(4);
            this.bi.Name = "bi";
            this.bi.Padding = new System.Windows.Forms.Padding(4);
            this.bi.Size = new System.Drawing.Size(718, 769);
            this.bi.TabIndex = 0;
            this.bi.Text = "Bigrams";
            this.bi.UseVisualStyleBackColor = true;
            // 
            // bigramView
            // 
            this.bigramView.AllColumns.Add(this.phrase2);
            this.bigramView.AllColumns.Add(this.count2);
            this.bigramView.CellEditUseWholeCell = false;
            this.bigramView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.phrase2,
            this.count2});
            this.bigramView.Cursor = System.Windows.Forms.Cursors.Default;
            this.bigramView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bigramView.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bigramView.HideSelection = false;
            this.bigramView.Location = new System.Drawing.Point(4, 4);
            this.bigramView.Margin = new System.Windows.Forms.Padding(4);
            this.bigramView.Name = "bigramView";
            this.bigramView.ShowGroups = false;
            this.bigramView.Size = new System.Drawing.Size(710, 761);
            this.bigramView.TabIndex = 0;
            this.bigramView.UseCompatibleStateImageBehavior = false;
            this.bigramView.View = System.Windows.Forms.View.Details;
            this.bigramView.VirtualMode = true;
            // 
            // phrase2
            // 
            this.phrase2.AspectName = "Key";
            this.phrase2.Text = "Phrase";
            this.phrase2.Width = 368;
            // 
            // count2
            // 
            this.count2.AspectName = "Value";
            this.count2.Text = "Count";
            this.count2.Width = 450;
            // 
            // trigramPage
            // 
            this.trigramPage.Controls.Add(this.trigramView);
            this.trigramPage.Location = new System.Drawing.Point(4, 24);
            this.trigramPage.Margin = new System.Windows.Forms.Padding(4);
            this.trigramPage.Name = "trigramPage";
            this.trigramPage.Padding = new System.Windows.Forms.Padding(4);
            this.trigramPage.Size = new System.Drawing.Size(718, 747);
            this.trigramPage.TabIndex = 1;
            this.trigramPage.Text = "Trigrams";
            this.trigramPage.UseVisualStyleBackColor = true;
            // 
            // trigramView
            // 
            this.trigramView.AllColumns.Add(this.phrase3);
            this.trigramView.AllColumns.Add(this.count3);
            this.trigramView.CellEditUseWholeCell = false;
            this.trigramView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.phrase3,
            this.count3});
            this.trigramView.Cursor = System.Windows.Forms.Cursors.Default;
            this.trigramView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trigramView.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trigramView.HideSelection = false;
            this.trigramView.Location = new System.Drawing.Point(4, 4);
            this.trigramView.Margin = new System.Windows.Forms.Padding(4);
            this.trigramView.Name = "trigramView";
            this.trigramView.ShowGroups = false;
            this.trigramView.Size = new System.Drawing.Size(710, 739);
            this.trigramView.TabIndex = 1;
            this.trigramView.UseCompatibleStateImageBehavior = false;
            this.trigramView.View = System.Windows.Forms.View.Details;
            this.trigramView.VirtualMode = true;
            // 
            // phrase3
            // 
            this.phrase3.AspectName = "Key";
            this.phrase3.Text = "Phrase";
            this.phrase3.Width = 316;
            // 
            // count3
            // 
            this.count3.AspectName = "Value";
            this.count3.Text = "Count";
            this.count3.Width = 189;
            // 
            // four
            // 
            this.four.Controls.Add(this.fourgramView);
            this.four.Location = new System.Drawing.Point(4, 24);
            this.four.Margin = new System.Windows.Forms.Padding(4);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(718, 747);
            this.four.TabIndex = 2;
            this.four.Text = "4-grams";
            this.four.UseVisualStyleBackColor = true;
            // 
            // fourgramView
            // 
            this.fourgramView.AllColumns.Add(this.phrase4);
            this.fourgramView.AllColumns.Add(this.count4);
            this.fourgramView.CellEditUseWholeCell = false;
            this.fourgramView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.phrase4,
            this.count4});
            this.fourgramView.Cursor = System.Windows.Forms.Cursors.Default;
            this.fourgramView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fourgramView.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fourgramView.HideSelection = false;
            this.fourgramView.Location = new System.Drawing.Point(0, 0);
            this.fourgramView.Margin = new System.Windows.Forms.Padding(4);
            this.fourgramView.Name = "fourgramView";
            this.fourgramView.ShowGroups = false;
            this.fourgramView.Size = new System.Drawing.Size(718, 747);
            this.fourgramView.TabIndex = 1;
            this.fourgramView.UseCompatibleStateImageBehavior = false;
            this.fourgramView.View = System.Windows.Forms.View.Details;
            this.fourgramView.VirtualMode = true;
            // 
            // phrase4
            // 
            this.phrase4.AspectName = "Key";
            this.phrase4.Text = "Phrase";
            this.phrase4.Width = 218;
            // 
            // count4
            // 
            this.count4.AspectName = "Value";
            this.count4.Text = "Count";
            this.count4.Width = 315;
            // 
            // five
            // 
            this.five.Controls.Add(this.fivegramView);
            this.five.Location = new System.Drawing.Point(4, 24);
            this.five.Margin = new System.Windows.Forms.Padding(4);
            this.five.Name = "five";
            this.five.Size = new System.Drawing.Size(718, 747);
            this.five.TabIndex = 3;
            this.five.Text = "5-grams";
            this.five.UseVisualStyleBackColor = true;
            // 
            // fivegramView
            // 
            this.fivegramView.AllColumns.Add(this.phrase);
            this.fivegramView.AllColumns.Add(this.count);
            this.fivegramView.CellEditUseWholeCell = false;
            this.fivegramView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.phrase,
            this.count});
            this.fivegramView.Cursor = System.Windows.Forms.Cursors.Default;
            this.fivegramView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fivegramView.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fivegramView.HideSelection = false;
            this.fivegramView.Location = new System.Drawing.Point(0, 0);
            this.fivegramView.Margin = new System.Windows.Forms.Padding(4);
            this.fivegramView.Name = "fivegramView";
            this.fivegramView.ShowGroups = false;
            this.fivegramView.Size = new System.Drawing.Size(718, 747);
            this.fivegramView.TabIndex = 1;
            this.fivegramView.UseCompatibleStateImageBehavior = false;
            this.fivegramView.View = System.Windows.Forms.View.Details;
            this.fivegramView.VirtualMode = true;
            // 
            // phrase
            // 
            this.phrase.AspectName = "Key";
            this.phrase.Text = "Phrase";
            this.phrase.Width = 428;
            // 
            // count
            // 
            this.count.AspectName = "Value";
            this.count.Text = "Count";
            this.count.Width = 587;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.keywordPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1093, 797);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "Keyword Analysis";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // keywordPanel
            // 
            this.keywordPanel.Controls.Add(this.keywordSplitContainer);
            this.keywordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keywordPanel.Location = new System.Drawing.Point(0, 0);
            this.keywordPanel.Margin = new System.Windows.Forms.Padding(2);
            this.keywordPanel.Name = "keywordPanel";
            this.keywordPanel.Size = new System.Drawing.Size(1093, 797);
            this.keywordPanel.TabIndex = 1;
            // 
            // keywordSplitContainer
            // 
            this.keywordSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keywordSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.keywordSplitContainer.Name = "keywordSplitContainer";
            // 
            // keywordSplitContainer.Panel1
            // 
            this.keywordSplitContainer.Panel1.BackColor = System.Drawing.Color.Lavender;
            this.keywordSplitContainer.Panel1.Controls.Add(this.tableLayoutPanel5);
            // 
            // keywordSplitContainer.Panel2
            // 
            this.keywordSplitContainer.Panel2.Controls.Add(this.keywordTabs);
            this.keywordSplitContainer.Size = new System.Drawing.Size(1093, 797);
            this.keywordSplitContainer.SplitterDistance = 363;
            this.keywordSplitContainer.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.button6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.comboBox1, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.button8, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(363, 91);
            this.tableLayoutPanel5.TabIndex = 9;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Lavender;
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Enabled = false;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(3, 2);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(175, 41);
            this.button6.TabIndex = 5;
            this.button6.Text = "Extract keywords";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.Enabled = false;
            this.comboBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(3, 47);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 23);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Text = "Phrase length (def 2)";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Lavender;
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Enabled = false;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(184, 2);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(176, 41);
            this.button8.TabIndex = 8;
            this.button8.Text = "Extract noun phrases";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(184, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 46);
            this.label3.TabIndex = 9;
            this.label3.Text = "(Requires CoreNLP)";
            // 
            // keywordTabs
            // 
            this.keywordTabs.Controls.Add(this.tabPage3);
            this.keywordTabs.Controls.Add(this.tabPage4);
            this.keywordTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keywordTabs.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.keywordTabs.Location = new System.Drawing.Point(0, 0);
            this.keywordTabs.Name = "keywordTabs";
            this.keywordTabs.SelectedIndex = 0;
            this.keywordTabs.Size = new System.Drawing.Size(726, 797);
            this.keywordTabs.TabIndex = 14;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.fastObjectListView5);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(718, 769);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Keywords";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // fastObjectListView5
            // 
            this.fastObjectListView5.CellEditUseWholeCell = false;
            this.fastObjectListView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListView5.HideSelection = false;
            this.fastObjectListView5.Location = new System.Drawing.Point(3, 3);
            this.fastObjectListView5.Name = "fastObjectListView5";
            this.fastObjectListView5.ShowGroups = false;
            this.fastObjectListView5.Size = new System.Drawing.Size(712, 763);
            this.fastObjectListView5.TabIndex = 0;
            this.fastObjectListView5.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView5.View = System.Windows.Forms.View.Details;
            this.fastObjectListView5.VirtualMode = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.richTextBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(718, 747);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Noun Phrases";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(3, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(712, 741);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // csvDialog
            // 
            this.csvDialog.FileName = "csvDialog";
            this.csvDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.csvDialog_FileOk);
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.tableLayoutPanel4);
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
            this.searchPanel.Size = new System.Drawing.Size(225, 504);
            this.searchPanel.TabIndex = 16;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.findButton, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.clearButton, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 423);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(225, 55);
            this.tableLayoutPanel4.TabIndex = 29;
            // 
            // findButton
            // 
            this.findButton.BackColor = System.Drawing.Color.Lavender;
            this.findButton.Enabled = false;
            this.findButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.findButton.FlatAppearance.BorderSize = 0;
            this.findButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.findButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findButton.Location = new System.Drawing.Point(2, 29);
            this.findButton.Margin = new System.Windows.Forms.Padding(2);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(218, 20);
            this.findButton.TabIndex = 15;
            this.findButton.Text = "Find";
            this.findButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.findButton.UseVisualStyleBackColor = false;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Lavender;
            this.clearButton.Enabled = false;
            this.clearButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.Location = new System.Drawing.Point(2, 2);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(218, 23);
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
            this.datesPanel.Size = new System.Drawing.Size(225, 59);
            this.datesPanel.TabIndex = 23;
            this.datesPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.startDate.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(58, 2);
            this.startDate.Margin = new System.Windows.Forms.Padding(2);
            this.startDate.MaxDate = new System.DateTime(9998, 1, 1, 0, 0, 0, 0);
            this.startDate.Name = "startDate";
            this.startDate.ShowCheckBox = true;
            this.startDate.Size = new System.Drawing.Size(165, 23);
            this.startDate.TabIndex = 17;
            this.startDate.Value = new System.DateTime(2020, 4, 28, 0, 0, 0, 0);
            // 
            // finishDate
            // 
            this.finishDate.Checked = false;
            this.finishDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishDate.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.finishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.finishDate.Location = new System.Drawing.Point(58, 31);
            this.finishDate.Margin = new System.Windows.Forms.Padding(2);
            this.finishDate.Name = "finishDate";
            this.finishDate.ShowCheckBox = true;
            this.finishDate.Size = new System.Drawing.Size(165, 23);
            this.finishDate.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.dateToggle.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.dateToggle.FlatAppearance.BorderSize = 0;
            this.dateToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dateToggle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateToggle.Location = new System.Drawing.Point(0, 332);
            this.dateToggle.Margin = new System.Windows.Forms.Padding(2);
            this.dateToggle.MinimumSize = new System.Drawing.Size(0, 32);
            this.dateToggle.Name = "dateToggle";
            this.dateToggle.Size = new System.Drawing.Size(225, 32);
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
            this.userPanel.Size = new System.Drawing.Size(225, 229);
            this.userPanel.TabIndex = 21;
            this.userPanel.Visible = false;
            // 
            // userList
            // 
            this.userList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userList.CheckBoxes = true;
            this.userList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Users});
            this.userList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userList.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userList.FullRowSelect = true;
            this.userList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.userList.HideSelection = false;
            this.userList.Location = new System.Drawing.Point(0, 0);
            this.userList.Margin = new System.Windows.Forms.Padding(2);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(225, 229);
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
            this.userToggle.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.userToggle.FlatAppearance.BorderSize = 0;
            this.userToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userToggle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userToggle.Location = new System.Drawing.Point(0, 71);
            this.userToggle.Margin = new System.Windows.Forms.Padding(2);
            this.userToggle.MinimumSize = new System.Drawing.Size(0, 32);
            this.userToggle.Name = "userToggle";
            this.userToggle.Size = new System.Drawing.Size(225, 32);
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
            this.queryPanel.Size = new System.Drawing.Size(225, 39);
            this.queryPanel.TabIndex = 20;
            this.queryPanel.Visible = false;
            // 
            // searchBox
            // 
            this.searchBox.AutoWordSelection = true;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchBox.Location = new System.Drawing.Point(0, 0);
            this.searchBox.Margin = new System.Windows.Forms.Padding(2);
            this.searchBox.Multiline = false;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(225, 39);
            this.searchBox.TabIndex = 15;
            this.searchBox.Text = "Enter query...";
            this.searchBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseClick);
            // 
            // queryButton
            // 
            this.queryButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.queryButton.Enabled = false;
            this.queryButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.queryButton.FlatAppearance.BorderSize = 0;
            this.queryButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.queryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.queryButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.queryButton.Location = new System.Drawing.Point(0, 0);
            this.queryButton.Margin = new System.Windows.Forms.Padding(2);
            this.queryButton.MinimumSize = new System.Drawing.Size(0, 32);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(225, 32);
            this.queryButton.TabIndex = 19;
            this.queryButton.Text = "Query";
            this.queryButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // topMenuStrip
            // 
            this.topMenuStrip.BackColor = System.Drawing.Color.Lavender;
            this.topMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.topMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.topMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.vizToolStripMenuItem,
            this.extractToolStripMenuItem1});
            this.topMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.topMenuStrip.MinimumSize = new System.Drawing.Size(0, 22);
            this.topMenuStrip.Name = "topMenuStrip";
            this.topMenuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.topMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.topMenuStrip.Size = new System.Drawing.Size(1330, 22);
            this.topMenuStrip.TabIndex = 14;
            this.topMenuStrip.Text = "menuStrip1";
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
            // bottomStrip
            // 
            this.bottomStrip.BackColor = System.Drawing.Color.Lavender;
            this.bottomStrip.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bottomStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageLabel,
            this.tagsetLabel,
            this.newSituationLabel,
            this.filterButton,
            this.saveButton,
            this.editSituationButton,
            this.tagsetEditorButton,
            this.suggesterButton});
            this.bottomStrip.Location = new System.Drawing.Point(0, 828);
            this.bottomStrip.Name = "bottomStrip";
            this.bottomStrip.Size = new System.Drawing.Size(1330, 22);
            this.bottomStrip.TabIndex = 30;
            this.bottomStrip.Text = "statusStrip1";
            // 
            // messageLabel
            // 
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(77, 17);
            this.messageLabel.Text = "Not loaded";
            // 
            // tagsetLabel
            // 
            this.tagsetLabel.Name = "tagsetLabel";
            this.tagsetLabel.Size = new System.Drawing.Size(70, 17);
            this.tagsetLabel.Text = "No tagset";
            // 
            // newSituationLabel
            // 
            this.newSituationLabel.Name = "newSituationLabel";
            this.newSituationLabel.Size = new System.Drawing.Size(91, 17);
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
            this.filterButton.Size = new System.Drawing.Size(135, 20);
            this.filterButton.Text = "Filter by tag...";
            this.filterButton.Visible = false;
            // 
            // chooseTagToolStripMenuItem
            // 
            this.chooseTagToolStripMenuItem.Name = "chooseTagToolStripMenuItem";
            this.chooseTagToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.chooseTagToolStripMenuItem.Text = "Choose tag...";
            // 
            // taggedOnlyToolStripMenuItem
            // 
            this.taggedOnlyToolStripMenuItem.Name = "taggedOnlyToolStripMenuItem";
            this.taggedOnlyToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
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
            this.saveButton.Size = new System.Drawing.Size(72, 20);
            this.saveButton.Text = "Save...";
            this.saveButton.Visible = false;
            // 
            // writeToDiskToolStripMenuItem
            // 
            this.writeToDiskToolStripMenuItem.Name = "writeToDiskToolStripMenuItem";
            this.writeToDiskToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.writeToDiskToolStripMenuItem.Text = "Write to disk";
            this.writeToDiskToolStripMenuItem.Click += new System.EventHandler(this.writeToDiskToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.saveToolStripMenuItem.Text = "Save ";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
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
            this.editSituationButton.ShowDropDownArrow = false;
            this.editSituationButton.Size = new System.Drawing.Size(109, 20);
            this.editSituationButton.Text = "Edit Situation";
            this.editSituationButton.Visible = false;
            // 
            // mergeToolStripMenuItem
            // 
            this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
            this.mergeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.mergeToolStripMenuItem.Text = "Merge...";
            // 
            // deleteSituationToolStripMenuItem
            // 
            this.deleteSituationToolStripMenuItem.Name = "deleteSituationToolStripMenuItem";
            this.deleteSituationToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.deleteSituationToolStripMenuItem.Text = "Delete situation";
            // 
            // changeTagToolStripMenuItem
            // 
            this.changeTagToolStripMenuItem.Name = "changeTagToolStripMenuItem";
            this.changeTagToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.changeTagToolStripMenuItem.Text = "Change tag";
            // 
            // tagsetEditorButton
            // 
            this.tagsetEditorButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tagsetEditorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tagsetEditorButton.DropDownButtonWidth = 0;
            this.tagsetEditorButton.Image = ((System.Drawing.Image)(resources.GetObject("tagsetEditorButton.Image")));
            this.tagsetEditorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tagsetEditorButton.Name = "tagsetEditorButton";
            this.tagsetEditorButton.Size = new System.Drawing.Size(103, 20);
            this.tagsetEditorButton.Text = "Tagset Editor";
            this.tagsetEditorButton.Visible = false;
            this.tagsetEditorButton.ButtonClick += new System.EventHandler(this.tagsetEditorButton_ButtonClick);
            // 
            // suggesterButton
            // 
            this.suggesterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.suggesterButton.DropDownButtonWidth = 0;
            this.suggesterButton.Image = ((System.Drawing.Image)(resources.GetObject("suggesterButton.Image")));
            this.suggesterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.suggesterButton.Name = "suggesterButton";
            this.suggesterButton.Size = new System.Drawing.Size(75, 20);
            this.suggesterButton.Text = "Suggester";
            this.suggesterButton.Visible = false;
            this.suggesterButton.Click += new System.EventHandler(this.suggester_Click);
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
            this.splitContainerLeft.Panel1.Controls.Add(this.searchPanel);
            // 
            // splitContainerLeft.Panel2
            // 
            this.splitContainerLeft.Panel2.Controls.Add(this.tagsetView);
            this.splitContainerLeft.Size = new System.Drawing.Size(225, 806);
            this.splitContainerLeft.SplitterDistance = 504;
            this.splitContainerLeft.TabIndex = 29;
            // 
            // tagsetView
            // 
            this.tagsetView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tagsetView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagsetView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.tagsetView.Dock = System.Windows.Forms.DockStyle.Top;
            this.tagsetView.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tagsetView.FullRowSelect = true;
            this.tagsetView.HideSelection = false;
            this.tagsetView.Location = new System.Drawing.Point(0, 0);
            this.tagsetView.MultiSelect = false;
            this.tagsetView.Name = "tagsetView";
            this.tagsetView.Size = new System.Drawing.Size(225, 280);
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
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 22);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerLeft);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(mainTabControl);
            this.splitContainerMain.Size = new System.Drawing.Size(1330, 806);
            this.splitContainerMain.SplitterDistance = 225;
            this.splitContainerMain.TabIndex = 31;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1330, 850);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.bottomStrip);
            this.Controls.Add(this.topMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1330, 850);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Corpora Annotator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            mainTabControl.ResumeLayout(false);
            this.Chat.ResumeLayout(false);
            this.Chat.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chatTable)).EndInit();
            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastSituationView)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Statistics.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.Concordance.ResumeLayout(false);
            this.concordancePanel.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ngramPage.ResumeLayout(false);
            this.ngramPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ngramTabs.ResumeLayout(false);
            this.bi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bigramView)).EndInit();
            this.trigramPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trigramView)).EndInit();
            this.four.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fourgramView)).EndInit();
            this.five.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fivegramView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.keywordPanel.ResumeLayout(false);
            this.keywordSplitContainer.Panel1.ResumeLayout(false);
            this.keywordSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.keywordSplitContainer)).EndInit();
            this.keywordSplitContainer.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.keywordTabs.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView5)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.datesPanel.ResumeLayout(false);
            this.datesPanel.PerformLayout();
            this.userPanel.ResumeLayout(false);
            this.queryPanel.ResumeLayout(false);
            this.topMenuStrip.ResumeLayout(false);
            this.topMenuStrip.PerformLayout();
            this.bottomStrip.ResumeLayout(false);
            this.bottomStrip.PerformLayout();
            this.splitContainerLeft.Panel1.ResumeLayout(false);
            this.splitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).EndInit();
            this.splitContainerLeft.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog csvDialog;
        private System.Windows.Forms.FolderBrowserDialog indexDialog;
        private System.Windows.Forms.MenuStrip topMenuStrip;
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
        private System.Windows.Forms.TabPage ngramPage;
        private System.Windows.Forms.Button ngramIndexButton;
        private System.Windows.Forms.Panel concordancePanel;
        private System.Windows.Forms.Panel ngramPanel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel keywordPanel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.StatusStrip bottomStrip;
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
        private System.Windows.Forms.SplitContainer splitContainerLeft;
        private System.Windows.Forms.SplitContainer splitContainerRight;
        private System.Windows.Forms.ListView tagsetView;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.ListView statisticsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView corpusStatisticsView;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem1;
        private BrightIdeasSoftware.ObjectListView fastSituationView;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private System.Windows.Forms.ListView dateView;
        private System.Windows.Forms.ColumnHeader Days;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl ngramTabs;
        private System.Windows.Forms.TabPage bi;
        private BrightIdeasSoftware.FastObjectListView bigramView;
        private BrightIdeasSoftware.OLVColumn phrase2;
        private BrightIdeasSoftware.OLVColumn count2;
        private BrightIdeasSoftware.FastObjectListView trigramView;
        private BrightIdeasSoftware.OLVColumn phrase3;
        private BrightIdeasSoftware.OLVColumn count3;
        private System.Windows.Forms.TabPage four;
        private BrightIdeasSoftware.FastObjectListView fourgramView;
        private BrightIdeasSoftware.OLVColumn phrase4;
        private BrightIdeasSoftware.OLVColumn count4;
        private System.Windows.Forms.TabPage five;
        private BrightIdeasSoftware.FastObjectListView fivegramView;
        private BrightIdeasSoftware.OLVColumn phrase;
        private BrightIdeasSoftware.OLVColumn count;
        private System.Windows.Forms.SplitContainer keywordSplitContainer;
        private System.Windows.Forms.Button ngramSearchButton;
        private System.Windows.Forms.TextBox ngramSearchBox;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TabControl keywordTabs;
        private System.Windows.Forms.TabPage tabPage3;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.TabPage trigramPage;
        private System.Windows.Forms.ComboBox charSelectionBox;
        private System.Windows.Forms.TextBox concordanceBox;
        private System.Windows.Forms.Button concordancerButton;
        private EasyScintilla.SimpleEditor concordanceView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label3;
    }
}

