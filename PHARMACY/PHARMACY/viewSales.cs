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
        public viewSales()
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            salesView();
        }

        DataTable dataTable;

        public void salesView()
        {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'SALE ID', drug_name AS 'DRUG NAME',quantity AS 'QUANTITY',price AS 'PRICE', pfno AS 'SERVED BY',sales_date AS 'DATE SOLD',unit AS 'UNITS', serial AS 'RECEIPT NUMBER' FROM sales ORDER BY sales_date DESC", con);

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
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                viewSalesdataGridView.DataSource = bs;

                a.Update(dataTable);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void viewSales_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //nsalesPdf();
            printSales printSales = new printSales();
            printSales.printReport(sender, e);
        }

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            salesExcel();
        }
    }
}
