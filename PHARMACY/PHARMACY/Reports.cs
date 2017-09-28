using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
//using MySql.Data.MySqlBackup;


using System.Threading;
using System.IO;

namespace PHARMACY
{
    public partial class Reports : Form
    {
        public Reports(String ms)
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            setTime();

            pfsession.Text = ms;

           
            //staff reports
            totalStaffReports();
            totalMaleStaffReports();
            totalFemaleStaffReports();
            totalMangerStaffReports();
            totalPharmacistStaffReports();

            //DRUGS REPORTS
            totalDrugsReports();

            //SUPPLIER REPORTS
            totalSupplierReports();

            //DEBTOR REPORTS
            totalDebtorReports();
            totalPaidDebtorReports();
            totalUnPaidDebtorReports();

            //SALES REPORTS
            totalSalesReports();
            amountSoldReport();

            //expired drugs
            expiredDrugs();

            //FINISHED DRUGS
            finisheddDrugs();

            //low drug quantity beep
            lowDrugQuantityBeeps();
             expiredDrugsBeeps();

            
        }


        //set time
        public void setTime()
        {
            DateTime salestime = DateTime.Now;
            this.time.Text = salestime.ToString();
        }

        //low quantity drugs
        public void lowDrugQuantityBeeps() {

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*), id AS 'ID', drug_name AS 'DRUG NAME' FROM net_stock WHERE quantity<=0 ", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                if (count >= 1) {
                    for (int i = 0; i < count; i++)
                    {
                        Console.Beep();
                        Thread.Sleep(1000);
                    }

                    MessageBox.Show(count+"drugs are out of stock");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //expires drugs notification
        public void expiredDrugsBeeps()
        {

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*),drug_name AS 'DRUG NAME', expiry_date AS 'EXPIRY DATE', DATEDIFF(expiry_date,'" + dateNow + "') AS 'DAYS PASSED' FROM net_stock WHERE DATEDIFF(expiry_date,'" + dateNow + "')<=0 AND quantity>0 ", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                if (count >= 1)
                {
                    for (int i = 0; i < count; i++)
                    {
                        Console.Beep();
                        Thread.Sleep(1000);
                    }

                    MessageBox.Show(count + "drugs have expired");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


       // total staff reports
        public void totalStaffReports() {
          string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
              try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM staff",con);
             //  MySqlDataReader mr = mc.ExecuteReader();

                   Int64 count = (Int64)mc.ExecuteScalar();

                   reportsTotalStaffs.Text = count.ToString();
             
                con.Close();
              
            }
            catch (Exception ex) {
                  MessageBox.Show(ex.Message);
            }
        }

        // total male staff reports
        public void totalMaleStaffReports()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM staff WHERE gender='Male'", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                reportsMaleStaffs.Text = count.ToString();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // total female staff reports
        public void totalFemaleStaffReports()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM staff WHERE gender='Female'", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                reportsFemaleStaffs.Text = count.ToString();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // total Managers staff reports
        public void totalMangerStaffReports()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM staff WHERE category='Manager'", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                reportsManagers.Text = count.ToString();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // total Pharmacist staff reports
        public void totalPharmacistStaffReports()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM staff WHERE category='Pharmacist'", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                reportsPharmacists.Text = count.ToString();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

            ///////===========DRUG==========

             // total drugs reports
        public void totalDrugsReports()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM drug", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                totalDrugs.Text = count.ToString();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

           ///////===========SUPPLIER==========

             // total supplier reports
        public void totalSupplierReports()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM supplier", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                totalSupplier.Text = count.ToString();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
            
           ///////===========Debtor==========

             // total Debtor reports
        public void totalDebtorReports()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM debtor", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                totalDebtorReport.Text = count.ToString();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        // total PAID Debtor reports
        public void totalPaidDebtorReports()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(`debtor`.`id`) FROM `drug` JOIN `debtor` ON `drug`.`id`=`debtor`.`drug_id` WHERE (`drug`.`price`*`debtor`.`quantity`)<=`debtor`.`deposit`", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                paidDebtors.Text = count.ToString();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //unpaidDebtor
        // total UNPAID Debtor reports
        public void totalUnPaidDebtorReports()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(`debtor`.`id`) FROM `drug` JOIN `debtor` ON `drug`.`id`=`debtor`.`drug_id` WHERE (`drug`.`price`*`debtor`.`quantity`)>`debtor`.`deposit`", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                unpaidDebtor.Text = count.ToString();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //////////////////////sales////////////

