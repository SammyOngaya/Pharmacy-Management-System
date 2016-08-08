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
    public partial class Log : Form
    {
        MySqlConnection con = null;
        public Log()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            showLogDetails();
            distinctUsers();
        }

        private void Log_Load(object sender, EventArgs e)
        {

        }


        DataTable dataTable;
       
      

        // Distinct users.
        private void distinctUsers()
        {

          
            try
            {

                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT COUNT(DISTINCT(`events`.`pfno`)) AS 'userCount' FROM `events` ", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    string userCount = reader.GetString("userCount");
                    distinctUsreLabel.Text = userCount + " users loged in.";
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while retrieving system log details ............!", "SYSTEM LOG REPORT ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }


        private void showLogDetails()
        {
          
            try
            {

                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `events`.`event_id` AS 'EVENT ID',`events`.`pfno` AS 'STAFF ID',`events`.`event_time` AS 'EVENT TIME',`events`.`description` AS 'ACTIVITY' FROM `events` ORDER BY `events`.`event_time` DESC", con);
                MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter();
                mysqlDataAdapter.SelectCommand = sqlCommand;
                dataTable = new DataTable();

                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("EVENT ID", typeof(string));
                dataTable.Columns.Add("EVENT TIME", typeof(string));
                // End formating titles.

                mysqlDataAdapter.Fill(dataTable);
                BindingSource bind = new BindingSource();
                bind.DataSource = dataTable;
                logDataGridView.DataSource = bind;

                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(logDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while retrieving system log details ............!", "SYSTEM LOG REPORT ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            distinctUsers();

        }



        // Search by date between.
        private void showLogDetailsFilterByDateBetween()
        {
           
            try
            {
                string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
                string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");

                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `events`.`event_id` AS 'EVENT ID',`events`.`pfno` AS 'STAFF ID',`events`.`event_time` AS 'EVENT TIME',`events`.`description` AS 'ACTIVITY' FROM `events` WHERE (`events`.`event_time` BETWEEN '" + startDate + "' AND '" + endDate + "') ORDER BY `events`.`event_time` DESC", con);
                MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter();
                mysqlDataAdapter.SelectCommand = sqlCommand;
                dataTable = new DataTable();

                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(int));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                mysqlDataAdapter.Fill(dataTable);
                BindingSource bind = new BindingSource();
                bind.DataSource = dataTable;
                logDataGridView.DataSource = bind;

                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(logDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while retrieving system log details ............!", "SYSTEM LOG REPORT ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            distinctUsers();
        }

        // Search by date between and staff.
        private void showLogDetailsFilterByDateBetweenAndStaff()
        {
           
            try
            {
                string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
                string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");

                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `events`.`event_id` AS 'EVENT ID',`events`.`pfno` AS 'STAFF ID',`events`.`event_time` AS 'EVENT TIME',`events`.`description` AS 'ACTIVITY' FROM `events` WHERE (`events`.`pfno`='" + this.staffIDTextBox.Text + "' AND `events`.`event_time` BETWEEN '" + startDate + "' AND '" + endDate + "') ORDER BY `events`.`event_time` DESC", con);
                MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter();
                mysqlDataAdapter.SelectCommand = sqlCommand;
                dataTable = new DataTable();

                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(int));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                mysqlDataAdapter.Fill(dataTable);
                BindingSource bind = new BindingSource();
                bind.DataSource = dataTable;
                logDataGridView.DataSource = bind;

                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(logDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while retrieving system log details ............!", "SYSTEM LOG REPORT ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            distinctUsers();
        }

        // Search by date.
        private void showLogDetailsFilterByDate()
        {
            
            try
            {
                string theDate = dateDateTimePicker.Value.ToString("yyyy-MM-dd");
                //string theDate = dateDateTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss");

                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `events`.`event_id` AS 'EVENT ID',`events`.`pfno` AS 'STAFF ID',`events`.`event_time` AS 'EVENT TIME',`events`.`description` AS 'ACTIVITY' FROM `events` WHERE `events`.`event_time` ='" + theDate + "' ORDER BY `events`.`event_time` DESC", con);
                MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter();
                mysqlDataAdapter.SelectCommand = sqlCommand;
                dataTable = new DataTable();

                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(int));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                mysqlDataAdapter.Fill(dataTable);
                BindingSource bind = new BindingSource();
                bind.DataSource = dataTable;
                logDataGridView.DataSource = bind;

                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(logDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while retrieving system log details ............!", "SYSTEM LOG REPORT ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

            distinctUsers();
        }

        // Search by date staff.
        private void showLogDetailsFilterByDateAndStaff()
        {
           
            try
            {
                string theDate = dateDateTimePicker.Value.ToString("yyyy-MM-dd");

                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `events`.`event_id` AS 'EVENT ID',`events`.`pfno` AS 'STAFF ID',`events`.`event_time` AS 'EVENT TIME',`events`.`description` AS 'ACTIVITY' FROM `events` WHERE `events`.`event_time` ='" + theDate + "' AND `events`.`pfno`='" + this.staffIDTextBox.Text + "' ORDER BY `events`.`event_time` DESC", con);
                MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter();
                mysqlDataAdapter.SelectCommand = sqlCommand;
                dataTable = new DataTable();

                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(int));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                mysqlDataAdapter.Fill(dataTable);
                BindingSource bind = new BindingSource();
                bind.DataSource = dataTable;
                logDataGridView.DataSource = bind;

                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(logDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while retrieving system log details ............!", "SYSTEM LOG REPORT ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            distinctUsers();

        }

        // Search by staff.
        private void showLogDetailsFilterByStaff()
        {
           
            try
            {

                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `events`.`event_id` AS 'EVENT ID',`events`.`pfno` AS 'STAFF ID',`events`.`event_time` AS 'EVENT TIME',`events`.`description` AS 'ACTIVITY' FROM `events` WHERE  `events`.`pfno`='" + this.staffIDTextBox.Text + "' ORDER BY `events`.`event_time` DESC", con);
                MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter();
                mysqlDataAdapter.SelectCommand = sqlCommand;
                dataTable = new DataTable();

                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(int));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                mysqlDataAdapter.Fill(dataTable);
                BindingSource bind = new BindingSource();
                bind.DataSource = dataTable;
                logDataGridView.DataSource = bind;

                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(logDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while retrieving system log details ............!", "SYSTEM LOG REPORT ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

            distinctUsers();
        }


        // Reports.
        //print log spreadsheet
        public void logExcel()
        {
          
            try
            {
                //DataTable dtCopy = dataTable.Copy();
                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dataTable);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\PMS\\Reports\\log.xls", ds);

                MessageBox.Show("Report generated successfully...............!", "SYSTEM LOG REPORT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process sts = System.Diagnostics.Process.Start("C:\\PMS\\Reports\\log.xls");
                sts.WaitForExit();

               
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while generating system log details ............!", "SYSTEM LOG REPORT GENERATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }


        //print log for float.

        public void logPdf()
        {
            try
            {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\log.pdf", FileMode.Create));
            doc.Open();//open document to write

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\PMS\\Resources\\faith2.png");
            img.ScalePercent(79f);
            /// img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);

            doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                                                log report");
            doc.Add(p);
            DateTime time = DateTime.Now;

            Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "                     On         " + time.ToString() + "        \n\n");
            doc.Add(p2);


            //load data from datagrid
            PdfPTable table = new PdfPTable(logDataGridView.Columns.Count);

            //add headers from the datagridview to the table
            for (int j = 0; j < logDataGridView.Columns.Count; j++)
            {

                table.AddCell(new Phrase(logDataGridView.Columns[j].HeaderText));

            }

            //flag the first row as header

            table.HeaderRows = 1;

            //add the actual rows to the table from datagridview

            for (int i = 0; i < logDataGridView.Rows.Count; i++)
            {
                for (int k = 0; k < logDataGridView.Columns.Count; k++)
                {

                    if (logDataGridView[k, i].Value != null)
                    {

                        table.AddCell(new Phrase(logDataGridView[k, i].Value.ToString()));
                    }

                }

            }

            doc.Add(table);
            // End querying from datagrid.


            doc.Close();//close document after writting in.

            MessageBox.Show("Report generated successfully...............!", "SYSTEM LOG REPORT", MessageBoxButtons.OK, MessageBoxIcon.Information);

            System.Diagnostics.Process.Start("C:\\PMS\\Reports\\log.pdf");

            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ", "DOCUMENT ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

            }

        }

        private void searchByDate_Click(object sender, EventArgs e)
        {
            showLogDetailsFilterByDateBetween();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            logPdf();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            logExcel();
        }

        private void searchByDriverID_Click(object sender, EventArgs e)
        {
            showLogDetailsFilterByStaff();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showLogDetailsFilterByDateAndStaff();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showLogDetailsFilterByDateBetweenAndStaff();
        }

        private void searchDate_Click(object sender, EventArgs e)
        {
            showLogDetailsFilterByDate();
        }

        private void dateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            showLogDetailsFilterByDate();
        }

        private void staffIDTextBox_TextChanged(object sender, EventArgs e)
        {
            showLogDetailsFilterByStaff();
        }

        private void endDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            showLogDetailsFilterByDateBetween();
        }


    }
}
