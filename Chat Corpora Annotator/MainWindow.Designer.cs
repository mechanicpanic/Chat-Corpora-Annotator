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
            this.chatTable = new BrightIdeasSoftware.FastObjectListView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chatTable)).BeginInit();
            this.SuspendLayout();
            // 
            // csvLoadButton
            // 
            this.csvLoadButton.Location = new System.Drawing.Point(10, 11);
            this.csvLoadButton.Margin = new System.Windows.Forms.Padding(2);
            this.csvLoadButton.Name = "csvLoadButton";
            this.csvLoadButton.Size = new System.Drawing.Size(102, 37);
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
            // chatTable
            // 
            this.chatTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatTable.CellEditUseWholeCell = false;
            this.chatTable.FullRowSelect = true;
            this.chatTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.chatTable.HideSelection = false;
            this.chatTable.Location = new System.Drawing.Point(117, 12);
            this.chatTable.Name = "chatTable";
            this.chatTable.RowHeight = 32;
            this.chatTable.ShowGroups = false;
            this.chatTable.Size = new System.Drawing.Size(509, 309);
            this.chatTable.TabIndex = 1;
            this.chatTable.TintSortColumn = true;
            this.chatTable.UseCompatibleStateImageBehavior = false;
            this.chatTable.View = System.Windows.Forms.View.Details;
            this.chatTable.VirtualMode = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 64);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "load .txt";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 333);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chatTable);
            this.Controls.Add(this.csvLoadButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainWindow";
            this.Text = "Chat Corpora Annotator";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chatTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button csvLoadButton;
        private System.Windows.Forms.OpenFileDialog csvDialog;
        private BrightIdeasSoftware.FastObjectListView chatTable;
        private System.Windows.Forms.Button button1;
    }
}

