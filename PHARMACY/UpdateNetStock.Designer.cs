namespace PHARMACY
{
    partial class UpdateNetStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateNetStock));
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.drugNameTextBox = new System.Windows.Forms.TextBox();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.updatestockpfsession = new System.Windows.Forms.TextBox();
            this.drugidforeignkey = new System.Windows.Forms.TextBox();
            this.cancelStock = new System.Windows.Forms.Button();
            this.updateStockId = new System.Windows.Forms.TextBox();
            this.supplieridforeignkey = new System.Windows.Forms.TextBox();
            this.updateStockdataGridView = new System.Windows.Forms.DataGridView();
            this.updateStockButton = new System.Windows.Forms.Button();
            this.updateStockSellingPrice = new System.Windows.Forms.TextBox();
            this.updateStockBuyingPrice = new System.Windows.Forms.TextBox();
            this.updateStockQuantity = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.updateStockExpiriDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateStockdataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.drugNameTextBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(217, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 50);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "search by batch no. and drug name";
            // 
            // drugNameTextBox
            // 
            this.drugNameTextBox.Location = new System.Drawing.Point(177, 21);
            this.drugNameTextBox.Name = "drugNameTextBox";
            this.drugNameTextBox.Size = new System.Drawing.Size(222, 20);
            this.drugNameTextBox.TabIndex = 7;
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(948, 388);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 21;
            // 
            // updatestockpfsession
            // 
            this.updatestockpfsession.Location = new System.Drawing.Point(635, 103);
            this.updatestockpfsession.Name = "updatestockpfsession";
            this.updatestockpfsession.Size = new System.Drawing.Size(178, 20);
            this.updatestockpfsession.TabIndex = 20;
            this.updatestockpfsession.Visible = false;
            // 
            // drugidforeignkey
            // 
            this.drugidforeignkey.Location = new System.Drawing.Point(928, 103);
            this.drugidforeignkey.Name = "drugidforeignkey";
            this.drugidforeignkey.Size = new System.Drawing.Size(192, 20);
            this.drugidforeignkey.TabIndex = 19;
            this.drugidforeignkey.Visible = false;
            // 
            // cancelStock
            // 
            this.cancelStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelStock.Location = new System.Drawing.Point(528, 205);
            this.cancelStock.Name = "cancelStock";
            this.cancelStock.Size = new System.Drawing.Size(80, 31);
            this.cancelStock.TabIndex = 17;
            this.cancelStock.Text = "cancel";
            this.cancelStock.UseVisualStyleBackColor = true;
            // 
            // updateStockId
            // 
            this.updateStockId.Location = new System.Drawing.Point(723, 205);
            this.updateStockId.Name = "updateStockId";
            this.updateStockId.Size = new System.Drawing.Size(162, 26);
            this.updateStockId.TabIndex = 6;
            this.updateStockId.Visible = false;
            // 
            // supplieridforeignkey
            // 
            this.supplieridforeignkey.Location = new System.Drawing.Point(382, 103);
            this.supplieridforeignkey.Name = "supplieridforeignkey";
            this.supplieridforeignkey.Size = new System.Drawing.Size(157, 20);
            this.supplieridforeignkey.TabIndex = 23;
            this.supplieridforeignkey.Visible = false;
            // 
            // updateStockdataGridView
            // 
            this.updateStockdataGridView.AllowUserToOrderColumns = true;
            this.updateStockdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.updateStockdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.updateStockdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updateStockdataGridView.Location = new System.Drawing.Point(186, 457);
            this.updateStockdataGridView.Name = "updateStockdataGridView";
            this.updateStockdataGridView.Size = new System.Drawing.Size(968, 171);
            this.updateStockdataGridView.TabIndex = 20;
            // 
            // updateStockButton
            // 
            this.updateStockButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateStockButton.Location = new System.Drawing.Point(413, 205);
            this.updateStockButton.Name = "updateStockButton";
            this.updateStockButton.Size = new System.Drawing.Size(80, 31);
            this.updateStockButton.TabIndex = 16;
            this.updateStockButton.Text = "update";
            this.updateStockButton.UseVisualStyleBackColor = true;
            // 
            // updateStockSellingPrice
            // 
            this.updateStockSellingPrice.Location = new System.Drawing.Point(587, 134);
            this.updateStockSellingPrice.MaxLength = 30;
            this.updateStockSellingPrice.Name = "updateStockSellingPrice";
            this.updateStockSellingPrice.Size = new System.Drawing.Size(277, 26);
            this.updateStockSellingPrice.TabIndex = 15;
            // 
            // updateStockBuyingPrice
            // 
            this.updateStockBuyingPrice.Location = new System.Drawing.Point(587, 58);
            this.updateStockBuyingPrice.MaxLength = 30;
            this.updateStockBuyingPrice.Name = "updateStockBuyingPrice";
            this.updateStockBuyingPrice.Size = new System.Drawing.Size(277, 26);
            this.updateStockBuyingPrice.TabIndex = 14;
            // 
            // updateStockQuantity
            // 
            this.updateStockQuantity.Enabled = false;
            this.updateStockQuantity.Location = new System.Drawing.Point(146, 49);
            this.updateStockQuantity.Name = "updateStockQuantity";
            this.updateStockQuantity.Size = new System.Drawing.Size(277, 26);
            this.updateStockQuantity.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancelStock);
            this.groupBox1.Controls.Add(this.updateStockId);
            this.groupBox1.Controls.Add(this.updateStockButton);
            this.groupBox1.Controls.Add(this.updateStockSellingPrice);
            this.groupBox1.Controls.Add(this.updateStockBuyingPrice);
            this.groupBox1.Controls.Add(this.updateStockQuantity);
            this.groupBox1.Controls.Add(this.updateStockExpiriDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(205, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 242);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Net Stock";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // updateStockExpiriDate
            // 
            this.updateStockExpiriDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.updateStockExpiriDate.Location = new System.Drawing.Point(146, 138);
            this.updateStockExpiriDate.Name = "updateStockExpiriDate";
            this.updateStockExpiriDate.Size = new System.Drawing.Size(241, 26);
            this.updateStockExpiriDate.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Expiry Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Selling Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Buying Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantity";
            // 
            // UpdateNetStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.drugidforeignkey);
            this.Controls.Add(this.updatestockpfsession);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.supplieridforeignkey);
            this.Controls.Add(this.updateStockdataGridView);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateNetStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Net Stock";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateStockdataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox drugNameTextBox;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.TextBox updatestockpfsession;
        private System.Windows.Forms.TextBox drugidforeignkey;
        private System.Windows.Forms.Button cancelStock;
        private System.Windows.Forms.TextBox updateStockId;
        private System.Windows.Forms.TextBox supplieridforeignkey;
        private System.Windows.Forms.DataGridView updateStockdataGridView;
        private System.Windows.Forms.Button updateStockButton;
        private System.Windows.Forms.TextBox updateStockSellingPrice;
        private System.Windows.Forms.TextBox updateStockBuyingPrice;
        private System.Windows.Forms.TextBox updateStockQuantity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker updateStockExpiriDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}