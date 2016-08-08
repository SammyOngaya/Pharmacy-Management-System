namespace PHARMACY
{
    partial class ReportPurchaseOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportPurchaseOrder));
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.searchByDate = new System.Windows.Forms.Button();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label32 = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dateBorrowedDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.searchDate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.drugNameTextBox = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.reportOrderDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.allSupplierToTalAmountLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.supplierTextBox = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.minDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button7 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportOrderDataGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(100, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(204, 40);
            this.button2.TabIndex = 27;
            this.button2.Text = "date and supplier";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.searchByDate);
            this.groupBox8.Controls.Add(this.endDateTimePicker);
            this.groupBox8.Controls.Add(this.label32);
            this.groupBox8.Controls.Add(this.startDateTimePicker);
            this.groupBox8.Controls.Add(this.label35);
            this.groupBox8.Location = new System.Drawing.Point(30, 29);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(795, 66);
            this.groupBox8.TabIndex = 87;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "search  by date between";
            // 
            // searchByDate
            // 
            this.searchByDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchByDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchByDate.Location = new System.Drawing.Point(670, 14);
            this.searchByDate.Name = "searchByDate";
            this.searchByDate.Size = new System.Drawing.Size(114, 40);
            this.searchByDate.TabIndex = 4;
            this.searchByDate.Text = "search";
            this.searchByDate.UseVisualStyleBackColor = true;
            this.searchByDate.Click += new System.EventHandler(this.searchByDate_Click);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateTimePicker.Location = new System.Drawing.Point(459, 25);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(154, 20);
            this.endDateTimePicker.TabIndex = 3;
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.endDateTimePicker_ValueChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(357, 24);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(72, 20);
            this.label32.TabIndex = 2;
            this.label32.Text = "end date";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateTimePicker.Location = new System.Drawing.Point(119, 26);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(154, 20);
            this.startDateTimePicker.TabIndex = 1;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(19, 26);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(77, 20);
            this.label35.TabIndex = 0;
            this.label35.Text = "start date";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dateBorrowedDateTimePicker);
            this.groupBox6.Controls.Add(this.searchDate);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Location = new System.Drawing.Point(30, 101);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(383, 66);
            this.groupBox6.TabIndex = 89;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "search by date";
            // 
            // dateBorrowedDateTimePicker
            // 
            this.dateBorrowedDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBorrowedDateTimePicker.Location = new System.Drawing.Point(67, 31);
            this.dateBorrowedDateTimePicker.Name = "dateBorrowedDateTimePicker";
            this.dateBorrowedDateTimePicker.Size = new System.Drawing.Size(206, 20);
            this.dateBorrowedDateTimePicker.TabIndex = 5;
            this.dateBorrowedDateTimePicker.ValueChanged += new System.EventHandler(this.dateBorrowedDateTimePicker_ValueChanged);
            // 
            // searchDate
            // 
            this.searchDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchDate.Location = new System.Drawing.Point(279, 20);
            this.searchDate.Name = "searchDate";
            this.searchDate.Size = new System.Drawing.Size(93, 40);
            this.searchDate.TabIndex = 4;
            this.searchDate.Text = "search";
            this.searchDate.UseVisualStyleBackColor = true;
            this.searchDate.Click += new System.EventHandler(this.searchDate_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "date";
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
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(361, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "date range and supplier";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.drugNameTextBox);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(30, 173);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 66);
            this.groupBox3.TabIndex = 92;
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
            // reportOrderDataGridView
            // 
            this.reportOrderDataGridView.AllowUserToOrderColumns = true;
            this.reportOrderDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportOrderDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.reportOrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportOrderDataGridView.Location = new System.Drawing.Point(30, 332);
            this.reportOrderDataGridView.Name = "reportOrderDataGridView";
            this.reportOrderDataGridView.Size = new System.Drawing.Size(1311, 412);
            this.reportOrderDataGridView.TabIndex = 85;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.rowCountLabel);
            this.groupBox4.Location = new System.Drawing.Point(838, 29);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(503, 66);
            this.groupBox4.TabIndex = 86;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "report";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(30, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 66);
            this.groupBox1.TabIndex = 91;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "combined search";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.allSupplierToTalAmountLabel);
            this.groupBox7.Location = new System.Drawing.Point(838, 101);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(503, 169);
            this.groupBox7.TabIndex = 90;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "summary";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "total amount";
            // 
            // allSupplierToTalAmountLabel
            // 
            this.allSupplierToTalAmountLabel.AutoSize = true;
            this.allSupplierToTalAmountLabel.Location = new System.Drawing.Point(142, 122);
            this.allSupplierToTalAmountLabel.Name = "allSupplierToTalAmountLabel";
            this.allSupplierToTalAmountLabel.Size = new System.Drawing.Size(0, 13);
            this.allSupplierToTalAmountLabel.TabIndex = 41;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.supplierTextBox);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(431, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 66);
            this.groupBox2.TabIndex = 93;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "search by supplier";
            // 
            // supplierTextBox
            // 
            this.supplierTextBox.Location = new System.Drawing.Point(100, 28);
            this.supplierTextBox.Name = "supplierTextBox";
            this.supplierTextBox.Size = new System.Drawing.Size(152, 20);
            this.supplierTextBox.TabIndex = 7;
            this.supplierTextBox.TextChanged += new System.EventHandler(this.supplierTextBox_TextChanged);
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(258, 20);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(114, 40);
            this.button6.TabIndex = 4;
            this.button6.Text = "search";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "supplier";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.minDateTimePicker);
            this.groupBox5.Controls.Add(this.button7);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(431, 173);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(383, 66);
            this.groupBox5.TabIndex = 94;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "search by date & minimum order";
            // 
            // minDateTimePicker
            // 
            this.minDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.minDateTimePicker.Location = new System.Drawing.Point(67, 31);
            this.minDateTimePicker.Name = "minDateTimePicker";
            this.minDateTimePicker.Size = new System.Drawing.Size(206, 20);
            this.minDateTimePicker.TabIndex = 5;
            this.minDateTimePicker.ValueChanged += new System.EventHandler(this.minDateTimePicker_ValueChanged);
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(279, 20);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(93, 40);
            this.button7.TabIndex = 4;
            this.button7.Text = "search";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "date";
            // 
            // button10
            // 
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(686, 19);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(87, 40);
            this.button10.TabIndex = 95;
            this.button10.Text = "load all";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // ReportPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.reportOrderDataGridView);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PURCHASE ORDER REPORT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportPurchaseOrder_Load);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportOrderDataGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button searchByDate;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DateTimePicker dateBorrowedDateTimePicker;
        private System.Windows.Forms.Button searchDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox drugNameTextBox;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView reportOrderDataGridView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox supplierTextBox;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker minDateTimePicker;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label allSupplierToTalAmountLabel;
        private System.Windows.Forms.Button button10;
    }
}