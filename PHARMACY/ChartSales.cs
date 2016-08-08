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
    public partial class ChartSales : Form
    {
        public ChartSales(string buyingAmt,string sellingAmt,string discountAmt,string profitAmt)
        {
            InitializeComponent();
            
            BuyingAmountTextBox.Text=buyingAmt;
            SellingAmountTextBox.Text=sellingAmt;
            discountTextBox.Text=discountAmt;
            profitForChartTextBox.Text=profitAmt;



            LoadChart();
        }

        private void ChartSales_Load(object sender, EventArgs e)
        {

        }

        public void LoadChart()
        {
            decimal buyingAmount = Convert.ToDecimal(BuyingAmountTextBox.Text);
            decimal sellingAmount = Convert.ToDecimal(SellingAmountTextBox.Text);
            decimal discount = Convert.ToDecimal(discountTextBox.Text);
            decimal profit = Convert.ToDecimal(profitForChartTextBox.Text);

            this.salesChart.Series["SALES"].Points.AddXY("BUYING AMOUNT (" +buyingAmount+ " Kshs.)", buyingAmount);

            this.salesChart.Series["SALES"].Points.AddXY("SELLING AMOUNT (" + sellingAmount + " Kshs.)", sellingAmount);

            this.salesChart.Series["SALES"].Points.AddXY("DISCOUNT (" + discount + " Kshs.)", discount);


            this.salesChart.Series["SALES"].Points.AddXY("PROFIT (" + profit + " Kshs.)", profit);
        }
    }
}
