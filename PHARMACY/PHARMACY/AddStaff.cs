using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace PHARMACY
{
    public partial class AddStaff : Form
    {
        public AddStaff()
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            addStaffView();
        }

        DialogResult dialog;
       
        
        //clear fields
        public void clearFields()
        {
            this.addstaffpfno.Text = "";
            this.addstafffirstname.Text = "";
            this.addstafflastname.Text = "";
            this.addstaffDob.Text = "";
            this.addstaffPassword.Text = "";
            this.addstaffNationalid.Text = "";
            this.addstaffPhone.Text = "";
            this.addstaffEmail.Text = "";
            this.addstaffCounty.Text = "";
            this.addstaffLocation.Text = "";
            this.addstaffDoe.Text = "";
            this.addstaffCategory.Text = "";
            genderComboBox.Text = string.Empty;
        }


        // Check image upload file size.
        public void fileSize()
        {

            try
            {
                byte[] imageBt = null;
                FileStream fs = new FileStream(this.imagePathTextBox.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageBt = br.ReadBytes((int)fs.Length);

                //Get file size.
                long size = imageBt.Length;
                String rs = size.ToString();

                if (size > 8474)
                {
                    MessageBox.Show("The image selected " + rs + " bytes is larger than required size is of 8474 bytes or 8KB....");
                }
            }
            catch (Exception)
            {
                //  MessageBox.Show("Problem    " + ex.Message);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (addstaffpfno.Text == string.Empty || addstafffirstname.Text == string.Empty || addstafflastname.Text == string.Empty || addstaffDob.Text == string.Empty || addstaffPassword.Text == string.Empty || addstaffNationalid.Text == string.Empty || addstaffPhone.Text == string.Empty || addstaffCounty.Text == string.Empty || addstaffLocation.Text == string.Empty || addstaffDoe.Text == string.Empty || addstaffCategory.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "STAFF REGISTRATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                string dateOfBirth = addstaffDob.Value.ToString("yyyy-MM-dd");
                string dateOfEmployment = addstaffDoe.Value.ToString("yyyy-MM-dd");
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                if (imagePathTextBox.Text == String.Empty)
                {
                    try
                    {
                        dialog = MessageBox.Show("Are you sure you want to register the employee ?", "EMPLOYEE REGISTRATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialog == DialogResult.Yes)
                        {

                            con.Open();

                            MySqlCommand command = new MySqlCommand("INSERT INTO staff VALUES('" + this.addstaffpfno.Text + "','" + this.addstafffirstname.Text + "','" + this.addstafflastname.Text + "','" + dateOfBirth + "','" + this.genderComboBox.Text + "','" + this.addstaffNationalid.Text + "','" + this.addstaffPhone.Text + "','" + this.addstaffEmail.Text + "','" + this.addstaffCounty.Text + "','" + this.addstaffLocation.Text + "','" + dateOfEmployment + "','" + this.addstaffCategory.Text + "','" + this.addstaffPassword.Text + "','NO PHOTO')", con);
                            command.ExecuteNonQuery();

                            con.Close();
                            MessageBox.Show("Staff registered successfully...............!", "EMPLOYEE PERSONAL DETAILS REGISTRATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            addStaffView();
                            clearFields();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error has occured while registering employee personal details............!", "EMPLOYEE PERSONAL DETAILS REGISTRATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    }


                }
                else
                {
                    byte[] imageByt = null;
                    FileStream fileStream = new FileStream(this.imagePathTextBox.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    imageByt = binaryReader.ReadBytes((int)fileStream.Length);

                    //Get file size.
                    long imageSize = imageByt.Length;
                    String rs = imageSize.ToString();

                    if (imageSize < 8474)
                    {

                        //STORE IMAGE IN BYTECODE
                        byte[] imageBt = null;
                        FileStream fs = new FileStream(this.imagePathTextBox.Text, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        imageBt = br.ReadBytes((int)fs.Length);

                        try
                        {
                            dialog = MessageBox.Show("Are you sure you want to register the employee ?", "EMPLOYEE REGISTRATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (dialog == DialogResult.Yes)
                            {

                                con.Open();

                                MySqlCommand c = new MySqlCommand("INSERT INTO staff VALUES('" + this.addstaffpfno.Text + "','" + this.addstafffirstname.Text + "','" + this.addstafflastname.Text + "','" + dateOfBirth + "','" + this.genderComboBox.Text + "','" + this.addstaffNationalid.Text + "','" + this.addstaffPhone.Text + "','" + this.addstaffEmail.Text + "','" + this.addstaffCounty.Text + "','" + this.addstaffLocation.Text + "','" + dateOfEmployment + "','" + this.addstaffCategory.Text + "','" + this.addstaffPassword.Text + "',@IMG)", con);

                                //bind image to database
                                c.Parameters.Add(new MySqlParameter("@IMG", imageBt));

                                MySqlDataReader r = c.ExecuteReader();

                                MessageBox.Show("Staff registered successfully...............!", "EMPLOYEE PERSONAL DETAILS REGISTRATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                con.Close();
                            }

                            addStaffView();
                            clearFields();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error has occured while registering employee personal details............!", "EMPLOYEE PERSONAL DETAILS REGISTRATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("The image selected " + rs + " bytes is larger than required size is of 8474 bytes or 8KB....");

                    }
                }
            }
        }


        public void addStaffView()
        {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                MySqlCommand com = new MySqlCommand("SELECT pfno AS 'PFNO',firstname AS 'FIRST NAME',lastname AS 'LAST NAME',dob AS 'DATE OF BIRTH',gender AS 'GENDER',nationalid AS 'NATIONAL ID',phone AS 'PHONE', email AS 'EMAIL', county AS 'COUNTY', location AS 'LOCATION', doe AS 'DATE OF EMPLOYMENT',category AS 'CATEGORY' FROM staff ORDER BY pfno DESC", con);

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
                addstaffdataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(addstaffdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception )
            {
                MessageBox.Show("Error has occured while displaying employee personal details............!", "EMPLOYEE PERSONAL DETAILS DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }


        //load image to store in table
        public void loadImage() {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files (*.jpg) | *.jpg| PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK) {

                string loc = dlg.FileName.ToString();
                imagePathTextBox.Text = loc;
                loadImagePictureBox.ImageLocation = loc;

            }
        }

        private void addstaffPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioMale_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioFemale_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void AddStaff_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            loadImage();
        }

        private void addstaffpfno_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(addstaffpfno.Text, "[^ 0-9]"))
            {
                addstaffpfno.Text = "";
            }
        }

        private void addstaffNationalid_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(addstaffNationalid.Text, "[^ 0-9]"))
            {
                addstaffNationalid.Text = "";
            }
        }

        private void imagePathTextBox_TextChanged(object sender, EventArgs e)
        {
            fileSize();
        }



    }
}
