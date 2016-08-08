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
      //  MySqlConnection con = null;
        public AddDebtor(string pfn)
        {
            InitializeComponent();
           // con = DBHandler.CreateConnection();

            adddebtorpfsession.Text = pfn;
            addDebtorkView();
            drugCombo();
        }

            DialogResult dialog;
            String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
           
        //clear fields
        public void clearFields()
        {
            addDebtorName.Text = string.Empty;
            addDrugCombo.Text = string.Empty;
            addQuantity.Text = string.Empty;
            dateBorrowed.Text = string.Empty;
            addPhone.Text = string.Empty;
            addDeposit.Text = string.Empty;
            dateOfPayment.Text = string.Empty;
            debtorPriceTextBox.Text = string.Empty;
            stockDrugQuantityTextbox.Text = string.Empty;
            remainingQtylabel.Text = string.Empty;
            amountLabel.Text = "0.00";
        }

        private void saveDebtor_Click(object sender, EventArgs e)
        {
            if (addDebtorName.Text == string.Empty || addDrugCombo.Text == string.Empty || stockIDTextBox.Text==string.Empty || addQuantity.Text == string.Empty || dateBorrowed.Text == string.Empty || addPhone.Text == string.Empty || dateOfPayment.Text == string.Empty || debtorPriceTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "DEBTOR REGISTRATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            }
            else
            {
               
                             
                try
                {
                                decimal qty = Convert.ToDecimal(addQuantity.Text);
                                decimal netQty = Convert.ToDecimal(stkQtyLabel.Text);
                    
                    if (netQty >= qty)
                                {
   //
                string borrowedDate = dateBorrowed.Value.ToString("yyyy-MM-dd");
                string PaymentDate = dateOfPayment.Value.ToString("yyyy-MM-dd");


                    dialog = MessageBox.Show("Are you sure you want to add a debtor?", "DEBTOR DETALS REGISTRATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();
                        DateTime dt = DateTime.Now;
                        string dateNow = dt.ToString("yyyy-MM-dd");



                        MySqlCommand c = new MySqlCommand("INSERT INTO debtor VALUES(NULL,'" + this.addDebtorName.Text + "','" + this.stockIDTextBox.Text + "','" + this.addQuantity.Text + "','" + this.debtorPriceTextBox.Text + "','" + borrowedDate + "','" + this.addPhone.Text + "','" + this.addDeposit.Text + "','" + PaymentDate + "','" + this.adddebtorpfsession.Text + "','" + dateNow + "')", con);

                        c.ExecuteNonQuery();

                        MessageBox.Show("Debtor details registered successfully...............!", "DEBTOR DETAILS REGISTRATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        con.Close();
                        updateStock();
                        addDebtorkView();
                        clearFields();
                    }

                               }
                               else
                               {

                                   MessageBox.Show("The quantity you entered is more than what is in the stock.: " + netQty, "EXCESS QUANTITY", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                              }
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                   // MessageBox.Show("Error has occured while registering debtor details............!", "DEBTOR DETAILS REGISTRATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

                }
                finally
                { 
                
                }

               
            }
        }

            

        // Update stock
        public void updateStock()
        {
           try
           {
               MySqlConnection con = new MySqlConnection(db);
                con.Open();
                //Double qt = Convert.ToDouble(this.addQuantity.Text);
                int drid = Convert.ToInt32(this.stockIDTextBox.Text);
                MySqlCommand mc = new MySqlCommand("UPDATE stock set quantity_sold=(quantity_sold + '" + this.addQuantity.Text + "') WHERE `stock`.`stock_id` ='" + this.stockIDTextBox.Text + "'", con);
                mc.ExecuteNonQuery();
              
            }
            catch (Exception )
            {

                //MessageBox.Show("Problem has occured while updating net stock"+ex.Message);
            }
        }

        public void addDebtorkView()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);

                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `debtor`.`id` AS 'DEBTOR ID',`debtor`.`name` AS 'NAME',`drug`.`name` AS 'DRUG NAME',`debtor`.`quantity` AS 'QUANTITY',`debtor`.`price` AS 'PRICE',(`debtor`.`quantity`*`debtor`.`price`) AS 'AMOUNT',`debtor`.`date_borrowed` AS 'DATE BORROWED',`debtor`.`phone` AS 'PHONE',`debtor`.`deposit` AS 'DEPOSIT',`debtor`.`date_of_payment` AS 'DATE OF PAYMENT',`debtor`.`pfno` AS 'REGISTERED BY',`debtor`.`registered_date` AS 'REGISTRATION DATE' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `debtor` ON `stock`.`stock_id`=`debtor`.`stock_id` WHERE ((`debtor`.`quantity`*`debtor`.`price`)>`debtor`.`deposit`) ORDER BY `debtor`.`date_borrowed` DESC ", con);

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
                dataTable.Columns.Add("DEBTOR ID");
                dataTable.Columns.Add("NAME");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("PRICE");
                dataTable.Columns.Add("AMOUNT");
                dataTable.Columns.Add("DATE BORROWED", typeof(string));
                dataTable.Columns.Add("PHONE");
                dataTable.Columns.Add("DEPOSIT");
                dataTable.Columns.Add("DATE OF PAYMENT", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                dataTable.Columns.Add("REGISTRATION DATE", typeof(string));
                // End formating titles.

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
            try
            {
                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT `drug`.`name` AS 'name',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'quantity' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` WHERE ((`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0) AND (`stock`.`status`='1')) GROUP BY `stock`.`drug_id` ORDER BY `drug`.`name` ASC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string l = r.GetString("name");
                    string qty = r.GetString("quantity");

                    addDrugCombo.Items.Add(l);
                    stockDrugQuantityTextbox.Text = qty;
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
                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT `stock`.`stock_id` AS 'stock_id',`stock`.`selling_price` AS 'selling_price', (`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'remaining_quantity' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` WHERE ((`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0) AND (`stock`.`status`='1') AND (`drug`.`name`='" + this.addDrugCombo.Text + "'))  GROUP BY `stock`.`drug_id` ORDER BY `drug`.`name` ASC", con);
                MySqlDataReader dr = mc.ExecuteReader();

                while (dr.Read())
                {
                    string stockId = dr.GetString("stock_id");
                    string price = dr.GetString("selling_price");

                    stockIDTextBox.Text = stockId;
                    debtorPriceTextBox.Text = price;

                }

                con.Close();

            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
            }

        }

        private void addDebtordataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addDrugCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            drugForeignKey();
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand mc = new MySqlCommand("SELECT (`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'quantity' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` WHERE `stock`.`stock_id`='" + this.stockIDTextBox.Text + "'", con);

                MySqlDataReader r = mc.ExecuteReader();

                while (r.Read())
                {
                    string qty = r.GetString("quantity");

                    stkQtyLabel.Text = qty;
                    stockDrugQuantityTextbox.Text = " Available Drug Quantity is : "+qty;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        private void addQuantity_TextChanged(object sender, EventArgs e)
        {
            CheckStockQuantity();
        }

        public void CheckStockQuantity() 
        {
            try
            {
                decimal qty = Convert.ToDecimal(stkQtyLabel.Text);
                decimal debtorQty = Convert.ToDecimal(addQuantity.Text);
                decimal price = Convert.ToDecimal(debtorPriceTextBox.Text);

                if (qty >= debtorQty)
                {
                    remainingQtylabel.ForeColor = Color.Green;
                    remainingQtylabel.Text = "REMAINING STOCK QUANTITY IS : " + (qty - debtorQty);

                    amountLabel.Text = (debtorQty*price) +"Kshs.";
                }
                else
                {
                    remainingQtylabel.ForeColor = Color.Red;
                    remainingQtylabel.Text = "NO SUCH QUANTITY IN STOCK. REMAINING STOCK QUANTITY IS : " + qty;
                }

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                remainingQtylabel.Text = string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void stockDrugQuantityTextbox_Click(object sender, EventArgs e)
        {
          
        }

        private void remainingQtylabel_Click(object sender, EventArgs e)
        {

            
        }

        private void stkQtyLabel_Click(object sender, EventArgs e)
        {
            CheckStockQuantity();
        }

        private void debtorPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckStockQuantity();
        }



    }
}
