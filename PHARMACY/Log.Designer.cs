namespace PHARMACY
{
    partial class Log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log));
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.distinctUsreLabel = new System.Windows.Forms.Label();
            this.distanceTravelledLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.staffIDTextBox = new System.Windows.Forms.TextBox();
            this.searchByDriverID = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.loggedInUserTextBox = new System.Windows.Forms.TextBox();
            this.searchByDate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.logDataGridView = new System.Windows.Forms.DataGridView();
            this.searchDate = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logDataGridView)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
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
            this.button4.Text = "PDF";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(26, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 66);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "combined search";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(146, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(193, 40);
            this.button2.TabIndex = 27;
            this.button2.Text = "date and staff";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(219, 170);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 20);
            this.textBox1.TabIndex = 26;
            this.textBox1.Visible = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(459, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "date range and staff";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.distinctUsreLabel);
            this.groupBox7.Controls.Add(this.distanceTravelledLabel);
            this.groupBox7.Controls.Add(this.amountLabel);
            this.groupBox7.Location = new System.Drawing.Point(847, 90);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(497, 169);
            this.groupBox7.TabIndex = 70;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "summary";
            // 
            // distinctUsreLabel
            // 
            this.distinctUsreLabel.AutoSize = true;
            this.distinctUsreLabel.Location = new System.Drawing.Point(27, 31);
            this.distinctUsreLabel.Name = "distinctUsreLabel";
            this.distinctUsreLabel.Size = new System.Drawing.Size(0, 13);
            this.distinctUsreLabel.TabIndex = 2;
            // 
            // distanceTravelledLabel
            // 
            this.distanceTravelledLabel.AutoSize = true;
            this.distanceTravelledLabel.Location = new System.Drawing.Point(18, 66);
            this.distanceTravelledLabel.Name = "distanceTravelledLabel";
            this.distanceTravelledLabel.Size = new System.Drawing.Size(0, 13);
            this.distanceTravelledLabel.TabIndex = 1;
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(19, 30);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(0, 13);
            this.amountLabel.TabIndex = 0;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.staffIDTextBox);
            this.groupBox2.Controls.Add(this.searchByDriverID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(438, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 66);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "search  by staff";
            // 
            // staffIDTextBox
            // 
            this.staffIDTextBox.Location = new System.Drawing.Point(119, 28);
            this.staffIDTextBox.Name = "staffIDTextBox";
            this.staffIDTextBox.Size = new System.Drawing.Size(113, 20);
            this.staffIDTextBox.TabIndex = 6;
            this.staffIDTextBox.TextChanged += new System.EventHandler(this.staffIDTextBox_TextChanged);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "staff ID";
            // 
            // loggedInUserTextBox
            // 
            this.loggedInUserTextBox.Location = new System.Drawing.Point(347, -8);
            this.loggedInUserTextBox.Name = "loggedInUserTextBox";
            this.loggedInUserTextBox.Size = new System.Drawing.Size(184, 20);
            this.loggedInUserTextBox.TabIndex = 26;
            this.loggedInUserTextBox.Visible = false;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "date";
            // 
            // logDataGridView
            // 
            this.logDataGridView.AllowUserToOrderColumns = true;
            this.logDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.logDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logDataGridView.Location = new System.Drawing.Point(26, 292);
            this.logDataGridView.Name = "logDataGridView";
            this.logDataGridView.Size = new System.Drawing.Size(1288, 392);
            this.logDataGridView.TabIndex = 65;
            // 
            // searchDate
            // 
            this.searchDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchDate.Location = new System.Drawing.Point(258, 20);
            this.searchDate.Name = "searchDate";
            this.searchDate.Size = new System.Drawing.Size(114, 40);
            this.searchDate.TabIndex = 4;
            this.searchDate.Text = "search";
            this.searchDate.UseVisualStyleBackColor = true;
            this.searchDate.Click += new System.EventHandler(this.searchDate_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dateDateTimePicker);
            this.groupBox6.Controls.Add(this.searchDate);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Location = new System.Drawing.Point(26, 104);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(383, 66);
            this.groupBox6.TabIndex = 69;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "date";
            // 
            // dateDateTimePicker
            // 
            this.dateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDateTimePicker.Location = new System.Drawing.Point(78, 29);
            this.dateDateTimePicker.Name = "dateDateTimePicker";
            this.dateDateTimePicker.Size = new System.Drawing.Size(154, 20);
            this.dateDateTimePicker.TabIndex = 5;
            this.dateDateTimePicker.ValueChanged += new System.EventHandler(this.dateDateTimePicker_ValueChanged);
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
            this.button3.Text = "EXCEL";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.searchByDate);
            this.groupBox8.Controls.Add(this.endDateTimePicker);
            this.groupBox8.Controls.Add(this.label32);
            this.groupBox8.Controls.Add(this.startDateTimePicker);
            this.groupBox8.Controls.Add(this.label35);
            this.groupBox8.Location = new System.Drawing.Point(26, 18);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(795, 66);
            this.groupBox8.TabIndex = 67;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "search  by date";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.rowCountLabel);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Location = new System.Drawing.Point(840, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(503, 66);
            this.groupBox4.TabIndex = 66;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "report";
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 702);
            this.Controls.Add(this.loggedInUserTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.logDataGridView);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Log";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SYSTEM LOG REPORT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Log_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logDataGridView)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label distinctUsreLabel;
        private System.Windows.Forms.Label distanceTravelledLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox staffIDTextBox;
        private System.Windows.Forms.Button searchByDriverID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox loggedInUserTextBox;
        private System.Windows.Forms.Button searchByDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView logDataGridView;
        private System.Windows.Forms.Button searchDate;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DateTimePicker dateDateTimePicker;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}