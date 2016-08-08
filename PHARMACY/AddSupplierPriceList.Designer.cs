namespace PHARMACY
{
    partial class AddSupplierPriceList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSupplierPriceList));
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.drugidforeignkey = new System.Windows.Forms.TextBox();
            this.supplieridforeignkey = new System.Windows.Forms.TextBox();
            this.saveSupplierPriceListButton = new System.Windows.Forms.Button();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.addSupplierCombo = new System.Windows.Forms.ComboBox();
            this.addDrugCombo = new System.Windows.Forms.ComboBox();
            this.supplierPriceListDataGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pfsession = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createNewSupplierPriceListButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.supplierPriceListDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(623, 347);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 9;
            // 
            // drugidforeignkey
            // 
            this.drugidforeignkey.Location = new System.Drawing.Point(161, 6);
            this.drugidforeignkey.Name = "drugidforeignkey";
            this.drugidforeignkey.Size = new System.Drawing.Size(100, 20);
            this.drugidforeignkey.TabIndex = 19;
            this.drugidforeignkey.Visible = false;
            // 
            // supplieridforeignkey
            // 
            this.supplieridforeignkey.Location = new System.Drawing.Point(23, 12);
            this.supplieridforeignkey.Name = "supplieridforeignkey";
            this.supplieridforeignkey.Size = new System.Drawing.Size(100, 20);
            this.supplieridforeignkey.TabIndex = 18;
            this.supplieridforeignkey.Visible = false;
            // 
            // saveSupplierPriceListButton
            // 
            this.saveSupplierPriceListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveSupplierPriceListButton.Location = new System.Drawing.Point(79, 209);
            this.saveSupplierPriceListButton.Name = "saveSupplierPriceListButton";
            this.saveSupplierPriceListButton.Size = new System.Drawing.Size(97, 44);
            this.saveSupplierPriceListButton.TabIndex = 16;
            this.saveSupplierPriceListButton.Text = "save";
            this.saveSupplierPriceListButton.UseVisualStyleBackColor = true;
            this.saveSupplierPriceListButton.Click += new System.EventHandler(this.saveSupplierPriceListButton_Click);
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(137, 139);
            this.PriceTextBox.MaxLength = 20;
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(277, 26);
            this.PriceTextBox.TabIndex = 14;
            // 
            // addSupplierCombo
            // 
            this.addSupplierCombo.FormattingEnabled = true;
            this.addSupplierCombo.Location = new System.Drawing.Point(137, 49);
            this.addSupplierCombo.Name = "addSupplierCombo";
            this.addSupplierCombo.Size = new System.Drawing.Size(277, 28);
            this.addSupplierCombo.TabIndex = 12;
            this.addSupplierCombo.SelectedIndexChanged += new System.EventHandler(this.addSupplierCombo_SelectedIndexChanged);
            // 
            // addDrugCombo
            // 
            this.addDrugCombo.FormattingEnabled = true;
            this.addDrugCombo.Location = new System.Drawing.Point(137, 90);
            this.addDrugCombo.Name = "addDrugCombo";
            this.addDrugCombo.Size = new System.Drawing.Size(277, 28);
            this.addDrugCombo.TabIndex = 11;
            this.addDrugCombo.SelectedIndexChanged += new System.EventHandler(this.addDrugCombo_SelectedIndexChanged);
            // 
            // supplierPriceListDataGridView
            // 
            this.supplierPriceListDataGridView.AllowUserToOrderColumns = true;
            this.supplierPriceListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierPriceListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.supplierPriceListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplierPriceListDataGridView.Location = new System.Drawing.Point(464, 38);
            this.supplierPriceListDataGridView.Name = "supplierPriceListDataGridView";
            this.supplierPriceListDataGridView.Size = new System.Drawing.Size(803, 286);
            this.supplierPriceListDataGridView.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Drug";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier";
            // 
            // pfsession
            // 
            this.pfsession.Location = new System.Drawing.Point(285, 6);
            this.pfsession.Name = "pfsession";
            this.pfsession.Size = new System.Drawing.Size(73, 20);
            this.pfsession.TabIndex = 8;
            this.pfsession.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.createNewSupplierPriceListButton);
            this.groupBox1.Controls.Add(this.saveSupplierPriceListButton);
            this.groupBox1.Controls.Add(this.PriceTextBox);
            this.groupBox1.Controls.Add(this.addSupplierCombo);
            this.groupBox1.Controls.Add(this.addDrugCombo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(23, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 286);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "supplier price list";
            // 
            // createNewSupplierPriceListButton
            // 
            this.createNewSupplierPriceListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createNewSupplierPriceListButton.Location = new System.Drawing.Point(194, 209);
            this.createNewSupplierPriceListButton.Name = "createNewSupplierPriceListButton";
            this.createNewSupplierPriceListButton.Size = new System.Drawing.Size(114, 44);
            this.createNewSupplierPriceListButton.TabIndex = 18;
            this.createNewSupplierPriceListButton.Text = "creat new";
            this.createNewSupplierPriceListButton.UseVisualStyleBackColor = true;
            this.createNewSupplierPriceListButton.Click += new System.EventHandler(this.createNewSupplierPriceListButton_Click);
            // 
            // AddSupplierPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 375);
            this.Controls.Add(this.drugidforeignkey);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.supplieridforeignkey);
            this.Controls.Add(this.supplierPriceListDataGridView);
            this.Controls.Add(this.pfsession);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddSupplierPriceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD SUPPLIER PRICE LIST";
            this.Load += new System.EventHandler(this.AddSupplierPriceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierPriceListDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.TextBox drugidforeignkey;
        private System.Windows.Forms.TextBox supplieridforeignkey;
        private System.Windows.Forms.Button saveSupplierPriceListButton;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.ComboBox addSupplierCombo;
        private System.Windows.Forms.ComboBox addDrugCombo;
        private System.Windows.Forms.DataGridView supplierPriceListDataGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pfsession;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button createNewSupplierPriceListButton;
    }
}