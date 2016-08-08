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
       // MySqlConnection con = null;
        public UpdateDrug(String pfn)
        {
            InitializeComponent();
           // con = DBHandler.CreateConnection();

            updatedrugpfsession.Text = pfn;
            viewDrug();
            searchDrug();
            drugCombo();
        }
        DialogResult dialog;
        DataTable dataTable;
        String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";

        //populate drug combo
        public void drugCombo()
        {
           try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("select * from drug_form", con);

                MySqlDataReader mm = c.ExecuteReader();

                while (mm.Read())
                {
                    String form_name = mm.GetString("form_name");
                    updateDrugForm.Items.Add(form_name);

                }
                con.Close();
            }
            catch (Exception)
            {

            }
           
        }

        //view drug

        public void viewDrug()
        {

            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `drug`.`name` AS 'Drug Name', `drug`.`form` AS 'Drug Form',`drug`.`pfno` AS 'Registered By', `drug`.`registered_date` AS 'Registered Date',`drug`.`status` AS 'Status' FROM drug ORDER BY name ASC", con);

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
                dataTable.Columns.Add("Drug Name");
                dataTable.Columns.Add("Drug Form");
                dataTable.Columns.Add("Registered By");
                dataTable.Columns.Add("Registered Date", typeof(string));
                dataTable.Columns.Add("Status");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                updateDrugdataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(updateDrugdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
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
            updateDrugName.Text = string.Empty;
            updateDrugForm.Text = string.Empty;
            updateDrugId.Text = string.Empty;
            searchDrugUpdate.Text = string.Empty;
            statusComboBox.Text = string.Empty;
          
        }

        //search drug from drug
        public void searchDrug()
        {
            searchDrugUpdate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchDrugUpdate.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("select * from drug", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    String l = r.GetString("name");
                    collection.Add(l);
                }
                con.Close();
            }
            catch (Exception) { 
            
            }

            searchDrugUpdate.AutoCompleteCustomSource = collection;

        }


        //fill data in fields
        public void showDrugData()
        {
            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM drug WHERE name='" + this.searchDrugUpdate.Text + "'", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string ids = r.GetInt32("id").ToString();
                    string nm = r.GetString("name");
                    string fr = r.GetString("form");
                    string status = r.GetString("status");

                    updateDrugName.Text = nm;
                    updateDrugForm.Text = fr;
                    updateDrugId.Text = ids;
                    statusComboBox.Text = status;
                }
                con.Close();
            }
            catch (Exception) { 
            
            }

        }


        //update Drug

        public void updateDrug()
        {

            if (updateDrugName.Text == string.Empty || updateDrugForm.Text == string.Empty ||  updateDrugId.Text == string.Empty || searchDrugUpdate.Text == string.Empty || statusComboBox.Text==string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "DRUG UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {

                    dialog = MessageBox.Show("Are you sure you want to update the drug?", "DRUG UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();
                        int did = Convert.ToInt32(updateDrugId.Text);
                        MySqlCommand c = new MySqlCommand("UPDATE drug SET pfno='" + this.updatedrugpfsession.Text + "'status='" + this.statusComboBox.Text + "',name='" + this.updateDrugName.Text + "',form='" + this.updateDrugForm.Text + "' WHERE id='" + did + "'", con);

                        c.ExecuteNonQuery();

                        MessageBox.Show("Drug updated successfully...............!", "DRUG UPDATE ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error has occured while updating drug............!", "DRUG UPDATE", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                

                viewDrug();
            }

        }

        private void searchDrugUpdate_TextChanged(object sender, EventArgs e)
        {
            showDrugData();
            //filterDatabase();
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
