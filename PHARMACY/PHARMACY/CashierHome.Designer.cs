namespace PHARMACY
{
    partial class CashierHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierHome));
            this.pfsession = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cashSale = new System.Windows.Forms.Button();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.quantitySale = new System.Windows.Forms.Button();
            this.QuantitySalePictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.drugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDrugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.netStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewNetStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debtorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDebtorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDebtorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDebtorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.time = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuantitySalePictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pfsession
            // 
            this.pfsession.Location = new System.Drawing.Point(190, 60);
            this.pfsession.Name = "pfsession";
            this.pfsession.Size = new System.Drawing.Size(74, 20);
            this.pfsession.TabIndex = 49;
            this.pfsession.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(787, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 164);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "reports";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(22, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 124);
            this.button2.TabIndex = 18;
            this.button2.Text = "Reports";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cashSale);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(441, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 164);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "quantity sale";
            // 
            // cashSale
            // 
            this.cashSale.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cashSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cashSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashSale.Location = new System.Drawing.Point(16, 34);
            this.cashSale.Name = "cashSale";
            this.cashSale.Size = new System.Drawing.Size(179, 113);
            this.cashSale.TabIndex = 36;
            this.cashSale.Text = "Quantity Sale";
            this.cashSale.UseVisualStyleBackColor = false;
            this.cashSale.Click += new System.EventHandler(this.cashSale_Click);
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Enabled = false;
            this.firstNameTextBox.Location = new System.Drawing.Point(348, 60);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(214, 20);
            this.firstNameTextBox.TabIndex = 50;
            this.firstNameTextBox.Visible = false;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Enabled = false;
            this.lastNameTextBox.Location = new System.Drawing.Point(659, 60);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(214, 20);
            this.lastNameTextBox.TabIndex = 51;
            this.lastNameTextBox.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.welcomeLabel);
            this.groupBox7.Controls.Add(this.QuantitySalePictureBox);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.ForeColor = System.Drawing.Color.Gray;
            this.groupBox7.Location = new System.Drawing.Point(1030, 112);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(263, 224);
            this.groupBox7.TabIndex = 55;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "cashier";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(24, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 16);
            this.label11.TabIndex = 8;
            this.label11.Text = "welcome  ";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.Black;
            this.welcomeLabel.Location = new System.Drawing.Point(95, 22);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(68, 16);
            this.welcomeLabel.TabIndex = 7;
            this.welcomeLabel.Text = "welcome  ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.quantitySale);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(94, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 164);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "cash sale";
            // 
            // quantitySale
            // 
            this.quantitySale.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.quantitySale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.quantitySale.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantitySale.Location = new System.Drawing.Point(21, 34);
            this.quantitySale.Name = "quantitySale";
            this.quantitySale.Size = new System.Drawing.Size(170, 113);
            this.quantitySale.TabIndex = 18;
            this.quantitySale.Text = "Cash Sale";
            this.quantitySale.UseVisualStyleBackColor = false;
            this.quantitySale.Click += new System.EventHandler(this.quantitySale_Click);
            // 
            // QuantitySalePictureBox
            // 
            this.QuantitySalePictureBox.Location = new System.Drawing.Point(16, 47);
            this.QuantitySalePictureBox.Name = "QuantitySalePictureBox";
            this.QuantitySalePictureBox.Size = new System.Drawing.Size(227, 167);
            this.QuantitySalePictureBox.TabIndex = 4;
            this.QuantitySalePictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.NavajoWhite;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drugToolStripMenuItem,
            this.netStockToolStripMenuItem,
            this.debtorToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.calculatorToolStripMenuItem,
            this.time});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1306, 29);
            this.menuStrip1.TabIndex = 56;
            this.menuStrip1.Text = "logout";
            // 
            // drugToolStripMenuItem
            // 
            this.drugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDrugToolStripMenuItem});
            this.drugToolStripMenuItem.Name = "drugToolStripMenuItem";
            this.drugToolStripMenuItem.Size = new System.Drawing.Size(60, 25);
            this.drugToolStripMenuItem.Text = "Drug";
            // 
            // viewDrugToolStripMenuItem
            // 
            this.viewDrugToolStripMenuItem.Name = "viewDrugToolStripMenuItem";
            this.viewDrugToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.viewDrugToolStripMenuItem.Text = "View Drug";
            this.viewDrugToolStripMenuItem.Click += new System.EventHandler(this.viewDrugToolStripMenuItem_Click);
            // 
            // netStockToolStripMenuItem
            // 
            this.netStockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewNetStockToolStripMenuItem});
            this.netStockToolStripMenuItem.Name = "netStockToolStripMenuItem";
            this.netStockToolStripMenuItem.Size = new System.Drawing.Size(96, 25);
            this.netStockToolStripMenuItem.Text = "Net Stock";
            // 
            // viewNetStockToolStripMenuItem
            // 
            this.viewNetStockToolStripMenuItem.Name = "viewNetStockToolStripMenuItem";
            this.viewNetStockToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.viewNetStockToolStripMenuItem.Text = "View Net Stock";
            this.viewNetStockToolStripMenuItem.Click += new System.EventHandler(this.viewNetStockToolStripMenuItem_Click);
            // 
            // debtorToolStripMenuItem
            // 
            this.debtorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDebtorToolStripMenuItem,
            this.updateDebtorToolStripMenuItem,
            this.viewDebtorToolStripMenuItem});
            this.debtorToolStripMenuItem.Name = "debtorToolStripMenuItem";
            this.debtorToolStripMenuItem.Size = new System.Drawing.Size(75, 25);
            this.debtorToolStripMenuItem.Text = "Debtor";
            // 
            // addDebtorToolStripMenuItem
            // 
            this.addDebtorToolStripMenuItem.Name = "addDebtorToolStripMenuItem";
            this.addDebtorToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.addDebtorToolStripMenuItem.Text = "Add Debtor";
            this.addDebtorToolStripMenuItem.Click += new System.EventHandler(this.addDebtorToolStripMenuItem_Click);
            // 
            // updateDebtorToolStripMenuItem
            // 
            this.updateDebtorToolStripMenuItem.Name = "updateDebtorToolStripMenuItem";
            this.updateDebtorToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.updateDebtorToolStripMenuItem.Text = "Update Debtor";
            this.updateDebtorToolStripMenuItem.Click += new System.EventHandler(this.updateDebtorToolStripMenuItem_Click);
            // 
            // viewDebtorToolStripMenuItem
            // 
            this.viewDebtorToolStripMenuItem.Name = "viewDebtorToolStripMenuItem";
            this.viewDebtorToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.viewDebtorToolStripMenuItem.Text = "View Debtor";
            this.viewDebtorToolStripMenuItem.Click += new System.EventHandler(this.viewDebtorToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(80, 25);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(73, 25);
            this.logoutToolStripMenuItem.Text = "logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(56, 25);
            this.helpToolStripMenuItem.Text = "help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // calculatorToolStripMenuItem
            // 
            this.calculatorToolStripMenuItem.Name = "calculatorToolStripMenuItem";
            this.calculatorToolStripMenuItem.Size = new System.Drawing.Size(100, 25);
            this.calculatorToolStripMenuItem.Text = "Calculator";
            this.calculatorToolStripMenuItem.Click += new System.EventHandler(this.calculatorToolStripMenuItem_Click);
            // 
            // time
            // 
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(60, 25);
            this.time.Text = "Time";
            // 
            // CashierHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 589);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pfsession);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CashierHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CashierHome";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QuantitySalePictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pfsession;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cashSale;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.PictureBox QuantitySalePictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button quantitySale;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem drugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDrugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem netStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewNetStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debtorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDebtorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateDebtorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDebtorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem time;
    }
}