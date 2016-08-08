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
    public partial class ChartNetStock : Form
    {
        public ChartNetStock(string buyingAmt, string sellingAmt, string profitAmt)
        {
            InitializeComponent();

            BuyingAmountTextBox.Text = buyingAmt;
            SellingAmountTextBox.Text = sellingAmt;
            profitForChartTextBox.Text = profitAmt;

            LoadChart();

        }

        private void ChartNetStock_Load(object sender, EventArgs e)
        {

        }


        public void LoadChart()
        {
            decimal buyingAmount = Convert.ToDecimal(BuyingAmountTextBox.Text);
            decimal sellingAmount = Convert.ToDecimal(SellingAmountTextBox.Text);
            decimal profit = Convert.ToDecimal(profitForChartTextBox.Text);

            this.salesChart.Series["NET STOCK"].Points.AddXY("BUYING AMOUNT (" + buyingAmount + " Kshs.)", buyingAmount);

            this.salesChart.Series["NET STOCK"].Points.AddXY("SELLING AMOUNT (" + sellingAmount + " Kshs.)", sellingAmount);

            this.salesChart.Series["NET STOCK"].Points.AddXY("PROFIT (" + profit + " Kshs.)", profit);
        }

    }
}
