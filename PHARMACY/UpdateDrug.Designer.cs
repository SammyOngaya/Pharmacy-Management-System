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
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.updateDrugId = new System.Windows.Forms.TextBox();
            this.updateDrugForm = new System.Windows.Forms.ComboBox();
            this.updateDrugName = new System.Windows.Forms.TextBox();
            this.updateDrugButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.updateDrugdataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.searchDrugUpdate = new System.Windows.Forms.TextBox();
            this.updatedrugpfsession = new System.Windows.Forms.TextBox();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateDrugdataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statusComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.updateDrugId);
            this.groupBox1.Controls.Add(this.updateDrugForm);
            this.groupBox1.Controls.Add(this.updateDrugName);
            this.groupBox1.Controls.Add(this.updateDrugButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(26, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 456);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Drug";
            // 
            // statusComboBox
            // 
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "Active",
            "Disable"});
            this.statusComboBox.Location = new System.Drawing.Point(217, 226);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(250, 32);
            this.statusComboBox.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "status";
            // 
            // updateDrugId
            // 
            this.updateDrugId.Location = new System.Drawing.Point(247, 20);
            this.updateDrugId.Name = "updateDrugId";
            this.updateDrugId.Size = new System.Drawing.Size(191, 29);
            this.updateDrugId.TabIndex = 16;
            this.updateDrugId.Visible = false;
            // 
            // updateDrugForm
            // 
            this.updateDrugForm.FormattingEnabled = true;
            this.updateDrugForm.Location = new System.Drawing.Point(229, 129);
            this.updateDrugForm.Name = "updateDrugForm";
            this.updateDrugForm.Size = new System.Drawing.Size(250, 32);
            this.updateDrugForm.TabIndex = 14;
            // 
            // updateDrugName
            // 
            this.updateDrugName.Location = new System.Drawing.Point(229, 55);
            this.updateDrugName.MaxLength = 150;
            this.updateDrugName.Name = "updateDrugName";
            this.updateDrugName.Size = new System.Drawing.Size(250, 29);
            this.updateDrugName.TabIndex = 13;
            // 
            // updateDrugButton
            // 
            this.updateDrugButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateDrugButton.Location = new System.Drawing.Point(179, 281);
            this.updateDrugButton.Name = "updateDrugButton";
            this.updateDrugButton.Size = new System.Drawing.Size(147, 47);
            this.updateDrugButton.TabIndex = 11;
            this.updateDrugButton.Text = "update";
            this.updateDrugButton.UseVisualStyleBackColor = true;
            this.updateDrugButton.Click += new System.EventHandler(this.updateDrugButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Drug Form";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Drug Name";
            // 
            // updateDrugdataGridView
            // 
            this.updateDrugdataGridView.AllowUserToOrderColumns = true;
            this.updateDrugdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.updateDrugdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updateDrugdataGridView.Location = new System.Drawing.Point(579, 86);
            this.updateDrugdataGridView.Name = "updateDrugdataGridView";
            this.updateDrugdataGridView.Size = new System.Drawing.Size(597, 447);
            this.updateDrugdataGridView.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(41, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "drug name";
            // 
            // searchDrugUpdate
            // 
            this.searchDrugUpdate.Location = new System.Drawing.Point(195, 29);
            this.searchDrugUpdate.Name = "searchDrugUpdate";
            this.searchDrugUpdate.Size = new System.Drawing.Size(344, 20);
            this.searchDrugUpdate.TabIndex = 3;
            this.searchDrugUpdate.TextChanged += new System.EventHandler(this.searchDrugUpdate_TextChanged);
            // 
            // updatedrugpfsession
            // 
            this.updatedrugpfsession.Location = new System.Drawing.Point(294, 55);
            this.updatedrugpfsession.Name = "updatedrugpfsession";
            this.updatedrugpfsession.Size = new System.Drawing.Size(183, 20);
            this.updatedrugpfsession.TabIndex = 4;
            this.updatedrugpfsession.Visible = false;
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(291, 7);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rowCountLabel);
            this.groupBox2.Controls.Add(this.searchDrugUpdate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(579, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(597, 68);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "search by drug name";
            // 
            // UpdateDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 556);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.updatedrugpfsession);
            this.Controls.Add(this.updateDrugdataGridView);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateDrug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UPDATE DRUG";
            this.Load += new System.EventHandler(this.UpdateDrug_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateDrugdataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox updateDrugForm;
        private System.Windows.Forms.TextBox updateDrugName;
        private System.Windows.Forms.Button updateDrugButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView updateDrugdataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox searchDrugUpdate;
        private System.Windows.Forms.TextBox updateDrugId;
        private System.Windows.Forms.TextBox updatedrugpfsession;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label label5;

    }
}