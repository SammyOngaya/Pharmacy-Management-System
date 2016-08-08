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
    public partial class ViewStaff : Form
    {
        MySqlConnection con = null;
        public ViewStaff()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            viewStaff();
        }

        DataTable dataTable;

        //view staff
        public void viewStaff()
        {

            try
            {

                MySqlCommand com = new MySqlCommand("SELECT pfno AS 'PFNO',firstname AS 'FIRST NAME',lastname AS 'LAST NAME',dob AS 'DATE OF BIRTH',gender AS 'GENDER',nationalid AS 'NATIONAL ID',phone AS 'PHONE', email AS 'EMAIL', county AS 'COUNTY', location AS 'LOCATION', doe AS 'DATE OF EMPLOYMENT',category AS 'CATEGORY',status AS 'STATUS' FROM staff ORDER BY pfno DESC", con);

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
                dataTable.Columns.Add("PFNO");
                dataTable.Columns.Add("FIRST NAME");
                dataTable.Columns.Add("LAST NAME");
                dataTable.Columns.Add("DATE OF BIRTH", typeof(string));
                dataTable.Columns.Add("GENDER");
                dataTable.Columns.Add("NATIONAL ID");
                dataTable.Columns.Add("PHONE");
                dataTable.Columns.Add("EMAIL");
                dataTable.Columns.Add("COUNTY");
                dataTable.Columns.Add("LOCATION");
                dataTable.Columns.Add("DATE OF EMPLOYMENT", typeof(string));
                dataTable.Columns.Add("CATEGORY");
                dataTable.Columns.Add("STATUS");
                // End formating titles.
                
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                viewstaffdataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewstaffdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception )
            {
                MessageBox.Show("Error has occured while displaying employee personal details............!", "EMPLOYEE PERSONAL DETAILS DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }

        //print pdf for staffs
        public void staffPdf()
        {
            try
            {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\Staff pdf", FileMode.Create));
            doc.Open();//open document to write

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\PMS\\Resources\\faith2.png");
            img.ScalePercent(79f);
            // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);



            doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                                                Staffs Report");
            doc.Add(p);
            DateTime time = DateTime.Now;

            Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "        Produced On         " + time.ToString() + "        \n\n");
            doc.Add(p2);


            //load data from datagrid
            PdfPTable table = new PdfPTable(viewstaffdataGridView.Columns.Count);

            //add headers from the datagridview to the table
            for (int j = 0; j < viewstaffdataGridView.Columns.Count; j++)
            {

                table.AddCell(new Phrase(viewstaffdataGridView.Columns[j].HeaderText));

            }

            //flag the first row as header

            table.HeaderRows = 1;

            //add the actual rows to the table from datagridview

            for (int i = 0; i < viewstaffdataGridView.Rows.Count; i++)
            {
                for (int k = 0; k < viewstaffdataGridView.Columns.Count; k++)
                {

                    if (viewstaffdataGridView[k, i].Value != null)
                    {

                        table.AddCell(new Phrase(viewstaffdataGridView[k, i].Value.ToString()));
                    }

                }

            }

            doc.Add(table);
            //end querying from datagrid


            doc.Close();//close document after writting in

            MessageBox.Show("Staff report generated successfully...............!", "EMPLOYEE REPORT GENERATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Staff pdf");

               }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ","DOCUMENT ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            finally
            { 
            
            }

        }

        //print staffs excel.
        public void staffExcel()
        {
            //sqlConnection = new MySqlConnection(databaseConnection);

            try
            {
                DataTable dtCopy = dataTable.Copy();

                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dtCopy);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\PMS\\Reports\\Staff.xls", ds);

                MessageBox.Show("Staff report generated successfully...............!", "EMPLOYEE REPORT GENERATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process sts = System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Staff.xls");
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


        private void ViewStaff_Load(object sender, EventArgs e)
        {

        }

        private void staffPdfReportButton_Click(object sender, EventArgs e)
        {
            staffPdf();
        }

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            staffExcel();
        }
    }
}
