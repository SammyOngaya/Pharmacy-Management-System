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
    public partial class ReportSales : Form
    {
        MySqlConnection con = null;
        DataTable dataTable;
        DialogResult dialog;
        public ReportSales()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            discountView();
            salesView();
            searchDrug();
            searchSerial();
            searchStaff();
        }

        //compute amount transacted.
        public void TotalBuyingAmount()
        {
            try
            {
            double sum = 0.00;
            for (int i = 0; i < salesReportDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(salesReportDataGridView.Rows[i].Cells[8].Value);

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
                    sum += Convert.ToDouble(salesReportDataGridView.Rows[i].Cells[9].Value);

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

                discountLabel.Text = "discount  " + sum.ToString()+ " Kshs";
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
                MySqlCommand discount = new MySqlCommand("SELECT DISTINCT(`sales`.`serial`) , discount FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` ", con);

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
            string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand discount = new MySqlCommand("SELECT DISTINCT(`sales`.`serial`) , discount FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE sales_date BETWEEN '" + startDate + "' AND '" + endDate + "' ", con);

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
            String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
             string date = dateDateTimePicker.Value.ToString("yyyy-MM-dd");

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand discount = new MySqlCommand("SELECT DISTINCT(`sales`.`serial`) , discount FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE sales_date='" + date + "' ORDER BY sales_date DESC", con);

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


         public void discountViewFilterByStaff()
        {
            String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand discount = new MySqlCommand("SELECT DISTINCT(`sales`.`serial`) , discount FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE `sales`.`pfno`='" + this.staffIDTextBox.Text + "' ", con);

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

         public void discountViewFilterByDrugName()
        {
            String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand discount = new MySqlCommand("SELECT DISTINCT(`sales`.`serial`) , discount FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE `drug`.`name`='" + this.drugNameTextBox.Text + "' ", con);

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

         public void discountViewFilterBySerial()
         {
             String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";

             try
             {
                 MySqlConnection con = new MySqlConnection(db);
                 con.Open();
                 MySqlCommand discount = new MySqlCommand("SELECT DISTINCT(`sales`.`serial`) , discount FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE serial='" + this.serialNoTextBox.Text + "' ", con);

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
          


         public void discountViewFilterByDateAndStaff()
         { 
             
             string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
             string date = dateDateTimePicker.Value.ToString("yyyy-MM-dd");
             try
             {
                 MySqlConnection con = new MySqlConnection(db);
                 con.Open();
                 MySqlCommand discount = new MySqlCommand("SELECT DISTINCT(`sales`.`serial`) , discount FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE (sales_date='" + date + "' AND `sales`.`pfno`='" + this.staffIDTextBox.Text + "') ", con);

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
         

              
         public void discountViewFilterByDateRangeAndStaff()
         {
             string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";

             string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
             string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");

             try
             {
                 MySqlConnection con = new MySqlConnection(db);
                 con.Open();
                 MySqlCommand discount = new MySqlCommand("SELECT DISTINCT(`sales`.`serial`) , discount FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE ((sales_date BETWEEN '" + startDate + "' AND '" + endDate + "') AND (`sales`.`pfno`='" + this.staffIDTextBox.Text + "')) ", con);

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

      

         public void discountViewFilterByDateAndDrug()
         {
             string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";

             string date = dateDateTimePicker.Value.ToString("yyyy-MM-dd");

             try
             {
                 MySqlConnection con = new MySqlConnection(db);
                 con.Open();
                 MySqlCommand discount = new MySqlCommand("SELECT DISTINCT(`sales`.`serial`) , discount FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE (sales_date='" + date + "' AND `drug`.`name`='" + this.drugNameTextBox.Text + "') ", con);

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


         

         public void discountViewFilterByDateRangeAndDrug()
         {
             string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";

             string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
             string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");

             try
             {
                 MySqlConnection con = new MySqlConnection(db);
                 con.Open();
                 MySqlCommand discount = new MySqlCommand("SELECT DISTINCT(`sales`.`serial`) , discount FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE ((sales_date BETWEEN '" + startDate + "' AND '" + endDate + "') AND (`drug`.`name`='" + this.drugNameTextBox.Text + "')) ", con);

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

        //search drug from sales
        public void searchDrug()
        {
            drugNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            drugNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {
                con.Open();

                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand c = new MySqlCommand("SELECT `drug`.`name` AS 'name' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` GROUP BY `sales`.`stock_id` ORDER BY `drug`.`name` ASC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    String name = r.GetString("name");
                    collection.Add(name);

                }
                con.Close();
            }
            catch (Exception) { 
            }
            drugNameTextBox.AutoCompleteCustomSource = collection;

        }

        //search staff from sales
        public void searchStaff()
        {
            staffIDTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            staffIDTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {
                con.Open();


                MySqlCommand c = new MySqlCommand("SELECT pfno AS 'pfno' FROM `sales`  ORDER BY pfno ASC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    String name = r.GetString("pfno");
                    collection.Add(name);

                }
                con.Close();
            }
            catch (Exception)
            {
            }
            staffIDTextBox.AutoCompleteCustomSource = collection;

        }

        //search serial from sales
        public void searchSerial()
        {
            serialNoTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            serialNoTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT serial FROM `sales`  ORDER BY serial ASC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    String serial = r.GetString("serial");
                    collection.Add(serial);

                }
                con.Close();
            }
            catch (Exception)
            {
            }
            serialNoTextBox.AutoCompleteCustomSource = collection;

        }

       

        public void salesView()
        {

            try
            {

                MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'SALE ID',`sales`.`stock_id` AS 'STOCK ID',`stock`.`batch_no` AS 'BATCH NO.', `drug`.`name` AS 'DRUG NAME',`sales`.`quantity` AS 'QUANTITY',`stock`.`buying_price` AS 'BUYING PRICE',`sales`.`price` AS 'SELLING PRICE',ROUND((`sales`.`quantity` *`stock`.`buying_price`),2) AS 'BUYING AMOUNT',ROUND((`sales`.`quantity` *`sales`.`price`),2) AS 'SELLING AMOUNT',((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT', `sales`.`pfno` AS 'SERVED BY',sales_date AS 'DATE SOLD',`stock`.`units` AS 'UNITS', serial AS 'RECEIPT NUMBER',`supplier`.`name` AS 'SUPPLIER',`stock`.`expiry_date` AS 'EXPIRY DATE' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` ORDER BY sales_date DESC", con);

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
                dataTable.Columns.Add("SALE ID", typeof(string));
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NO.");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("RECEIPT NUMBER");
                dataTable.Columns.Add("DATE SOLD", typeof(string));
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("SUPPLIER");
                dataTable.Columns.Add("SERVED BY");
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

                MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'SALE ID',`sales`.`stock_id` AS 'STOCK ID',`stock`.`batch_no` AS 'BATCH NO.', `drug`.`name` AS 'DRUG NAME',`sales`.`quantity` AS 'QUANTITY',`stock`.`buying_price` AS 'BUYING PRICE',`sales`.`price` AS 'SELLING PRICE',ROUND((`sales`.`quantity` *`stock`.`buying_price`),2) AS 'BUYING AMOUNT',ROUND((`sales`.`quantity` *`sales`.`price`),2) AS 'SELLING AMOUNT',((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT', `sales`.`pfno` AS 'SERVED BY',sales_date AS 'DATE SOLD',`stock`.`units` AS 'UNITS', serial AS 'RECEIPT NUMBER',`supplier`.`name` AS 'SUPPLIER',`stock`.`expiry_date` AS 'EXPIRY DATE' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE sales_date='" + date + "' ORDER BY sales_date DESC", con);

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
                dataTable.Columns.Add("SALE ID", typeof(string));
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NO.");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("RECEIPT NUMBER");
                dataTable.Columns.Add("DATE SOLD", typeof(string));
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("SUPPLIER");
                dataTable.Columns.Add("SERVED BY");
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

        // Filter by date and staff.
        public void salesViewFilterByDateAndStaff()
        {
            string date = dateDateTimePicker.Value.ToString("yyyy-MM-dd");
            try
            {

                MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'SALE ID',`sales`.`stock_id` AS 'STOCK ID',`stock`.`batch_no` AS 'BATCH NO.', `drug`.`name` AS 'DRUG NAME',`sales`.`quantity` AS 'QUANTITY',`stock`.`buying_price` AS 'BUYING PRICE',`sales`.`price` AS 'SELLING PRICE',ROUND((`sales`.`quantity` *`stock`.`buying_price`),2) AS 'BUYING AMOUNT',ROUND((`sales`.`quantity` *`sales`.`price`),2) AS 'SELLING AMOUNT',((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT', `sales`.`pfno` AS 'SERVED BY',sales_date AS 'DATE SOLD',`stock`.`units` AS 'UNITS', serial AS 'RECEIPT NUMBER',`supplier`.`name` AS 'SUPPLIER',`stock`.`expiry_date` AS 'EXPIRY DATE' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE (sales_date='" + date + "' AND `sales`.`pfno`='" + this.staffIDTextBox.Text + "') ORDER BY sales_date DESC", con);

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
                dataTable.Columns.Add("SALE ID", typeof(string));
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NO.");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("RECEIPT NUMBER");
                dataTable.Columns.Add("DATE SOLD", typeof(string));
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("SUPPLIER");
                dataTable.Columns.Add("SERVED BY");
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

        // Filter by date and drug.
        public void salesViewFilterByDateAndDrug()
        {
            string date = dateDateTimePicker.Value.ToString("yyyy-MM-dd");
            try
            {

                MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'SALE ID',`sales`.`stock_id` AS 'STOCK ID',`stock`.`batch_no` AS 'BATCH NO.', `drug`.`name` AS 'DRUG NAME',`sales`.`quantity` AS 'QUANTITY',`stock`.`buying_price` AS 'BUYING PRICE',`sales`.`price` AS 'SELLING PRICE',ROUND((`sales`.`quantity` *`stock`.`buying_price`),2) AS 'BUYING AMOUNT',ROUND((`sales`.`quantity` *`sales`.`price`),2) AS 'SELLING AMOUNT',((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT', `sales`.`pfno` AS 'SERVED BY',sales_date AS 'DATE SOLD',`stock`.`units` AS 'UNITS', serial AS 'RECEIPT NUMBER',`supplier`.`name` AS 'SUPPLIER',`stock`.`expiry_date` AS 'EXPIRY DATE' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE (sales_date='" + date + "' AND `drug`.`name`='" + this.drugNameTextBox.Text + "') ORDER BY sales_date DESC", con);

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
                dataTable.Columns.Add("SALE ID", typeof(string));
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NO.");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("RECEIPT NUMBER");
                dataTable.Columns.Add("DATE SOLD", typeof(string));
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("SUPPLIER");
                dataTable.Columns.Add("SERVED BY");
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

                MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'SALE ID',`sales`.`stock_id` AS 'STOCK ID',`stock`.`batch_no` AS 'BATCH NO.', `drug`.`name` AS 'DRUG NAME',`sales`.`quantity` AS 'QUANTITY',`stock`.`buying_price` AS 'BUYING PRICE',`sales`.`price` AS 'SELLING PRICE',ROUND((`sales`.`quantity` *`stock`.`buying_price`),2) AS 'BUYING AMOUNT',ROUND((`sales`.`quantity` *`sales`.`price`),2) AS 'SELLING AMOUNT',((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT', `sales`.`pfno` AS 'SERVED BY',sales_date AS 'DATE SOLD',`stock`.`units` AS 'UNITS', serial AS 'RECEIPT NUMBER',`supplier`.`name` AS 'SUPPLIER',`stock`.`expiry_date` AS 'EXPIRY DATE' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE sales_date BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY sales_date DESC", con);

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
                dataTable.Columns.Add("SALE ID", typeof(string));
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NO.");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("RECEIPT NUMBER");
                dataTable.Columns.Add("DATE SOLD", typeof(string));
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("SUPPLIER");
                dataTable.Columns.Add("SERVED BY");
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

        // Fliter by date range and staff.
        public void salesViewFilterByDateRangeAndStaff()
        {
            string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");
            try
            {

                MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'SALE ID',`sales`.`stock_id` AS 'STOCK ID',`stock`.`batch_no` AS 'BATCH NO.', `drug`.`name` AS 'DRUG NAME',`sales`.`quantity` AS 'QUANTITY',`stock`.`buying_price` AS 'BUYING PRICE',`sales`.`price` AS 'SELLING PRICE',ROUND((`sales`.`quantity` *`stock`.`buying_price`),2) AS 'BUYING AMOUNT',ROUND((`sales`.`quantity` *`sales`.`price`),2) AS 'SELLING AMOUNT',((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT', `sales`.`pfno` AS 'SERVED BY',sales_date AS 'DATE SOLD',`stock`.`units` AS 'UNITS', serial AS 'RECEIPT NUMBER',`supplier`.`name` AS 'SUPPLIER',`stock`.`expiry_date` AS 'EXPIRY DATE' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE ((sales_date BETWEEN '" + startDate + "' AND '" + endDate + "') AND (`sales`.`pfno`='" + this.staffIDTextBox.Text + "')) ORDER BY sales_date DESC", con);

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
                dataTable.Columns.Add("SALE ID", typeof(string));
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NO.");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("RECEIPT NUMBER");
                dataTable.Columns.Add("DATE SOLD", typeof(string));
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("SUPPLIER");
                dataTable.Columns.Add("SERVED BY");
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

        // Fliter by date range and drug.
        public void salesViewFilterByDateRangeAndDrug()
        {
            string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");
            try
            {

                MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'SALE ID',`sales`.`stock_id` AS 'STOCK ID',`stock`.`batch_no` AS 'BATCH NO.', `drug`.`name` AS 'DRUG NAME',`sales`.`quantity` AS 'QUANTITY',`stock`.`buying_price` AS 'BUYING PRICE',`sales`.`price` AS 'SELLING PRICE',ROUND((`sales`.`quantity` *`stock`.`buying_price`),2) AS 'BUYING AMOUNT',ROUND((`sales`.`quantity` *`sales`.`price`),2) AS 'SELLING AMOUNT',((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT', `sales`.`pfno` AS 'SERVED BY',sales_date AS 'DATE SOLD',`stock`.`units` AS 'UNITS', serial AS 'RECEIPT NUMBER',`supplier`.`name` AS 'SUPPLIER',`stock`.`expiry_date` AS 'EXPIRY DATE' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE ((sales_date BETWEEN '" + startDate + "' AND '" + endDate + "') AND (`drug`.`name`='" + this.drugNameTextBox.Text + "')) ORDER BY sales_date DESC", con);

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
                dataTable.Columns.Add("SALE ID", typeof(string));
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NO.");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("RECEIPT NUMBER");
                dataTable.Columns.Add("DATE SOLD", typeof(string));
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("SUPPLIER");
                dataTable.Columns.Add("SERVED BY");
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

        // Filter by serial number.
        public void salesViewFilterBySerial()
        {
           try
            {

                MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'SALE ID',`sales`.`stock_id` AS 'STOCK ID',`stock`.`batch_no` AS 'BATCH NO.', `drug`.`name` AS 'DRUG NAME',`sales`.`quantity` AS 'QUANTITY',`stock`.`buying_price` AS 'BUYING PRICE',`sales`.`price` AS 'SELLING PRICE',ROUND((`sales`.`quantity` *`stock`.`buying_price`),2) AS 'BUYING AMOUNT',ROUND((`sales`.`quantity` *`sales`.`price`),2) AS 'SELLING AMOUNT',((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT', `sales`.`pfno` AS 'SERVED BY',sales_date AS 'DATE SOLD',`stock`.`units` AS 'UNITS', serial AS 'RECEIPT NUMBER',`supplier`.`name` AS 'SUPPLIER',`stock`.`expiry_date` AS 'EXPIRY DATE' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE serial='" + this.serialNoTextBox.Text + "' ORDER BY sales_date DESC", con);

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
                dataTable.Columns.Add("SALE ID", typeof(string));
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NO.");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("RECEIPT NUMBER");
                dataTable.Columns.Add("DATE SOLD", typeof(string));
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("SUPPLIER");
                dataTable.Columns.Add("SERVED BY");
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

        // Filter by staff id.
        public void salesViewFilterByStaff()
        {
            try
            {

                MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'SALE ID',`sales`.`stock_id` AS 'STOCK ID',`stock`.`batch_no` AS 'BATCH NO.', `drug`.`name` AS 'DRUG NAME',`sales`.`quantity` AS 'QUANTITY',`stock`.`buying_price` AS 'BUYING PRICE',`sales`.`price` AS 'SELLING PRICE',ROUND((`sales`.`quantity` *`stock`.`buying_price`),2) AS 'BUYING AMOUNT',ROUND((`sales`.`quantity` *`sales`.`price`),2) AS 'SELLING AMOUNT',((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT', `sales`.`pfno` AS 'SERVED BY',sales_date AS 'DATE SOLD',`stock`.`units` AS 'UNITS', serial AS 'RECEIPT NUMBER',`supplier`.`name` AS 'SUPPLIER',`stock`.`expiry_date` AS 'EXPIRY DATE' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE `sales`.`pfno`='" + this.staffIDTextBox.Text + "' ORDER BY sales_date DESC", con);

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
                dataTable.Columns.Add("SALE ID", typeof(string));
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NO.");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("RECEIPT NUMBER");
                dataTable.Columns.Add("DATE SOLD", typeof(string));
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("SUPPLIER");
                dataTable.Columns.Add("SERVED BY");
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

        // // Filter by drug name.
        public void salesViewFilterByDrugName()
        {
            try
            {

                MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'SALE ID',`sales`.`stock_id` AS 'STOCK ID',`stock`.`batch_no` AS 'BATCH NO.', `drug`.`name` AS 'DRUG NAME',`sales`.`quantity` AS 'QUANTITY',`stock`.`buying_price` AS 'BUYING PRICE',`sales`.`price` AS 'SELLING PRICE',ROUND((`sales`.`quantity` *`stock`.`buying_price`),2) AS 'BUYING AMOUNT',ROUND((`sales`.`quantity` *`sales`.`price`),2) AS 'SELLING AMOUNT',((ROUND((`sales`.`quantity` *`sales`.`price`),2))-(ROUND((`sales`.`quantity` *`stock`.`buying_price`),2))) AS 'PROFIT', `sales`.`pfno` AS 'SERVED BY',sales_date AS 'DATE SOLD',`stock`.`units` AS 'UNITS', serial AS 'RECEIPT NUMBER',`supplier`.`name` AS 'SUPPLIER',`stock`.`expiry_date` AS 'EXPIRY DATE' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` JOIN supplier ON `supplier`.`id`=`stock`.`supplier_id` JOIN sales ON `sales`.`stock_id`=`stock`.`stock_id` WHERE `drug`.`name`='" + this.drugNameTextBox.Text + "' ORDER BY sales_date DESC", con);

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
                dataTable.Columns.Add("SALE ID", typeof(string));
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NO.");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("RECEIPT NUMBER");
                dataTable.Columns.Add("DATE SOLD", typeof(string));
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("SUPPLIER");
                dataTable.Columns.Add("SERVED BY");
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
        private void ReportSales_Load(object sender, EventArgs e)
        {

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
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\PMS\\Reports\\log.xls", ds);

                MessageBox.Show("Report generated successfully...............!", "SALES REPORT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process sts = System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Sales.xls");
                sts.WaitForExit();


            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while generating system sales report ............!", "SALES REPORT GENERATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }


        //print sales report.

        public void salesPdf()
        {
            try
            {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\Sales.pdf", FileMode.Create));
            doc.Open();//open document to write

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\PMS\\Resources\\faith2.png");
            img.ScalePercent(79f);
            /// img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);

            doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                                                sales report");
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

            MessageBox.Show("Report generated successfully...............!", "SALES REPORT", MessageBoxButtons.OK, MessageBoxIcon.Information);

            System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Sales.pdf");

               }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ","DOCUMENT ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            finally
            { 
            
            }

        }


        private void dateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            discountViewFilterByDate();
            salesViewFilterByDate();
            
        }

        private void searchDate_Click(object sender, EventArgs e)
        {
            discountViewFilterByDate();
            salesViewFilterByDate();
           
        }

        private void endDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            discountViewFilterByDateRange();
            salesViewFilterByDateRange();
           
        }

        private void searchByDate_Click(object sender, EventArgs e)
        {
            discountViewFilterByDateRange();
            salesViewFilterByDateRange();
           
        }

        private void serialNoTextBox_TextChanged(object sender, EventArgs e)
        {
            //searchSerial();
            discountViewFilterBySerial();
            salesViewFilterBySerial();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            searchSerial();
            discountViewFilterBySerial();
            salesViewFilterBySerial();
            
        }

        private void staffIDTextBox_TextChanged(object sender, EventArgs e)
        {
            //searchStaff();
            discountViewFilterByStaff();
            salesViewFilterByStaff();
            
        }

        private void searchByDriverID_Click(object sender, EventArgs e)
        {
            searchStaff();
            discountViewFilterByStaff();
            salesViewFilterByStaff();
            
        }

        private void drugNameTextBox_TextChanged(object sender, EventArgs e)
        {
            //searchDrug();
            discountViewFilterByDrugName();
            salesViewFilterByDrugName();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            searchDrug();
            discountViewFilterByDrugName();
            salesViewFilterByDrugName();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            discountViewFilterByDateAndStaff();
            salesViewFilterByDateAndStaff();
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            discountViewFilterByDateAndDrug();
            salesViewFilterByDateAndDrug();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            discountViewFilterByDateRangeAndStaff();
            salesViewFilterByDateRangeAndStaff();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            discountViewFilterByDateRangeAndDrug();
            salesViewFilterByDateRangeAndDrug();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            salesPdf();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            salesExcel();
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {


                if (salesReportDataGridView.SelectedRows.Count > 0)
                {
                    int selectedIndex = salesReportDataGridView.SelectedRows[0].Index;
                    string debtorString = (salesReportDataGridView[12, selectedIndex].Value.ToString());


                    if (debtorString=="DEBTOR")
                    {
                        MessageBox.Show("YOU CAN NOT REVERSE THE SELECTED DRUG. PLEASE CHECK IF THE DRUG WAS TAKEN BY THE DEBTOR. ELSE YOU CAN CLOSE THE APPLICATION AND TRY AGAIN THE PROCESS", "DRUG REVERSAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        queryNetStockValue();
                        dialog = MessageBox.Show(" Are you sure you want to return drug back to stock?", "RETURN DRUG TO STOCK", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialog == DialogResult.Yes)
                        {
                            updateNetStock();
                        }
                    }

                }
                else {
                    MessageBox.Show("NO DRUG SELECTED. PLEASE SELECT THE DRUG TO PROCEED.", "NO DRUG SELECTED", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                MessageBox.Show("NO DRUG SELECTED. PLEASE SELECT THE DRUG TO PROCEED.", "NO DRUG SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Question);
            
            }
            finally 
            { 
            
            }
        }

        public void removeFromSales()
        {

            try
            {

                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                if (salesReportDataGridView.SelectedRows.Count > 0)
                {

                    int selectedIndex = salesReportDataGridView.SelectedRows[0].Index;
                    long RowID = int.Parse(salesReportDataGridView[1, selectedIndex].Value.ToString());

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM sales WHERE sales_id = " + RowID + "", con);
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("sales id is : " + salesReportDataGridView[2, selectedIndex].Value.ToString());
                    con.Close();

                    MessageBox.Show("Stock Updated Successfully", "STOCK UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     reverseQuantityTextBox.Text = string.Empty;
                     reverseInitialQuantityTextBox.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("No Drug selected", "NO DRUG SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has occured!" + ex.Message);
            }
            finally
            {
                discountView();
                salesView();
            }
        }

        //update net stock
        public void updateNetStock()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

             if (salesReportDataGridView.SelectedRows.Count > 0)
                {

            try
            {
                    decimal netStockQuantity = Convert.ToDecimal(reverseQuantityTextBox.Text);
                    decimal netStockInitialQuantity = Convert.ToDecimal(reverseInitialQuantityTextBox.Text);

                      int selectedIndex = salesReportDataGridView.SelectedRows[0].Index;
                      long RowID = long.Parse(salesReportDataGridView[2, selectedIndex].Value.ToString());
                      decimal qty = Convert.ToDecimal(salesReportDataGridView[5, selectedIndex].Value.ToString());
                      

                     if ((netStockQuantity + qty) <= netStockInitialQuantity)
                     {
                          con.Open();
                          MySqlCommand mc = new MySqlCommand("UPDATE stock set quantity_sold=(quantity_sold - " + qty + "), status='1' WHERE stock_id= " + RowID + " ", con);
                          mc.ExecuteNonQuery();
                          con.Close();

                          removeFromSales();
                      }
                      else
                      {
                          MessageBox.Show("The drug seems not to exist from the system", "NO DRUG MATCH FOUND", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      }

            }
            catch (Exception )
            {
                MessageBox.Show("ERROR HAS OCCURED DURING THE UPDATE OF STOCK","STOCK UPDATE ERROR",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
                }
             else
             {
                 MessageBox.Show("No Drug selected", "NO DRUG SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
        }


        // Retrieves net stock value first.
        public void queryNetStockValue()
        {
            if (salesReportDataGridView.SelectedRows.Count > 0)
                {

            try
            {
               

                    int selectedIndex = salesReportDataGridView.SelectedRows[0].Index;
                    int RowID = int.Parse(salesReportDataGridView[2, selectedIndex].Value.ToString());


                   con.Open();
                    // Select drug from net stock to view the quantity first.
                    MySqlCommand queryNetStock = new MySqlCommand("SELECT (`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'remaining_quantity', initial_quantity FROM stock WHERE (stock_id='" + RowID + "') ", con);
                    MySqlDataReader mr = queryNetStock.ExecuteReader();
                    while (mr.Read())
                    {

                        string quantity = mr.GetString("remaining_quantity");
                        string initial_quantity = mr.GetString("initial_quantity");
                        //string debtor = mr.GetString("debtor");

                        reverseQuantityTextBox.Text = quantity;
                        reverseInitialQuantityTextBox.Text = initial_quantity;
                       // serialAsDebtorTextBox.Text = debtor;
                    }

                    //mr.Close();
                    con.Close();
               }
            catch (Exception )
            {
               MessageBox.Show("YOU CAN NOT REVERSE THE SELECTED DRUG. PLEASE CHECK IF THE DRUG WAS TAKEN BY THE DEBTOR. ELSE YOU CAN CLOSE THE APPLICATION AND TRY AGAIN THE PROCESS","DRUG REVERSAL ERROR",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            finally
            {
                //
            }

                }
             else
             {
                 MessageBox.Show("No Drug selected", "NO DRUG SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            salesView();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ChartSales cs = new ChartSales(BuyingAmountTextBox.Text, SellingAmountTextBox.Text, discountTextBox.Text, profitForChartTextBox.Text);
            cs.ShowDialog();
        }

    }
}
