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
    public partial class DrugForm : Form
    {
        MySqlConnection con = null;
        DialogResult dialog;
        public DrugForm()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            drugFormView();
            searchDrugForm();
        }
     //   String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
        private void DrugForm_Load(object sender, EventArgs e)
        {

        }




        private void save_Click(object sender, EventArgs e)
        {
            
            if (drugFormTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "DRUG FORM DETAILS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {

                    dialog = MessageBox.Show("Are you sure you want to register the drug details?", "DRUG FORM DETAILS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                      //  MySqlConnection con = new MySqlConnection(db);
                        con.Open();

                        DateTime dt = DateTime.Now;
                        String dateNow = dt.ToString("yyyy-MM-dd");

                        MySqlCommand c = new MySqlCommand("INSERT INTO drug_form VALUES(NULL,'" + this.drugFormTextBox.Text + "')", con);
                        c.ExecuteNonQuery();
                        MessageBox.Show("Drug form registered successfully...............!", "DRUG FORM DETAILS ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        drugFormView();
                        clearFields();
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Error has occured while adding drug form details............!", "DRUG FORM DETAILS ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                searchDrugForm();
            }
            
        }



        // Clear fields.
        private void clearFields() {
            drugFormTextBox.Text = string.Empty;
            drugFormIDTextBox.Text = string.Empty;
            searchDrugFormtextBox.Text = string.Empty;
        }

        // View drug form.
        public void drugFormView() {

           
            try
            {
                //MySqlConnection con = new MySqlConnection(db);
                con.Open();
               
                MySqlCommand com = new MySqlCommand("SELECT `drug_form`.`form_name` AS 'Drug FORM' FROM `drug_form`  ORDER BY `drug_form`.`form_name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dataTable = new DataTable();
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
                drugFormdataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(drugFormdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Error has occured while displaying drug form............!", "DRUG FORM DETAILS DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            

        }

        private void update_Click(object sender, EventArgs e)
        {
           
            if (drugFormTextBox.Text == string.Empty || drugFormIDTextBox.Text == string.Empty || searchDrugFormtextBox.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "DRUG FORM DETAILS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {
                   // MySqlConnection con = new MySqlConnection(db);
                    con.Open();

                    dialog = MessageBox.Show("Are you sure you want to update the drug details?", "DRUG FORM DETAILS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        DateTime dt = DateTime.Now;
                        String dateNow = dt.ToString("yyyy-MM-dd");

                        MySqlCommand c = new MySqlCommand("UPDATE drug_form SET form_name='" + this.drugFormTextBox.Text + "' WHERE drug_form_id='" + this.drugFormIDTextBox.Text + "' ", con);
                        c.ExecuteNonQuery();
                        MessageBox.Show("Drug form updated successfully...............!", "DRUG FORM DETAILS ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                    }
                    con.Close();
                    drugFormView();
                    
                }
                catch (Exception )
                {
                    //MessageBox.Show(ex.Message);
                   // MessageBox.Show("Error has occured while updating drug form details............!", "DRUG FORM DETAILS ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                searchDrugForm();
            }
            
        }

        private void delete_Click(object sender, EventArgs e)
        {

          
            if (drugFormTextBox.Text == string.Empty || drugFormIDTextBox.Text == string.Empty || searchDrugFormtextBox.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "DRUG FORM DETAILS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {
                   // MySqlConnection con = new MySqlConnection(db);
                    con.Open();

                    dialog = MessageBox.Show("Are you sure you want to delete the drug form?", "DRUG FORM DETAILS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        
                        DateTime dt = DateTime.Now;
                        String dateNow = dt.ToString("yyyy-MM-dd");

                        MySqlCommand c = new MySqlCommand("DELETE FROM drug_form WHERE drug_form_id='" + this.drugFormIDTextBox.Text + "' ", con);
                        c.ExecuteNonQuery();
                        MessageBox.Show("Drug form deleted successfully...............!", "DRUG FORM DETAILS ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        clearFields();
                    }
                    con.Close();
                    drugFormView();
                }
                catch (Exception )
                {
                   // MessageBox.Show(ex.Message);
                   // MessageBox.Show("Error has occured while deleting drug form details............!", "DRUG FORM DETAILS ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                searchDrugForm();
            }
            
        }


        //search drug form
        public void searchDrugForm()
        {
           
            searchDrugFormtextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchDrugFormtextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            try
            {
               // MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM drug_form", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    String form_name = r.GetString("form_name");
                    collection.Add(form_name);

                }

                con.Close();
            }
            catch (Exception) { 
            
            }
            
            searchDrugFormtextBox.AutoCompleteCustomSource = collection;
            
        }


        // Get drug form data in fields.
        public void showDrugFormData()
        {
            
            try
            {
               // MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM drug_form WHERE form_name='" + this.searchDrugFormtextBox.Text + "'", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    String drug_form_id = r.GetString("drug_form_id");
                    String form_name = r.GetString("form_name");

                    drugFormIDTextBox.Text = drug_form_id;
                    drugFormTextBox.Text = form_name;

                }
                con.Close();
            }
            catch (Exception) { 
            }
            
        }

        private void searchDrugFormtextBox_TextChanged(object sender, EventArgs e)
        {
            showDrugFormData();
        }

    }
}
