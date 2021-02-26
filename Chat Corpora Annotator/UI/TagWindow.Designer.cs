namespace Viewer.UI
{
    partial class TagWindow
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
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.suggesterButton = new System.Windows.Forms.Button();
            this.removeTagButton = new System.Windows.Forms.Button();
            this.addTagButton = new System.Windows.Forms.Button();
            this.tagsetView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.loadMoreButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tagTable = new BrightIdeasSoftware.FastObjectListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.situationView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonBackPanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagTable)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.buttonBackPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Edit tagset...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightSalmon;
            this.button4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(0, 579);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(209, 52);
            this.button4.TabIndex = 3;
            this.button4.Text = "Write to disk";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.Controls.Add(this.tagsetView);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.suggesterButton);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 631);
            this.panel2.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lavender;
            this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(0, 441);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(209, 50);
            this.button3.TabIndex = 7;
            this.button3.Text = "Tagged only";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // suggesterButton
            // 
            this.suggesterButton.BackColor = System.Drawing.Color.Lavender;
            this.suggesterButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.suggesterButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.suggesterButton.FlatAppearance.BorderSize = 0;
            this.suggesterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suggesterButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.suggesterButton.Location = new System.Drawing.Point(0, 491);
            this.suggesterButton.Name = "suggesterButton";
            this.suggesterButton.Size = new System.Drawing.Size(209, 50);
            this.suggesterButton.TabIndex = 5;
            this.suggesterButton.Text = "Show suggestions";
            this.suggesterButton.UseVisualStyleBackColor = false;
            this.suggesterButton.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // removeTagButton
            // 
            this.removeTagButton.BackColor = System.Drawing.Color.LightSalmon;
            this.removeTagButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.removeTagButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.removeTagButton.FlatAppearance.BorderSize = 0;
            this.removeTagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeTagButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeTagButton.Location = new System.Drawing.Point(0, 0);
            this.removeTagButton.Name = "removeTagButton";
            this.removeTagButton.Size = new System.Drawing.Size(530, 48);
            this.removeTagButton.TabIndex = 3;
            this.removeTagButton.Text = "Remove tag";
            this.removeTagButton.UseVisualStyleBackColor = false;
            this.removeTagButton.Click += new System.EventHandler(this.removeTagButton_Click);
            // 
            // addTagButton
            // 
            this.addTagButton.BackColor = System.Drawing.Color.MediumAquamarine;
            this.addTagButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addTagButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.addTagButton.FlatAppearance.BorderSize = 0;
            this.addTagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTagButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addTagButton.Location = new System.Drawing.Point(0, 0);
            this.addTagButton.Name = "addTagButton";
            this.addTagButton.Size = new System.Drawing.Size(530, 48);
            this.addTagButton.TabIndex = 2;
            this.addTagButton.Text = "Add tag";
            this.addTagButton.UseVisualStyleBackColor = false;
            this.addTagButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // tagsetView
            // 
            this.tagsetView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagsetView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.tagsetView.Dock = System.Windows.Forms.DockStyle.Top;
            this.tagsetView.FullRowSelect = true;
            this.tagsetView.HideSelection = false;
            this.tagsetView.Location = new System.Drawing.Point(0, 48);
            this.tagsetView.MultiSelect = false;
            this.tagsetView.Name = "tagsetView";
            this.tagsetView.Size = new System.Drawing.Size(209, 316);
            this.tagsetView.TabIndex = 4;
            this.tagsetView.UseCompatibleStateImageBehavior = false;
            this.tagsetView.View = System.Windows.Forms.View.Details;
            this.tagsetView.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tagset";
            this.columnHeader2.Width = 210;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lavender;
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(0, 541);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 38);
            this.button2.TabIndex = 6;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button4_Click);
            // 
            // loadMoreButton
            // 
            this.loadMoreButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadMoreButton.BackColor = System.Drawing.Color.Lavender;
            this.loadMoreButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadMoreButton.FlatAppearance.BorderSize = 0;
            this.loadMoreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.loadMoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadMoreButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadMoreButton.Location = new System.Drawing.Point(0, 534);
            this.loadMoreButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.loadMoreButton.Name = "loadMoreButton";
            this.loadMoreButton.Size = new System.Drawing.Size(1061, 52);
            this.loadMoreButton.TabIndex = 12;
            this.loadMoreButton.Text = "Load more...";
            this.loadMoreButton.UseVisualStyleBackColor = false;
            this.loadMoreButton.Click += new System.EventHandler(this.loadMoreButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tagTable);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.loadMoreButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(209, 45);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1061, 586);
            this.panel1.TabIndex = 0;
            // 
            // tagTable
            // 
            this.tagTable.CellEditUseWholeCell = false;
            this.tagTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagTable.FullRowSelect = true;
            this.tagTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.tagTable.HideSelection = false;
            this.tagTable.Location = new System.Drawing.Point(0, 0);
            this.tagTable.Name = "tagTable";
            this.tagTable.RowHeight = 52;
            this.tagTable.ShowGroups = false;
            this.tagTable.Size = new System.Drawing.Size(851, 534);
            this.tagTable.TabIndex = 18;
            this.tagTable.UseCompatibleStateImageBehavior = false;
            this.tagTable.View = System.Windows.Forms.View.Details;
            this.tagTable.VirtualMode = true;
            this.tagTable.SelectedIndexChanged += new System.EventHandler(this.tagTable_SelectedIndexChanged_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.situationView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(851, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(210, 534);
            this.panel3.TabIndex = 17;
            // 
            // situationView
            // 
            this.situationView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.situationView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.situationView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.situationView.FullRowSelect = true;
            this.situationView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.situationView.HideSelection = false;
            this.situationView.Location = new System.Drawing.Point(0, 0);
            this.situationView.MultiSelect = false;
            this.situationView.Name = "situationView";
            this.situationView.Size = new System.Drawing.Size(210, 534);
            this.situationView.TabIndex = 15;
            this.situationView.UseCompatibleStateImageBehavior = false;
            this.situationView.View = System.Windows.Forms.View.Details;
            this.situationView.DoubleClick += new System.EventHandler(this.situationView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Situations";
            this.columnHeader1.Width = 204;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Lavender;
            this.panel4.Controls.Add(this.removeTagButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(530, 48);
            this.panel4.TabIndex = 19;
            // 
            // buttonBackPanel
            // 
            this.buttonBackPanel.BackColor = System.Drawing.Color.Lavender;
            this.buttonBackPanel.Controls.Add(this.panel6);
            this.buttonBackPanel.Controls.Add(this.panel4);
            this.buttonBackPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBackPanel.Location = new System.Drawing.Point(209, 0);
            this.buttonBackPanel.Name = "buttonBackPanel";
            this.buttonBackPanel.Size = new System.Drawing.Size(1061, 48);
            this.buttonBackPanel.TabIndex = 20;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Lavender;
            this.panel6.Controls.Add(this.addTagButton);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(531, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(530, 48);
            this.panel6.TabIndex = 20;
            // 
            // TagWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1270, 631);
            this.Controls.Add(this.buttonBackPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TagWindow";
            this.Text = "Tagger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TagWindow_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tagTable)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.buttonBackPanel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button removeTagButton;
        private System.Windows.Forms.Button addTagButton;
        private System.Windows.Forms.Button loadMoreButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView situationView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView tagsetView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button suggesterButton;
        private System.Windows.Forms.Button button2;
        private BrightIdeasSoftware.FastObjectListView tagTable;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel buttonBackPanel;
        private System.Windows.Forms.Panel panel6;
    }
}