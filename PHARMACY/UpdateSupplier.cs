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
       // MySqlConnection con = null;

        public UpdateSupplier(String pfn)
        {
            InitializeComponent();
           // con = DBHandler.CreateConnection();
            viewSupplier();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            updatepfsession.Text = pfn; //session variable
            searchSupplierName();
            showSupplierData();
            
        
        }
        String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
        DialogResult dialog;
        DataTable dataTable;

        //filter database
        public void filterDatabase()
        {
            DataView dv = new DataView(dataTable);
            dv.RowFilter = string.Format("name LIKE '%{0}%'", searchSupplier.Text);
            updateSupplierDataGridView.DataSource = dv;
        }

        //search supplier from suppliers
        public void searchSupplierName()
        {
            searchSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchSupplier.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("select * from supplier", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    String l = r.GetString("name");
                    collection.Add(l);


                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has occured!" + ex.Message);
            } 
           
            searchSupplier.AutoCompleteCustomSource = collection;
           
        }


        //fill data in fields
        public void showSupplierData()
        {
             try
            {
                MySqlConnection con = new MySqlConnection(db);
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
                    String status = r.GetString("status");

                    updateSupplierName.Text = nm;
                    updateSupplierPhone.Text = ph;
                    updateSupplierAdress.Text = ad;
                    updateSupplierLocation.Text = loc;
                    updateSupplierId.Text = ids;
                    supplierStatusComboBox.Text = status;
                }
                con.Close();
            }
            catch (Exception ex) {
                MessageBox.Show("Error has occured!"+ex.Message);
            }
             
        }


        //view supplier

        public void viewSupplier() {

            try
            {
                MySqlConnection con = new MySqlConnection(db);

                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT  `supplier`.`name` AS 'Supplier Name',`supplier`.`phone` AS 'Supplier Phone',`supplier`.`address` AS 'Supplier Adress',`supplier`.`location` AS 'Supplier Location',`supplier`.`pfno` AS 'Registered By',`supplier`.`registered_date` AS 'Registered Date',`supplier`.`status` AS 'Status' FROM supplier ORDER BY name ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(int));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("Supplier Name");
                dataTable.Columns.Add("Supplier Phone");
                dataTable.Columns.Add("Supplier Adress");
                dataTable.Columns.Add("Supplier Location");
                dataTable.Columns.Add("Registered By");
                dataTable.Columns.Add("Registered Date", typeof(string));
                dataTable.Columns.Add("Status");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                updateSupplierDataGridView.DataSource = bs;

                a.Update(dataTable);

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

        public void updateSupplier()
        {

            if (updateSupplierId.Text == string.Empty || updateSupplierName.Text == string.Empty || updateSupplierPhone.Text == string.Empty || updateSupplierAdress.Text == string.Empty || updateSupplierLocation.Text == string.Empty || searchSupplier.Text == string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "SUPPLIER UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    DateTime dt = DateTime.Now;
                    string date = dt.ToString("yyyy-MM-dd");

                    dialog = MessageBox.Show("Are you sure you want to update the supplier?", "SUPPLIER UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();
                        int did = Convert.ToInt32(updateSupplierId.Text);
                        // int pf = Convert.ToInt32(updatepfsession.Text);
                        MySqlCommand c = new MySqlCommand("UPDATE supplier SET pfno='" + this.updatepfsession.Text + "',name='" + this.updateSupplierName.Text + "',phone='" + this.updateSupplierPhone.Text + "',address='" + this.updateSupplierAdress.Text + "',location='" + this.updateSupplierLocation.Text + "',status='" + this.supplierStatusComboBox.Text+ "' WHERE id='" + did + "'", con);
                        c.ExecuteNonQuery();
                        MessageBox.Show("Supplier updated successfully...............!", "SUPPLIER UPDATE ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                   
                }
                catch (Exception)
                {
                    MessageBox.Show("Error has occured while updating supplier............!", "SUPPLIER UPDATE", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }

                

                viewSupplier();

            }
        }
       

        private void searchSupplier_TextChanged(object sender, EventArgs e)
        {
            showSupplierData();
           // filterDatabase();
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

        private void deleteSupplier_Click(object sender, EventArgs e)
        {

        }
    }
}
