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

        }

        //DatabaseConnection dbcon = new DatabaseConnection();
        //progress bar method
        public void startTimer()
        {
            Application.Run(new Form1());
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
                MySqlCommand mc = new MySqlCommand("SELECT * FROM staff WHERE (pfno='" + this.loginusername.Text + "' AND password='" + this.loginpassword.Text + "' AND status='Active') ", con);

                MySqlDataReader mr = mc.ExecuteReader();

                int count = 0;

                while (mr.Read())
                {
                    string rn = mr.GetString("category");
                    string firstname = mr.GetString("firstname");
                    string lastname = mr.GetString("lastname");

                    firstNameTextBox.Text = firstname;
                    lastNameTextBox.Text = lastname;

                    userCategory.Text = rn;
                    
                    count += 1;

                }

                mr.Close();

                if ((count == 1) && (userCategory.Text=="Manager"))
                {
                    MessageBox.Show("You have logged in successfully", "Manager LOGGED IN SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                     ManagerHome d = new ManagerHome(loginusername.Text,firstNameTextBox.Text, lastNameTextBox.Text);
                   //Dashboard d = new Dashboard(loginusername.Text);
                    d.ShowDialog();

                    MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'"+ this.loginusername.Text +"','" + dateCurrent + "','manager login')", con);
                    me.ExecuteNonQuery();

                }
                else if ((count == 1) && (userCategory.Text == "Supervisor"))
                {

                    MessageBox.Show("You have logged in successfully", "SUPERVISOR LOGGED IN SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    SupervisorHome d = new SupervisorHome(loginusername.Text, firstNameTextBox.Text, lastNameTextBox.Text);
                    d.ShowDialog();
                    MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.loginusername.Text + "','" + dateCurrent + "','supervisor login')", con);
                    me.ExecuteNonQuery();

                }
                else if ((count == 1) && (userCategory.Text == "Pharmacist"))
                {

                    MessageBox.Show("You have logged in successfully", "PHARMACIST LOGGED IN SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    CashierHome d = new CashierHome(loginusername.Text, firstNameTextBox.Text, lastNameTextBox.Text);
                    d.ShowDialog();
                    MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.loginusername.Text + "','" + dateCurrent + "','pharmacist login')", con);
                    me.ExecuteNonQuery();//SupervisorHome

                }
                else if (count > 1) {

                    MessageBox.Show("More records found. Access denied...","ACCESS DENIED",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    loginusername.Select();
                }
                else
                {
                    MessageBox.Show("Wrong username / password combination. Access denied...", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.loginusername.Text + "','" + dateCurrent + "','failed login attempt')", con);
                    me.ExecuteNonQuery();

                    loginusername.Select();

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

        // Enter key event handler.
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                loginForm();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

       

}
}




