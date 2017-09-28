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
    public partial class AddDebtor : Form
    {
        public AddDebtor(String pfn)
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            adddebtorpfsession.Text = pfn;
            addDebtorkView();
            drugCombo();
        }

            DialogResult dialog;

        //clear fields
        public void clearFields()
        {
            this.addDebtorName.Text = "";
            this.addDrugCombo.Text = "";
            this.addQuantity.Text = "";
            this.dateBorrowed.Text = "";
            this.addPhone.Text = "";
            this.addDeposit.Text = "";
            this.dateOfPayment.Text = "";
        }

        private void saveDebtor_Click(object sender, EventArgs e)
        {
            if (addDebtorName.Text == string.Empty || addDrugCombo.Text == string.Empty || addQuantity.Text == string.Empty || dateBorrowed.Text == string.Empty || addPhone.Text == string.Empty || dateOfPayment.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "DEBTOR REGISTRATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            }
            else
            {

                string borrowedDate = dateBorrowed.Value.ToString("yyyy-MM-dd");
                string PaymentDate = dateOfPayment.Value.ToString("yyyy-MM-dd");

                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);
                try
                {
                    dialog = MessageBox.Show("Are you sure you want to register the debtor?", "DEBTOR DETALS REGISTRATION", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        con.Open();
                        DateTime dt = DateTime.Now;
                        String dateNow = dt.ToString("yyyy-MM-dd");

                        //convert drug id to foreign key
                        int drugid = Convert.ToInt32(drugidforeignkey.Text);

                        MySqlCommand c = new MySqlCommand("INSERT INTO debtor VALUES(NULL,'" + this.addDebtorName.Text + "','" + drugid + "','" + this.addQuantity.Text + "','" + borrowedDate + "','" + this.addPhone.Text + "','" + this.addDeposit.Text + "','" + PaymentDate + "','" + this.adddebtorpfsession.Text + "','" + dateNow + "')", con);

                        MySqlDataReader r = c.ExecuteReader();

                        MessageBox.Show("Debtor details registered successfully...............!", "DEBTOR DETAILS REGISTRATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        con.Close();
                        updateNetStock();
                        addDebtorkView();
                        clearFields();
                    }
                }
                catch (Exception) {
                    MessageBox.Show("Error has occured while registering debtor details............!", "DEBTOR DETAILS REGISTRATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                
                }
                
            }
        }

        //update net stock
        public void updateNetStock()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                //Double qt = Convert.ToDouble(this.addQuantity.Text);
                int drid = Convert.ToInt32(this.drugidforeignkey.Text);
                MySqlCommand mc = new MySqlCommand("UPDATE net_stock set quantity=(quantity-'"+this.addQuantity.Text+"') WHERE drug_name='"+this.addDrugCombo.Text+"'", con);
                mc.ExecuteNonQuery();
              
            }
            catch (Exception ex)
            {

                MessageBox.Show("Problem has occured while updating net stock"+ex.Message);
            }
        }

        public void addDebtorkView()
        {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                MySqlCommand com = new MySqlCommand("SELECT * FROM debtor ORDER BY date_borrowed DESC", con);

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
                addDebtordataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(addDebtordataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    
        //populate drug combo
        public void drugCombo()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            con.Open();

            MySqlCommand c = new MySqlCommand("select `drug`.`id`,`drug`.`name` FROM `drug` JOIN `net_stock` ON `drug`.`id`=`net_stock`.`drug_id` WHERE `net_stock`.`quantity`>0 GROUP BY `net_stock`.`drug_id` ORDER BY `drug`.`name` ASC", con);

            MySqlDataReader r = c.ExecuteReader();

            while (r.Read())
            {
                String l = r.GetString("name");
                addDrugCombo.Items.Add(l);
            }
        }


        //fetch id from drug and use the foreign key
        public void drugForeignKey()
        {
            try
            {

                String db = "datasource=localhost; port=3306; username=root; password=root; database=pms;";
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM drug WHERE name='" + this.addDrugCombo.Text + "'", con);
                MySqlDataReader dr = mc.ExecuteReader();

                while (dr.Read())
                {
                    String did = dr.GetInt32("id").ToString();
                    drugidforeignkey.Text = did;

                }


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void addDebtordataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addDrugCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            drugForeignKey();
        }

        private void AddDebtor_Load(object sender, EventArgs e)
        {

        }

        private void Calculatorbutton1_Click(object sender, EventArgs e)
        {
            Calculator c = new Calculator();
            c.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void addDeposit_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(addDeposit.Text, "[^ 0-9]"))
            {
                addDeposit.Text = "";
            }
        }



    }
}
