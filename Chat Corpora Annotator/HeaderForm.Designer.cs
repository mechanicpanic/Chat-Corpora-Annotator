namespace Chat_Corpora_Annotator
{
    partial class HeaderForm
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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.fieldButton = new System.Windows.Forms.Button();
            this.csvListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.clearAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selected columns:";
            // 
            // selectedListBox
            // 
            this.selectedListBox.AllowDrop = true;
            this.selectedListBox.BackColor = System.Drawing.SystemColors.Window;
            this.selectedListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedListBox.FormattingEnabled = true;
            this.selectedListBox.ItemHeight = 18;
            this.selectedListBox.Location = new System.Drawing.Point(325, 35);
            this.selectedListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectedListBox.Name = "selectedListBox";
            this.selectedListBox.Size = new System.Drawing.Size(186, 272);
            this.selectedListBox.TabIndex = 4;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(228, 122);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(72, 32);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "=>";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // fieldButton
            // 
            this.fieldButton.Location = new System.Drawing.Point(532, 54);
            this.fieldButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fieldButton.Name = "fieldButton";
            this.fieldButton.Size = new System.Drawing.Size(112, 32);
            this.fieldButton.TabIndex = 7;
            this.fieldButton.Text = "Upload";
            this.fieldButton.UseVisualStyleBackColor = true;
            this.fieldButton.Click += new System.EventHandler(this.fieldButton_Click);
            // 
            // csvListBox
            // 
            this.csvListBox.AllowDrop = true;
            this.csvListBox.BackColor = System.Drawing.SystemColors.Window;
            this.csvListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.csvListBox.FormattingEnabled = true;
            this.csvListBox.ItemHeight = 18;
            this.csvListBox.Location = new System.Drawing.Point(18, 35);
            this.csvListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.csvListBox.Name = "csvListBox";
            this.csvListBox.Size = new System.Drawing.Size(186, 272);
            this.csvListBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 9;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(228, 162);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(72, 32);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "<=";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // clearAllButton
            // 
            this.clearAllButton.Location = new System.Drawing.Point(532, 94);
            this.clearAllButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(112, 32);
            this.clearAllButton.TabIndex = 11;
            this.clearAllButton.Text = "Clear All";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // HeaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 323);
            this.Controls.Add(this.clearAllButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.csvListBox);
            this.Controls.Add(this.fieldButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.selectedListBox);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HeaderForm";
            this.Text = "Select Columns";
            this.Load += new System.EventHandler(this.HeaderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox selectedListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button fieldButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox csvListBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button clearAllButton;
    }
}