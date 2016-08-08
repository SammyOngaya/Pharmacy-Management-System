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
    public partial class ChartDebtor : Form
    {
        public ChartDebtor(string buyingAmt, string sellingAmt, string profitAmt)
        {
            InitializeComponent();

            debtorAmountTextBox.Text = buyingAmt;
            depositedAmountTextBox.Text = sellingAmt;
            DebtorsRemainingAmountTextBox.Text = profitAmt;

            LoadChart();

        }

        private void ChartDebtor_Load(object sender, EventArgs e)
        {

        }



        public void LoadChart()
        {
            decimal buyingAmount = Convert.ToDecimal(debtorAmountTextBox.Text);
            decimal sellingAmount = Convert.ToDecimal(depositedAmountTextBox.Text);
            decimal profit = Convert.ToDecimal(DebtorsRemainingAmountTextBox.Text);

            this.salesChart.Series["DEBTOR"].Points.AddXY("TOTAL AMOUNT (" + buyingAmount + " Kshs.)", buyingAmount);

            this.salesChart.Series["DEBTOR"].Points.AddXY("DEPOSIT (" + sellingAmount + " Kshs.)", sellingAmount);

            this.salesChart.Series["DEBTOR"].Points.AddXY("REMAINING AMOUNT (" + profit + " Kshs.)", profit);
        }


    }
}
