namespace PHARMACY
{
    partial class AddStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStaff));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.staffStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.genderComboBox = new System.Windows.Forms.ComboBox();
            this.default_pfno = new System.Windows.Forms.Label();
            this.addstaffpfno = new System.Windows.Forms.TextBox();
            this.addstaffPassword = new System.Windows.Forms.TextBox();
            this.addstaffDob = new System.Windows.Forms.DateTimePicker();
            this.addstafflastname = new System.Windows.Forms.TextBox();
            this.addstafffirstname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addstaffCategory = new System.Windows.Forms.ComboBox();
            this.addstaffLocation = new System.Windows.Forms.TextBox();
            this.addstaffCounty = new System.Windows.Forms.TextBox();
            this.addstaffEmail = new System.Windows.Forms.TextBox();
            this.addstaffPhone = new System.Windows.Forms.TextBox();
            this.addstaffNationalid = new System.Windows.Forms.TextBox();
            this.addstaffDoe = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.addstaffdataGridView = new System.Windows.Forms.DataGridView();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.imagePathTextBox = new System.Windows.Forms.TextBox();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.loadImagePictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addstaffdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.staffStatusComboBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.genderComboBox);
            this.groupBox1.Controls.Add(this.default_pfno);
            this.groupBox1.Controls.Add(this.addstaffpfno);
            this.groupBox1.Controls.Add(this.addstaffPassword);
            this.groupBox1.Controls.Add(this.addstaffDob);
            this.groupBox1.Controls.Add(this.addstafflastname);
            this.groupBox1.Controls.Add(this.addstafffirstname);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 288);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Data";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // staffStatusComboBox
            // 
            this.staffStatusComboBox.FormattingEnabled = true;
            this.staffStatusComboBox.Items.AddRange(new object[] {
            "Active",
            "Disabled"});
            this.staffStatusComboBox.Location = new System.Drawing.Point(126, 247);
            this.staffStatusComboBox.Name = "staffStatusComboBox";
            this.staffStatusComboBox.Size = new System.Drawing.Size(234, 28);
            this.staffStatusComboBox.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 250);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 20);
            this.label14.TabIndex = 17;
            this.label14.Text = "Status";
            // 
            // genderComboBox
            // 
            this.genderComboBox.FormattingEnabled = true;
            this.genderComboBox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.genderComboBox.Location = new System.Drawing.Point(131, 177);
            this.genderComboBox.Name = "genderComboBox";
            this.genderComboBox.Size = new System.Drawing.Size(231, 28);
            this.genderComboBox.TabIndex = 16;
            // 
            // default_pfno
            // 
            this.default_pfno.AutoSize = true;
            this.default_pfno.Location = new System.Drawing.Point(233, 4);
            this.default_pfno.Name = "default_pfno";
            this.default_pfno.Size = new System.Drawing.Size(111, 20);
            this.default_pfno.TabIndex = 14;
            this.default_pfno.Text = "default_pfno";
            this.default_pfno.Visible = false;
            // 
            // addstaffpfno
            // 
            this.addstaffpfno.Location = new System.Drawing.Point(131, 25);
            this.addstaffpfno.MaxLength = 50;
            this.addstaffpfno.Name = "addstaffpfno";
            this.addstaffpfno.Size = new System.Drawing.Size(236, 26);
            this.addstaffpfno.TabIndex = 13;
            this.addstaffpfno.TextChanged += new System.EventHandler(this.addstaffpfno_TextChanged);
            // 
            // addstaffPassword
            // 
            this.addstaffPassword.Location = new System.Drawing.Point(126, 211);
            this.addstaffPassword.MaxLength = 100;
            this.addstaffPassword.Name = "addstaffPassword";
            this.addstaffPassword.Size = new System.Drawing.Size(236, 26);
            this.addstaffPassword.TabIndex = 10;
            this.addstaffPassword.TextChanged += new System.EventHandler(this.addstaffPassword_TextChanged);
            // 
            // addstaffDob
            // 
            this.addstaffDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.addstaffDob.Location = new System.Drawing.Point(126, 145);
            this.addstaffDob.Name = "addstaffDob";
            this.addstaffDob.Size = new System.Drawing.Size(234, 26);
            this.addstaffDob.TabIndex = 9;
            // 
            // addstafflastname
            // 
            this.addstafflastname.Location = new System.Drawing.Point(126, 102);
            this.addstafflastname.MaxLength = 100;
            this.addstafflastname.Name = "addstafflastname";
            this.addstafflastname.Size = new System.Drawing.Size(236, 26);
            this.addstafflastname.TabIndex = 7;
            // 
            // addstafffirstname
            // 
            this.addstafffirstname.Location = new System.Drawing.Point(131, 65);
            this.addstafffirstname.MaxLength = 100;
            this.addstafffirstname.Name = "addstafffirstname";
            this.addstafffirstname.Size = new System.Drawing.Size(235, 26);
            this.addstafffirstname.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gender";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 212);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "DoB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "PFNO";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addstaffCategory);
            this.groupBox2.Controls.Add(this.addstaffLocation);
            this.groupBox2.Controls.Add(this.addstaffCounty);
            this.groupBox2.Controls.Add(this.addstaffEmail);
            this.groupBox2.Controls.Add(this.addstaffPhone);
            this.groupBox2.Controls.Add(this.addstaffNationalid);
            this.groupBox2.Controls.Add(this.addstaffDoe);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(465, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 279);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Physical Details";
            // 
            // addstaffCategory
            // 
            this.addstaffCategory.FormattingEnabled = true;
            this.addstaffCategory.Items.AddRange(new object[] {
            "Manager",
            "Supervisor",
            "Pharmacist"});
            this.addstaffCategory.Location = new System.Drawing.Point(138, 235);
            this.addstaffCategory.Name = "addstaffCategory";
            this.addstaffCategory.Size = new System.Drawing.Size(211, 28);
            this.addstaffCategory.TabIndex = 14;
            // 
            // addstaffLocation
            // 
            this.addstaffLocation.Location = new System.Drawing.Point(138, 157);
            this.addstaffLocation.MaxLength = 100;
            this.addstaffLocation.Name = "addstaffLocation";
            this.addstaffLocation.Size = new System.Drawing.Size(200, 26);
            this.addstaffLocation.TabIndex = 13;
            // 
            // addstaffCounty
            // 
            this.addstaffCounty.Location = new System.Drawing.Point(138, 122);
            this.addstaffCounty.MaxLength = 100;
            this.addstaffCounty.Name = "addstaffCounty";
            this.addstaffCounty.Size = new System.Drawing.Size(200, 26);
            this.addstaffCounty.TabIndex = 12;
            // 
            // addstaffEmail
            // 
            this.addstaffEmail.Location = new System.Drawing.Point(138, 92);
            this.addstaffEmail.MaxLength = 150;
            this.addstaffEmail.Name = "addstaffEmail";
            this.addstaffEmail.Size = new System.Drawing.Size(200, 26);
            this.addstaffEmail.TabIndex = 11;
            // 
            // addstaffPhone
            // 
            this.addstaffPhone.Location = new System.Drawing.Point(138, 62);
            this.addstaffPhone.MaxLength = 30;
            this.addstaffPhone.Name = "addstaffPhone";
            this.addstaffPhone.Size = new System.Drawing.Size(200, 26);
            this.addstaffPhone.TabIndex = 10;
            // 
            // addstaffNationalid
            // 
            this.addstaffNationalid.Location = new System.Drawing.Point(138, 29);
            this.addstaffNationalid.MaxLength = 20;
            this.addstaffNationalid.Name = "addstaffNationalid";
            this.addstaffNationalid.Size = new System.Drawing.Size(200, 26);
            this.addstaffNationalid.TabIndex = 9;
            this.addstaffNationalid.TextChanged += new System.EventHandler(this.addstaffNationalid_TextChanged);
            // 
            // addstaffDoe
            // 
            this.addstaffDoe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.addstaffDoe.Location = new System.Drawing.Point(138, 193);
            this.addstaffDoe.Name = "addstaffDoe";
            this.addstaffDoe.Size = new System.Drawing.Size(200, 26);
            this.addstaffDoe.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 238);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "Category";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "DoE";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "Location";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "County";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Phone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "National ID";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(280, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Tomato;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(488, 315);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(176, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // addstaffdataGridView
            // 
            this.addstaffdataGridView.AllowUserToOrderColumns = true;
            this.addstaffdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addstaffdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.addstaffdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addstaffdataGridView.Location = new System.Drawing.Point(12, 368);
            this.addstaffdataGridView.Name = "addstaffdataGridView";
            this.addstaffdataGridView.Size = new System.Drawing.Size(1266, 150);
            this.addstaffdataGridView.TabIndex = 4;
            // 
            // loadImageButton
            // 
            this.loadImageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadImageButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.loadImageButton.Location = new System.Drawing.Point(979, 277);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(127, 32);
            this.loadImageButton.TabIndex = 6;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // imagePathTextBox
            // 
            this.imagePathTextBox.Location = new System.Drawing.Point(935, 251);
            this.imagePathTextBox.Name = "imagePathTextBox";
            this.imagePathTextBox.Size = new System.Drawing.Size(220, 20);
            this.imagePathTextBox.TabIndex = 7;
            this.imagePathTextBox.Visible = false;
            this.imagePathTextBox.TextChanged += new System.EventHandler(this.imagePathTextBox_TextChanged);
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(838, 337);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 8;
            // 
            // loadImagePictureBox
            // 
            this.loadImagePictureBox.Location = new System.Drawing.Point(935, 33);
            this.loadImagePictureBox.Name = "loadImagePictureBox";
            this.loadImagePictureBox.Size = new System.Drawing.Size(220, 204);
            this.loadImagePictureBox.TabIndex = 5;
            this.loadImagePictureBox.TabStop = false;
            // 
            // AddStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 518);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.imagePathTextBox);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.loadImagePictureBox);
            this.Controls.Add(this.addstaffdataGridView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTER STAFF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AddStaff_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addstaffdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker addstaffDob;
        private System.Windows.Forms.TextBox addstafflastname;
        private System.Windows.Forms.TextBox addstafffirstname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox addstaffPassword;
        private System.Windows.Forms.TextBox addstaffLocation;
        private System.Windows.Forms.TextBox addstaffCounty;
        private System.Windows.Forms.TextBox addstaffEmail;
        private System.Windows.Forms.TextBox addstaffPhone;
        private System.Windows.Forms.TextBox addstaffNationalid;
        private System.Windows.Forms.DateTimePicker addstaffDoe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView addstaffdataGridView;
        private System.Windows.Forms.PictureBox loadImagePictureBox;
        private System.Windows.Forms.TextBox addstaffpfno;
        private System.Windows.Forms.Label default_pfno;
        private System.Windows.Forms.ComboBox addstaffCategory;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.TextBox imagePathTextBox;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.ComboBox staffStatusComboBox;
        private System.Windows.Forms.Label label14;
    }
}