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
    public partial class FinishedDrugStockLevel : Form
    {
        MySqlConnection con = null;
        DialogResult dialog;
        public FinishedDrugStockLevel()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            getDrugLevel();
        }

        private void FinishedDrugStockLevel_Load(object sender, EventArgs e)
        {

        }


        // Get drug level from database.
        public void getDrugLevel()
        {
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT finished_drug_level FROM finished_drug_level", con);
                MySqlDataReader reader = mc.ExecuteReader();

                while (reader.Read())
                {
                    string drugLevel = reader.GetString("finished_drug_level");
                    drugLevelTextBox.Text = drugLevel;
                    drugLevelUpdadteValue.Text = drugLevel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Has occured" + ex.Message);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (drugLevelUpdadteValue.Text == string.Empty)
            {
                MessageBox.Show("Please fill the above field...............!", "DRUG LEVEL VALUE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    dialog = MessageBox.Show("Are you sure you want to update the minimum Drug Stock level?", "DRUG LEVEL VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        con.Open();
                        MySqlCommand c = new MySqlCommand("UPDATE `finished_drug_level` SET finished_drug_level='" + this.drugLevelUpdadteValue.Text + "' WHERE finished_drug_level_id='1'", con);

                        c.ExecuteNonQuery();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Has occured" + ex.Message);
                }
                con.Close();
                getDrugLevel();
            }
        }
    }
}
