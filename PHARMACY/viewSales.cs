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
using PHARMACY.PrintingControl;

namespace PHARMACY
{
    public partial class viewSales : Form
    {
        //MySqlConnection con = null;
        public viewSales()
        {
            InitializeComponent();
           // con = DBHandler.CreateConnection();
           
            salesView();
            dailyTotal();
           
        }

        DataTable dataTable;
        String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";

        // Compute daily totals.
        public void dailyTotal()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                String dateNow = salesDateTimePicker.Value.ToString("yyyy-MM-dd");

                MySqlCommand mc = new MySqlCommand("SELECT SUM(quantity*price) AS 'total' FROM sales WHERE sales_date='"+dateNow+"' ", con);
                MySqlDataReader reader = mc.ExecuteReader();

                while(reader.Read()){
                    string total = reader.GetString("total");
                    dailyTotalLabel.Text = total + "  Kshs.";
                }

                con.Close();

            }
            catch (Exception)
            {
                
            }

        }

        // Filter by date.
        public void salesViewFilterByDate()
        {
            string date = salesDateTimePicker.Value.ToString("yyyy-MM-dd");
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'SALE ID', `drug`.`name` AS 'DRUG NAME',quantity AS 'QUANTITY',`sales`.`buying_price` AS 'BUYING PRICE',`sales`.`price` AS 'SELLING PRICE',ROUND((`sales`.`quantity` *`sales`.`buying_price`),2) AS 'BUYING AMOUNT',ROUND((`sales`.`quantity` *`sales`.`price`),2) AS 'SELLING AMOUNT', `sales`.`pfno` AS 'SERVED BY',sales_date AS 'DATE SOLD',unit AS 'UNITS', serial AS 'RECEIPT NUMBER' FROM drug JOIN sales ON `drug`.`id`=`sales`.`drug_id` WHERE sales_date='" + date + "' ORDER BY sales_date DESC", con);

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
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("AMOUNT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("RECEIPT NUMBER");
                dataTable.Columns.Add("DATE SOLD", typeof(string));
                dataTable.Columns.Add("SERVED BY");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                viewSalesdataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewSalesdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dailyTotal();
        }

        public void salesView()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'SALE ID', `drug`.`name` AS 'DRUG NAME',quantity AS 'QUANTITY',`sales`.`buying_price` AS 'BUYING PRICE',`sales`.`price` AS 'SELLING PRICE',ROUND((`sales`.`quantity` *`sales`.`buying_price`),2) AS 'BUYING AMOUNT',ROUND((`sales`.`quantity` *`sales`.`price`),2) AS 'SELLING AMOUNT', `sales`.`pfno` AS 'SERVED BY',sales_date AS 'DATE SOLD',unit AS 'UNITS', serial AS 'RECEIPT NUMBER' FROM drug JOIN sales ON `drug`.`id`=`sales`.`drug_id` ORDER BY sales_date DESC", con);

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
                 dataTable.Columns.Add("DRUG NAME");
                 dataTable.Columns.Add("QUANTITY");
                 dataTable.Columns.Add("BUYING PRICE");
                 dataTable.Columns.Add("SELLING PRICE");
                 dataTable.Columns.Add("BUYING AMOUNT");
                 dataTable.Columns.Add("SELLING AMOUNT");
                 dataTable.Columns.Add("UNITS");
                 dataTable.Columns.Add("RECEIPT NUMBER");
                 dataTable.Columns.Add("DATE SOLD", typeof(string));
                 dataTable.Columns.Add("SERVED BY");
               // End formating titles.
                
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                viewSalesdataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewSalesdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //print pdf for sales
        public void nsalesPdf()
        {

            try
            {

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\Sales pdf", FileMode.Create));
            doc.Open();//open document to write

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\PMS\\Resources\\faith2.png");
            img.ScalePercent(79f);
            // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);



            doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                                                Sales Report");
            doc.Add(p);
            DateTime time = DateTime.Now;

            Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "        Produced On         " + time.ToString() + "        \n\n");
            doc.Add(p2);


            //load data from datagrid
            PdfPTable table = new PdfPTable(viewSalesdataGridView.Columns.Count);

            //add headers from the datagridview to the table
            for (int j = 0; j < viewSalesdataGridView.Columns.Count; j++)
            {

                table.AddCell(new Phrase(viewSalesdataGridView.Columns[j].HeaderText));

            }

            //flag the first row as header

            table.HeaderRows = 1;

            //add the actual rows to the table from datagridview

            for (int i = 0; i < viewSalesdataGridView.Rows.Count; i++)
            {
                for (int k = 0; k < viewSalesdataGridView.Columns.Count; k++)
                {

                    if (viewSalesdataGridView[k, i].Value != null)
                    {

                        table.AddCell(new Phrase(viewSalesdataGridView[k, i].Value.ToString()));
                    }

                }

            }

            doc.Add(table);
            //end querying from datagrid


            doc.Close();//close document after writting in

            MessageBox.Show("Sales Report generated Successful");

            System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Sales pdf");

               }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ","DOCUMENT ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            finally
            { 
            
            }

        }

        //print sales excel.
        public void salesExcel()
        {
            //sqlConnection = new MySqlConnection(databaseConnection);

            try
            {
                DataTable dtCopy = dataTable.Copy();

                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dtCopy);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\PMS\\Reports\\Sales.xls", ds);

                MessageBox.Show("Report generated successfully");
                Process sts = System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Sales.xls");
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

        private void viewSales_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           nsalesPdf();
            
           // printSales printSales = new printSales();
           // printSales.printReport(sender, e);
        }

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            salesExcel();
        }

        private void salesDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            salesViewFilterByDate();
        }
    }
}
