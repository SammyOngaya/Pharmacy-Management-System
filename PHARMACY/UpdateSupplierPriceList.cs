using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PHARMACY
{
    public partial class UpdateSupplierPriceList : Form
    {
        //MySqlConnection con = null;
        DialogResult dialog;
        public UpdateSupplierPriceList(string user)
        {
            InitializeComponent();
           /// con = DBHandler.CreateConnection();
            pfsession.Text = user;
            supplierCombo();
            displayPriceListRecords();
            searchDrug();
        }
        String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
        //populate supplier combo
        public void supplierCombo()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("select * from supplier WHERE status='Active' ORDER BY name ASC", con);

                MySqlDataReader m = c.ExecuteReader();

                while (m.Read())
                {
                    String l = m.GetString("name");
                    addSupplierCombo.Items.Add(l);



                }
                con.Close();
            }
            catch (Exception) { 
            }
        }
       

        private void AddSupplierPriceList_Load(object sender, EventArgs e)
        {

        }


        private void displayPriceListRecords()
        {
            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER',`drug`.`name` AS 'DRUG',`supplier_price_list`.`price` AS 'PRICE' FROM `supplier` JOIN `supplier_price_list` ON `supplier`.`id`=`supplier_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`supplier_price_list`.`drug_id` ORDER BY `supplier`.`name` ASC", con);

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
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            

        }


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

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `drug`.`name` AS 'name' FROM `drug` JOIN `supplier_price_list` ON `drug`.`id`=`supplier_price_list`.`drug_id` WHERE `drug`.`status`='Active' ORDER BY `drug`.`name` ASC", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String name = reader.GetString("name");
                    collection.Add(name);
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while searching drug details............!", "DRUG DETAILS SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
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
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
               //MessageBox.Show("Error has occured while searching order list price............!", "ORDER PRICE SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
           
        } // End show drug name.

        public void getDrugID() {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `drug`.`id` AS 'id' FROM `supplier` JOIN `supplier_price_list` ON `supplier`.`id`=`supplier_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`supplier_price_list`.`drug_id` WHERE `drug`.`name`='" + this.searchDrugTextBox.Text + "' GROUP BY `supplier_price_list`.`drug_id`", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    

                    String id = reader.GetInt64("id").ToString();

                    drugIDTextBox.Text = id;

                }
                con.Close();
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
                //MessageBox.Show("Error has occured while searching order list price............!", "ORDER PRICE SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
           
        }

        // Show drug price.
        public void drugPrice()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `supplier_price_list`.`price` AS 'price' FROM `supplier` JOIN `supplier_price_list` ON `supplier`.`id`=`supplier_price_list`.`supplier_id` JOIN `drug` ON `drug`.`id`=`supplier_price_list`.`drug_id` WHERE `supplier`.`name`='" + this.addSupplierCombo.Text + "' AND `drug`.`name`='" + this.searchDrugTextBox.Text + "'", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String price = reader.GetString("price");

                    PriceTextBox.Text = price;

                }
                con.Close();
            }
            catch (Exception )
            {
                 MessageBox.Show("Error has occured while searching order list price............!", "ORDER PRICE SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            
        } // End show drug name.



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PriceTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateSupplierPriceList_Load(object sender, EventArgs e)
        {

        }

        private void searchDrugTextBox_TextChanged(object sender, EventArgs e)
        {
            drugData();
            getDrugID();
            drugPrice();

        }

        private void searchSupplierPriceListButton_Click(object sender, EventArgs e)
        {
            drugData();
            drugPrice();
        }

        private void saveSupplierPriceListButton_Click(object sender, EventArgs e)
        {
            if (addSupplierCombo.Text == string.Empty || PriceTextBox.Text == string.Empty || searchDrugTextBox.Text == string.Empty )
            {

                MessageBox.Show("Please fill all the required fields...............!", "SUPPLIER ORDER LIST UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    DateTime dt = DateTime.Now;
                    string date = dt.ToString("yyyy-MM-dd");

                    dialog = MessageBox.Show("Are you sure you want to update the price?", "SUPPLIER ORDER LIST UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();

                        // Update price.
                      MySqlCommand c = new MySqlCommand("UPDATE supplier_price_list SET `supplier_price_list`.`price` ='" + this.PriceTextBox.Text + "'  WHERE `supplier_price_list`.`supplier_id`='" + this.supplierIDTextBox.Text + "' AND `supplier_price_list`.`drug_id`='" + this.drugIDTextBox.Text + "'", con);

                      c.ExecuteNonQuery();

                        MessageBox.Show("Price list details updated successfully...............!", "SUPPLIER ORDER LIST UPDATE ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Insert to events
                        //current date
                        DateTime curdate = DateTime.Now;
                        String dateCurrent = curdate.ToString("yyyy-MM-dd");

                        MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.pfsession.Text + "','" + dateCurrent + "','updated order list for supplier ''" + this.addSupplierCombo.Text + "')", con);
                        me.ExecuteNonQuery();
                        // End inserting to events.

                        con.Close();
                        displayPriceListRecords();
                    }
                   
                }
                catch (Exception)
                {
                    MessageBox.Show("Error has occured while registering price list details............!", "SUPPLIER ORDER LIST REGISTRATION", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                
            }


        }

        private void addSupplierCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplierForeignKey();
        }

        //fetch id from supplier and use the foreign key
        public void supplierForeignKey()
        {

            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM supplier WHERE name='" + this.addSupplierCombo.Text + "'", con);
                MySqlDataReader n = mc.ExecuteReader();

                while (n.Read())
                {
                    String supid = n.GetInt32("id").ToString();
                    supplierIDTextBox.Text = supid;

                }


                con.Close();

            }
            catch (Exception)
            {

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (addSupplierCombo.Text == string.Empty || PriceTextBox.Text == string.Empty || searchDrugTextBox.Text == string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "SUPPLIER ORDER LIST DELETE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    DateTime dt = DateTime.Now;
                    string date = dt.ToString("yyyy-MM-dd");

                    dialog = MessageBox.Show("Are you sure you want to remove the price list?", "SUPPLIER ORDER LIST DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();

                        // Update price.
                        MySqlCommand c = new MySqlCommand("DELETE FROM supplier_price_list  WHERE `supplier_price_list`.`supplier_id`='" + this.supplierIDTextBox.Text + "' AND `supplier_price_list`.`drug_id`='" + this.drugIDTextBox.Text + "'", con);

                        c.ExecuteNonQuery();


                        MessageBox.Show("Price list details removed successfully...............!", "SUPPLIER ORDER LIST DELETE ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        // Insert to events
                        //current date
                        DateTime curdate = DateTime.Now;
                        String dateCurrent = curdate.ToString("yyyy-MM-dd");

                        MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.pfsession.Text + "','" + dateCurrent + "','removed supplier order list for supplier ''" + this.addSupplierCombo.Text + "')", con);
                        me.ExecuteNonQuery();
                        // End inserting to events.

                        con.Close();
                        displayPriceListRecords();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error has occured while removing price list details............!", "SUPPLIER ORDER LIST DELETE", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
