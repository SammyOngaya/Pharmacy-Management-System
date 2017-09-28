using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace samapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            createDatabase();
            createTables();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //create database
        public void createDatabase()
        {
            try
            {

                String db = "datasource=localhost; port=3306; username=root; password=root;";
                MySqlConnection con = new MySqlConnection(db);

                con.Open();

                MySqlCommand mc1 = new MySqlCommand("CREATE DATABASE IF NOT EXISTS `pms`", con);

                mc1.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
        public void cretaeFirstUser() {
            try
            {

                String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand mc = new MySqlCommand("SELECT * FROM staff", con);

                MySqlDataReader mr = mc.ExecuteReader();

                int count = 0;

                while (mr.Read())
                {
                         count += 1;
                  }

                mr.Close();

                if (count < 1)
                {
                    MySqlCommand c = new MySqlCommand("INSERT INTO staff VALUES('3030','22','22','" + dateNow + "','22','22','22','22','22','22','" + dateNow + "','Manager','3030','22')", con);
                    c.ExecuteNonQuery();
                }
                else {
                    MessageBox.Show("User already exists");
                }

                con.Close();
            }
            catch (Exception) { 
            
            }
        
        }


        //create database
        public void createTables()
        {
            try
            {

                String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                con.Open();

                MySqlCommand mc1 = new MySqlCommand("CREATE TABLE IF NOT EXISTS `staff`(pfno varchar(30) NOT NULL PRIMARY KEY,firstname varchar(100) NOT NULL, lastname varchar(100) NOT NULL, dob DATETIME NOT NULL,gender varchar(10) NOT NULL,nationalid int(30) NOT NULL UNIQUE,phone varchar(30), email varchar(100),county varchar(100) NOT NULL, location varchar(150),doe DATETIME NOT NULL,category varchar(100) NOT NULL,password varchar(100) NOT NULL, photo BLOB )", con);
                MySqlCommand mcd = new MySqlCommand("CREATE TABLE IF NOT EXISTS  `supplier`(id int(30) NOT NULL PRIMARY KEY AUTO_INCREMENT,name varchar(200) NOT NULL,phone varchar(30) NOT NULL,address varchar(100), location varchar(200) NOT NULL,pfno varchar(30) NOT NULL, registered_date DATETIME NOT NULL, FOREIGN KEY(pfno) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE)", con);
                MySqlCommand mcd1 = new MySqlCommand("CREATE TABLE IF NOT EXISTS  `drug`(id int(30) NOT NULL PRIMARY KEY AUTO_INCREMENT,name varchar(200) NOT NULL,form varchar(100) NOT NULL,price varchar(30),pfno varchar(100) NOT NULL, registered_date DATETIME NOT NULL, FOREIGN KEY(pfno) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE)", con);
                MySqlCommand mcd2 = new MySqlCommand("CREATE TABLE IF NOT EXISTS  `stock`(id int(22) NOT NULL PRIMARY KEY AUTO_INCREMENT,supplier_id int(22) NOT NULL,quantity varchar(100) NOT NULL,buying_price varchar(30) NOT NULL,selling_price varchar(30) NOT NULL,drug_id int(11) NOT NULL,units varchar(100) NOT NULL,expiry_date DATETIME NOT NULL,batch_no varchar(100) UNIQUE,pfno varchar(100) NOT NULL, registered_date DATETIME NOT NULL, FOREIGN KEY(supplier_id) REFERENCES supplier(id) ON DELETE CASCADE ON UPDATE CASCADE, FOREIGN KEY(drug_id) REFERENCES drug(id) ON DELETE CASCADE ON UPDATE CASCADE, FOREIGN KEY(pfno) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE)", con);
                MySqlCommand mcd3 = new MySqlCommand("CREATE TABLE IF NOT EXISTS  `debtor`(id int(22) NOT NULL PRIMARY KEY AUTO_INCREMENT,name varchar(200) NOT NULL,drug_id int(100) NOT NULL,quantity varchar(20) NOT NULL,date_borrowed DATETIME NOT NULL,phone varchar(30) NOT NULL,deposit varchar(11) ,date_of_payment DATETIME ,pfno varchar(100) NOT NULL, registered_date DATETIME NOT NULL,  FOREIGN KEY(drug_id) REFERENCES drug(id) ON DELETE CASCADE ON UPDATE CASCADE, FOREIGN KEY(pfno) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE)", con);
                MySqlCommand mcd4 = new MySqlCommand("CREATE TABLE IF NOT EXISTS  `net_stock`(id int(22) NOT NULL PRIMARY KEY,drug_id int(100) NOT NULL,drug_name varchar(150) NOT NULL, quantity varchar(11) ,pfno varchar(100) NOT NULL,units varchar(20) NOT NULL,expiry_date DATETIME NOT NULL,  FOREIGN KEY(drug_id) REFERENCES drug(id) ON DELETE CASCADE ON UPDATE CASCADE, FOREIGN KEY(pfno) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE)", con);
                MySqlCommand mcd5 = new MySqlCommand("CREATE TABLE IF NOT EXISTS  `sales`(sales_id int(22) NOT NULL PRIMARY KEY AUTO_INCREMENT,cart_id int (33) NOT NULL,drug_name varchar(150) NOT NULL, quantity varchar(11) NOT NULL,price varchar(20) NOT NULL,pfno varchar(100) NOT NULL, sales_date DATETIME NOT NULL, unit varchar(20) NOT NULL, serial varchar(100) NOT NULL, FOREIGN KEY(pfno) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE)", con);
                MySqlCommand mcd6 = new MySqlCommand("CREATE TABLE IF NOT EXISTS  `cart`(cart_id int(22) NOT NULL PRIMARY KEY AUTO_INCREMENT,drug_name varchar(150) NOT NULL, quantity varchar(11) NOT NULL,price varchar(20) NOT NULL, unit varchar(20) NOT NULL)", con);
                MySqlCommand mcd7 = new MySqlCommand("CREATE TABLE IF NOT EXISTS `events`(event_id int(33) NOT NULL PRIMARY KEY AUTO_INCREMENT, pfno varchar(50) NOT NULL, event_time DATETIME NOT NULL, description varchar(200) NOT NULL, FOREIGN KEY(pfno) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE)", con);

                mc1.ExecuteNonQuery();
                mcd.ExecuteNonQuery();
                mcd1.ExecuteNonQuery();
                mcd2.ExecuteNonQuery();
                mcd3.ExecuteNonQuery();
                mcd4.ExecuteNonQuery();
                mcd5.ExecuteNonQuery();
                mcd6.ExecuteNonQuery();
                mcd7.ExecuteNonQuery();


                con.Close();

                MessageBox.Show("Database created successfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cretaeFirstUser();
        }
    }
}
