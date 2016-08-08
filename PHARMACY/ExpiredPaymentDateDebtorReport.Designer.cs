namespace PHARMACY
{
    partial class ExpiredPaymentDateDebtorReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpiredPaymentDateDebtorReport));
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.remainingAmount = new System.Windows.Forms.Label();
            this.depositAmount = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.drugNameTextBox = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.debtroReportDataGridView = new System.Windows.Forms.DataGridView();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.searchByDriverID = new System.Windows.Forms.Button();
            this.pfSessionTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debtroReportDataGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(6, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 38);
            this.button3.TabIndex = 8;
            this.button3.Text = "pdf";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(140, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 38);
            this.button4.TabIndex = 9;
            this.button4.Text = "excel";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "phone";
            // 
            // remainingAmount
            // 
            this.remainingAmount.AutoSize = true;
            this.remainingAmount.Location = new System.Drawing.Point(18, 107);
            this.remainingAmount.Name = "remainingAmount";
            this.remainingAmount.Size = new System.Drawing.Size(10, 13);
            this.remainingAmount.TabIndex = 2;
            this.remainingAmount.Text = ".";
            // 
            // depositAmount
            // 
            this.depositAmount.AutoSize = true;
            this.depositAmount.Location = new System.Drawing.Point(18, 66);
            this.depositAmount.Name = "depositAmount";
            this.depositAmount.Size = new System.Drawing.Size(10, 13);
            this.depositAmount.TabIndex = 1;
            this.depositAmount.Text = ".";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.drugNameTextBox);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(30, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 66);
            this.groupBox3.TabIndex = 91;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "search by drug name";
            // 
            // drugNameTextBox
            // 
            this.drugNameTextBox.Location = new System.Drawing.Point(100, 28);
            this.drugNameTextBox.Name = "drugNameTextBox";
            this.drugNameTextBox.Size = new System.Drawing.Size(152, 20);
            this.drugNameTextBox.TabIndex = 7;
            this.drugNameTextBox.TextChanged += new System.EventHandler(this.drugNameTextBox_TextChanged);
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(258, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(114, 40);
            this.button5.TabIndex = 4;
            this.button5.Text = "search";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "drug name";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(18, 20);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(10, 13);
            this.amountLabel.TabIndex = 0;
            this.amountLabel.Text = ".";
            // 
            // debtroReportDataGridView
            // 
            this.debtroReportDataGridView.AllowUserToOrderColumns = true;
            this.debtroReportDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.debtroReportDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.debtroReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.debtroReportDataGridView.Location = new System.Drawing.Point(30, 220);
            this.debtroReportDataGridView.Name = "debtroReportDataGridView";
            this.debtroReportDataGridView.Size = new System.Drawing.Size(1311, 513);
            this.debtroReportDataGridView.TabIndex = 84;
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowCountLabel.Location = new System.Drawing.Point(295, 27);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 20);
            this.rowCountLabel.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.button11);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.rowCountLabel);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Location = new System.Drawing.Point(30, 121);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(795, 66);
            this.groupBox4.TabIndex = 85;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "report";
            // 
            // button11
            // 
            this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button11.Location = new System.Drawing.Point(696, 25);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(82, 35);
            this.button11.TabIndex = 92;
            this.button11.Text = "pay";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(100, 28);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(132, 20);
            this.phoneTextBox.TabIndex = 6;
            this.phoneTextBox.TextChanged += new System.EventHandler(this.phoneTextBox_TextChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.remainingAmount);
            this.groupBox7.Controls.Add(this.depositAmount);
            this.groupBox7.Controls.Add(this.amountLabel);
            this.groupBox7.Location = new System.Drawing.Point(838, 18);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(503, 169);
            this.groupBox7.TabIndex = 89;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "summary";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.phoneTextBox);
            this.groupBox2.Controls.Add(this.searchByDriverID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(436, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 66);
            this.groupBox2.TabIndex = 87;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "search  by debtor phone";
            // 
            // searchByDriverID
            // 
            this.searchByDriverID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchByDriverID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchByDriverID.Location = new System.Drawing.Point(258, 20);
            this.searchByDriverID.Name = "searchByDriverID";
            this.searchByDriverID.Size = new System.Drawing.Size(114, 40);
            this.searchByDriverID.TabIndex = 4;
            this.searchByDriverID.Text = "search";
            this.searchByDriverID.UseVisualStyleBackColor = true;
            this.searchByDriverID.Click += new System.EventHandler(this.searchByDriverID_Click);
            // 
            // pfSessionTextBox
            // 
            this.pfSessionTextBox.Location = new System.Drawing.Point(603, 3);
            this.pfSessionTextBox.Name = "pfSessionTextBox";
            this.pfSessionTextBox.Size = new System.Drawing.Size(152, 20);
            this.pfSessionTextBox.TabIndex = 100;
            this.pfSessionTextBox.Visible = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(573, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 40);
            this.button1.TabIndex = 98;
            this.button1.Text = "load all";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExpiredPaymentDateDebtorReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.pfSessionTextBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.debtroReportDataGridView);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExpiredPaymentDateDebtorReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EXCEEDED PAYMENT DATE DEBTOR REPORT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ExpiredPaymentDateDebtorReport_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debtroReportDataGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label remainingAmount;
        private System.Windows.Forms.Label depositAmount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox drugNameTextBox;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.DataGridView debtroReportDataGridView;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button searchByDriverID;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox pfSessionTextBox;
        private System.Windows.Forms.Button button1;
    }
}