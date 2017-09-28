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

namespace PHARMACY
{
    public partial class QuantitySale : Form
    {
        DataTable dt;

        public QuantitySale(String mess, string firstname, string lastname)
        {
            InitializeComponent();
            firstNameTextBox.Text = firstname;
            lastNameTextBox.Text = lastname;
            //Welcome user.
            welcomeLabel.Text = firstname;
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            setTime();

            searchDrug();
            cartView();
           // totalAmount();
            pfsession.Text = mess;
            timer1.Start();
            getImage();
            checkCart();
           
        }
        DataTable ddt = new DataTable();


        //set time
        public void setTime()
        {
            DateTime salestime = DateTime.Now;
            string time = salestime.ToString();
        }


        private void QuantitySale_Load(object sender, EventArgs e)
        {
            ddt.Columns.Add("Item Id",typeof(int));
            ddt.Columns.Add("Drug Name", typeof(string));
            ddt.Columns.Add("Quantity", typeof(string));
            ddt.Columns.Add("Price", typeof(string));
            }


        //clear fields
        public void clearFields()
        {
            this.cashSaleTotal.Text = "";
            this.cashSaleAmount.Text = "";
            this.cashSaleDiscount.Text = "";
            this.cashSaleBalance.Text = "";
            this.quantityOfDrugs.Text = "";
            this.cashSaleDrugSearch.Text = "";
            this.quantitysaleAmount.Text = "";
            this.pricePerUnit.Text = "";
        }

        //clear drug search field
        public void clearDrugSearch()
        {
           
            this.cashSaleDrugSearch.Text = "";
            this.quantitysaleAmount.Text = "";
            this.pricePerUnit.Text = "";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        QuantitySalePictureBox.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(imgg);
                        QuantitySalePictureBox.Image = System.Drawing.Image.FromStream(ms);
                    }
                    //end fetching image
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error caught"+ex.Message);
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

            con.Open();

            DateTime dtt = DateTime.Now;
            String dateNow = dtt.ToString("yyyy-MM-dd");

            //select `drug`.`id`,`drug`.`name`,`drug`.`price`,`stock`.`id`,`stock`.`drug_id`,`stock`.`units` FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` WHERE `drug`.`name`='" + this.cashSaleDrugSearch.Text + "' GROUP BY `drug`.`id`
            MySqlCommand c = new MySqlCommand("select `drug`.`id`,`drug`.`name` FROM `drug` JOIN `net_stock` ON `drug`.`id`=`net_stock`.`drug_id` WHERE `net_stock`.`quantity`>0 AND DATEDIFF(`net_stock`.`expiry_date`,'" + dateNow + "')>0 GROUP BY `net_stock`.`drug_id` ORDER BY `drug`.`name` ASC", con);

            MySqlDataReader r = c.ExecuteReader();

            while (r.Read())
            {
                String l = r.GetString("name");
                collection.Add(l);


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

                MySqlCommand com = new MySqlCommand("SELECT `cart`.`cart_id` AS 'Item Id', `cart`.`drug_name` AS'Drug Name',`cart`.`quantity` AS 'Quantity',`cart`.`price` AS 'Price', ROUND((`cart`.`quantity`*`cart`.`price`),2) AS 'Total Amount',`cart`.`unit` AS 'Units' FROM `cart` ORDER BY `cart`.`cart_id` DESC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dt = new DataTable();
                a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                saleDashboardDataGridView.DataSource = bs;

                a.Update(dt);
              }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                 MySqlCommand mc = new MySqlCommand("SELECT `drug`.`id` AS id,`drug`.`name` AS 'drname',`drug`.`price` AS price,`net_stock`.`id` AS net_id,`net_stock`.`drug_id`,`net_stock`.`units` AS units, `net_stock`.`quantity` AS net_Quantity FROM `drug` JOIN `net_stock` ON `drug`.`id`=`net_stock`.`drug_id` WHERE `drug`.`name`='" + this.cashSaleDrugSearch.Text + "' GROUP BY `drug`.`id`", con);
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {
                   
                    String did = nn.GetInt32("id").ToString();
                    String un = nn.GetString("units");
                   // String pr = nn.GetInt32("price").ToString();
                    //String qty = nn.GetString("net_Quantity");
                    String pr = nn.GetDouble("price").ToString();
                    String qty = nn.GetDouble("net_Quantity").ToString();
                    String drn = nn.GetString("drname");

                    drugidforeignkey.Text = did;
                    priceforeignkey.Text = pr;
                    unitforeignkey.Text = un;
                    pricePerUnit.Text = pr;
                    netStockDrugQuantityTextbox.Text = qty;
                    drugnameforeignkey.Text = drn;

                }

                nn.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    String am = nn.GetDouble("amount").ToString();
                    cashSaleTotal.Text = am;

                }

