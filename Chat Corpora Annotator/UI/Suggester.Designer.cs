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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listButton = new System.Windows.Forms.Button();
            this.deleteListButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listContents = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button7 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fastObjectListView1 = new BrightIdeasSoftware.FastObjectListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 645);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.listButton);
            this.panel4.Controls.Add(this.deleteListButton);
            this.panel4.Controls.Add(this.listView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 261);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(385, 206);
            this.panel4.TabIndex = 14;
            // 
            // listButton
            // 
            this.listButton.BackColor = System.Drawing.Color.Lavender;
            this.listButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.listButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listButton.Location = new System.Drawing.Point(5, 164);
            this.listButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listButton.Name = "listButton";
            this.listButton.Size = new System.Drawing.Size(180, 34);
            this.listButton.TabIndex = 8;
            this.listButton.Text = "Add dictionary";
            this.listButton.UseVisualStyleBackColor = false;
            this.listButton.Click += new System.EventHandler(this.listButton_Click);
            // 
            // deleteListButton
            // 
            this.deleteListButton.BackColor = System.Drawing.Color.Lavender;
            this.deleteListButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.deleteListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteListButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteListButton.Location = new System.Drawing.Point(191, 164);
            this.deleteListButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteListButton.Name = "deleteListButton";
            this.deleteListButton.Size = new System.Drawing.Size(191, 34);
            this.deleteListButton.TabIndex = 9;
            this.deleteListButton.Text = "Delete dictionary";
            this.deleteListButton.UseVisualStyleBackColor = false;
            this.deleteListButton.Click += new System.EventHandler(this.deleteListButton_Click);
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
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(385, 158);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Lavender;
            this.button7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(0, 595);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(385, 50);
            this.button7.TabIndex = 7;
            this.button7.Text = "Find suggestions...";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button8);
            this.panel5.Controls.Add(this.button6);
            this.panel5.Controls.Add(this.button5);
            this.panel5.Controls.Add(this.button4);
            this.panel5.Controls.Add(this.button3);
            this.panel5.Controls.Add(this.button12);
            this.panel5.Controls.Add(this.button9);
            this.panel5.Controls.Add(this.button11);
            this.panel5.Controls.Add(this.button10);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 124);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(385, 137);
            this.panel5.TabIndex = 18;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Lavender;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(0, 102);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(187, 34);
            this.button8.TabIndex = 23;
            this.button8.Text = "inwin";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.operator_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Lavender;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(198, 102);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(187, 34);
            this.button6.TabIndex = 22;
            this.button6.Text = "haslocation()";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.operator_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Lavender;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(198, 68);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(187, 34);
            this.button5.TabIndex = 21;
            this.button5.Text = "hasorganization()";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.operator_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Lavender;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(198, 0);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(187, 34);
            this.button4.TabIndex = 20;
            this.button4.Text = "hasdate()";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.operator_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lavender;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(0, 68);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(187, 34);
            this.button3.TabIndex = 19;
            this.button3.Text = "hasusermentioned()";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Lavender;
            this.button12.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button12.Location = new System.Drawing.Point(198, 34);
            this.button12.Margin = new System.Windows.Forms.Padding(4);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(187, 34);
            this.button12.TabIndex = 18;
            this.button12.Text = "hastime()";
            this.button12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.operator_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Lavender;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.Location = new System.Drawing.Point(0, 34);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(187, 34);
            this.button9.TabIndex = 12;
            this.button9.Text = "byuser()";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.operator_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Lavender;
            this.button11.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button11.Location = new System.Drawing.Point(0, 0);
            this.button11.Margin = new System.Windows.Forms.Padding(4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(187, 34);
            this.button11.TabIndex = 17;
            this.button11.Text = "haswordofdict()";
            this.button11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.operator_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Lavender;
            this.button10.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button10.Location = new System.Drawing.Point(0, 0);
            this.button10.Margin = new System.Windows.Forms.Padding(4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(187, 34);
            this.button10.TabIndex = 13;
            this.button10.Text = "hasusermentioned()";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.operator_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 98);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(385, 26);
            this.panel3.TabIndex = 15;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(385, 98);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "select";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fastObjectListView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel2.Location = new System.Drawing.Point(385, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(931, 588);
            this.panel2.TabIndex = 2;
            // 
            // fastObjectListView1
            // 
            this.fastObjectListView1.CellEditUseWholeCell = false;
            this.fastObjectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fastObjectListView1.FullRowSelect = true;
            this.fastObjectListView1.HideSelection = false;
            this.fastObjectListView1.Location = new System.Drawing.Point(0, 0);
            this.fastObjectListView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fastObjectListView1.Name = "fastObjectListView1";
            this.fastObjectListView1.RowHeight = 48;
            this.fastObjectListView1.ShowGroups = false;
            this.fastObjectListView1.Size = new System.Drawing.Size(931, 588);
            this.fastObjectListView1.TabIndex = 0;
            this.fastObjectListView1.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView1.View = System.Windows.Forms.View.Details;
            this.fastObjectListView1.VirtualMode = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(881, 599);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(272, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button2_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lavender;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(587, 599);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(261, 42);
            this.button2.TabIndex = 4;
            this.button2.Text = "Prev";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // Suggester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1316, 645);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Suggester";
            this.Text = "Suggester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Suggester_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button deleteListButton;
        private System.Windows.Forms.Button listButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader listName;
        private System.Windows.Forms.ColumnHeader listContents;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}