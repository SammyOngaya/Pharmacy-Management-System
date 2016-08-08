namespace PHARMACY
{
    partial class OrderList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderList));
            this.drugidforeignkey = new System.Windows.Forms.TextBox();
            this.minimumTotalAmountLabel = new System.Windows.Forms.Label();
            this.supplieridforeignkey = new System.Windows.Forms.TextBox();
            this.supplierPriceListDataGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.pfsession = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.minimumSupplierRowCountLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchSupplierPriceListButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.quantityText = new System.Windows.Forms.Label();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.searchDrugTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AllSuppliersRowCountLabel = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.allSupplierToTalAmountLabel = new System.Windows.Forms.Label();
            this.otherSuppliersOrderListDataGridView = new System.Windows.Forms.DataGridView();
            this.minPriceTextBox = new System.Windows.Forms.TextBox();
            this.minimuListDataGridView = new System.Windows.Forms.DataGridView();
            this.otherSuppliersPriceListDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.searchSupplierTextBox = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.supplierPriceListDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.otherSuppliersOrderListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimuListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherSuppliersPriceListDataGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // drugidforeignkey
            // 
            this.drugidforeignkey.Location = new System.Drawing.Point(166, 88);
            this.drugidforeignkey.Name = "drugidforeignkey";
            this.drugidforeignkey.Size = new System.Drawing.Size(124, 20);
            this.drugidforeignkey.TabIndex = 32;
            this.drugidforeignkey.Visible = false;
            // 
            // minimumTotalAmountLabel
            // 
            this.minimumTotalAmountLabel.AutoSize = true;
            this.minimumTotalAmountLabel.Location = new System.Drawing.Point(150, 32);
            this.minimumTotalAmountLabel.Name = "minimumTotalAmountLabel";
            this.minimumTotalAmountLabel.Size = new System.Drawing.Size(0, 20);
            this.minimumTotalAmountLabel.TabIndex = 30;
            // 
            // supplieridforeignkey
            // 
            this.supplieridforeignkey.Location = new System.Drawing.Point(12, 88);
            this.supplieridforeignkey.Name = "supplieridforeignkey";
            this.supplieridforeignkey.Size = new System.Drawing.Size(100, 20);
            this.supplieridforeignkey.TabIndex = 31;
            this.supplieridforeignkey.Visible = false;
            // 
            // supplierPriceListDataGridView
            // 
            this.supplierPriceListDataGridView.AllowUserToOrderColumns = true;
            this.supplierPriceListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.supplierPriceListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplierPriceListDataGridView.Location = new System.Drawing.Point(0, 58);
            this.supplierPriceListDataGridView.Name = "supplierPriceListDataGridView";
            this.supplierPriceListDataGridView.Size = new System.Drawing.Size(572, 439);
            this.supplierPriceListDataGridView.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Drug name";
            // 
            // pfsession
            // 
            this.pfsession.Location = new System.Drawing.Point(310, 88);
            this.pfsession.Name = "pfsession";
            this.pfsession.Size = new System.Drawing.Size(82, 20);
            this.pfsession.TabIndex = 29;
            this.pfsession.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.minimumSupplierRowCountLabel);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.supplierPriceListDataGridView);
            this.groupBox1.Controls.Add(this.minimumTotalAmountLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 527);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "minimum list";
            // 
            // minimumSupplierRowCountLabel
            // 
            this.minimumSupplierRowCountLabel.AutoSize = true;
            this.minimumSupplierRowCountLabel.Location = new System.Drawing.Point(382, 29);
            this.minimumSupplierRowCountLabel.Name = "minimumSupplierRowCountLabel";
            this.minimumSupplierRowCountLabel.Size = new System.Drawing.Size(87, 20);
            this.minimumSupplierRowCountLabel.TabIndex = 38;
            this.minimumSupplierRowCountLabel.Text = "row count";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(472, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 34);
            this.button2.TabIndex = 37;
            this.button2.Text = "print";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "total amount";
            // 
            // searchSupplierPriceListButton
            // 
            this.searchSupplierPriceListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchSupplierPriceListButton.Location = new System.Drawing.Point(470, 13);
            this.searchSupplierPriceListButton.Name = "searchSupplierPriceListButton";
            this.searchSupplierPriceListButton.Size = new System.Drawing.Size(81, 31);
            this.searchSupplierPriceListButton.TabIndex = 18;
            this.searchSupplierPriceListButton.Text = "add";
            this.searchSupplierPriceListButton.UseVisualStyleBackColor = true;
            this.searchSupplierPriceListButton.Click += new System.EventHandler(this.searchSupplierPriceListButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.quantityText);
            this.groupBox2.Controls.Add(this.quantityTextBox);
            this.groupBox2.Controls.Add(this.searchDrugTextBox);
            this.groupBox2.Controls.Add(this.searchSupplierPriceListButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(586, 50);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "add drug to list";
            // 
            // quantityText
            // 
            this.quantityText.AutoSize = true;
            this.quantityText.Location = new System.Drawing.Point(290, 22);
            this.quantityText.Name = "quantityText";
            this.quantityText.Size = new System.Drawing.Size(44, 13);
            this.quantityText.TabIndex = 30;
            this.quantityText.Text = "quantity";
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(340, 20);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(124, 20);
            this.quantityTextBox.TabIndex = 20;
            // 
            // searchDrugTextBox
            // 
            this.searchDrugTextBox.Location = new System.Drawing.Point(70, 19);
            this.searchDrugTextBox.Name = "searchDrugTextBox";
            this.searchDrugTextBox.Size = new System.Drawing.Size(198, 20);
            this.searchDrugTextBox.TabIndex = 19;
            this.searchDrugTextBox.TextChanged += new System.EventHandler(this.searchDrugTextBox_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AllSuppliersRowCountLabel);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.allSupplierToTalAmountLabel);
            this.groupBox3.Controls.Add(this.otherSuppliersOrderListDataGridView);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox3.Location = new System.Drawing.Point(620, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(575, 515);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "all suppliers";
            // 
            // AllSuppliersRowCountLabel
            // 
            this.AllSuppliersRowCountLabel.AutoSize = true;
            this.AllSuppliersRowCountLabel.Location = new System.Drawing.Point(365, 36);
            this.AllSuppliersRowCountLabel.Name = "AllSuppliersRowCountLabel";
            this.AllSuppliersRowCountLabel.Size = new System.Drawing.Size(92, 20);
            this.AllSuppliersRowCountLabel.TabIndex = 42;
            this.AllSuppliersRowCountLabel.Text = "row count ";
            this.AllSuppliersRowCountLabel.Click += new System.EventHandler(this.AllSuppliersRowCountLabel_Click);
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Location = new System.Drawing.Point(463, 29);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 34);
            this.button6.TabIndex = 41;
            this.button6.Text = "print";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "total amount";
            // 
            // allSupplierToTalAmountLabel
            // 
            this.allSupplierToTalAmountLabel.AutoSize = true;
            this.allSupplierToTalAmountLabel.Location = new System.Drawing.Point(150, 46);
            this.allSupplierToTalAmountLabel.Name = "allSupplierToTalAmountLabel";
            this.allSupplierToTalAmountLabel.Size = new System.Drawing.Size(0, 20);
            this.allSupplierToTalAmountLabel.TabIndex = 39;
            // 
            // otherSuppliersOrderListDataGridView
            // 
            this.otherSuppliersOrderListDataGridView.AllowUserToOrderColumns = true;
            this.otherSuppliersOrderListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.otherSuppliersOrderListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.otherSuppliersOrderListDataGridView.Location = new System.Drawing.Point(10, 92);
            this.otherSuppliersOrderListDataGridView.Name = "otherSuppliersOrderListDataGridView";
            this.otherSuppliersOrderListDataGridView.Size = new System.Drawing.Size(553, 403);
            this.otherSuppliersOrderListDataGridView.TabIndex = 28;
            // 
            // minPriceTextBox
            // 
            this.minPriceTextBox.Location = new System.Drawing.Point(407, 92);
            this.minPriceTextBox.Name = "minPriceTextBox";
            this.minPriceTextBox.Size = new System.Drawing.Size(177, 20);
            this.minPriceTextBox.TabIndex = 37;
            this.minPriceTextBox.Visible = false;
            this.minPriceTextBox.TextChanged += new System.EventHandler(this.minPriceTextBox_TextChanged);
            // 
            // minimuListDataGridView
            // 
            this.minimuListDataGridView.AllowUserToOrderColumns = true;
            this.minimuListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.minimuListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.minimuListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.minimuListDataGridView.Location = new System.Drawing.Point(22, 710);
            this.minimuListDataGridView.Name = "minimuListDataGridView";
            this.minimuListDataGridView.Size = new System.Drawing.Size(646, 28);
            this.minimuListDataGridView.TabIndex = 38;
            this.minimuListDataGridView.Visible = false;
            // 
            // otherSuppliersPriceListDataGridView
            // 
            this.otherSuppliersPriceListDataGridView.AllowUserToOrderColumns = true;
            this.otherSuppliersPriceListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.otherSuppliersPriceListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.otherSuppliersPriceListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.otherSuppliersPriceListDataGridView.Location = new System.Drawing.Point(711, 710);
            this.otherSuppliersPriceListDataGridView.Name = "otherSuppliersPriceListDataGridView";
            this.otherSuppliersPriceListDataGridView.Size = new System.Drawing.Size(646, 28);
            this.otherSuppliersPriceListDataGridView.TabIndex = 39;
            this.otherSuppliersPriceListDataGridView.Visible = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(529, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 33);
            this.button1.TabIndex = 40;
            this.button1.Text = "new list";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(656, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(135, 32);
            this.button4.TabIndex = 41;
            this.button4.Text = "search order list";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Supplier";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(306, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 31);
            this.button3.TabIndex = 18;
            this.button3.Text = "search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // searchSupplierTextBox
            // 
            this.searchSupplierTextBox.Location = new System.Drawing.Point(66, 20);
            this.searchSupplierTextBox.Name = "searchSupplierTextBox";
            this.searchSupplierTextBox.Size = new System.Drawing.Size(217, 20);
            this.searchSupplierTextBox.TabIndex = 19;
            this.searchSupplierTextBox.TextChanged += new System.EventHandler(this.searchSupplierTextBox_TextChanged);
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.Location = new System.Drawing.Point(446, 14);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(102, 31);
            this.button8.TabIndex = 20;
            this.button8.Text = "view all";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.searchSupplierTextBox);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(620, 45);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(575, 50);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "search by supplier";
            this.groupBox4.Visible = false;
            // 
            // OrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.otherSuppliersPriceListDataGridView);
            this.Controls.Add(this.minimuListDataGridView);
            this.Controls.Add(this.minPriceTextBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.drugidforeignkey);
            this.Controls.Add(this.supplieridforeignkey);
            this.Controls.Add(this.pfsession);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ORDER LIST";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OrderList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierPriceListDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.otherSuppliersOrderListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimuListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherSuppliersPriceListDataGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox drugidforeignkey;
        private System.Windows.Forms.Label minimumTotalAmountLabel;
        private System.Windows.Forms.TextBox supplieridforeignkey;
        private System.Windows.Forms.DataGridView supplierPriceListDataGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pfsession;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchSupplierPriceListButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox searchDrugTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView otherSuppliersOrderListDataGridView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label quantityText;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.TextBox minPriceTextBox;
        private System.Windows.Forms.DataGridView minimuListDataGridView;
        private System.Windows.Forms.DataGridView otherSuppliersPriceListDataGridView;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label allSupplierToTalAmountLabel;
        private System.Windows.Forms.Label minimumSupplierRowCountLabel;
        private System.Windows.Forms.Label AllSuppliersRowCountLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox searchSupplierTextBox;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}