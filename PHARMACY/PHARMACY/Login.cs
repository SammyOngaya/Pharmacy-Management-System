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
using System.Net.NetworkInformation;
using System.Threading;


namespace PHARMACY
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           // Thread t = new Thread(startTimer);
           // t.Start();
           // Thread.Sleep(500);

            InitializeComponent();
            //t.Abort();
            
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;
        
        }

        //DatabaseConnection dbcon = new DatabaseConnection();
        //progress bar method
        public void startTimer()
        {
            Application.Run(new Form1());
        }

       
        //create database
        public void createDatabase() {
            try
            {

                String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                con.Open();
                
                MySqlCommand mc1 = new MySqlCommand("CREATE TABLE  `pms`.`staff`(pfno varchar(30) NOT NULL PRIMARY KEY,firstname varchar(100) NOT NULL, lastname varchar(100) NOT NULL, dob varchar(50) NOT NULL,gender varchar(10) NOT NULL,nationalid int(30) NOT NULL UNIQUE,phone varchar(30), email varchar(100),county varchar(100) NOT NULL, location varchar(150),doe varchar(50) NOT NULL,category varchar(100) NOT NULL,password varchar(100) NOT NULL, photo BLOB )", con);
                MySqlCommand mcd = new MySqlCommand("CREATE TABLE  `supplier`(id int(30) NOT NULL PRIMARY KEY AUTO_INCREMENT,name varchar(200) NOT NULL,phone varchar(30) NOT NULL,address varchar(100), location varchar(200) NOT NULL,pfno varchar(30) NOT NULL, registered_date varchar(100) NOT NULL, FOREIGN KEY(pfno) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE)", con);
                MySqlCommand mcd1 = new MySqlCommand("CREATE TABLE  `drug`(id int(30) NOT NULL PRIMARY KEY AUTO_INCREMENT,name varchar(200) NOT NULL,form varchar(100) NOT NULL,price varchar(30),pfno varchar(100) NOT NULL, registered_date varchar(100) NOT NULL, FOREIGN KEY(pfno) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE)", con);
                MySqlCommand mcd2 = new MySqlCommand("CREATE TABLE  `stock`(id int(22) NOT NULL PRIMARY KEY AUTO_INCREMENT,supplier_id int(22) NOT NULL,quantity varchar(100) NOT NULL,buying_price varchar(30) NOT NULL,selling_price varchar(30) NOT NULL,drug_id int(11) NOT NULL,units varchar(100) NOT NULL,expiry_date varchar(100) NOT NULL,batch_no varchar(100) UNIQUE,pfno varchar(100) NOT NULL, registered_date varchar(100) NOT NULL, FOREIGN KEY(supplier_id) REFERENCES supplier(id) ON DELETE CASCADE ON UPDATE CASCADE, FOREIGN KEY(drug_id) REFERENCES drug(id) ON DELETE CASCADE ON UPDATE CASCADE, FOREIGN KEY(pfno) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE)", con);
                MySqlCommand mcd3 = new MySqlCommand("CREATE TABLE  `debtor`(id int(22) NOT NULL PRIMARY KEY AUTO_INCREMENT,name varchar(200) NOT NULL,drug_id int(100) NOT NULL,quantity varchar(20) NOT NULL,date_borrowed varchar(50) NOT NULL,phone varchar(30) NOT NULL,deposit varchar(11) ,date_of_payment varchar(100) ,pfno varchar(100) NOT NULL, registered_date varchar(100) NOT NULL,  FOREIGN KEY(drug_id) REFERENCES drug(id) ON DELETE CASCADE ON UPDATE CASCADE, FOREIGN KEY(pfno) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE)", con);
                MySqlCommand mcd4 = new MySqlCommand("CREATE TABLE  `net_stock`(id int(22) NOT NULL PRIMARY KEY,drug_id int(100) NOT NULL,drug_name varchar(150) NOT NULL, quantity varchar(11) ,pfno varchar(100) NOT NULL,units varchar(20) NOT NULL,expiry_date varchar(20) NOT NULL,  FOREIGN KEY(drug_id) REFERENCES drug(id) ON DELETE CASCADE ON UPDATE CASCADE, FOREIGN KEY(pfno) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE)", con);
                MySqlCommand mcd5 = new MySqlCommand("CREATE TABLE  `sales`(sales_id int(22) NOT NULL PRIMARY KEY AUTO_INCREMENT,cart_id int (33) NOT NULL,drug_name varchar(150) NOT NULL, quantity varchar(11) NOT NULL,price varchar(20) NOT NULL,pfno varchar(100) NOT NULL, sales_date varchar(100) NOT NULL, unit varchar(20) NOT NULL, serial varchar(100) NOT NULL, FOREIGN KEY(pfno) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE)", con);
                MySqlCommand mcd6 = new MySqlCommand("CREATE TABLE `cart`(cart_id int(22) NOT NULL PRIMARY KEY AUTO_INCREMENT,drug_name varchar(150) NOT NULL, quantity varchar(11) NOT NULL,price varchar(20) NOT NULL, unit varchar(20) NOT NULL)", con);
               
               

                mc1.ExecuteNonQuery();
                mcd.ExecuteNonQuery();
                mcd1.ExecuteNonQuery();
                mcd2.ExecuteNonQuery();
                mcd3.ExecuteNonQuery();
                mcd4.ExecuteNonQuery();
                mcd5.ExecuteNonQuery();
                mcd6.ExecuteNonQuery();
             
               
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        //login method
        public void loginForm() {

            //current date
            DateTime curdate = DateTime.Now;
            String dateCurrent = curdate.ToString("yyyy-MM-dd");

            //convert loginusername to integer
            //int pf = Convert.ToInt32(loginusername.Text);

           String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
           MySqlConnection con = new MySqlConnection(db);

           // DatabaseConnection con = new DatabaseConnection();

          
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM staff WHERE pfno='" + this.loginusername.Text + "' AND password='" + this.loginpassword.Text + "'", con);

                MySqlDataReader mr = mc.ExecuteReader();

                int count = 0;

                while (mr.Read())
                {
                    String rn = mr.GetString("category");
                    String firstname = mr.GetString("firstname");
                    String lastname = mr.GetString("lastname");

                    firstNameTextBox.Text = firstname;
                    lastNameTextBox.Text = lastname;

                    userCategory.Text = rn;
                    
                    count += 1;

                }

                mr.Close();

                if ((count == 1) && (userCategory.Text=="Manager"))
                {
                    MessageBox.Show("logged in successfully");
                    this.Hide();
                     ManagerHome d = new ManagerHome(loginusername.Text,firstNameTextBox.Text, lastNameTextBox.Text);
                   //Dashboard d = new Dashboard(loginusername.Text);
                    d.ShowDialog();

                    MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'"+ this.loginusername.Text +"','" + dateCurrent + "','manager login')", con);
                    me.ExecuteNonQuery();

                }
                else if ((count == 1) && (userCategory.Text == "Pharmacist"))
                {
                    MessageBox.Show("logged in successfully");
                    this.Hide();
                    CashierHome d = new CashierHome(loginusername.Text, firstNameTextBox.Text, lastNameTextBox.Text);
                    d.ShowDialog();
                    MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.loginusername.Text + "','" + dateCurrent + "','pharmacist login')", con);
                    me.ExecuteNonQuery();

                }
                else if (count > 1) {
                    MessageBox.Show("More record found. Access denied...");
                }
                else
                {
                    MessageBox.Show("Access denied!....");
                    MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.loginusername.Text + "','" + dateCurrent + "','failed login attempt')", con);
                    me.ExecuteNonQuery();

                }

                    con.Close();

            }
            catch (Exception )
            {
               // MessageBox.Show("Error has occured. Please try again with different data"+ex.Message);
            }
        }

      
        /*
        public void exitApplication() {
        
             //current date
            DateTime curdate = DateTime.Now;
            String dateCurrent = curdate.ToString();

              int pf = Convert.ToInt32(loginusername.Text);

            String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
        
            try{
                con.Open();
            
                 MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + pf + "','" + dateCurrent + "','exit application')", con);
            me.ExecuteNonQuery();

            con.Close();

            }catch(Exception ex){
            
                MessageBox.Show("Error has occured while exiting the system"+ex.Message);
            }
        
        }


        */
 
        

        private void login_Click_1(object sender, EventArgs e)
        {
            loginForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

}
}




