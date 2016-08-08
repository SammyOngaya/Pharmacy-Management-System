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
    public partial class AddStock : Form
    {
       // MySqlConnection con = null;

        public AddStock(String pfn)
        {
            InitializeComponent();
           // con = DBHandler.CreateConnection();
           

            addstockpfsession.Text = pfn;
            addStockView();


            supplierCombo();
            drugCombo();

            getCurrentBatchNo();

        }
        String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
        DialogResult dialog;


        // Get current batch no.
        private void getCurrentBatchNo()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*)  FROM stock WHERE drug_id='" + this.drugidforeignkey.Text + "'", con);

                MySqlCommand command = new MySqlCommand("SELECT MAX(batch_no) AS 'batch' FROM stock WHERE drug_id='" + this.drugidforeignkey.Text+ "'", con);
              

                Int64 count = (Int64)mc.ExecuteScalar();


                if (count >= 1)
                {

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String batch = reader.GetString("batch");
                        currentBatchTextBox.Text = batch;
                    }


                }
                else {
                    currentBatchTextBox.Text = "No stock";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        // Clear fields.
        public void clearFields()
        {
            addSupplierCombo.Text = string.Empty;
            addQuantity.Text = string.Empty;
            buyingPrice.Text = string.Empty;
            sellingPrice.Text = string.Empty;
            addDrugCombo.Text = string.Empty;
            addUnit.Text = string.Empty;
            addDate.Text = string.Empty;
            addBatchNo.Text = string.Empty;
            supplieridforeignkey.Text = string.Empty;
            drugidforeignkey.Text = string.Empty;

        }


        private void saveStock_Click(object sender, EventArgs e)
        {
            if (addSupplierCombo.Text == string.Empty || addQuantity.Text == string.Empty || buyingPrice.Text == string.Empty || sellingPrice.Text == string.Empty || addDrugCombo.Text == string.Empty || addDate.Text == string.Empty || this.addBatchNo.Text == string.Empty || reoderLevelTextBox.Text==string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "STOCK REGISTRATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    string expiryDate = addDate.Value.ToString("yyyy-MM-dd");

                    dialog = MessageBox.Show("Are you sure you want to add the stock ?", "STOCK REGISTRATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();
                        DateTime dt = DateTime.Now;
                        String dateNow = dt.ToString("yyyy-MM-dd");


                        //convert drug id to integer
                        //int dr = Convert.ToInt32(drugidforeignkey.Text);
                        //convert supplierforeignkey to integer
                       // int i = Convert.ToInt32(supplieridforeignkey.Text);

                        //insert into stock
                        MySqlCommand c = new MySqlCommand("INSERT INTO stock VALUES(NULL,'" + this.supplieridforeignkey.Text + "','" + this.addQuantity.Text + "','0.00','" + this.buyingPrice.Text + "','" + this.sellingPrice.Text + "','" + this.drugidforeignkey.Text + "','" + this.addUnit.Text + "','" + expiryDate + "','" + this.addBatchNo.Text + "','" + this.addstockpfsession.Text + "','" + dateNow + "','1','" + this.reoderLevelTextBox.Text+ "')", con);
                        c.ExecuteNonQuery();


                        MessageBox.Show("Stock registered successfully...............!", "STOCK  REGISTRATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        con.Close();
                       // updateNetstock();
                       // updateDrudPrice();
                        addStockView();
                        clearFields();
                        getCurrentBatchNo();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error has occured while registering stock details. Please check if you have entered all the fields ...........!", "STOCK DETAILS REGISTRATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }

            }
        }

        //update netStock
        public void updateNetstock()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
               // int drugid = Convert.ToInt32(drugidforeignkey.Text);
                MySqlCommand cmd = new MySqlCommand("SELECT  * FROM net_stock WHERE drug_id='" + this.drugidforeignkey.Text + "'", con);
                MySqlDataReader r;
                r = cmd.ExecuteReader();
                int c = 0;
                while (r.Read())
                {
                    c = c + 1;
                }
                r.Close();

                if (c == 0)
                {
                    Random rd = new Random();
                    int nsid = rd.Next(1, 1000000000);

                    MySqlCommand cmdi = new MySqlCommand("INSERT INTO net_stock VALUES('" + nsid + "','" + this.drugidforeignkey.Text + "', '" + this.addQuantity.Text + "', '" + this.addQuantity.Text + "', '" + this.addstockpfsession.Text + "','" + this.addUnit.Text + "','" + this.addDate.Value.Date.ToString("yyyy-MM-dd") + "')", con);
                    cmdi.ExecuteNonQuery();

                }
                else if (c == 1)
                {
                    // int newQty = Convert.ToInt32(addQuantity.Text);
                    MySqlCommand cmdU = new MySqlCommand("UPDATE net_stock set initial_quantity=(quantity + '" + this.addQuantity.Text + "'),quantity=(quantity + '" + this.addQuantity.Text + "'), pfno='" + this.addstockpfsession.Text + "',expiry_date='" + this.addDate.Value.Date.ToString("yyyy-MM-dd") + "' WHERE drug_id ='" + this.drugidforeignkey.Text + "'", con);
                    cmdU.ExecuteNonQuery();

                }
                else
                {
                    MessageBox.Show("Error has occured while updating net stock ............!", "NET STOCK UPDATE ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

                }


                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while updating net stock ............!", "NET STOCK UPDATE ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }
        }


        //update drug price
        public void updateDrudPrice()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                //int drugid = Convert.ToInt32(drugidforeignkey.Text);
                MySqlCommand cmd = new MySqlCommand("UPDATE drug SET price='" + this.sellingPrice.Text + "', buying_price='" + this.buyingPrice.Text+ "' WHERE id='" + this.drugidforeignkey.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception )
            {
               MessageBox.Show("Error has occured while updating drug price ............!", "DRUG PRICE UPDATE ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }
        }



        public void addStockView()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER NAME',`drug`.`name` AS 'DRUG NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED',`stock`.`reoder_level` AS 'RE-ODER LEVEL' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE `stock`.`status`='1' ORDER BY `drug`.`name` ASC", con);

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
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("RE-ODER LEVEL");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.
                
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                addStockdataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(addStockdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying drug stock ............!", "DRUG DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

           

        }

        //populate supplier combo
        public void supplierCombo()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM supplier WHERE status='Active' ORDER BY name ASC ", con);

                MySqlDataReader m = c.ExecuteReader();

                while (m.Read())
                {
                    String l = m.GetString("name");
                    addSupplierCombo.Items.Add(l);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //populate drug combo
        public void drugCombo()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM drug WHERE `drug`.`status`='Active' ORDER BY name ASC", con);

                MySqlDataReader mm = c.ExecuteReader();

                while (mm.Read())
                {
                    String l = mm.GetString("name");
                    addDrugCombo.Items.Add(l);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //fetch id from supplier and use the foreign key
        public void supplierForeignKey()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                 con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM supplier WHERE (name='" + this.addSupplierCombo.Text + "' AND status='Active')", con);
                MySqlDataReader n = mc.ExecuteReader();

                while (n.Read())
                {
                  //  String supid = n.GetInt32("id").ToString();
                    String supid = n.GetString("id");
                    supplieridforeignkey.Text = supid;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //fetch id from drug and use the foreign key
        public void drugForeignKey()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM drug WHERE name='" + this.addDrugCombo.Text + "'", con);
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {
                 //   String did = nn.GetInt32("id").ToString();
                    String did = nn.GetString("id");

                    drugidforeignkey.Text = did;

                }

                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            getCurrentBatchNo();
        }


        private void addSupplierCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplierForeignKey();
        }

        private void addDrugCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            drugForeignKey();
            getCurrentBatchNo();
        }

        private void addStockdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void drugidforeignkey_TextChanged(object sender, EventArgs e)
        {

        }

        private void supplieridforeignkey_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancelStock_Click(object sender, EventArgs e)
        {

        }

        private void sellingPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void buyingPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void addQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void addUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addDate_ValueChanged(object sender, EventArgs e)
        {
            addDate.Format = DateTimePickerFormat.Custom;
            addDate.CustomFormat = "yyyy-MM-dd";
        }

        private void addBatchNo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(addBatchNo.Text, "[^ 0-9]"))
            {
                addBatchNo.Text = "";
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AddStock_Load(object sender, EventArgs e)
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
