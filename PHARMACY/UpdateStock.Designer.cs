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
            this.originalQuantityTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.quantityCheckWarningLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.quantitySoldTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.remainingQuantityTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.updateStockId = new System.Windows.Forms.TextBox();
            this.StatuscomboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.updatestockpfsession = new System.Windows.Forms.TextBox();
            this.drugidforeignkey = new System.Windows.Forms.TextBox();
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
            this.supplieridforeignkey = new System.Windows.Forms.TextBox();
            this.updateStockdataGridView = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.searchUpdateStock = new System.Windows.Forms.TextBox();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.stockIDTextBox = new System.Windows.Forms.TextBox();
            this.drugNameTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.reoderLevelTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateStockdataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateStockButton
            // 
            this.updateStockButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateStockButton.Location = new System.Drawing.Point(836, 265);
            this.updateStockButton.Name = "updateStockButton";
            this.updateStockButton.Size = new System.Drawing.Size(80, 31);
            this.updateStockButton.TabIndex = 16;
            this.updateStockButton.Text = "update";
            this.updateStockButton.UseVisualStyleBackColor = true;
            this.updateStockButton.Click += new System.EventHandler(this.updateStockButton_Click);
            // 
            // updateStockSellingPrice
            // 
            this.updateStockSellingPrice.Location = new System.Drawing.Point(800, 100);
            this.updateStockSellingPrice.MaxLength = 30;
            this.updateStockSellingPrice.Name = "updateStockSellingPrice";
            this.updateStockSellingPrice.Size = new System.Drawing.Size(352, 26);
            this.updateStockSellingPrice.TabIndex = 15;
            // 
            // updateStockBuyingPrice
            // 
            this.updateStockBuyingPrice.Location = new System.Drawing.Point(800, 58);
            this.updateStockBuyingPrice.MaxLength = 30;
            this.updateStockBuyingPrice.Name = "updateStockBuyingPrice";
            this.updateStockBuyingPrice.Size = new System.Drawing.Size(352, 26);
            this.updateStockBuyingPrice.TabIndex = 14;
            // 
            // originalQuantityTextBox
            // 
            this.originalQuantityTextBox.Location = new System.Drawing.Point(180, 117);
            this.originalQuantityTextBox.Name = "originalQuantityTextBox";
            this.originalQuantityTextBox.Size = new System.Drawing.Size(312, 26);
            this.originalQuantityTextBox.TabIndex = 13;
            this.originalQuantityTextBox.TextChanged += new System.EventHandler(this.originalQuantityTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reoderLevelTextBox);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.quantityCheckWarningLabel);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.quantitySoldTextBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.remainingQuantityTextBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.updateStockId);
            this.groupBox1.Controls.Add(this.StatuscomboBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.updatestockpfsession);
            this.groupBox1.Controls.Add(this.drugidforeignkey);
            this.groupBox1.Controls.Add(this.cancelStock);
            this.groupBox1.Controls.Add(this.updateStockButton);
            this.groupBox1.Controls.Add(this.updateStockSellingPrice);
            this.groupBox1.Controls.Add(this.updateStockBuyingPrice);
            this.groupBox1.Controls.Add(this.originalQuantityTextBox);
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
            this.groupBox1.Location = new System.Drawing.Point(48, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1259, 300);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Stock";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // quantityCheckWarningLabel
            // 
            this.quantityCheckWarningLabel.AutoSize = true;
            this.quantityCheckWarningLabel.Location = new System.Drawing.Point(176, 181);
            this.quantityCheckWarningLabel.Name = "quantityCheckWarningLabel";
            this.quantityCheckWarningLabel.Size = new System.Drawing.Size(14, 20);
            this.quantityCheckWarningLabel.TabIndex = 27;
            this.quantityCheckWarningLabel.Text = ".";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(1056, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 31);
            this.button1.TabIndex = 19;
            this.button1.Text = "load all drugs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // quantitySoldTextBox
            // 
            this.quantitySoldTextBox.Enabled = false;
            this.quantitySoldTextBox.Location = new System.Drawing.Point(180, 200);
            this.quantitySoldTextBox.Name = "quantitySoldTextBox";
            this.quantitySoldTextBox.Size = new System.Drawing.Size(313, 26);
            this.quantitySoldTextBox.TabIndex = 26;
            this.quantitySoldTextBox.TextChanged += new System.EventHandler(this.quantitySoldTextBox_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 201);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 20);
            this.label14.TabIndex = 25;
            this.label14.Text = "Quantity Sold";
            // 
            // remainingQuantityTextBox
            // 
            this.remainingQuantityTextBox.Enabled = false;
            this.remainingQuantityTextBox.Location = new System.Drawing.Point(180, 152);
            this.remainingQuantityTextBox.Name = "remainingQuantityTextBox";
            this.remainingQuantityTextBox.Size = new System.Drawing.Size(313, 26);
            this.remainingQuantityTextBox.TabIndex = 24;
            this.remainingQuantityTextBox.TextChanged += new System.EventHandler(this.remainingQuantityTextBox_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(166, 20);
            this.label13.TabIndex = 23;
            this.label13.Text = "Remaining Quantity";
            // 
            // updateStockId
            // 
            this.updateStockId.Location = new System.Drawing.Point(573, 263);
            this.updateStockId.Name = "updateStockId";
            this.updateStockId.Size = new System.Drawing.Size(207, 26);
            this.updateStockId.TabIndex = 6;
            this.updateStockId.Visible = false;
            // 
            // StatuscomboBox
            // 
            this.StatuscomboBox.FormattingEnabled = true;
            this.StatuscomboBox.Items.AddRange(new object[] {
            "1",
            "0"});
            this.StatuscomboBox.Location = new System.Drawing.Point(800, 229);
            this.StatuscomboBox.Name = "StatuscomboBox";
            this.StatuscomboBox.Size = new System.Drawing.Size(352, 28);
            this.StatuscomboBox.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(659, 229);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 20);
            this.label12.TabIndex = 21;
            this.label12.Text = "Status";
            // 
            // updatestockpfsession
            // 
            this.updatestockpfsession.Location = new System.Drawing.Point(430, -10);
            this.updatestockpfsession.Name = "updatestockpfsession";
            this.updatestockpfsession.Size = new System.Drawing.Size(178, 26);
            this.updatestockpfsession.TabIndex = 20;
            this.updatestockpfsession.Visible = false;
            // 
            // drugidforeignkey
            // 
            this.drugidforeignkey.Location = new System.Drawing.Point(723, -10);
            this.drugidforeignkey.Name = "drugidforeignkey";
            this.drugidforeignkey.Size = new System.Drawing.Size(192, 26);
            this.drugidforeignkey.TabIndex = 19;
            this.drugidforeignkey.Visible = false;
            // 
            // cancelStock
            // 
            this.cancelStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelStock.Location = new System.Drawing.Point(951, 265);
            this.cancelStock.Name = "cancelStock";
            this.cancelStock.Size = new System.Drawing.Size(80, 31);
            this.cancelStock.TabIndex = 17;
            this.cancelStock.Text = "cancel";
            this.cancelStock.UseVisualStyleBackColor = true;
            this.cancelStock.Click += new System.EventHandler(this.cancelStock_Click);
            // 
            // updateSupplierCombo
            // 
            this.updateSupplierCombo.FormattingEnabled = true;
            this.updateSupplierCombo.Location = new System.Drawing.Point(180, 25);
            this.updateSupplierCombo.Name = "updateSupplierCombo";
            this.updateSupplierCombo.Size = new System.Drawing.Size(312, 28);
            this.updateSupplierCombo.TabIndex = 12;
            this.updateSupplierCombo.SelectedIndexChanged += new System.EventHandler(this.addSupplierCombo_SelectedIndexChanged);
            // 
            // updateDrugCombo
            // 
            this.updateDrugCombo.FormattingEnabled = true;
            this.updateDrugCombo.Location = new System.Drawing.Point(180, 73);
            this.updateDrugCombo.Name = "updateDrugCombo";
            this.updateDrugCombo.Size = new System.Drawing.Size(312, 28);
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
            this.updateStockUnit.Location = new System.Drawing.Point(800, 22);
            this.updateStockUnit.Name = "updateStockUnit";
            this.updateStockUnit.Size = new System.Drawing.Size(352, 28);
            this.updateStockUnit.TabIndex = 10;
            // 
            // updateStockExpiriDate
            // 
            this.updateStockExpiriDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.updateStockExpiriDate.Location = new System.Drawing.Point(800, 148);
            this.updateStockExpiriDate.Name = "updateStockExpiriDate";
            this.updateStockExpiriDate.Size = new System.Drawing.Size(349, 26);
            this.updateStockExpiriDate.TabIndex = 9;
            // 
            // updateStockBatchNo
            // 
            this.updateStockBatchNo.Location = new System.Drawing.Point(800, 183);
            this.updateStockBatchNo.MaxLength = 30;
            this.updateStockBatchNo.Name = "updateStockBatchNo";
            this.updateStockBatchNo.Size = new System.Drawing.Size(349, 26);
            this.updateStockBatchNo.TabIndex = 8;
            this.updateStockBatchNo.TextChanged += new System.EventHandler(this.updateStockBatchNo_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(656, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Batch No";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(656, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Expiry Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(656, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Units";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Drug";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(654, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Selling Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(656, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Buying Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Original Quantity";
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
            // supplieridforeignkey
            // 
            this.supplieridforeignkey.Location = new System.Drawing.Point(255, 4);
            this.supplieridforeignkey.Name = "supplieridforeignkey";
            this.supplieridforeignkey.Size = new System.Drawing.Size(157, 20);
            this.supplieridforeignkey.TabIndex = 18;
            this.supplieridforeignkey.Visible = false;
            // 
            // updateStockdataGridView
            // 
            this.updateStockdataGridView.AllowUserToOrderColumns = true;
            this.updateStockdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.updateStockdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.updateStockdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updateStockdataGridView.Location = new System.Drawing.Point(38, 396);
            this.updateStockdataGridView.Name = "updateStockdataGridView";
            this.updateStockdataGridView.Size = new System.Drawing.Size(1269, 341);
            this.updateStockdataGridView.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(408, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 24);
            this.label9.TabIndex = 4;
            this.label9.Text = "Batch No.";
            // 
            // searchUpdateStock
            // 
            this.searchUpdateStock.Location = new System.Drawing.Point(515, 20);
            this.searchUpdateStock.Name = "searchUpdateStock";
            this.searchUpdateStock.Size = new System.Drawing.Size(193, 20);
            this.searchUpdateStock.TabIndex = 5;
            this.searchUpdateStock.TextChanged += new System.EventHandler(this.searchUpdateStock_TextChanged);
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(1122, 351);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.stockIDTextBox);
            this.groupBox2.Controls.Add(this.drugNameTextBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.searchUpdateStock);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(48, 329);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1050, 50);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "search by batch no. and drug name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(753, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 24);
            this.label11.TabIndex = 8;
            this.label11.Text = "Sock ID";
            // 
            // stockIDTextBox
            // 
            this.stockIDTextBox.Location = new System.Drawing.Point(840, 19);
            this.stockIDTextBox.Name = "stockIDTextBox";
            this.stockIDTextBox.Size = new System.Drawing.Size(193, 20);
            this.stockIDTextBox.TabIndex = 9;
            this.stockIDTextBox.TextChanged += new System.EventHandler(this.stockIDTextBox_TextChanged);
            // 
            // drugNameTextBox
            // 
            this.drugNameTextBox.Location = new System.Drawing.Point(157, 21);
            this.drugNameTextBox.Name = "drugNameTextBox";
            this.drugNameTextBox.Size = new System.Drawing.Size(208, 20);
            this.drugNameTextBox.TabIndex = 7;
            this.drugNameTextBox.TextChanged += new System.EventHandler(this.drugNameTextBox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(35, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 24);
            this.label10.TabIndex = 6;
            this.label10.Text = "Drug Name";
            // 
            // reoderLevelTextBox
            // 
            this.reoderLevelTextBox.Location = new System.Drawing.Point(180, 247);
            this.reoderLevelTextBox.MaxLength = 30;
            this.reoderLevelTextBox.Name = "reoderLevelTextBox";
            this.reoderLevelTextBox.Size = new System.Drawing.Size(312, 26);
            this.reoderLevelTextBox.TabIndex = 29;
            this.reoderLevelTextBox.TextChanged += new System.EventHandler(this.reoderLevelTextBox_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 253);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 20);
            this.label15.TabIndex = 28;
            this.label15.Text = "Re-oder level";
            // 
            // UpdateStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.supplieridforeignkey);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.updateStockdataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UPDATE STOCK";
            this.Load += new System.EventHandler(this.UpdateStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateStockdataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateStockButton;
        private System.Windows.Forms.TextBox updateStockSellingPrice;
        private System.Windows.Forms.TextBox updateStockBuyingPrice;
        private System.Windows.Forms.TextBox originalQuantityTextBox;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox drugNameTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox stockIDTextBox;
        private System.Windows.Forms.ComboBox StatuscomboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox remainingQuantityTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox quantitySoldTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label quantityCheckWarningLabel;
        private System.Windows.Forms.TextBox reoderLevelTextBox;
        private System.Windows.Forms.Label label15;
    }
}