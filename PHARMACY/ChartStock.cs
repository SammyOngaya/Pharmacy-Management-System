using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PHARMACY
{
    public partial class ChartStock : Form
    {
        public ChartStock(string buyingAmt, string sellingAmt, string projSellingAmt, string profitAmt, string projProfit)
        {
            InitializeComponent();

            BuyingAmountTextBox.Text = buyingAmt;
            SellingAmountTextBox.Text = sellingAmt;
            projectedSellingAmountTextBox.Text = projSellingAmt;
            profitForChartTextBox.Text = profitAmt;
            projProfitTextBox.Text = projProfit;

            LoadChart();

        }

        private void ChartStock_Load(object sender, EventArgs e)
        {

        }

        public void LoadChart()
        {
            decimal buyingAmount = Convert.ToDecimal(BuyingAmountTextBox.Text);
            decimal sellingAmount = Convert.ToDecimal(SellingAmountTextBox.Text);
            decimal projSellingAmount = Convert.ToDecimal(projectedSellingAmountTextBox.Text);
            decimal profit = Convert.ToDecimal(profitForChartTextBox.Text);
            decimal projProfitAmount = Convert.ToDecimal(projProfitTextBox.Text);

            this.salesChart.Series["STOCK"].Points.AddXY("BUYING AMT (" + buyingAmount + " Kshs.)", buyingAmount);

            this.salesChart.Series["STOCK"].Points.AddXY("SELLING AMT (" + sellingAmount + " Kshs.)", sellingAmount);

            this.salesChart.Series["STOCK"].Points.AddXY("PROFIT (" + profit + " Kshs.)", profit);

            this.salesChart.Series["STOCK"].Points.AddXY("PROJ. SELLING AMT (" + projSellingAmount + " Kshs.)", projSellingAmount);

            this.salesChart.Series["STOCK"].Points.AddXY("PROJ. PROFIT (" + projProfitAmount + " Kshs.)", projProfitAmount);

        }

    }
}
