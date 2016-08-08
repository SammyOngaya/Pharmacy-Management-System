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
using System.Diagnostics;

namespace PHARMACY
{
    public partial class CashierViewNetStock : Form
    {
        MySqlConnection con = null;
        public CashierViewNetStock()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            searchDrug();
            netStockView();
        }

        private void CashierViewNetStock_Load(object sender, EventArgs e)
        {

        }


        DataTable dataTable;


        // Search drug.
        public void searchDrug()
        {
            searchDrugTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchDrugTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            try
            {
                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");

                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `drug`.`name` AS 'drug_name' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` WHERE ((`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0) AND (`stock`.`status`='1')) GROUP BY `stock`.`drug_id` ORDER BY `drug`.`name` ASC", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String name = reader.GetString("drug_name");
                    collection.Add(name);
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while searching drug details............!", "DRUG DETAILS SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

            searchDrugTextBox.AutoCompleteCustomSource = collection;

        }// End search drug.


        public void searchNetStockView()
        {

            try
            {
                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`drug`.`name` AS 'DRUG NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`)) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`)) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`))-(`stock`.`buying_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE ((`stock`.`status`=1) AND ( `drug`.`name`='" + this.searchDrugTextBox.Text + "') AND  (`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0) ) ORDER BY `drug`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(int));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                viewNetStockdataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewNetStockdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void netStockView()
        {


            try
            {
                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`drug`.`name` AS 'DRUG NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`)) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`)) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`))-(`stock`.`buying_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE ((`stock`.`status`=1) AND (`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0))  ORDER BY `drug`.`name` ASC", con);
                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(int));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                viewNetStockdataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewNetStockdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }




        //print pdf for net stock
        public void netStockPdf()
        {
            try
            {

                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
                PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\NET STOCK", FileMode.Create));
                doc.Open();//open document to write

                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\PMS\\Resources\\faith2.png");
                img.ScalePercent(79f);
                // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);



                doc.Add(img); //add image to document
                Paragraph p = new Paragraph("                                                               Net Stock Report");
                doc.Add(p);
                DateTime time = DateTime.Now;

                Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "        Produced On         " + time.ToString() + "        \n\n");
                doc.Add(p2);


                //load data from datagrid
                PdfPTable table = new PdfPTable(viewNetStockdataGridView.Columns.Count);

                //add headers from the datagridview to the table
                for (int j = 0; j < viewNetStockdataGridView.Columns.Count; j++)
                {

                    table.AddCell(new Phrase(viewNetStockdataGridView.Columns[j].HeaderText));

                }

                //flag the first row as header

                table.HeaderRows = 1;

                //add the actual rows to the table from datagridview

                for (int i = 0; i < viewNetStockdataGridView.Rows.Count; i++)
                {
                    for (int k = 0; k < viewNetStockdataGridView.Columns.Count; k++)
                    {

                        if (viewNetStockdataGridView[k, i].Value != null)
                        {

                            table.AddCell(new Phrase(viewNetStockdataGridView[k, i].Value.ToString()));
                        }

                    }

                }

                doc.Add(table);
                //end querying from datagrid


                doc.Close();//close document after writting in

                MessageBox.Show("Net Stock Report generated Successful");

                System.Diagnostics.Process.Start("C:\\PMS\\Reports\\NET STOCK");
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ","DOCUMENT ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            finally
            { 
            
            }

        }

        //print net stock excel.
        public void netStockExcel()
        {
            //sqlConnection = new MySqlConnection(databaseConnection);

            try
            {
                DataTable dtCopy = dataTable.Copy();

                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dtCopy);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\PMS\\Reports\\NET STOCK.xls", ds);

                MessageBox.Show("Report generated successfully");
                Process sts = System.Diagnostics.Process.Start("C:\\PMS\\Reports\\NET STOCK.xls");
                sts.WaitForExit();

                // sqlConnection.Close();


            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ", "DOCUMENT ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

            }

        }

        private void searchDrugTextBox_TextChanged(object sender, EventArgs e)
        {
            searchNetStockView();
        }

        private void searchSupplierPriceListButton_Click(object sender, EventArgs e)
        {
            searchNetStockView();
        }

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            netStockExcel();
        }

        private void netStockPdfReport_Click(object sender, EventArgs e)
        {
            netStockPdf();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            netStockView();
        }
    }
}
