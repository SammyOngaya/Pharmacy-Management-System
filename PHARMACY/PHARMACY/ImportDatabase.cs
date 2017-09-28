using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace PHARMACY
{
    public partial class ImportDatabase : Form
    {
        public ImportDatabase()
        {
            InitializeComponent();
        }
        DialogResult dialog;

        String databaseConnection = "datasource=127.0.0.1; username=root; password=root; database=pms";

        private void ImportDatabase_Load(object sender, EventArgs e)
        {

        }

        //creat database
        public void creatDatabase()
        {

            try
            {
                String databaseConnection = "datasource=localhost; port=3306; username=root; password=root";
                MySqlConnection con = new MySqlConnection(databaseConnection);

                con.Open();

                MySqlCommand mc = new MySqlCommand("CREATE DATABASE IF NOT EXISTS pms", con);
                //execute query
                mc.ExecuteNonQuery();

                con.Close();

                // MessageBox.Show("Ddatabase created!!");

            }
            catch (Exception)
            {
                //MessageBox.Show("Unable to create database " + ex.Message);
            }

        }



        // Database restore method.
        private void databaseRestore()
        {

            try
            {
                dialog = MessageBox.Show("Are you sure you want to restore the database?", "DATABASE RESTORE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {

                    string file = "C:\\PMS\\Data\\backup.sql";

                    using (MySqlConnection con = new MySqlConnection(databaseConnection))
                    {
                        using (MySqlCommand command = new MySqlCommand())
                        {
                            using (MySqlBackup backup = new MySqlBackup(command))
                            {

                                command.Connection = con;
                                con.Open();
                                backup.ImportFromFile(file);
                                con.Close();

                            }

                        }

                    }
                    MessageBox.Show("Database restored successfully...............!", "DATA RESTORE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while restoring database ............!", "DATABASE RESTORE ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }// End restore of database.

        private void databaseBackupButton_Click(object sender, EventArgs e)
        {
            creatDatabase();
            databaseRestore();
        }

    }
}
