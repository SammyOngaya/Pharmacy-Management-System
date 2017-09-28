namespace PHARMACY
{
    partial class UpdateDrug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDrug));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.updateDrugId = new System.Windows.Forms.TextBox();
            this.updateDrugPrice = new System.Windows.Forms.TextBox();
            this.updateDrugForm = new System.Windows.Forms.ComboBox();
            this.updateDrugName = new System.Windows.Forms.TextBox();
            this.updateDrugButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.updateDrugdataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.searchDrugUpdate = new System.Windows.Forms.TextBox();
            this.updatedrugpfsession = new System.Windows.Forms.TextBox();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateDrugdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.updateDrugId);
            this.groupBox1.Controls.Add(this.updateDrugPrice);
            this.groupBox1.Controls.Add(this.updateDrugForm);
            this.groupBox1.Controls.Add(this.updateDrugName);
            this.groupBox1.Controls.Add(this.updateDrugButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(35, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 303);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Drug";
            // 
            // updateDrugId
            // 
            this.updateDrugId.Location = new System.Drawing.Point(171, 21);
            this.updateDrugId.Name = "updateDrugId";
            this.updateDrugId.Size = new System.Drawing.Size(191, 29);
            this.updateDrugId.TabIndex = 16;
            this.updateDrugId.Visible = false;
            // 
            // updateDrugPrice
            // 
            this.updateDrugPrice.Location = new System.Drawing.Point(153, 196);
            this.updateDrugPrice.Name = "updateDrugPrice";
            this.updateDrugPrice.Size = new System.Drawing.Size(250, 29);
            this.updateDrugPrice.TabIndex = 15;
            // 
            // updateDrugForm
            // 
            this.updateDrugForm.FormattingEnabled = true;
            this.updateDrugForm.Items.AddRange(new object[] {
            "Cream",
            "Capsules",
            "Gel",
            "Injection",
            "Ointment",
            "Powder",
            "Syrup",
            "Suspension",
            "Tablet"});
            this.updateDrugForm.Location = new System.Drawing.Point(153, 130);
            this.updateDrugForm.Name = "updateDrugForm";
            this.updateDrugForm.Size = new System.Drawing.Size(250, 32);
            this.updateDrugForm.TabIndex = 14;
            // 
            // updateDrugName
            // 
            this.updateDrugName.Location = new System.Drawing.Point(156, 56);
            this.updateDrugName.Name = "updateDrugName";
            this.updateDrugName.Size = new System.Drawing.Size(250, 29);
            this.updateDrugName.TabIndex = 13;
            // 
            // updateDrugButton
            // 
            this.updateDrugButton.Location = new System.Drawing.Point(147, 244);
            this.updateDrugButton.Name = "updateDrugButton";
            this.updateDrugButton.Size = new System.Drawing.Size(147, 35);
            this.updateDrugButton.TabIndex = 11;
            this.updateDrugButton.Text = "update";
            this.updateDrugButton.UseVisualStyleBackColor = true;
            this.updateDrugButton.Click += new System.EventHandler(this.updateDrugButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Price per Unit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Drug Form";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Drug Name";
            // 
            // updateDrugdataGridView
            // 
            this.updateDrugdataGridView.AllowUserToOrderColumns = true;
            this.updateDrugdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.updateDrugdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updateDrugdataGridView.Location = new System.Drawing.Point(485, 76);
            this.updateDrugdataGridView.Name = "updateDrugdataGridView";
            this.updateDrugdataGridView.Size = new System.Drawing.Size(597, 282);
            this.updateDrugdataGridView.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(520, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Search";
            // 
            // searchDrugUpdate
            // 
            this.searchDrugUpdate.Location = new System.Drawing.Point(617, 22);
            this.searchDrugUpdate.Name = "searchDrugUpdate";
            this.searchDrugUpdate.Size = new System.Drawing.Size(344, 20);
            this.searchDrugUpdate.TabIndex = 3;
            this.searchDrugUpdate.TextChanged += new System.EventHandler(this.searchDrugUpdate_TextChanged);
            // 
            // updatedrugpfsession
            // 
            this.updatedrugpfsession.Location = new System.Drawing.Point(393, 55);
            this.updatedrugpfsession.Name = "updatedrugpfsession";
            this.updatedrugpfsession.Size = new System.Drawing.Size(37, 20);
            this.updatedrugpfsession.TabIndex = 4;
            this.updatedrugpfsession.Visible = false;
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(329, 22);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 17;
            // 
            // UpdateDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 452);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.updatedrugpfsession);
            this.Controls.Add(this.searchDrugUpdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.updateDrugdataGridView);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateDrug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateDrug";
            this.Load += new System.EventHandler(this.UpdateDrug_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateDrugdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox updateDrugPrice;
        private System.Windows.Forms.ComboBox updateDrugForm;
        private System.Windows.Forms.TextBox updateDrugName;
        private System.Windows.Forms.Button updateDrugButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView updateDrugdataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox searchDrugUpdate;
        private System.Windows.Forms.TextBox updateDrugId;
        private System.Windows.Forms.TextBox updatedrugpfsession;
        private System.Windows.Forms.Label rowCountLabel;

    }
}