                nn.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Compute Balance
        public void computeBalance()
        {

            try
            {

                if ((this.cashSaleTotal.Text != ""))
                {

                    Double amt = Convert.ToDouble(cashSaleAmount.Text);
                    Double total = Convert.ToDouble(cashSaleTotal.Text);

                    if (String.IsNullOrEmpty(this.cashSaleDiscount.Text))
                    {

                        Double ans = (total - amt);
                        cashSaleBalance.Text = Convert.ToString(ans);

                    }
                    else
                    {
                        Double disc = Convert.ToDouble(cashSaleDiscount.Text);

                        Double ans = (total - (amt + disc));
                        cashSaleBalance.Text = Convert.ToString(ans);

                    }
                }
                else
                {
                    MessageBox.Show("No Product!");
                }

            }
            catch (Exception) {
                MessageBox.Show("No amount");
            }

        }
        
       
        //fetch unit from the stock
      
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
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {
                  

                }
               // MessageBox.Show("All Data Deleted Successfull");
                nn.Close();
                //insert to events
                MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + pf + "','" + dateCurrent + "','Canceled drugs worth Kshs. ''"+this.cashSaleTotal.Text+"')", con);
                me.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cartView();

        }
       

        //insert into cart
        public void insertToCart() {

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            if ((this.cashSaleDrugSearch.Text != "") && (this.quantitysaleAmount.Text != "") && (this.pricePerUnit.Text != ""))
                {

            try
            {
                
                con.Open();

               Double qty = Convert.ToDouble(quantityOfDrugs.Text);
               Double netQty = Convert.ToDouble(netStockDrugQuantityTextbox.Text);


                if (netQty >= qty)
                {
                DateTime dt = DateTime.Now;
                String dateNow = dt.ToString();
                //int drid = Convert.ToInt32(drugidforeignkey.Text);
               // int pfs = Convert.ToInt32(pfsession.Text);
                //int pr = Convert.ToInt32(priceforeignkey.Text);

                MySqlCommand c = new MySqlCommand("INSERT INTO cart VALUES(NULL,'" + this.drugnameforeignkey.Text + "','" + this.quantityOfDrugs.Text + "','" + this.pricePerUnit.Text + "','" + this.unitforeignkey.Text + "')", con);

                MySqlDataReader r = c.ExecuteReader();

                MessageBox.Show("Drug added to cart successfully");

                while (r.Read())
                {

                }

                }
                else
                {

                    MessageBox.Show("The quantity you entered is more than what is in the stock.: " + netQty);
                }

                con.Close();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cartView();//display in grid
            totalAmount();//display in total

                }
             else
             {
                 MessageBox.Show("Wrong Operation!");
             }
        }



        public void computeQuantity()
        {

            if ((this.quantitysaleAmount.Text != ""))
            {

                Double amt = Convert.ToDouble(quantitysaleAmount.Text);
                Double pr = Convert.ToDouble(pricePerUnit.Text);

                Double rs = Math.Round((amt / pr), 2);

                quantityOfDrugs.Text = Convert.ToString(rs);

            }
        }

        
        

        public void removeFromCart() {

            try
            {

                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                if (saleDashboardDataGridView.SelectedRows.Count > 0)
                {

                    int selectedIndex = saleDashboardDataGridView.SelectedRows[0].Index;
                    int RowID = int.Parse(saleDashboardDataGridView[0, selectedIndex].Value.ToString());

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM cart WHERE cart_id = " + RowID + "", con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                }
                else
                {
                    MessageBox.Show("No data selected");
                }

            }
            catch (Exception) {
                MessageBox.Show("Error has occured!");
            }
            cartView();
        }

        //update net stock
        public void updateNetStock()
        {

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

          try{
                con.Open();
                MySqlCommand mc = new MySqlCommand("UPDATE net_stock set quantity=(quantity-@quantity) WHERE drug_name=@drug_name",con);

                foreach (DataRow row in dt.Rows)
                {
                    mc.Parameters.Clear();
                    mc.Parameters.AddWithValue("@drug_name", row["Drug Name"]);
                    mc.Parameters.AddWithValue("@quantity", row["quantity"]);
                     mc.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Problem has occured while updating net stock"+ex.Message);
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

           

                try
                {

                    Random rd = new Random();
                    int serial = rd.Next(1, 1000000000);

                    setSerial.Text = serial.ToString();

                    con.Open();
                    MySqlCommand c = new MySqlCommand("INSERT INTO sales VALUES(NULL,@cart_id,@drug_name,@quantity,@price,'" + this.pfsession.Text + "','" +dateCurrent+ "',@unit,'" + serial + "')", con);

                    foreach (DataRow row in dt.Rows)
                    {

                        //  Random rn = new Random();
                        // int serial=rn.Next(10,20);

                        c.Parameters.Clear();
                        //c.Parameters.AddWithValue("@sales_id",NULL);
                        c.Parameters.AddWithValue("@cart_id", row["Item Id"]);
                        c.Parameters.AddWithValue("@drug_name", row["Drug Name"]);
                        c.Parameters.AddWithValue("@quantity", row["Quantity"]);
                        c.Parameters.AddWithValue("@price", row["Price"]);
                        c.Parameters.AddWithValue("@unit", row["Units"]);
                        // c.Parameters.AddWithValue("@pfno",row["pfno"]);
                        //c.Parameters.AddWithValue('"+this.timeToolStripMenuItem.Text');
                        // c.Parameters.AddWithValue("@serial_no", serial);

                        c.ExecuteNonQuery();

                    }
                    updateNetStock();
                    //cashSaleDelete();
                    MessageBox.Show("SUCCESS");

                     MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + pf + "','" + dateCurrent + "','Sold drugs worth Kshs. ''"+this.cashSaleTotal.Text+"')", con);
                     me.ExecuteNonQuery();

                    cartView();

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
            drugForeignKey();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insertToCart();
        }

        private void drugidforeignkey_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cashSaleDelete();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertToSales();
            computeBalance();
        }

        private void cashSalePay_Click(object sender, EventArgs e)
        {
            computeBalance();
        }

        private void viewSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewSales s = new viewSales();
            s.ShowDialog();
        }

        private void viewNetStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewNetStock v= new ViewNetStock();
            v.Show();
        }

        private void cashSaleRemove_Click(object sender, EventArgs e)
        {
            removeFromCart();
        }

        private void quantitySale_Click(object sender, EventArgs e)
        {
            QuantitySale qs = new QuantitySale(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            qs.ShowDialog();
        }

        private void drugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      

        /// <summary>
        /// ////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        ////////////////



        /// <summary>
        /// /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addStaffToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddStaff a = new AddStaff();
            a.ShowDialog();
        }

        private void updateStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStock u = new UpdateStock(pfsession.Text);
            u.ShowDialog();
        }

        private void updateStaffToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateStaff u = new UpdateStaff();
            u.Show();
        }

        private void viewStaffToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewStaff v = new ViewStaff();
            v.ShowDialog();
        }

        private void addSupplierToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddSupplier ad = new AddSupplier(pfsession.Text);
            ad.ShowDialog();
        }

        private void updateSupplierToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateSupplier u = new UpdateSupplier(pfsession.Text);
            u.ShowDialog();
        }

        private void viewSupplierToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewSupplier v = new ViewSupplier();
            v.ShowDialog();
        }

        private void addDrugToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddDrug a = new AddDrug(pfsession.Text);
            a.ShowDialog();
        }

        private void updateDrugToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateDrug u = new UpdateDrug(pfsession.Text);
            u.ShowDialog();
        }

        private void viewDrugToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewDrug v = new ViewDrug();
            v.ShowDialog();
        }

        private void addStockToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddStock a = new AddStock(pfsession.Text);
            a.ShowDialog();
        }

        private void viewStockToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewStock v = new ViewStock();
            v.ShowDialog();
        }

        private void viewNetStockToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewNetStock v = new ViewNetStock();
            v.Show();
        }

        private void viewSalesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            viewSales s = new viewSales();
            s.ShowDialog();
        }

        private void addDebtorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddDebtor a = new AddDebtor(pfsession.Text);
            a.ShowDialog();
        }

        private void updateDebtorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateDebtor u = new UpdateDebtor(pfsession.Text);
            u.ShowDialog();
        }

        private void viewDebtorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewDebtor v = new ViewDebtor();
            v.ShowDialog();
        }

        private void cashSalePay_Click_1(object sender, EventArgs e)
        {
            computeBalance();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if ((this.cashSaleTotal.Text != ""))
            {

                insertToSales();
                salesReceipt();
                cashSaleDelete();
                clearFields();
            }
            else
            {
                MessageBox.Show("No Drug");
            }
        }

        private void cashSaleCancel_Click(object sender, EventArgs e)
        {
            cashSaleDelete();
            clearFields();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            computeQuantity();
            insertToCart();
            clearDrugSearch();
        }

        private void cashSaleRemove_Click_1(object sender, EventArgs e)
        {
            removeFromCart();
            totalAmount();
        }

        private void cashSale_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard qs = new Dashboard(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            qs.ShowDialog();
            this.Close();
        }

        private void cashSaleDrugSearch_TextChanged_1(object sender, EventArgs e)
        {
            drugForeignKey();
        }

        private void cashSaleQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void drugidforeignkey_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void quantitysaleAmount_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(quantitysaleAmount.Text, "[^ 0-9]"))
            {
                quantitysaleAmount.Text = "";
            }
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports r = new Reports(pfsession.Text);
            r.ShowDialog();

            this.Close();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculator c = new Calculator();
            c.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logoutEvent();
            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminHelpEvent();
            System.Diagnostics.Process.Start("C:\\PMS\\Support\\admin manual.pdf");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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

        private void cashSaleAmount_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cashSaleAmount.Text, "[^ 0-9]"))
            {
                cashSaleAmount.Text = "";
            }
        }

        private void cashSaleDiscount_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cashSaleDiscount.Text, "[^ 0-9]"))
            {
                cashSaleDiscount.Text = "";
            }
        }


    }
}
