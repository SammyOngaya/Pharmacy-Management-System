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

        public UpdateStock(String pfn)
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            updatestockpfsession.Text = pfn;
            supplierCombo();
            drugCombo();
            viewStock();
            searchStock();
            //showStockData();
        }

        DataTable dataTable;

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
            this.updateSupplierCombo.Text = "";
            this.updateStockQuantity.Text = "";
            this.updateStockBuyingPrice.Text = "";
            this.updateStockSellingPrice.Text = "";
            this.updateDrugCombo.Text = "";
            this.updateStockUnit.Text = "";
            this.updateStockExpiriDate.Text = "";
            this.updateStockBatchNo.Text = "";

        }

        //view stock
        public void viewStock()
        {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                MySqlCommand com = new MySqlCommand("SELECT `stock`.`id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`drug`.`name` AS 'DRUG NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`quantity` AS 'QUANTITY', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` GROUP BY `stock`.`id` ORDER BY `stock`.`registered_date` DESC", con);

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

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            con.Open();

            MySqlCommand c = new MySqlCommand("select * from stock", con);

            MySqlDataReader r = c.ExecuteReader();

            while (r.Read())
            {
                String l = r.GetString("batch_no");
                collection.Add(l);


            }

            searchUpdateStock.AutoCompleteCustomSource = collection;


        }


        //fill data in fields
        public void showStockData()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            con.Open();

            MySqlCommand c = new MySqlCommand("SELECT `drug`.`id`, `stock`.`id` AS sid,`supplier`.`id`,`stock`.`supplier_id`  AS supplier_id ,`stock`.`drug_id`  AS drug_id,`drug`.`name` as drugname,`stock`.`id`,`stock`.`quantity` ,buying_price,selling_price,batch_no,expiry_date,`supplier`.`id`,`supplier`.`name` as suppliername,`stock`.`units` from drug JOIN stock on `drug`.`id`=`stock`.`drug_id` JOIN supplier on `supplier`.`id`=`stock`.`supplier_id` WHERE batch_no='" + this.searchUpdateStock.Text + "'", con);
            //SELECT drug.id,drug.name as drugname,`stock`.`id`,stock.quantity ,buying_price,selling_price,batch_no,expiry_date,supplier.id,supplier.name as suppliername,stock.units from drug JOIN stock on drug.id=stock.drug_id JOIN supplier on supplier.id=stock.supplier_id;
            MySqlDataReader r = c.ExecuteReader();
           
            while (r.Read())
            {
                String ids = r.GetInt32("sid").ToString();

                String sp = r.GetString("suppliername");
                String dr = r.GetString("drugname");
                String qty = r.GetString("quantity");
                String bp = r.GetString("buying_price");
                String spr = r.GetString("selling_price");
                String units = r.GetString("units");
                String expdate = r.GetString("expiry_date");
                String bt = r.GetString("batch_no");

                //supplieridforeignkey.Text = sp;
                //drugidforeignkey.Text = dr;
                updateStockQuantity.Text = qty;
                updateStockBuyingPrice.Text = bp;
                updateStockSellingPrice.Text = spr;
                updateStockUnit.Text = units;
                updateStockExpiriDate.Text = expdate;
                updateStockBatchNo.Text = bt;
                updateSupplierCombo.Text = sp;
                updateDrugCombo.Text = dr;

                updateStockId.Text = ids;

            }

        }


        //update Stock

        public void updateStock()
        {

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                int stid = Convert.ToInt32(this.updateStockId.Text);
                int supforeign = Convert.ToInt32(supplieridforeignkey.Text);
                int drid = Convert.ToInt32(drugidforeignkey.Text);

                MySqlCommand c = new MySqlCommand("UPDATE `stock` SET pfno='" + this.updatestockpfsession.Text + "',supplier_id='" + supforeign + "',drug_id='" + drid + "',buying_price='" + this.updateStockBuyingPrice.Text + "',selling_price='" + this.updateStockSellingPrice.Text + "',units='" + this.updateStockUnit.Text + "',expiry_date='" + this.updateStockExpiriDate.Text + "',batch_no='" + this.updateStockBatchNo.Text + "'  WHERE `stock`.`id`='" + stid + "'", con);

                MySqlDataReader r = c.ExecuteReader();



                MessageBox.Show("Stock Updated successfully");

                while (r.Read())
                {

                }

                con.Close();
              
            }
            catch (Exception ex) {
                MessageBox.Show("Error while updating stock!!"+ex.Message);
            }
            updateDrudPrice();
            updateExpiryDate();
            viewStock();
        }

        //update drug price
        public void updateExpiryDate()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            try
            {
                con.Open();
                int drugid = Convert.ToInt32(drugidforeignkey.Text);
                MySqlCommand mcd = new MySqlCommand("UPDATE net_stock SET expiry_date='" + this.updateStockExpiriDate.Text + "' WHERE drug_id='" + drugid + "'", con);
                mcd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("was not able to update expiry date" + ex.Message);
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
                MySqlCommand cmd = new MySqlCommand("UPDATE drug SET price='" + this.updateStockSellingPrice.Text + "' where id='" + drugid + "'", con);
                MySqlDataReader r;
                r = cmd.ExecuteReader();
                r.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("was not able to update Price" + ex.Message);
            }
        }


        //populate supplier combo
        public void supplierCombo()
        {
            MySqlConnection con;
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            con = new MySqlConnection(db);

            con.Open();

            MySqlCommand c = new MySqlCommand("select * from supplier", con);

            MySqlDataReader m = c.ExecuteReader();

            while (m.Read())
            {
                String l = m.GetString("name");
                updateSupplierCombo.Items.Add(l);

            }
            m.Close();
            // m.Close();
            con.Close();
        }


        //populate drug combo
        public void drugCombo()
        {
            MySqlConnection con;
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            con = new MySqlConnection(db);

            con.Open();

            MySqlCommand c = new MySqlCommand("select * from drug", con);

            MySqlDataReader mm = c.ExecuteReader();

            while (mm.Read())
            {
                String l = mm.GetString("name");
                updateDrugCombo.Items.Add(l);

            }

            mm.Close();
            con.Close();
        }

        //fetch id from supplier and use the foreign key
        public void supplierForeignKey()
        {
            MySqlConnection con;
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";

            try
            {
                 
                con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM supplier WHERE name='" + this.updateSupplierCombo.Text + "'", con);
                MySqlDataReader n = mc.ExecuteReader();

                while (n.Read())
                {
                    String supid = n.GetInt32("id").ToString();
                    supplieridforeignkey.Text = supid;

                }


                n.Close();
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
            MySqlConnection con;
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";

            try
            {


                con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM drug WHERE name='" + this.updateDrugCombo.Text + "'", con);
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {
                    String did = nn.GetInt32("id").ToString();
                    drugidforeignkey.Text = did;


                }

                nn.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            showStockData();
            //filterDatabase();
        }

        private void updateStockButton_Click(object sender, EventArgs e)
        {
            updateStock();
            clearFields();
            
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

       
    }
}
