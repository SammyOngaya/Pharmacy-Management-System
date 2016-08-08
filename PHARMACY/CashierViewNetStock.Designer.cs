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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.searchDrugTextBox = new System.Windows.Forms.TextBox();
            this.searchSupplierPriceListButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.exportToExcelButton = new System.Windows.Forms.Button();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.netStockPdfReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.viewNetStockdataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewNetStockdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.searchDrugTextBox);
            this.groupBox2.Controls.Add(this.searchSupplierPriceListButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(21, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 50);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "search";
            // 
            // searchDrugTextBox
            // 
            this.searchDrugTextBox.Location = new System.Drawing.Point(45, 17);
            this.searchDrugTextBox.MaxLength = 150;
            this.searchDrugTextBox.Name = "searchDrugTextBox";
            this.searchDrugTextBox.Size = new System.Drawing.Size(227, 20);
            this.searchDrugTextBox.TabIndex = 19;
            this.searchDrugTextBox.TextChanged += new System.EventHandler(this.searchDrugTextBox_TextChanged);
            // 
            // searchSupplierPriceListButton
            // 
            this.searchSupplierPriceListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchSupplierPriceListButton.Location = new System.Drawing.Point(278, 13);
            this.searchSupplierPriceListButton.Name = "searchSupplierPriceListButton";
            this.searchSupplierPriceListButton.Size = new System.Drawing.Size(78, 31);
            this.searchSupplierPriceListButton.TabIndex = 18;
            this.searchSupplierPriceListButton.Text = "search";
            this.searchSupplierPriceListButton.UseVisualStyleBackColor = true;
            this.searchSupplierPriceListButton.Click += new System.EventHandler(this.searchSupplierPriceListButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Drug";
            // 
            // exportToExcelButton
            // 
            this.exportToExcelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.exportToExcelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportToExcelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportToExcelButton.Location = new System.Drawing.Point(1061, 11);
            this.exportToExcelButton.Name = "exportToExcelButton";
            this.exportToExcelButton.Size = new System.Drawing.Size(138, 30);
            this.exportToExcelButton.TabIndex = 32;
            this.exportToExcelButton.Text = "Excel";
            this.exportToExcelButton.UseVisualStyleBackColor = false;
            this.exportToExcelButton.Click += new System.EventHandler(this.exportToExcelButton_Click);
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(1058, 32);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 31;
            // 
            // netStockPdfReport
            // 
            this.netStockPdfReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.netStockPdfReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.netStockPdfReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.netStockPdfReport.Location = new System.Drawing.Point(892, 13);
            this.netStockPdfReport.Name = "netStockPdfReport";
            this.netStockPdfReport.Size = new System.Drawing.Size(142, 27);
            this.netStockPdfReport.TabIndex = 30;
            this.netStockPdfReport.Text = "Print";
            this.netStockPdfReport.UseVisualStyleBackColor = false;
            this.netStockPdfReport.Click += new System.EventHandler(this.netStockPdfReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(430, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Current Stock";
            // 
            // viewNetStockdataGridView
            // 
            this.viewNetStockdataGridView.AllowUserToOrderColumns = true;
            this.viewNetStockdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.viewNetStockdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.viewNetStockdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewNetStockdataGridView.Location = new System.Drawing.Point(7, 68);
            this.viewNetStockdataGridView.Name = "viewNetStockdataGridView";
            this.viewNetStockdataGridView.Size = new System.Drawing.Size(1248, 670);
            this.viewNetStockdataGridView.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(649, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 31);
            this.button1.TabIndex = 99;
            this.button1.Text = "load all drugs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CashierViewNetStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 750);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.exportToExcelButton);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.netStockPdfReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewNetStockdataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CashierViewNetStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Net Stock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CashierViewNetStock_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewNetStockdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox searchDrugTextBox;
        private System.Windows.Forms.Button searchSupplierPriceListButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button exportToExcelButton;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.Button netStockPdfReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView viewNetStockdataGridView;
        private System.Windows.Forms.Button button1;
    }
}