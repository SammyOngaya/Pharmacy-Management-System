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
        public AddDrug(String pfn)
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            drugpfsession.Text = pfn;
            addDrugView();
        }

        DialogResult dialog;

        private void button1_Click(object sender, EventArgs e)
        {

            if (drugname.Text == string.Empty || drugform.Text == string.Empty || drugprice.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "DRUG DETAILS REGISTRATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {

                    string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                    MySqlConnection con = new MySqlConnection(db);

                     dialog = MessageBox.Show("Are you sure you want to register the drug details?", "DRUG DETALS REGISTRATION", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                     if (dialog == DialogResult.Yes)
                     {


                         con.Open();
                         DateTime dt = DateTime.Now;
                         String dateNow = dt.ToString("yyyy-MM-dd");

                         MySqlCommand c = new MySqlCommand("INSERT INTO drug VALUES(NULL,'" + this.drugname.Text + "','" + this.drugform.Text + "','" + this.drugprice.Text + "','" + this.drugpfsession.Text + "','" + dateNow + "')", con);

                         MySqlDataReader r = c.ExecuteReader();

                         MessageBox.Show("Drug details registered successfully...............!", "DRUG DETAILS REGISTRATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                         con.Close();

                         addDrugView();
                         clearFields();
                     }
                }
                catch (Exception) {
                    MessageBox.Show("Error has occured while registering drug details............!", "DRUG DETAILS REGISTRATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
        }

        //clear fields
        public void clearFields() {
            this.drugname.Text = "";
            this.drugform.Text = "";
            this.drugprice.Text = "";
        }

        public void addDrugView()
        {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                MySqlCommand com = new MySqlCommand("SELECT `drug`.`id` AS 'Drug Id', `drug`.`name` AS 'Drug Name', `drug`.`form` AS 'Drug Form',`drug`.`price` AS 'Drug Price',`drug`.`pfno` AS 'Registered By', `drug`.`registered_date` AS 'Registered Date' FROM drug ORDER BY name ASC", con);

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

      
    }
}
