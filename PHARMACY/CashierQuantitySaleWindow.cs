using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Printing;

namespace PHARMACY
{
    public partial class CashierQuantitySaleWindow : Form
    {
        // Calculator properties starts here.
        Double results = 0;
        String operation = "";
        bool isOperationPerformed = false;
        
        // End.
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

        public CashierQuantitySaleWindow()
        {
            //Initialize connection string.
            //  con = DBHandler.CreateConnection();
        }
        public CashierQuantitySaleWindow(String mess, string firstname, string lastname)
        {
            InitializeComponent();
            firstNameTextBox.Text = firstname;
            lastNameTextBox.Text = lastname;
            //Welcome user.
            welcomeLabel.Text = firstname;
           

            setTime();

            searchDrug();
           cartView();
            // totalAmount();
            msg.Text = mess;
            pfsession.Text = mess;
            timer1.Start();
            getImage();

            checkCart();
            getVat();
        }

        //set time
        public void setTime()
        {
            DateTime salestime = DateTime.Now;
            string time = salestime.ToString();
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
                //MessageBox.Show("Error Has occured" + ex.Message);
            }
        }


        //fetch image from database
        public void getImage()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                //MySqlCommand c = new MySqlCommand("SELECT * from staff ", con);
                MySqlCommand c = new MySqlCommand("SELECT photo,pfno FROM staff WHERE pfno='" + this.pfsession.Text + "'", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    //retrieve image from the database upon the user
                    byte[] imgg = (byte[])(r["photo"]);
                    if (imgg == null)
                    {
                        dashboardPictureBox.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(imgg);
                        dashboardPictureBox.Image = System.Drawing.Image.FromStream(ms);
                    }
                    //end fetching image
                }
                con.Close();
            }
            catch (Exception )
            {
              //  MessageBox.Show("Error Has occured" + ex.Message);
            }
        }


        //clear fields
        public void clearFields()
        {
             cashSaleTotal.Text = string.Empty;
            amountPaidTextBox.Text = string.Empty;
            cashSaleDiscountTextBox.Text = string.Empty;
            cashSaleDrugSearch.Text = string.Empty;
            cashSaleQuantity.Text = string.Empty;
            pricePerUnit.Text = string.Empty;
            cashSaleBalanceTextBox.Text = string.Empty;
            setSerial.Text = string.Empty;
            drugidforeignkey.Text = string.Empty;
            BuyingPriceTextBox.Text = string.Empty;
        }

        //clear drug search field
        public void clearDrugSearch()
        {

            cashSaleDrugSearch.Text = string.Empty;
            cashSaleQuantity.Text = string.Empty;
            pricePerUnit.Text = string.Empty;
            drugidforeignkey.Text = string.Empty;
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


        //search drug from netsock
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
                String dateNow = dtt.ToString("yyyy-MM-dd");
                  MySqlCommand c = new MySqlCommand("select `drug`.`id`,`drug`.`name` FROM `drug` JOIN `net_stock` ON `drug`.`id`=`net_stock`.`drug_id` WHERE (`net_stock`.`quantity`>0 AND DATEDIFF(`net_stock`.`expiry_date`,'" + dateNow + "')>0 AND (`drug`.`status`='Active')) GROUP BY `net_stock`.`drug_id` ORDER BY `drug`.`name` ASC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    String l = r.GetString("name");
                    collection.Add(l);


                }
                con.Close();
            }
            catch (Exception) { 
            
            }
            cashSaleDrugSearch.AutoCompleteCustomSource = collection;


        }

        //view drugs in cart

        public void cartView()
        {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `cart`.`cart_id` AS 'Item Id',`cart`.`drug_id` AS 'Drug ID', `drug`.`name` AS 'Drug Name',`cart`.`quantity` AS 'Quantity',`cart`.`buying_price` AS 'Buying Price',`cart`.`price` AS 'Price', ROUND((`cart`.`quantity`*`cart`.`price`),2) AS 'Total Amount',`cart`.`unit` AS 'Units' FROM drug JOIN `cart` ON `drug`.`id`=`cart`.`drug_id` ORDER BY `cart`.`cart_id` DESC", con);
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
                     saleDashboardDataGridView.Columns["Item Id"].Visible = false;
                     saleDashboardDataGridView.Columns["Drug ID"].Visible = false;
                     saleDashboardDataGridView.Columns["Units"].Visible = false;
                     saleDashboardDataGridView.Columns["Buying Price"].Visible = false;
                     saleDashboardDataGridView.Columns["No."].Width = 75;
                     saleDashboardDataGridView.Columns["Quantity"].Width = 100;
                     //saleDashboardDataGridView.Columns["Buying Price"].Width = 0;
                     saleDashboardDataGridView.Columns["Price"].Width = 75;
                     saleDashboardDataGridView.Columns["Total Amount"].Width = 150;
                     // END setting them invisible.
                    a.Update(dt);
              
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(saleDashboardDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " items";
            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
            }
        }

        //fetch id from drug and use the foreign key
        public void drugForeignKey()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();



                MySqlCommand mc = new MySqlCommand("SELECT `drug`.`id` AS id,`drug`.`name` AS 'drname',`drug`.`buying_price` AS 'Buying_price',`drug`.`price` AS price,`net_stock`.`id` AS net_id,`net_stock`.`drug_id`,`net_stock`.`units` AS units, `net_stock`.`quantity` AS net_Quantity FROM `drug` JOIN `net_stock` ON `drug`.`id`=`net_stock`.`drug_id` WHERE `drug`.`name`='" + this.cashSaleDrugSearch.Text + "'  GROUP BY `drug`.`id`", con);
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {
                    string did = nn.GetInt32("id").ToString();
                    string un = nn.GetString("units");
                    //String pr = nn.GetInt32("price").ToString();
                    string pr = nn.GetDouble("price").ToString();
                    //String qty = nn.GetString("net_Quantity");
                    string qty = nn.GetDouble("net_Quantity").ToString();
                    string drn = nn.GetString("drname");
                    string Buying_price = nn.GetInt32("Buying_price").ToString();

                    BuyingPriceTextBox.Text = Buying_price;
                    drugidforeignkey.Text = did;
                    priceforeignkey.Text = pr;
                    unitforeignkey.Text = un;
                    pricePerUnit.Text = pr;
                    netStockDrugQuantityTextbox.Text = qty;
                    drugnameforeignkey.Text = drn;

                }

                con.Close();

            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
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
                    String am = nn.GetDouble("amount").ToString();
                    cashSaleTotal.Text = am;

                }

                con.Close();

            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
            }

        }


        //Compute Balance
        public void computeBalance()
        {
            try
            {

                if ((this.cashSaleTotal.Text != ""))
                {

                    Double amt = Convert.ToDouble(amountPaidTextBox.Text);
                    Double total = Convert.ToDouble(cashSaleTotal.Text);


                    if (string.IsNullOrEmpty(this.cashSaleDiscountTextBox.Text))
                    {

                        Double ans = (amt - total);
                        cashSaleBalanceTextBox.Text = Convert.ToString(ans);

                    }
                    else
                    {
                        //int disc = Convert.ToInt32(cashSaleDiscount.Text);
                        Double disc = Convert.ToDouble(cashSaleDiscountTextBox.Text);

                        Double ans = ((amt + disc) - total);
                        cashSaleBalanceTextBox.Text = Convert.ToString(ans);

                    }
                }
                else
                {
                    MessageBox.Show("No Drug!","NO DRUG",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No Drug!", "NO DRUG", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        //deletes all records from cart
        public void cashSaleDelete()
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
                MySqlCommand mc = new MySqlCommand("DELETE FROM cart", con);
                mc.ExecuteNonQuery();

                MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + pf + "','" + dateCurrent + "','Canceled drugs worth Kshs. ''" + this.cashSaleTotal.Text + "')", con);
                me.ExecuteNonQuery();

                con.Close(); //close connection

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cartView(); //displays the cart method

        } //end delete from cart method
        //String.IsNullOrEmpty(this.cashSaleDiscount.Text)

        //insert into cart
        public void insertToCart()
        {

            if ((this.cashSaleDrugSearch.Text != "") && (this.cashSaleQuantity.Text != "") && (this.pricePerUnit.Text != ""))
            {


                try
                {
                    
                    Double qty = Convert.ToDouble(cashSaleQuantity.Text);
                    Double netQty = Convert.ToDouble(netStockDrugQuantityTextbox.Text);

                    if (netQty >= qty)
                    {

                        DateTime dt = DateTime.Now;
                        String dateNow = dt.ToString("yyyy-MM-dd");
                        // int drid = Convert.ToInt32(drugidforeignkey.Text);
                        int pfs = Convert.ToInt32(pfsession.Text);
                        //int pr = Convert.ToInt32(priceforeignkey.Text);
                        string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();

                        MySqlCommand c = new MySqlCommand("INSERT INTO cart VALUES(NULL,'" + this.drugidforeignkey.Text + "','" + this.cashSaleQuantity.Text + "','" + this.BuyingPriceTextBox.Text + "','" + this.pricePerUnit.Text + "','" + this.unitforeignkey.Text + "')", con);
                        c.ExecuteNonQuery();

                        con.Close();
                    }
                    else
                    {

                        MessageBox.Show("The quantity you entered is more than what is in the stock.: " + netQty, "EXCESS QUANTITY", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                catch (Exception )
                {
                  //  MessageBox.Show("Erro has occured" + ex.Message);
                }

                cartView();//display in grid
                totalAmount();//display in total

            }
            else
            {
                MessageBox.Show("Wrong Operation!","WRONG OPERATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("No data selected","NO DRUG SELECTED",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
               // MessageBox.Show("Error has occured!");
            }
            cartView();


        }


        //update net stock
        public void updateNetStock()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("UPDATE net_stock set quantity=(quantity-@quantity) WHERE drug_id=@drug_id", con);

                foreach (DataRow row in dt.Rows)
                {
                    mc.Parameters.Clear();
                    mc.Parameters.AddWithValue("@drug_id", row["Drug ID"]);
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



        //insert to sales from cart
        public void insertToSales()
        {
            //current date
            DateTime curdate = DateTime.Now;
            String dateCurrent = curdate.ToString("yyyy-MM-dd");

            //convert loginusername to integer
            int pf = Convert.ToInt32(pfsession.Text);


            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            Random rd = new Random();
            int serial = rd.Next(1, 1000000000);

            setSerial.Text = serial.ToString();



            try
            {

                con.Open();

                if (!string.IsNullOrWhiteSpace(cashSaleDiscount.Text))
                {

                    MySqlCommand c = new MySqlCommand("INSERT INTO sales VALUES(NULL,@cart_id,@drug_id,@quantity,@buying_price,@price,'" + this.pfsession.Text + "','" + dateCurrent + "',@unit,'" + serial + "','" + this.cashSaleDiscount.Text + "')", con);

                    foreach (DataRow row in dt.Rows)
                    {

                        //  Random rn = new Random();
                        // int serial=rn.Next(10,20);

                        c.Parameters.Clear();

                        c.Parameters.AddWithValue("@cart_id", row["Item Id"]);
                        c.Parameters.AddWithValue("@drug_id", row["Drug ID"]);
                        c.Parameters.AddWithValue("@quantity", row["Quantity"]);
                        c.Parameters.AddWithValue("@buying_price", row["Buying Price"]);
                        c.Parameters.AddWithValue("@price", row["Price"]);
                        c.Parameters.AddWithValue("@unit", row["Units"]);

                        c.ExecuteNonQuery();

                    }

                }
                else
                {
                    MySqlCommand c = new MySqlCommand("INSERT INTO sales VALUES(NULL,@cart_id,@drug_id,@quantity,@buying_price,@price,'" + this.pfsession.Text + "','" + dateCurrent + "',@unit,'" + serial + "','0.00')", con);

                    foreach (DataRow row in dt.Rows)
                    {

                        //  Random rn = new Random();
                        // int serial=rn.Next(10,20);

                        c.Parameters.Clear();

                        c.Parameters.AddWithValue("@cart_id", row["Item Id"]);
                        c.Parameters.AddWithValue("@drug_id", row["Drug ID"]);
                        c.Parameters.AddWithValue("@quantity", row["Quantity"]);
                        c.Parameters.AddWithValue("@buying_price", row["Buying Price"]);
                        c.Parameters.AddWithValue("@price", row["Price"]);
                        c.Parameters.AddWithValue("@unit", row["Units"]);

                        c.ExecuteNonQuery();

                    }
                }

                updateNetStock();

                // cashSaleDelete();
                MessageBox.Show("SUCCESS","SUCCESS",MessageBoxButtons.OK,MessageBoxIcon.Information);

                MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + pf + "','" + dateCurrent + "',Sold drugs worth Kshs. '" + this.cashSaleTotal.Text + "')", con);
                me.ExecuteNonQuery();

                cartView();

                con.Close();
            }
            catch (Exception)
            {
               // MessageBox.Show(ex.Message);
            }

        }


        //print receipt for sale
        public void salesReceipt()
        {
            DateTime tm = DateTime.Now;
            string time = tm.ToString();

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\receipt", FileMode.Create));
            doc.Open();//open document to write

            //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\Users\\sam\\Desktop\\C#\\PHARMACY\\PHARMACY\\Resources\\faith2.png");
            //img.ScalePercent(25f);
            //img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);

            //doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                 Pharmacy Management System   serial: " + this.setSerial.Text + "\n\n  ");
            doc.Add(p);


            //load data from datagrid
            PdfPTable table = new PdfPTable(saleDashboardDataGridView.Columns.Count);

            //add headers from the datagridview to the table
            for (int j = 0; j < saleDashboardDataGridView.Columns.Count; j++)
            {

                table.AddCell(new Phrase(saleDashboardDataGridView.Columns[j].HeaderText));

            }

            //flag the first row as header

            table.HeaderRows = 1;

            //add the actual rows to the table from datagridview

            for (int i = 0; i < saleDashboardDataGridView.Rows.Count; i++)
            {
                for (int k = 0; k < saleDashboardDataGridView.Columns.Count; k++)
                {

                    if (saleDashboardDataGridView[k, i].Value != null)
                    {

                        table.AddCell(new Phrase(saleDashboardDataGridView[k, i].Value.ToString()));
                    }

                }

            }

            doc.Add(table);
            //end querying from datagrid
            Paragraph p2 = new Paragraph("Total amount: " + this.cashSaleTotal.Text + "\n Paid: " + this.cashSaleAmount.Text + "\n Discount: " + this.cashSaleDiscount.Text + "\n Balance: " + this.cashSaleBalance.Text + "\n Produced by " + this.pfsession.Text + ", on " + time + "\n thank you and welcome again!");
            doc.Add(p2);

            doc.Close();//close document after writting in

            //MessageBox.Show("Sales completed");

            System.Diagnostics.Process.Start("C:\\PMS\\Reports\\receipt");

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

        private void CashierQuantitySaleWindow_Load(object sender, EventArgs e)
        {

        }

        private void cashSaleDrugSearch_TextChanged(object sender, EventArgs e)
        {
            drugForeignKey();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insertToCart();
            clearDrugSearch();
            cashSaleDrugSearch.Select();
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

        private void button2_Click(object sender, EventArgs e)
        {
            computeBalance();
            cashSaleDrugSearch.Select();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Int64 count = Convert.ToInt64(saleDashboardDataGridView.Rows.Count) - 1;

            if ((this.cashSaleTotal.Text != "") && (count > 0))
            {
                // Generate receipt serial number first.
                Random rd = new Random();
                int serial = rd.Next(1, 1000000000);
                setSerial.Text = serial.ToString();

                // Call the print method from printReceipt class to print the client receipt.
                // Print receipt before clearing the window.
               // print(sender, e); ##############uncomment this line to enable printing.
                // End printing the receipt.
                insertToSales();
                //salesReceipt();
                clearFields();
                cashSaleDelete();
                cashSaleDrugSearch.Select();
            }
            else
            {
                MessageBox.Show("The drug name you entered does not exist ", "NO SUCH DRUG", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cashSaleDrugSearch.Select();
            }
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logoutEvent();
            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
        }

        private void quantitySale_Click(object sender, EventArgs e)
        {

        }

        private void viewDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDrug v = new ViewDrug();
            v.ShowDialog();
        }

        private void viewNetStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewNetStock v = new ViewNetStock();
            v.Show();
        }

        private void addDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDebtor a = new AddDebtor(pfsession.Text);
            a.ShowDialog();
        }

        private void updateDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDebtor u = new UpdateDebtor(pfsession.Text);
            u.ShowDialog();
        }

        private void viewDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDebtor v = new ViewDebtor();
            v.ShowDialog();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculator c = new Calculator();
            c.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashierReports c = new CashierReports(pfsession.Text);
            c.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminHelpEvent();
            System.Diagnostics.Process.Start("C:\\PMS\\Support\\pharmacist manual.pdf");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(amountPaidTextBox.Text, "[^ 0-9]"))
            {
                amountPaidTextBox.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cashSaleDiscountTextBox.Text, "[^ 0-9]"))
            {
                cashSaleDiscountTextBox.Text = "";
            }
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
            string headerText = "SAMPLE PHARMACY\n".PadLeft(35) + " P.O BOX XXX\n".PadLeft(35) + " TOWN\n".PadLeft(35) + " PHONE +254 XXX XXX XXX".PadLeft(35);
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
                catch (InvalidCastException)
                {
                    MessageBox.Show("Something wrong has occured while generating a receipt. Please close the system and try again! ", "RECEIPT GENERATION ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
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
            graphic.DrawString("Amount received : ".PadLeft(5) + amountPaidTextBox.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Discount : ".PadLeft(5) + cashSaleDiscountTextBox.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Change : ".PadLeft(5) + cashSaleBalanceTextBox.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Served by : ".PadLeft(5) + firstNameTextBox.Text + "  " + lastNameTextBox.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Date of purchase : ".PadLeft(5) + timeOfSale, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Receipt serial no. : ".PadLeft(5) + setSerial.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("PRICES INCLUSSIVE OF VAT WHERE APPLICABLE ".PadLeft(5), font, new SolidBrush(Color.Black), startX, startY + offset);
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

              //  DialogResult result = printDialog.ShowDialog();

                // DialogResult result = printDialog.ShowDialog();

                //  result = MessageBox.Show("Do you want to print receipt ? ", "PRINT RECEIPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //  if (result == DialogResult.OK)
                // {
                printDocument.Print();

                // }

            }
            catch (Exception)
            {
                MessageBox.Show("Something wrong has occured while printing receipt. ","RECEIPT PRINTING ERROR",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            }
            finally
            { 
            
            }

        }

       // Calculator module starts here.

        private void button_click(object sender, EventArgs e)
        {
            try{

            if ((resultsTextBox.Text == "0") || (isOperationPerformed))
                resultsTextBox.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!(resultsTextBox.Text.Contains(".")))
                    resultsTextBox.Text = resultsTextBox.Text + button.Text;

            }
            else
            {

                resultsTextBox.Text = resultsTextBox.Text + button.Text;
            }

            }
            catch (Exception)
            {

            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
    try{
    if (results != 0)
            {
                equalsButton11.PerformClick();

                operation = button.Text;

                displayResults.Text = results + " " + operation;
                results = Double.Parse(resultsTextBox.Text);
                isOperationPerformed = true;
            }
            else
            {
                operation = button.Text;

                displayResults.Text = results + " " + operation;
                results = Double.Parse(resultsTextBox.Text);
                isOperationPerformed = true;
            }
              }
            catch (Exception) { 
            
            }

        }

        private void cancelEntryButton5_Click(object sender, EventArgs e)
        {
            resultsTextBox.Text = "0";
        }

        private void cancelButton6_Click(object sender, EventArgs e)
        {
            resultsTextBox.Text = "0";
            displayResults.Text = "0";
            results = 0;
        }

        private void equalsButton11_Click(object sender, EventArgs e)
        {
           try{
               switch (operation)
            {

                case "+":
                    resultsTextBox.Text = (results + Double.Parse(resultsTextBox.Text)).ToString();
                    break;
                case "-":
                    resultsTextBox.Text = (results - Double.Parse(resultsTextBox.Text)).ToString();
                    break;
                case "*":
                    resultsTextBox.Text = (results * Double.Parse(resultsTextBox.Text)).ToString();
                    break;
                case "/":
                    resultsTextBox.Text = (results / Double.Parse(resultsTextBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            results = Double.Parse(resultsTextBox.Text);
            displayResults.Text = "";
              }
            catch (Exception) { 
            
            }
        }
        
        // Ends here.

        private void CashierQuantitySaleWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {// Insert drug to cart.
             ////   insertToCart();
              //  clearDrugSearch();
              //  cashSaleDrugSearch.Select();

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

                    //DialogResult dialog;

                    //dialog = MessageBox.Show("Do you want to print a receipt","PRINT RECEIPT",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    //if(dialog==)

                    // Call the print method from printReceipt class to print the client receipt.
                    // Print receipr before clearing the window.
                     print(sender, e);
                    // End printing the receipt.

                    insertToSales();
                   // salesReceipt();
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
                cashSaleAmount.Select();
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {// Open A calculator.
                Calculator c = new Calculator();
                c.ShowDialog();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Calculator c = new Calculator();
            c.ShowDialog();
        }


        
    }
}
