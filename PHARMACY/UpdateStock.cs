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
    public partial class UpdateStock : Form
    {
        //MySqlConnection con = null;
        public UpdateStock(String pfn)
        {
            InitializeComponent();
         
            updatestockpfsession.Text = pfn;
            supplierCombo();
            drugCombo();
            viewStock();
            searchStock();
            searchDrug();
            //showStockData();

        }
        String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
        DataTable dataTable;
        DialogResult dialog;

        //filter database
        public void filterDatabase()
        {
            DataView dv = new DataView(dataTable);
            dv.RowFilter = string.Format("batch_no LIKE '%{0}%'", searchUpdateStock.Text);
            updateStockdataGridView.DataSource = dv;
        }


        //clear fields
        public void clearFields()
        {
            updateSupplierCombo.Text = string.Empty;
            originalQuantityTextBox.Text = string.Empty;
            updateStockBuyingPrice.Text = string.Empty;
            updateStockSellingPrice.Text = string.Empty;
            updateDrugCombo.Text = string.Empty;
            updateStockUnit.Text = string.Empty;
            updateStockExpiriDate.Text = string.Empty;
            updateStockBatchNo.Text = string.Empty;
            supplieridforeignkey.Text = string.Empty;
            drugidforeignkey.Text = string.Empty;
            updateStockId.Text = string.Empty;
            StatuscomboBox.Text = string.Empty;
            remainingQuantityTextBox.Text = string.Empty;
            quantitySoldTextBox.Text = string.Empty;
            drugNameTextBox.Text = string.Empty;
            searchUpdateStock.Text = string.Empty;
            stockIDTextBox.Text = string.Empty;
            updateStockId.Text = string.Empty;
            quantityCheckWarningLabel.Text = string.Empty;
            reoderLevelTextBox.Text = string.Empty;
        }



        //search drug from netsock
        public void searchDrug()
        {
            drugNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            drugNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");
                 MySqlCommand c = new MySqlCommand("select `drug`.`id`,`drug`.`name` FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` GROUP BY `stock`.`drug_id` ORDER BY `drug`.`name` ASC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string l = r.GetString("name");
                    collection.Add(l);

                }
                con.Close();
            }
            catch (Exception)
            {

            }

            drugNameTextBox.AutoCompleteCustomSource = collection;


        }


        //search drug from netsock
        public void drugData()
        {

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");
                MySqlCommand c = new MySqlCommand("SELECT * FROM drug WHERE name='" + this.drugNameTextBox.Text + "'", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string id = r.GetString("id");
                    drugidforeignkey.Text = id;

                }
                con.Close();
            }
            catch (Exception)
            {

            }
        }


        //view stock
        public void viewStock()
        {
            DateTime dtt = DateTime.Now;
            String dateNow = dtt.ToString("yyyy-MM-dd");

            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`drug`.`name` AS 'DRUG NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED',`stock`.`reoder_level` AS 'RE-ODER LEVEL' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE ((`stock`.`status`=1) AND (`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0)) ORDER BY `drug`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("RE-ODER LEVEL");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                updateStockdataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(updateStockdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        // Filter stock by drug name.
        public void filterStockByDrugName()
        {

            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`drug`.`name` AS 'DRUG NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED',`stock`.`reoder_level` AS 'RE-ODER LEVEL' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE (`drug`.`name`='" + this.drugNameTextBox.Text + "') AND `stock`.`status`=1 ORDER BY `stock`.`registered_date` DESC", con);

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
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("RE-ODER LEVEL");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.


                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                updateStockdataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(updateStockdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }




        //search stock from stock
        public void searchStock()
        {
            searchUpdateStock.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchUpdateStock.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("select * from stock WHERE status='1' ", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string l = r.GetString("batch_no");
                    collection.Add(l);


                }
                con.Close();
            }
            catch (Exception) { 
            
            }
            searchUpdateStock.AutoCompleteCustomSource = collection;


        }


        //fill data in fields
        public void showStockData()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT `stock`.`stock_id`, `drug`.`id`,`supplier`.`id`,`stock`.`status` AS 'status',`stock`.`supplier_id`  AS supplier_id ,`stock`.`drug_id`  AS drug_id,`drug`.`name` as 'drugname',`stock`.`initial_quantity` ,(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'remaining_quantity',`stock`.`quantity_sold` AS 'quantity_sold' ,`stock`.`buying_price` AS 'buying_price',`stock`.`selling_price` AS 'selling_price',batch_no,expiry_date,`supplier`.`id`,`supplier`.`name` as suppliername,`stock`.`units`,`stock`.`reoder_level` AS 'reoder_level' FROM drug JOIN stock on `drug`.`id`=`stock`.`drug_id` JOIN supplier on `supplier`.`id`=`stock`.`supplier_id` WHERE (drug_id='" + this.drugidforeignkey.Text + "' AND batch_no='" + this.searchUpdateStock.Text + "' AND stock_id='" + this.stockIDTextBox.Text + "' )", con);
              
                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {

                    string stockID = r.GetString("stock_id");
                    String supplier_id = r.GetString("supplier_id");
                    String drug_id = r.GetString("drug_id");
                    String sp = r.GetString("suppliername");
                    String dr = r.GetString("drugname");
                    String qty = r.GetString("initial_quantity");
                    String bp = r.GetString("buying_price");
                    String spr = r.GetString("selling_price");
                    String units = r.GetString("units");
                    String expdate = r.GetString("expiry_date");
                    String bt = r.GetString("batch_no");
                    string status = r.GetString("status");
                    string quantittSold = r.GetString("quantity_sold");
                    string remainingQuantity = r.GetString("remaining_quantity");
                    string reoderLevel = r.GetString("reoder_level");

                    updateStockId.Text = stockID;
                    originalQuantityTextBox.Text = qty;
                    updateStockBuyingPrice.Text = bp;
                    updateStockSellingPrice.Text = spr;
                    updateStockUnit.Text = units;
                    updateStockExpiriDate.Text = expdate;
                    updateStockBatchNo.Text = bt;
                    updateSupplierCombo.Text = sp;
                    updateDrugCombo.Text = dr;
                    StatuscomboBox.Text = status;
                    quantitySoldTextBox.Text = quantittSold;
                    supplieridforeignkey.Text = supplier_id;
                    remainingQuantityTextBox.Text = remainingQuantity;
                    drugidforeignkey.Text = drug_id;
                    reoderLevelTextBox.Text = reoderLevel;


                }
                con.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        // Fill data in fields.
        public void showStockDataFilterByStockOnly()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT `stock`.`stock_id`, `drug`.`id`,`supplier`.`id`,`stock`.`status` AS 'status',`stock`.`supplier_id`  AS supplier_id ,`stock`.`drug_id`  AS drug_id,`drug`.`name` as 'drugname',`stock`.`initial_quantity` ,(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'remaining_quantity',`stock`.`quantity_sold` AS 'quantity_sold' ,`stock`.`buying_price` AS 'buying_price',`stock`.`selling_price` AS 'selling_price',batch_no,expiry_date,`supplier`.`id`,`supplier`.`name` as suppliername,`stock`.`units`,`stock`.`reoder_level` AS 'reoder_level' FROM drug JOIN stock on `drug`.`id`=`stock`.`drug_id` JOIN supplier on `supplier`.`id`=`stock`.`supplier_id` WHERE (stock_id='" + this.stockIDTextBox.Text + "' )", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {

                    string stockID = r.GetString("stock_id");
                    String supplier_id = r.GetString("supplier_id");
                    String drug_id = r.GetString("drug_id");
                    String sp = r.GetString("suppliername");
                    String dr = r.GetString("drugname");
                    String qty = r.GetString("initial_quantity");
                    String bp = r.GetString("buying_price");
                    String spr = r.GetString("selling_price");
                    String units = r.GetString("units");
                    String expdate = r.GetString("expiry_date");
                    String bt = r.GetString("batch_no");
                    string status = r.GetString("status");
                    string quantittSold = r.GetString("quantity_sold");
                    string remainingQuantity = r.GetString("remaining_quantity");
                    string reoderLevel = r.GetString("reoder_level");

                    updateStockId.Text = stockID;
                    originalQuantityTextBox.Text = qty;
                    updateStockBuyingPrice.Text = bp;
                    updateStockSellingPrice.Text = spr;
                    updateStockUnit.Text = units;
                    updateStockExpiriDate.Text = expdate;
                    updateStockBatchNo.Text = bt;
                    updateSupplierCombo.Text = sp;
                    updateDrugCombo.Text = dr;
                    StatuscomboBox.Text = status;
                    quantitySoldTextBox.Text = quantittSold;
                    supplieridforeignkey.Text = supplier_id;
                    remainingQuantityTextBox.Text = remainingQuantity;
                    drugidforeignkey.Text = drug_id;
                    reoderLevelTextBox.Text = reoderLevel;

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //update Stock

        public void updateStock()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                
                string expiryDate= updateStockExpiriDate.Value.ToString("yyyy-MM-dd");

                MySqlCommand c = new MySqlCommand("UPDATE `stock` SET supplier_id='" + this.supplieridforeignkey.Text + "', initial_quantity='" + this.originalQuantityTextBox.Text + "', pfno='" + this.updatestockpfsession.Text + "',buying_price='" + this.updateStockBuyingPrice.Text + "',selling_price='" + this.updateStockSellingPrice.Text + "',units='" + this.updateStockUnit.Text + "' , expiry_date='" + expiryDate + "', drug_id='" + this.drugidforeignkey.Text + "' , batch_no='" + this.updateStockBatchNo.Text + "', status='" + this.StatuscomboBox.Text + "',reoder_level='" + this.reoderLevelTextBox.Text+ "'  WHERE stock_id='" + this.updateStockId.Text + "' ", con);

                c.ExecuteNonQuery();

                MessageBox.Show("Stock Updated successfully","STOCK UPDATE",MessageBoxButtons.OK,MessageBoxIcon.Information);

               
                con.Close();

                viewStock();
              
            }
            catch (Exception ex) {
                MessageBox.Show("Error while updating stock!!......................"+ex.Message);
            }

            viewStock();
        }

     


        //populate supplier combo
        public void supplierCombo()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("select * from supplier WHERE  status='Active'", con);

                MySqlDataReader m = c.ExecuteReader();

                while (m.Read())
                {
                    string l = m.GetString("name");
                    updateSupplierCombo.Items.Add(l);

                }
                con.Close();
            }
            catch (Exception) { 
            
            }
        }


        //populate drug combo
        public void drugCombo()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("select * from drug", con);

                MySqlDataReader mm = c.ExecuteReader();

                while (mm.Read())
                {
                    string l = mm.GetString("name");
                    updateDrugCombo.Items.Add(l);

                }

                con.Close();
            }
            catch (Exception) { 
            }
        }

        //fetch id from supplier and use the foreign key
        public void supplierForeignKey()
        {
            
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM supplier WHERE (name='" + this.updateSupplierCombo.Text + "' AND status='Active')", con);
                MySqlDataReader n = mc.ExecuteReader();

                while (n.Read())
                {
                    string supid = n.GetString("id");
                    supplieridforeignkey.Text = supid;

                }


                con.Close();

            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
            }


        }



        //fetch id from drug and use the foreign key
        public void drugForeignKey()
        {
           
            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM drug WHERE name='" + this.drugNameTextBox.Text + "' AND status='Active' ", con);
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {
                    string did = nn.GetString("id");
                    drugidforeignkey.Text = did;

                }

                con.Close();

            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
            }


        }

        private void addSupplierCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplierForeignKey();
        }

        private void addDrugCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            drugForeignKey();
        }

        private void searchUpdateStock_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(searchUpdateStock.Text, "[^ 0-9]"))
            {
                searchUpdateStock.Text = "";
            }
            
            //filterDatabase();
        }

        private void updateStockButton_Click(object sender, EventArgs e)
        {
            if (updateSupplierCombo.Text == string.Empty || updateDrugCombo.Text == string.Empty || originalQuantityTextBox.Text == string.Empty || updateStockUnit.Text == string.Empty || updateStockBuyingPrice.Text == string.Empty || updateStockSellingPrice.Text == string.Empty || this.updateStockExpiriDate.Text == string.Empty || this.updateStockBatchNo.Text == string.Empty || this.StatuscomboBox.Text == string.Empty || this.reoderLevelTextBox.Text==string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "STOCK UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                decimal originalQuantity = Convert.ToDecimal(originalQuantityTextBox.Text);
                decimal soldQuantity = Convert.ToDecimal(quantitySoldTextBox.Text);


                if (soldQuantity <= originalQuantity)
                {
                    //quantityCheckWarningLabel.Text = "You cannot add more stock";
                    //quantityCheckWarningLabel.ForeColor = Color.Red;

                    dialog = MessageBox.Show("Are you sure you want to update stock?", "UPDATE STOCK", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        updateStock();
                    }
                }
                else
                {
                    MessageBox.Show("You cannot update stock. The quantity sold is greater than the original stock you are updating?", "UPDATE STOCK ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                viewStock();
                clearFields();
            }
            
        }

        private void UpdateStock_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void updateStockBatchNo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(updateStockBatchNo.Text, "[^ 0-9]"))
            {
                updateStockBatchNo.Text = "";
            }
        }

        private void drugNameTextBox_TextChanged(object sender, EventArgs e)
        {
            drugForeignKey();
            filterStockByDrugName();
            //drugData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewStock();
        }

        private void stockIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(stockIDTextBox.Text, "[^ 0-9]"))
            {
                searchUpdateStock.Text = "";
            }
            showStockDataFilterByStockOnly();
            showStockData();
          
        }

        private void cancelStock_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        public void CheckQuantities()
        {
            try
            {

                decimal originalQuantity = Convert.ToDecimal(originalQuantityTextBox.Text);
                decimal soldQuantity = Convert.ToDecimal(quantitySoldTextBox.Text);

                if (soldQuantity > originalQuantity)
                {
                    quantityCheckWarningLabel.Text = "You cannot add stock less than the quantity sold.";
                    quantityCheckWarningLabel.ForeColor = Color.Red;
                }
                else {
                    quantityCheckWarningLabel.Text = string.Empty;
                }
            }
            catch (Exception)
            { 
            }
        }

        private void originalQuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckQuantities();
        }

        private void remainingQuantityTextBox_TextChanged(object sender, EventArgs e)
        {
          // CheckQuantities();
        }

        private void quantitySoldTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void reoderLevelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(reoderLevelTextBox.Text, "[^ 0-9]"))
            {
                reoderLevelTextBox.Text = "";
            }
        }
       
    }
}
