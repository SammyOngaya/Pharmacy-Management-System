﻿namespace PHARMACY
{
    partial class UpdateSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateSupplier));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.updateSupplierId = new System.Windows.Forms.TextBox();
            this.updateSupplierLocation = new System.Windows.Forms.TextBox();
            this.updateSupplierAdress = new System.Windows.Forms.TextBox();
            this.updateSupplierPhone = new System.Windows.Forms.TextBox();
            this.updateSupplierName = new System.Windows.Forms.TextBox();
            this.deleteSupplier = new System.Windows.Forms.Button();
            this.updateSupplierButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.updateSupplierDataGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.searchSupplier = new System.Windows.Forms.TextBox();
            this.updatepfsession = new System.Windows.Forms.TextBox();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateSupplierDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.updateSupplierId);
            this.groupBox1.Controls.Add(this.updateSupplierLocation);
            this.groupBox1.Controls.Add(this.updateSupplierAdress);
            this.groupBox1.Controls.Add(this.updateSupplierPhone);
            this.groupBox1.Controls.Add(this.updateSupplierName);
            this.groupBox1.Controls.Add(this.deleteSupplier);
            this.groupBox1.Controls.Add(this.updateSupplierButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(30, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 299);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Drug";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // updateSupplierId
            // 
            this.updateSupplierId.Location = new System.Drawing.Point(213, 17);
            this.updateSupplierId.Name = "updateSupplierId";
            this.updateSupplierId.Size = new System.Drawing.Size(100, 26);
            this.updateSupplierId.TabIndex = 10;
            this.updateSupplierId.Visible = false;
            // 
            // updateSupplierLocation
            // 
            this.updateSupplierLocation.Location = new System.Drawing.Point(121, 196);
            this.updateSupplierLocation.Name = "updateSupplierLocation";
            this.updateSupplierLocation.Size = new System.Drawing.Size(252, 26);
            this.updateSupplierLocation.TabIndex = 9;
            // 
            // updateSupplierAdress
            // 
            this.updateSupplierAdress.Location = new System.Drawing.Point(121, 140);
            this.updateSupplierAdress.Name = "updateSupplierAdress";
            this.updateSupplierAdress.Size = new System.Drawing.Size(252, 26);
            this.updateSupplierAdress.TabIndex = 8;
            // 
            // updateSupplierPhone
            // 
            this.updateSupplierPhone.Location = new System.Drawing.Point(121, 95);
            this.updateSupplierPhone.Name = "updateSupplierPhone";
            this.updateSupplierPhone.Size = new System.Drawing.Size(252, 26);
            this.updateSupplierPhone.TabIndex = 7;
            // 
            // updateSupplierName
            // 
            this.updateSupplierName.Location = new System.Drawing.Point(121, 43);
            this.updateSupplierName.Name = "updateSupplierName";
            this.updateSupplierName.Size = new System.Drawing.Size(252, 26);
            this.updateSupplierName.TabIndex = 6;
            // 
            // deleteSupplier
            // 
            this.deleteSupplier.Location = new System.Drawing.Point(257, 259);
            this.deleteSupplier.Name = "deleteSupplier";
            this.deleteSupplier.Size = new System.Drawing.Size(75, 23);
            this.deleteSupplier.TabIndex = 5;
            this.deleteSupplier.Text = "delete";
            this.deleteSupplier.UseVisualStyleBackColor = true;
            // 
            // updateSupplierButton
            // 
            this.updateSupplierButton.Location = new System.Drawing.Point(104, 259);
            this.updateSupplierButton.Name = "updateSupplierButton";
            this.updateSupplierButton.Size = new System.Drawing.Size(75, 23);
            this.updateSupplierButton.TabIndex = 4;
            this.updateSupplierButton.Text = "update";
            this.updateSupplierButton.UseVisualStyleBackColor = true;
            this.updateSupplierButton.Click += new System.EventHandler(this.updateSupplierButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Adress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // updateSupplierDataGridView
            // 
            this.updateSupplierDataGridView.AllowUserToOrderColumns = true;
            this.updateSupplierDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.updateSupplierDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updateSupplierDataGridView.Location = new System.Drawing.Point(477, 74);
            this.updateSupplierDataGridView.Name = "updateSupplierDataGridView";
            this.updateSupplierDataGridView.Size = new System.Drawing.Size(578, 239);
            this.updateSupplierDataGridView.TabIndex = 1;
            this.updateSupplierDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.updateSupplierDataGridView_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(489, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "search";
            // 
            // searchSupplier
            // 
            this.searchSupplier.Location = new System.Drawing.Point(624, 40);
            this.searchSupplier.Name = "searchSupplier";
            this.searchSupplier.Size = new System.Drawing.Size(301, 20);
            this.searchSupplier.TabIndex = 3;
            this.searchSupplier.TextChanged += new System.EventHandler(this.searchSupplier_TextChanged);
            // 
            // updatepfsession
            // 
            this.updatepfsession.Location = new System.Drawing.Point(413, 12);
            this.updatepfsession.Name = "updatepfsession";
            this.updatepfsession.Size = new System.Drawing.Size(80, 20);
            this.updatepfsession.TabIndex = 4;
            this.updatepfsession.Visible = false;
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(695, 336);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 11;
            // 
            // UpdateSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 401);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.updatepfsession);
            this.Controls.Add(this.searchSupplier);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.updateSupplierDataGridView);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateSupplier";
            this.Load += new System.EventHandler(this.UpdateSupplier_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateSupplierDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox updateSupplierLocation;
        private System.Windows.Forms.TextBox updateSupplierAdress;
        private System.Windows.Forms.TextBox updateSupplierPhone;
        private System.Windows.Forms.TextBox updateSupplierName;
        private System.Windows.Forms.Button deleteSupplier;
        private System.Windows.Forms.Button updateSupplierButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView updateSupplierDataGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox searchSupplier;
        private System.Windows.Forms.TextBox updateSupplierId;
        private System.Windows.Forms.TextBox updatepfsession;
        private System.Windows.Forms.Label rowCountLabel;
    }
}