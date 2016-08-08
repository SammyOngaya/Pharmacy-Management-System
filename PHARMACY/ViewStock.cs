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
    public partial class ViewStock : Form
    {
        MySqlConnection con = null;
        public ViewStock()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            viewStock();
        }

        DataTable dataTable;

        
        private void viewStockdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }



        public void viewStock()
        {

            try
            {


                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER NAME',`drug`.`name` AS 'DRUG NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`quantity` AS 'QUANTITY', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` ORDER BY `drug`.`name` ASC", con);

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
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                viewStockdataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewStockdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //print pdf for stock
        public void stockPdf()
        {
            try
            {

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\Stock pdf", FileMode.Create));
            doc.Open();//open document to write

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\PMS\\Resources\\faith2.png");
            img.ScalePercent(79f);
           // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);

            

            doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                                                Stock Report");
            doc.Add(p);
            DateTime time = DateTime.Now;

            Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "        Produced On         " + time.ToString() + "        \n\n");
            doc.Add(p2);

            //load data from datagrid
            PdfPTable table = new PdfPTable(viewStockdataGridView.Columns.Count);

            //add headers from the datagridview to the table
            for (int j = 0; j < viewStockdataGridView.Columns.Count; j++)
            {

                table.AddCell(new Phrase(viewStockdataGridView.Columns[j].HeaderText));

            }

            //flag the first row as header

            table.HeaderRows = 1;

            //add the actual rows to the table from datagridview

            for (int i = 0; i < viewStockdataGridView.Rows.Count; i++)
            {
                for (int k = 0; k < viewStockdataGridView.Columns.Count; k++)
                {

                    if (viewStockdataGridView[k, i].Value != null)
                    {

                        table.AddCell(new Phrase(viewStockdataGridView[k, i].Value.ToString()));
                    }

                }

            }

            doc.Add(table);
            //end querying from datagrid


            doc.Close();//close document after writting in

            MessageBox.Show("Stock Report generated Successful");

            System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Stock pdf");

               }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ","DOCUMENT ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            finally
            { 
            
            }

        }


        //print stock excell.
        public void stockExcell()
        {
            //sqlConnection = new MySqlConnection(databaseConnection);

            try
            {
                DataTable dtCopy = dataTable.Copy();

                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dtCopy);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\PMS\\Reports\\Stock.xls", ds);

                MessageBox.Show("Report generated successfully");
                Process sts = System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Stock.xls");
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


        private void ViewStock_Load(object sender, EventArgs e)
        {

        }

        private void stockReportPdf_Click(object sender, EventArgs e)
        {
            stockPdf();
        }

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            stockExcell();
        }


    }
}
