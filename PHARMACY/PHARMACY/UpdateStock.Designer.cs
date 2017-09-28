namespace PHARMACY
{
    partial class UpdateStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateStock));
            this.updateStockButton = new System.Windows.Forms.Button();
            this.updateStockSellingPrice = new System.Windows.Forms.TextBox();
            this.updateStockBuyingPrice = new System.Windows.Forms.TextBox();
            this.updateStockQuantity = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.updatestockpfsession = new System.Windows.Forms.TextBox();
            this.drugidforeignkey = new System.Windows.Forms.TextBox();
            this.supplieridforeignkey = new System.Windows.Forms.TextBox();
            this.cancelStock = new System.Windows.Forms.Button();
            this.updateSupplierCombo = new System.Windows.Forms.ComboBox();
            this.updateDrugCombo = new System.Windows.Forms.ComboBox();
            this.updateStockUnit = new System.Windows.Forms.ComboBox();
            this.updateStockExpiriDate = new System.Windows.Forms.DateTimePicker();
            this.updateStockBatchNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.updateStockdataGridView = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.searchUpdateStock = new System.Windows.Forms.TextBox();
            this.updateStockId = new System.Windows.Forms.TextBox();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateStockdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // updateStockButton
            // 
            this.updateStockButton.Location = new System.Drawing.Point(413, 205);
            this.updateStockButton.Name = "updateStockButton";
            this.updateStockButton.Size = new System.Drawing.Size(80, 31);
            this.updateStockButton.TabIndex = 16;
            this.updateStockButton.Text = "update";
            this.updateStockButton.UseVisualStyleBackColor = true;
            this.updateStockButton.Click += new System.EventHandler(this.updateStockButton_Click);
            // 
            // updateStockSellingPrice
            // 
            this.updateStockSellingPrice.Location = new System.Drawing.Point(134, 156);
            this.updateStockSellingPrice.Name = "updateStockSellingPrice";
            this.updateStockSellingPrice.Size = new System.Drawing.Size(277, 26);
            this.updateStockSellingPrice.TabIndex = 15;
            // 
            // updateStockBuyingPrice
            // 
            this.updateStockBuyingPrice.Location = new System.Drawing.Point(134, 115);
            this.updateStockBuyingPrice.Name = "updateStockBuyingPrice";
            this.updateStockBuyingPrice.Size = new System.Drawing.Size(277, 26);
            this.updateStockBuyingPrice.TabIndex = 14;
            // 
            // updateStockQuantity
            // 
            this.updateStockQuantity.Enabled = false;
            this.updateStockQuantity.Location = new System.Drawing.Point(134, 73);
            this.updateStockQuantity.Name = "updateStockQuantity";
            this.updateStockQuantity.Size = new System.Drawing.Size(277, 26);
            this.updateStockQuantity.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.updatestockpfsession);
            this.groupBox1.Controls.Add(this.drugidforeignkey);
            this.groupBox1.Controls.Add(this.supplieridforeignkey);
            this.groupBox1.Controls.Add(this.cancelStock);
            this.groupBox1.Controls.Add(this.updateStockButton);
            this.groupBox1.Controls.Add(this.updateStockSellingPrice);
            this.groupBox1.Controls.Add(this.updateStockBuyingPrice);
            this.groupBox1.Controls.Add(this.updateStockQuantity);
            this.groupBox1.Controls.Add(this.updateSupplierCombo);
            this.groupBox1.Controls.Add(this.updateDrugCombo);
            this.groupBox1.Controls.Add(this.updateStockUnit);
            this.groupBox1.Controls.Add(this.updateStockExpiriDate);
            this.groupBox1.Controls.Add(this.updateStockBatchNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(78, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 242);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Stock";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // updatestockpfsession
            // 
            this.updatestockpfsession.Location = new System.Drawing.Point(340, -2);
            this.updatestockpfsession.Name = "updatestockpfsession";
            this.updatestockpfsession.Size = new System.Drawing.Size(71, 26);
            this.updatestockpfsession.TabIndex = 20;
            this.updatestockpfsession.Visible = false;
            // 
            // drugidforeignkey
            // 
            this.drugidforeignkey.Location = new System.Drawing.Point(723, 0);
            this.drugidforeignkey.Name = "drugidforeignkey";
            this.drugidforeignkey.Size = new System.Drawing.Size(100, 26);
            this.drugidforeignkey.TabIndex = 19;
            this.drugidforeignkey.Visible = false;
            // 
            // supplieridforeignkey
            // 
            this.supplieridforeignkey.Location = new System.Drawing.Point(202, -7);
            this.supplieridforeignkey.Name = "supplieridforeignkey";
            this.supplieridforeignkey.Size = new System.Drawing.Size(100, 26);
            this.supplieridforeignkey.TabIndex = 18;
            this.supplieridforeignkey.Visible = false;
            // 
            // cancelStock
            // 
            this.cancelStock.Location = new System.Drawing.Point(528, 205);
            this.cancelStock.Name = "cancelStock";
            this.cancelStock.Size = new System.Drawing.Size(80, 31);
            this.cancelStock.TabIndex = 17;
            this.cancelStock.Text = "cancel";
            this.cancelStock.UseVisualStyleBackColor = true;
            // 
            // updateSupplierCombo
            // 
            this.updateSupplierCombo.FormattingEnabled = true;
            this.updateSupplierCombo.Location = new System.Drawing.Point(134, 25);
            this.updateSupplierCombo.Name = "updateSupplierCombo";
            this.updateSupplierCombo.Size = new System.Drawing.Size(277, 28);
            this.updateSupplierCombo.TabIndex = 12;
            this.updateSupplierCombo.SelectedIndexChanged += new System.EventHandler(this.addSupplierCombo_SelectedIndexChanged);
            // 
            // updateDrugCombo
            // 
            this.updateDrugCombo.FormattingEnabled = true;
            this.updateDrugCombo.Location = new System.Drawing.Point(651, 22);
            this.updateDrugCombo.Name = "updateDrugCombo";
            this.updateDrugCombo.Size = new System.Drawing.Size(241, 28);
            this.updateDrugCombo.TabIndex = 11;
            this.updateDrugCombo.SelectedIndexChanged += new System.EventHandler(this.addDrugCombo_SelectedIndexChanged);
            // 
            // updateStockUnit
            // 
            this.updateStockUnit.FormattingEnabled = true;
            this.updateStockUnit.Items.AddRange(new object[] {
            "gms",
            "mgs",
            "mls"});
            this.updateStockUnit.Location = new System.Drawing.Point(651, 74);
            this.updateStockUnit.Name = "updateStockUnit";
            this.updateStockUnit.Size = new System.Drawing.Size(241, 28);
            this.updateStockUnit.TabIndex = 10;
            // 
            // updateStockExpiriDate
            // 
            this.updateStockExpiriDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.updateStockExpiriDate.Location = new System.Drawing.Point(651, 114);
            this.updateStockExpiriDate.Name = "updateStockExpiriDate";
            this.updateStockExpiriDate.Size = new System.Drawing.Size(241, 26);
            this.updateStockExpiriDate.TabIndex = 9;
            // 
            // updateStockBatchNo
            // 
            this.updateStockBatchNo.Location = new System.Drawing.Point(651, 151);
            this.updateStockBatchNo.Name = "updateStockBatchNo";
            this.updateStockBatchNo.Size = new System.Drawing.Size(241, 26);
            this.updateStockBatchNo.TabIndex = 8;
            this.updateStockBatchNo.TextChanged += new System.EventHandler(this.updateStockBatchNo_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(507, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Batch No";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(507, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Expiry Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(507, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Units";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(507, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Drug";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Selling Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Buying Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier";
            // 
            // updateStockdataGridView
            // 
            this.updateStockdataGridView.AllowUserToOrderColumns = true;
            this.updateStockdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.updateStockdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.updateStockdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updateStockdataGridView.Location = new System.Drawing.Point(78, 295);
            this.updateStockdataGridView.Name = "updateStockdataGridView";
            this.updateStockdataGridView.Size = new System.Drawing.Size(915, 150);
            this.updateStockdataGridView.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(74, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 24);
            this.label9.TabIndex = 4;
            this.label9.Text = "search";
            // 
            // searchUpdateStock
            // 
            this.searchUpdateStock.Location = new System.Drawing.Point(212, 262);
            this.searchUpdateStock.Name = "searchUpdateStock";
            this.searchUpdateStock.Size = new System.Drawing.Size(277, 20);
            this.searchUpdateStock.TabIndex = 5;
            this.searchUpdateStock.TextChanged += new System.EventHandler(this.searchUpdateStock_TextChanged);
            // 
            // updateStockId
            // 
            this.updateStockId.Location = new System.Drawing.Point(554, 266);
            this.updateStockId.Name = "updateStockId";
            this.updateStockId.Size = new System.Drawing.Size(162, 20);
            this.updateStockId.TabIndex = 6;
            this.updateStockId.Visible = false;
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(798, 269);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 7;
            // 
            // UpdateStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 458);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.updateStockId);
            this.Controls.Add(this.searchUpdateStock);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.updateStockdataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateStock";
            this.Load += new System.EventHandler(this.UpdateStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateStockdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateStockButton;
        private System.Windows.Forms.TextBox updateStockSellingPrice;
        private System.Windows.Forms.TextBox updateStockBuyingPrice;
        private System.Windows.Forms.TextBox updateStockQuantity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox drugidforeignkey;
        private System.Windows.Forms.TextBox supplieridforeignkey;
        private System.Windows.Forms.Button cancelStock;
        private System.Windows.Forms.ComboBox updateSupplierCombo;
        private System.Windows.Forms.ComboBox updateDrugCombo;
        private System.Windows.Forms.ComboBox updateStockUnit;
        private System.Windows.Forms.DateTimePicker updateStockExpiriDate;
        private System.Windows.Forms.TextBox updateStockBatchNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView updateStockdataGridView;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox searchUpdateStock;
        private System.Windows.Forms.TextBox updateStockId;
        private System.Windows.Forms.TextBox updatestockpfsession;
        private System.Windows.Forms.Label rowCountLabel;
    }
}