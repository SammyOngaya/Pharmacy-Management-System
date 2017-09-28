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
    class printSales
    {
        MySqlConnection con = null;
        public int sales_id { get; set; }
        public int cart_id { get; set; }
        public string drug_name { get; set; }
        public string quantity { get; set; }
        public string price { get; set; }
        public string pfno { get; set; }
        public string sales_date { get; set; }
        public string unit { get; set; }
        public string serial { get; set; }

        public printSales()
        {
            //initialize DB connection
            con = DBHandler.CreateConnection();
        }
        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            con.Open();

            MySqlCommand com = new MySqlCommand("SELECT sales_id AS 'ID', drug_name AS 'DRUG NAME',quantity AS 'QUANTITY',price AS 'PRICE', pfno AS 'SERVED BY',sales_date AS 'DATE SOLD',unit AS 'UNITS', serial AS 'RECEIPT NUMBER' FROM sales ORDER BY sales_date ASC", con);

            MySqlDataReader results = com.ExecuteReader();

            //create a new instance of drugprint class
            printSales newSalesPrint = new printSales();

            //print the report

            Graphics graphic = e.Graphics;

            System.Drawing.Font font = new System.Drawing.Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 150;

            System.Drawing.Image headerImage = System.Drawing.Image.FromFile("C:\\PMS\\Resources\\faith2.png");
            graphic.DrawImage(headerImage, startX, startY, 830, 150);

            string headerText = "Sales Report".PadLeft(35);
            graphic.DrawString(headerText, new System.Drawing.Font("Courier New", 16), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent

            graphic.DrawString("----------------------------------".PadLeft(55), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 7; //make the spacing consistent

            graphic.DrawString("Drug Name |".PadRight(5) + " Qty |".PadRight(5) + " Price |".PadRight(5) + " Served By |".PadRight(5) + " Units |".PadRight(5) + " Receipt No. |".PadRight(5) + " Date".PadRight(5), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            graphic.DrawString("--------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            while (results.Read())
            {
                try
                {
                    newSalesPrint.sales_id = results.GetInt16(0);
                    newSalesPrint.drug_name = results.GetString(1);
                    newSalesPrint.quantity = results.GetString(2);
                    newSalesPrint.price = results.GetString(3);
                    newSalesPrint.pfno = results.GetString(4);
                    newSalesPrint.sales_date = results.GetString(5);
                    newSalesPrint.unit = results.GetString(6);
                    newSalesPrint.serial = results.GetString(7);

                    graphic.DrawString(newSalesPrint.drug_name.PadRight(12) + newSalesPrint.quantity.PadRight(5) +
                                       newSalesPrint.price.PadRight(9) + newSalesPrint.pfno.PadRight(13) + newSalesPrint.unit.PadRight(7) + newSalesPrint.serial.PadRight(13) +
                                       newSalesPrint.sales_date.PadRight(7), font, new SolidBrush(Color.Black), startX, startY + offset);

                    offset = offset + (int)fontHeight; //make the spacing consistent

                    graphic.DrawString("--------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }
                catch (InvalidCastException er)
                {
                    MessageBox.Show(er.Message);
                }
            }

            con.Close();

            offset = offset + 20; //make some room so that the footer stands out.

            graphic.DrawString("Pharmacy Name".PadLeft(70), font, new SolidBrush(Color.Black), startX, startY + 1040);
            offset = offset + 15;
            graphic.DrawString("CopyRight @ 2015".PadLeft(72), font, new SolidBrush(Color.Black), startX, startY + 1040 + 20);

        }

        public void printReport(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();

            }
        }
    }
}
