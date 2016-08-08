namespace PHARMACY
{
    partial class DebtorPayDebt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebtorPayDebt));
            this.searchByDriverID = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.updatePhone = new System.Windows.Forms.TextBox();
            this.totalAmountOwedLabel = new System.Windows.Forms.Label();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.RemainingAmountLabel = new System.Windows.Forms.Label();
            this.depositTXTlabel = new System.Windows.Forms.Label();
            this.remainingAmount = new System.Windows.Forms.Label();
            this.depositAmount = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.debtroReportDataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.searchDebtorIDTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.DebtStatusLabel = new System.Windows.Forms.Label();
            this.userAmountTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pfSessionTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DrugNameLabel = new System.Windows.Forms.Label();
            this.drugQuantityLabel = new System.Windows.Forms.Label();
            this.phoneLable = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.updateDebtorPriceTextBox = new System.Windows.Forms.TextBox();
            this.updateQuantity = new System.Windows.Forms.TextBox();
            this.stockIDTextBox = new System.Windows.Forms.TextBox();
            this.updateDebtorPrimaryKey = new System.Windows.Forms.TextBox();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debtroReportDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
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
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.updatePhone);
            this.groupBox7.Controls.Add(this.totalAmountOwedLabel);
            this.groupBox7.Controls.Add(this.balanceLabel);
            this.groupBox7.Controls.Add(this.RemainingAmountLabel);
            this.groupBox7.Controls.Add(this.depositTXTlabel);
            this.groupBox7.Controls.Add(this.remainingAmount);
            this.groupBox7.Controls.Add(this.depositAmount);
            this.groupBox7.Controls.Add(this.amountLabel);
            this.groupBox7.Location = new System.Drawing.Point(838, 83);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(503, 241);
            this.groupBox7.TabIndex = 95;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "summary";
            // 
            // updatePhone
            // 
            this.updatePhone.Location = new System.Drawing.Point(871, 72);
            this.updatePhone.MaxLength = 30;
            this.updatePhone.Name = "updatePhone";
            this.updatePhone.Size = new System.Drawing.Size(281, 20);
            this.updatePhone.TabIndex = 25;
            // 
            // totalAmountOwedLabel
            // 
            this.totalAmountOwedLabel.AutoSize = true;
            this.totalAmountOwedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAmountOwedLabel.Location = new System.Drawing.Point(17, 220);
            this.totalAmountOwedLabel.Name = "totalAmountOwedLabel";
            this.totalAmountOwedLabel.Size = new System.Drawing.Size(137, 20);
            this.totalAmountOwedLabel.TabIndex = 11;
            this.totalAmountOwedLabel.Text = "totalAmountOwed";
            this.totalAmountOwedLabel.Visible = false;
            // 
            // balanceLabel
            // 
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balanceLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.balanceLabel.Location = new System.Drawing.Point(17, 164);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(14, 20);
            this.balanceLabel.TabIndex = 10;
            this.balanceLabel.Text = ".";
            // 
            // RemainingAmountLabel
            // 
            this.RemainingAmountLabel.AutoSize = true;
            this.RemainingAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemainingAmountLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.RemainingAmountLabel.Location = new System.Drawing.Point(17, 131);
            this.RemainingAmountLabel.Name = "RemainingAmountLabel";
            this.RemainingAmountLabel.Size = new System.Drawing.Size(14, 20);
            this.RemainingAmountLabel.TabIndex = 9;
            this.RemainingAmountLabel.Text = ".";
            // 
            // depositTXTlabel
            // 
            this.depositTXTlabel.AutoSize = true;
            this.depositTXTlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depositTXTlabel.Location = new System.Drawing.Point(17, 200);
            this.depositTXTlabel.Name = "depositTXTlabel";
            this.depositTXTlabel.Size = new System.Drawing.Size(82, 20);
            this.depositTXTlabel.TabIndex = 3;
            this.depositTXTlabel.Text = "depositTxt";
            this.depositTXTlabel.Visible = false;
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
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(18, 20);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(10, 13);
            this.amountLabel.TabIndex = 0;
            this.amountLabel.Text = ".";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(100, 28);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(132, 20);
            this.phoneTextBox.TabIndex = 6;
            this.phoneTextBox.TextChanged += new System.EventHandler(this.phoneTextBox_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.rowCountLabel);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Location = new System.Drawing.Point(30, 258);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(795, 66);
            this.groupBox4.TabIndex = 93;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "report";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(670, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 40);
            this.button2.TabIndex = 11;
            this.button2.Text = "Load all";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowCountLabel.Location = new System.Drawing.Point(295, 27);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 20);
            this.rowCountLabel.TabIndex = 10;
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
            // debtroReportDataGridView
            // 
            this.debtroReportDataGridView.AllowUserToOrderColumns = true;
            this.debtroReportDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.debtroReportDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.debtroReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.debtroReportDataGridView.Location = new System.Drawing.Point(30, 337);
            this.debtroReportDataGridView.Name = "debtroReportDataGridView";
            this.debtroReportDataGridView.Size = new System.Drawing.Size(1311, 396);
            this.debtroReportDataGridView.TabIndex = 92;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.phoneTextBox);
            this.groupBox2.Controls.Add(this.searchByDriverID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(30, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 66);
            this.groupBox2.TabIndex = 94;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "search  by debtor phone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Debt ID";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.searchDebtorIDTextBox);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(442, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 66);
            this.groupBox3.TabIndex = 96;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "search by debt id";
            // 
            // searchDebtorIDTextBox
            // 
            this.searchDebtorIDTextBox.Location = new System.Drawing.Point(77, 28);
            this.searchDebtorIDTextBox.Name = "searchDebtorIDTextBox";
            this.searchDebtorIDTextBox.Size = new System.Drawing.Size(152, 20);
            this.searchDebtorIDTextBox.TabIndex = 8;
            this.searchDebtorIDTextBox.TextChanged += new System.EventHandler(this.searchDebtorIDTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.DebtStatusLabel);
            this.groupBox1.Controls.Add(this.userAmountTextBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(30, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 66);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PAY";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(658, 20);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(114, 40);
            this.button6.TabIndex = 11;
            this.button6.Text = "REVERSE";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // DebtStatusLabel
            // 
            this.DebtStatusLabel.AutoSize = true;
            this.DebtStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebtStatusLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.DebtStatusLabel.Location = new System.Drawing.Point(375, 32);
            this.DebtStatusLabel.Name = "DebtStatusLabel";
            this.DebtStatusLabel.Size = new System.Drawing.Size(14, 20);
            this.DebtStatusLabel.TabIndex = 10;
            this.DebtStatusLabel.Text = ".";
            // 
            // userAmountTextBox
            // 
            this.userAmountTextBox.Location = new System.Drawing.Point(127, 32);
            this.userAmountTextBox.Name = "userAmountTextBox";
            this.userAmountTextBox.Size = new System.Drawing.Size(198, 20);
            this.userAmountTextBox.TabIndex = 8;
            this.userAmountTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(527, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "UPDATE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "AMOUNT";
            // 
            // pfSessionTextBox
            // 
            this.pfSessionTextBox.Location = new System.Drawing.Point(30, 240);
            this.pfSessionTextBox.Name = "pfSessionTextBox";
            this.pfSessionTextBox.Size = new System.Drawing.Size(152, 20);
            this.pfSessionTextBox.TabIndex = 98;
            this.pfSessionTextBox.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.DrugNameLabel);
            this.groupBox5.Controls.Add(this.drugQuantityLabel);
            this.groupBox5.Controls.Add(this.phoneLable);
            this.groupBox5.Controls.Add(this.NameLabel);
            this.groupBox5.Location = new System.Drawing.Point(30, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1311, 66);
            this.groupBox5.TabIndex = 99;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Debtor Name";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // DrugNameLabel
            // 
            this.DrugNameLabel.AutoSize = true;
            this.DrugNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrugNameLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.DrugNameLabel.Location = new System.Drawing.Point(642, 32);
            this.DrugNameLabel.Name = "DrugNameLabel";
            this.DrugNameLabel.Size = new System.Drawing.Size(94, 20);
            this.DrugNameLabel.TabIndex = 14;
            this.DrugNameLabel.Text = "drug name";
            // 
            // drugQuantityLabel
            // 
            this.drugQuantityLabel.AutoSize = true;
            this.drugQuantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drugQuantityLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.drugQuantityLabel.Location = new System.Drawing.Point(1033, 32);
            this.drugQuantityLabel.Name = "drugQuantityLabel";
            this.drugQuantityLabel.Size = new System.Drawing.Size(114, 20);
            this.drugQuantityLabel.TabIndex = 13;
            this.drugQuantityLabel.Text = "drug quantity";
            // 
            // phoneLable
            // 
            this.phoneLable.AutoSize = true;
            this.phoneLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLable.ForeColor = System.Drawing.Color.LimeGreen;
            this.phoneLable.Location = new System.Drawing.Point(424, 32);
            this.phoneLable.Name = "phoneLable";
            this.phoneLable.Size = new System.Drawing.Size(59, 20);
            this.phoneLable.TabIndex = 12;
            this.phoneLable.Text = "phone";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.NameLabel.Location = new System.Drawing.Point(19, 32);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(53, 20);
            this.NameLabel.TabIndex = 11;
            this.NameLabel.Text = "name";
            // 
            // updateDebtorPriceTextBox
            // 
            this.updateDebtorPriceTextBox.Location = new System.Drawing.Point(566, 240);
            this.updateDebtorPriceTextBox.MaxLength = 20;
            this.updateDebtorPriceTextBox.Name = "updateDebtorPriceTextBox";
            this.updateDebtorPriceTextBox.Size = new System.Drawing.Size(163, 20);
            this.updateDebtorPriceTextBox.TabIndex = 26;
            this.updateDebtorPriceTextBox.Visible = false;
            // 
            // updateQuantity
            // 
            this.updateQuantity.Location = new System.Drawing.Point(373, 240);
            this.updateQuantity.MaxLength = 20;
            this.updateQuantity.Name = "updateQuantity";
            this.updateQuantity.Size = new System.Drawing.Size(163, 20);
            this.updateQuantity.TabIndex = 24;
            this.updateQuantity.Visible = false;
            // 
            // stockIDTextBox
            // 
            this.stockIDTextBox.Location = new System.Drawing.Point(546, 149);
            this.stockIDTextBox.Name = "stockIDTextBox";
            this.stockIDTextBox.Size = new System.Drawing.Size(150, 20);
            this.stockIDTextBox.TabIndex = 27;
            this.stockIDTextBox.Visible = false;
            // 
            // updateDebtorPrimaryKey
            // 
            this.updateDebtorPrimaryKey.Location = new System.Drawing.Point(373, 155);
            this.updateDebtorPrimaryKey.Name = "updateDebtorPrimaryKey";
            this.updateDebtorPrimaryKey.Size = new System.Drawing.Size(137, 20);
            this.updateDebtorPrimaryKey.TabIndex = 18;
            this.updateDebtorPrimaryKey.Visible = false;
            // 
            // DebtorPayDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.updateDebtorPrimaryKey);
            this.Controls.Add(this.stockIDTextBox);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.updateDebtorPriceTextBox);
            this.Controls.Add(this.pfSessionTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.updateQuantity);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.debtroReportDataGridView);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DebtorPayDebt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DEBTORS DEBT PAYMENT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DebtorPayDebt_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debtroReportDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchByDriverID;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label remainingAmount;
        private System.Windows.Forms.Label depositAmount;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView debtroReportDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox searchDebtorIDTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox userAmountTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RemainingAmountLabel;
        private System.Windows.Forms.Label depositTXTlabel;
        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.Label totalAmountOwedLabel;
        private System.Windows.Forms.Label DebtStatusLabel;
        private System.Windows.Forms.TextBox pfSessionTextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label drugQuantityLabel;
        private System.Windows.Forms.Label phoneLable;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox updateDebtorPriceTextBox;
        private System.Windows.Forms.TextBox updatePhone;
        private System.Windows.Forms.TextBox updateQuantity;
        private System.Windows.Forms.TextBox stockIDTextBox;
        private System.Windows.Forms.TextBox updateDebtorPrimaryKey;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label DrugNameLabel;
    }
}