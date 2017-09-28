namespace PHARMACY
{
    partial class AdminHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminHelp));
            this.adminHelpAxAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.adminHelpAxAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // adminHelpAxAcroPDF1
            // 
            this.adminHelpAxAcroPDF1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.adminHelpAxAcroPDF1.Enabled = true;
            this.adminHelpAxAcroPDF1.Location = new System.Drawing.Point(117, 4);
            this.adminHelpAxAcroPDF1.Name = "adminHelpAxAcroPDF1";
            this.adminHelpAxAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("adminHelpAxAcroPDF1.OcxState")));
            this.adminHelpAxAcroPDF1.Size = new System.Drawing.Size(1002, 421);
            this.adminHelpAxAcroPDF1.TabIndex = 0;
            // 
            // AdminHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 437);
            this.Controls.Add(this.adminHelpAxAcroPDF1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminHelp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminHelp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.adminHelpAxAcroPDF1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF adminHelpAxAcroPDF1;
    }
}