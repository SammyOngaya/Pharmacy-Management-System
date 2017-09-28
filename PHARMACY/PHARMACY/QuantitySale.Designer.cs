namespace PHARMACY
{
    partial class QuantitySale
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuantitySale));
            this.cashSalePay = new System.Windows.Forms.Button();
            this.unitforeignkey = new System.Windows.Forms.TextBox();
            this.priceforeignkey = new System.Windows.Forms.TextBox();
            this.drugidforeignkey = new System.Windows.Forms.TextBox();
            this.cashSaleBalance = new System.Windows.Forms.TextBox();
            this.cashSaleCancel = new System.Windows.Forms.Button();
            this.cashSaleTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.quantitysaleAmount = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.cashSaleDiscount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.QuantitySalePictureBox = new System.Windows.Forms.PictureBox();
            this.pfsession = new System.Windows.Forms.TextBox();
            this.cashSaleDrugSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cashSaleRemove = new System.Windows.Forms.Button();
            this.pricePerUnit = new System.Windows.Forms.TextBox();
            this.quantityOfDrugs = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cashSaleAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cashSale = new System.Windows.Forms.Button();
            this.saleDashboardDataGridView = new System.Windows.Forms.DataGridView();
            this.netStockDrugQuantityTextbox = new System.Windows.Forms.TextBox();
            this.drugnameforeignkey = new System.Windows.Forms.TextBox();
            this.setSerial = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuantitySalePictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saleDashboardDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cashSalePay
            // 
            this.cashSalePay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cashSalePay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashSalePay.ForeColor = System.Drawing.Color.Black;
            this.cashSalePay.Location = new System.Drawing.Point(861, 13);
            this.cashSalePay.Name = "cashSalePay";
            this.cashSalePay.Size = new System.Drawing.Size(71, 37);
            this.cashSalePay.TabIndex = 34;
            this.cashSalePay.Text = "Pay";
            this.cashSalePay.UseVisualStyleBackColor = false;
            this.cashSalePay.Click += new System.EventHandler(this.cashSalePay_Click_1);
            // 
            // unitforeignkey
            // 
            this.unitforeignkey.Location = new System.Drawing.Point(496, 66);
            this.unitforeignkey.Name = "unitforeignkey";
            this.unitforeignkey.Size = new System.Drawing.Size(89, 20);
            this.unitforeignkey.TabIndex = 33;
            this.unitforeignkey.Visible = false;
            // 
            // priceforeignkey
            // 
            this.priceforeignkey.Location = new System.Drawing.Point(386, 66);
            this.priceforeignkey.Name = "priceforeignkey";
            this.priceforeignkey.Size = new System.Drawing.Size(93, 20);
            this.priceforeignkey.TabIndex = 32;
            this.priceforeignkey.Visible = false;
            // 
            // drugidforeignkey
            // 
            this.drugidforeignkey.Location = new System.Drawing.Point(269, 66);
            this.drugidforeignkey.Name = "drugidforeignkey";
            this.drugidforeignkey.Size = new System.Drawing.Size(88, 20);
            this.drugidforeignkey.TabIndex = 31;
            this.drugidforeignkey.Visible = false;
            this.drugidforeignkey.TextChanged += new System.EventHandler(this.drugidforeignkey_TextChanged_1);
            // 
            // cashSaleBalance
            // 
            this.cashSaleBalance.Enabled = false;
            this.cashSaleBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashSaleBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cashSaleBalance.Location = new System.Drawing.Point(727, 17);
            this.cashSaleBalance.Name = "cashSaleBalance";
            this.cashSaleBalance.Size = new System.Drawing.Size(128, 29);
            this.cashSaleBalance.TabIndex = 24;
            // 
            // cashSaleCancel
            // 
            this.cashSaleCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cashSaleCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashSaleCancel.Location = new System.Drawing.Point(1022, 14);
            this.cashSaleCancel.Name = "cashSaleCancel";
            this.cashSaleCancel.Size = new System.Drawing.Size(81, 36);
            this.cashSaleCancel.TabIndex = 30;
            this.cashSaleCancel.Text = "cancel";
            this.cashSaleCancel.UseVisualStyleBackColor = false;
            this.cashSaleCancel.Click += new System.EventHandler(this.cashSaleCancel_Click);
            // 
            // cashSaleTotal
            // 
            this.cashSaleTotal.Enabled = false;
            this.cashSaleTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashSaleTotal.ForeColor = System.Drawing.Color.Blue;
            this.cashSaleTotal.Location = new System.Drawing.Point(74, 22);
            this.cashSaleTotal.Name = "cashSaleTotal";
            this.cashSaleTotal.Size = new System.Drawing.Size(109, 29);
            this.cashSaleTotal.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "Total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(304, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 24);
            this.label7.TabIndex = 2;
            this.label7.Text = "Amount";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(938, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 36);
            this.button1.TabIndex = 29;
            this.button1.Text = "sale";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(636, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 24);
            this.label3.TabIndex = 20;
            this.label3.Text = "Balance";
            // 
            // quantitysaleAmount
            // 
            this.quantitysaleAmount.Location = new System.Drawing.Point(388, 39);
            this.quantitysaleAmount.Name = "quantitysaleAmount";
            this.quantitysaleAmount.Size = new System.Drawing.Size(124, 26);
            this.quantitysaleAmount.TabIndex = 3;
            this.quantitysaleAmount.TextChanged += new System.EventHandler(this.quantitysaleAmount_TextChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(681, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 30);
            this.button3.TabIndex = 4;
            this.button3.Text = "Enter";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // cashSaleDiscount
            // 
            this.cashSaleDiscount.Location = new System.Drawing.Point(523, 26);
            this.cashSaleDiscount.Name = "cashSaleDiscount";
            this.cashSaleDiscount.Size = new System.Drawing.Size(102, 20);
            this.cashSaleDiscount.TabIndex = 27;
            this.cashSaleDiscount.TextChanged += new System.EventHandler(this.cashSaleDiscount_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(12, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "Qty";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.welcomeLabel);
            this.groupBox2.Controls.Add(this.QuantitySalePictureBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Gray;
            this.groupBox2.Location = new System.Drawing.Point(958, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 224);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "manager";
            // 
            // QuantitySalePictureBox
            // 
            this.QuantitySalePictureBox.Location = new System.Drawing.Point(16, 47);
            this.QuantitySalePictureBox.Name = "QuantitySalePictureBox";
            this.QuantitySalePictureBox.Size = new System.Drawing.Size(227, 167);
            this.QuantitySalePictureBox.TabIndex = 4;
            this.QuantitySalePictureBox.TabStop = false;
            // 
            // pfsession
            // 
            this.pfsession.Location = new System.Drawing.Point(1127, 18);
            this.pfsession.Name = "pfsession";
            this.pfsession.Size = new System.Drawing.Size(74, 20);
            this.pfsession.TabIndex = 2;
            this.pfsession.Visible = false;
            // 
            // cashSaleDrugSearch
            // 
            this.cashSaleDrugSearch.Location = new System.Drawing.Point(64, 38);
            this.cashSaleDrugSearch.Name = "cashSaleDrugSearch";
            this.cashSaleDrugSearch.Size = new System.Drawing.Size(234, 26);
            this.cashSaleDrugSearch.TabIndex = 1;
            this.cashSaleDrugSearch.TextChanged += new System.EventHandler(this.cashSaleDrugSearch_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drug";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cashSaleRemove);
            this.groupBox1.Controls.Add(this.pricePerUnit);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.quantitysaleAmount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cashSaleDrugSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(16, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 77);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cash sale";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(518, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 24);
            this.label9.TabIndex = 39;
            this.label9.Text = "Price";
            // 
            // cashSaleRemove
            // 
            this.cashSaleRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cashSaleRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashSaleRemove.ForeColor = System.Drawing.Color.Black;
            this.cashSaleRemove.Location = new System.Drawing.Point(804, 37);
            this.cashSaleRemove.Name = "cashSaleRemove";
            this.cashSaleRemove.Size = new System.Drawing.Size(87, 30);
            this.cashSaleRemove.TabIndex = 7;
            this.cashSaleRemove.Text = "Remove";
            this.cashSaleRemove.UseVisualStyleBackColor = false;
            this.cashSaleRemove.Click += new System.EventHandler(this.cashSaleRemove_Click_1);
            // 
            // pricePerUnit
            // 
            this.pricePerUnit.Location = new System.Drawing.Point(579, 39);
            this.pricePerUnit.Name = "pricePerUnit";
            this.pricePerUnit.Size = new System.Drawing.Size(96, 26);
            this.pricePerUnit.TabIndex = 38;
            // 
            // quantityOfDrugs
            // 
            this.quantityOfDrugs.Location = new System.Drawing.Point(67, 63);
            this.quantityOfDrugs.Name = "quantityOfDrugs";
            this.quantityOfDrugs.Size = new System.Drawing.Size(106, 20);
            this.quantityOfDrugs.TabIndex = 36;
            // 
            // cashSaleAmount
            // 
            this.cashSaleAmount.Location = new System.Drawing.Point(279, 25);
            this.cashSaleAmount.Name = "cashSaleAmount";
            this.cashSaleAmount.Size = new System.Drawing.Size(121, 20);
            this.cashSaleAmount.TabIndex = 25;
            this.cashSaleAmount.TextChanged += new System.EventHandler(this.cashSaleAmount_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(426, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 24);
            this.label5.TabIndex = 26;
            this.label5.Text = "Discount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(191, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 23;
            this.label4.Text = "Amount";
            // 
            // cashSale
            // 
            this.cashSale.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cashSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cashSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashSale.Location = new System.Drawing.Point(1022, 322);
            this.cashSale.Name = "cashSale";
            this.cashSale.Size = new System.Drawing.Size(129, 71);
            this.cashSale.TabIndex = 35;
            this.cashSale.Text = "Cash Sale";
            this.cashSale.UseVisualStyleBackColor = false;
            this.cashSale.Click += new System.EventHandler(this.cashSale_Click);
            // 
            // saleDashboardDataGridView
            // 
            this.saleDashboardDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleDashboardDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.saleDashboardDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.saleDashboardDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.saleDashboardDataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.saleDashboardDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.saleDashboardDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.saleDashboardDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.saleDashboardDataGridView.Location = new System.Drawing.Point(23, 166);
            this.saleDashboardDataGridView.Name = "saleDashboardDataGridView";
            this.saleDashboardDataGridView.Size = new System.Drawing.Size(895, 227);
            this.saleDashboardDataGridView.TabIndex = 21;
            // 
            // netStockDrugQuantityTextbox
            // 
            this.netStockDrugQuantityTextbox.Location = new System.Drawing.Point(603, 69);
            this.netStockDrugQuantityTextbox.Name = "netStockDrugQuantityTextbox";
            this.netStockDrugQuantityTextbox.Size = new System.Drawing.Size(159, 20);
            this.netStockDrugQuantityTextbox.TabIndex = 37;
            this.netStockDrugQuantityTextbox.Visible = false;
            // 
            // drugnameforeignkey
            // 
            this.drugnameforeignkey.Location = new System.Drawing.Point(787, 65);
            this.drugnameforeignkey.Name = "drugnameforeignkey";
            this.drugnameforeignkey.Size = new System.Drawing.Size(151, 20);
            this.drugnameforeignkey.TabIndex = 38;
            this.drugnameforeignkey.Visible = false;
            // 
            // setSerial
            // 
            this.setSerial.Location = new System.Drawing.Point(958, 65);
            this.setSerial.Name = "setSerial";
            this.setSerial.Size = new System.Drawing.Size(108, 20);
            this.setSerial.TabIndex = 39;
            this.setSerial.Visible = false;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Enabled = false;
            this.lastNameTextBox.Location = new System.Drawing.Point(641, 91);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(214, 20);
            this.lastNameTextBox.TabIndex = 41;
            this.lastNameTextBox.Visible = false;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Enabled = false;
            this.firstNameTextBox.Location = new System.Drawing.Point(330, 91);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(214, 20);
            this.firstNameTextBox.TabIndex = 40;
            this.firstNameTextBox.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(13, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 16);
            this.label11.TabIndex = 12;
            this.label11.Text = "welcome  ";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.Black;
            this.welcomeLabel.Location = new System.Drawing.Point(84, 22);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(68, 16);
            this.welcomeLabel.TabIndex = 11;
            this.welcomeLabel.Text = "welcome  ";
            // 
            // QuantitySale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 446);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.setSerial);
            this.Controls.Add(this.pfsession);
            this.Controls.Add(this.drugnameforeignkey);
            this.Controls.Add(this.netStockDrugQuantityTextbox);
            this.Controls.Add(this.quantityOfDrugs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cashSale);
            this.Controls.Add(this.cashSalePay);
            this.Controls.Add(this.unitforeignkey);
            this.Controls.Add(this.priceforeignkey);
            this.Controls.Add(this.drugidforeignkey);
            this.Controls.Add(this.cashSaleBalance);
            this.Controls.Add(this.cashSaleCancel);
            this.Controls.Add(this.cashSaleTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cashSaleDiscount);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.saleDashboardDataGridView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cashSaleAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuantitySale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CASH SALE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QuantitySale_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuantitySalePictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saleDashboardDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cashSalePay;
        private System.Windows.Forms.TextBox unitforeignkey;
        private System.Windows.Forms.TextBox priceforeignkey;
        private System.Windows.Forms.TextBox drugidforeignkey;
        private System.Windows.Forms.TextBox cashSaleBalance;
        private System.Windows.Forms.Button cashSaleCancel;
        private System.Windows.Forms.TextBox cashSaleTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox quantitysaleAmount;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox cashSaleDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox pfsession;
        private System.Windows.Forms.TextBox cashSaleDrugSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cashSaleRemove;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox cashSaleAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cashSale;
        private System.Windows.Forms.TextBox quantityOfDrugs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox pricePerUnit;
        private System.Windows.Forms.DataGridView saleDashboardDataGridView;
        private System.Windows.Forms.PictureBox QuantitySalePictureBox;
        private System.Windows.Forms.TextBox netStockDrugQuantityTextbox;
        private System.Windows.Forms.TextBox drugnameforeignkey;
        private System.Windows.Forms.TextBox setSerial;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label welcomeLabel;
    }
}