namespace PHARMACY
{
    partial class ViewDrug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewDrug));
            this.viewDrugdataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.printDrugPdfButton = new System.Windows.Forms.Button();
            this.printDrugExcel = new System.Windows.Forms.Button();
            this.rowCountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.viewDrugdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // viewDrugdataGridView
            // 
            this.viewDrugdataGridView.AllowUserToOrderColumns = true;
            this.viewDrugdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.viewDrugdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.viewDrugdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewDrugdataGridView.Location = new System.Drawing.Point(108, 61);
            this.viewDrugdataGridView.Name = "viewDrugdataGridView";
            this.viewDrugdataGridView.Size = new System.Drawing.Size(839, 372);
            this.viewDrugdataGridView.TabIndex = 0;
            this.viewDrugdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.viewDrugdataGridView_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(261, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "View Drugs";
            // 
            // printDrugPdfButton
            // 
            this.printDrugPdfButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.printDrugPdfButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printDrugPdfButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printDrugPdfButton.Location = new System.Drawing.Point(394, 4);
            this.printDrugPdfButton.Name = "printDrugPdfButton";
            this.printDrugPdfButton.Size = new System.Drawing.Size(132, 39);
            this.printDrugPdfButton.TabIndex = 2;
            this.printDrugPdfButton.Text = "Print Pdf";
            this.printDrugPdfButton.UseVisualStyleBackColor = false;
            this.printDrugPdfButton.Click += new System.EventHandler(this.printDrugPdfButton_Click);
            // 
            // printDrugExcel
            // 
            this.printDrugExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.printDrugExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printDrugExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printDrugExcel.Location = new System.Drawing.Point(585, 9);
            this.printDrugExcel.Name = "printDrugExcel";
            this.printDrugExcel.Size = new System.Drawing.Size(132, 34);
            this.printDrugExcel.TabIndex = 3;
            this.printDrugExcel.Text = "Print Excel";
            this.printDrugExcel.UseVisualStyleBackColor = false;
            this.printDrugExcel.Click += new System.EventHandler(this.printDrugExcel_Click);
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(821, 22);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 5;
            // 
            // ViewDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 445);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.printDrugExcel);
            this.Controls.Add(this.printDrugPdfButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewDrugdataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewDrug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIEW DRUGS";
            this.Load += new System.EventHandler(this.ViewDrug_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewDrugdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView viewDrugdataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button printDrugPdfButton;
        private System.Windows.Forms.Button printDrugExcel;
        private System.Windows.Forms.Label rowCountLabel;
    }
}