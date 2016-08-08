using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;
using System.Diagnostics;

namespace PHARMACY
{
    public partial class ReportDailySales : Form
    {
        MySqlConnection con = null;
        DataTable dataTable;
       
        public ReportDailySales()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            discountView();
            salesView();


           LoadChart();
           LoadBarChart();
           LoadPieChart();

        }

        private void ReportDailySales_Load(object sender, EventArgs e)
        {

        }

        public void ClearData()
        {
            

            this.salesChart.Series["SALES"].Points.Clear();
            this.salesBarChart.Series["SALES"].Points.Clear();
            this.salesPieChart.Series["SALES"].Points.Clear();

            salesPieChart.Refresh();
            salesBarChart.Refresh();
            salesChart.Refresh();

        }

      
        //compute amount transacted.
        public void TotalBuyingAmount()
        {
            try
            {
                double sum = 0.00;
                for (int i = 0; i < salesReportDataGridView.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(salesReportDataGridView.Rows[i].Cells[2].Value);

                }

                TotalBuyingAmountLabel.Text = "total buying amount  " + sum.ToString() + " Kshs";
                BuyingAmountTextBox.Text = sum.ToString();
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }
        //compute amount transacted.
        public void TotalSellingAmount()
        {
            try
            {
                double sum = 0.00;
                for (int i = 0; i < salesReportDataGridView.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(salesReportDataGridView.Rows[i].Cells[3].Value);

                }
                double discount = Convert.ToDouble(discountTextBox.Text);
                double newSum = (sum - discount);
                TotalSellingAmountLabel.Text = "total selling amount  " + newSum.ToString() + " Kshs";
                SellingAmountTextBox.Text = newSum.ToString();
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }
        //compute amount transacted.
        public void TotalPproffitAmount()
        {

            try
            {

                double buyingPrice = Convert.ToDouble(BuyingAmountTextBox.Text);
                double sellingPrice = Convert.ToDouble(SellingAmountTextBox.Text);

                double profit = sellingPrice - buyingPrice;

                ProfitAmountLabel.Text = "profit  " + profit.ToString() + " Kshs";
                profitForChartTextBox.Text = profit.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        ///////////////////////////////##################### DISCOUNT SUMAATION METHODS#######################3////////////////////////////

        //compute view discount.
        public void ViewDisountAmount()
        {
            try
            {
                double sum = 0.00;
                for (int i = 0; i < discountDataGridView.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(discountDataGridView.Rows[i].Cells[1].Value);

                }

                discountLabel.Text = "discount  " + sum.ToString() + " Kshs";
                discountTextBox.Text = sum.ToString();
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }

        //////////////////////////////################### END DISCOUNT SUMMATION METHODS ###############################///////////////////

        /////////////////////########################33 DISCOUNT VIEW ###########################//////////////////////////////
        public void discountView()
        {
            String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand discount = new MySqlCommand("SELECT DISTINCT(serial), SUM(discount) FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` GROUP BY sales_date ", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = discount;
                DataTable dt = new DataTable();
                a.Fill(dt);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                discountDataGridView.DataSource = bs;
                a.Update(dt);
                con.Close();

            }
            catch (Exception)
            {
            }
            finally
            {
                ViewDisountAmount();
            }
        }



        // Filter by date range

        public void discountViewFilterByDateRange()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
          
            try
            {
                string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
                string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");

                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand discount = new MySqlCommand("SELECT DISTINCT(serial), SUM(discount) FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE sales_date BETWEEN '" + startDate + "' AND '" + endDate + "' GROUP BY sales_date ", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = discount;
                DataTable dt = new DataTable();
                a.Fill(dt);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                discountDataGridView.DataSource = bs;
                a.Update(dt);
                con.Close();

            }
            catch (Exception)
            {
            }
            finally
            {
                ViewDisountAmount();
            }
        }



        // Filter by date.
        public void discountViewFilterByDate()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            
            try
            {
                string date = dateDateTimePicker.Value.ToString("yyyy-MM-dd");

                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand discount = new MySqlCommand("SELECT DISTINCT(serial),  SUM(discount) FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE sales_date='" + date + "' GROUP BY sales_date ORDER BY sales_date DESC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = discount;
                DataTable dt = new DataTable();
                a.Fill(dt);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                discountDataGridView.DataSource = bs;
                a.Update(dt);
                con.Close();

            }
            catch (Exception)
            {
            }
            finally
            {
                ViewDisountAmount();
            }
        }


        //////////////////////////################################ END DISCOUNT METHOD ##########################3//////////////////////////////


        public void salesView()
        {

            try
            {

                MySqlCommand com = new MySqlCommand("SELECT DISTINCT(serial) AS 'SERIAL',SUM(`sales`.`discount`) AS 'DISCOUNT', SUM(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2)) AS 'BUYING AMOUNT', SUM(ROUND((`sales`.`quantity` *`sales`.`price`),2)) AS 'SELLING AMOUNT',SUM((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT',`sales`.`sales_date` AS 'DATE SOLD' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` GROUP BY `sales`.`sales_date` ORDER BY sales_date DESC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("DATE SOLD", typeof(string));
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("DISCOUNT");
                dataTable.Columns.Add("SERIAL");
                // End formating titles.
                
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                salesReportDataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(salesReportDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            TotalBuyingAmount();
            TotalSellingAmount();
            TotalPproffitAmount();

        }


        // Filter by date.
        public void salesViewFilterByDate()
        {
            string date = dateDateTimePicker.Value.ToString("yyyy-MM-dd");
            try
            {

                MySqlCommand com = new MySqlCommand("SELECT DISTINCT(serial)AS 'SERIAL',SUM(`sales`.`discount`) AS 'DISCOUNT', SUM(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2)) AS 'BUYING AMOUNT', SUM(ROUND((`sales`.`quantity` *`sales`.`price`),2)) AS 'SELLING AMOUNT',SUM((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT',`sales`.`sales_date` AS 'DATE SOLD' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE sales_date='" + date + "' GROUP BY `sales`.`sales_date` ORDER BY sales_date DESC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("DATE SOLD", typeof(string));
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("DISCOUNT");
                dataTable.Columns.Add("SERIAL");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                salesReportDataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(salesReportDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TotalBuyingAmount();
            TotalSellingAmount();
            TotalPproffitAmount();

        }

        
        // Fliter by date range.
        public void salesViewFilterByDateRange()
        {
            string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");

            try
            {

                MySqlCommand com = new MySqlCommand("SELECT DISTINCT(serial) AS 'SERIAL',SUM(`sales`.`discount`) AS 'DISCOUNT',SUM(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2)) AS 'BUYING AMOUNT',SUM(ROUND((`sales`.`quantity` *`sales`.`price`),2)) AS 'SELLING AMOUNT',SUM((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT',`sales`.`sales_date` AS 'DATE SOLD' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE sales_date BETWEEN '" + startDate + "' AND '" + endDate + "' GROUP BY `sales`.`sales_date` ORDER BY sales_date DESC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("DATE SOLD", typeof(string));
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("DISCOUNT");
                dataTable.Columns.Add("SERIAL");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                salesReportDataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(salesReportDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TotalBuyingAmount();
            TotalSellingAmount();
            TotalPproffitAmount();

        }

        // Reports.
        //print sales spreadsheet
        public void salesExcel()
        {

            try
            {
                //DataTable dtCopy = dataTable.Copy();
                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dataTable);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\PMS\\Reports\\DAILY SALES REPORT.xls", ds);

                MessageBox.Show("Report generated successfully...............!", "DAILY SALES REPORT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process sts = System.Diagnostics.Process.Start("C:\\PMS\\Reports\\DAILY SALES REPORT.xls");
                sts.WaitForExit();


            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while generating system sales report ............!", "DAILY SALES REPORT GENERATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }


        //print sales report.

        public void salesPdf()
        {
            try
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
                PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\DAILY SALES REPORT.pdf", FileMode.Create));
                doc.Open();//open document to write

                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\PMS\\Resources\\faith2.png");
                img.ScalePercent(79f);
                /// img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);

                doc.Add(img); //add image to document
                Paragraph p = new Paragraph("                                                                DAILY SALES REPORT");
                doc.Add(p);
                DateTime time = DateTime.Now;

                Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "                     On         " + time.ToString() + "        \n\n");
                doc.Add(p2);


                //load data from datagrid
                PdfPTable table = new PdfPTable(salesReportDataGridView.Columns.Count);

                //add headers from the datagridview to the table
                for (int j = 0; j < salesReportDataGridView.Columns.Count; j++)
                {

                    table.AddCell(new Phrase(salesReportDataGridView.Columns[j].HeaderText));

                }

                //flag the first row as header

                table.HeaderRows = 1;

                //add the actual rows to the table from datagridview

                for (int i = 0; i < salesReportDataGridView.Rows.Count; i++)
                {
                    for (int k = 0; k < salesReportDataGridView.Columns.Count; k++)
                    {

                        if (salesReportDataGridView[k, i].Value != null)
                        {

                            table.AddCell(new Phrase(salesReportDataGridView[k, i].Value.ToString()));
                        }

                    }

                }

                doc.Add(table);
                // End querying from datagrid.


                doc.Close();//close document after writting in.

                MessageBox.Show("Report generated successfully...............!", "DAILY SALES REPORT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Diagnostics.Process.Start("C:\\PMS\\Reports\\DAILY SALES REPORT.pdf");

            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ", "DOCUMENT ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            salesExcel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            salesPdf();
        }

      
        private void dateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            discountViewFilterByDate();
            salesViewFilterByDate();

            ClearData();

            LoadChartFilterByDate();
            LoadBarChart();
            LoadPieChart();
        }

        private void searchDate_Click(object sender, EventArgs e)
        {
            discountViewFilterByDate();
            salesViewFilterByDate();

            ClearData();

            LoadChartFilterByDate();
            LoadBarChart();
            LoadPieChart();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           // ClearData();
            salesView();

            ClearData();

            LoadChart();
            LoadBarChart();
            LoadPieChart();
        }

        private void endDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            discountViewFilterByDateRange();
            salesViewFilterByDateRange();

            ClearData();

            LoadChartFilterByDateRange();
            LoadBarChart();
            LoadPieChart();

           
        }

        private void searchByDate_Click(object sender, EventArgs e)
        {
            discountViewFilterByDateRange();
            salesViewFilterByDateRange();

            ClearData();

            LoadChartFilterByDateRange();
            LoadBarChart();
            LoadPieChart();
           
        }

        public void LoadChart()
        {
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT DISTINCT(serial) AS 'SERIAL',SUM(`sales`.`discount`) AS 'DISCOUNT', SUM(ROUND((`sales`.`quantity` *`sales`.`price`),2)) AS 'AMOUNT',SUM((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT',`sales`.`sales_date` AS 'DATE' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` GROUP BY `sales`.`sales_date` ORDER BY sales_date DESC", con);

                MySqlDataReader r = com.ExecuteReader();

                while (r.Read())
                {
                    this.salesChart.Series["SALES"].Points.AddXY(r.GetDateTime("DATE"), r.GetDecimal("AMOUNT"));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { 
            
            }

        }


        public void LoadChartFilterByDate()
        {
            try
            {
                
            string date = dateDateTimePicker.Value.ToString("yyyy-MM-dd");
             
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT DISTINCT(serial) AS 'SERIAL',SUM(`sales`.`discount`) AS 'DISCOUNT', SUM(ROUND((`sales`.`quantity` *`sales`.`price`),2)) AS 'AMOUNT',SUM((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT',`sales`.`sales_date` AS 'DATE' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE sales_date='" + date + "' GROUP BY `sales`.`sales_date` ORDER BY sales_date DESC", con);

                MySqlDataReader r = com.ExecuteReader();

                while (r.Read())
                {
                    this.salesChart.Series["SALES"].Points.AddXY(r.GetDateTime("DATE"), r.GetDecimal("AMOUNT"));
                }
                con.Close();
            }
            catch (Exception)
            {
             //   MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }

        public void LoadChartFilterByDateRange()
        {
            try
            {
            string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");
            
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT DISTINCT(serial) AS 'SERIAL',SUM(`sales`.`discount`) AS 'DISCOUNT', SUM(ROUND((`sales`.`quantity` *`sales`.`price`),2)) AS 'AMOUNT',SUM((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT',`sales`.`sales_date` AS 'DATE' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE sales_date BETWEEN '" + startDate + "' AND '" + endDate + "' GROUP BY `sales`.`sales_date` ORDER BY sales_date DESC", con);

                MySqlDataReader r = com.ExecuteReader();

                while (r.Read())
                {
                    this.salesChart.Series["SALES"].Points.AddXY(r.GetDateTime("DATE"), r.GetDecimal("AMOUNT"));
                }
                con.Close();
            }
            catch (Exception)
            {
              //  MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }



        public void LoadBarChart()
        {
            decimal buyingAmount = Convert.ToDecimal(BuyingAmountTextBox.Text);
            decimal sellingAmount = Convert.ToDecimal(SellingAmountTextBox.Text);
            decimal discount = Convert.ToDecimal(discountTextBox.Text);
            decimal profit = Convert.ToDecimal(profitForChartTextBox.Text);

            this.salesBarChart.Series["SALES"].Points.AddXY("BUYING AMOUNT (" + buyingAmount + " Kshs.)", buyingAmount);

            this.salesBarChart.Series["SALES"].Points.AddXY("SELLING AMOUNT (" + sellingAmount + " Kshs.)", sellingAmount);

            this.salesBarChart.Series["SALES"].Points.AddXY("DISCOUNT (" + discount + " Kshs.)", discount);


            this.salesBarChart.Series["SALES"].Points.AddXY("PROFIT (" + profit + " Kshs.)", profit);
        }

        public void LoadPieChart()
        {
            decimal buyingAmount = Convert.ToDecimal(BuyingAmountTextBox.Text);
            decimal sellingAmount = Convert.ToDecimal(SellingAmountTextBox.Text);
            decimal discount = Convert.ToDecimal(discountTextBox.Text);
            decimal profit = Convert.ToDecimal(profitForChartTextBox.Text);

            this.salesPieChart.Series["SALES"].Points.AddXY("BUYING AMOUNT (" + buyingAmount + " Kshs.)", buyingAmount);

            this.salesPieChart.Series["SALES"].Points.AddXY("SELLING AMOUNT (" + sellingAmount + " Kshs.)", sellingAmount);

            this.salesPieChart.Series["SALES"].Points.AddXY("DISCOUNT (" + discount + " Kshs.)", discount);

            this.salesPieChart.Series["SALES"].Points.AddXY("PROFIT (" + profit + " Kshs.)", profit);
        }

        private void salesBarChart_Click(object sender, EventArgs e)
        {

        }

    }
}
