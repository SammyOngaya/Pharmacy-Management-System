using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PHARMACY
{
    public partial class UpdateSupplier : Form
    {
        public UpdateSupplier(String pfn)
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            updatepfsession.Text = pfn; //session variable
            searchDrug();
            showSupplierData();
            viewSupplier();
        
        }

        DataTable dt;

        //filter database
        public void filterDatabase()
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("name LIKE '%{0}%'", searchSupplier.Text);
            updateSupplierDataGridView.DataSource = dv;
        }

        //search supplier from suppliers
        public void searchDrug()
        {
            searchSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchSupplier.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            con.Open();

            MySqlCommand c = new MySqlCommand("select * from supplier", con);

            MySqlDataReader r = c.ExecuteReader();

            while (r.Read())
            {
                String l = r.GetString("name");
                collection.Add(l);


            }

            searchSupplier.AutoCompleteCustomSource = collection;


        }


        //fill data in fields
        public void showSupplierData()
        {
             string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                MySqlCommand c = new MySqlCommand("select * from supplier WHERE name='" + this.searchSupplier.Text + "'", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    String ids = r.GetInt32("id").ToString();
                    String nm = r.GetString("name");
                    String ph = r.GetString("phone");
                    String ad = r.GetString("address");
                    String loc = r.GetString("location");

                    updateSupplierName.Text = nm;
                    updateSupplierPhone.Text = ph;
                    updateSupplierAdress.Text = ad;
                    updateSupplierLocation.Text = loc;
                    updateSupplierId.Text = ids;



                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error has occured!"+ex.Message);
            }

        }


        //view supplier

        public void viewSupplier() {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`id` AS 'Supplier Id',`supplier`.`name` AS 'name',`supplier`.`phone` AS 'Supplier Phone',`supplier`.`address` AS 'Supplier Adress',`supplier`.`location` AS 'Supplier Location',`supplier`.`pfno` AS 'Registered By',`supplier`.`id` AS 'Registered Date' FROM supplier ORDER BY name ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

               dt = new DataTable();
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
                updateSupplierDataGridView.DataSource = bs;

                a.Update(dt);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(updateSupplierDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //update supplier

        public void updateSupplier() {

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            con.Open();
            int did = Convert.ToInt32(updateSupplierId.Text);
           // int pf = Convert.ToInt32(updatepfsession.Text);
            MySqlCommand c = new MySqlCommand("UPDATE supplier SET pfno='" + this.updatepfsession.Text + "',name='"+this.updateSupplierName.Text+"',phone='" + this.updateSupplierPhone.Text + "',address='" + this.updateSupplierAdress.Text + "',location='" + this.updateSupplierLocation.Text + "' WHERE id='" + did + "'", con);

            MySqlDataReader r = c.ExecuteReader();

            MessageBox.Show("Supplier Updated successfully");

            while (r.Read())
            {

            }



            con.Close();

            viewSupplier();
        
        }

       

        private void searchSupplier_TextChanged(object sender, EventArgs e)
        {
            showSupplierData();
            filterDatabase();
        }

        private void updateSupplierButton_Click(object sender, EventArgs e)
        {
            updateSupplier();
        }

        private void updateSupplierDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateSupplier_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
