using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PHARMACY.PrintingControl
{
    class printReceipt
    {
        MySqlConnection con = null;
        public string drug_name{get;set;}
        public string quantity { get; set; }
        public string units { get; set; }
        public string price { get; set; }
        public string total_amount { get; set; }
       // public string sum { get; set; }

        public printReceipt() { 
        //Initialize connection string.
            con = DBHandler.CreateConnection();
        }

        public void createReceipt(object sender,System.Drawing.Printing.PrintPageEventArgs events) {
            con.Open();
            MySqlCommand command = new MySqlCommand("SELECT drug_name AS 'DRUG NAME',quantity AS 'QTY',price AS 'PRICE',quantity*price AS 'TOTAL',unit AS 'UNITS' FROM cart ORDER BY cart_id ASC",con);
            MySqlDataReader reader = command.ExecuteReader();
           
            //create a new instance of printReceipt class
            printReceipt newPrintReceipt = new printReceipt();

            //print the receipt layout first

            Graphics graphic = events.Graphics;

            System.Drawing.Font font = new System.Drawing.Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 150;

            // Locate the image of the receipt.
            System.Drawing.Image headerImage = System.Drawing.Image.FromFile("C:\\PMS\\Resources\\faith2.png");
            graphic.DrawImage(headerImage, startX, startY, 830, 150);

            // This is the title of the receipt.
            string headerText = "Sales Receipt".PadLeft(35);
            graphic.DrawString(headerText, new System.Drawing.Font("Courier New", 16), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent

            graphic.DrawString("----------------------------------".PadLeft(55), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 7; //make the spacing consistent

            graphic.DrawString("Drug Name |".PadRight(5) + " Qty |".PadRight(5) + " Price |".PadRight(5) + " Total |".PadRight(5) + " Units".PadRight(5), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            graphic.DrawString("--------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            while (reader.Read())
            {
                try
                {
                    newPrintReceipt.drug_name = reader.GetString(0);
                    newPrintReceipt.quantity = reader.GetString(1);
                    newPrintReceipt.price = reader.GetString(2);
                    newPrintReceipt.total_amount = reader.GetString(3);
                    newPrintReceipt.units = reader.GetString(4);

                    graphic.DrawString(newPrintReceipt.drug_name.PadRight(12) + newPrintReceipt.quantity.PadRight(5) +
                                       newPrintReceipt.price.PadRight(9) + newPrintReceipt.total_amount.PadRight(5) + newPrintReceipt.units.PadRight(7), font, new SolidBrush(Color.Black), startX, startY + offset);

                    offset = offset + (int)fontHeight; //make the spacing consistent

                    graphic.DrawString("--------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight + 5; //make the spacing consistent.
                }
                catch (InvalidCastException er)
                {
                    MessageBox.Show(er.Message);
                }
            }

            con.Close();

            offset = offset + 5; //make some room so that the footer stands out.
            drugDetails dashboard = new drugDetails();

            //graphic.DrawString("Total Cost : ".PadLeft(70) + dashboard.getTotalCost(), font, new SolidBrush(Color.Black), startX, startY + offset);
           // offset = offset + 15;

            graphic.DrawString("Wabsta Pharmacy \"TOUCHING LIVES REACHING PEOPLE.\"".PadLeft(70), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("DESIGNED BY TESMOLITE TECHNOLOGIES.".PadLeft(72), font, new SolidBrush(Color.Black), startX, startY + offset + 20);

        }


        public void print(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(createReceipt); //add an event handler that will do the printing

            DialogResult result = printDialog.ShowDialog();
           
            
            if (result == DialogResult.OK)
            {
                printDocument.Print();

            }
           
        }

    }
}
