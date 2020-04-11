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
            this.listView1 = new System.Windows.Forms.ListView();
            this.Users = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.searchTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView2)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTable
            // 
            this.searchTable.AllowDrop = true;
            this.searchTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTable.CellEditUseWholeCell = false;
            this.searchTable.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTable.HideSelection = false;
            this.searchTable.Location = new System.Drawing.Point(214, 12);
            this.searchTable.Name = "searchTable";
            this.searchTable.RowHeight = 48;
            this.searchTable.ShowGroups = false;
            this.searchTable.Size = new System.Drawing.Size(1000, 600);
            this.searchTable.TabIndex = 1;
            this.searchTable.UseCompatibleStateImageBehavior = false;
            this.searchTable.View = System.Windows.Forms.View.Details;
            this.searchTable.VirtualMode = true;
            this.searchTable.Resize += new System.EventHandler(this.searchTable_Resize);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchBox.HideSelection = false;
            this.searchBox.Location = new System.Drawing.Point(20, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(175, 117);
            this.searchBox.TabIndex = 2;
            this.searchBox.TabStop = false;
            this.searchBox.Text = "Enter query...";
            this.searchBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.searchBox_MouseClick);
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // findButton
            // 
            this.findButton.FlatAppearance.BorderSize = 0;
            this.findButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findButton.Location = new System.Drawing.Point(20, 570);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(175, 42);
            this.findButton.TabIndex = 3;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // fastObjectListView2
            // 
            this.fastObjectListView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fastObjectListView2.CellEditUseWholeCell = false;
            this.fastObjectListView2.HideSelection = false;
            this.fastObjectListView2.Location = new System.Drawing.Point(1210, 12);
            this.fastObjectListView2.Name = "fastObjectListView2";
            this.fastObjectListView2.ShowGroups = false;
            this.fastObjectListView2.Size = new System.Drawing.Size(170, 600);
            this.fastObjectListView2.TabIndex = 1;
            this.fastObjectListView2.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView2.View = System.Windows.Forms.View.Details;
            this.fastObjectListView2.VirtualMode = true;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Users});
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(20, 135);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(175, 429);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Users
            // 
            this.Users.Text = "Users";
            this.Users.Width = 170;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1382, 653);
            this.Controls.Add(this.listView1);
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Users;
    }
}