namespace PHARMACY
{
    partial class UpdateSupplierPriceList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateSupplierPriceList));
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.saveSupplierPriceListButton = new System.Windows.Forms.Button();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.addSupplierCombo = new System.Windows.Forms.ComboBox();
            this.supplierPriceListDataGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pfsession = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.searchSupplierPriceListButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.searchDrugTextBox = new System.Windows.Forms.TextBox();
            this.supplierIDTextBox = new System.Windows.Forms.TextBox();
            this.drugIDTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.supplierPriceListDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(362, 86);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 23;
            // 
            // saveSupplierPriceListButton
            // 
            this.saveSupplierPriceListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveSupplierPriceListButton.Location = new System.Drawing.Point(138, 165);
            this.saveSupplierPriceListButton.Name = "saveSupplierPriceListButton";
            this.saveSupplierPriceListButton.Size = new System.Drawing.Size(111, 48);
            this.saveSupplierPriceListButton.TabIndex = 16;
            this.saveSupplierPriceListButton.Text = "save";
            this.saveSupplierPriceListButton.UseVisualStyleBackColor = true;
            this.saveSupplierPriceListButton.Click += new System.EventHandler(this.saveSupplierPriceListButton_Click);
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(138, 91);
            this.PriceTextBox.MaxLength = 20;
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(295, 26);
            this.PriceTextBox.TabIndex = 14;
            this.PriceTextBox.TextChanged += new System.EventHandler(this.PriceTextBox_TextChanged);
            // 
            // addSupplierCombo
            // 
            this.addSupplierCombo.FormattingEnabled = true;
            this.addSupplierCombo.Location = new System.Drawing.Point(62, 18);
            this.addSupplierCombo.Name = "addSupplierCombo";
            this.addSupplierCombo.Size = new System.Drawing.Size(132, 21);
            this.addSupplierCombo.TabIndex = 12;
            this.addSupplierCombo.SelectedIndexChanged += new System.EventHandler(this.addSupplierCombo_SelectedIndexChanged);
            // 
            // supplierPriceListDataGridView
            // 
            this.supplierPriceListDataGridView.AllowUserToOrderColumns = true;
            this.supplierPriceListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.supplierPriceListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplierPriceListDataGridView.Location = new System.Drawing.Point(613, 31);
            this.supplierPriceListDataGridView.Name = "supplierPriceListDataGridView";
            this.supplierPriceListDataGridView.Size = new System.Drawing.Size(746, 370);
            this.supplierPriceListDataGridView.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Drug";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier";
            // 
            // pfsession
            // 
            this.pfsession.Location = new System.Drawing.Point(296, 79);
            this.pfsession.Name = "pfsession";
            this.pfsession.Size = new System.Drawing.Size(102, 20);
            this.pfsession.TabIndex = 22;
            this.pfsession.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.saveSupplierPriceListButton);
            this.groupBox1.Controls.Add(this.PriceTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(13, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 299);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "supplier price list";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(309, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 48);
            this.button1.TabIndex = 17;
            this.button1.Text = "remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // searchSupplierPriceListButton
            // 
            this.searchSupplierPriceListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchSupplierPriceListButton.Location = new System.Drawing.Point(473, 13);
            this.searchSupplierPriceListButton.Name = "searchSupplierPriceListButton";
            this.searchSupplierPriceListButton.Size = new System.Drawing.Size(102, 31);
            this.searchSupplierPriceListButton.TabIndex = 18;
            this.searchSupplierPriceListButton.Text = "search";
            this.searchSupplierPriceListButton.UseVisualStyleBackColor = true;
            this.searchSupplierPriceListButton.Click += new System.EventHandler(this.searchSupplierPriceListButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.searchDrugTextBox);
            this.groupBox2.Controls.Add(this.searchSupplierPriceListButton);
            this.groupBox2.Controls.Add(this.addSupplierCombo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(13, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(593, 50);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "search";
            // 
            // searchDrugTextBox
            // 
            this.searchDrugTextBox.Location = new System.Drawing.Point(246, 19);
            this.searchDrugTextBox.MaxLength = 150;
            this.searchDrugTextBox.Name = "searchDrugTextBox";
            this.searchDrugTextBox.Size = new System.Drawing.Size(187, 20);
            this.searchDrugTextBox.TabIndex = 19;
            this.searchDrugTextBox.TextChanged += new System.EventHandler(this.searchDrugTextBox_TextChanged);
            // 
            // supplierIDTextBox
            // 
            this.supplierIDTextBox.Location = new System.Drawing.Point(75, 5);
            this.supplierIDTextBox.Name = "supplierIDTextBox";
            this.supplierIDTextBox.Size = new System.Drawing.Size(187, 20);
            this.supplierIDTextBox.TabIndex = 27;
            this.supplierIDTextBox.Visible = false;
            // 
            // drugIDTextBox
            // 
            this.drugIDTextBox.Location = new System.Drawing.Point(322, 5);
            this.drugIDTextBox.Name = "drugIDTextBox";
            this.drugIDTextBox.Size = new System.Drawing.Size(187, 20);
            this.drugIDTextBox.TabIndex = 28;
            this.drugIDTextBox.Visible = false;
            // 
            // UpdateSupplierPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 418);
            this.Controls.Add(this.supplierIDTextBox);
            this.Controls.Add(this.drugIDTextBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.supplierPriceListDataGridView);
            this.Controls.Add(this.pfsession);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateSupplierPriceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UPDATE SUPPLIER PRICE LIST";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UpdateSupplierPriceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierPriceListDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.Button saveSupplierPriceListButton;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.ComboBox addSupplierCombo;
        private System.Windows.Forms.DataGridView supplierPriceListDataGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pfsession;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button searchSupplierPriceListButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox searchDrugTextBox;
        private System.Windows.Forms.TextBox supplierIDTextBox;
        private System.Windows.Forms.TextBox drugIDTextBox;
        private System.Windows.Forms.Button button1;
    }
}