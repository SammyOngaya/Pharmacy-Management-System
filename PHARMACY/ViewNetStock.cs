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
    public partial class ViewNetStock : Form
    {
        MySqlConnection con = null;
        public ViewNetStock()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
             searchDrug();
            netStockView();
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
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `drug`.`name` AS 'name' FROM `drug` JOIN `net_stock` ON `drug`.`id`=`net_stock`.`drug_id`  GROUP BY `net_stock`.`id` ORDER BY `drug`.`name` ASC", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String name = reader.GetString("name");
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
            DateTime dtt = DateTime.Now;
            String dateNow = dtt.ToString("yyyy-MM-dd");
            try
            {

                MySqlCommand com = new MySqlCommand("SELECT `drug`.`name` AS 'DRUG NAME', initial_quantity AS 'ORIGINAL QUANTITY', quantity AS 'REMAINING QUANTITY',(initial_quantity-quantity) AS 'QUANTITY SOLD' , `net_stock`.`pfno` AS 'REGISTERED BY',units AS 'UNITS', expiry_date AS 'EXPIRY DATE', DATEDIFF(expiry_date,'" + dateNow + "') AS 'DAYS REMAINING' FROM drug JOIN net_stock ON `drug`.`id`=`net_stock`.`drug_id` WHERE `drug`.`name`='" + this.searchDrugTextBox.Text + "' AND (DATEDIFF(`net_stock`.`expiry_date`,'" + dateNow + "') >=0) ORDER BY `drug`.`name` ASC", con);

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
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                dataTable.Columns.Add("DAYS REMAINING");
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

                MySqlCommand com = new MySqlCommand("SELECT `drug`.`name` AS 'DRUG NAME', initial_quantity AS 'ORIGINAL QUANTITY', quantity AS 'REMAINING QUANTITY',(initial_quantity-quantity) AS 'QUANTITY SOLD' , `drug`.`price` AS 'SELLING PRICE', `drug`.`buying_price` AS 'BUYING PRICE',(`drug`.`buying_price`*`net_stock`.`quantity`) AS 'BUYING AMOUNT',(`drug`.`price`*`net_stock`.`quantity`) AS 'SELLING AMOUNT',`net_stock`.`pfno` AS 'REGISTERED BY',units AS 'UNITS', expiry_date AS 'EXPIRY DATE', DATEDIFF(expiry_date,'" + dateNow + "') AS 'DAYS REMAINING' FROM drug JOIN net_stock ON `drug`.`id`=`net_stock`.`drug_id` WHERE  (DATEDIFF(expiry_date,'" + dateNow + "') >= 0) ORDER BY `drug`.`name` ASC", con);

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
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DAYS REMAINING");
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
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\Net Stock pdf", FileMode.Create));
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

            System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Net Stock pdf");

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
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\PMS\\Reports\\Net Stock.xls", ds);

                MessageBox.Show("Report generated successfully");
                Process sts = System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Net Stock.xls");
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


        private void ViewNetStock_Load(object sender, EventArgs e)
        {

        }

        private void netStockPdfReport_Click(object sender, EventArgs e)
        {
            netStockPdf();
        }

        private void viewNetStockdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            netStockExcel();
        }

        private void searchDrugTextBox_TextChanged(object sender, EventArgs e)
        {
            searchNetStockView();
        }

        private void searchSupplierPriceListButton_Click(object sender, EventArgs e)
        {
            searchNetStockView();
        }
    }
}
