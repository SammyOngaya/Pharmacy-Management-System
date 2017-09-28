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
    public partial class AddSupplier : Form
    {
        public AddSupplier(String pfn)
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            addSupplierSessionPf.Text = pfn;
            addSupplierView();

        }

        DialogResult dialog;
        //clear fields
        public void clearFields()
        {
            this.addSupplierCompanyName.Text = "";
            this.addSupplierPhone.Text = "";
            this.addSupplierAdress.Text = "";
            this.addSupplierLocation.Text = "";
        
        }

        private void saveSupplier_Click_1(object sender, EventArgs e)
        {

            if (addSupplierCompanyName.Text == string.Empty || addSupplierPhone.Text == string.Empty || addSupplierLocation.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "SUPPLIER REGISTRATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);
                try
                {
                     dialog = MessageBox.Show("Are you sure you want to register supplier details?", "SUPPLIER DETALS REGISTRATION", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                     if (dialog == DialogResult.Yes)
                     {

                         con.Open();
                         DateTime dt = DateTime.Now;
                         String dateNow = dt.ToString("yyyy-MM-dd");

                         MySqlCommand c = new MySqlCommand("INSERT INTO supplier VALUES(NULL,'" + this.addSupplierCompanyName.Text + "','" + this.addSupplierPhone.Text + "','" + this.addSupplierAdress.Text + "','" + this.addSupplierLocation.Text + "','" + this.addSupplierSessionPf.Text + "','" + dateNow + "')", con);

                         MySqlDataReader r = c.ExecuteReader();

                         MessageBox.Show("Supplier details registered successfully...............!", "SUPPLIER DETAILS REGISTRATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                         con.Close();

                         addSupplierView();
                         clearFields();
                     }
                }
                catch (Exception) {
                    MessageBox.Show("Error has occured while registering supplier details............!", "SUPPLIER DETAILS REGISTRATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
        }


        public void addSupplierView()
        {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`id` AS 'Supplier Id',`supplier`.`name` AS 'Supplier Name',`supplier`.`phone` AS 'Supplier Phone',`supplier`.`address` AS 'Supplier Adress',`supplier`.`location` AS 'Supplier Location',`supplier`.`pfno` AS 'Registered By',`supplier`.`id` AS 'Registered Date' FROM supplier ORDER BY name ASC", con);

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
                addSupplierdataGridView.DataSource = bs;

                a.Update(dt);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(addSupplierdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception )
            {
                MessageBox.Show("Error has occured while displaying supplier details............!", "SUPPLIER DETAILS DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
               
            }





        }

        private void AddSupplier_Load(object sender, EventArgs e)
        {

        }

       


    }
}
