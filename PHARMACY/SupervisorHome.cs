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
    public partial class SupervisorHome : Form
    {
        MySqlConnection con = null;

        public SupervisorHome(string mess, string firstname, string lastname)
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            firstNameTextBox.Text = firstname;
            lastNameTextBox.Text = lastname;
            //Welcome user.
            welcomeLabel.Text = firstname;
            pfsession.Text = mess;
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashierReports c = new CashierReports(pfsession.Text);
            c.ShowDialog();
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

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logoutEvent();
            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            adminHelpEvent();
            System.Diagnostics.Process.Start("C:\\PMS\\Support\\pharmacist manual.pdf");
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

            }
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

            //ViewDebtor v = new ViewDebtor();
            //v.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CashierCashSaleWindow d = new CashierCashSaleWindow(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            d.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //CashierQuantitySaleWindow d = new CashierQuantitySaleWindow(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
           // d.ShowDialog();

            drugDetails cashSale = new drugDetails(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            cashSale.ShowDialog();
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
            //ViewDebtor v = new ViewDebtor();
            //v.ShowDialog();
        }

        private void netStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewNetStock v = new ViewNetStock();
            v.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            OrderList orderlist = new OrderList(pfsession.Text);
            orderlist.ShowDialog();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            UpdateOrderList update = new UpdateOrderList(pfsession.Text);
            update.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ViewOrderList view = new ViewOrderList();
            view.ShowDialog();
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

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vat vat = new Vat();
            vat.ShowDialog();
        }

        private void vATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vat vat = new Vat();
            vat.ShowDialog();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            inventory.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            inventory.ShowDialog();
        }

        private void SupervisorHome_Load(object sender, EventArgs e)
        {

        }

        private void mINIMUMSTOCKLEVELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinishedDrugStockLevel drugLevel = new FinishedDrugStockLevel();
            drugLevel.ShowDialog();
        }

        private void updateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Vat vat = new Vat();
            vat.ShowDialog();
        }
    }
}
