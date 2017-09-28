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
    public partial class ViewDrug : Form
    {
        public ViewDrug()
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            DrugView();
        }

        DataTable dataTable;

        private void viewDrugdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //view drugs
        public void DrugView()
        {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                MySqlCommand com = new MySqlCommand("SELECT `drug`.`id` AS 'Drug Id', `drug`.`name` AS 'Drug Name', `drug`.`form` AS 'Drug Form',`drug`.`price` AS 'Drug Price',`drug`.`pfno` AS 'Registered By', `drug`.`registered_date` AS 'Registered Date' FROM drug ORDER BY name ASC", con);

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
                viewDrugdataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewDrugdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       
        //print pdf for drug
        public void drugPdf() {

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\drug pdf", FileMode.Create));
            doc.Open();//open document to write
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\PMS\\Resources\\faith2.png");
            img.ScalePercent(79f);
            // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);



            doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                                                Drugs Report");
            doc.Add(p);
            DateTime time = DateTime.Now;

            Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "        Produced On         " + time.ToString() + "        \n\n");
            doc.Add(p2);


            //load data from datagrid
            PdfPTable table = new PdfPTable(viewDrugdataGridView.Columns.Count);

            //add headers from the datagridview to the table
            for (int j = 0; j < viewDrugdataGridView.Columns.Count; j++) {

                table.AddCell(new Phrase(viewDrugdataGridView.Columns[j].HeaderText));
            
            }

            //flag the first row as header

            table.HeaderRows = 1;

            //add the actual rows to the table from datagridview

            for (int i = 0; i < viewDrugdataGridView.Rows.Count; i++) {
                for (int k = 0; k < viewDrugdataGridView.Columns.Count; k++) {

                    if (viewDrugdataGridView[k,i].Value != null) {

                        table.AddCell(new Phrase(viewDrugdataGridView[k,i].Value.ToString()));
                    }
                
                }
            
            }

            doc.Add(table);
            //end querying from datagrid


                doc.Close();//close document after writting in

            MessageBox.Show("Drug Report generated Successful");

            System.Diagnostics.Process.Start("C:\\PMS\\Reports\\drug pdf");
        
        }


        //print drug excell.
        public void drugExcel()
        {
            //sqlConnection = new MySqlConnection(databaseConnection);

            try
            {
                DataTable dtCopy = dataTable.Copy();

                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dtCopy);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\PMS\\Reports\\Drugs.xls", ds);

                MessageBox.Show("Report generated successfully");
                Process sts = System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Drugs.xls");
                sts.WaitForExit();

                // sqlConnection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ViewDrug_Load(object sender, EventArgs e)
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
