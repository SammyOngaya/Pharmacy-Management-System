namespace PHARMACY
{
    partial class DrugForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrugForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.drugFormIDTextBox = new System.Windows.Forms.TextBox();
            this.drugFormTextBox = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.drugFormdataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.searchDrugFormtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drugFormdataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.delete);
            this.groupBox1.Controls.Add(this.update);
            this.groupBox1.Controls.Add(this.drugFormIDTextBox);
            this.groupBox1.Controls.Add(this.drugFormTextBox);
            this.groupBox1.Controls.Add(this.save);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(81, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 307);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Drug Form";
            // 
            // delete
            // 
            this.delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete.Location = new System.Drawing.Point(301, 151);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(123, 40);
            this.delete.TabIndex = 7;
            this.delete.Text = "delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // update
            // 
            this.update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.update.Location = new System.Drawing.Point(153, 151);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(123, 40);
            this.update.TabIndex = 6;
            this.update.Text = "update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // drugFormIDTextBox
            // 
            this.drugFormIDTextBox.Location = new System.Drawing.Point(303, 10);
            this.drugFormIDTextBox.Name = "drugFormIDTextBox";
            this.drugFormIDTextBox.Size = new System.Drawing.Size(100, 26);
            this.drugFormIDTextBox.TabIndex = 2;
            this.drugFormIDTextBox.Visible = false;
            // 
            // drugFormTextBox
            // 
            this.drugFormTextBox.Location = new System.Drawing.Point(153, 42);
            this.drugFormTextBox.MaxLength = 100;
            this.drugFormTextBox.Name = "drugFormTextBox";
            this.drugFormTextBox.Size = new System.Drawing.Size(250, 26);
            this.drugFormTextBox.TabIndex = 5;
            // 
            // save
            // 
            this.save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save.Location = new System.Drawing.Point(11, 151);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(123, 40);
            this.save.TabIndex = 3;
            this.save.Text = "save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Drug Form";
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(700, 117);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 8;
            // 
            // drugFormdataGridView
            // 
            this.drugFormdataGridView.AllowUserToOrderColumns = true;
            this.drugFormdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.drugFormdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.drugFormdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drugFormdataGridView.Location = new System.Drawing.Point(556, 145);
            this.drugFormdataGridView.Name = "drugFormdataGridView";
            this.drugFormdataGridView.Size = new System.Drawing.Size(667, 309);
            this.drugFormdataGridView.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.searchDrugFormtextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(556, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(564, 61);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "search drug form";
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(423, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 40);
            this.button4.TabIndex = 8;
            this.button4.Text = "search";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // searchDrugFormtextBox
            // 
            this.searchDrugFormtextBox.Location = new System.Drawing.Point(150, 25);
            this.searchDrugFormtextBox.Name = "searchDrugFormtextBox";
            this.searchDrugFormtextBox.Size = new System.Drawing.Size(250, 20);
            this.searchDrugFormtextBox.TabIndex = 7;
            this.searchDrugFormtextBox.TextChanged += new System.EventHandler(this.searchDrugFormtextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Drug Form";
            // 
            // DrugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 570);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.drugFormdataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DrugForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DRUG FORM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DrugForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drugFormdataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.TextBox drugFormIDTextBox;
        private System.Windows.Forms.TextBox drugFormTextBox;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.DataGridView drugFormdataGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox searchDrugFormtextBox;
        private System.Windows.Forms.Label label1;
    }
}