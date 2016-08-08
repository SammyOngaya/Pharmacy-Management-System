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
    public partial class CashierHome : Form
    {
        MySqlConnection con = null;

        public CashierHome(string mess, string firstname, string lastname)
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            firstNameTextBox.Text = firstname;
            lastNameTextBox.Text = lastname;
            //Welcome user.
            welcomeLabel.Text = firstname;
            pfsession.Text = mess;
            getImage();
        }
        //fetch image from database
        public void getImage()
        {
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
            catch (Exception )
            {
                //MessageBox.Show("Error caught" + ex.Message);
            }
        }
        private void quantitySale_Click(object sender, EventArgs e)
        {
            CashierCashSaleWindow d = new CashierCashSaleWindow(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            d.ShowDialog();
        }

        private void cashSale_Click(object sender, EventArgs e)
        {
            CashierQuantitySaleWindow d = new CashierQuantitySaleWindow(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            d.ShowDialog();
        }

        private void viewDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDrug v = new ViewDrug();
            v.ShowDialog();
        }

        private void viewNetStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashierViewNetStock net = new CashierViewNetStock();
            net.ShowDialog();
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

            DebtorPayDebt v = new DebtorPayDebt(pfsession.Text);
            v.ShowDialog();

           // ViewDebtor v = new ViewDebtor();
          //  v.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashierReports c = new CashierReports(pfsession.Text);
            c.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CashierReports c = new CashierReports(pfsession.Text);
            c.ShowDialog();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Calculator c = new Calculator();
            c.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
             adminHelpEvent();
            System.Diagnostics.Process.Start("C:\\PMS\\Support\\pharmacist manual.pdf");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
             logoutEvent();
            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
        }

         //events methods

        //viewed admin help method
        public void adminHelpEvent()
        {
            //current date
            DateTime curdate = DateTime.Now;
            String dateCurrent = curdate.ToString("yyyy-MM-dd");

            //convert loginusername to integer
            int pf = Convert.ToInt32(pfsession.Text);
 
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

        private void CashierHome_Load(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {
          
        }

        private void label18_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddDebtor a = new AddDebtor(pfsession.Text);
            a.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

            UpdateDebtor u = new UpdateDebtor(pfsession.Text);
            u.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DebtorPayDebt v = new DebtorPayDebt(pfsession.Text);
            v.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //CashierQuantitySaleWindow d = new CashierQuantitySaleWindow(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
           // d.ShowDialog();
            drugDetails cashSale = new drugDetails(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            cashSale.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CashierCashSaleWindow d = new CashierCashSaleWindow(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            d.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            CashierReports c = new CashierReports(pfsession.Text);
            c.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            logoutEvent();
            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            adminHelpEvent();
            System.Diagnostics.Process.Start("C:\\PMS\\Support\\pharmacist manual.pdf");
        }

        private void netStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashierViewNetStock net = new CashierViewNetStock();
            net.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            CashierViewNetStock net = new CashierViewNetStock();
            net.ShowDialog();
        }
    }
}
