namespace Viewer
{
    partial class CSVLoader
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
            this.stepLabel = new System.Windows.Forms.Label();
            this.panelStep = new System.Windows.Forms.Panel();
            this.cmdNext = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.stepLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 534);
            this.panel1.TabIndex = 0;
            // 
            // stepLabel
            // 
            this.stepLabel.AutoSize = true;
            this.stepLabel.BackColor = System.Drawing.Color.Lavender;
            this.stepLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepLabel.Location = new System.Drawing.Point(12, 61);
            this.stepLabel.Name = "stepLabel";
            this.stepLabel.Size = new System.Drawing.Size(55, 23);
            this.stepLabel.TabIndex = 0;
            this.stepLabel.Text = "label1";
            // 
            // panelStep
            // 
            this.panelStep.BackColor = System.Drawing.Color.Lavender;
            this.panelStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStep.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panelStep.Location = new System.Drawing.Point(196, 0);
            this.panelStep.Name = "panelStep";
            this.panelStep.Size = new System.Drawing.Size(655, 461);
            this.panelStep.TabIndex = 0;
            // 
            // cmdNext
            // 
            this.cmdNext.BackColor = System.Drawing.Color.Lavender;
            this.cmdNext.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdNext.Location = new System.Drawing.Point(712, 481);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(125, 30);
            this.cmdNext.TabIndex = 1;
            this.cmdNext.Text = "Next >";
            this.cmdNext.UseVisualStyleBackColor = false;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // CSVLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 534);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.panelStep);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "CSVLoader";
            this.Text = "Load a .csv file";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelStep;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Label stepLabel;
    }
}