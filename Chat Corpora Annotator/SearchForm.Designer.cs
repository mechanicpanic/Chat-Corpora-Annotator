namespace Chat_Corpora_Annotator
{
    partial class SearchForm
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
            this.searchTable = new BrightIdeasSoftware.FastObjectListView();
            this.searchBox = new System.Windows.Forms.RichTextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.fastObjectListView2 = new BrightIdeasSoftware.FastObjectListView();
            ((System.ComponentModel.ISupportInitialize)(this.searchTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView2)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTable
            // 
            this.searchTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTable.CellEditUseWholeCell = false;
            this.searchTable.HideSelection = false;
            this.searchTable.Location = new System.Drawing.Point(256, 12);
            this.searchTable.Name = "searchTable";
            this.searchTable.RowHeight = 48;
            this.searchTable.ShowGroups = false;
            this.searchTable.Size = new System.Drawing.Size(642, 390);
            this.searchTable.TabIndex = 1;
            this.searchTable.UseCompatibleStateImageBehavior = false;
            this.searchTable.View = System.Windows.Forms.View.Details;
            this.searchTable.VirtualMode = true;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(12, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(237, 75);
            this.searchBox.TabIndex = 2;
            this.searchBox.Text = "";
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(13, 94);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(237, 42);
            this.findButton.TabIndex = 3;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // fastObjectListView2
            // 
            this.fastObjectListView2.BackColor = System.Drawing.SystemColors.Menu;
            this.fastObjectListView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fastObjectListView2.CellEditUseWholeCell = false;
            this.fastObjectListView2.HideSelection = false;
            this.fastObjectListView2.Location = new System.Drawing.Point(51, 142);
            this.fastObjectListView2.Name = "fastObjectListView2";
            this.fastObjectListView2.ShowGroups = false;
            this.fastObjectListView2.Size = new System.Drawing.Size(153, 259);
            this.fastObjectListView2.TabIndex = 4;
            this.fastObjectListView2.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView2.View = System.Windows.Forms.View.Details;
            this.fastObjectListView2.VirtualMode = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 414);
            this.Controls.Add(this.fastObjectListView2);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.searchTable);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SearchForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.searchTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView searchTable;
        private System.Windows.Forms.RichTextBox searchBox;
        private System.Windows.Forms.Button findButton;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView2;
    }
}