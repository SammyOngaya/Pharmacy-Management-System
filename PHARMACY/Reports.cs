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
       // MySqlConnection con = null;
        public Reports(String ms)
        {
            InitializeComponent();
           // con = DBHandler.CreateConnection();
            setTime();

            pfsession.Text = ms;

            //staff reports
             viewDebtor();
            totalStaffReports();
           // totalMaleStaffReports();
            //totalFemaleStaffReports();
            totalMangerStaffReports();
            totalPharmacistStaffReports();

            //DRUGS REPORTS
            totalDrugsReports();

            //SUPPLIER REPORTS
            totalSupplierReports();

           
          
            //expired drugs
            expiredDrugs();

            //FINISHED DRUGS
            finisheddDrugs();

            //low drug quantity beep
            lowDrugQuantityBeeps();
            expiredDrugsBeeps();

            
        }

        String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
        DialogResult dialog;

        //set time
        public void setTime()
        {
            DateTime salestime = DateTime.Now;
            this.time.Text = salestime.ToString();
        }

        //low quantity drugs
        public void lowDrugQuantityBeeps() {

            try
            {
                int count = int.Parse(ExpiredDrugLabel.Text);

                if (count > 1) {
                  //  for (int i = 0; i < count; i++)
                  //  {
                        Console.Beep();
                        Thread.Sleep(1000);
                   // }

                    MessageBox.Show(count+" drugs are out of stock","FINISHED DRUG",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else if (count == 1)
                {
                    MessageBox.Show(count + " drug is out of stock", "FINISHED DRUG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
            }

        }

        //expires drugs notification
        public void expiredDrugsBeeps()
        {

            try
            {
                int count = int.Parse(finishedDrugLabel.Text);

                if (count > 1)
                {
                   // for (int i = 0; i < count; i++)
                  //  {
                        Console.Beep();
                        Thread.Sleep(1000);
                  //  }

                    MessageBox.Show(count + " drugs have expired","EXPIRED DRUGS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else if (count == 1)
                {
                    MessageBox.Show(count + " drug has expired", "EXPIRED DRUG", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else { 
                
                }
               
            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
            }

        }


       // total staff reports
        public void totalStaffReports() {
             try
             {
                 MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM staff",con);
             //  MySqlDataReader mr = mc.ExecuteReader();

                   Int64 count = (Int64)mc.ExecuteScalar();

                   reportsTotalStaffs.Text = count.ToString();
             
                con.Close();
              
            }
            catch (Exception ) {
                  //MessageBox.Show(ex.Message);
            }
        }
      

        // total Managers staff reports
        public void totalMangerStaffReports()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM staff WHERE category='Manager'", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                reportsManagers.Text = count.ToString();

                con.Close();

            }
            catch (Exception )
            {
              //  MessageBox.Show(ex.Message);
            }
        }

       
        // total Pharmacist staff reports
        public void totalPharmacistStaffReports()
        {
             try
             {
                 MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM staff WHERE category='Pharmacist'", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                reportsPharmacists.Text = count.ToString();

                con.Close();

            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
            }
        }
        

            ///////===========DRUG==========

             // total drugs reports
        public void totalDrugsReports()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM drug", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                totalDrugs.Text = count.ToString();

                con.Close();

            }
            catch (Exception )
            {
               //MessageBox.Show(ex.Message);
            }
        }

           ///////===========SUPPLIER==========

             // total supplier reports
        public void totalSupplierReports()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM supplier", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                totalSupplier.Text = count.ToString();

                con.Close();

            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
            }
        }
        
   
       

        //EXPIRED DRUGS
        public void expiredDrugs()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`drug`.`name` AS 'DRUG NAME', expiry_date AS 'EXPIRY DATE',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY', DATEDIFF(expiry_date,'" + dateNow + "') AS 'DAYS PASSED' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` WHERE ((DATEDIFF(expiry_date,'" + dateNow + "')<=0) AND (`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (`stock`.`status`='1')) ", con);

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
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(expiredDrugDataGridView.Rows.Count) - 1;
                ExpiredDrugLabel.Text = count.ToString() + " Records";
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
                
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT  `stock`.`stock_id` AS 'STOCK ID',`drug`.`name` AS 'DRUG NAME',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`reoder_level` AS 'RE-ODER LEVEL' FROM drug JOIN stock ON `drug`.`id`=`stock`.`drug_id` WHERE ((`stock`.`status`='1') AND ((`stock`.`initial_quantity`-`stock`.`quantity_sold`) <= (`reoder_level`))) ", con);

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
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(finishedDrugdataGridView1.Rows.Count) - 1;
                finishedDrugLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);
            }


        }

        public void viewDebtor()
        {

            try
            {
                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT DISTINCT(phone) AS 'PHONE',name AS 'NAMES',date_of_payment AS 'DATE OF PAYMENT' FROM `debtor`  WHERE ((DATEDIFF(`debtor`.`date_of_payment`,'" + dateNow + "')<=0) AND ((quantity*price)>deposit))  ORDER BY date_of_payment DESC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dt = new DataTable();

                // Add autoincrement column.
               dt.Columns.Add("#", typeof(string));
                dt.PrimaryKey = new DataColumn[] {dt.Columns["#"] };
               dt.Columns["#"].AutoIncrement = true;
               dt.Columns["#"].AutoIncrementSeed = 1;
               dt.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
               dt.Columns.Add("NAMES");
               dt.Columns.Add("PHONE");
               dt.Columns.Add("DATE OF PAYMENT", typeof(string));
                // End formating titles.

                a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                viewDebtorDataGridView.DataSource = bs;

                a.Update(dt);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewDebtorDataGridView.Rows.Count) - 1;
                totalUpaidDebtorslabel.Text = count.ToString() + " Records";
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
            drugDetails qs = new drugDetails(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            ReportSales salesReport = new ReportSales();
            salesReport.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportStock stock = new ReportStock();
            stock.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportDebtor debtor = new ReportDebtor(pfsession.Text);
            debtor.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReportPurchaseOrder purchase = new ReportPurchaseOrder();
            purchase.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Log log = new Log();
            log.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReportNetStock netStock = new ReportNetStock();
            netStock.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
             dialog = MessageBox.Show("Are you sure you want to remove expired drug from stock?", "REMOVE EXPIRED DRUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

             if (dialog == DialogResult.Yes)
             {

                 try
                 {

                     string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                     MySqlConnection con = new MySqlConnection(db);

                     if (expiredDrugDataGridView.SelectedRows.Count > 0)
                     {

                         int selectedIndex = expiredDrugDataGridView.SelectedRows[0].Index;
                         int RowID = int.Parse(expiredDrugDataGridView[1, selectedIndex].Value.ToString());

                         con.Open();
                         MySqlCommand cmd = new MySqlCommand("UPDATE stock set status='0' WHERE stock_id = " + RowID + "", con);
                         cmd.ExecuteNonQuery();
                         //MessageBox.Show("sales id is : " + salesReportDataGridView[2, selectedIndex].Value.ToString());
                         con.Close();

                         MessageBox.Show("Drug Removed Successfully", "EXPIRED DRUG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         expiredDrugs();
                     }
                     else
                     {
                         MessageBox.Show("No Drug selected", "NO DRUG SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     }

                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Error has occured while removing expired drug!" + ex.Message);
                 }
                 finally
                 {
                     //salesView();
                 }
             }
        }

        private void button8_Click(object sender, EventArgs e)
        {
           // UpdateStock u = new UpdateStock(pfsession.Text);
           // u.ShowDialog();

           

                try
                {

                    string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                    MySqlConnection con = new MySqlConnection(db);

                    if (expiredDrugDataGridView.SelectedRows.Count > 0)
                    {
                         dialog = MessageBox.Show("Are you sure you want to update drug expiry date?", "UPDATE EXPIRY DATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {

                        int selectedIndex = expiredDrugDataGridView.SelectedRows[0].Index;
                        int RowID = int.Parse(expiredDrugDataGridView[1, selectedIndex].Value.ToString());

                        DateTime date = DateTime.Parse(expiredDrugDataGridView[3, selectedIndex].Value.ToString());
                        string expiryDate = date.ToString("yyyy-MM-dd");

                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("UPDATE stock set expiry_date='" + expiryDate + "' WHERE stock_id = " + RowID + "", con);
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("sales id is : " + salesReportDataGridView[2, selectedIndex].Value.ToString());
                        con.Close();

                        MessageBox.Show("Drug updated Successfully", "EXPIRED DRUG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        expiredDrugs();
                 }
                    }
                    else
                    {
                        MessageBox.Show("No Drug selected", "NO DRUG SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error has occured while updating drug expiry date!" + ex.Message);
                }
                finally
                {
                    //salesView();
                }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
             

                 try
                 {

                     string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                     MySqlConnection con = new MySqlConnection(db);

                     if (finishedDrugdataGridView1.SelectedRows.Count > 0)
                     {
                         
                         dialog = MessageBox.Show("Are you sure you want to remove finished drug from stock?", "REMOVE FINISHED DRUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

             if (dialog == DialogResult.Yes)
             {

                         int selectedIndex = finishedDrugdataGridView1.SelectedRows[0].Index;
                         int RowID = int.Parse(finishedDrugdataGridView1[1, selectedIndex].Value.ToString());

                         con.Open();
                         MySqlCommand cmd = new MySqlCommand("UPDATE stock set status='0' WHERE stock_id = " + RowID + "", con);
                         cmd.ExecuteNonQuery();
                         //MessageBox.Show("sales id is : " + salesReportDataGridView[2, selectedIndex].Value.ToString());
                         con.Close();

                         MessageBox.Show("Drug Removed Successfully", "FINISHED DRUG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         finisheddDrugs();
             }
                     }
                     else
                     {
                         MessageBox.Show("No Drug selected", "NO DRUG SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     }

                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Error has occured while removing finished drug!" + ex.Message);
                 }
                 finally
                 {
                     //salesView();
                 }
             
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddStock a = new AddStock(pfsession.Text);
            a.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void reportsPharmacists_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void reportsManagers_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            ExpiredPaymentDateDebtorReport debtor = new ExpiredPaymentDateDebtorReport(pfsession.Text);
            debtor.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DebtorPayDebt v = new DebtorPayDebt(pfsession.Text);
            v.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ReportDailySales rds = new ReportDailySales();
            rds.ShowDialog();
        }
        
    
    }
}
