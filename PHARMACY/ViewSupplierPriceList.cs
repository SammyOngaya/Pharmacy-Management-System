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
    public partial class ViewSupplierPriceList : Form
    {
        MySqlConnection con = null;
        DataTable dataTable;

        public ViewSupplierPriceList()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            displayPriceListRecords();
            supplierCombo();
            searchDrug();
        }

        // Search drug.
        public void searchDrug()
        {
            searchDrugTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchDrugTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            try
            {
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `drug`.`name` AS 'name' FROM `drug` JOIN `supplier_price_list` ON `drug`.`id`=`supplier_price_list`.`drug_id` GROUP BY `supplier_price_list`.`drug_id` ORDER BY `drug`.`name` ASC", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String name = reader.GetString("name");
                    collection.Add(name);
                }
               // reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while searching drug details............!", "DRUG DETAILS SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

            searchDrugTextBox.AutoCompleteCustomSource = collection;
            con.Close();
        }// End search drug.

        //populate supplier combo
        public void supplierCombo()
        {

            con.Open();

            MySqlCommand c = new MySqlCommand("SELECT `supplier`.`name` AS 'name' FROM `supplier` JOIN `supplier_price_list` ON `supplier`.`id`=`supplier_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`supplier_price_list`.`drug_id` GROUP BY `supplier_price_list`.`supplier_id` ORDER BY `supplier`.`name` ASC", con);

            MySqlDataReader m = c.ExecuteReader();

            while (m.Read())
            {
                String name = m.GetString("name");
                addSupplierCombox.Items.Add(name);



            }
            m.Close();
            // m.Close();
            con.Close();
        }

        private void displayPriceListRecords()
        {
            try
            {

                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER',`drug`.`name` AS 'DRUG',`supplier_price_list`.`price` AS 'PRICE' FROM `supplier` JOIN `supplier_price_list` ON `supplier`.`id`=`supplier_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`supplier_price_list`.`drug_id` ORDER BY `supplier`.`name` ASC", con);

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
                supplierPriceListDataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(supplierPriceListDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            con.Close();

        }

        // Search by supplier.
        private void searchPriceListRecordsBySupplier()
        {
            try
            {

                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER',`drug`.`name` AS 'DRUG',`supplier_price_list`.`price` AS 'PRICE' FROM `supplier` JOIN `supplier_price_list` ON `supplier`.`id`=`supplier_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`supplier_price_list`.`drug_id` WHERE `supplier`.`name`='" + this.addSupplierCombox.Text + "' ORDER BY `supplier`.`name` ASC", con);

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
                supplierPriceListDataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(supplierPriceListDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            con.Close();

        }


        // Search by drug.
        private void searchPriceListRecordsByDrug()
        {
            try
            {

                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER',`drug`.`name` AS 'DRUG',`supplier_price_list`.`price` AS 'PRICE' FROM `supplier` JOIN `supplier_price_list` ON `supplier`.`id`=`supplier_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`supplier_price_list`.`drug_id` WHERE `drug`.`name`='" + this.searchDrugTextBox.Text + "' ORDER BY `drug`.`name` ASC", con);

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
                 a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                supplierPriceListDataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(supplierPriceListDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            con.Close();

        }



        //print pdf for supplier price list.
        public void supplierPriceList()
        {
            try
            {

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\Supplier Price List pdf", FileMode.Create));
            doc.Open();//open document to write

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\PMS\\Resources\\faith2.png");
            img.ScalePercent(79f);
            // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);



            doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                                                Supplier Price List Report");
            doc.Add(p);
            DateTime time = DateTime.Now;

            Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "        Produced On         " + time.ToString() + "        \n\n");
            doc.Add(p2);


            //load data from datagrid
            PdfPTable table = new PdfPTable(supplierPriceListDataGridView.Columns.Count);

            //add headers from the datagridview to the table
            for (int j = 0; j < supplierPriceListDataGridView.Columns.Count; j++)
            {

                table.AddCell(new Phrase(supplierPriceListDataGridView.Columns[j].HeaderText));

            }

            //flag the first row as header

            table.HeaderRows = 1;

            //add the actual rows to the table from datagridview

            for (int i = 0; i < supplierPriceListDataGridView.Rows.Count; i++)
            {
                for (int k = 0; k < supplierPriceListDataGridView.Columns.Count; k++)
                {

                    if (supplierPriceListDataGridView[k, i].Value != null)
                    {

                        table.AddCell(new Phrase(supplierPriceListDataGridView[k, i].Value.ToString()));
                    }

                }

            }

            doc.Add(table);
            //end querying from datagrid


            doc.Close();//close document after writting in

            MessageBox.Show("Supplier Price List Report generated Successful");

            System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Supplier Price List pdf");

               }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ","DOCUMENT ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            finally
            { 
            
            }

        }

        //print supplier price list in excel.
        public void supplierPriceListExcel()
        {
            //sqlConnection = new MySqlConnection(databaseConnection);

            try
            {
                DataTable dtCopy = dataTable.Copy();

                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dtCopy);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\PMS\\Reports\\Supplier Price List.xls", ds);

                MessageBox.Show("Report generated successfully");
                Process sts = System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Supplier Price List.xls");
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



        private void ViewSupplierPriceList_Load(object sender, EventArgs e)
        {

        }

        private void addSupplierCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchPriceListRecordsBySupplier();
        }

        private void searchSupplierPriceListButton_Click(object sender, EventArgs e)
        {
            searchPriceListRecordsBySupplier();
        }

        private void searchDrugTextBox_TextChanged(object sender, EventArgs e)
        {
            searchPriceListRecordsByDrug();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            searchPriceListRecordsByDrug();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            supplierPriceList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            supplierPriceListExcel();
        }
    }
}
