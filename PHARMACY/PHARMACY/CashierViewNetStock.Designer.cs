namespace PHARMACY
{
    partial class CashierViewNetStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierViewNetStock));
            this.netStockPdfReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.viewNetStockdataGridView = new System.Windows.Forms.DataGridView();
            this.rowCountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.viewNetStockdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // netStockPdfReport
            // 
            this.netStockPdfReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.netStockPdfReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.netStockPdfReport.Location = new System.Drawing.Point(646, 38);
            this.netStockPdfReport.Name = "netStockPdfReport";
            this.netStockPdfReport.Size = new System.Drawing.Size(142, 27);
            this.netStockPdfReport.TabIndex = 9;
            this.netStockPdfReport.Text = "Print";
            this.netStockPdfReport.UseVisualStyleBackColor = false;
            this.netStockPdfReport.Click += new System.EventHandler(this.netStockPdfReport_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(425, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "View Net Stock";
            // 
            // viewNetStockdataGridView
            // 
            this.viewNetStockdataGridView.AllowUserToOrderColumns = true;
            this.viewNetStockdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.viewNetStockdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewNetStockdataGridView.Location = new System.Drawing.Point(11, 104);
            this.viewNetStockdataGridView.Name = "viewNetStockdataGridView";
            this.viewNetStockdataGridView.Size = new System.Drawing.Size(895, 262);
            this.viewNetStockdataGridView.TabIndex = 7;
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(261, 52);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 10;
            // 
            // CashierViewNetStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 404);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.netStockPdfReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewNetStockdataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CashierViewNetStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CashierViewNetStock";
            this.Load += new System.EventHandler(this.CashierViewNetStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewNetStockdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button netStockPdfReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView viewNetStockdataGridView;
        private System.Windows.Forms.Label rowCountLabel;
    }
}