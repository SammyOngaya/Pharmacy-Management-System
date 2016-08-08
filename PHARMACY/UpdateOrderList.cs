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
    public partial class UpdateOrderList : Form
    {
        //MySqlConnection con = null;
        DialogResult dialog;

        public UpdateOrderList(string user)
        {
            InitializeComponent();
            //con = DBHandler.CreateConnection();
            pfsession.Text = user;
            searchDrug();
            minimumPriceList();
            orderListGridView();
            searchSupplier();
        }
        String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";

        // Search drug.
        public void searchDrug()
        {
            searchDrugTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchDrugTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `drug`.`name` AS 'name' FROM `drug` JOIN `supplier_price_list` ON `drug`.`id`=`supplier_price_list`.`drug_id` WHERE `drug`.`status`='Active' GROUP BY `supplier_price_list`.`drug_id` ORDER BY `drug`.`name` ASC", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String name = reader.GetString("name");
                    collection.Add(name);
                }
                con.Close();
            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while searching drug details............!", "DRUG DETAILS SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

            searchDrugTextBox.AutoCompleteCustomSource = collection;
           
        }// End search drug.

        // Show drug name.
        public void drugData()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `drug`.`name` AS 'name',`drug`.`id` AS 'id' FROM `supplier` JOIN `supplier_price_list` ON `supplier`.`id`=`supplier_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`supplier_price_list`.`drug_id` WHERE `drug`.`name`='" + this.searchDrugTextBox.Text + "' GROUP BY `supplier_price_list`.`drug_id`", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String name = reader.GetString("name");

                    searchDrugTextBox.Text = name;

                }
                con.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                //MessageBox.Show("Error has occured while searching order list price............!", "ORDER PRICE SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            
        } // End show drug name.


        // Search supplier name.
        public void searchSupplier()
        {
            searchSupplierTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchSupplierTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `supplier`.`name` AS 'name' FROM `supplier` JOIN `order_price_list` ON `supplier`.`id`=`order_price_list`.`supplier_id` GROUP BY `order_price_list`.`supplier_id`", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String name = reader.GetString("name");
                    collection.Add(name);
                }
                con.Close();
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while searching drug details............!", "DRUG DETAILS SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

            searchSupplierTextBox.AutoCompleteCustomSource = collection;
            
        }// End search drug.

        // Show supplier name.
        public void supplierData()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `supplier`.`name` AS 'name',`order_price_list`.`supplier_id` AS 'supplier_id' FROM `supplier` JOIN `order_price_list` ON `supplier`.`id`=`order_price_list`.`supplier_id`  WHERE `supplier`.`name`='" + this.searchSupplierTextBox.Text + "' GROUP BY `order_price_list`.`drug_id`", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String name = reader.GetString("name");
                    String supplier_id = reader.GetString("supplier_id");

                    searchSupplierTextBox.Text = name;
                    supplieridforeignkey.Text = supplier_id;

                }
                con.Close();
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
                //MessageBox.Show("Error has occured while searching order list price............!", "ORDER PRICE SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            
        } // End show drug name.

        public void getDrugID()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `drug`.`id` AS 'id' FROM `supplier` JOIN `supplier_price_list` ON `supplier`.`id`=`supplier_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`supplier_price_list`.`drug_id` WHERE `drug`.`name`='" + this.searchDrugTextBox.Text + "' GROUP BY `supplier_price_list`.`drug_id`", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String id = reader.GetInt64("id").ToString();

                    drugidforeignkey.Text = id;

                }
                con.Close();
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
                //MessageBox.Show("Error has occured while searching order list price............!", "ORDER PRICE SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            
        }



        // Get quantity to textbox.
        // Show quantity .
        public void quantityData()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `quantity` FROM `order_price_list`  WHERE (`order_price_list`.`supplier_id`='" + this.supplieridforeignkey.Text + "' AND `order_price_list`.`drug_id`='" + this.drugidforeignkey.Text + "')", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {

                    String quantity = reader.GetString("quantity");

                    quantityTextBox.Text = quantity;
                   
                }
                con.Close();
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
                //MessageBox.Show("Error has occured while searching order list price............!", "ORDER PRICE SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            
        } // End show quantity.


        private void UpdateOrderList_Load(object sender, EventArgs e)
        {

        }

        // display order price list.
        private void orderListGridView()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER',`drug`.`name` AS 'DRUG',`order_price_list`.`price` AS 'PRICE', `order_price_list`.`quantity` AS 'QUANTITY',ROUND((`order_price_list`.`price`*`order_price_list`.`quantity`),2) AS 'TOTAL' FROM `supplier` JOIN `order_price_list` ON `supplier`.`id`=`order_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`order_price_list`.`drug_id`  ORDER BY `supplier`.`name` ASC", con);

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

                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(otherSuppliersOrderListDataGridView.Rows.Count) - 1;
                AllSuppliersRowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            
            getSupplierListAmount();
        }

        // display minimum price list.
        private void minimumPriceList()
        {
            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER',`drug`.`name` AS 'DRUG',`min_order_price_list`.`price` AS 'PRICE', `min_order_price_list`.`quantity` AS 'QUANTITY',ROUND((`min_order_price_list`.`price`*`min_order_price_list`.`quantity`),2) AS 'TOTAL' FROM `supplier` JOIN `min_order_price_list` ON `supplier`.`id`=`min_order_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`min_order_price_list`.`drug_id`  ORDER BY `supplier`.`name` ASC", con);
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
                supplierPriceListDataGridView.DataSource = bs;

                a.Update(dataTable);

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



        //print pdf for order price list.
        public void orderPriceList()
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

        private void searchDrugTextBox_TextChanged(object sender, EventArgs e)
        {
            drugData();
            getDrugID();
        }

        private void searchSupplierTextBox_TextChanged(object sender, EventArgs e)
        {
            supplierData();
            quantityData();
        }

        private void searchSupplierPriceListButton_Click(object sender, EventArgs e)
        {
            quantityData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (searchDrugTextBox.Text == string.Empty || searchSupplierTextBox.Text == string.Empty || supplieridforeignkey.Text == string.Empty || drugidforeignkey.Text == string.Empty || quantityTextBox.Text == string.Empty )
            {

                MessageBox.Show("Please fill all the required fields...............!", "ORDER LIST QUANTITY UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    DateTime dt = DateTime.Now;
                    string date = dt.ToString("yyyy-MM-dd");

                    dialog = MessageBox.Show("Are you sure you want to update the quantity?", "ORDER LIST QUANTITY UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();

                        // Update the order list first.
                        MySqlCommand c = new MySqlCommand("UPDATE order_price_list SET `order_price_list`.`quantity` ='" + this.quantityTextBox.Text + "'  WHERE (`order_price_list`.`supplier_id`='" + this.supplieridforeignkey.Text + "' AND `order_price_list`.`drug_id`='" + this.drugidforeignkey.Text + "')", con);

                        c.ExecuteNonQuery();

                        // Update the minimal order list first.
                        MySqlCommand minimalOrderList = new MySqlCommand("UPDATE min_order_price_list SET `min_order_price_list`.`quantity` ='" + this.quantityTextBox.Text + "'  WHERE (`min_order_price_list`.`supplier_id`='" + this.supplieridforeignkey.Text + "' AND `min_order_price_list`.`drug_id`='" + this.drugidforeignkey.Text + "')", con);

                        minimalOrderList.ExecuteNonQuery();

                        MessageBox.Show("Order list quantity updated successfully...............!", "ORDER LIST QUANTITY UPDATE ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Insert to events
                        //current date
                        DateTime curdate = DateTime.Now;
                        String dateCurrent = curdate.ToString("yyyy-MM-dd");

                        MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.pfsession.Text + "','" + dateCurrent + "','updated order list for supplier ''" + this.supplieridforeignkey.Text + "')", con);
                        me.ExecuteNonQuery();
                        // End inserting to events.

                        con.Close();
                        
                        minimumPriceList();
                        orderListGridView();
                        
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error has occured while updating order list quantity............!", "ORDER LIST QUANTITY UPDATE ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (searchDrugTextBox.Text == string.Empty || searchSupplierTextBox.Text == string.Empty || supplieridforeignkey.Text == string.Empty || drugidforeignkey.Text == string.Empty || quantityTextBox.Text == string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "ORDER LIST DELETE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    DateTime dt = DateTime.Now;
                    string date = dt.ToString("yyyy-MM-dd");

                    dialog = MessageBox.Show("Are you sure you want to remove the drug?", "ORDER LIST DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();

                        // delete the order list first.
                        MySqlCommand c = new MySqlCommand("DELETE FROM `order_price_list` WHERE (`order_price_list`.`supplier_id`='" + this.supplieridforeignkey.Text + "' AND `order_price_list`.`drug_id`='" + this.drugidforeignkey.Text + "')", con);

                        c.ExecuteNonQuery();

                        // delete the minimal order list first.
                        MySqlCommand minimalOrderList = new MySqlCommand("DELETE FROM `min_order_price_list`  WHERE (`min_order_price_list`.`supplier_id`='" + this.supplieridforeignkey.Text + "' AND `min_order_price_list`.`drug_id`='" + this.drugidforeignkey.Text + "')", con);

                        minimalOrderList.ExecuteNonQuery();

                        MessageBox.Show("Order list removed successfully...............!", "ORDER LIST DELETE ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Insert to events
                        //current date
                        DateTime curdate = DateTime.Now;
                        String dateCurrent = curdate.ToString("yyyy-MM-dd");

                        MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.pfsession.Text + "','" + dateCurrent + "','removed order list for supplier ''" + this.supplieridforeignkey.Text + "')", con);
                        me.ExecuteNonQuery();
                        // End inserting to events.

                        con.Close();

                        minimumPriceList();
                        orderListGridView();

                    }

                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                    //MessageBox.Show("Error has occured while deleting order list ............!", "ORDER LIST DELETE ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }

            }
        }
    }
}
