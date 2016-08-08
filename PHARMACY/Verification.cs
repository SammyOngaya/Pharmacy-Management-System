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
using System.Net.NetworkInformation;

namespace PHARMACY
{
    public partial class Verification : Form
    {
        public Verification()
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            validatedSoftware();
        }


        public void validatedSoftware()
        {

            if (!File.Exists("C:\\PMS\\‎\\KEYFILE.txt"))
            {
               readMacAddress();
               writeKeyFile();

              // this.Hide();
               Form1 f = new Form1();
               f.ShowDialog();
              // this.Close();
              
            }
            else
            {
                readMacAddress();
                readKeyFile();

                String macAddressKey = Convert.ToString(this.verificationMacAddress.Text);
                String keyFileKey = Convert.ToString(this.keyFromFile.Text);

                if (macAddressKey == keyFileKey)
                {
                    //this.Hide();
                    Form1 f = new Form1();
                    f.ShowDialog();
                    //this.Close();
                
                }else{

                    MessageBox.Show("This is copy of the software is not genuine");
                }

               

            }
        }


        //read mac address
        public void readMacAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String mac = string.Empty;

            foreach (NetworkInterface adapter in nics)
            {
                if (mac == String.Empty)
                {//returns mac address from first card
                    IPInterfaceProperties pr = adapter.GetIPProperties();
                    mac = adapter.GetPhysicalAddress().ToString();

                }
            }

            verificationMacAddress.Text = mac;

        }


        //write to key file
        public void writeKeyFile()
        {
            try
            {
                FileStream fs = new FileStream("C:\\PMS\\‎\\KEYFILE.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);
                String key = Convert.ToString(this.verificationMacAddress.Text);
                writer.Write(key);
                writer.Close();

            }
            catch(Exception ex) {
                MessageBox.Show("error while writting to file"+ex.Message);
            }
        }


       
        //read from key file
        public void readKeyFile()
        {
            FileStream fs = new FileStream("C:\\PMS\\‎\\KEYFILE.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            keyFromFile.Text = reader.ReadToEnd();
            reader.Close();
        }

             private void Verification_Load(object sender, EventArgs e)
        {

        }

             private void splashTimer_Tick(object sender, EventArgs e)
             {
                 splashProgressBar.Increment(1);
                 //if (splashProgressBar.Value == 100) {

                     //validatedSoftware();

                    // splashTimer.Stop();

                // }
             }
    }
}
