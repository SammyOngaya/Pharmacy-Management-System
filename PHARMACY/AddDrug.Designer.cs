namespace PHARMACY
{
    partial class AddDrug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDrug));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.drugpfsession = new System.Windows.Forms.TextBox();
            this.drugform = new System.Windows.Forms.ComboBox();
            this.drugname = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addDrugdataGridView = new System.Windows.Forms.DataGridView();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addDrugdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statusComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.drugpfsession);
            this.groupBox1.Controls.Add(this.drugform);
            this.groupBox1.Controls.Add(this.drugname);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(37, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 428);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Drug";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // statusComboBox
            // 
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "Active",
            "Disable"});
            this.statusComboBox.Location = new System.Drawing.Point(189, 194);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(250, 28);
            this.statusComboBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "status";
            // 
            // drugpfsession
            // 
            this.drugpfsession.Location = new System.Drawing.Point(233, 10);
            this.drugpfsession.Name = "drugpfsession";
            this.drugpfsession.Size = new System.Drawing.Size(170, 26);
            this.drugpfsession.TabIndex = 2;
            this.drugpfsession.Visible = false;
            this.drugpfsession.TextChanged += new System.EventHandler(this.drugpfsession_TextChanged);
            // 
            // drugform
            // 
            this.drugform.FormattingEnabled = true;
            this.drugform.Location = new System.Drawing.Point(189, 112);
            this.drugform.Name = "drugform";
            this.drugform.Size = new System.Drawing.Size(250, 28);
            this.drugform.TabIndex = 6;
            this.drugform.SelectedIndexChanged += new System.EventHandler(this.drugform_SelectedIndexChanged);
            // 
            // drugname
            // 
            this.drugname.Location = new System.Drawing.Point(189, 45);
            this.drugname.MaxLength = 150;
            this.drugname.Name = "drugname";
            this.drugname.Size = new System.Drawing.Size(250, 26);
            this.drugname.TabIndex = 5;
            this.drugname.TextChanged += new System.EventHandler(this.drugname_TextChanged);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(210, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Drug Form";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drug Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // addDrugdataGridView
            // 
            this.addDrugdataGridView.AllowUserToOrderColumns = true;
            this.addDrugdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addDrugdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.addDrugdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addDrugdataGridView.Location = new System.Drawing.Point(512, 75);
            this.addDrugdataGridView.Name = "addDrugdataGridView";
            this.addDrugdataGridView.Size = new System.Drawing.Size(667, 428);
            this.addDrugdataGridView.TabIndex = 1;
            this.addDrugdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.addDrugdataGridView_CellContentClick);
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(656, 57);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 5;
            this.rowCountLabel.Click += new System.EventHandler(this.rowCountLabel_Click);
            // 
            // AddDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 548);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.addDrugdataGridView);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddDrug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTER DRUG";
            this.Load += new System.EventHandler(this.AddDrug_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addDrugdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox drugform;
        private System.Windows.Forms.TextBox drugname;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView addDrugdataGridView;
        private System.Windows.Forms.TextBox drugpfsession;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label label4;
    }
}