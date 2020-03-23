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
            this.heatMapButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.dateView = new System.Windows.Forms.ListView();
            this.Day = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chatTable = new BrightIdeasSoftware.FastObjectListView();
            this.indexDialog = new System.Windows.Forms.FolderBrowserDialog();
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
            this.button2.Click += new System.EventHandler(this.chartButton_Click);
            // 
            // heatMapButton
            // 
            this.heatMapButton.Location = new System.Drawing.Point(34, 135);
            this.heatMapButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.heatMapButton.Name = "heatMapButton";
            this.heatMapButton.Size = new System.Drawing.Size(136, 46);
            this.heatMapButton.TabIndex = 5;
            this.heatMapButton.Text = "Heatmap";
            this.heatMapButton.UseVisualStyleBackColor = true;
            this.heatMapButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(33, 199);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(136, 46);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateView
            // 
            this.dateView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Day});
            this.dateView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.dateView.HideSelection = false;
            this.dateView.Location = new System.Drawing.Point(12, 275);
            this.dateView.MultiSelect = false;
            this.dateView.Name = "dateView";
            this.dateView.Size = new System.Drawing.Size(188, 340);
            this.dateView.TabIndex = 8;
            this.dateView.UseCompatibleStateImageBehavior = false;
            this.dateView.View = System.Windows.Forms.View.Details;
            this.dateView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // Day
            // 
            this.Day.Text = "Days";
            this.Day.Width = 184;
            // 
            // chatTable
            // 
            this.chatTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatTable.CellEditUseWholeCell = false;
            this.chatTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chatTable.FullRowSelect = true;
            this.chatTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.chatTable.HideSelection = false;
            this.chatTable.Location = new System.Drawing.Point(221, 11);
            this.chatTable.Name = "chatTable";
            this.chatTable.RowHeight = 48;
            this.chatTable.ShowGroups = false;
            this.chatTable.Size = new System.Drawing.Size(1000, 600);
            this.chatTable.TabIndex = 9;
            this.chatTable.UseCellFormatEvents = true;
            this.chatTable.UseCompatibleStateImageBehavior = false;
            this.chatTable.View = System.Windows.Forms.View.Details;
            this.chatTable.VirtualMode = true;
            this.chatTable.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.ChatTable_FormatCell);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 630);
            this.Controls.Add(this.chatTable);
            this.Controls.Add(this.dateView);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.heatMapButton);
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
        private System.Windows.Forms.Button heatMapButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListView dateView;
        private System.Windows.Forms.ColumnHeader Day;
        private BrightIdeasSoftware.FastObjectListView chatTable;
        private System.Windows.Forms.FolderBrowserDialog indexDialog;
    }
}

