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
    public partial class OrderList : Form
    {
       // MySqlConnection con = null;
        DataTable dataTableMinimalTemp, dataTableMin,dataTableOrder, dataTableOtherSuppliersTemp;
        DialogResult dialog;
        public OrderList(string user)
        {
            InitializeComponent();
           // con = DBHandler.CreateConnection();
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

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `drug`.`name` AS 'name' FROM `drug` JOIN `supplier_price_list` ON `drug`.`id`=`supplier_price_list`.`drug_id` GROUP BY `supplier_price_list`.`drug_id` ORDER BY `drug`.`name` ASC", con);
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

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `drug`.`name` AS 'name' FROM `drug` JOIN `supplier_price_list` ON `drug`.`id`=`supplier_price_list`.`drug_id`  WHERE `drug`.`name`='" + this.searchDrugTextBox.Text + "' ", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String name = reader.GetString("name");

                    searchDrugTextBox.Text = name;

                }
                con.Close();
            }
            catch (Exception )
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

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `supplier`.`name` AS 'name' FROM `supplier` JOIN `order_price_list` ON `supplier`.`id`=`order_price_list`.`supplier_id`", con);
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

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `supplier`.`name` AS 'name',`supplier`.`id` AS 'id' FROM `supplier` JOIN `order_price_list` ON `supplier`.`id`=`order_price_list`.`supplier_id`  WHERE `supplier`.`name`='" + this.searchSupplierTextBox.Text + "'", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String name = reader.GetString("name");
                    String id = reader.GetString("id");

                    searchSupplierTextBox.Text = name;
                    supplieridforeignkey.Text = id;

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


        // Add minimal price item on list to data grid that will be later used to insert data to database.
        public void getMinimalPriceListItemToDatagridView()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT  `supplier_price_list`.`supplier_id` AS 'supplier_id',`supplier_price_list`.`drug_id` AS 'drug_id',`supplier_price_list`.`price` AS 'price' FROM  `supplier_price_list` WHERE `supplier_price_list`.`drug_id`='" + this.drugidforeignkey.Text + "' AND `supplier_price_list`.`price`='" + this.minPriceTextBox.Text + "'", con);
                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTableMinimalTemp = new DataTable();

                a.Fill(dataTableMinimalTemp);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTableMinimalTemp;
                minimuListDataGridView.DataSource = bs;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Error has occured while searching order list price............!", "ORDER PRICE SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            
        }

        // get minimal price .
        public void getMinimalPrice()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT ROUND(MIN(`supplier_price_list`.`price`),2) AS 'min_price' FROM  `supplier_price_list` WHERE `supplier_price_list`.`drug_id`='" + this.drugidforeignkey.Text + "'", con);
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    String min_price = reader.GetString("min_price");

                    minPriceTextBox.Text = min_price;

                }
                con.Close();
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
              // MessageBox.Show("Error has occured while searching minimum list price............!", "ORDER PRICE SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            
        }

        private void OrderList_Load(object sender, EventArgs e)
        {

        }
       

        private void searchDrugTextBox_TextChanged(object sender, EventArgs e)
        {
            drugData();
            getDrugID();
            getMinimalPrice();
            getMinimalPriceListItemToDatagridView(); // Load datagrid.  /// This method is invoke inside the minimum textbox display since it requires data from the minimum drug price before loading the datagrid.
            getPriceListItemToDatagridView(); // Load other suppliers price list to datagrid.
        }

        private void minPriceTextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        // Save price list to database.
        public void saveMinimalPriceList() {

            //current date
            DateTime curdate = DateTime.Now;
            String dateCurrent = curdate.ToString("yyyy-MM-dd");

            if (searchDrugTextBox.Text == string.Empty || quantityTextBox.Text == string.Empty || drugidforeignkey.Text == string.Empty || minPriceTextBox.Text == string.Empty || pfsession.Text == string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "ORDER LIST", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    dialog = MessageBox.Show("Are you sure you want to add the drug to order list?", "ORDER LIST", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();
                        MySqlCommand c = new MySqlCommand("INSERT INTO min_order_price_list VALUES(@supplier_id,@drug_id,@price,'" + this.quantityTextBox.Text + "','" + dateCurrent + "','" + this.pfsession.Text + "')", con);

                        foreach (DataRow row in dataTableMinimalTemp.Rows)
                        {

                            c.Parameters.Clear();
                            c.Parameters.AddWithValue("@supplier_id", row["supplier_id"]);
                            c.Parameters.AddWithValue("@drug_id", row["drug_id"]);
                            c.Parameters.AddWithValue("@price", row["price"]);

                            c.ExecuteNonQuery();
                        }

                        // Insert to events
                        //current date
                       
                     //   MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.pfsession.Text + "','" + dateCurrent + "','added order list with quantity. ''" + this.quantityTextBox.Text + "')", con);
                     //   me.ExecuteNonQuery();
                        // End inserting to events.
                        con.Close();
                    }

                    
                }
                catch (Exception ex )
                {
                    MessageBox.Show(ex.Message);
                    // MessageBox.Show("Error has occured while adding price list details............!", "ORDER LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
              
                }
            }
            
        }

        public void clearList() { 

        searchDrugTextBox.Text = string.Empty ;
        quantityTextBox.Text = string.Empty ;
        drugidforeignkey.Text = string.Empty;
        minPriceTextBox.Text = string.Empty ;
       }

        // display minimum price list.
        private void minimumPriceList()
        {
            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER',`drug`.`name` AS 'DRUG',`min_order_price_list`.`price` AS 'PRICE',ROUND(( `min_order_price_list`.`quantity`),0) AS 'QUANTITY',ROUND((`min_order_price_list`.`price`*`min_order_price_list`.`quantity`),2) AS 'TOTAL' FROM `supplier` JOIN `min_order_price_list` ON `supplier`.`id`=`min_order_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`min_order_price_list`.`drug_id`  ORDER BY `supplier`.`name` ASC", con);
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

        private void searchSupplierPriceListButton_Click(object sender, EventArgs e)
        {
            saveMinimalPriceList();
            savePriceList(); // This method add price lists to the database for other suppliers.
            clearList();
            minimumPriceList();
            minimumSupplier();

        }

        /// Other suppliers price list order starts here.
        /// 
        /// 
        /// 
        /// ////////////////////////////
        /// 


        // getPriceListItems.
        public void getPriceListItemToDatagridView()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT  `supplier_price_list`.`supplier_id` AS 'supplier_id',`supplier_price_list`.`drug_id` AS 'drug_id',`supplier_price_list`.`price` AS 'price' FROM  `supplier_price_list` WHERE `supplier_price_list`.`drug_id`='" + this.drugidforeignkey.Text + "' ", con);
                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTableOtherSuppliersTemp = new DataTable();

                a.Fill(dataTableOtherSuppliersTemp);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTableOtherSuppliersTemp;
                otherSuppliersPriceListDataGridView.DataSource = bs;
                con.Close();
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
                //MessageBox.Show("Error has occured while searching order list price............!", "ORDER PRICE SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            
        }



        // Save price list to database.
        public void savePriceList()
            {
            
            //current date
            DateTime curdate = DateTime.Now;
            String dateCurrent = curdate.ToString("yyyy-MM-dd");

           try{
               MySqlConnection con = new MySqlConnection(db);
               con.Open();
                        MySqlCommand c = new MySqlCommand("INSERT INTO order_price_list VALUES(@supplier_id,@drug_id,@price,'" + this.quantityTextBox.Text + "','" + dateCurrent + "','" + this.pfsession.Text + "')", con);

                        foreach (DataRow row in dataTableOtherSuppliersTemp.Rows)
                        {

                            c.Parameters.Clear();
                            c.Parameters.AddWithValue("@supplier_id", row["supplier_id"]);
                            c.Parameters.AddWithValue("@drug_id", row["drug_id"]);
                            c.Parameters.AddWithValue("@price", row["price"]);

                            c.ExecuteNonQuery();
                        }
                        con.Close();
                }
                catch (Exception)
                {
                   // MessageBox.Show(ex.Message);
                    // MessageBox.Show("Error has occured while adding price list details............!", "ORDER LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

                }
            
            

            orderListGridView();
        }


        // display order price list.
        private void orderListGridView()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER',`drug`.`name` AS 'DRUG',`order_price_list`.`price` AS 'PRICE', ROUND((`order_price_list`.`quantity`),0) AS 'QUANTITY',ROUND((`order_price_list`.`price`*`order_price_list`.`quantity`),2) AS 'TOTAL' FROM `supplier` JOIN `order_price_list` ON `supplier`.`id`=`order_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`order_price_list`.`drug_id`  ORDER BY `supplier`.`name` ASC", con);

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

            ;
            getSupplierListAmount();
        }

        // Search price list by supplier.
        private void searchOrderListBySupplier()
        {
            try
            {

                MySqlConnection con = new MySqlConnection(db);
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

        /// not implemented as for now.
        

        // Search price list by minimum supplier.
        private void minimumSupplier()
        {
            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER',`drug`.`name` AS 'DRUG',`order_price_list`.`price` AS 'PRICE', ROUND((`order_price_list`.`quantity`),0) AS 'QUANTITY',ROUND((`order_price_list`.`price`*`order_price_list`.`quantity`),2) AS 'TOTAL' FROM `supplier` JOIN `order_price_list` ON `supplier`.`id`=`order_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`order_price_list`.`drug_id` WHERE `supplier`.`name`='" + this.searchSupplierTextBox.Text + "' GROUP BY `order_price_list`.`drug_id` ORDER BY `supplier`.`name` ASC", con);

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

            

        }


      
        private void button8_Click(object sender, EventArgs e)
        {
            orderListGridView();
        }

        private void searchSupplierTextBox_TextChanged(object sender, EventArgs e)
        {
            supplierData();
            searchOrderListBySupplier();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            searchOrderListBySupplier();
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

        private void button6_Click(object sender, EventArgs e)
        {
            orderPriceList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            minimalOrderPriceList();
        }

        // Insert to order price list hitory.
            private void saveToOrderPriceListHistory(){
            

                //current date
            DateTime curdate = DateTime.Now;
            String dateCurrent = curdate.ToString("yyyy-MM-dd");

           
                try
                {

                    MySqlConnection con = new MySqlConnection(db);
                    con.Open();
                        MySqlCommand c = new MySqlCommand("INSERT INTO order_price_list_history VALUES(@supplier_name,@drug_name,@price,@quantity,'" + dateCurrent + "','" + this.pfsession.Text + "')", con);

                        foreach (DataRow row in dataTableOrder.Rows)
                        {

                            c.Parameters.Clear();
                            c.Parameters.AddWithValue("@supplier_name", row["SUPPLIER"]);
                            c.Parameters.AddWithValue("@drug_name", row["DRUG"]);
                            c.Parameters.AddWithValue("@price", row["PRICE"]);
                            c.Parameters.AddWithValue("@quantity", row["QUANTITY"]);

                            c.ExecuteNonQuery();
                        }

                        con.Close();
                }
                catch (Exception )
                {
                    //MessageBox.Show(ex.Message);
            }
           
        }

        // Insert to min order price list hitory.
            private void saveToMinOrderPriceListHistory(){
            

                //current date
            DateTime curdate = DateTime.Now;
            String dateCurrent = curdate.ToString("yyyy-MM-dd");

           
                try
                {

                    MySqlConnection con = new MySqlConnection(db);
                    con.Open();
                        MySqlCommand c = new MySqlCommand("INSERT INTO min_order_price_list_history VALUES(@supplier_name,@drug_name,@price,@quantity,'" + dateCurrent + "','" + this.pfsession.Text + "')", con);

                        foreach (DataRow row in dataTableMin.Rows)
                        {

                            c.Parameters.Clear();
                            c.Parameters.AddWithValue("@supplier_name", row["SUPPLIER"]);
                            c.Parameters.AddWithValue("@drug_name", row["DRUG"]);
                            c.Parameters.AddWithValue("@price", row["PRICE"]);
                            c.Parameters.AddWithValue("@quantity", row["QUANTITY"]);

                            c.ExecuteNonQuery();
                        }

                        con.Close();
                }
                catch (Exception )
                {
                 
            }
           
        }

        // Delete from order_price_list table.
        private void deleteOrderPriceList(){
           try
                {

                    MySqlConnection con = new MySqlConnection(db);
                    con.Open();
                        MySqlCommand c = new MySqlCommand("DELETE FROM order_price_list", con);

                            c.ExecuteNonQuery();
                            con.Close();
                }
                catch (Exception )
                {
                   
            }
            
        
        }

          // Delete from min_order_price_list table.
        private void deleteMinOrderPriceList(){
           try
                {
                    MySqlConnection con = new MySqlConnection(db);
                    con.Open();
                        MySqlCommand c = new MySqlCommand("DELETE FROM min_order_price_list", con);

                            c.ExecuteNonQuery();

                            MessageBox.Show("Data cleared  successfully...............!", "NEW ORDER LIST ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Insert to events
                            //current date
                          //  DateTime curdate = DateTime.Now;
                          //  String dateCurrent = curdate.ToString("yyyy-MM-dd");

                            //MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.pfsession.Text + "','" + dateCurrent + "','Created new order list. ')", con);
                           // me.ExecuteNonQuery();
                    // End inserting to events.
                            con.Close();
                }
                catch (Exception )
                {
                   
            }
           
        
        }



        private void button1_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show("Are you sure you want to clear the list?", "NEW ORDER LIST", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {

                saveToOrderPriceListHistory();
                deleteOrderPriceList();
                saveToMinOrderPriceListHistory();
                deleteMinOrderPriceList();
                minimumPriceList();
                orderListGridView();

            }
            else {
                deleteOrderPriceList();
                deleteMinOrderPriceList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewOrderList view = new ViewOrderList();
            view.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ViewOrderList view = new ViewOrderList();
            view.ShowDialog();
        }

        private void AllSuppliersRowCountLabel_Click(object sender, EventArgs e)
        {

        }

    }
}
