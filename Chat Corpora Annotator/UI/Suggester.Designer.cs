namespace Viewer.UI
{
    partial class Suggester
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
            this.sidePanel = new System.Windows.Forms.Panel();
            this.queryBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.findButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listButton = new System.Windows.Forms.Button();
            this.deleteListButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listContents = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.operatorPanel = new System.Windows.Forms.TableLayoutPanel();
            this.button8 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.suggLabel = new System.Windows.Forms.Label();
            this.groupsLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.boolPanel = new System.Windows.Forms.TableLayoutPanel();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.suggesterView = new BrightIdeasSoftware.FastObjectListView();
            this.queryPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.switchModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.sidePanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.operatorPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.boolPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suggesterView)).BeginInit();
            this.panel6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.Lavender;
            this.sidePanel.Controls.Add(this.label4);
            this.sidePanel.Controls.Add(this.label3);
            this.sidePanel.Controls.Add(this.controlPanel);
            this.sidePanel.Controls.Add(this.suggLabel);
            this.sidePanel.Controls.Add(this.groupsLabel);
            this.sidePanel.Controls.Add(this.panel3);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(400, 673);
            this.sidePanel.TabIndex = 1;
            // 
            // queryBox
            // 
            this.queryBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.queryBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.queryBox.Location = new System.Drawing.Point(0, 0);
            this.queryBox.Margin = new System.Windows.Forms.Padding(2);
            this.queryBox.Name = "queryBox";
            this.queryBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.queryBox.Size = new System.Drawing.Size(901, 140);
            this.queryBox.TabIndex = 6;
            this.queryBox.Text = "";
            this.queryBox.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 492);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 472);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 21;
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.findButton);
            this.controlPanel.Controls.Add(this.listView1);
            this.controlPanel.Controls.Add(this.tableLayoutPanel2);
            this.controlPanel.Controls.Add(this.panel4);
            this.controlPanel.Controls.Add(this.operatorPanel);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(0, 30);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(400, 587);
            this.controlPanel.TabIndex = 14;
            // 
            // findButton
            // 
            this.findButton.BackColor = System.Drawing.Color.Pink;
            this.findButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.findButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.findButton.FlatAppearance.BorderSize = 0;
            this.findButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findButton.Location = new System.Drawing.Point(0, 443);
            this.findButton.Margin = new System.Windows.Forms.Padding(2);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(400, 45);
            this.findButton.TabIndex = 7;
            this.findButton.Text = "Find suggestions...";
            this.findButton.UseVisualStyleBackColor = false;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.listButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.deleteListButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 182);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(400, 45);
            this.tableLayoutPanel2.TabIndex = 25;
            // 
            // listButton
            // 
            this.listButton.BackColor = System.Drawing.Color.Lavender;
            this.listButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.listButton.FlatAppearance.BorderSize = 0;
            this.listButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listButton.Location = new System.Drawing.Point(2, 2);
            this.listButton.Margin = new System.Windows.Forms.Padding(2);
            this.listButton.Name = "listButton";
            this.listButton.Size = new System.Drawing.Size(196, 41);
            this.listButton.TabIndex = 8;
            this.listButton.Text = "Add dictionary";
            this.listButton.UseVisualStyleBackColor = false;
            this.listButton.Click += new System.EventHandler(this.listButton_Click);
            // 
            // deleteListButton
            // 
            this.deleteListButton.BackColor = System.Drawing.Color.Lavender;
            this.deleteListButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteListButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.deleteListButton.FlatAppearance.BorderSize = 0;
            this.deleteListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteListButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteListButton.Location = new System.Drawing.Point(202, 2);
            this.deleteListButton.Margin = new System.Windows.Forms.Padding(2);
            this.deleteListButton.Name = "deleteListButton";
            this.deleteListButton.Size = new System.Drawing.Size(196, 41);
            this.deleteListButton.TabIndex = 9;
            this.deleteListButton.Text = "Delete dictionary";
            this.deleteListButton.UseVisualStyleBackColor = false;
            this.deleteListButton.Click += new System.EventHandler(this.deleteListButton_Click);
            this.deleteListButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.operator_MouseClick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listName,
            this.listContents});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 227);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(400, 216);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // listName
            // 
            this.listName.Text = "Name";
            this.listName.Width = 74;
            // 
            // listContents
            // 
            this.listContents.Text = "Contents";
            this.listContents.Width = 416;
            // 
            // operatorPanel
            // 
            this.operatorPanel.ColumnCount = 2;
            this.operatorPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.operatorPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.operatorPanel.Controls.Add(this.button8, 0, 3);
            this.operatorPanel.Controls.Add(this.button5, 1, 0);
            this.operatorPanel.Controls.Add(this.button4, 1, 3);
            this.operatorPanel.Controls.Add(this.button12, 1, 1);
            this.operatorPanel.Controls.Add(this.button3, 0, 1);
            this.operatorPanel.Controls.Add(this.button6, 1, 2);
            this.operatorPanel.Controls.Add(this.button9, 0, 2);
            this.operatorPanel.Controls.Add(this.button11, 0, 0);
            this.operatorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.operatorPanel.Location = new System.Drawing.Point(0, 0);
            this.operatorPanel.Name = "operatorPanel";
            this.operatorPanel.RowCount = 4;
            this.operatorPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.operatorPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.operatorPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.operatorPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.operatorPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.operatorPanel.Size = new System.Drawing.Size(400, 134);
            this.operatorPanel.TabIndex = 24;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Lavender;
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button8.Location = new System.Drawing.Point(3, 102);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(194, 29);
            this.button8.TabIndex = 23;
            this.button8.Text = "inwin";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.operator_Click);
            this.button8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Lavender;
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button5.Location = new System.Drawing.Point(203, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(194, 27);
            this.button5.TabIndex = 21;
            this.button5.Text = "hasorganization()";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.operator_Click);
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Lavender;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button4.Location = new System.Drawing.Point(203, 102);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(194, 29);
            this.button4.TabIndex = 20;
            this.button4.Text = "hasdate()";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.operator_Click);
            this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Lavender;
            this.button12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button12.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button12.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button12.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button12.Location = new System.Drawing.Point(203, 36);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(194, 27);
            this.button12.TabIndex = 18;
            this.button12.Text = "hastime()";
            this.button12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.operator_Click);
            this.button12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lavender;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button3.Location = new System.Drawing.Point(3, 36);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(194, 27);
            this.button3.TabIndex = 19;
            this.button3.Text = "hasusermentioned()";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Lavender;
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button6.Location = new System.Drawing.Point(203, 69);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(194, 27);
            this.button6.TabIndex = 22;
            this.button6.Text = "haslocation()";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.operator_Click);
            this.button6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Lavender;
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button9.Location = new System.Drawing.Point(3, 69);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(194, 27);
            this.button9.TabIndex = 12;
            this.button9.Text = "byuser()";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.operator_Click);
            this.button9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Lavender;
            this.button11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button11.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button11.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button11.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button11.Location = new System.Drawing.Point(3, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(194, 27);
            this.button11.TabIndex = 17;
            this.button11.Text = "haswordofdict()";
            this.button11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.operator_Click);
            this.button11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // suggLabel
            // 
            this.suggLabel.AutoSize = true;
            this.suggLabel.Location = new System.Drawing.Point(2, 631);
            this.suggLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.suggLabel.Name = "suggLabel";
            this.suggLabel.Size = new System.Drawing.Size(125, 16);
            this.suggLabel.TabIndex = 20;
            this.suggLabel.Text = "Found suggestions:";
            this.suggLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupsLabel
            // 
            this.groupsLabel.AutoSize = true;
            this.groupsLabel.Location = new System.Drawing.Point(2, 647);
            this.groupsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.groupsLabel.Name = "groupsLabel";
            this.groupsLabel.Size = new System.Drawing.Size(94, 16);
            this.groupsLabel.TabIndex = 19;
            this.groupsLabel.Text = "Found groups:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.boolPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 30);
            this.panel3.TabIndex = 15;
            // 
            // boolPanel
            // 
            this.boolPanel.ColumnCount = 9;
            this.boolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.boolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.boolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.boolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.boolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.boolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.75F));
            this.boolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.75F));
            this.boolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.75F));
            this.boolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.75F));
            this.boolPanel.Controls.Add(this.button20, 0, 0);
            this.boolPanel.Controls.Add(this.button19, 0, 0);
            this.boolPanel.Controls.Add(this.button18, 0, 0);
            this.boolPanel.Controls.Add(this.button17, 0, 0);
            this.boolPanel.Controls.Add(this.button16, 0, 0);
            this.boolPanel.Controls.Add(this.button15, 0, 0);
            this.boolPanel.Controls.Add(this.button14, 0, 0);
            this.boolPanel.Controls.Add(this.button13, 0, 0);
            this.boolPanel.Controls.Add(this.button10, 0, 0);
            this.boolPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boolPanel.Location = new System.Drawing.Point(0, 0);
            this.boolPanel.Name = "boolPanel";
            this.boolPanel.RowCount = 1;
            this.boolPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.boolPanel.Size = new System.Drawing.Size(400, 30);
            this.boolPanel.TabIndex = 0;
            this.boolPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.Lavender;
            this.button20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button20.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button20.ForeColor = System.Drawing.Color.Crimson;
            this.button20.Location = new System.Drawing.Point(286, 3);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(33, 24);
            this.button20.TabIndex = 26;
            this.button20.Text = ";";
            this.button20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button20.UseVisualStyleBackColor = false;
            this.button20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.Lavender;
            this.button19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button19.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button19.ForeColor = System.Drawing.Color.Crimson;
            this.button19.Location = new System.Drawing.Point(247, 3);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(33, 24);
            this.button19.TabIndex = 25;
            this.button19.Text = ",";
            this.button19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button19.UseVisualStyleBackColor = false;
            this.button19.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.Lavender;
            this.button18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button18.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button18.ForeColor = System.Drawing.Color.Crimson;
            this.button18.Location = new System.Drawing.Point(364, 3);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(33, 24);
            this.button18.TabIndex = 24;
            this.button18.Text = ")";
            this.button18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button18.UseVisualStyleBackColor = false;
            this.button18.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Lavender;
            this.button17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button17.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button17.ForeColor = System.Drawing.Color.Crimson;
            this.button17.Location = new System.Drawing.Point(325, 3);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(33, 24);
            this.button17.TabIndex = 23;
            this.button17.Text = "(";
            this.button17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.operator_Click);
            this.button17.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Lavender;
            this.button16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button16.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button16.ForeColor = System.Drawing.Color.Crimson;
            this.button16.Location = new System.Drawing.Point(203, 3);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(38, 24);
            this.button16.TabIndex = 22;
            this.button16.Text = "num";
            this.button16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.operator_Click);
            this.button16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Lavender;
            this.button15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button15.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button15.ForeColor = System.Drawing.Color.Crimson;
            this.button15.Location = new System.Drawing.Point(71, 3);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(38, 24);
            this.button15.TabIndex = 21;
            this.button15.Text = "and";
            this.button15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.operator_Click);
            this.button15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Lavender;
            this.button14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button14.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button14.ForeColor = System.Drawing.Color.Crimson;
            this.button14.Location = new System.Drawing.Point(3, 3);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(62, 24);
            this.button14.TabIndex = 20;
            this.button14.Text = "select";
            this.button14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.operator_Click);
            this.button14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Lavender;
            this.button13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button13.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button13.ForeColor = System.Drawing.Color.Crimson;
            this.button13.Location = new System.Drawing.Point(159, 3);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(38, 24);
            this.button13.TabIndex = 19;
            this.button13.Text = "not";
            this.button13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.operator_Click);
            this.button13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Lavender;
            this.button10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button10.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button10.ForeColor = System.Drawing.Color.Crimson;
            this.button10.Location = new System.Drawing.Point(115, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(38, 24);
            this.button10.TabIndex = 18;
            this.button10.Text = "or";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.operator_Click);
            this.button10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operator_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel2.Location = new System.Drawing.Point(400, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(901, 140);
            this.panel2.TabIndex = 2;
            // 
            // suggesterView
            // 
            this.suggesterView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.suggesterView.CellEditUseWholeCell = false;
            this.suggesterView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suggesterView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.suggesterView.FullRowSelect = true;
            this.suggesterView.HideSelection = false;
            this.suggesterView.Location = new System.Drawing.Point(400, 164);
            this.suggesterView.Margin = new System.Windows.Forms.Padding(2);
            this.suggesterView.Name = "suggesterView";
            this.suggesterView.RowHeight = 48;
            this.suggesterView.ShowGroups = false;
            this.suggesterView.Size = new System.Drawing.Size(901, 467);
            this.suggesterView.TabIndex = 0;
            this.suggesterView.UseCompatibleStateImageBehavior = false;
            this.suggesterView.UseHotItem = true;
            this.suggesterView.View = System.Windows.Forms.View.Details;
            this.suggesterView.VirtualMode = true;
            this.suggesterView.ItemActivate += new System.EventHandler(this.fastObjectListView1_ItemActivate);
            this.suggesterView.DoubleClick += new System.EventHandler(this.fastObjectListView1_DoubleClick);
            this.suggesterView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fastObjectListView1_MouseDoubleClick);
            // 
            // queryPanel
            // 
            this.queryPanel.AllowDrop = true;
            this.queryPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.queryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryPanel.Location = new System.Drawing.Point(0, 0);
            this.queryPanel.Name = "queryPanel";
            this.queryPanel.Size = new System.Drawing.Size(901, 140);
            this.queryPanel.TabIndex = 1;
            this.queryPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowLayoutPanel1_DragDrop);
            this.queryPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowLayoutPanel1_DragEnter);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(611, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(290, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "Next suggestion >";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button2_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lavender;
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(287, 42);
            this.button2.TabIndex = 4;
            this.button2.Text = "< Previous suggestion";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button2);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel6.Location = new System.Drawing.Point(400, 631);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(901, 42);
            this.panel6.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchModeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(400, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(901, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // switchModeToolStripMenuItem
            // 
            this.switchModeToolStripMenuItem.Name = "switchModeToolStripMenuItem";
            this.switchModeToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.switchModeToolStripMenuItem.Text = "Switch Mode";
            this.switchModeToolStripMenuItem.Click += new System.EventHandler(this.switchModeToolStripMenuItem_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.queryBox);
            this.panel1.Controls.Add(this.queryPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 140);
            this.panel1.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 134);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(400, 48);
            this.panel4.TabIndex = 26;
            // 
            // Suggester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1301, 673);
            this.Controls.Add(this.suggesterView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.sidePanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Suggester";
            this.Text = "Suggester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Suggester_FormClosing);
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.operatorPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.boolPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.suggesterView)).EndInit();
            this.panel6.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox queryBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button deleteListButton;
        private System.Windows.Forms.Button listButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader listName;
        private System.Windows.Forms.ColumnHeader listContents;
        private BrightIdeasSoftware.FastObjectListView suggesterView;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label suggLabel;
        private System.Windows.Forms.Label groupsLabel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel operatorPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel boolPanel;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.FlowLayoutPanel queryPanel;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem switchModeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel panel4;
    }
}