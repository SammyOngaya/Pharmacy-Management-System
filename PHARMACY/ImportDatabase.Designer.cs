namespace PHARMACY
{
    partial class ImportDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportDatabase));
            this.databaseBackupButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // databaseBackupButton
            // 
            this.databaseBackupButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.databaseBackupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseBackupButton.Location = new System.Drawing.Point(373, 192);
            this.databaseBackupButton.Name = "databaseBackupButton";
            this.databaseBackupButton.Size = new System.Drawing.Size(294, 133);
            this.databaseBackupButton.TabIndex = 13;
            this.databaseBackupButton.Text = "RESTORE";
            this.databaseBackupButton.UseVisualStyleBackColor = true;
            this.databaseBackupButton.Click += new System.EventHandler(this.databaseBackupButton_Click);
            // 
            // ImportDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 516);
            this.Controls.Add(this.databaseBackupButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RESTORE DATABASE";
            this.Load += new System.EventHandler(this.ImportDatabase_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button databaseBackupButton;
    }
}