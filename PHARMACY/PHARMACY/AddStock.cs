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
       

        public AddStock(String pfn)
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            addstockpfsession.Text = pfn;
            addStockView();
            supplierCombo();
            drugCombo();
        }

        DialogResult dialog;

        //clear fields
        public void clearFields()
        {
            this.addSupplierCombo.Text = "";
            this.addQuantity.Text = "";
            this.buyingPrice.Text = "";
            this.sellingPrice.Text = "";
            this.addDrugCombo.Text = "";
            this.addUnit.Text = "";
            this.addDate.Text = "";
            this.addBatchNo.Text = "";
          
        }


        private void saveStock_Click(object sender, EventArgs e)
        {
            if (addSupplierCombo.Text == string.Empty || addQuantity.Text == string.Empty || buyingPrice.Text == string.Empty || sellingPrice.Text == string.Empty || addDrugCombo.Text == string.Empty || addDate.Text == string.Empty || this.addBatchNo.Text == string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "STOCK REGISTRATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);
                try
                {
                    string expiryDate = addDate.Value.ToString("yyyy-MM-dd");

                    dialog = MessageBox.Show("Are you sure you want to register stock details?", "STOCK DETALS REGISTRATION", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        con.Open();
                        DateTime dt = DateTime.Now;
                        String dateNow = dt.ToString("yyyy-MM-dd");


                        //convert drug id to integer
                        int dr = Convert.ToInt32(drugidforeignkey.Text);
                        //convert supplierforeignkey to integer
                        int i = Convert.ToInt32(supplieridforeignkey.Text);

                        //insert into stock
                        MySqlCommand c = new MySqlCommand("INSERT INTO stock VALUES(NULL,'" + i + "','" + this.addQuantity.Text + "','" + this.buyingPrice.Text + "','" + this.sellingPrice.Text + "','" + dr + "','" + this.addUnit.Text + "','" + expiryDate + "','" + this.addBatchNo.Text + "','" + this.addstockpfsession.Text + "','" + dateNow + "')", con);
                        MySqlDataReader mdrc = c.ExecuteReader();

                        mdrc.Close();


                        MessageBox.Show("Stock details registered successfully...............!", "STOCK DETAILS REGISTRATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        con.Close();
                        updateNetstock();
                        updateDrudPrice();
                        addStockView();
                        clearFields();
                    }

                }
                catch (Exception )
                {
                    MessageBox.Show("Error has occured while registering stock details............!", "STOCK DETAILS REGISTRATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                
            }
        }

        //update netStock
        public void updateNetstock()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            try
            {
                con.Open();
                int drugid = Convert.ToInt32(drugidforeignkey.Text);
               MySqlCommand cmd = new MySqlCommand("SELECT  * FROM net_stock where drug_id='"+drugid+"'", con);
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

                    MySqlCommand cmdi = new MySqlCommand("INSERT INTO net_stock VALUES('" + nsid + "','" + drugid + "','" + this.addDrugCombo.Text + "', '" + this.addQuantity.Text + "', '" + this.addstockpfsession.Text + "','" + this.addUnit.Text + "','" + this.addDate.Value.Date.ToString("yyyy-MM-dd") + "')", con);
                  cmdi.ExecuteNonQuery();

                    }
                else if (c == 1)
                    {
                       // int newQty = Convert.ToInt32(addQuantity.Text);
                        MySqlCommand cmdU = new MySqlCommand("UPDATE net_stock set quantity=(quantity + '" + this.addQuantity.Text + "'), pfno='" + this.addstockpfsession.Text + "',expiry_date='" + this.addDate.Value.Date.ToString("yyyy-MM-dd") + "' WHERE drug_name ='" + this.addDrugCombo.Text + "'", con);
                       cmdU.ExecuteNonQuery();
                       
                    }
                    else
                    {
                        MessageBox.Show("Error has occured while updating net stock ............!", "NET STOCK UPDATE ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
               
                    }


                con.Close();
            }
            catch (Exception )
            {
                MessageBox.Show("Error has occured while updating net stock ............!", "NET STOCK UPDATE ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
               
            }
        }


        //update drug price
        public void updateDrudPrice()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            try
            {
                con.Open();
                int drugid = Convert.ToInt32(drugidforeignkey.Text);
                MySqlCommand cmd = new MySqlCommand("UPDATE drug SET price='" + this.sellingPrice .Text+ "' where id='" + drugid + "'", con);
                MySqlDataReader r;
                r = cmd.ExecuteReader();
                r.Close();
                con.Close();
            }
            catch (Exception )
            {
                MessageBox.Show("Error has occured while updating drug price ............!", "DRUG PRICE UPDATE ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
               
            }
        }

      

        public void addStockView()
        {
            
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
               
                
                 con.Open();

                 MySqlCommand com = new MySqlCommand("SELECT `stock`.`id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`drug`.`name` AS 'DRUG NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`quantity` AS 'QUANTITY', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` GROUP BY `stock`.`id` ASC", con);

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
                addStockdataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(addStockdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception )
            {
                MessageBox.Show("Error has occured while displaying drug price ............!", "DRUG DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
             
            }

            con.Close();

        }

        //populate supplier combo
        public void supplierCombo() {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

             con = new MySqlConnection(db);

            con.Open();

            MySqlCommand c = new MySqlCommand("select * from supplier", con);

            MySqlDataReader m = c.ExecuteReader();

            while (m.Read())
            {
                String l = m.GetString("name");
                addSupplierCombo.Items.Add(l);
               

             
            }
            m.Close();
           // m.Close();
            con.Close();
        }
        //populate drug combo
        public void drugCombo()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            con = new MySqlConnection(db);

            con.Open();

            MySqlCommand c = new MySqlCommand("select * from drug", con);

            MySqlDataReader mm = c.ExecuteReader();

            while (mm.Read())
            {
                String l = mm.GetString("name");
                addDrugCombo.Items.Add(l);
               
            }

            mm.Close();
            con.Close();
        }


      //fetch id from supplier and use the foreign key
        public void supplierForeignKey() {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {

                
               
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM supplier WHERE name='" + this.addSupplierCombo.Text + "'", con);
                MySqlDataReader n = mc.ExecuteReader();

                while (n.Read())
                {
                    String supid = n.GetInt32("id").ToString();
                    supplieridforeignkey.Text = supid;

                }


                n.Close();

            }
            catch (Exception )
            {
                
            }

           
            con.Close();
        
        }



        //fetch id from drug and use the foreign key
        public void drugForeignKey()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {

                
                
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM drug WHERE name='" + this.addDrugCombo.Text + "'", con);
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {
                    String did = nn.GetInt32("id").ToString();
                    //String drn = nn.GetString("drug_name");

                    drugidforeignkey.Text = did;
                   // drugnameforeignkey.Text = drn;
                   

                }

                nn.Close();
                con.Close();

            }
            catch (Exception )
            {
              
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


    }
}
