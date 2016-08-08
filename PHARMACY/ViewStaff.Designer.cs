namespace PHARMACY
{
    partial class ViewStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewStaff));
            this.viewstaffdataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.staffPdfReportButton = new System.Windows.Forms.Button();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.exportToExcelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.viewstaffdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // viewstaffdataGridView
            // 
            this.viewstaffdataGridView.AllowUserToOrderColumns = true;
            this.viewstaffdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.viewstaffdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.viewstaffdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewstaffdataGridView.Location = new System.Drawing.Point(2, 78);
            this.viewstaffdataGridView.Name = "viewstaffdataGridView";
            this.viewstaffdataGridView.Size = new System.Drawing.Size(1305, 501);
            this.viewstaffdataGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(459, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Staffs";
            // 
            // staffPdfReportButton
            // 
            this.staffPdfReportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.staffPdfReportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.staffPdfReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffPdfReportButton.Location = new System.Drawing.Point(567, 24);
            this.staffPdfReportButton.Name = "staffPdfReportButton";
            this.staffPdfReportButton.Size = new System.Drawing.Size(104, 30);
            this.staffPdfReportButton.TabIndex = 2;
            this.staffPdfReportButton.Text = "Print";
            this.staffPdfReportButton.UseVisualStyleBackColor = false;
            this.staffPdfReportButton.Click += new System.EventHandler(this.staffPdfReportButton_Click);
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(890, 31);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 5;
            // 
            // exportToExcelButton
            // 
            this.exportToExcelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.exportToExcelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportToExcelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportToExcelButton.Location = new System.Drawing.Point(687, 25);
            this.exportToExcelButton.Name = "exportToExcelButton";
            this.exportToExcelButton.Size = new System.Drawing.Size(138, 30);
            this.exportToExcelButton.TabIndex = 6;
            this.exportToExcelButton.Text = "Excel";
            this.exportToExcelButton.UseVisualStyleBackColor = false;
            this.exportToExcelButton.Click += new System.EventHandler(this.exportToExcelButton_Click);
            // 
            // ViewStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 586);
            this.Controls.Add(this.exportToExcelButton);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.staffPdfReportButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewstaffdataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIEW STAFF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ViewStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewstaffdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView viewstaffdataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button staffPdfReportButton;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.Button exportToExcelButton;
    }
}