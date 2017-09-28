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
    public partial class ExportDatabase : Form
    {
        public ExportDatabase()
        {
            InitializeComponent();
        }

        DialogResult dialog;
        String databaseConnection = "datasource=127.0.0.1; username=root; password=root; database=pms";

        private void ExportDatabase_Load(object sender, EventArgs e)
        {

        }

        // Database backup method.
        private void databaseBackUp()
        {

            try
            {
                dialog = MessageBox.Show("Are you sure you want to back up the database?", "DATABASE BACKUP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                                backup.ExportToFile(file);
                                con.Close();

                            }

                        }

                    }
                    MessageBox.Show("Database backup successful...............!", "DATABASE BACKUP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while backing up database ............!", "DATABASE BACKUP ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }// End backup of database.

        private void databaseBackupButton_Click(object sender, EventArgs e)
        {
            databaseBackUp();
        }

    }
}
