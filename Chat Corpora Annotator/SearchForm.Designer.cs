namespace Chat_Corpora_Annotator
{
    partial class Search
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
            this.fastObjectListView1 = new BrightIdeasSoftware.FastObjectListView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.fastObjectListView2 = new BrightIdeasSoftware.FastObjectListView();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView2)).BeginInit();
            this.SuspendLayout();
            // 
            // fastObjectListView1
            // 
            this.fastObjectListView1.CellEditUseWholeCell = false;
            this.fastObjectListView1.HideSelection = false;
            this.fastObjectListView1.Location = new System.Drawing.Point(256, 12);
            this.fastObjectListView1.Name = "fastObjectListView1";
            this.fastObjectListView1.ShowGroups = false;
            this.fastObjectListView1.Size = new System.Drawing.Size(642, 390);
            this.fastObjectListView1.TabIndex = 1;
            this.fastObjectListView1.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView1.View = System.Windows.Forms.View.Details;
            this.fastObjectListView1.VirtualMode = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(237, 75);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
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
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 414);
            this.Controls.Add(this.fastObjectListView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.fastObjectListView1);
            this.Name = "Search";
            this.Text = "SearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView fastObjectListView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView2;
    }
}