using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using PHARMACY.PrintingControl;

namespace PHARMACY
{
    public partial class drugDetails : Form
    {
        DataTable dt;
        DataTable dtdelete = new DataTable();
        DialogResult dialog;

       
         
        /// MySqlConnection con = null;
        public string drug_name { get; set; }
        public string quantity { get; set; }
        public string units { get; set; }
        public string price { get; set; }
        public string total_amount { get; set; }
        // public string sum { get; set; }

        public drugDetails()
        {
          
        }

        public drugDetails(String mess, string firstname, string lastname)
        {
            InitializeComponent();
            firstNameTextBox.Text = firstname;
            lastNameTextBox.Text = lastname;
            //Welcome user.
            welcomeLabel.Text = firstname;
         
            setTime();
            cartQuantityTextBox.Text = "0.00";
            cartStockIDtextBox.Text = "0";
            searchDrug();
            cartView();
            // totalAmount();
            pfsession.Text = mess;
            timer1.Start();
           
            checkCart();
            getVat();
        }

        // Not so important BUT NECESSAR /////////////#######################################################################################3

        //set time
        public void setTime()
        {
            DateTime salestime = DateTime.Now;
            string time = salestime.ToString("yyyy-MM-dd");
        }

        // Get vat tax from database.
        public void getVat()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand c = new MySqlCommand("SELECT * FROM vat", con);

                MySqlDataReader reader = c.ExecuteReader();

