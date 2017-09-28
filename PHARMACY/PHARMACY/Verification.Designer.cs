namespace PHARMACY
{
    partial class Verification
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Verification));
            this.verificationMacAddress = new System.Windows.Forms.TextBox();
            this.keyFromFile = new System.Windows.Forms.TextBox();
            this.splashProgressBar = new System.Windows.Forms.ProgressBar();
            this.splashTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // verificationMacAddress
            // 
            this.verificationMacAddress.Location = new System.Drawing.Point(378, 12);
            this.verificationMacAddress.Name = "verificationMacAddress";
            this.verificationMacAddress.Size = new System.Drawing.Size(245, 20);
            this.verificationMacAddress.TabIndex = 0;
            this.verificationMacAddress.Visible = false;
            // 
            // keyFromFile
            // 
            this.keyFromFile.Location = new System.Drawing.Point(681, 12);
            this.keyFromFile.Name = "keyFromFile";
            this.keyFromFile.Size = new System.Drawing.Size(245, 20);
            this.keyFromFile.TabIndex = 1;
            this.keyFromFile.Visible = false;
            // 
            // splashProgressBar
            // 
            this.splashProgressBar.Location = new System.Drawing.Point(428, 399);
            this.splashProgressBar.Name = "splashProgressBar";
            this.splashProgressBar.Size = new System.Drawing.Size(253, 27);
            this.splashProgressBar.TabIndex = 2;
            // 
            // splashTimer
            // 
            this.splashTimer.Enabled = true;
            this.splashTimer.Interval = 32;
            this.splashTimer.Tick += new System.EventHandler(this.splashTimer_Tick);
            // 
            // Verification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PHARMACY.Properties.Resources.pmsoverview;
            this.ClientSize = new System.Drawing.Size(1187, 464);
            this.Controls.Add(this.splashProgressBar);
            this.Controls.Add(this.keyFromFile);
            this.Controls.Add(this.verificationMacAddress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Verification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verification";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Verification_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox verificationMacAddress;
        private System.Windows.Forms.TextBox keyFromFile;
        private System.Windows.Forms.ProgressBar splashProgressBar;
        private System.Windows.Forms.Timer splashTimer;
    }
}