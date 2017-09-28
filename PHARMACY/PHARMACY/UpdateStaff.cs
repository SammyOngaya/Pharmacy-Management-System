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
    public partial class UpdateStaff : Form
    {
        public UpdateStaff()
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            viewStaff();
            searchStaff();
            showStaffData();
        }

        DataTable dt;
        DialogResult dialog;

        //view staff
        public void viewStaff()
        {

            try
            {
                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                MySqlCommand com = new MySqlCommand("SELECT pfno AS 'PFNO',firstname AS 'FIRST NAME',lastname AS 'LAST NAME',dob AS 'DATE OF BIRTH',gender AS 'GENDER',nationalid AS 'NATIONAL ID',phone AS 'PHONE', email AS 'EMAIL', county AS 'COUNTY', location AS 'LOCATION', doe AS 'DATE OF EMPLOYMENT',category AS 'CATEGORY' FROM staff ORDER BY pfno DESC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

               dt = new DataTable();
                a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                updateStaffdataGridView.DataSource = bs;

                a.Update(dt);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(updateStaffdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
                     }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //clear fields
        public void clearFields()
        {
            this.updateStaffpfno.Text = "";
            this.updateStafffirstname.Text = "";
            this.updateStafflastname.Text = "";
            this.addstaffDob.Text = "";
            this.updateStaffPassword.Text = "";
            this.updateStaffNationalid.Text = "";
            this.updateStaffPhone.Text = "";
            this.updateStaffEmail.Text = "";
            this.updateStaffCounty.Text = "";
            this.updateStaffLocation.Text = "";
            this.addstaffDoe.Text = "";
            this.updateStaffCategory.Text = "";
            genderComboBox.Text = string.Empty;
            searchStaffUpdate.Text = string.Empty;
        }


        //filter database
        public void filterDatabase()
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("pfno LIKE '%{0}%'", searchStaffUpdate.Text);
            updateStaffdataGridView.DataSource = dv;
        }


        //search staff from staff
        public void searchStaff()
        {
            searchStaffUpdate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchStaffUpdate.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

            con.Open();

            MySqlCommand c = new MySqlCommand("select * from staff", con);

            MySqlDataReader r = c.ExecuteReader();

            while (r.Read())
            {
                String l = r.GetString("pfno");
                collection.Add(l);


            }

            searchStaffUpdate.AutoCompleteCustomSource = collection;

        }




        //fill data in fields
        public void showStaffData()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {

                con.Open();

                //MySqlCommand c = new MySqlCommand("SELECT * from staff ", con);
                MySqlCommand c = new MySqlCommand("SELECT * FROM staff WHERE pfno='" + this.searchStaffUpdate.Text + "'", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    String ids = r.GetString("pfno");

                    String firstname = r.GetString("firstname");
                    String lastname = r.GetString("lastname");
                    String gender = r.GetString("gender");
                    String nationalid = r.GetString("nationalid");
                    String phone = r.GetString("phone");
                    String county = r.GetString("county");
                    String location = r.GetString("location");
                    String doe = r.GetString("doe");
                    String dob = r.GetString("dob");
                    String category = r.GetString("category");
                    String password = r.GetString("password");
                    String email = r.GetString("email");

                    updateStafffirstname.Text = firstname;
                    updateStafflastname.Text = lastname;
                    addstaffDob.Text = dob;
                    genderComboBox.Text = gender;
                    updateStaffNationalid.Text = nationalid;
                    updateStaffPhone.Text = phone;
                    updateStaffCounty.Text = county;
                    updateStaffLocation.Text = location;
                    addstaffDoe.Text = doe;
                    updateStaffCategory.Text = category;
                    updateStaffPassword.Text = password;
                    updateStaffEmail.Text = email;

                    updateStaffpfno.Text = ids;


                    //retrieve image from the database upon the user
                    byte[] imgg = (byte[])(r["photo"]);
                    if (imgg == null)
                    {
                        loadImagePictureBox.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(imgg);
                        loadImagePictureBox.Image = System.Drawing.Image.FromStream(ms);
                    }
                    //end fetching image



                }

            }
            catch (Exception ex) {
                MessageBox.Show("Error has occured! pleasse"+ex.Message);
            }

        }


        //update Staffs

        public void updateStaffs()
        {
            if (updateStaffpfno.Text == string.Empty || updateStafffirstname.Text == string.Empty || updateStafflastname.Text == string.Empty || addstaffDob.Text == string.Empty || updateStaffPassword.Text == string.Empty || updateStaffNationalid.Text == string.Empty || updateStaffPhone.Text == string.Empty || updateStaffCounty.Text == string.Empty || updateStaffLocation.Text == string.Empty || addstaffDoe.Text == string.Empty || updateStaffCategory.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "STAFF UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
                MySqlConnection con = new MySqlConnection(db);

                if (imagePathTextBox.Text == String.Empty)
                {
                    try
                    {
                        dialog = MessageBox.Show("Are you sure you want to update employee personal details?", "EMPLOYEE CONTACTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialog == DialogResult.Yes)
                        {

                            con.Open();
                            int pid = Convert.ToInt32(updateStaffpfno.Text);
                            // int drid = Convert.ToInt32(drugidforeignkey.Text);
                            int nat = Convert.ToInt32(updateStaffNationalid.Text);

                            MySqlCommand c = new MySqlCommand("UPDATE `staff` SET nationalid='" + nat + "',firstname='" + this.updateStafffirstname.Text + "',gender='" + this.genderComboBox .Text+ "', lastname='" + this.updateStafflastname.Text + "', password='" + this.updateStaffPassword.Text + "', phone='" + this.updateStaffPhone.Text + "', email='" + this.updateStaffEmail.Text + "', county='" + this.updateStaffCounty.Text + "', location='" + this.updateStaffLocation.Text + "', category='" + this.updateStaffCategory.Text + "' WHERE pfno='" + pid + "'", con);

                            MySqlDataReader r = c.ExecuteReader();

                            MessageBox.Show("Staff updated successfully...............!", "EMPLOYEE PERSONAL DETAILS UPDATE ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            con.Close();
                            viewStaff();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error has occured while updating employee personal details............!", "EMPLOYEE PERSONAL DETAILS UPDATE ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
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

                if (imageSize > 8474)
                {
                    MessageBox.Show("The image selected " + rs + " bytes is larger than required size is of 8474 bytes or 8KB....");
                }
                else
                {
                    try
                    {
                        dialog = MessageBox.Show("Are you sure you want to update employee personal details?", "EMPLOYEE CONTACTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialog == DialogResult.Yes)
                        {


                            //STORE IMAGE IN BYTECODE
                            byte[] imageBt = null;
                            FileStream fs = new FileStream(this.imagePathTextBox.Text, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fs);
                            imageBt = br.ReadBytes((int)fs.Length);

                            con.Open();
                            int pid = Convert.ToInt32(updateStaffpfno.Text);
                            // int drid = Convert.ToInt32(drugidforeignkey.Text);
                            int nat = Convert.ToInt32(updateStaffNationalid.Text);

                            MySqlCommand command = new MySqlCommand("UPDATE `staff` SET nationalid='" + nat + "',gender='" + this.genderComboBox.Text + "',photo=@IMG,firstname='" + this.updateStafffirstname.Text + "', lastname='" + this.updateStafflastname.Text + "', password='" + this.updateStaffPassword.Text + "', phone='" + this.updateStaffPhone.Text + "', email='" + this.updateStaffEmail.Text + "', county='" + this.updateStaffCounty.Text + "', location='" + this.updateStaffLocation.Text + "', category='" + this.updateStaffCategory.Text + "' WHERE pfno='" + pid + "'", con);
                            command.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                            command.ExecuteNonQuery();

                            MessageBox.Show("Staff updated successfully...............!", "EMPLOYEE PERSONAL DETAILS UPDATE ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            con.Close();
                            viewStaff();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error has occured while updating employee personal details............!", "EMPLOYEE PERSONAL DETAILS UPDATE ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    }
                }

                }
            }
        }

        
        //deletes staff records from staff table
        public void deleteStaff()
        {
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("DELETE FROM staff WHERE pfno='" + this.updateStaffpfno.Text+ "'", con);
                MySqlDataReader nn = mc.ExecuteReader();
                while (nn.Read())
                {
                }
                MessageBox.Show("All Data Deleted Successfull");
                nn.Close(); //close rader
                con.Close(); //close connection

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //cartView(); //displays the cart method

        } //end delete from cart method
       
        

        private void UpdateStaff_Load(object sender, EventArgs e)
        {

        }

        private void searchStaffUpdate_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(searchStaffUpdate.Text, "[^ 0-9]"))
            {
                searchStaffUpdate.Text = "";
            }

            showStaffData();
            filterDatabase();
        }

        private void deleteStaff_Click(object sender, EventArgs e)
        {
             dialog = MessageBox.Show("Are you sure you want to delete th employee you have selected?", "EMPLOYEE REMOVAL", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

             if (dialog == DialogResult.Yes)
             {
                 deleteStaff();
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateStaffs();
            clearFields();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void updateStaffpfno_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(updateStaffpfno.Text, "[^ 0-9]"))
            {
                updateStaffpfno.Text = "";
            }
        }

        private void updateStaffNationalid_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(updateStaffNationalid.Text, "[^ 0-9]"))
            {
                updateStaffNationalid.Text = "";
            }
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

        private void imagePathTextBox_TextChanged(object sender, EventArgs e)
        {
            fileSize();
        }


        //load image to store in table
        public void loadImage()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files (*.jpg) | *.jpg| PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                string loc = dlg.FileName.ToString();
                imagePathTextBox.Text = loc;
                loadImagePictureBox.ImageLocation = loc;

            }

        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            loadImage();
        }
    }
}
