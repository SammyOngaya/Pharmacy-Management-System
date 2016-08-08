namespace PHARMACY
{
    partial class FinishedDrugStockLevel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.drugLevelTextBox = new System.Windows.Forms.Label();
            this.drugLevelUpdadteValue = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.drugLevelTextBox);
            this.groupBox1.Controls.Add(this.drugLevelUpdadteValue);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(82, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(871, 160);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MINIMUM DRUG STOCK LEVEL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(489, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "STOCK DRUG LEVEL";
            // 
            // drugLevelTextBox
            // 
            this.drugLevelTextBox.AutoSize = true;
            this.drugLevelTextBox.Location = new System.Drawing.Point(751, 48);
            this.drugLevelTextBox.Name = "drugLevelTextBox";
            this.drugLevelTextBox.Size = new System.Drawing.Size(0, 20);
            this.drugLevelTextBox.TabIndex = 7;
            // 
            // drugLevelUpdadteValue
            // 
            this.drugLevelUpdadteValue.Location = new System.Drawing.Point(138, 42);
            this.drugLevelUpdadteValue.MaxLength = 10;
            this.drugLevelUpdadteValue.Name = "drugLevelUpdadteValue";
            this.drugLevelUpdadteValue.Size = new System.Drawing.Size(123, 26);
            this.drugLevelUpdadteValue.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(138, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "LEVEL";
            // 
            // FinishedDrugStockLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 359);
            this.Controls.Add(this.groupBox1);
            this.Name = "FinishedDrugStockLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finished Drug Stock Level";
            this.Load += new System.EventHandler(this.FinishedDrugStockLevel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label drugLevelTextBox;
        private System.Windows.Forms.TextBox drugLevelUpdadteValue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}