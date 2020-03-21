namespace Chat_Corpora_Annotator
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
            this.csvLoadButton = new System.Windows.Forms.Button();
            this.csvDialog = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Day = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chatTable = new BrightIdeasSoftware.FastObjectListView();
            ((System.ComponentModel.ISupportInitialize)(this.chatTable)).BeginInit();
            this.SuspendLayout();
            // 
            // csvLoadButton
            // 
            this.csvLoadButton.Location = new System.Drawing.Point(34, 14);
            this.csvLoadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.csvLoadButton.Name = "csvLoadButton";
            this.csvLoadButton.Size = new System.Drawing.Size(136, 46);
            this.csvLoadButton.TabIndex = 0;
            this.csvLoadButton.Text = "load .csv";
            this.csvLoadButton.UseVisualStyleBackColor = true;
            this.csvLoadButton.Click += new System.EventHandler(this.csvLoadButton_Click);
            // 
            // csvDialog
            // 
            this.csvDialog.FileName = "csvDialog";
            this.csvDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.csvDialog_FileOk);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(33, 75);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 46);
            this.button2.TabIndex = 3;
            this.button2.Text = "Plot";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(34, 135);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 46);
            this.button3.TabIndex = 5;
            this.button3.Text = "Heatmap";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 199);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 46);
            this.button1.TabIndex = 7;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Day});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 263);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(188, 352);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // Day
            // 
            this.Day.Text = "Days";
            this.Day.Width = 184;
            // 
            // chatTable
            // 
            this.chatTable.CellEditUseWholeCell = false;
            this.chatTable.HideSelection = false;
            this.chatTable.Location = new System.Drawing.Point(229, 14);
            this.chatTable.Name = "chatTable";
            this.chatTable.ShowGroups = false;
            this.chatTable.Size = new System.Drawing.Size(994, 604);
            this.chatTable.TabIndex = 9;
            this.chatTable.UseCompatibleStateImageBehavior = false;
            this.chatTable.View = System.Windows.Forms.View.Details;
            this.chatTable.VirtualMode = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 630);
            this.Controls.Add(this.chatTable);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.csvLoadButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Chat Corpora Annotator";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chatTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button csvLoadButton;
        private System.Windows.Forms.OpenFileDialog csvDialog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Day;
        private BrightIdeasSoftware.FastObjectListView chatTable;
    }
}

