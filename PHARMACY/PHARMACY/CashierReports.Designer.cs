namespace PHARMACY
{
    partial class CashierReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierReports));
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.finishedDrugdataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.expiredDrugDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finishedDrugdataGridView1)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expiredDrugDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.finishedDrugdataGridView1);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox8.Location = new System.Drawing.Point(612, 12);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(431, 494);
            this.groupBox8.TabIndex = 48;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Finished Drugs";
            // 
            // finishedDrugdataGridView1
            // 
            this.finishedDrugdataGridView1.AllowUserToOrderColumns = true;
            this.finishedDrugdataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.finishedDrugdataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.finishedDrugdataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.finishedDrugdataGridView1.Location = new System.Drawing.Point(6, 25);
            this.finishedDrugdataGridView1.Name = "finishedDrugdataGridView1";
            this.finishedDrugdataGridView1.Size = new System.Drawing.Size(419, 463);
            this.finishedDrugdataGridView1.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.expiredDrugDataGridView);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox7.Location = new System.Drawing.Point(114, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(431, 494);
            this.groupBox7.TabIndex = 47;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Expired Drug";
            // 
            // expiredDrugDataGridView
            // 
            this.expiredDrugDataGridView.AllowUserToOrderColumns = true;
            this.expiredDrugDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.expiredDrugDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.expiredDrugDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expiredDrugDataGridView.Location = new System.Drawing.Point(16, 31);
            this.expiredDrugDataGridView.Name = "expiredDrugDataGridView";
            this.expiredDrugDataGridView.Size = new System.Drawing.Size(388, 463);
            this.expiredDrugDataGridView.TabIndex = 0;
            // 
            // CashierReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 483);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CashierReports";
            this.Text = "CashierReports";
            this.Load += new System.EventHandler(this.CashierReports_Load);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.finishedDrugdataGridView1)).EndInit();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expiredDrugDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView finishedDrugdataGridView1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView expiredDrugDataGridView;
    }
}