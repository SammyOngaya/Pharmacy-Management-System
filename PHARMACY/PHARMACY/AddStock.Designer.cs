namespace PHARMACY
{
    partial class AddStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStock));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.drugidforeignkey = new System.Windows.Forms.TextBox();
            this.supplieridforeignkey = new System.Windows.Forms.TextBox();
            this.cancelStock = new System.Windows.Forms.Button();
            this.saveStock = new System.Windows.Forms.Button();
            this.sellingPrice = new System.Windows.Forms.TextBox();
            this.buyingPrice = new System.Windows.Forms.TextBox();
            this.addQuantity = new System.Windows.Forms.TextBox();
            this.addSupplierCombo = new System.Windows.Forms.ComboBox();
            this.addDrugCombo = new System.Windows.Forms.ComboBox();
            this.addUnit = new System.Windows.Forms.ComboBox();
            this.addDate = new System.Windows.Forms.DateTimePicker();
            this.addBatchNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addStockdataGridView = new System.Windows.Forms.DataGridView();
            this.addstockpfsession = new System.Windows.Forms.TextBox();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addStockdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.drugidforeignkey);
            this.groupBox1.Controls.Add(this.supplieridforeignkey);
            this.groupBox1.Controls.Add(this.cancelStock);
            this.groupBox1.Controls.Add(this.saveStock);
            this.groupBox1.Controls.Add(this.sellingPrice);
            this.groupBox1.Controls.Add(this.buyingPrice);
            this.groupBox1.Controls.Add(this.addQuantity);
            this.groupBox1.Controls.Add(this.addSupplierCombo);
            this.groupBox1.Controls.Add(this.addDrugCombo);
            this.groupBox1.Controls.Add(this.addUnit);
            this.groupBox1.Controls.Add(this.addDate);
            this.groupBox1.Controls.Add(this.addBatchNo);
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
            this.groupBox1.Location = new System.Drawing.Point(25, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Stock";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // drugidforeignkey
            // 
            this.drugidforeignkey.Location = new System.Drawing.Point(718, -7);
            this.drugidforeignkey.Name = "drugidforeignkey";
            this.drugidforeignkey.Size = new System.Drawing.Size(100, 26);
            this.drugidforeignkey.TabIndex = 19;
            this.drugidforeignkey.Visible = false;
            this.drugidforeignkey.TextChanged += new System.EventHandler(this.drugidforeignkey_TextChanged);
            // 
            // supplieridforeignkey
            // 
            this.supplieridforeignkey.Location = new System.Drawing.Point(202, -7);
            this.supplieridforeignkey.Name = "supplieridforeignkey";
            this.supplieridforeignkey.Size = new System.Drawing.Size(100, 26);
            this.supplieridforeignkey.TabIndex = 18;
            this.supplieridforeignkey.Visible = false;
            this.supplieridforeignkey.TextChanged += new System.EventHandler(this.supplieridforeignkey_TextChanged);
            // 
            // cancelStock
            // 
            this.cancelStock.Location = new System.Drawing.Point(528, 205);
            this.cancelStock.Name = "cancelStock";
            this.cancelStock.Size = new System.Drawing.Size(75, 31);
            this.cancelStock.TabIndex = 17;
            this.cancelStock.Text = "cancel";
            this.cancelStock.UseVisualStyleBackColor = true;
            this.cancelStock.Click += new System.EventHandler(this.cancelStock_Click);
            // 
            // saveStock
            // 
            this.saveStock.Location = new System.Drawing.Point(413, 205);
            this.saveStock.Name = "saveStock";
            this.saveStock.Size = new System.Drawing.Size(75, 31);
            this.saveStock.TabIndex = 16;
            this.saveStock.Text = "save";
            this.saveStock.UseVisualStyleBackColor = true;
            this.saveStock.Click += new System.EventHandler(this.saveStock_Click);
            // 
            // sellingPrice
            // 
            this.sellingPrice.Location = new System.Drawing.Point(134, 156);
            this.sellingPrice.Name = "sellingPrice";
            this.sellingPrice.Size = new System.Drawing.Size(277, 26);
            this.sellingPrice.TabIndex = 15;
            this.sellingPrice.TextChanged += new System.EventHandler(this.sellingPrice_TextChanged);
            // 
            // buyingPrice
            // 
            this.buyingPrice.Location = new System.Drawing.Point(134, 115);
            this.buyingPrice.Name = "buyingPrice";
            this.buyingPrice.Size = new System.Drawing.Size(277, 26);
            this.buyingPrice.TabIndex = 14;
            this.buyingPrice.TextChanged += new System.EventHandler(this.buyingPrice_TextChanged);
            // 
            // addQuantity
            // 
            this.addQuantity.Location = new System.Drawing.Point(134, 73);
            this.addQuantity.Name = "addQuantity";
            this.addQuantity.Size = new System.Drawing.Size(277, 26);
            this.addQuantity.TabIndex = 13;
            this.addQuantity.TextChanged += new System.EventHandler(this.addQuantity_TextChanged);
            // 
            // addSupplierCombo
            // 
            this.addSupplierCombo.FormattingEnabled = true;
            this.addSupplierCombo.Location = new System.Drawing.Point(134, 25);
            this.addSupplierCombo.Name = "addSupplierCombo";
            this.addSupplierCombo.Size = new System.Drawing.Size(277, 28);
            this.addSupplierCombo.TabIndex = 12;
            this.addSupplierCombo.SelectedIndexChanged += new System.EventHandler(this.addSupplierCombo_SelectedIndexChanged);
            // 
            // addDrugCombo
            // 
            this.addDrugCombo.FormattingEnabled = true;
            this.addDrugCombo.Location = new System.Drawing.Point(651, 22);
            this.addDrugCombo.Name = "addDrugCombo";
            this.addDrugCombo.Size = new System.Drawing.Size(241, 28);
            this.addDrugCombo.TabIndex = 11;
            this.addDrugCombo.SelectedIndexChanged += new System.EventHandler(this.addDrugCombo_SelectedIndexChanged);
            // 
            // addUnit
            // 
            this.addUnit.FormattingEnabled = true;
            this.addUnit.Items.AddRange(new object[] {
            "gms",
            "mgs",
            "mls"});
            this.addUnit.Location = new System.Drawing.Point(651, 74);
            this.addUnit.Name = "addUnit";
            this.addUnit.Size = new System.Drawing.Size(241, 28);
            this.addUnit.TabIndex = 10;
            this.addUnit.SelectedIndexChanged += new System.EventHandler(this.addUnit_SelectedIndexChanged);
            // 
            // addDate
            // 
            this.addDate.CustomFormat = "";
            this.addDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.addDate.Location = new System.Drawing.Point(651, 114);
            this.addDate.Name = "addDate";
            this.addDate.Size = new System.Drawing.Size(241, 26);
            this.addDate.TabIndex = 9;
            this.addDate.ValueChanged += new System.EventHandler(this.addDate_ValueChanged);
            // 
            // addBatchNo
            // 
            this.addBatchNo.Location = new System.Drawing.Point(651, 151);
            this.addBatchNo.Name = "addBatchNo";
            this.addBatchNo.Size = new System.Drawing.Size(241, 26);
            this.addBatchNo.TabIndex = 8;
            this.addBatchNo.TextChanged += new System.EventHandler(this.addBatchNo_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(507, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Batch No";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(507, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Expiry Date";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(507, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Units";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(507, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Drug";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Selling Price";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Buying Price";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantity";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // addStockdataGridView
            // 
            this.addStockdataGridView.AllowUserToOrderColumns = true;
            this.addStockdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addStockdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.addStockdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addStockdataGridView.Location = new System.Drawing.Point(25, 306);
            this.addStockdataGridView.Name = "addStockdataGridView";
            this.addStockdataGridView.Size = new System.Drawing.Size(936, 150);
            this.addStockdataGridView.TabIndex = 1;
            this.addStockdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.addStockdataGridView_CellContentClick);
            // 
            // addstockpfsession
            // 
            this.addstockpfsession.Location = new System.Drawing.Point(385, 12);
            this.addstockpfsession.Name = "addstockpfsession";
            this.addstockpfsession.Size = new System.Drawing.Size(51, 20);
            this.addstockpfsession.TabIndex = 2;
            this.addstockpfsession.Visible = false;
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(477, 290);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 5;
            // 
            // AddStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 459);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.addstockpfsession);
            this.Controls.Add(this.addStockdataGridView);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddStock";
            this.Load += new System.EventHandler(this.AddStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addStockdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox sellingPrice;
        private System.Windows.Forms.TextBox buyingPrice;
        private System.Windows.Forms.TextBox addQuantity;
        private System.Windows.Forms.ComboBox addSupplierCombo;
        private System.Windows.Forms.ComboBox addDrugCombo;
        private System.Windows.Forms.ComboBox addUnit;
        private System.Windows.Forms.DateTimePicker addDate;
        private System.Windows.Forms.TextBox addBatchNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelStock;
        private System.Windows.Forms.Button saveStock;
        private System.Windows.Forms.DataGridView addStockdataGridView;
        private System.Windows.Forms.TextBox supplieridforeignkey;
        private System.Windows.Forms.TextBox drugidforeignkey;
        private System.Windows.Forms.TextBox addstockpfsession;
        private System.Windows.Forms.Label rowCountLabel;
    }
}