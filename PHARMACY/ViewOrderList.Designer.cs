namespace PHARMACY
{
    partial class ViewOrderList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewOrderList));
            this.button8 = new System.Windows.Forms.Button();
            this.searchSupplierTextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.allSupplierToTalAmountLabel = new System.Windows.Forms.Label();
            this.otherSuppliersOrderListDataGridView = new System.Windows.Forms.DataGridView();
            this.AllSuppliersRowCountLabel = new System.Windows.Forms.Label();
            this.minimumSupplierRowCountLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pfsession = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.supplierPriceListDataGridView = new System.Windows.Forms.DataGridView();
            this.minimumTotalAmountLabel = new System.Windows.Forms.Label();
            this.supplieridforeignkey = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.drugidforeignkey = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.otherSuppliersOrderListDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplierPriceListDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.Location = new System.Drawing.Point(422, 13);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(102, 31);
            this.button8.TabIndex = 20;
            this.button8.Text = "view all";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // searchSupplierTextBox
            // 
            this.searchSupplierTextBox.Location = new System.Drawing.Point(71, 24);
            this.searchSupplierTextBox.Name = "searchSupplierTextBox";
            this.searchSupplierTextBox.Size = new System.Drawing.Size(217, 20);
            this.searchSupplierTextBox.TabIndex = 19;
            this.searchSupplierTextBox.TextChanged += new System.EventHandler(this.searchSupplierTextBox_TextChanged);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(300, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 31);
            this.button3.TabIndex = 18;
            this.button3.Text = "search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.searchSupplierTextBox);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(22, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(563, 50);
            this.groupBox4.TabIndex = 47;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "search by supplier";
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Location = new System.Drawing.Point(449, 29);
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
            this.otherSuppliersOrderListDataGridView.Size = new System.Drawing.Size(547, 435);
            this.otherSuppliersOrderListDataGridView.TabIndex = 28;
            // 
            // AllSuppliersRowCountLabel
            // 
            this.AllSuppliersRowCountLabel.AutoSize = true;
            this.AllSuppliersRowCountLabel.Location = new System.Drawing.Point(351, 43);
            this.AllSuppliersRowCountLabel.Name = "AllSuppliersRowCountLabel";
            this.AllSuppliersRowCountLabel.Size = new System.Drawing.Size(92, 20);
            this.AllSuppliersRowCountLabel.TabIndex = 42;
            this.AllSuppliersRowCountLabel.Text = "row count ";
            // 
            // minimumSupplierRowCountLabel
            // 
            this.minimumSupplierRowCountLabel.AutoSize = true;
            this.minimumSupplierRowCountLabel.Location = new System.Drawing.Point(403, 29);
            this.minimumSupplierRowCountLabel.Name = "minimumSupplierRowCountLabel";
            this.minimumSupplierRowCountLabel.Size = new System.Drawing.Size(87, 20);
            this.minimumSupplierRowCountLabel.TabIndex = 38;
            this.minimumSupplierRowCountLabel.Text = "row count";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(506, 18);
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
            // pfsession
            // 
            this.pfsession.Location = new System.Drawing.Point(302, 91);
            this.pfsession.Name = "pfsession";
            this.pfsession.Size = new System.Drawing.Size(82, 20);
            this.pfsession.TabIndex = 42;
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
            this.groupBox1.Location = new System.Drawing.Point(4, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 549);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "minimum list";
            // 
            // supplierPriceListDataGridView
            // 
            this.supplierPriceListDataGridView.AllowUserToOrderColumns = true;
            this.supplierPriceListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.supplierPriceListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplierPriceListDataGridView.Location = new System.Drawing.Point(10, 55);
            this.supplierPriceListDataGridView.Name = "supplierPriceListDataGridView";
            this.supplierPriceListDataGridView.Size = new System.Drawing.Size(606, 478);
            this.supplierPriceListDataGridView.TabIndex = 28;
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
            this.supplieridforeignkey.Location = new System.Drawing.Point(4, 91);
            this.supplieridforeignkey.Name = "supplieridforeignkey";
            this.supplieridforeignkey.Size = new System.Drawing.Size(100, 20);
            this.supplieridforeignkey.TabIndex = 43;
            this.supplieridforeignkey.Visible = false;
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
            this.groupBox3.Location = new System.Drawing.Point(645, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(563, 543);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "all suppliers";
            // 
            // drugidforeignkey
            // 
            this.drugidforeignkey.Location = new System.Drawing.Point(158, 91);
            this.drugidforeignkey.Name = "drugidforeignkey";
            this.drugidforeignkey.Size = new System.Drawing.Size(124, 20);
            this.drugidforeignkey.TabIndex = 44;
            this.drugidforeignkey.Visible = false;
            // 
            // ViewOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.pfsession);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.supplieridforeignkey);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.drugidforeignkey);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewOrderList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIEW ORDER LIST";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ViewOrderList_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.otherSuppliersOrderListDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplierPriceListDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox searchSupplierTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label allSupplierToTalAmountLabel;
        private System.Windows.Forms.DataGridView otherSuppliersOrderListDataGridView;
        private System.Windows.Forms.Label AllSuppliersRowCountLabel;
        private System.Windows.Forms.Label minimumSupplierRowCountLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pfsession;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView supplierPriceListDataGridView;
        private System.Windows.Forms.Label minimumTotalAmountLabel;
        private System.Windows.Forms.TextBox supplieridforeignkey;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox drugidforeignkey;
    }
}