        //totalSalesReport

        public void totalSalesReports()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM sales", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                totalSalesReport.Text = count.ToString();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //amountSold

        public void amountSoldReport()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT ROUND(SUM(quantity*price),2) AS sum FROM sales", con);
                  MySqlDataReader mr = mc.ExecuteReader();

                  while (mr.Read()) {

                      String sm = mr.GetDouble("sum").ToString();
                      amountSold.Text = sm;
                   }

              

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //EXPIRED DRUGS
        public void expiredDrugs()
        {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand com = new MySqlCommand("SELECT drug_name AS 'DRUG NAME', expiry_date AS 'EXPIRY DATE', DATEDIFF(expiry_date,'" + dateNow + "') AS 'DAYS PASSED' FROM net_stock WHERE DATEDIFF(expiry_date,'" + dateNow + "')<=0 AND quantity>0 ", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dt = new DataTable();
                // Add autoincrement column.
                dt.Columns.Add("#", typeof(int));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["#"] };
                dt.Columns["#"].AutoIncrement = true;
                dt.Columns["#"].AutoIncrementSeed = 1;
                dt.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                expiredDrugDataGridView.DataSource = bs;

                a.Update(dt);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(expiredDrugDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           // DateTime dtt = DateTime.Now;
           // String dateNow = dtt.ToString("MM/dd/yyyy");
            // textBox2.Text = dateNow;



        }

        //FINISHED DRUGS
        public void finisheddDrugs()
        {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                
                MySqlCommand com = new MySqlCommand("SELECT id AS 'ID', drug_name AS 'DRUG NAME' FROM net_stock WHERE quantity<=0 ", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dt = new DataTable();
                // Add autoincrement column.
                dt.Columns.Add("#", typeof(int));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["#"] };
                dt.Columns["#"].AutoIncrement = true;
                dt.Columns["#"].AutoIncrementSeed = 1;
                dt.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                finishedDrugdataGridView1.DataSource = bs;

                a.Update(dt);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(finishedDrugdataGridView1.Rows.Count) - 1;
                finishedDrugsLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

       

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void addStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStaff a = new AddStaff();
            a.ShowDialog();
        }

        private void updateStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStaff u = new UpdateStaff();
            u.Show();
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

        private void updateSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSupplier u = new UpdateSupplier(pfsession.Text);
            u.ShowDialog();
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

        private void updateDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDrug u = new UpdateDrug(pfsession.Text);
            u.ShowDialog();
        }

        private void viewDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDrug v = new ViewDrug();
            v.ShowDialog();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStock a = new AddStock(pfsession.Text);
            a.ShowDialog();
        }

        private void updateStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStock u = new UpdateStock(pfsession.Text);
            u.ShowDialog();
        }

        private void viewStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStock v = new ViewStock();
            v.ShowDialog();
        }

        private void viewNetStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewNetStock v = new ViewNetStock();
            v.Show();
        }

        private void viewSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewSales s = new viewSales();
            s.ShowDialog();
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

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reports r = new Reports(this.pfsession.Text);
           // r.ShowDialog();
        }

        private void quantitySale_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuantitySale qs = new QuantitySale(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            qs.ShowDialog();
            this.Close();
        }

        private void cashSale_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard qs = new Dashboard(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
            qs.ShowDialog();
            this.Close();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculator c = new Calculator();
            c.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
        }

        private void reportsTotalStaffs_TextChanged(object sender, EventArgs e)
        {

        }

        private void totalDrugs_TextChanged(object sender, EventArgs e)
        {

        }

        private void moreSalesReports_Click(object sender, EventArgs e)
        {
            MoreSalesReports m = new MoreSalesReports();
            m.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\PMS\\Support\\admin manual.pdf");
        }

        private void backUpDatabase_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

    
    }
}
