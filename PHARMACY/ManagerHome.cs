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
    public partial class ManagerHome : Form
    {
        MySqlConnection con = null;
        public ManagerHome(string mess, string firstname,string lastname)
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            firstNameTextBox.Text = firstname;
           lastNameTextBox.Text = lastname;
             //Welcome user.
            welcomeLabel.Text = firstname;
            pfsession.Text = mess;
            getImage();
            setTime();
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
            catch (Exception)
            {
               // MessageBox.Show("There is no image!", "EMPTY IMAGE", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }


        //set time
        public void setTime()
        {
            DateTime salestime = DateTime.Now;
            this.time.Text = salestime.ToString("yyyy-MM-dd");
        }

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
               // MessageBox.Show("THERE IS NO HELP!", "HELP ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
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


        private void cashSale_Click(object sender, EventArgs e)
        {
            //this.Hide();
            drugDetails qs = new drugDetails(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            // Dashboard qs = new Dashboard(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            qs.ShowDialog();
            // this.Close();
        }

       
        private void quantitySale_Click(object sender, EventArgs e)
        {
            //  this.Hide();
            QuantitySale qs = new QuantitySale(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            //QuantitySale qs = new QuantitySale(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            qs.ShowDialog();
            // this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reports r = new Reports(pfsession.Text);
            r.ShowDialog();

        }

        private void ManagerHome_Load(object sender, EventArgs e)
        {
            
        }

     
     
    
        private void quantitySale_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            drugDetails qs = new drugDetails(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            // Dashboard qs = new Dashboard(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            qs.ShowDialog();
            // this.Close();
        }

        private void cashSale_Click_1(object sender, EventArgs e)
        {
            //  this.Hide();
            QuantitySale qs = new QuantitySale(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            //QuantitySale qs = new QuantitySale(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            qs.ShowDialog();
            // this.Close();
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

        private void backupToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ExportDatabase export = new ExportDatabase();
            export.ShowDialog();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportDatabase import = new ImportDatabase();
            import.ShowDialog();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculator c = new Calculator();
            c.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports r = new Reports(pfsession.Text);
            r.ShowDialog();
        }

        private void viewDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DebtorPayDebt v = new DebtorPayDebt(pfsession.Text);
            v.ShowDialog();
            //ViewDebtor v = new ViewDebtor();
            //v.ShowDialog();
        }

        private void updateDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDebtor u = new UpdateDebtor(pfsession.Text);
            u.ShowDialog();
        }

        private void viewSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSales salesReport = new ReportSales();
            salesReport.ShowDialog();
        }

        private void viewNetStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewNetStock v = new ViewNetStock();
            v.Show();
        }

        private void viewStockToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewStock v = new ViewStock();
            v.ShowDialog();
        }

        private void updateStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStock u = new UpdateStock(pfsession.Text);
            u.ShowDialog();
        }

        private void addStockToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddStock a = new AddStock(pfsession.Text);
            a.ShowDialog();
        }

        private void viewDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDrug v = new ViewDrug();
            v.ShowDialog();
        }

        private void updateDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDrug u = new UpdateDrug(pfsession.Text);
            u.ShowDialog();
        }

        private void addDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDrug a = new AddDrug(pfsession.Text);
            a.ShowDialog();
        }

        private void viewSupplierToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewSupplier v = new ViewSupplier();
            v.ShowDialog();
        }

        private void updateSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSupplier u = new UpdateSupplier(pfsession.Text);
            u.ShowDialog();
        }

        private void addSupplierToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddSupplier ad = new AddSupplier(pfsession.Text);
            ad.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddSupplier ad = new AddSupplier(pfsession.Text);
            ad.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            UpdateSupplier u = new UpdateSupplier(pfsession.Text);
            u.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewSupplier v = new ViewSupplier();
            v.ShowDialog();
        }

        private void addStaffToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddStaff a = new AddStaff();
            a.ShowDialog();
        }

        private void viewStaffToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewStaff v = new ViewStaff();
            v.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ViewStaff v = new ViewStaff();
            v.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UpdateStaff u = new UpdateStaff();
            u.Show();
        }

        private void updateStaffToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateStaff u = new UpdateStaff();
            u.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            AddStaff a = new AddStaff();
            a.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            AddDebtor a = new AddDebtor(pfsession.Text);
            a.ShowDialog();
        }

        private void addDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDebtor a = new AddDebtor(pfsession.Text);
            a.ShowDialog();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            UpdateDebtor u = new UpdateDebtor(pfsession.Text);
            u.ShowDialog();
        
        }

        private void label13_Click(object sender, EventArgs e)
        {
            //ViewDebtor v = new ViewDebtor();
            //v.ShowDialog();

            DebtorPayDebt v = new DebtorPayDebt(pfsession.Text);
            v.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            AddStock a = new AddStock(pfsession.Text);
            a.ShowDialog();
        
        }

        private void label7_Click(object sender, EventArgs e)
        {
            UpdateStock u = new UpdateStock(pfsession.Text);
            u.ShowDialog();
        
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ViewStock v = new ViewStock();
            v.ShowDialog();
        
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Reports r = new Reports(pfsession.Text);
            r.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vat vat = new Vat();
            vat.ShowDialog();
        }

        private void addSupplierPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSupplierPriceList supplier = new AddSupplierPriceList(pfsession.Text);
            supplier.ShowDialog();
        }

        private void updateSupplierPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSupplierPriceList supplier = new UpdateSupplierPriceList(pfsession.Text);
            supplier.ShowDialog();
        }

        private void viewSupplierPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSupplierPriceList supplier = new ViewSupplierPriceList();
            supplier.ShowDialog();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderList orderlist = new OrderList(pfsession.Text);
            orderlist.ShowDialog();
        }

        private void updateOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateOrderList update = new UpdateOrderList(pfsession.Text);
            update.ShowDialog();
        }

        private void viewOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewOrderList view = new ViewOrderList();
            view.ShowDialog();
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log log = new Log();
            log.ShowDialog();
        }

        private void drugFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrugForm form = new DrugForm();
            form.ShowDialog();
        }

        private void addDebtorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddDebtor debtor = new AddDebtor(pfsession.Text);
            debtor.ShowDialog();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            adminHelpEvent();
            System.Diagnostics.Process.Start("C:\\PMS\\Support\\admin manual.pdf");
        }

        private void label18_Click(object sender, EventArgs e)
        {
            logoutEvent();
            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            ExportDatabase export = new ExportDatabase();
            export.ShowDialog();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            ImportDatabase import = new ImportDatabase();
            import.ShowDialog();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Log log = new Log();
            log.ShowDialog();
        }

        private void vATToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            inventory.ShowDialog();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            inventory.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //  this.Hide();
            QuantitySale qs = new QuantitySale(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            //QuantitySale qs = new QuantitySale(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            qs.ShowDialog();
            // this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //  this.Hide();
            drugDetails cashSale = new drugDetails(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            cashSale.ShowDialog();
            // this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Reports r = new Reports(pfsession.Text);
            r.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void pfsession_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ExportDatabase export = new ExportDatabase();
            export.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ImportDatabase import = new ImportDatabase();
            import.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Log log = new Log();
            log.ShowDialog();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            adminHelpEvent();
            System.Diagnostics.Process.Start("C:\\PMS\\Support\\admin manual.pdf");
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            logoutEvent();
            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            ReportSales salesReport = new ReportSales();
            salesReport.ShowDialog();
        }

        private void mINIMUMSTOCKLEVELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinishedDrugStockLevel drugLevel = new FinishedDrugStockLevel();
            drugLevel.ShowDialog();
        }
    }
}
