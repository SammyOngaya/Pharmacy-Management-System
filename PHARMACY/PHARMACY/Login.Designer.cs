namespace PHARMACY
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.login = new System.Windows.Forms.Button();
            this.loginpassword = new System.Windows.Forms.TextBox();
            this.loginusername = new System.Windows.Forms.TextBox();
            this.loginp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userCategory = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(228, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(647, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHARMACY MANAGEMENT SYSTEM";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.login);
            this.groupBox1.Controls.Add(this.loginpassword);
            this.groupBox1.Controls.Add(this.loginusername);
            this.groupBox1.Controls.Add(this.loginp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(316, 288);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 184);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(172, 137);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(165, 41);
            this.login.TabIndex = 4;
            this.login.Text = "login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click_1);
            // 
            // loginpassword
            // 
            this.loginpassword.Location = new System.Drawing.Point(157, 94);
            this.loginpassword.Name = "loginpassword";
            this.loginpassword.PasswordChar = '*';
            this.loginpassword.Size = new System.Drawing.Size(226, 29);
            this.loginpassword.TabIndex = 3;
            // 
            // loginusername
            // 
            this.loginusername.Location = new System.Drawing.Point(157, 39);
            this.loginusername.Name = "loginusername";
            this.loginusername.Size = new System.Drawing.Size(226, 29);
            this.loginusername.TabIndex = 2;
            // 
            // loginp
            // 
            this.loginp.AutoSize = true;
            this.loginp.Location = new System.Drawing.Point(21, 97);
            this.loginp.Name = "loginp";
            this.loginp.Size = new System.Drawing.Size(100, 24);
            this.loginp.TabIndex = 1;
            this.loginp.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username";
            // 
            // userCategory
            // 
            this.userCategory.Enabled = false;
            this.userCategory.Location = new System.Drawing.Point(758, 69);
            this.userCategory.Name = "userCategory";
            this.userCategory.Size = new System.Drawing.Size(214, 20);
            this.userCategory.TabIndex = 3;
            this.userCategory.Visible = false;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Enabled = false;
            this.firstNameTextBox.Location = new System.Drawing.Point(248, 69);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(214, 20);
            this.firstNameTextBox.TabIndex = 4;
            this.firstNameTextBox.Visible = false;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Enabled = false;
            this.lastNameTextBox.Location = new System.Drawing.Point(504, 69);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(214, 20);
            this.lastNameTextBox.TabIndex = 5;
            this.lastNameTextBox.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PHARMACY.Properties.Resources.curve_jpg;
            this.pictureBox1.Location = new System.Drawing.Point(123, 95);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(901, 164);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 498);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.userCategory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PMS LOGIN";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.TextBox loginpassword;
        private System.Windows.Forms.TextBox loginusername;
        private System.Windows.Forms.Label loginp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userCategory;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
    }
}

