namespace PHARMACY
{
    partial class ChartDebtor
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartDebtor));
            this.DebtorsRemainingAmountTextBox = new System.Windows.Forms.TextBox();
            this.debtorAmountTextBox = new System.Windows.Forms.TextBox();
            this.depositedAmountTextBox = new System.Windows.Forms.TextBox();
            this.salesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.salesChart)).BeginInit();
            this.SuspendLayout();
            // 
            // DebtorsRemainingAmountTextBox
            // 
            this.DebtorsRemainingAmountTextBox.Location = new System.Drawing.Point(641, 47);
            this.DebtorsRemainingAmountTextBox.Name = "DebtorsRemainingAmountTextBox";
            this.DebtorsRemainingAmountTextBox.Size = new System.Drawing.Size(169, 20);
            this.DebtorsRemainingAmountTextBox.TabIndex = 93;
            this.DebtorsRemainingAmountTextBox.Visible = false;
            // 
            // debtorAmountTextBox
            // 
            this.debtorAmountTextBox.Location = new System.Drawing.Point(249, 47);
            this.debtorAmountTextBox.Name = "debtorAmountTextBox";
            this.debtorAmountTextBox.Size = new System.Drawing.Size(169, 20);
            this.debtorAmountTextBox.TabIndex = 92;
            this.debtorAmountTextBox.Visible = false;
            // 
            // depositedAmountTextBox
            // 
            this.depositedAmountTextBox.Location = new System.Drawing.Point(424, 47);
            this.depositedAmountTextBox.Name = "depositedAmountTextBox";
            this.depositedAmountTextBox.Size = new System.Drawing.Size(176, 20);
            this.depositedAmountTextBox.TabIndex = 91;
            this.depositedAmountTextBox.Visible = false;
            // 
            // salesChart
            // 
            chartArea1.Name = "ChartArea1";
            this.salesChart.ChartAreas.Add(chartArea1);
            legend1.Name = "DEBTORS CHART";
            this.salesChart.Legends.Add(legend1);
            this.salesChart.Location = new System.Drawing.Point(249, 151);
            this.salesChart.Name = "salesChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "DEBTORS CHART";
            series1.LegendText = "DEBTOR";
            series1.Name = "DEBTOR";
            this.salesChart.Series.Add(series1);
            this.salesChart.Size = new System.Drawing.Size(763, 392);
            this.salesChart.TabIndex = 90;
            this.salesChart.Text = "SALES CHART";
            // 
            // ChartDebtor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 590);
            this.Controls.Add(this.DebtorsRemainingAmountTextBox);
            this.Controls.Add(this.debtorAmountTextBox);
            this.Controls.Add(this.depositedAmountTextBox);
            this.Controls.Add(this.salesChart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartDebtor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DEBTOR CHART";
            this.Load += new System.EventHandler(this.ChartDebtor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salesChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DebtorsRemainingAmountTextBox;
        private System.Windows.Forms.TextBox debtorAmountTextBox;
        private System.Windows.Forms.TextBox depositedAmountTextBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart salesChart;
    }
}