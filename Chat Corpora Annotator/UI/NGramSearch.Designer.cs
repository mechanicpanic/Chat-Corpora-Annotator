namespace Viewer.UI
{
    partial class NGramSearch
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.bi = new System.Windows.Forms.TabPage();
            this.tri = new System.Windows.Forms.TabPage();
            this.four = new System.Windows.Forms.TabPage();
            this.five = new System.Windows.Forms.TabPage();
            this.fastObjectListView1 = new BrightIdeasSoftware.FastObjectListView();
            this.fastObjectListView2 = new BrightIdeasSoftware.FastObjectListView();
            this.fastObjectListView3 = new BrightIdeasSoftware.FastObjectListView();
            this.fastObjectListView4 = new BrightIdeasSoftware.FastObjectListView();
            this.phrase = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.count = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.phrase4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.count4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.phrase3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.count3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.phrase2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.count2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.bi.SuspendLayout();
            this.tri.SuspendLayout();
            this.four.SuspendLayout();
            this.five.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView4)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(6, 64);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "Show ngrams";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(50, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.MaximumSize = new System.Drawing.Size(301, 200);
            this.textBox1.MinimumSize = new System.Drawing.Size(76, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 60);
            this.textBox1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.MaximumSize = new System.Drawing.Size(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 515);
            this.panel1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(2, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Filter";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.bi);
            this.tabControl2.Controls.Add(this.tri);
            this.tabControl2.Controls.Add(this.four);
            this.tabControl2.Controls.Add(this.five);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl2.Location = new System.Drawing.Point(200, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(697, 515);
            this.tabControl2.TabIndex = 13;
            // 
            // bi
            // 
            this.bi.Controls.Add(this.fastObjectListView1);
            this.bi.Location = new System.Drawing.Point(4, 26);
            this.bi.Name = "bi";
            this.bi.Padding = new System.Windows.Forms.Padding(3);
            this.bi.Size = new System.Drawing.Size(689, 485);
            this.bi.TabIndex = 0;
            this.bi.Text = "Bigrams";
            this.bi.UseVisualStyleBackColor = true;
            // 
            // tri
            // 
            this.tri.Controls.Add(this.fastObjectListView2);
            this.tri.Location = new System.Drawing.Point(4, 26);
            this.tri.Name = "tri";
            this.tri.Padding = new System.Windows.Forms.Padding(3);
            this.tri.Size = new System.Drawing.Size(689, 485);
            this.tri.TabIndex = 1;
            this.tri.Text = "Trigrams";
            this.tri.UseVisualStyleBackColor = true;
            // 
            // four
            // 
            this.four.Controls.Add(this.fastObjectListView3);
            this.four.Location = new System.Drawing.Point(4, 26);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(689, 485);
            this.four.TabIndex = 2;
            this.four.Text = "4-grams";
            this.four.UseVisualStyleBackColor = true;
            // 
            // five
            // 
            this.five.Controls.Add(this.fastObjectListView4);
            this.five.Location = new System.Drawing.Point(4, 26);
            this.five.Name = "five";
            this.five.Size = new System.Drawing.Size(689, 485);
            this.five.TabIndex = 3;
            this.five.Text = "5-grams";
            this.five.UseVisualStyleBackColor = true;
            // 
            // fastObjectListView1
            // 
            this.fastObjectListView1.AllColumns.Add(this.phrase2);
            this.fastObjectListView1.AllColumns.Add(this.count2);
            this.fastObjectListView1.CellEditUseWholeCell = false;
            this.fastObjectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.phrase2,
            this.count2});
            this.fastObjectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListView1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fastObjectListView1.HideSelection = false;
            this.fastObjectListView1.Location = new System.Drawing.Point(3, 3);
            this.fastObjectListView1.Name = "fastObjectListView1";
            this.fastObjectListView1.ShowGroups = false;
            this.fastObjectListView1.Size = new System.Drawing.Size(683, 479);
            this.fastObjectListView1.TabIndex = 0;
            this.fastObjectListView1.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView1.View = System.Windows.Forms.View.Details;
            this.fastObjectListView1.VirtualMode = true;
            // 
            // fastObjectListView2
            // 
            this.fastObjectListView2.AllColumns.Add(this.phrase3);
            this.fastObjectListView2.AllColumns.Add(this.count3);
            this.fastObjectListView2.CellEditUseWholeCell = false;
            this.fastObjectListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.phrase3,
            this.count3});
            this.fastObjectListView2.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListView2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fastObjectListView2.HideSelection = false;
            this.fastObjectListView2.Location = new System.Drawing.Point(3, 3);
            this.fastObjectListView2.Name = "fastObjectListView2";
            this.fastObjectListView2.ShowGroups = false;
            this.fastObjectListView2.Size = new System.Drawing.Size(683, 479);
            this.fastObjectListView2.TabIndex = 1;
            this.fastObjectListView2.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView2.View = System.Windows.Forms.View.Details;
            this.fastObjectListView2.VirtualMode = true;
            // 
            // fastObjectListView3
            // 
            this.fastObjectListView3.AllColumns.Add(this.phrase4);
            this.fastObjectListView3.AllColumns.Add(this.count4);
            this.fastObjectListView3.CellEditUseWholeCell = false;
            this.fastObjectListView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.phrase4,
            this.count4});
            this.fastObjectListView3.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListView3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fastObjectListView3.HideSelection = false;
            this.fastObjectListView3.Location = new System.Drawing.Point(0, 0);
            this.fastObjectListView3.Name = "fastObjectListView3";
            this.fastObjectListView3.ShowGroups = false;
            this.fastObjectListView3.Size = new System.Drawing.Size(689, 485);
            this.fastObjectListView3.TabIndex = 1;
            this.fastObjectListView3.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView3.View = System.Windows.Forms.View.Details;
            this.fastObjectListView3.VirtualMode = true;
            // 
            // fastObjectListView4
            // 
            this.fastObjectListView4.AllColumns.Add(this.phrase);
            this.fastObjectListView4.AllColumns.Add(this.count);
            this.fastObjectListView4.CellEditUseWholeCell = false;
            this.fastObjectListView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.phrase,
            this.count});
            this.fastObjectListView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListView4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fastObjectListView4.HideSelection = false;
            this.fastObjectListView4.Location = new System.Drawing.Point(0, 0);
            this.fastObjectListView4.Name = "fastObjectListView4";
            this.fastObjectListView4.ShowGroups = false;
            this.fastObjectListView4.Size = new System.Drawing.Size(689, 485);
            this.fastObjectListView4.TabIndex = 1;
            this.fastObjectListView4.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView4.View = System.Windows.Forms.View.Details;
            this.fastObjectListView4.VirtualMode = true;
            // 
            // phrase
            // 
            this.phrase.AspectName = "Key";
            this.phrase.Text = "Phrase";
            // 
            // count
            // 
            this.count.AspectName = "Value";
            this.count.Text = "Count";
            // 
            // phrase4
            // 
            this.phrase4.AspectName = "Key";
            this.phrase4.Text = "Phrase";
            this.phrase4.Width = 218;
            // 
            // count4
            // 
            this.count4.AspectName = "Value";
            this.count4.Text = "Count";
            this.count4.Width = 315;
            // 
            // phrase3
            // 
            this.phrase3.AspectName = "Key";
            this.phrase3.Text = "Phrase";
            this.phrase3.Width = 316;
            // 
            // count3
            // 
            this.count3.AspectName = "Value";
            this.count3.Text = "Count";
            this.count3.Width = 189;
            // 
            // phrase2
            // 
            this.phrase2.AspectName = "Key";
            this.phrase2.Text = "Phrase";
            this.phrase2.Width = 251;
            // 
            // count2
            // 
            this.count2.AspectName = "Value";
            this.count2.Text = "Count";
            this.count2.Width = 338;
            // 
            // NGramSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NGramSearch";
            this.Size = new System.Drawing.Size(897, 515);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.bi.ResumeLayout(false);
            this.tri.ResumeLayout(false);
            this.four.ResumeLayout(false);
            this.five.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage bi;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView1;
        private System.Windows.Forms.TabPage tri;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView2;
        private System.Windows.Forms.TabPage four;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView3;
        private System.Windows.Forms.TabPage five;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView4;
        private BrightIdeasSoftware.OLVColumn phrase4;
        private BrightIdeasSoftware.OLVColumn count4;
        private BrightIdeasSoftware.OLVColumn phrase;
        private BrightIdeasSoftware.OLVColumn count;
        private BrightIdeasSoftware.OLVColumn phrase3;
        private BrightIdeasSoftware.OLVColumn count3;
        private BrightIdeasSoftware.OLVColumn phrase2;
        private BrightIdeasSoftware.OLVColumn count2;
    }
}