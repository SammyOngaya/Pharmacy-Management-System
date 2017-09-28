using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.Threading;

namespace PHARMACY
{
    public partial class CashierReports : Form
    {
        public CashierReports()
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            //expired drugs
            expiredDrugs();

            //FINISHED DRUGS
            finisheddDrugs();

            //low drug quantity beep
            lowDrugQuantityBeeps();
            expiredDrugsBeeps();
        }

       

        //low quantity drugs
        public void lowDrugQuantityBeeps()
        {

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

                if (count >= 1)
                {
                    for (int i = 0; i < count; i++)
                    {
                        Console.Beep();
                        Thread.Sleep(1000);
                    }

                    MessageBox.Show(count + "drugs are out of stock");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        private void CashierReports_Load(object sender, EventArgs e)
        {

        }
    }
}
