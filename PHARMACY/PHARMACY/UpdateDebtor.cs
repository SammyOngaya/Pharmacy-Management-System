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
    public partial class UpdateDebtor : Form
    {
        public UpdateDebtor(String pfn)
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            updatedebtorpfsession.Text = pfn;
            viewDebtor();
            drugCombo();
            searchStock();
        }

        DataTable dt;


        //filter database
        public void filterDatabase()
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("phone LIKE '%{0}%'", updateSearchDebtor.Text);
            updateDebtordataGridView.DataSource = dv;
        }

        //clear fields
        public void clearFields()
        {
            this.updateDebtorName.Text = "";
            this.updateDrugCombo.Text = "";
            this.updateQuantity.Text = "";
            this.updateDateBorrowed.Text = "";
            this.updatePhone.Text = "";
            this.updateDeposit.Text = "";
            this.dateOfPayment.Text = "";
        }

        //view debtors
        public void viewDebtor()
        {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);
                //SELECT `debtor`.`id` AS 'ID',`debtor`.`name` AS 'NAME',`drug`.`name` AS 'DRUG NAME',`debtor`.`quantity` AS 'QUANTITY',`debtor`.`date_borrowed` AS 'DATE BORROWED',`debtor`.`phone` AS 'PHONE',`debtor`.`deposit` AS 'DEPOSIT',`debtor`.`date_of_payment` AS 'DATE OF PAYMENT',`debtor`.`pfno` AS 'REGISTERED BY',`debtor`.`registered_date` AS 'REGISTRATION DATE' FROM `drug` JOIN `debtor` ON `drug`.`id`=`debtor`.`drug_id` GROUP BY `debtor`.`id` ASC
                MySqlCommand com = new MySqlCommand("SELECT `drug`.`id` AS 'Drug ID',`drug`.`price` AS price, `debtor`.`id` AS id,`debtor`.`name` AS name,`debtor`.`drug_id` AS drug_id,`debtor`.`quantity` AS quantity,`debtor`.`date_borrowed` AS date_borrowed,`debtor`.`phone` AS phone,`debtor`.`deposit` AS deposit,`debtor`.`date_of_payment` AS date_of_payment,`debtor`.`pfno` AS pfno,`debtor`.`registered_date` AS registered_date FROM `drug` JOIN `debtor` ON `drug`.`id`=`debtor`.`drug_id` WHERE (`drug`.`price`*`debtor`.`quantity`)>=`debtor`.`deposit` ORDER BY `debtor`.`date_borrowed` DESC ", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dt = new DataTable();
                // Add autoincrement column.
                dt.Columns.Add("#", typeof(int));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["#"] };
                dt.Columns["#"].AutoIncrement = true;
                dt.Columns["#"].AutoIncrementSeed = 1;
                dt.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                updateDebtordataGridView.DataSource = bs;

                a.Update(dt);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(updateDebtordataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ViewDebtor_Load(object sender, EventArgs e)
        {

        }


         //search debtor from debtor
        public void searchStock()
        {
            updateSearchDebtor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            updateSearchDebtor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            con.Open();

            MySqlCommand c = new MySqlCommand("select * from debtor", con);

            MySqlDataReader r = c.ExecuteReader();

            while (r.Read())
            {
                String l = r.GetString("phone");
                collection.Add(l);


            }

            updateSearchDebtor.AutoCompleteCustomSource = collection;


        }



        //fill data in fields
        public void showDebtorData()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            con.Open();

            MySqlCommand c = new MySqlCommand("SELECT `drug`.`id` AS drug_id,`drug`.`name` AS drugname,`drug`.`price` AS price, `debtor`.`id` AS did, `debtor`.`name` AS debtorname ,`debtor`.`quantity` AS drquantity,`debtor`.`date_borrowed`,`debtor`.`phone`,`debtor`.`phone`,`debtor`.`deposit` FROM `drug` JOIN `debtor` ON `drug`.`id`=`debtor`.`drug_id` WHERE phone='" + this.updateSearchDebtor.Text + "'", con);
           
            MySqlDataReader r = c.ExecuteReader();

            while (r.Read())
            {
                String ids = r.GetInt32("did").ToString();

                String drugid = r.GetInt32("drug_id").ToString();
                String name = r.GetString("debtorname");
                String dr = r.GetString("drugname");
                String qty = r.GetDouble("drquantity").ToString();
                String dateborrowed = r.GetString("date_borrowed");
                String ph = r.GetString("phone");
                String dep = r.GetString("deposit");
                String pri = r.GetString("price");
              //  String un = r.GetString("unit");
                //String dop = r.GetString("date_of_payment");
               
                //supplieridforeignkey.Text = sp;
                drugidforeignkey.Text = drugid;
                updateDebtorName.Text = name;
                updateDrugCombo.Text = dr;
                updateQuantity.Text = qty;
                updateDateBorrowed.Text = dateborrowed;
                updatePhone.Text = ph;
                updateDeposit.Text = dep;
                updateDebtorPrice.Text = pri;
                //updateDebtorUnit.Text=un;

                updateDebtorPrimaryKey.Text = ids;

            }

        }

        //save to sales
        public void saveToSales() {

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                DateTime dt = DateTime.Now;
                String dateNow = dt.ToString("yyyy-MM-dd");

                con.Open();
                //int pid = Convert.ToInt32(updateDebtorPrimaryKey.Text);
                int drid = Convert.ToInt32(drugidforeignkey.Text);
                Double qty = Convert.ToDouble(updateQuantity.Text);

                MySqlCommand c = new MySqlCommand("INSERT INTO sales VALUES(NULL,'" + this.updatePhone.Text + "','" + drid + "','" + qty + "','" + this.updateDebtorPrice.Text + "','" + this.updatedebtorpfsession.Text + "',dateNow,'debtor')", con);

                MySqlDataReader r = c.ExecuteReader();

                MessageBox.Show("Debtor Cleared Successfully");

                while (r.Read())
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();


        }

        //update Stock

        public void updateDebtor()
        {
            string borrowedDate = updateDateBorrowed.Value.ToString("yyyy-MM-dd");

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                int pid = Convert.ToInt32(updateDebtorPrimaryKey.Text);
                int drid = Convert.ToInt32(drugidforeignkey.Text);
                Double qty = Convert.ToDouble(updateQuantity.Text);
                Double price = Convert.ToDouble(updateDebtorPrice.Text);
                Double dep=Convert.ToDouble(updateDeposit.Text);

                Double toBePaid = qty * price;

                if (toBePaid <= dep)
                {
                    saveToSales();
                }



                MySqlCommand c = new MySqlCommand("UPDATE `debtor` SET drug_id='" + drid + "',pfno='" + this.updatedebtorpfsession.Text + "',quantity='" + qty + "',date_borrowed='" + borrowedDate + "', deposit='" + this.updateDeposit.Text + "', name='" + this.updateDebtorName.Text + "', phone='" + this.updatePhone.Text + "' WHERE id='" + pid + "'", con);

                MySqlDataReader r = c.ExecuteReader();

                MessageBox.Show("Debtor Updated successfully");

                while (r.Read())
                {

                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            viewDebtor();
        }


        //populate drug combo
        public void drugCombo()
        {
            MySqlConnection con;
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            con = new MySqlConnection(db);

            con.Open();

            MySqlCommand c = new MySqlCommand("select `drug`.`id`,`drug`.`name` FROM `drug` JOIN `net_stock` ON `drug`.`id`=`net_stock`.`drug_id` WHERE `net_stock`.`quantity`>0 GROUP BY `net_stock`.`drug_id` ORDER BY `drug`.`name` ASC", con);

            MySqlDataReader mm = c.ExecuteReader();

            while (mm.Read())
            {
                String l = mm.GetString("name");
                updateDrugCombo.Items.Add(l);

            }

            mm.Close();
            con.Close();
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

        private void updateSearchDebtor_TextChanged(object sender, EventArgs e)
        {
            showDebtorData();
            filterDatabase();
        }

        private void updateDebtorButton_Click(object sender, EventArgs e)
        {
            updateDebtor();
            clearFields();
           
        }

        private void UpdateDebtor_Load(object sender, EventArgs e)
        {

        }

        private void updateDrugCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            drugForeignKey();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculator c = new Calculator();
            c.ShowDialog();
        }

        private void updateDeposit_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(updateDeposit.Text, "[^ 0-9]"))
            {
                updateDeposit.Text = "";
            }
        }

    }
}
