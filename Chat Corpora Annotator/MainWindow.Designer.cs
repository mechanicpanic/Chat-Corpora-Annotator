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
            this.chatTable = new BrightIdeasSoftware.FastObjectListView();
            this.indexDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.loadMoreButton = new System.Windows.Forms.Button();
            this.dateView = new System.Windows.Forms.ListView();
            this.Days = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.chatTable)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // csvLoadButton
            // 
            this.csvLoadButton.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.csvLoadButton.FlatAppearance.BorderSize = 0;
            this.csvLoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.csvLoadButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.csvLoadButton.Location = new System.Drawing.Point(0, 59);
            this.csvLoadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.csvLoadButton.Name = "csvLoadButton";
            this.csvLoadButton.Size = new System.Drawing.Size(200, 46);
            this.csvLoadButton.TabIndex = 0;
            this.csvLoadButton.Text = "load .csv";
            this.csvLoadButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(0, 157);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 46);
            this.button2.TabIndex = 3;
            this.button2.Text = "Plot";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.chartButton_Click);
            // 
            // heatMapButton
            // 
            this.heatMapButton.FlatAppearance.BorderSize = 0;
            this.heatMapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.heatMapButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heatMapButton.Location = new System.Drawing.Point(0, 107);
            this.heatMapButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.heatMapButton.Name = "heatMapButton";
            this.heatMapButton.Size = new System.Drawing.Size(200, 46);
            this.heatMapButton.TabIndex = 5;
            this.heatMapButton.Text = "Heatmap";
            this.heatMapButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.heatMapButton.UseVisualStyleBackColor = true;
            this.heatMapButton.Click += new System.EventHandler(this.heatMapButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchButton.Location = new System.Drawing.Point(0, 207);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(200, 46);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search";
            this.searchButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // chatTable
            // 
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
            this.chatTable.Location = new System.Drawing.Point(200, 11);
            this.chatTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chatTable.Name = "chatTable";
            this.chatTable.RowHeight = 52;
            this.chatTable.ShowGroups = false;
            this.chatTable.Size = new System.Drawing.Size(1000, 600);
            this.chatTable.TabIndex = 9;
            this.chatTable.UseCellFormatEvents = true;
            this.chatTable.UseCompatibleStateImageBehavior = false;
            this.chatTable.View = System.Windows.Forms.View.Details;
            this.chatTable.VirtualMode = true;
            this.chatTable.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.ChatTable_FormatCell);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.heatMapButton);
            this.panel1.Controls.Add(this.csvLoadButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 653);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 23);
            this.label1.TabIndex = 8;
            // 
            // loadMoreButton
            // 
            this.loadMoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadMoreButton.FlatAppearance.BorderSize = 0;
            this.loadMoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadMoreButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadMoreButton.Location = new System.Drawing.Point(200, 618);
            this.loadMoreButton.Name = "loadMoreButton";
            this.loadMoreButton.Size = new System.Drawing.Size(1182, 39);
            this.loadMoreButton.TabIndex = 11;
            this.loadMoreButton.Text = "Load more...";
            this.loadMoreButton.UseVisualStyleBackColor = true;
            this.loadMoreButton.Click += new System.EventHandler(this.loadMoreButton_Click);
            // 
            // dateView
            // 
            this.dateView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dateView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Days});
            this.dateView.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateView.HideSelection = false;
            this.dateView.Location = new System.Drawing.Point(1200, 11);
            this.dateView.Name = "dateView";
            this.dateView.Size = new System.Drawing.Size(170, 600);
            this.dateView.TabIndex = 12;
            this.dateView.UseCompatibleStateImageBehavior = false;
            this.dateView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.dateView_RetrieveVirtualItem);
            this.dateView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dateView_MouseDoubleClick);
            // 
            // Days
            // 
            this.Days.Text = "Active dates";
            this.Days.Width = 115;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1382, 653);
            this.Controls.Add(this.dateView);
            this.Controls.Add(this.loadMoreButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chatTable);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Chat Corpora Annotator";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chatTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button csvLoadButton;
        private System.Windows.Forms.OpenFileDialog csvDialog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button heatMapButton;
        private System.Windows.Forms.Button searchButton;
        private BrightIdeasSoftware.FastObjectListView chatTable;
        private System.Windows.Forms.FolderBrowserDialog indexDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadMoreButton;
        private System.Windows.Forms.ListView dateView;
        private System.Windows.Forms.ColumnHeader Days;
    }
}

