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
    public partial class CashierDrugView : Form
    {
        MySqlConnection con = null;
        public CashierDrugView()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            DrugView();
        }

        //view drugs
        public void DrugView()
        {

            try
            {
                
                MySqlCommand com = new MySqlCommand("SELECT `drug`.`name` AS 'Drug Name', `drug`.`form` AS 'Drug Form',`drug`.`price` AS 'Drug Price',`drug`.`pfno` AS 'Registered By', `drug`.`registered_date` AS 'Registered Date' FROM drug ORDER BY name ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dt = new DataTable();
                // Add autoincrement column.
                dt.Columns.Add("#", typeof(int));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["#"] };
                dt.Columns["#"].AutoIncrement = true;
                dt.Columns["#"].AutoIncrementSeed = 1;
                dt.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dt.Columns.Add("Registered Date", typeof(string));
                // End formating titles.

                a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                viewDrugdataGridView.DataSource = bs;

                a.Update(dt);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewDrugdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //print drugs spreadsheet
        public void drugExcel()
        {

            try
            {
               con.Open();
                MySqlCommand com = new MySqlCommand("SELECT  `drug`.`name` AS 'Drug Name', `drug`.`form` AS 'Drug Form',`drug`.`price` AS 'Drug Price',`drug`.`pfno` AS 'Registered By', `drug`.`registered_date` AS 'Registered Date' FROM drug ORDER BY name ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dt = new DataTable();
                // Add autoincrement column.
                dt.Columns.Add("#", typeof(string));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["#"] };
                dt.Columns["#"].AutoIncrement = true;
                dt.Columns["#"].AutoIncrementSeed = 1;
                dt.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dt.Columns.Add("Registered Date", typeof(string));
                // End formating titles.

                a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                viewDrugdataGridView.DataSource = bs;

                a.Update(dt);

                DataSet ds = new DataSet("New_DataSet");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                a.Fill(dt);
                ds.Tables.Add(dt);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\Users\\sam\\Desktop\\C#\\PHARMACY\\Reports\\DrugExcel.xls", ds);
                Process sts = System.Diagnostics.Process.Start(@"C:\\Users\\sam\\Desktop\\C#\\PHARMACY\\Reports\\DrugExcel.xls");
                sts.WaitForExit();

                string fname = "C:\\Users\\sam\\Desktop\\C#\\PHARMACY\\Reports\\DrugExcel.xls";
                Workbook workbook = new Workbook();
                Worksheet worksheet = new Worksheet("DrugExcel");
                workbook.Worksheets.Add(worksheet);

                for (int i = 0; i < 100; i++)
                    worksheet.Cells[i, 0] = new Cell("");
                workbook.Save(fname);
                con.Close();
                MessageBox.Show("excel generated successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //print pdf for drug
        public void drugPdf()
        {

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\sam\\Desktop\\C#\\PHARMACY\\Reports\\drug pdf", FileMode.Create));
            doc.Open();//open document to write

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\Users\\sam\\Desktop\\C#\\PHARMACY\\PHARMACY\\Resources\\faith2.png");
            img.ScalePercent(25f);
            img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);

            doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                 Drugs Report");
            doc.Add(p);
            Paragraph p2 = new Paragraph("                 Produced by ");
            doc.Add(p2);


            //load data from datagrid
            PdfPTable table = new PdfPTable(viewDrugdataGridView.Columns.Count);

            //add headers from the datagridview to the table
            for (int j = 0; j < viewDrugdataGridView.Columns.Count; j++)
            {

                table.AddCell(new Phrase(viewDrugdataGridView.Columns[j].HeaderText));

            }

            //flag the first row as header

            table.HeaderRows = 1;

            //add the actual rows to the table from datagridview

            for (int i = 0; i < viewDrugdataGridView.Rows.Count; i++)
            {
                for (int k = 0; k < viewDrugdataGridView.Columns.Count; k++)
                {

                    if (viewDrugdataGridView[k, i].Value != null)
                    {

                        table.AddCell(new Phrase(viewDrugdataGridView[k, i].Value.ToString()));
                    }

                }

            }

            doc.Add(table);
            //end querying from datagrid


            doc.Close();//close document after writting in

            MessageBox.Show("Drug Report generated Successful");

            System.Diagnostics.Process.Start("C:\\Users\\sam\\Desktop\\C#\\PHARMACY\\Reports\\drug pdf");

        }

        private void CashierDrugView_Load(object sender, EventArgs e)
        {

        }

        private void printDrugPdfButton_Click(object sender, EventArgs e)
        {
            drugPdf();
        }

        private void printDrugExcel_Click(object sender, EventArgs e)
        {
            drugExcel();
        }
    }
}
