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
    public partial class Vat : Form
    {
        MySqlConnection con = null;
        public Vat()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            getVat();
        }

        DialogResult dialog;

        // Get vat tax from database.
        public void getVat()
        {
            try
            {
                con.Open();
                MySqlCommand c = new MySqlCommand("SELECT * FROM vat", con);

                MySqlDataReader reader = c.ExecuteReader();

                while (reader.Read())
                {
                    string vat = reader.GetString("vat_value");
                    vatTextBox.Text = vat;
                    vatUpdadteValue.Text = vat;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Has occured" + ex.Message);
            }
            con.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                if (vatTextBox.Text == string.Empty)
                {
                    MessageBox.Show("Please fill all the above field...............!", "VAT VALUE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                    dialog = MessageBox.Show("Are you sure you want to update the VAT value?", "VAT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        con.Open();
                        MySqlCommand c = new MySqlCommand("UPDATE `vat` SET vat_value='" + this.vatUpdadteValue.Text + "' WHERE vat_id='1'", con);

                        c.ExecuteNonQuery();

                    }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Has occured" + ex.Message);
            }
                    con.Close();
            getVat();
        }
              }


        private void Vat_Load(object sender, EventArgs e)
        {

        }
    }
}
