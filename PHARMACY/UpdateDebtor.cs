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
        MySqlConnection con = null;
        public UpdateDebtor(String pfn)
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
           
            updatedebtorpfsession.Text = pfn;
            stockIDTextBox.Text = string.Empty;
            viewDebtor();
            drugCombo();
            searchPhone();
            searchStockID();
        }

        DataTable dt;
        DialogResult dialog;

        String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
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
            updateDebtorName.Text = string.Empty;
            updateDrugCombo.Text = string.Empty;
            //updateQuantity.Text = string.Empty;
            updateDateBorrowed.Text = string.Empty;
            updatePhone.Text = string.Empty;
            updateDebtorDepositTextBox.Text = string.Empty;
            dateOfPayment.Text = string.Empty;
            //updateDebtorPriceTextBox.Text = string.Empty;
            searchDebtorIDTextBox.Text = string.Empty;
            stockIDTextBox.Text = string.Empty;
            updateDebtorPrimaryKey.Text = string.Empty;
            updateQuantity.Text = "0.00";
            updateDebtorPriceTextBox.Text = "0.00";
            stkQtyLabel.Text = "0.00";
            amountLabel.Text = "0.00";
            stockIDTextBox.Text = string.Empty;
            stockDrugQuantityTextbox.Text = string.Empty;
            remainingQtylabel.Text = string.Empty;
            originalQuantityLabel1.Text = string.Empty;
        }

        //search drug from debtor.
        public void searchStockID()
        {
            searchDebtorIDTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchDebtorIDTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {
                MySqlConnection con = new MySqlConnection(db);

                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                con.Open();


                MySqlCommand com = new MySqlCommand("SELECT `debtor`.`id` AS 'id' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `debtor` ON `stock`.`stock_id`=`debtor`.`stock_id` WHERE (((`debtor`.`quantity`*`debtor`.`price`)>`debtor`.`deposit`))  ", con);

                MySqlDataReader r = com.ExecuteReader();

                while (r.Read())
                {
                    string id = r.GetString("id");
                    collection.Add(id);

                }
                con.Close();
            }
            catch (Exception)
            {
            }
            searchDebtorIDTextBox.AutoCompleteCustomSource = collection;

        }


        //search phone from debtor.
        public void searchPhone()
        {
            updateSearchDebtor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            updateSearchDebtor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {
                MySqlConnection con = new MySqlConnection(db);

                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                con.Open();


                MySqlCommand com = new MySqlCommand("SELECT phone FROM  debtor ", con);

                MySqlDataReader r = com.ExecuteReader();

                while (r.Read())
                {
                    string phone = r.GetString("phone");
                    collection.Add(phone);

                }
                con.Close();
            }
            catch (Exception)
            {
            }
            updateSearchDebtor.AutoCompleteCustomSource = collection;

        }


        //view debtors
        public void viewDebtor()
        {

            try
            {
               // MySqlConnection con = new MySqlConnection();
               /// con.Open();

                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand com = new MySqlCommand("SELECT `debtor`.`id` AS 'DEBTOR ID',`debtor`.`name` AS 'NAME',`drug`.`name` AS 'DRUG NAME',`debtor`.`quantity` AS 'QUANTITY',`debtor`.`price` AS 'PRICE',(`debtor`.`quantity`*`debtor`.`price`) AS 'AMOUNT',((`debtor`.`quantity`*`debtor`.`price`)-`debtor`.`deposit`) AS 'BALANCE',`debtor`.`date_borrowed` AS 'DATE BORROWED',`debtor`.`phone` AS 'PHONE',`debtor`.`deposit` AS 'DEPOSIT',`debtor`.`date_of_payment` AS 'DATE OF PAYMENT',`debtor`.`pfno` AS 'REGISTERED BY',`debtor`.`registered_date` AS 'REGISTRATION DATE' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `debtor` ON `stock`.`stock_id`=`debtor`.`stock_id` WHERE (((`debtor`.`quantity`*`debtor`.`price`)>`debtor`.`deposit`))  ORDER BY `debtor`.`date_borrowed` DESC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dt = new DataTable();

                // Add autoincrement column.
                dt.Columns.Add("#", typeof(string));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["#"] };
                dt.Columns["#"].AutoIncrement = true;
                dt.Columns["#"].AutoIncrementSeed = 1;
                dt.Columns["#"].ReadOnly = true;
                // End adding AI column.


                // Format titles.
                dt.Columns.Add("DEBTOR ID");
                dt.Columns.Add("NAME");
                dt.Columns.Add("DRUG NAME");
                dt.Columns.Add("QUANTITY");
                dt.Columns.Add("PRICE");
                dt.Columns.Add("AMOUNT");
                dt.Columns.Add("DEPOSIT");
                dt.Columns.Add("BALANCE");
                dt.Columns.Add("DATE BORROWED", typeof(string));
                dt.Columns.Add("PHONE");
                dt.Columns.Add("DATE OF PAYMENT", typeof(string));
                dt.Columns.Add("REGISTERED BY");
                dt.Columns.Add("REGISTRATION DATE", typeof(string));
                // End formating titles.

                a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                updateDebtordataGridView.DataSource = bs;

                a.Update(dt);
                //con.Close();

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


       


        //fill data in fields
        public void showDebtorData()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `debtor`.`id` AS 'debtor_id',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'remaining_quantity',`debtor`.`stock_id` AS 'stock_id',`debtor`.`name` AS 'debtorname',`drug`.`name` AS 'drugname',`debtor`.`quantity` AS 'drquantity',`debtor`.`price` AS 'price',(`debtor`.`price`*`debtor`.`quantity`) AS 'amount',`debtor`.`date_borrowed` AS 'date_borrowed',`debtor`.`phone` AS 'phone',deposit,`debtor`.`date_of_payment` AS 'date_of_payment' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `debtor` ON `stock`.`stock_id`=`debtor`.`stock_id` WHERE (( `debtor`.`id`='" + this.searchDebtorIDTextBox.Text + "') AND ((`debtor`.`quantity`*`debtor`.`price`)>`debtor`.`deposit`)) ", con);

                MySqlDataReader r = com.ExecuteReader();

                while (r.Read())
                {
                    string ids = r.GetString("debtor_id");

                    string drugid = r.GetString("stock_id");
                    string name = r.GetString("debtorname");
                    string dr = r.GetString("drugname");
                    string qty = r.GetString("drquantity");
                    string dateborrowed = r.GetString("date_borrowed");
                    string ph = r.GetString("phone");
                    string dep = r.GetString("deposit");
                    string pri = r.GetString("price");
                    string dop = r.GetString("date_of_payment");
                    string amount = r.GetString("amount");
                    string remainingQty = r.GetString("remaining_quantity");

                    //supplieridforeignkey.Text = sp;

                    stkQtyLabel.Text = remainingQty;
                    stockIDTextBox.Text = drugid;
                    updateDebtorName.Text = name;
                    updateDrugCombo.Text = dr;
                    updateQuantity.Text = qty;
                    originalQuantityLabel1.Text = qty;
                    updateDateBorrowed.Text = dateborrowed;
                    updatePhone.Text = ph;
                    updateDebtorPriceTextBox.Text = pri;
                    dateOfPayment.Text = dop;
                    amountLabel.Text = amount;
                    updateDebtorDepositTextBox.Text = dep;
                    totalAmountLabel1.Text = amount;
                    

                    updateDebtorPrimaryKey.Text = ids;

                }
                con.Close();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        //save to sales
        public void saveToSales() {

            try
            {
                DateTime dt = DateTime.Now;
                String dateNow = dt.ToString("yyyy-MM-dd");

                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("INSERT INTO sales VALUES(NULL,'" + this.updatePhone.Text + "','" + this.stockIDTextBox.Text + "','" + this.updateQuantity.Text + "','" + this.updateDebtorPriceTextBox.Text + "','" + this.updatedebtorpfsession.Text + "','" + dateNow + "','units','debtor')", con);

                c.ExecuteNonQuery();

                MessageBox.Show("Debtor Cleared Successfully");

                con.Close();
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
            }
           
        }

        //update Stock

        public void updateDebtor()
        {
            string borrowedDate = updateDateBorrowed.Value.ToString("yyyy-MM-dd");
            string dop = dateOfPayment.Value.ToString("yyyy-MM-dd");

             try
            {
               

                decimal cqty = Convert.ToDecimal(stkQtyLabel.Text);
               decimal debtorQty = Convert.ToDecimal(updateQuantity.Text);
                decimal cprice = Convert.ToDecimal(updateDebtorPriceTextBox.Text);
                decimal originalQuantity = Convert.ToDecimal(originalQuantityLabel1.Text);

                if (cqty >= debtorQty)
                {

                if (originalQuantity == debtorQty)
                {

               
                double amount = Convert.ToDouble(totalAmountLabel1.Text);
                double deposit = Convert.ToDouble(updateDebtorDepositTextBox.Text);


               if (amount <= deposit)
               {
                    double debtorPrice = Convert.ToDouble(updateQuantity.Text);
                    double debtorQuantity = Convert.ToDouble(updateDebtorPriceTextBox.Text);

                    MySqlConnection con = new MySqlConnection(db);
                    con.Open();
                   
                    MySqlCommand c = new MySqlCommand("UPDATE `debtor` SET stock_id='" + this.stockIDTextBox.Text + "',pfno='" + this.updatedebtorpfsession.Text + "',date_borrowed='" + borrowedDate + "',date_of_payment='" + dop + "',price='" + this.updateDebtorPriceTextBox.Text + "', deposit='" + (debtorPrice * debtorQuantity) + "', name='" + this.updateDebtorName.Text + "', phone='" + this.updatePhone.Text + "' WHERE id='" + this.updateDebtorPrimaryKey.Text + "'", con);

                    c.ExecuteNonQuery();
                   
                   MessageBox.Show("Debt Updated successfully. And is Settled.","UPDATE DEBTOR",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    con.Close();

                    insertToSales();
                }
                else 
                {
                    MySqlConnection con = new MySqlConnection(db);
                    con.Open();

                    MySqlCommand c = new MySqlCommand("UPDATE `debtor` SET stock_id='" + this.stockIDTextBox.Text + "',pfno='" + this.updatedebtorpfsession.Text + "',date_borrowed='" + borrowedDate + "',date_of_payment='" + dop + "',price='" + this.updateDebtorPriceTextBox.Text + "', deposit='" + this.updateDebtorDepositTextBox.Text+ "', name='" + this.updateDebtorName.Text + "', phone='" + this.updatePhone.Text + "' WHERE id='" + this.updateDebtorPrimaryKey.Text + "'", con);

                    c.ExecuteNonQuery();
                    MessageBox.Show("Debt Updated successfully.", "UPDATE DEBTOR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                  
                }
               else 
                { 
                    // Reverse the quantity first then update fresh.
                    ReverseStockQuantity();

                    // Update the debtor a fresh.
                    UpdateDebtorAgain();

                    updateStockAgain();
                }

                clearFields();

                }
                else
                {

                    MessageBox.Show("The quantity you entered is more than what is in the stock.: " + this.stkQtyLabel.Text, "EXCESS QUANTITY", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (Exception ) {
               // MessageBox.Show(ex.Message);
            }
           
            viewDebtor();
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

                MySqlDataReader mm = c.ExecuteReader();

                while (mm.Read())
                {
                    string l = mm.GetString("name");
                    string qty = mm.GetString("quantity");

                    stockIDTextBox.Text = qty;
                    updateDrugCombo.Items.Add(l);

                }

                con.Close();
            }
            catch (Exception ) {
                //MessageBox.Show(ex.Message);
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
                MySqlCommand mc = new MySqlCommand("SELECT `stock`.`stock_id` AS 'stock_id',`stock`.`selling_price` AS 'price', (`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'remaining_quantity' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` WHERE ((`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0) AND (`stock`.`status`='1') AND (`drug`.`name`='" + this.updateDrugCombo.Text + "'))  GROUP BY `stock`.`drug_id` ORDER BY `drug`.`name` ASC", con);
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {
                    string stockId = nn.GetString("stock_id");
                    string price = nn.GetString("price");

                    stockIDTextBox.Text = stockId;
                    updateDebtorPriceTextBox.Text = price;


                }
                con.Close();

            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
            }


        }

        private void updateSearchDebtor_TextChanged(object sender, EventArgs e)
        {
            //showDebtorData();
           filterDatabase();
        }

        private void updateDebtorButton_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show("Are you sure you want to make the following changes?","UPDATE DEBTOR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                updateDebtor();
             
            }
           
        }

        private void UpdateDebtor_Load(object sender, EventArgs e)
        {

        }

        private void updateDrugCombo_SelectedIndexChanged(object sender, EventArgs e)
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
                    stockDrugQuantityTextbox.Text = " Available Drug Quantity is : " + qty;
                }
                con.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
            
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
            if (System.Text.RegularExpressions.Regex.IsMatch(updateDebtorDepositTextBox.Text, "[^ 0-9]"))
            {
                updateDebtorDepositTextBox.Text = "";
            }
        }

        private void updatePhone_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(updatePhone.Text, "[^ 0-9]"))
            {
                updatePhone.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveToSales();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void updateDebtorName_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchDebtorIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(searchDebtorIDTextBox.Text, "[^ 0-9]"))
            {
                searchDebtorIDTextBox.Text = "";
            }

            showDebtorData();
        }


        public void CheckStockQuantity()
        {
            try
            {
                decimal qty = Convert.ToDecimal(stkQtyLabel.Text);
                decimal debtorQty = Convert.ToDecimal(updateQuantity.Text);
                decimal price = Convert.ToDecimal(updateDebtorPriceTextBox.Text);

                decimal originalQuantity = Convert.ToDecimal(originalQuantityLabel1.Text);

                if (qty >= debtorQty)
                {
                    remainingQtylabel.ForeColor = Color.Green;
                    remainingQtylabel.Text = "REMAINING STOCK QUANTITY IS : " + (qty - debtorQty + originalQuantity);

                    amountLabel.Text = (debtorQty * price) + "Kshs.";
                    totalAmountLabel1.Text = (debtorQty * price).ToString();
                }
                else
                {
                    remainingQtylabel.ForeColor = Color.Red;
                    remainingQtylabel.Text = "NO SUCH QUANTITY IN STOCK. REMAINING STOCK QUANTITY IS : " + qty;
                }

            }
            catch (Exception  )
            {
                //MessageBox.Show(ex.Message);
                remainingQtylabel.Text = string.Empty;
            }
        }


        public void ReverseStockQuantity()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand mc = new MySqlCommand("UPDATE stock set quantity_sold=(quantity_sold - " + this.originalQuantityLabel1.Text + "), status='1' WHERE stock_id= '" + this.stockIDTextBox.Text + "' ", con);
                mc.ExecuteNonQuery();          
                //MessageBox.Show("reverse method called!!!");
                con.Close();
            }
            catch (Exception)
            {

            }
            finally 
            { 
            
            }
        
        }

        public void UpdateDebtorAgain()
        {
            try
            {
               
                string borrowedDate = updateDateBorrowed.Value.ToString("yyyy-MM-dd");
                string dop = dateOfPayment.Value.ToString("yyyy-MM-dd");

                decimal amount = Convert.ToDecimal(totalAmountLabel1.Text);
                decimal deposit = Convert.ToDecimal(updateDebtorDepositTextBox.Text);

               
               if (amount <= deposit)
                {

                    double debtorPrice = Convert.ToDouble(updateQuantity.Text);
                    double debtorQuantity = Convert.ToDouble(updateDebtorPriceTextBox.Text);

                    MySqlConnection con = new MySqlConnection(db);
                    con.Open();

                    MySqlCommand c = new MySqlCommand("UPDATE `debtor` SET stock_id='" + this.stockIDTextBox.Text + "',pfno='" + this.updatedebtorpfsession.Text + "',date_borrowed='" + borrowedDate + "',date_of_payment='" + dop + "',quantity='" + this.updateQuantity.Text + "',price='" + this.updateDebtorPriceTextBox.Text + "', deposit='" + (debtorPrice * debtorQuantity) + "', name='" + this.updateDebtorName.Text + "', phone='" + this.updatePhone.Text + "' WHERE id='" + this.updateDebtorPrimaryKey.Text + "'", con);

                    c.ExecuteNonQuery();
                    MessageBox.Show("Debt Updated successfully. And is Settled.", "UPDATE DEBTOR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();

                    insertToSales();

                }
                else 
                {
                    MessageBox.Show("Calling this section");
                    con.Open();

                    MySqlCommand c = new MySqlCommand("UPDATE `debtor` SET stock_id='" + this.stockIDTextBox.Text + "',pfno='" + this.updatedebtorpfsession.Text + "',date_borrowed='" + borrowedDate + "',date_of_payment='" + dop + "',quantity='" + this.updateQuantity.Text + "',price='" + this.updateDebtorPriceTextBox.Text + "', deposit='" + this.updateDebtorDepositTextBox.Text + "', name='" + this.updateDebtorName.Text + "', phone='" + this.updatePhone.Text + "' WHERE id='" + this.updateDebtorPrimaryKey.Text + "'", con);

                    c.ExecuteNonQuery();
                    MessageBox.Show("Debt Updated successfully.", "UPDATE DEBTOR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { 
            
            }
        
        }

        // Insert to sales from cart
        public void insertToSales()
        {


            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);


            try
            {
                MessageBox.Show("CALLING SALES");
                   

                //current date
                DateTime curdate = DateTime.Now;
                String dateCurrent = curdate.ToString("yyyy-MM-dd");

                con.Open();

                MySqlCommand c = new MySqlCommand("INSERT INTO sales VALUES(NULL,'99','" + this.stockIDTextBox.Text + "','" + this.updateQuantity.Text + "','" + this.updateDebtorPriceTextBox.Text + "','" + this.updatedebtorpfsession.Text + "','" + dateCurrent + "','DEBTOR','0.00')", con);
                c.ExecuteNonQuery();
                // cashSaleDelete();
                MessageBox.Show("SUCCESS", "SECSESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        // Update stock
        public void updateStockAgain()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("UPDATE stock set quantity_sold=(quantity_sold + '" + this.updateQuantity.Text + "') WHERE `stock`.`stock_id` ='" + this.stockIDTextBox.Text + "'", con);
                mc.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception)
            {

            }
        }

        private void stkQtyLabel_Click(object sender, EventArgs e)
        {
            CheckStockQuantity();
        }

        private void updateQuantity_TextChanged(object sender, EventArgs e)
        {
            CheckStockQuantity();
        }

        private void updateDebtorPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckStockQuantity();
        }

        private void remainingQtylabel_Click(object sender, EventArgs e)
        {

        }

    }
}
