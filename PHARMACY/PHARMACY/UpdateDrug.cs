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
    public partial class UpdateDrug : Form
    {
        public UpdateDrug(String pfn)
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            updatedrugpfsession.Text = pfn;
            viewDrug();
            searchDrug();
            showDrugData();
        }

        DataTable dataTable;

        //view drug

        public void viewDrug()
        {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                MySqlCommand com = new MySqlCommand("SELECT `drug`.`id` AS 'Drug Id', `drug`.`name` AS 'name', `drug`.`form` AS 'Drug Form',`drug`.`price` AS 'Drug Price',`drug`.`pfno` AS 'Registered By', `drug`.`registered_date` AS 'Registered Date' FROM drug ORDER BY name ASC", con);

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
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                updateDrugdataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(updateDrugdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //filter database
        public void filterDatabase() {
            DataView dv = new DataView(dataTable);
            dv.RowFilter = string.Format("name LIKE '%{0}%'", searchDrugUpdate.Text);
            updateDrugdataGridView.DataSource = dv;
        }


        //clear fields
        public void clearFields()
        {
            this.updateDrugName.Text = "";
            this.updateDrugForm.Text = "";
            this.updateDrugPrice.Text = "";
          
        }

        //search drug from drug
        public void searchDrug()
        {
            searchDrugUpdate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchDrugUpdate.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            con.Open();

            MySqlCommand c = new MySqlCommand("select * from drug", con);

            MySqlDataReader r = c.ExecuteReader();

            while (r.Read())
            {
                String l = r.GetString("name");
                collection.Add(l);


            }

            searchDrugUpdate.AutoCompleteCustomSource = collection;


        }


        //fill data in fields
        public void showDrugData()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            con.Open();

            MySqlCommand c = new MySqlCommand("select * from drug WHERE name='" + this.searchDrugUpdate.Text + "'", con);

            MySqlDataReader r = c.ExecuteReader();

            while (r.Read())
            {
                String ids = r.GetInt32("id").ToString();
                String nm = r.GetString("name");
                String fr = r.GetString("form");
                String pr = r.GetDouble("price").ToString();
               
                updateDrugName.Text = nm;
                updateDrugForm.Text = fr;
                updateDrugPrice.Text = pr;
                updateDrugId.Text = ids;



            }

        }


        //update Drug

        public void updateDrug()
        {

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            con.Open(); 
            int did = Convert.ToInt32(updateDrugId.Text);
            MySqlCommand c = new MySqlCommand("UPDATE drug SET pfno='" + this.updatedrugpfsession.Text + "',name='" + this.updateDrugName.Text + "',form='" + this.updateDrugForm.Text + "',price='" + this.updateDrugPrice.Text + "' WHERE id='" + did + "'", con);

            MySqlDataReader r = c.ExecuteReader();

            MessageBox.Show("Drug Updated successfully");

            while (r.Read())
            {

            }



            con.Close();

            viewDrug();

        }

        private void searchDrugUpdate_TextChanged(object sender, EventArgs e)
        {
            showDrugData();
            filterDatabase();
        }

        private void updateDrugButton_Click(object sender, EventArgs e)
        {
            updateDrug();
            clearFields();
        }

        private void UpdateDrug_Load(object sender, EventArgs e)
        {

        }

    }
}
