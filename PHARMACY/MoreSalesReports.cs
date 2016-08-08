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

namespace PHARMACY
{
    public partial class MoreSalesReports : Form
    {
        MySqlConnection con = null;
        public MoreSalesReports()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            salesView();
        }

        //view sales
        public void salesView()
        {
            string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");

            try
            {
                
                MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'ID', drug_name AS 'DRUG NAME',quantity AS 'QUANTITY',price AS 'PRICE', pfno AS 'SERVED BY',sales_date AS 'DATE SOLD',unit AS 'UNITS', serial AS 'RECEIPT NUMBER' FROM sales WHERE sales_date BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY sales_date ASC", con);

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
                a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                viewMoreSalesdataGridView.DataSource = bs;

                a.Update(dt);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewMoreSalesdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception )
            {
               // MessageBox.Show("Error has occured while registering supplier details............!", "SUPPLIER DETAILS REGISTRATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
               
            }
        }


        //////////////////////sales////////////

        //total Sales Report

        public void totalSalesReports()
        {
          
            string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");


            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM sales WHERE sales_date BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY sales_date ASC", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                totalSalesReport.Text = count.ToString();

                con.Close();

            }
            catch (Exception )
            {
               
            }
        }

        //amount Sold

        public void amountSoldReport()
        {

            string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");

            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT ROUND(SUM(quantity*price),2) AS sum FROM sales WHERE sales_date BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY sales_date ASC", con);
                MySqlDataReader mr = mc.ExecuteReader();

                while (mr.Read())
                {

                    String sm = mr.GetDouble("sum").ToString();
                    amountSold.Text = sm;
                }



                con.Close();

            }
            catch (Exception )
            {
              
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

            doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                 Sales Report");
            doc.Add(p);
            Paragraph p2 = new Paragraph("                 Produced by ");
            doc.Add(p2);


            //load data from datagrid
            PdfPTable table = new PdfPTable(viewMoreSalesdataGridView.Columns.Count);

            //add headers from the datagridview to the table
            for (int j = 0; j < viewMoreSalesdataGridView.Columns.Count; j++)
            {

                table.AddCell(new Phrase(viewMoreSalesdataGridView.Columns[j].HeaderText));

            }

            //flag the first row as header

            table.HeaderRows = 1;

            //add the actual rows to the table from datagridview

            for (int i = 0; i < viewMoreSalesdataGridView.Rows.Count; i++)
            {
                for (int k = 0; k < viewMoreSalesdataGridView.Columns.Count; k++)
                {

                    if (viewMoreSalesdataGridView[k, i].Value != null)
                    {

                        table.AddCell(new Phrase(viewMoreSalesdataGridView[k, i].Value.ToString()));
                    }

                }

            }

            doc.Add(table);
            //end querying from datagrid


            doc.Close();//close document after writting in

            MessageBox.Show("Sales Report generated Successfully");

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
        private void MoreSalesReports_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            salesView();
            totalSalesReports();
            amountSoldReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nsalesPdf();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
