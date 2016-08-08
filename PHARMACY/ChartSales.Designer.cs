namespace PHARMACY
{
    partial class ChartSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartSales));
            this.salesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.profitForChartTextBox = new System.Windows.Forms.TextBox();
            this.discountTextBox = new System.Windows.Forms.TextBox();
            this.BuyingAmountTextBox = new System.Windows.Forms.TextBox();
            this.SellingAmountTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.salesChart)).BeginInit();
            this.SuspendLayout();
            // 
            // salesChart
            // 
            chartArea1.Name = "ChartArea1";
            this.salesChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.salesChart.Legends.Add(legend1);
            this.salesChart.Location = new System.Drawing.Point(165, 116);
            this.salesChart.Name = "salesChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.LegendText = "SALES CHART";
            series1.Name = "SALES";
            this.salesChart.Series.Add(series1);
            this.salesChart.Size = new System.Drawing.Size(763, 392);
            this.salesChart.TabIndex = 0;
            this.salesChart.Text = "SALES CHART";
            // 
            // profitForChartTextBox
            // 
            this.profitForChartTextBox.Location = new System.Drawing.Point(721, 12);
            this.profitForChartTextBox.Name = "profitForChartTextBox";
            this.profitForChartTextBox.Size = new System.Drawing.Size(169, 20);
            this.profitForChartTextBox.TabIndex = 84;
            this.profitForChartTextBox.Visible = false;
            // 
            // discountTextBox
            // 
            this.discountTextBox.Location = new System.Drawing.Point(526, 12);
            this.discountTextBox.Name = "discountTextBox";
            this.discountTextBox.Size = new System.Drawing.Size(169, 20);
            this.discountTextBox.TabIndex = 83;
            this.discountTextBox.Visible = false;
            // 
            // BuyingAmountTextBox
            // 
            this.BuyingAmountTextBox.Location = new System.Drawing.Point(165, 12);
            this.BuyingAmountTextBox.Name = "BuyingAmountTextBox";
            this.BuyingAmountTextBox.Size = new System.Drawing.Size(169, 20);
            this.BuyingAmountTextBox.TabIndex = 82;
            this.BuyingAmountTextBox.Visible = false;
            // 
            // SellingAmountTextBox
            // 
            this.SellingAmountTextBox.Location = new System.Drawing.Point(340, 12);
            this.SellingAmountTextBox.Name = "SellingAmountTextBox";
            this.SellingAmountTextBox.Size = new System.Drawing.Size(176, 20);
            this.SellingAmountTextBox.TabIndex = 81;
            this.SellingAmountTextBox.Visible = false;
            // 
            // ChartSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 576);
            this.Controls.Add(this.profitForChartTextBox);
            this.Controls.Add(this.discountTextBox);
            this.Controls.Add(this.BuyingAmountTextBox);
            this.Controls.Add(this.SellingAmountTextBox);
            this.Controls.Add(this.salesChart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHARTS";
            this.Load += new System.EventHandler(this.ChartSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salesChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart salesChart;
        private System.Windows.Forms.TextBox profitForChartTextBox;
        private System.Windows.Forms.TextBox discountTextBox;
        private System.Windows.Forms.TextBox BuyingAmountTextBox;
        private System.Windows.Forms.TextBox SellingAmountTextBox;
    }
}