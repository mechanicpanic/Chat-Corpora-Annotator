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
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // csvLoadButton
            // 
            this.csvLoadButton.Location = new System.Drawing.Point(13, 13);
            this.csvLoadButton.Name = "csvLoadButton";
            this.csvLoadButton.Size = new System.Drawing.Size(136, 45);
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
            // objectListView1
            // 
            this.objectListView1.HideSelection = false;
            this.objectListView1.Location = new System.Drawing.Point(156, 13);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(660, 352);
            this.objectListView1.TabIndex = 1;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 410);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.csvLoadButton);
            this.Name = "MainWindow";
            this.Text = "Chat Corpora Annotator";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button csvLoadButton;
        private System.Windows.Forms.OpenFileDialog csvDialog;
        private BrightIdeasSoftware.ObjectListView objectListView1;
    }
}

