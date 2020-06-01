﻿namespace Viewer.UI
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.code = new System.Windows.Forms.TabPage();
            this.codeView = new BrightIdeasSoftware.FastObjectListView();
            this.job = new System.Windows.Forms.TabPage();
            this.jobView = new BrightIdeasSoftware.FastObjectListView();
            this.meet = new System.Windows.Forms.TabPage();
            this.meetView = new BrightIdeasSoftware.FastObjectListView();
            this.soft = new System.Windows.Forms.TabPage();
            this.softView = new BrightIdeasSoftware.FastObjectListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.code.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codeView)).BeginInit();
            this.job.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobView)).BeginInit();
            this.meet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meetView)).BeginInit();
            this.soft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.softView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 519);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel2.Location = new System.Drawing.Point(233, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(864, 455);
            this.panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.code);
            this.tabControl1.Controls.Add(this.soft);
            this.tabControl1.Controls.Add(this.job);
            this.tabControl1.Controls.Add(this.meet);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 455);
            this.tabControl1.TabIndex = 0;
            // 
            // code
            // 
            this.code.Controls.Add(this.codeView);
            this.code.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.code.Location = new System.Drawing.Point(4, 29);
            this.code.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.code.Name = "code";
            this.code.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.code.Size = new System.Drawing.Size(856, 422);
            this.code.TabIndex = 0;
            this.code.Text = "CodeAssistance";
            this.code.UseVisualStyleBackColor = true;
            // 
            // codeView
            // 
            this.codeView.CellEditUseWholeCell = false;
            this.codeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.codeView.HideSelection = false;
            this.codeView.Location = new System.Drawing.Point(4, 4);
            this.codeView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.codeView.Name = "codeView";
            this.codeView.ShowGroups = false;
            this.codeView.Size = new System.Drawing.Size(848, 414);
            this.codeView.TabIndex = 0;
            this.codeView.UseCompatibleStateImageBehavior = false;
            this.codeView.View = System.Windows.Forms.View.Details;
            this.codeView.VirtualMode = true;
            // 
            // job
            // 
            this.job.Controls.Add(this.jobView);
            this.job.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.job.Location = new System.Drawing.Point(4, 29);
            this.job.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.job.Name = "job";
            this.job.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.job.Size = new System.Drawing.Size(856, 422);
            this.job.TabIndex = 1;
            this.job.Text = "JobDiscussion";
            this.job.UseVisualStyleBackColor = true;
            // 
            // jobView
            // 
            this.jobView.CellEditUseWholeCell = false;
            this.jobView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jobView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.jobView.HideSelection = false;
            this.jobView.Location = new System.Drawing.Point(4, 4);
            this.jobView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.jobView.Name = "jobView";
            this.jobView.ShowGroups = false;
            this.jobView.Size = new System.Drawing.Size(848, 414);
            this.jobView.TabIndex = 0;
            this.jobView.UseCompatibleStateImageBehavior = false;
            this.jobView.View = System.Windows.Forms.View.Details;
            this.jobView.VirtualMode = true;
            // 
            // meet
            // 
            this.meet.Controls.Add(this.meetView);
            this.meet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.meet.Location = new System.Drawing.Point(4, 29);
            this.meet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.meet.Name = "meet";
            this.meet.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.meet.Size = new System.Drawing.Size(856, 422);
            this.meet.TabIndex = 2;
            this.meet.Text = "Meeting";
            this.meet.UseVisualStyleBackColor = true;
            // 
            // meetView
            // 
            this.meetView.CellEditUseWholeCell = false;
            this.meetView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meetView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.meetView.HideSelection = false;
            this.meetView.Location = new System.Drawing.Point(4, 4);
            this.meetView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.meetView.Name = "meetView";
            this.meetView.ShowGroups = false;
            this.meetView.Size = new System.Drawing.Size(848, 414);
            this.meetView.TabIndex = 0;
            this.meetView.UseCompatibleStateImageBehavior = false;
            this.meetView.View = System.Windows.Forms.View.Details;
            this.meetView.VirtualMode = true;
            // 
            // soft
            // 
            this.soft.Controls.Add(this.softView);
            this.soft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.soft.Location = new System.Drawing.Point(4, 29);
            this.soft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.soft.Name = "soft";
            this.soft.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.soft.Size = new System.Drawing.Size(856, 422);
            this.soft.TabIndex = 3;
            this.soft.Text = "SoftwareSupport";
            this.soft.UseVisualStyleBackColor = true;
            // 
            // softView
            // 
            this.softView.CellEditUseWholeCell = false;
            this.softView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.softView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.softView.HideSelection = false;
            this.softView.Location = new System.Drawing.Point(4, 4);
            this.softView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.softView.Name = "softView";
            this.softView.ShowGroups = false;
            this.softView.Size = new System.Drawing.Size(848, 414);
            this.softView.TabIndex = 0;
            this.softView.UseCompatibleStateImageBehavior = false;
            this.softView.View = System.Windows.Forms.View.Details;
            this.softView.VirtualMode = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(680, 463);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(272, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(399, 463);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(261, 42);
            this.button2.TabIndex = 4;
            this.button2.Text = "Prev";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(222, 28);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 201);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(222, 28);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(0, 131);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(222, 28);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(3, 78);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(222, 28);
            this.button6.TabIndex = 5;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            // 
            // Suggester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 519);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Suggester";
            this.Text = "Suggester";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.code.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.codeView)).EndInit();
            this.job.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jobView)).EndInit();
            this.meet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meetView)).EndInit();
            this.soft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.softView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage code;
        private BrightIdeasSoftware.FastObjectListView codeView;
        private System.Windows.Forms.TabPage job;
        private BrightIdeasSoftware.FastObjectListView jobView;
        private System.Windows.Forms.TabPage meet;
        private BrightIdeasSoftware.FastObjectListView meetView;
        private System.Windows.Forms.TabPage soft;
        private BrightIdeasSoftware.FastObjectListView softView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}