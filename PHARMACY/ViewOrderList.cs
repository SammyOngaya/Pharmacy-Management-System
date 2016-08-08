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
    public partial class ViewOrderList : Form
    {
        MySqlConnection con = null;
        DataTable  dataTableMin, dataTableOrder;

        public ViewOrderList()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            minimumPriceList();
            orderListGridView();
            searchSupplier();
        }


        // Search supplier name.
        public void searchSupplier()
        {
            searchSupplierTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchSupplierTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            try
            {
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `supplier`.`name` AS 'name' FROM `supplier` JOIN `order_price_list` ON `supplier`.`id`=`order_price_list`.`supplier_id`", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String name = reader.GetString("name");

                    collection.Add(name);
                }
               
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while searching drug details............!", "DRUG DETAILS SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

            searchSupplierTextBox.AutoCompleteCustomSource = collection;
            con.Close();
        }// End search drug.

        // Show supplier name.
        public void supplierData()
        {

            try
            {
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `supplier`.`name` AS 'name',`supplier`.`id` AS 'id' FROM `supplier` JOIN `order_price_list` ON `supplier`.`id`=`order_price_list`.`supplier_id`  WHERE `supplier`.`name`='" + this.searchSupplierTextBox.Text + "'", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String name = reader.GetString("name");
                    String id = reader.GetString("id");

                    searchSupplierTextBox.Text = name;
                    supplieridforeignkey.Text = id;

                }

            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
                //MessageBox.Show("Error has occured while searching order list price............!", "ORDER PRICE SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            con.Close();
        } // End show drug name.

        // display minimum price list.
        private void minimumPriceList()
        {
            try
            {

                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER',`drug`.`name` AS 'DRUG',`min_order_price_list`.`price` AS 'PRICE', ROUND((`min_order_price_list`.`quantity`),0) AS 'QUANTITY',ROUND((`min_order_price_list`.`price`*`min_order_price_list`.`quantity`),2) AS 'TOTAL' FROM `supplier` JOIN `min_order_price_list` ON `supplier`.`id`=`min_order_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`min_order_price_list`.`drug_id`  ORDER BY `supplier`.`name` ASC", con);
               

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTableMin = new DataTable();
                // Add autoincrement column.
                dataTableMin.Columns.Add("#", typeof(int));
                dataTableMin.PrimaryKey = new DataColumn[] { dataTableMin.Columns["#"] };
                dataTableMin.Columns["#"].AutoIncrement = true;
                dataTableMin.Columns["#"].AutoIncrementSeed = 1;
                dataTableMin.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dataTableMin);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTableMin;
                supplierPriceListDataGridView.DataSource = bs;

                a.Update(dataTableMin);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(supplierPriceListDataGridView.Rows.Count) - 1;
                minimumSupplierRowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            getMinimumListAmount();
        }

        // display order price list.
        private void orderListGridView()
        {
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER',`drug`.`name` AS 'DRUG',`order_price_list`.`price` AS 'PRICE',ROUND(( `order_price_list`.`quantity`),0) AS 'QUANTITY',ROUND((`order_price_list`.`price`*`order_price_list`.`quantity`),2) AS 'TOTAL' FROM `supplier` JOIN `order_price_list` ON `supplier`.`id`=`order_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`order_price_list`.`drug_id`  ORDER BY `supplier`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTableOrder = new DataTable();
                // Add autoincrement column.
                dataTableOrder.Columns.Add("#", typeof(int));
                dataTableOrder.PrimaryKey = new DataColumn[] { dataTableOrder.Columns["#"] };
                dataTableOrder.Columns["#"].AutoIncrement = true;
                dataTableOrder.Columns["#"].AutoIncrementSeed = 1;
                dataTableOrder.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dataTableOrder);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTableOrder;
                otherSuppliersOrderListDataGridView.DataSource = bs;

                a.Update(dataTableOrder);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(otherSuppliersOrderListDataGridView.Rows.Count) - 1;
                AllSuppliersRowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            con.Close();
            getSupplierListAmount();
        }


        // Search price list by supplier.
        private void searchOrderListBySupplier()
        {
            try
            {

                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER',`drug`.`name` AS 'DRUG',`order_price_list`.`price` AS 'PRICE',ROUND(( `order_price_list`.`quantity`),0) AS 'QUANTITY',ROUND((`order_price_list`.`price`*`order_price_list`.`quantity`),2) AS 'TOTAL' FROM `supplier` JOIN `order_price_list` ON `supplier`.`id`=`order_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`order_price_list`.`drug_id` WHERE `order_price_list`.`supplier_id`='" + this.supplieridforeignkey.Text + "' GROUP BY `order_price_list`.`drug_id` ORDER BY `supplier`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dataTable = new DataTable();
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
                otherSuppliersOrderListDataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(otherSuppliersOrderListDataGridView.Rows.Count) - 1;
                AllSuppliersRowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            con.Close();

            getSupplierListAmount();

        }

        // Totals 

        //compute amount transacted.
        public void getMinimumListAmount()
        {

            double sum = 0.00;
            for (int i = 0; i < supplierPriceListDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(supplierPriceListDataGridView.Rows[i].Cells[5].Value);

            }
            //string amt = "amount  "+sum.ToString();
            minimumTotalAmountLabel.Text = "  " + sum.ToString() + " Kshs";
        }


        public void getSupplierListAmount()
        {
            double sum = 0.00;
            for (int i = 0; i < otherSuppliersOrderListDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(otherSuppliersOrderListDataGridView.Rows[i].Cells[5].Value);

            }
            //string amt = "amount  "+sum.ToString();
            allSupplierToTalAmountLabel.Text = "  " + sum.ToString() + " Kshs";
        }


        //print pdf for minimal order price list.
        public void minimalOrderPriceList()
        {

            try
            {

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\Minimal Order List pdf", FileMode.Create));
            doc.Open();//open document to write

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\PMS\\Resources\\faith2.png");
            img.ScalePercent(79f);
            // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);



            doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                                           Minimal Order List");
            doc.Add(p);
            DateTime time = DateTime.Now;

            Paragraph p2 = new Paragraph("                      Amount " + this.minimumTotalAmountLabel.Text + "        Produced On         " + time.ToString() + "        \n\n");
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

            MessageBox.Show("Price List Report generated Successful");

            System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Minimal Order List pdf");

               }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ","DOCUMENT ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            finally
            { 
            
            }

        }



        //print pdf for order price list.
        public void orderPriceList()
        {
            try
            {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\Order List pdf", FileMode.Create));
            doc.Open();//open document to write

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\PMS\\Resources\\faith2.png");
            img.ScalePercent(79f);
            // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);



            doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                                           Order List");
            doc.Add(p);
            DateTime time = DateTime.Now;

            Paragraph p2 = new Paragraph("   Supplier  " + this.searchSupplierTextBox.Text + "             Amount " + this.allSupplierToTalAmountLabel.Text + "      Produced On     " + time.ToString() + "        \n\n");
            doc.Add(p2);


            //load data from datagrid
            PdfPTable table = new PdfPTable(otherSuppliersOrderListDataGridView.Columns.Count);

            //add headers from the datagridview to the table
            for (int j = 0; j < otherSuppliersOrderListDataGridView.Columns.Count; j++)
            {

                table.AddCell(new Phrase(otherSuppliersOrderListDataGridView.Columns[j].HeaderText));

            }

            //flag the first row as header

            table.HeaderRows = 1;

            //add the actual rows to the table from datagridview

            for (int i = 0; i < otherSuppliersOrderListDataGridView.Rows.Count; i++)
            {
                for (int k = 0; k < otherSuppliersOrderListDataGridView.Columns.Count; k++)
                {

                    if (otherSuppliersOrderListDataGridView[k, i].Value != null)
                    {

                        table.AddCell(new Phrase(otherSuppliersOrderListDataGridView[k, i].Value.ToString()));
                    }

                }

            }

            doc.Add(table);
            //end querying from datagrid


            doc.Close();//close document after writting in

            MessageBox.Show("Order List Report generated Successfully");

            System.Diagnostics.Process.Start("C:\\PMS\\Reports\\Order List pdf");

               }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ","DOCUMENT ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            finally
            { 
            
            }

        }

        private void ViewOrderList_Load(object sender, EventArgs e)
        {

        }

        private void searchSupplierTextBox_TextChanged(object sender, EventArgs e)
        {
            supplierData();
            searchOrderListBySupplier();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            orderPriceList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            minimalOrderPriceList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            searchOrderListBySupplier();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            orderListGridView();
        }
    }
}