                while (reader.Read())
                {
                    string vat = reader.GetString("vat_value");
                    vatTextBox.Text = vat;
                }
                con.Close();
            }
            catch (Exception )
            {
              //  MessageBox.Show("Error Has occured" + ex.Message);
            }
        }
       
        // end Not so important BUT NECESSAR /////////////#######################################################################################3


        //clear fields
        public void clearFields()
        {
           cashSaleTotal.Text = string.Empty;
           cashSaleAmountTextBox.Text = string.Empty;
           cashSaleDiscount.Text = string.Empty;
           cashSaleBalance.Text = string.Empty;
           cashSaleDrugSearch.Text = string.Empty;
           cashSaleQuantity.Text = string.Empty;
           pricePerUnit.Text = string.Empty;
           stockIDTextBox.Text = string.Empty;
           drugDetailsLabel.Text = string.Empty;
           setSerial.Text = string.Empty;
           cartQuantityTextBox.Text = "0.00";
           cartStockIDtextBox.Text = "0";
           }

        //clear drug search field
        public void clearDrugSearch()
        {
            cashSaleDrugSearch.Text = string.Empty;
            cashSaleQuantity.Text = string.Empty;
            pricePerUnit.Text = string.Empty;
            drugStockQuantityTextBox.Text = string.Empty;
            stockIDTextBox.Text = string.Empty;
            drugDetailsLabel.Text = string.Empty;
            setSerial.Text = string.Empty;
            cartQuantityTextBox.Text = "0.00";
            cartStockIDtextBox.Text = "0";
         }
        //check for data in cart

        public void checkCart()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM cart", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                if (count >= 1)
                {
                    totalAmount();
                }

                con.Close();

            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
            }
        }


        // Search drug from stock
        public void searchDrug()
        {
            cashSaleDrugSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cashSaleDrugSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand c = new MySqlCommand("SELECT `drug`.`name` AS 'drug_name',`stock`.`batch_no` AS 'batch_no',`stock`.`expiry_date` AS 'drug_exiry_date',`stock`.`stock_id` AS 'stock_id' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` WHERE ((`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0) AND (`stock`.`status`='1')) GROUP BY `stock`.`drug_id` ORDER BY `drug`.`name` ASC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    
                    string drugName = r.GetString("drug_name");

                    collection.Add(drugName);
                   
                }
                con.Close();
            }
            catch (Exception ex) {
                MessageBox.Show("ERROR "+ex.Message);
            }
            cashSaleDrugSearch.AutoCompleteCustomSource = collection;
              }


        // Fetch stock id from stock and use the.
        public void stockIDKey()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand mc = new MySqlCommand("SELECT `drug`.`name` AS 'drug_name',`stock`.`batch_no` AS 'batch_no',`stock`.`expiry_date` AS 'drug_exiry_date',`stock`.`stock_id` AS 'stock_id',`stock`.`selling_price` AS 'selling_price', (`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'remaining_quantity' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` WHERE ((`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0) AND (`stock`.`status`='1') AND (`drug`.`name`='" + this.cashSaleDrugSearch.Text + "'))  GROUP BY `stock`.`drug_id` ORDER BY `drug`.`name` ASC", con);
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {

                    string stockID = nn.GetString("stock_id");
                    string batchNo = nn.GetString("batch_no");
                    string expiryDate = nn.GetString("drug_exiry_date");

                    string qty = nn.GetString("remaining_quantity");
                    string drug = "BATCH : " + batchNo + " | EXP DATE : " + expiryDate + " | STOCK QUANTITY : "+qty+" ";
                    string pr = nn.GetString("selling_price");

                    drugDetailsLabel.Text = drug;
                    drugDetailsLabel.ForeColor = Color.Blue;
                    pricePerUnit.Text = pr;
                    stockIDTextBox.Text = stockID;
                    drugStockQuantityTextBox.Text = qty;

                }

                con.Close();

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

            
        }


        //view drugs in cart

        public void cartView()
        {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                MySqlCommand com = new MySqlCommand("SELECT `cart`.`cart_id` AS 'Item Id',`stock`.`stock_id` AS 'Stock ID', `drug`.`name` AS 'Drug Name',`cart`.`quantity` AS 'Quantity',`cart`.`price` AS 'Price', ROUND((`cart`.`quantity`*`cart`.`price`),2) AS 'Total Amount',`stock`.`units` AS 'Units' FROM drug JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `cart` ON `stock`.`stock_id`=`cart`.`stock_id` ORDER BY `cart`.`cart_id` DESC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dt = new DataTable();

                // Add autoincrement column.
                dt.Columns.Add("No.", typeof(string));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["No."] };
                dt.Columns["No."].AutoIncrement = true;
                dt.Columns["No."].AutoIncrementSeed = 1;
                dt.Columns["No."].ReadOnly = true;
                // End adding AI column.

               a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                saleDashboardDataGridView.DataSource = bs;

                // SET ITEMID COLUMN TO HAVE SMALL WIDTH AND INVISIBLE.
                saleDashboardDataGridView.Columns["No."].Width = 100;
                saleDashboardDataGridView.Columns["Item Id"].Visible = false;
                saleDashboardDataGridView.Columns["Stock ID"].Visible = false;
                saleDashboardDataGridView.Columns["Drug Name"].Width=450;
                saleDashboardDataGridView.Columns["Quantity"].Width = 200;
                saleDashboardDataGridView.Columns["Price"].Width = 200;
                saleDashboardDataGridView.Columns["Total Amount"].Width = 200;

                // END setting them invisible.
                a.Update(dt);
             
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(saleDashboardDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " items";
            }
            catch (Exception)
            {
               // MessageBox.Show(ex.Message);
            }
        }

       

        //Compute total amount
        public void totalAmount()
        {

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                MySqlCommand mc = new MySqlCommand("SELECT ROUND(SUM(quantity*price),2) AS amount FROM cart", con);
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {
                    // String am = nn.GetInt32("amount").ToString();
                    string am = nn.GetDouble("amount").ToString();
                    cashSaleTotal.Text = am;

                }

                con.Close();

            }
            catch (Exception)
            {
               // MessageBox.Show(ex.Message);
            }

        }


        public void checkDrugStockQuantity()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();



                MySqlCommand mc = new MySqlCommand("SELECT SUM(quantity) AS 'quantity', stock_id FROM cart WHERE stock_id='" + this.stockIDTextBox.Text + "' ", con);
                MySqlDataReader nn = mc.ExecuteReader();

               // int count = 0;

                while (nn.Read())
                {
                    string stockID = nn.GetString("stock_id");
                    string qty = nn.GetString("quantity");

                    cartStockIDtextBox.Text = stockID;
                    cartQuantityTextBox.Text = qty;

                   // count += 1;
                }

                con.Close();

              //  if (count == 0)
              //  {
              //      cartQuantityTextBox.Text = "0";
              //  }

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        //Compute Balance
        public void computeBalance()
        {

            try
            {

                if ((this.cashSaleTotal.Text != ""))
                {

                    double amt = Convert.ToDouble(cashSaleAmountTextBox.Text);
                    double total = Convert.ToDouble(cashSaleTotal.Text);


                    if (string.IsNullOrEmpty(this.cashSaleDiscount.Text))
                    {

                        double ans = (amt - total);
                        cashSaleBalance.Text = "Balence : " + Convert.ToString(ans);

                    }
                    else
                    {
                        //int disc = Convert.ToInt32(cashSaleDiscount.Text);
                        double disc = Convert.ToDouble(cashSaleDiscount.Text);

                        double ans = ((amt + disc) - total);
                        cashSaleBalance.Text = "Balence : "+Convert.ToString(ans);

                    }
                }
                else
                {
                  //  MessageBox.Show("No Product!","NO DRUG",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cashSaleBalance.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                cashSaleBalance.Text = string.Empty;
               // MessageBox.Show("No amount","NO AMOUNT",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        //deletes all records from cart
        public void cashSaleDelete()
        {

           

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                //current date
                DateTime curdate = DateTime.Now;
                string dateCurrent = curdate.ToString("yyyy-MM-dd");

                //convert loginusername to integer
                int pf = Convert.ToInt32(pfsession.Text);

                con.Open();
                MySqlCommand mc = new MySqlCommand("DELETE FROM cart", con);
                MySqlDataReader nn = mc.ExecuteReader();
                while (nn.Read())
                {
                }
                //MessageBox.Show("All Data Deleted Successfull");
                nn.Close(); //close rader

                //insert to events
                MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + pf + "','" + dateCurrent + "',Deleted drugs worth Kshs. '" + this.cashSaleTotal.Text + "')", con);
                me.ExecuteNonQuery();

                con.Close(); //close connection

            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
            }

            cartView(); //displays the cart method

        } //end delete from cart method
        //String.IsNullOrEmpty(this.cashSaleDiscount.Text)

        public void DrugQuantityAlert()
        { 
                    try
                    {
                        double qty = Convert.ToDouble(cashSaleQuantity.Text);
                        double cartQty = Convert.ToDouble(cartQuantityTextBox.Text);
                        double stockQty = Convert.ToDouble(drugStockQuantityTextBox.Text);

                        if ((stockQty - cartQty) >= qty)
                        {
                            remainedDrugQuantitylabel.ForeColor = Color.Green;
                            remainedDrugQuantitylabel.Text = "REMAINING QTY : " + (stockQty - cartQty);
                        }
                        else
                        {
                            remainedDrugQuantitylabel.Text = "THE QUANTITY IS MORE THAN WHAT IS IN THE STOCK . REMAINING QTY : " + (stockQty - cartQty);
                            remainedDrugQuantitylabel.ForeColor = Color.Red;
                        }
                    }
                    catch (Exception)
                    {
                        remainedDrugQuantitylabel.Text = string.Empty;
                    }
        }

        //insert into cart
        public void insertToCart()
        {

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            if ((this.cashSaleDrugSearch.Text != string.Empty) && (this.cashSaleQuantity.Text != string.Empty) && (this.pricePerUnit.Text != string.Empty))
            {


                try
                {
                    con.Open();
                    double qty = Convert.ToDouble(cashSaleQuantity.Text);
                    double cartQty = Convert.ToDouble(cartQuantityTextBox.Text);
                    double stockQty = Convert.ToDouble(drugStockQuantityTextBox.Text);

                    int stockStockID = int.Parse(stockIDTextBox.Text);
                    int cartStockID = int.Parse(cartStockIDtextBox.Text);

                    if ((stockQty - cartQty) >= qty)
                    {

                        if (stockStockID == cartStockID)
                        {
                            DateTime dt = DateTime.Now;
                            String dateNow = dt.ToString("yyyy-MM-dd");
                            // int drid = Convert.ToInt32(drugidforeignkey.Text);
                            int pfs = Convert.ToInt32(pfsession.Text);
                            //int pr = Convert.ToInt32(priceforeignkey.Text);

                            MySqlCommand c = new MySqlCommand("UPDATE cart SET quantity=(quantity + ('" + this.cashSaleQuantity.Text + "'))  WHERE stock_id='" + this.stockIDTextBox.Text + "' ", con);

                            c.ExecuteNonQuery();
                        }
                        else
                        {

                            DateTime dt = DateTime.Now;
                            String dateNow = dt.ToString("yyyy-MM-dd");
                            // int drid = Convert.ToInt32(drugidforeignkey.Text);
                            int pfs = Convert.ToInt32(pfsession.Text);
                            //int pr = Convert.ToInt32(priceforeignkey.Text);

                            MySqlCommand c = new MySqlCommand("INSERT INTO cart VALUES(NULL,'" + this.stockIDTextBox.Text + "','" + this.cashSaleQuantity.Text + "','" + this.pricePerUnit.Text + "')", con);

                            c.ExecuteNonQuery();
                        }

                    }
                    else
                    {

                        MessageBox.Show("The quantity you entered is more than what is in the stock. : " + (stockQty - cartQty), "EXCESS QUANTITY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    con.Close();

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro has occured    " + ex.Message);
                }

                cartView();//display in grid
                totalAmount();//display in total

            }
            else
            {
                MessageBox.Show("Wrong Operation!","WRONG OPERATION",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }


        }
        //end insert to cart method



        public void removeFromCart()
        {

            try
            {

                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                if (saleDashboardDataGridView.SelectedRows.Count > 0)
                {

                    int selectedIndex = saleDashboardDataGridView.SelectedRows[0].Index;
                    int RowID = int.Parse(saleDashboardDataGridView[1, selectedIndex].Value.ToString());

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM cart WHERE cart_id = " + RowID + "", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("No data selected","NO DRUG SELECTED",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has occured!"+ex.Message);
            }
            cartView();


        }


        //update net stock
        public void updateStock()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("UPDATE stock set quantity_sold=(quantity_sold+@quantity) WHERE stock_id=@stock_id", con);

                foreach (DataRow row in dt.Rows)
                {
                    mc.Parameters.Clear();
                    mc.Parameters.AddWithValue("@stock_id", row["Stock ID"]);
                    mc.Parameters.AddWithValue("@quantity", row["quantity"]);
                    mc.ExecuteNonQuery();
                }
                con.Close();
            }
            catch (Exception )
            {

               // MessageBox.Show("Problem has occured while updating net stock" + ex.Message);
            }
        }


        // Insert to sales from cart
        public void insertToSales()
        {

            //current date
            DateTime curdate = DateTime.Now;
            String dateCurrent = curdate.ToString("yyyy-MM-dd");

            //convert loginusername to integer
            int pf = Convert.ToInt32(pfsession.Text);

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);


            try
            {

                con.Open();

                if (!string.IsNullOrWhiteSpace(cashSaleDiscount.Text))
                {
                    MySqlCommand c = new MySqlCommand("INSERT INTO sales VALUES(NULL,@cart_id,@stock_id,@quantity,@price,'" + this.pfsession.Text + "','" + dateCurrent + "','" + this.setSerial.Text + "','" + this.cashSaleDiscount.Text + "')", con);

                    foreach (DataRow row in dt.Rows)
                    {

                        //  Random rn = new Random();
                        // int serial=rn.Next(10,20);

                        c.Parameters.Clear();

                        c.Parameters.AddWithValue("@cart_id", row["Item Id"]);
                        c.Parameters.AddWithValue("@stock_id", row["Stock ID"]);
                        c.Parameters.AddWithValue("@quantity", row["Quantity"]);
                        c.Parameters.AddWithValue("@price", row["Price"]);

                        c.ExecuteNonQuery();

                    }

                }
                else
                {
                    MySqlCommand c = new MySqlCommand("INSERT INTO sales VALUES(NULL,@cart_id,@stock_id,@quantity,@price,'" + this.pfsession.Text + "','" + dateCurrent + "','" + this.setSerial.Text + "','0.00')", con);

                    foreach (DataRow row in dt.Rows)
                    {

                        //  Random rn = new Random();
                        // int serial=rn.Next(10,20);

                        c.Parameters.Clear();

                        c.Parameters.AddWithValue("@cart_id", row["Item Id"]);
                        c.Parameters.AddWithValue("@stock_id", row["Stock ID"]);
                        c.Parameters.AddWithValue("@quantity", row["Quantity"]);
                        c.Parameters.AddWithValue("@price", row["Price"]);

                        c.ExecuteNonQuery();

                    }
                }


                updateStock();

                // cashSaleDelete();
                MessageBox.Show("SUCCESS","SECSESS",MessageBoxButtons.OK,MessageBoxIcon.Information);

                //insert to events
                MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + pf + "','" + dateCurrent + "','sold drugs worth kshs. '" + this.cashSaleTotal.Text + "')", con);
                me.ExecuteNonQuery();


                con.Close();

                cartView();
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
            }
        }



        //events methods

        //logout method
        public void logoutEvent()
        {
            //current date
            DateTime curdate = DateTime.Now;
            String dateCurrent = curdate.ToString("yyyy-MM-dd");

            //convert loginusername to integer
            int pf = Convert.ToInt32(pfsession.Text);

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            try
            {
                con.Open();

                MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + pf + "','" + dateCurrent + "','logged out')", con);
                me.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {

            }

        }

        //viewed admin help method
        public void adminHelpEvent()
        {
            //current date
            DateTime curdate = DateTime.Now;
            String dateCurrent = curdate.ToString("yyyy-MM-dd");

            //convert loginusername to integer
            int pf = Convert.ToInt32(pfsession.Text);

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            try
            {
                con.Open();

                MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + pf + "','" + dateCurrent + "','Viewed admin help')", con);
                me.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {

            }

        }

        private void updateStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStock u = new UpdateStock(pfsession.Text);
            u.ShowDialog();
        }

        private void addStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStaff a = new AddStaff();
            a.ShowDialog();
        }

        private void viewStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStaff v = new ViewStaff();
            v.ShowDialog();
        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSupplier ad = new AddSupplier(pfsession.Text);
            ad.ShowDialog();
        }

        private void viewSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSupplier v = new ViewSupplier();
            v.ShowDialog();
        }

        private void addDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDrug a = new AddDrug(pfsession.Text);
            a.ShowDialog();
        }

        private void viewDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDrug v = new ViewDrug();
            v.ShowDialog();
        }

        private void addStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStock a = new AddStock(pfsession.Text);
            a.ShowDialog();
        }

        private void viewStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStock v = new ViewStock();
            v.ShowDialog();
        }

        private void addDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDebtor a = new AddDebtor(pfsession.Text);
            a.ShowDialog();
        }

        private void viewDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDebtor v = new ViewDebtor();
            v.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string time = dt.ToString();
        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


        private void updateDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDrug u = new UpdateDrug(pfsession.Text);
            u.ShowDialog();
        }

        private void updateSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSupplier u = new UpdateSupplier(pfsession.Text);
            u.ShowDialog();
        }

        private void updateDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDebtor u = new UpdateDebtor(pfsession.Text);
            u.ShowDialog();
        }

        private void updateStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStaff u = new UpdateStaff();
            u.Show();
        }

        private void pfsession_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cashSaleDiscount.Text, "[^ 0-9]"))
            {
                cashSaleDiscount.Text = "";
            }
            computeBalance();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cashSaleAmountTextBox.Text, "[^ 0-9]"))
            {
                cashSaleAmountTextBox.Text = "";
            }

            computeBalance();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void saleDashboardDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void msg_Click(object sender, EventArgs e)
        {

        }

        private void cashSaleDrugSearch_TextChanged(object sender, EventArgs e)
        {
            stockIDKey();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insertToCart();
            clearDrugSearch();
            cashSaleDrugSearch.Select();
           

        }

        private void drugidforeignkey_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             dialog = MessageBox.Show("Are you sure you want to cancel the transaction ?", "CANCEL SALES", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

             if (dialog == DialogResult.Yes)
             {
                 cashSaleDelete();
                 clearFields();
                 cashSaleDrugSearch.Select();
             }
             cashSaleDrugSearch.Select();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            Int64 count = Convert.ToInt64(saleDashboardDataGridView.Rows.Count) - 1;

            if ((this.cashSaleTotal.Text != "") && (count > 0))
            {
                // Generate receipt serial number first.
                Random rd = new Random();
                int serial = rd.Next(1, 1000000000);
                setSerial.Text = serial.ToString();

                // Call the print method from printReceipt class to print the client receipt.
                // Print receipr before clearing the window.
            //    print(sender, e); ################# UNCOMMENT THIS LINE TO ENABLE PRINTING.
                // End printing the receipt.
              

                 insertToSales();
                //salesReceipt();
                clearFields();
                cashSaleDelete();
                cashSaleDrugSearch.Select();
                
                /*
                // Close to refresh.
                this.Hide();
                drugDetails cashSale = new drugDetails(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
                cashSale.ShowDialog();
                this.Close();

                // Open Again.
                drugDetails cs = new drugDetails(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
                cs.ShowDialog();
                */
            }
            else
            {
                MessageBox.Show("The drug name you entered does not exist ", "NO SUCH DRUG", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cashSaleDrugSearch.Select();
            }
           
        }

        private void cashSalePay_Click(object sender, EventArgs e)
        {
           
            computeBalance();
            cashSaleDrugSearch.Select();
        }

        private void viewSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewSales s = new viewSales();
            s.ShowDialog();
        }

        private void viewNetStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewNetStock v = new ViewNetStock();
            v.Show();
        }

        private void cashSaleRemove_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show("Are you sure you want to remove the drug?", "REMOVE DRUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                removeFromCart();
                totalAmount();
                cashSaleDrugSearch.Select();
            }
            cashSaleDrugSearch.Select();
        }

        private void quantitySale_Click(object sender, EventArgs e)
        {
        }

        private void drugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void priceforeignkey_TextChanged(object sender, EventArgs e)
        {

        }

        private void unitforeignkey_TextChanged(object sender, EventArgs e)
        {

        }

        private void pricePerUnit_TextChanged(object sender, EventArgs e)
        {

        }

        private void cashSaleQuantity_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cashSaleQuantity.Text, "[^ 0-9]"))
            {
                cashSaleQuantity.Text = "";
            }
            DrugQuantityAlert();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports r = new Reports(this.pfsession.Text);
            r.ShowDialog();
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logoutEvent();

            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculator c = new Calculator();
            c.ShowDialog();
        }

        private void cashSaleBalance_TextChanged(object sender, EventArgs e)
        {

        }

        private void setSerial_TextChanged(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminHelpEvent();
            System.Diagnostics.Process.Start("C:\\PMS\\Support\\admin manual.pdf");
        }

        private void cashSaleTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportDatabase export = new ExportDatabase();
            export.ShowDialog();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportDatabase import = new ImportDatabase();
            import.ShowDialog();
        }

        ///////////////////////////////////GENERATE RECEIPT AND PRINT IT //////////////////////////////////////////


        public void createReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs events)
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            //current date and time of sale.
            DateTime curdate = DateTime.Now;
            String timeOfSale = curdate.ToString();

            // Get vat from textBox.
            double vat = Convert.ToDouble(vatTextBox.Text);
            double cost = Convert.ToDouble(cashSaleTotal.Text);

            double vatableAmount = (vat / 100) * cost;

            con.Open();
            MySqlCommand command = new MySqlCommand("SELECT drug_name AS 'DRUG NAME',quantity AS 'QTY',price AS 'PRICE',quantity*price AS 'TOTAL',unit AS 'UNITS' FROM cart ORDER BY cart_id ASC", con);
            MySqlDataReader reader = command.ExecuteReader();

            //create a new instance of printReceipt class
            drugDetails newPrintReceipt = new drugDetails();

            //print the receipt layout first

            Graphics graphic = events.Graphics;

            System.Drawing.Font font = new System.Drawing.Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 150;

            // Locate the image of the receipt.
            System.Drawing.Image headerImage = System.Drawing.Image.FromFile("C:\\PMS\\Resources\\faith2.png");
            graphic.DrawImage(headerImage, startX, startY, 830, 150);

            // This is the title of the receipt. Put the address here.
            string headerText = "SAMPLE PHARMACY\n".PadLeft(35)+" P.O BOX XXX\n".PadLeft(35)+" TOWN\n".PadLeft(35)+" PHONE +254 XXX XXX XXX".PadLeft(35);
            graphic.DrawString(headerText, new System.Drawing.Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 55; //make the spacing consistent

            graphic.DrawString("-----------------------------------------------------------------------------------".PadLeft(55), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 7; //make the spacing consistent

            graphic.DrawString("Drug Name |".PadRight(5) + " Qty |".PadRight(5) + " Price |".PadRight(5) + " Total |".PadRight(5) + " Units".PadRight(5), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            graphic.DrawString("--------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            while (reader.Read())
            {
                try
                {
                    newPrintReceipt.drug_name = reader.GetString(0);
                    newPrintReceipt.quantity = reader.GetString(1);
                    newPrintReceipt.price = reader.GetString(2);
                    newPrintReceipt.total_amount = reader.GetString(3);
                    newPrintReceipt.units = reader.GetString(4);

                    graphic.DrawString(newPrintReceipt.drug_name.PadRight(12) + newPrintReceipt.quantity.PadRight(5) +
                                       newPrintReceipt.price.PadRight(9) + newPrintReceipt.total_amount.PadRight(5) + newPrintReceipt.units.PadRight(7), font, new SolidBrush(Color.Black), startX, startY + offset);

                    offset = offset + (int)fontHeight; //make the spacing consistent

                    graphic.DrawString("--------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight + 5; //make the spacing consistent.
                }
                catch (InvalidCastException er)
                {
                    MessageBox.Show(er.Message);
                }
            }

            con.Close();

            offset = offset + 5; //make some room so that the footer stands out.

            graphic.DrawString("Total items bought : ".PadLeft(5) + rowCountLabel.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Total Cost : ".PadLeft(5) + cashSaleTotal.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("VAT : ".PadLeft(5) + vatTextBox.Text + " %     VAT amount : " + vatableAmount, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Amount received : ".PadLeft(5) + cashSaleAmountTextBox.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Discount : ".PadLeft(5) + cashSaleDiscount.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Change : ".PadLeft(5) + cashSaleBalance.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Served by : ".PadLeft(5) + firstNameTextBox.Text + "  " + lastNameTextBox.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Date of purchase : ".PadLeft(5) + timeOfSale, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Receipt serial no. : ".PadLeft(5) + setSerial.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("PRICES INCLUSIVE OF VAT WHERE APPLICABLE ".PadLeft(5), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 25;
            graphic.DrawString("Thank you and welcome again!! ".PadLeft(5), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 25;
            graphic.DrawString("Sample Pharmacy \"TOUCHING LIVES REACHING PEOPLE.\"".PadLeft(20), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("DESIGNED BY TESMOLITE TECHNOLOGIES.".PadLeft(20), font, new SolidBrush(Color.Black), startX, startY + offset + 20);

        }


        public void print(object sender, EventArgs e)
        {
            try
            {

                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument; //add the document to the dialog box...

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(createReceipt); //add an event handler that will do the printing

                printDocument.Print();

                //DialogResult result = printDialog.ShowDialog();


                //if (result == DialogResult.OK)
                // {
                printDocument.Print();

                //}
            }
            catch (Exception)
            {
                MessageBox.Show("Something wrong has occured while printing receipt.  ", "RECEIPT PRINTING ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            { 
            
            }

        }

    
       /////////////////////////////END PRINT RECEIPT ////////////////////////////////////////////////////////
        
        
        // Key press events and shortcut.
        private void Dashboard_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Dashboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {// Insert drug to cart.
               // insertToCart();
               // clearDrugSearch();
               // cashSaleDrugSearch.Select();

            }
            else if (e.Control && e.KeyCode == Keys.R)
            {// Remove drug from cart.
                dialog = MessageBox.Show("Are you sure you want to remove the drug?", "REMOVE DRUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    removeFromCart();
                    totalAmount();
                    cashSaleDrugSearch.Select();
                }
                cashSaleDrugSearch.Select();
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {// Cancel transaction.
                dialog = MessageBox.Show("Are you sure you want to cancel the transaction ?", "CANCEL SALES", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    cashSaleDelete();
                    clearFields();
                    cashSaleDrugSearch.Select();
                }
                cashSaleDrugSearch.Select();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {// Sale drugs.
                Int64 count = Convert.ToInt64(saleDashboardDataGridView.Rows.Count) - 1;

                if ((this.cashSaleTotal.Text != "") && (count > 0))
                {
                    // Generate receipt serial number first.
                    Random rd = new Random();
                    int serial = rd.Next(1, 1000000000);
                    setSerial.Text = serial.ToString();

                    // Call the print method from printReceipt class to print the client receipt.
                    // Print receipr before clearing the window.
                    print(sender, e);
                    // End printing the receipt.

                    insertToSales();
                    //salesReceipt();
                    clearFields();
                    cashSaleDelete();
                    cashSaleDrugSearch.Select();
                }
                else
                {
                    MessageBox.Show("No Drug");
                    cashSaleDrugSearch.Select();
                }
            }
            else if (e.Control && e.KeyCode == Keys.P)
            {// Calculate balance.
                computeBalance();
                cashSaleDrugSearch.Select();
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {// Focus cursor on amount.
                cashSaleAmountTextBox.Select();
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {// Open A calculator.
                Calculator c = new Calculator();
                c.ShowDialog();
            }
            
            /*
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Enter Drug to cart.");

            }
            else if (e.Control && e.KeyCode == Keys.R)
            {
                MessageBox.Show("CTRL+R for remove drug.");
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                MessageBox.Show("CTRL+C for canceling sales transaction.");
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                MessageBox.Show("CTRL+S for selling drugs.");
            }
            else if (e.Control && e.KeyCode == Keys.P)
            {
                MessageBox.Show("CTRL+P for calculating the balance drug sale.");
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                MessageBox.Show("CTRL+A for for entering amount from client.");
            }
            */
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Calculator c = new Calculator();
            c.ShowDialog();
        }

        private void drugDetailsLabel_Click(object sender, EventArgs e)
        {
           
        }

        private void stockIDTextBox_TextChanged(object sender, EventArgs e)
        {
            checkDrugStockQuantity();
        }
    }
}
