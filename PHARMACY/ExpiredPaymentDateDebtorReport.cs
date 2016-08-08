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
    public partial class ExpiredPaymentDateDebtorReport : Form
    {
        MySqlConnection con = null;
        DataTable dataTable;

        public ExpiredPaymentDateDebtorReport(string user)
        {
            InitializeComponent();
            pfSessionTextBox.Text = user;
            con = DBHandler.CreateConnection();
            viewDebtor();
            searchDrug();
            searchPhone();
        }

        private void ExpiredPaymentDateDebtorReport_Load(object sender, EventArgs e)
        {

        }

        //compute amount transacted.
        public void amount()
        {

            double sum = 0.00;
            for (int i = 0; i < debtroReportDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(debtroReportDataGridView.Rows[i].Cells[6].Value);

            }

            amountLabel.Text = "total amount  " + sum.ToString() + " Kshs";
        }

        //compute amount transacted.
        public void DepositAmount()
        {

            double sum = 0.00;
            for (int i = 0; i < debtroReportDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(debtroReportDataGridView.Rows[i].Cells[7].Value);

            }

            depositAmount.Text = "deposit amount  " + sum.ToString() + " Kshs";
        }

        //compute amount transacted.
        public void RemainingAmount()
        {

            double sum = 0.00;
            for (int i = 0; i < debtroReportDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(debtroReportDataGridView.Rows[i].Cells[8].Value);

            }

            remainingAmount.Text = "remaining amount  " + sum.ToString() + " Kshs";
        }

        private void ReportDebtor_Load(object sender, EventArgs e)
        {

        }




        //search drug from debtor.
        public void searchDrug()
        {
            drugNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            drugNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {
                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                con.Open();


                MySqlCommand com = new MySqlCommand("SELECT `drug`.`name` AS 'name' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `debtor` ON `stock`.`stock_id`=`debtor`.`stock_id` WHERE ((DATEDIFF(`debtor`.`date_of_payment`,'" + dateNow + "')<=0) AND ((`debtor`.`quantity`*`debtor`.`price`)>`debtor`.`deposit`)) GROUP BY `debtor`.`stock_id` ORDER BY `drug`.`name` ASC", con);

                MySqlDataReader r = com.ExecuteReader();

                while (r.Read())
                {
                    string name = r.GetString("name");
                    collection.Add(name);

                }
                con.Close();
            }
            catch (Exception)
            {
            }
            drugNameTextBox.AutoCompleteCustomSource = collection;

        }


        //search phone from debtor.
        public void searchPhone()
        {
            phoneTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            phoneTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {
                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                con.Open();


                MySqlCommand com = new MySqlCommand("SELECT phone FROM  debtor WHERE ((DATEDIFF(`debtor`.`date_of_payment`,'" + dateNow + "')<=0) AND ((`debtor`.`quantity`*`debtor`.`price`)>`debtor`.`deposit`))  ORDER BY phone ASC", con);

                MySqlDataReader r = com.ExecuteReader();

                while (r.Read())
                {
                    string phone = r.GetString("phone");
                    collection.Add(phone);

                }
                con.Close();
            }
            catch (Exception)
            {
            }
            phoneTextBox.AutoCompleteCustomSource = collection;

        }


        public void viewDebtor()
        {

            try
            {
                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand com = new MySqlCommand("SELECT `debtor`.`id` AS 'DEBTOR ID',`debtor`.`name` AS 'NAME',`drug`.`name` AS 'DRUG NAME',`debtor`.`quantity` AS 'QUANTITY',`debtor`.`price` AS 'PRICE',(`debtor`.`quantity`*`debtor`.`price`) AS 'AMOUNT',((`debtor`.`quantity`*`debtor`.`price`)-`debtor`.`deposit`) AS 'BALANCE',`debtor`.`date_borrowed` AS 'DATE BORROWED',`debtor`.`phone` AS 'PHONE',`debtor`.`deposit` AS 'DEPOSIT',`debtor`.`date_of_payment` AS 'DATE OF PAYMENT',`debtor`.`pfno` AS 'REGISTERED BY',`debtor`.`registered_date` AS 'REGISTRATION DATE' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `debtor` ON `stock`.`stock_id`=`debtor`.`stock_id` WHERE ((DATEDIFF(`debtor`.`date_of_payment`,'" + dateNow + "')<=0) AND ((`debtor`.`quantity`*`debtor`.`price`)>`debtor`.`deposit`))  ORDER BY `debtor`.`date_borrowed` DESC", con);

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
                dataTable.Columns.Add("DEBTOR ID");
                dataTable.Columns.Add("NAME");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("PRICE");
                dataTable.Columns.Add("AMOUNT");
                dataTable.Columns.Add("DEPOSIT");
                dataTable.Columns.Add("BALANCE");
                dataTable.Columns.Add("DATE BORROWED", typeof(string));
                dataTable.Columns.Add("PHONE");
                dataTable.Columns.Add("DATE OF PAYMENT", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                dataTable.Columns.Add("REGISTRATION DATE", typeof(string));
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                debtroReportDataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(debtroReportDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            amount();
            DepositAmount();
            RemainingAmount();
        }


        // View debtor filter by drug name.
        public void viewDebtorFilterByDrugName()
        {
            try
            {
                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand com = new MySqlCommand("SELECT `debtor`.`id` AS 'DEBTOR ID',`debtor`.`name` AS 'NAME',`drug`.`name` AS 'DRUG NAME',`debtor`.`quantity` AS 'QUANTITY',`debtor`.`price` AS 'PRICE',(`debtor`.`quantity`*`debtor`.`price`) AS 'AMOUNT',((`debtor`.`quantity`*`debtor`.`price`)-`debtor`.`deposit`) AS 'BALANCE',`debtor`.`date_borrowed` AS 'DATE BORROWED',`debtor`.`phone` AS 'PHONE',`debtor`.`deposit` AS 'DEPOSIT',`debtor`.`date_of_payment` AS 'DATE OF PAYMENT',`debtor`.`pfno` AS 'REGISTERED BY',`debtor`.`registered_date` AS 'REGISTRATION DATE' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `debtor` ON `stock`.`stock_id`=`debtor`.`stock_id` WHERE ((DATEDIFF(`debtor`.`date_of_payment`,'" + dateNow + "')<=0) AND ((`debtor`.`quantity`*`debtor`.`price`)>`debtor`.`deposit`) AND (`drug`.`name`='" + this.drugNameTextBox.Text + "'))  ORDER BY `drug`.`name` ASC", con);

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
                dataTable.Columns.Add("DEBTOR ID");
                dataTable.Columns.Add("NAME");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("PRICE");
                dataTable.Columns.Add("AMOUNT");
                dataTable.Columns.Add("DEPOSIT");
                dataTable.Columns.Add("BALANCE");
                dataTable.Columns.Add("DATE BORROWED", typeof(string));
                dataTable.Columns.Add("PHONE");
                dataTable.Columns.Add("DATE OF PAYMENT", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                dataTable.Columns.Add("REGISTRATION DATE", typeof(string));
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                debtroReportDataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(debtroReportDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            amount();
            DepositAmount();
            RemainingAmount();
        }

        // View debtor filter by phone.
        public void viewDebtorFilterByPhone()
        {
            try
            {
                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand com = new MySqlCommand("SELECT `debtor`.`id` AS 'DEBTOR ID',`debtor`.`name` AS 'NAME',`drug`.`name` AS 'DRUG NAME',`debtor`.`quantity` AS 'QUANTITY',`debtor`.`price` AS 'PRICE',(`debtor`.`quantity`*`debtor`.`price`) AS 'AMOUNT',((`debtor`.`quantity`*`debtor`.`price`)-`debtor`.`deposit`) AS 'BALANCE',`debtor`.`date_borrowed` AS 'DATE BORROWED',`debtor`.`phone` AS 'PHONE',`debtor`.`deposit` AS 'DEPOSIT',`debtor`.`date_of_payment` AS 'DATE OF PAYMENT',`debtor`.`pfno` AS 'REGISTERED BY',`debtor`.`registered_date` AS 'REGISTRATION DATE' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `debtor` ON `stock`.`stock_id`=`debtor`.`stock_id` WHERE ((DATEDIFF(`debtor`.`date_of_payment`,'" + dateNow + "')<=0) AND ((`debtor`.`quantity`*`debtor`.`price`)>`debtor`.`deposit`) AND (`debtor`.`phone`='" + this.phoneTextBox.Text + "'))  ORDER BY `debtor`.`phone` ASC", con);

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
                dataTable.Columns.Add("DEBTOR ID");
                dataTable.Columns.Add("NAME");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("PRICE");
                dataTable.Columns.Add("AMOUNT");
                dataTable.Columns.Add("DEPOSIT");
                dataTable.Columns.Add("BALANCE");
                dataTable.Columns.Add("DATE BORROWED", typeof(string));
                dataTable.Columns.Add("PHONE");
                dataTable.Columns.Add("DATE OF PAYMENT", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                dataTable.Columns.Add("REGISTRATION DATE", typeof(string));
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                debtroReportDataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(debtroReportDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            amount();
            DepositAmount();
            RemainingAmount();
        }

        //print pdf for debtor
        public void debtorPdf()
        {

            try
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
                PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\EXCEEDED PAYMENT DATE DEBTOR REPORT", FileMode.Create));
                doc.Open();//open document to write

                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\PMS\\Resources\\faith2.png");
                img.ScalePercent(79f);
                // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);



                doc.Add(img); //add image to document
                Paragraph p = new Paragraph("                                                                Debtor Report");
                doc.Add(p);
                DateTime time = DateTime.Now;

                Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "        Produced On         " + time.ToString() + "        \n\n");
                doc.Add(p2);


                //load data from datagrid
                PdfPTable table = new PdfPTable(debtroReportDataGridView.Columns.Count);

                //add headers from the datagridview to the table
                for (int j = 0; j < debtroReportDataGridView.Columns.Count; j++)
                {

                    table.AddCell(new Phrase(debtroReportDataGridView.Columns[j].HeaderText));

                }

                //flag the first row as header

                table.HeaderRows = 1;

                //add the actual rows to the table from datagridview

                for (int i = 0; i < debtroReportDataGridView.Rows.Count; i++)
                {
                    for (int k = 0; k < debtroReportDataGridView.Columns.Count; k++)
                    {

                        if (debtroReportDataGridView[k, i].Value != null)
                        {

                            table.AddCell(new Phrase(debtroReportDataGridView[k, i].Value.ToString()));
                        }

                    }

                }

                doc.Add(table);
                //end querying from datagrid


                doc.Close();//close document after writting in

                MessageBox.Show("Debtor Report generated Successful");

                System.Diagnostics.Process.Start("C:\\PMS\\Reports\\EXCEEDED PAYMENT DATE DEBTOR REPORT");

            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ", "DOCUMENT ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

            }

        }

        //print debtors excel.
        public void debtorsExcel()
        {
            //sqlConnection = new MySqlConnection(databaseConnection);

            try
            {
                DataTable dtCopy = dataTable.Copy();

                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dtCopy);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\PMS\\Reports\\EXCEEDED PAYMENT DATE DEBTOR REPORT.xls", ds);

                MessageBox.Show("Report generated successfully");
                Process sts = System.Diagnostics.Process.Start("C:\\PMS\\Reports\\EXCEEDED PAYMENT DATE DEBTOR REPORT.xls");
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

        private void drugNameTextBox_TextChanged(object sender, EventArgs e)
        {
            viewDebtorFilterByDrugName();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            viewDebtorFilterByDrugName();
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            viewDebtorFilterByPhone();
        }

        private void searchByDriverID_Click(object sender, EventArgs e)
        {
            viewDebtorFilterByPhone();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DebtorPayDebt v = new DebtorPayDebt(pfSessionTextBox.Text);
            v.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewDebtor();
        }

    }
}
