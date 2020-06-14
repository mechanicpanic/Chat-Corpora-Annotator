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
            this.Chat = new System.Windows.Forms.TabPage();
            this.chatTable = new BrightIdeasSoftware.FastObjectListView();
            this.dateView = new System.Windows.Forms.ListView();
            this.Days = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loadMoreButton = new System.Windows.Forms.Button();
            this.Statistics = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.label3 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.RichTextBox();
            this.queryButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.messageLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCorpusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCorpusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heatmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.highlightTextRenderer1 = new BrightIdeasSoftware.HighlightTextRenderer();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabControl1.SuspendLayout();
            this.Chat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chatTable)).BeginInit();
            this.Statistics.SuspendLayout();
            this.Concordance.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.keywordPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.datesPanel.SuspendLayout();
            this.userPanel.SuspendLayout();
            this.queryPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            tabControl1.Location = new System.Drawing.Point(303, 43);
            tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new System.Drawing.Point(0, 0);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1227, 695);
            tabControl1.TabIndex = 17;
            tabControl1.TabStop = false;
            // 
            // Chat
            // 
            this.Chat.BackColor = System.Drawing.Color.Lavender;
            this.Chat.Controls.Add(this.chatTable);
            this.Chat.Controls.Add(this.dateView);
            this.Chat.Controls.Add(this.loadMoreButton);
            this.Chat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Chat.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Chat.Location = new System.Drawing.Point(4, 32);
            this.Chat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Chat.Name = "Chat";
            this.Chat.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Chat.Size = new System.Drawing.Size(1219, 659);
            this.Chat.TabIndex = 0;
            this.Chat.Text = "Chat";
            this.Chat.UseVisualStyleBackColor = true;
            // 
            // chatTable
            // 
            this.chatTable.AllowColumnReorder = true;
            this.chatTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatTable.BackColor = System.Drawing.Color.White;
            this.chatTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatTable.CellEditUseWholeCell = false;
            this.chatTable.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chatTable.FullRowSelect = true;
            this.chatTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.chatTable.HeaderUsesThemes = true;
            this.chatTable.HideSelection = false;
            this.chatTable.Location = new System.Drawing.Point(3, 2);
            this.chatTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chatTable.Name = "chatTable";
            this.chatTable.RowHeight = 52;
            this.chatTable.ShowGroups = false;
            this.chatTable.Size = new System.Drawing.Size(1019, 604);
            this.chatTable.TabIndex = 9;
            this.chatTable.UseCellFormatEvents = true;
            this.chatTable.UseCompatibleStateImageBehavior = false;
            this.chatTable.UseFiltering = true;
            this.chatTable.View = System.Windows.Forms.View.Details;
            this.chatTable.VirtualMode = true;
            // 
            // dateView
            // 
            this.dateView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dateView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Days});
            this.dateView.Dock = System.Windows.Forms.DockStyle.Right;
            this.dateView.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateView.FullRowSelect = true;
            this.dateView.HideSelection = false;
            this.dateView.Location = new System.Drawing.Point(1027, 2);
            this.dateView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateView.Name = "dateView";
            this.dateView.ShowItemToolTips = true;
            this.dateView.Size = new System.Drawing.Size(189, 606);
            this.dateView.TabIndex = 12;
            this.dateView.UseCompatibleStateImageBehavior = false;
            this.dateView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dateView_MouseDoubleClick);
            this.dateView.Resize += new System.EventHandler(this.dateView_Resize);
            // 
            // Days
            // 
            this.Days.Text = "Active dates";
            this.Days.Width = 115;
            // 
            // loadMoreButton
            // 
            this.loadMoreButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadMoreButton.BackColor = System.Drawing.Color.Lavender;
            this.loadMoreButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadMoreButton.FlatAppearance.BorderSize = 0;
            this.loadMoreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.loadMoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadMoreButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadMoreButton.Location = new System.Drawing.Point(3, 608);
            this.loadMoreButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadMoreButton.Name = "loadMoreButton";
            this.loadMoreButton.Size = new System.Drawing.Size(1213, 49);
            this.loadMoreButton.TabIndex = 11;
            this.loadMoreButton.Text = "Load more...";
            this.loadMoreButton.UseVisualStyleBackColor = false;
            this.loadMoreButton.Visible = false;
            this.loadMoreButton.Click += new System.EventHandler(this.loadMoreButton_Click);
            // 
            // Statistics
            // 
            this.Statistics.Controls.Add(this.button1);
            this.Statistics.Controls.Add(this.tableLayoutPanel1);
            this.Statistics.Controls.Add(this.richTextBox1);
            this.Statistics.Location = new System.Drawing.Point(4, 32);
            this.Statistics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Statistics.Name = "Statistics";
            this.Statistics.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Statistics.Size = new System.Drawing.Size(1219, 659);
            this.Statistics.TabIndex = 3;
            this.Statistics.Text = "Statistics";
            this.Statistics.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(692, 303);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(524, 52);
            this.button1.TabIndex = 3;
            this.button1.Text = "Load concordancer";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(683, 655);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 2);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1213, 655);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Concordance
            // 
            this.Concordance.Controls.Add(this.concordancePanel);
            this.Concordance.Controls.Add(this.concordancerButton);
            this.Concordance.Location = new System.Drawing.Point(4, 32);
            this.Concordance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Concordance.Name = "Concordance";
            this.Concordance.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Concordance.Size = new System.Drawing.Size(1219, 659);
            this.Concordance.TabIndex = 4;
            this.Concordance.Text = "Concordance";
            this.Concordance.UseVisualStyleBackColor = true;
            // 
            // concordancePanel
            // 
            this.concordancePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.concordancePanel.Location = new System.Drawing.Point(3, 2);
            this.concordancePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.concordancePanel.Name = "concordancePanel";
            this.concordancePanel.Size = new System.Drawing.Size(1213, 603);
            this.concordancePanel.TabIndex = 3;
            // 
            // concordancerButton
            // 
            this.concordancerButton.BackColor = System.Drawing.Color.Lavender;
            this.concordancerButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.concordancerButton.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.concordancerButton.FlatAppearance.BorderSize = 0;
            this.concordancerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.concordancerButton.Location = new System.Drawing.Point(3, 605);
            this.concordancerButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.concordancerButton.Name = "concordancerButton";
            this.concordancerButton.Size = new System.Drawing.Size(1213, 52);
            this.concordancerButton.TabIndex = 2;
            this.concordancerButton.Text = "Load concordancer";
            this.concordancerButton.UseVisualStyleBackColor = false;
            this.concordancerButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ngramPanel);
            this.tabPage1.Controls.Add(this.ngramButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1219, 659);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "N-gram Search";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ngramPanel
            // 
            this.ngramPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ngramPanel.Location = new System.Drawing.Point(0, 0);
            this.ngramPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ngramPanel.Name = "ngramPanel";
            this.ngramPanel.Size = new System.Drawing.Size(1219, 607);
            this.ngramPanel.TabIndex = 4;
            // 
            // ngramButton
            // 
            this.ngramButton.BackColor = System.Drawing.Color.Lavender;
            this.ngramButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ngramButton.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.ngramButton.FlatAppearance.BorderSize = 0;
            this.ngramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ngramButton.Location = new System.Drawing.Point(0, 607);
            this.ngramButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ngramButton.Name = "ngramButton";
            this.ngramButton.Size = new System.Drawing.Size(1219, 52);
            this.ngramButton.TabIndex = 3;
            this.ngramButton.Text = "Load ngrammer";
            this.ngramButton.UseVisualStyleBackColor = false;
            this.ngramButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.keywordPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1219, 659);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "Keyword Analysis";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // keywordPanel
            // 
            this.keywordPanel.Controls.Add(this.keywordButton);
            this.keywordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keywordPanel.Location = new System.Drawing.Point(0, 0);
            this.keywordPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.keywordPanel.Name = "keywordPanel";
            this.keywordPanel.Size = new System.Drawing.Size(1219, 659);
            this.keywordPanel.TabIndex = 1;
            // 
            // keywordButton
            // 
            this.keywordButton.BackColor = System.Drawing.Color.Lavender;
            this.keywordButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.keywordButton.FlatAppearance.BorderSize = 0;
            this.keywordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keywordButton.Location = new System.Drawing.Point(0, 605);
            this.keywordButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.keywordButton.Name = "keywordButton";
            this.keywordButton.Size = new System.Drawing.Size(1219, 54);
            this.keywordButton.TabIndex = 0;
            this.keywordButton.Text = "Load keyworder";
            this.keywordButton.UseVisualStyleBackColor = false;
            this.keywordButton.Click += new System.EventHandler(this.button3_Click_1);
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
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.searchPanel.Location = new System.Drawing.Point(0, 39);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(304, 729);
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
            this.findButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findButton.Location = new System.Drawing.Point(0, 629);
            this.findButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(304, 39);
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
            this.clearButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.Location = new System.Drawing.Point(0, 590);
            this.clearButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(304, 39);
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
            this.datesPanel.Location = new System.Drawing.Point(0, 517);
            this.datesPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datesPanel.Name = "datesPanel";
            this.datesPanel.RowCount = 2;
            this.datesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.datesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.datesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.datesPanel.Size = new System.Drawing.Size(304, 73);
            this.datesPanel.TabIndex = 23;
            this.datesPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.MinimumSize = new System.Drawing.Size(60, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 36);
            this.label2.TabIndex = 20;
            this.label2.Text = "from";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // startDate
            // 
            this.startDate.Checked = false;
            this.startDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(78, 2);
            this.startDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startDate.MaxDate = new System.DateTime(9998, 1, 1, 0, 0, 0, 0);
            this.startDate.Name = "startDate";
            this.startDate.ShowCheckBox = true;
            this.startDate.Size = new System.Drawing.Size(223, 30);
            this.startDate.TabIndex = 17;
            this.startDate.Value = new System.DateTime(2020, 4, 28, 0, 0, 0, 0);
            // 
            // finishDate
            // 
            this.finishDate.Checked = false;
            this.finishDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.finishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.finishDate.Location = new System.Drawing.Point(78, 38);
            this.finishDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.finishDate.Name = "finishDate";
            this.finishDate.ShowCheckBox = true;
            this.finishDate.Size = new System.Drawing.Size(223, 30);
            this.finishDate.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.MinimumSize = new System.Drawing.Size(40, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 36);
            this.label1.TabIndex = 19;
            this.label1.Text = "to";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dateToggle
            // 
            this.dateToggle.Appearance = System.Windows.Forms.Appearance.Button;
            this.dateToggle.AutoSize = true;
            this.dateToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateToggle.Enabled = false;
            this.dateToggle.FlatAppearance.BorderSize = 0;
            this.dateToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dateToggle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateToggle.Location = new System.Drawing.Point(0, 478);
            this.dateToggle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateToggle.MinimumSize = new System.Drawing.Size(0, 39);
            this.dateToggle.Name = "dateToggle";
            this.dateToggle.Size = new System.Drawing.Size(304, 39);
            this.dateToggle.TabIndex = 28;
            this.dateToggle.Text = "Select Dates Toggle";
            this.dateToggle.UseVisualStyleBackColor = true;
            this.dateToggle.CheckedChanged += new System.EventHandler(this.datesToggle_CheckedChanged);
            // 
            // userPanel
            // 
            this.userPanel.Controls.Add(this.userList);
            this.userPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.userPanel.Location = new System.Drawing.Point(0, 196);
            this.userPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(304, 282);
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
            this.userList.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userList.FullRowSelect = true;
            this.userList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.userList.HideSelection = false;
            this.userList.Location = new System.Drawing.Point(0, 0);
            this.userList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(304, 282);
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
            this.userToggle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userToggle.Location = new System.Drawing.Point(0, 157);
            this.userToggle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userToggle.MinimumSize = new System.Drawing.Size(0, 39);
            this.userToggle.Name = "userToggle";
            this.userToggle.Size = new System.Drawing.Size(304, 39);
            this.userToggle.TabIndex = 27;
            this.userToggle.Text = "Select Users Toggle";
            this.userToggle.UseVisualStyleBackColor = true;
            this.userToggle.CheckedChanged += new System.EventHandler(this.userToggle_CheckedChanged);
            // 
            // queryPanel
            // 
            this.queryPanel.Controls.Add(this.label3);
            this.queryPanel.Controls.Add(this.searchBox);
            this.queryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.queryPanel.Location = new System.Drawing.Point(0, 39);
            this.queryPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.queryPanel.Name = "queryPanel";
            this.queryPanel.Size = new System.Drawing.Size(304, 118);
            this.queryPanel.TabIndex = 20;
            this.queryPanel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(0, 49);
            this.label3.MaximumSize = new System.Drawing.Size(303, 0);
            this.label3.MinimumSize = new System.Drawing.Size(0, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 60);
            this.label3.TabIndex = 16;
            this.label3.Text = "Hint: \"wikipedia page\" ~2 will search for \"wikipedia\" and \"page\" two words apart " +
    "from each other";
            // 
            // searchBox
            // 
            this.searchBox.AutoWordSelection = true;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBox.Font = new System.Drawing.Font("Segoe UI", 10.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchBox.Location = new System.Drawing.Point(0, 0);
            this.searchBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(304, 49);
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
            this.queryButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.queryButton.Location = new System.Drawing.Point(0, 0);
            this.queryButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.queryButton.MinimumSize = new System.Drawing.Size(0, 39);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(304, 39);
            this.queryButton.TabIndex = 19;
            this.queryButton.Text = "Query";
            this.queryButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.messageLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(304, 734);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1225, 34);
            this.panel1.TabIndex = 25;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.messageLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageLabel.Location = new System.Drawing.Point(1129, 0);
            this.messageLabel.MinimumSize = new System.Drawing.Size(0, 30);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(96, 30);
            this.messageLabel.TabIndex = 24;
            this.messageLabel.Text = "Not loaded";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.messageLabel.Click += new System.EventHandler(this.messageLabel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.vizToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MinimumSize = new System.Drawing.Size(0, 39);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1529, 39);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadCorpusToolStripMenuItem,
            this.openCorpusToolStripMenuItem,
            this.extractToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(49, 35);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadCorpusToolStripMenuItem
            // 
            this.loadCorpusToolStripMenuItem.Name = "loadCorpusToolStripMenuItem";
            this.loadCorpusToolStripMenuItem.Size = new System.Drawing.Size(199, 28);
            this.loadCorpusToolStripMenuItem.Text = "Index new file";
            this.loadCorpusToolStripMenuItem.Click += new System.EventHandler(this.loadCorpusToolStripMenuItem_Click);
            // 
            // openCorpusToolStripMenuItem
            // 
            this.openCorpusToolStripMenuItem.Name = "openCorpusToolStripMenuItem";
            this.openCorpusToolStripMenuItem.Size = new System.Drawing.Size(199, 28);
            this.openCorpusToolStripMenuItem.Text = "Open corpus";
            this.openCorpusToolStripMenuItem.Click += new System.EventHandler(this.openCorpusToolStripMenuItem_Click);
            // 
            // extractToolStripMenuItem
            // 
            this.extractToolStripMenuItem.Name = "extractToolStripMenuItem";
            this.extractToolStripMenuItem.Size = new System.Drawing.Size(199, 28);
            this.extractToolStripMenuItem.Text = "Extract...";
            this.extractToolStripMenuItem.Click += new System.EventHandler(this.extractToolStripMenuItem_Click);
            // 
            // vizToolStripMenuItem
            // 
            this.vizToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plotToolStripMenuItem,
            this.heatmapToolStripMenuItem});
            this.vizToolStripMenuItem.Name = "vizToolStripMenuItem";
            this.vizToolStripMenuItem.Size = new System.Drawing.Size(90, 35);
            this.vizToolStripMenuItem.Text = "Visualize";
            // 
            // plotToolStripMenuItem
            // 
            this.plotToolStripMenuItem.Name = "plotToolStripMenuItem";
            this.plotToolStripMenuItem.Size = new System.Drawing.Size(164, 28);
            this.plotToolStripMenuItem.Text = "Plot";
            this.plotToolStripMenuItem.Click += new System.EventHandler(this.plotToolStripMenuItem_Click);
            // 
            // heatmapToolStripMenuItem
            // 
            this.heatmapToolStripMenuItem.Name = "heatmapToolStripMenuItem";
            this.heatmapToolStripMenuItem.Size = new System.Drawing.Size(164, 28);
            this.heatmapToolStripMenuItem.Text = "Heatmap";
            this.heatmapToolStripMenuItem.Click += new System.EventHandler(this.heatmapToolStripMenuItem_Click);
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
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(1317, 4);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(212, 36);
            this.button2.TabIndex = 29;
            this.button2.Text = "Start tagging";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1529, 768);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(tabControl1);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Chat Corpora Annotator";
            tabControl1.ResumeLayout(false);
            this.Chat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chatTable)).EndInit();
            this.Statistics.ResumeLayout(false);
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
            this.queryPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Button loadMoreButton;
        private BrightIdeasSoftware.FastObjectListView chatTable;
        private System.Windows.Forms.ListView dateView;
        private System.Windows.Forms.ColumnHeader Days;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TabPage Statistics;
        private System.Windows.Forms.TabPage Concordance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.CheckBox dateToggle;
        private System.Windows.Forms.CheckBox userToggle;
        private System.Windows.Forms.ListView userList;
        private System.Windows.Forms.ColumnHeader Users;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem;
    }
}

