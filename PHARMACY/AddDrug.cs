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
    public partial class AddDrug : Form
    {
       // MySqlConnection con = null;
        public AddDrug(String pfn)
        {
            InitializeComponent();
           // con = DBHandler.CreateConnection();
            drugpfsession.Text = pfn;
            addDrugView();
            drugCombo();
        }

        DialogResult dialog;
        String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";

        //populate drug combo
        public void drugCombo()
        {
             try
             {
                 MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM drug_form", con);

                MySqlDataReader mm = c.ExecuteReader();

                while (mm.Read())
                {
                    String form_name = mm.GetString("form_name");
                    drugform.Items.Add(form_name);

                } 
                 con.Close();
            }
            catch (Exception) { 
            
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (drugname.Text == string.Empty || drugform.Text == string.Empty ||  statusComboBox.Text==string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "DRUG DETAILS REGISTRATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {

                   
                     dialog = MessageBox.Show("Are you sure you want to register the drug details?", "DRUG DETALS REGISTRATION", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                     if (dialog == DialogResult.Yes)
                     {
                         MySqlConnection con = new MySqlConnection(db);

                         con.Open();
                         DateTime dt = DateTime.Now;
                         String dateNow = dt.ToString("yyyy-MM-dd");

                         MySqlCommand c = new MySqlCommand("INSERT INTO drug VALUES(NULL,'" + this.drugname.Text + "','" + this.drugform.Text + "','" + this.drugpfsession.Text + "','" + dateNow + "','" + this.statusComboBox.Text + "')", con);
                         c.ExecuteNonQuery();
                         MessageBox.Show("Drug details registered successfully...............!", "DRUG DETAILS REGISTRATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                         con.Close();

                         addDrugView();
                         clearFields();
                     }
                }
                catch (Exception) {
                    //MessageBox.Show(ex.Message);
                    MessageBox.Show("Error has occured while registering drug details............!", "DRUG DETAILS REGISTRATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
        }

        //clear fields
        public void clearFields() {
            drugname.Text = string.Empty;
            drugform.Text = string.Empty;
            statusComboBox.Text = string.Empty;
        }

        public void addDrugView()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(db);

                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT  `drug`.`name` AS 'Drug Name', `drug`.`form` AS 'Drug Form',`drug`.`pfno` AS 'Registered By', `drug`.`registered_date` AS 'Registered Date' , status AS 'Status' FROM drug ORDER BY name ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
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
                addDrugdataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(addDrugdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception )
            {
                MessageBox.Show("Error has occured while displaying drug details............!", "DRUG DETAILS DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }

        private void addDrugdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddDrug_Load(object sender, EventArgs e)
        {

        }

        private void drugpfsession_TextChanged(object sender, EventArgs e)
        {

        }

        private void drugprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void drugform_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void drugname_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rowCountLabel_Click(object sender, EventArgs e)
        {

        }

      
    }
}
