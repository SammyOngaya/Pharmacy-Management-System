namespace PHARMACY
{
    partial class AddSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSupplier));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.supplierStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addSupplierLocation = new System.Windows.Forms.TextBox();
            this.addSupplierAdress = new System.Windows.Forms.TextBox();
            this.addSupplierPhone = new System.Windows.Forms.TextBox();
            this.addSupplierCompanyName = new System.Windows.Forms.TextBox();
            this.clearSupplier = new System.Windows.Forms.Button();
            this.saveSupplier = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addSupplierdataGridView = new System.Windows.Forms.DataGridView();
            this.addSupplierSessionPf = new System.Windows.Forms.TextBox();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addSupplierdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.supplierStatusComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.addSupplierLocation);
            this.groupBox1.Controls.Add(this.addSupplierAdress);
            this.groupBox1.Controls.Add(this.addSupplierPhone);
            this.groupBox1.Controls.Add(this.addSupplierCompanyName);
            this.groupBox1.Controls.Add(this.clearSupplier);
            this.groupBox1.Controls.Add(this.saveSupplier);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(18, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 338);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supplier Details";
            // 
            // supplierStatusComboBox
            // 
            this.supplierStatusComboBox.FormattingEnabled = true;
            this.supplierStatusComboBox.Items.AddRange(new object[] {
            "Active",
            "Disabled"});
            this.supplierStatusComboBox.Location = new System.Drawing.Point(153, 239);
            this.supplierStatusComboBox.Name = "supplierStatusComboBox";
            this.supplierStatusComboBox.Size = new System.Drawing.Size(217, 28);
            this.supplierStatusComboBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Status";
            // 
            // addSupplierLocation
            // 
            this.addSupplierLocation.Location = new System.Drawing.Point(156, 188);
            this.addSupplierLocation.MaxLength = 150;
            this.addSupplierLocation.Name = "addSupplierLocation";
            this.addSupplierLocation.Size = new System.Drawing.Size(215, 26);
            this.addSupplierLocation.TabIndex = 9;
            // 
            // addSupplierAdress
            // 
            this.addSupplierAdress.Location = new System.Drawing.Point(156, 142);
            this.addSupplierAdress.MaxLength = 100;
            this.addSupplierAdress.Name = "addSupplierAdress";
            this.addSupplierAdress.Size = new System.Drawing.Size(215, 26);
            this.addSupplierAdress.TabIndex = 8;
            // 
            // addSupplierPhone
            // 
            this.addSupplierPhone.Location = new System.Drawing.Point(156, 93);
            this.addSupplierPhone.MaxLength = 30;
            this.addSupplierPhone.Name = "addSupplierPhone";
            this.addSupplierPhone.Size = new System.Drawing.Size(215, 26);
            this.addSupplierPhone.TabIndex = 7;
            // 
            // addSupplierCompanyName
            // 
            this.addSupplierCompanyName.Location = new System.Drawing.Point(156, 44);
            this.addSupplierCompanyName.MaxLength = 150;
            this.addSupplierCompanyName.Name = "addSupplierCompanyName";
            this.addSupplierCompanyName.Size = new System.Drawing.Size(215, 26);
            this.addSupplierCompanyName.TabIndex = 6;
            // 
            // clearSupplier
            // 
            this.clearSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearSupplier.Location = new System.Drawing.Point(228, 285);
            this.clearSupplier.Name = "clearSupplier";
            this.clearSupplier.Size = new System.Drawing.Size(75, 33);
            this.clearSupplier.TabIndex = 5;
            this.clearSupplier.Text = "clear";
            this.clearSupplier.UseVisualStyleBackColor = true;
            this.clearSupplier.Click += new System.EventHandler(this.clearSupplier_Click);
            // 
            // saveSupplier
            // 
            this.saveSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveSupplier.Location = new System.Drawing.Point(91, 286);
            this.saveSupplier.Name = "saveSupplier";
            this.saveSupplier.Size = new System.Drawing.Size(75, 32);
            this.saveSupplier.TabIndex = 4;
            this.saveSupplier.Text = "save";
            this.saveSupplier.UseVisualStyleBackColor = true;
            this.saveSupplier.Click += new System.EventHandler(this.saveSupplier_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Adress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name";
            // 
            // addSupplierdataGridView
            // 
            this.addSupplierdataGridView.AllowUserToOrderColumns = true;
            this.addSupplierdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.addSupplierdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addSupplierdataGridView.Location = new System.Drawing.Point(430, 78);
            this.addSupplierdataGridView.Name = "addSupplierdataGridView";
            this.addSupplierdataGridView.Size = new System.Drawing.Size(639, 325);
            this.addSupplierdataGridView.TabIndex = 4;
            // 
            // addSupplierSessionPf
            // 
            this.addSupplierSessionPf.Location = new System.Drawing.Point(472, 53);
            this.addSupplierSessionPf.Name = "addSupplierSessionPf";
            this.addSupplierSessionPf.Size = new System.Drawing.Size(153, 20);
            this.addSupplierSessionPf.TabIndex = 5;
            this.addSupplierSessionPf.Visible = false;
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(755, 56);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 6;
            // 
            // AddSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 429);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addSupplierdataGridView);
            this.Controls.Add(this.addSupplierSessionPf);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTER SUPPLIER";
            this.Load += new System.EventHandler(this.AddSupplier_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addSupplierdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox addSupplierLocation;
        private System.Windows.Forms.TextBox addSupplierAdress;
        private System.Windows.Forms.TextBox addSupplierPhone;
        private System.Windows.Forms.TextBox addSupplierCompanyName;
        private System.Windows.Forms.Button clearSupplier;
        private System.Windows.Forms.Button saveSupplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView addSupplierdataGridView;
        private System.Windows.Forms.TextBox addSupplierSessionPf;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox supplierStatusComboBox;
    }
}