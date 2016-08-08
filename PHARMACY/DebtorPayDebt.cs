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
using iTextSharp.text;
using iTextSharp.text.pdf;

using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;
using System.Diagnostics;

namespace PHARMACY
{
    public partial class DebtorPayDebt : Form
    {
        MySqlConnection con = null;
        DataTable dataTable;
        DialogResult dialog;

        public DebtorPayDebt(string pfno)
        {
            InitializeComponent();
            pfSessionTextBox.Text = pfno;
            con = DBHandler.CreateConnection();
            viewDebtor();
            searchStockID();
            searchPhone();
        }
        String db = "datasource=localhost; port=3306; username=root; password=root; database=pms";

        private void DebtorPayDebt_Load(object sender, EventArgs e)
        {

        }

        //compute amount transacted.
        public void amount()
        {

            double sum = 0.00;
            for (int i = 0; i < debtroReportDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(debtroReportDataGridView.Rows[i].Cells[6].Value);

            }

            amountLabel.Text = "total amount  " + sum.ToString() + " Kshs";
            totalAmountOwedLabel.Text = sum.ToString();
        }

        //compute amount transacted.
        public void DepositAmount()
        {

            double sum = 0.00;
            for (int i = 0; i < debtroReportDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(debtroReportDataGridView.Rows[i].Cells[7].Value);

            }

            depositAmount.Text = "deposit amount  " + sum.ToString() + " Kshs";
            depositTXTlabel.Text = sum.ToString();
        }

        //compute amount transacted.
        public void RemainingAmount()
        {

            double sum = 0.00;
            for (int i = 0; i < debtroReportDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(debtroReportDataGridView.Rows[i].Cells[8].Value);

            }

            remainingAmount.Text = "remaining amount  " + sum.ToString() + " Kshs";
        }


        public void ComputeRemainingAmountAfterPaying()
        {
            try
            {
                double userAmountTxt = Convert.ToDouble(userAmountTextBox.Text);
                double deposit = Convert.ToDouble(depositTXTlabel.Text);
                double totalAmount=Convert.ToDouble(totalAmountOwedLabel.Text);

                balanceLabel.Text = "";
                RemainingAmountLabel.Text = "";


                if ((userAmountTxt + deposit) >= totalAmount)
                {
                    DebtStatusLabel.ForeColor = Color.Green;
                    DebtStatusLabel.Text = "Good!!";
                    balanceLabel.ForeColor = Color.Green;
                    balanceLabel.Text = "Balance is : " + ((userAmountTxt + deposit) - totalAmount) + "Kshs.";
                    RemainingAmountLabel.ForeColor = Color.Green;
                    RemainingAmountLabel.Text = "Your debt is settled.";
                }
                else
                {
                    DebtStatusLabel.ForeColor = Color.Red;
                    DebtStatusLabel.Text = "Not yet!!";
                    balanceLabel.ForeColor = Color.Red;
                    balanceLabel.Text = "Your debt is not settled.";
                    RemainingAmountLabel.ForeColor = Color.Red;
                    RemainingAmountLabel.Text = "Remaining Amount is " + (totalAmount-(userAmountTxt + deposit)) + "Kshs.";

                }


            }
            catch (Exception) { 
            
            }
        }

        private void ReportDebtor_Load(object sender, EventArgs e)
        {

        }




        //search drug from debtor.
        public void searchStockID()
        {
            searchDebtorIDTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchDebtorIDTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {
                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                con.Open();


                MySqlCommand com = new MySqlCommand("SELECT `drug`.`name` AS 'name' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `debtor` ON `stock`.`stock_id`=`debtor`.`stock_id` WHERE ((`debtor`.`quantity`*`debtor`.`price`)>`debtor`.`deposit`) GROUP BY `debtor`.`stock_id` ORDER BY `drug`.`name` ASC", con);

                MySqlDataReader r = com.ExecuteReader();

                while (r.Read())
                {
                    string name = r.GetString("name");
                    collection.Add(name);

                }
                con.Close();
            }
            catch (Exception)
            {
            }
            searchDebtorIDTextBox.AutoCompleteCustomSource = collection;

        }


        //search phone from debtor.
        public void searchPhone()
        {
            phoneTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            phoneTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {
                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                con.Open();


                MySqlCommand com = new MySqlCommand("SELECT phone FROM  debtor WHERE (((`debtor`.`quantity`*`debtor`.`price`)>`debtor`.`deposit`))  ORDER BY phone ASC", con);

                MySqlDataReader r = com.ExecuteReader();

                while (r.Read())
                {
                    string phone = r.GetString("phone");
                    collection.Add(phone);

                }
                con.Close();
            }
            catch (Exception)
            {
            }
            phoneTextBox.AutoCompleteCustomSource = collection;

        }


        public void viewDebtor()
        {

            try
            {
                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand com = new MySqlCommand("SELECT `debtor`.`id` AS 'DEBTOR ID',`debtor`.`name` AS 'NAME',`drug`.`name` AS 'DRUG NAME',`debtor`.`quantity` AS 'QUANTITY',`debtor`.`price` AS 'PRICE',(`debtor`.`quantity`*`debtor`.`price`) AS 'AMOUNT',((`debtor`.`quantity`*`debtor`.`price`)-`debtor`.`deposit`) AS 'BALANCE',`debtor`.`date_borrowed` AS 'DATE BORROWED',`debtor`.`phone` AS 'PHONE',`debtor`.`deposit` AS 'DEPOSIT',`debtor`.`date_of_payment` AS 'DATE OF PAYMENT',`debtor`.`pfno` AS 'REGISTERED BY',`debtor`.`registered_date` AS 'REGISTRATION DATE',`debtor`.`stock_id` AS 'STOCK ID' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `debtor` ON `stock`.`stock_id`=`debtor`.`stock_id` WHERE (((`debtor`.`quantity`*`debtor`.`price`)>`debtor`.`deposit`))  ORDER BY `debtor`.`date_borrowed` DESC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();

                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.


                // Format titles.
                dataTable.Columns.Add("DEBTOR ID");
                dataTable.Columns.Add("NAME");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("PRICE");
                dataTable.Columns.Add("AMOUNT");
                dataTable.Columns.Add("DEPOSIT");
                dataTable.Columns.Add("BALANCE");
                dataTable.Columns.Add("DATE BORROWED", typeof(string));
                dataTable.Columns.Add("PHONE");
                dataTable.Columns.Add("DATE OF PAYMENT", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                dataTable.Columns.Add("REGISTRATION DATE", typeof(string));
                dataTable.Columns.Add("STOCK ID");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                debtroReportDataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(debtroReportDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            amount();
            DepositAmount();
            RemainingAmount();
        }


        // View debtor filter by drug name.
        public void viewDebtorFilterBystockID()
        {
            try
            {
                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand com = new MySqlCommand("SELECT `debtor`.`id` AS 'DEBTOR ID',`debtor`.`name` AS 'NAME',`drug`.`name` AS 'DRUG NAME',`debtor`.`quantity` AS 'QUANTITY',`debtor`.`price` AS 'PRICE',(`debtor`.`quantity`*`debtor`.`price`) AS 'AMOUNT',((`debtor`.`quantity`*`debtor`.`price`)-`debtor`.`deposit`) AS 'BALANCE',`debtor`.`date_borrowed` AS 'DATE BORROWED',`debtor`.`phone` AS 'PHONE',`debtor`.`deposit` AS 'DEPOSIT',`debtor`.`date_of_payment` AS 'DATE OF PAYMENT',`debtor`.`pfno` AS 'REGISTERED BY',`debtor`.`registered_date` AS 'REGISTRATION DATE',`debtor`.`stock_id` AS 'STOCK ID' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `debtor` ON `stock`.`stock_id`=`debtor`.`stock_id` WHERE (((`debtor`.`quantity`*`debtor`.`price`)>`debtor`.`deposit`) AND (`debtor`.`id`='" + this.searchDebtorIDTextBox.Text + "'))  ORDER BY `drug`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();

                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.


                // Format titles.
                dataTable.Columns.Add("DEBTOR ID");
                dataTable.Columns.Add("NAME");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("PRICE");
                dataTable.Columns.Add("AMOUNT");
                dataTable.Columns.Add("DEPOSIT");
                dataTable.Columns.Add("BALANCE");
                dataTable.Columns.Add("DATE BORROWED", typeof(string));
                dataTable.Columns.Add("PHONE");
                dataTable.Columns.Add("DATE OF PAYMENT", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                dataTable.Columns.Add("REGISTRATION DATE", typeof(string));
                dataTable.Columns.Add("STOCK ID");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                debtroReportDataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(debtroReportDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            amount();
            DepositAmount();
            RemainingAmount();
        }

        // View debtor filter by phone.
        public void viewDebtorFilterByPhone()
        {
            try
            {
                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand com = new MySqlCommand("SELECT `debtor`.`id` AS 'DEBTOR ID',`debtor`.`name` AS 'NAME',`drug`.`name` AS 'DRUG NAME',`debtor`.`quantity` AS 'QUANTITY',`debtor`.`price` AS 'PRICE',(`debtor`.`quantity`*`debtor`.`price`) AS 'AMOUNT',((`debtor`.`quantity`*`debtor`.`price`)-`debtor`.`deposit`) AS 'BALANCE',`debtor`.`date_borrowed` AS 'DATE BORROWED',`debtor`.`phone` AS 'PHONE',`debtor`.`deposit` AS 'DEPOSIT',`debtor`.`date_of_payment` AS 'DATE OF PAYMENT',`debtor`.`pfno` AS 'REGISTERED BY',`debtor`.`registered_date` AS 'REGISTRATION DATE' ,`debtor`.`stock_id` AS 'STOCK ID' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `debtor` ON `stock`.`stock_id`=`debtor`.`stock_id` WHERE ( ((`debtor`.`quantity`*`debtor`.`price`)>`debtor`.`deposit`) AND (`debtor`.`phone`='" + this.phoneTextBox.Text + "'))  ORDER BY `debtor`.`phone` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();

                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("DEBTOR ID");
                dataTable.Columns.Add("NAME");
                dataTable.Columns.Add("DRUG NAME");
                dataTable.Columns.Add("QUANTITY");
                dataTable.Columns.Add("PRICE");
                dataTable.Columns.Add("AMOUNT");
                dataTable.Columns.Add("DEPOSIT");
                dataTable.Columns.Add("BALANCE");
                dataTable.Columns.Add("DATE BORROWED", typeof(string));
                dataTable.Columns.Add("PHONE");
                dataTable.Columns.Add("DATE OF PAYMENT", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                dataTable.Columns.Add("REGISTRATION DATE", typeof(string));
                dataTable.Columns.Add("STOCK ID");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                debtroReportDataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(debtroReportDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            amount();
            DepositAmount();
            RemainingAmount();
        }

        //print pdf for debtor
        public void debtorPdf()
        {

            try
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
                PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\PMS\\Reports\\DEBTOR REQUEST REPORT", FileMode.Create));
                doc.Open();//open document to write

                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\PMS\\Resources\\faith2.png");
                img.ScalePercent(79f);
                // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);



                doc.Add(img); //add image to document
                Paragraph p = new Paragraph("                                                                Debtor Report");
                doc.Add(p);
                DateTime time = DateTime.Now;

                Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "        Produced On         " + time.ToString() + "        \n\n");
                doc.Add(p2);


                //load data from datagrid
                PdfPTable table = new PdfPTable(debtroReportDataGridView.Columns.Count);

                //add headers from the datagridview to the table
                for (int j = 0; j < debtroReportDataGridView.Columns.Count; j++)
                {

                    table.AddCell(new Phrase(debtroReportDataGridView.Columns[j].HeaderText));

                }

                //flag the first row as header

                table.HeaderRows = 1;

                //add the actual rows to the table from datagridview

                for (int i = 0; i < debtroReportDataGridView.Rows.Count; i++)
                {
                    for (int k = 0; k < debtroReportDataGridView.Columns.Count; k++)
                    {

                        if (debtroReportDataGridView[k, i].Value != null)
                        {

                            table.AddCell(new Phrase(debtroReportDataGridView[k, i].Value.ToString()));
                        }

                    }

                }

                doc.Add(table);
                //end querying from datagrid


                doc.Close();//close document after writting in

                MessageBox.Show("Debtor Report generated Successful");

                System.Diagnostics.Process.Start("C:\\PMS\\Reports\\DEBTOR REQUEST REPORT");

            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ", "DOCUMENT ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

            }

        }

        //print debtors excel.
        public void debtorsExcel()
        {
            //sqlConnection = new MySqlConnection(databaseConnection);

            try
            {
                DataTable dtCopy = dataTable.Copy();

                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dtCopy);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\PMS\\Reports\\DEBTOR REQUEST REPORT.xls", ds);

                MessageBox.Show("Report generated successfully");
                Process sts = System.Diagnostics.Process.Start("C:\\PMS\\Reports\\DEBTOR REQUEST REPORT.xls");
                sts.WaitForExit();

                // sqlConnection.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ", "DOCUMENT ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

            }

        }


        //fill data in fields
        public void showDebtorData()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `debtor`.`id` AS 'debtor_id',`debtor`.`stock_id` AS 'stock_id',`debtor`.`name` AS 'debtorname',`drug`.`name` AS 'drugname',`debtor`.`quantity` AS 'drquantity',`debtor`.`price` AS 'price',`debtor`.`phone` AS 'phone' FROM `drug` JOIN `stock` ON `drug`.`id`=`stock`.`drug_id` JOIN `debtor` ON `stock`.`stock_id`=`debtor`.`stock_id` WHERE ( `debtor`.`id`='" + this.searchDebtorIDTextBox.Text + "') ", con);

                MySqlDataReader r = com.ExecuteReader();

                while (r.Read())
                {
                    string ids = r.GetString("debtor_id");

                    string drugid = r.GetString("stock_id");
                    string name = r.GetString("debtorname");
                    string dr = r.GetString("drugname");
                    string qty = r.GetString("drquantity");
                    string ph = r.GetString("phone");
                    string pri = r.GetString("price");

                    updateDebtorPrimaryKey.Text = ids;
                    stockIDTextBox.Text = drugid;
                    DrugNameLabel.Text = "Drug Name : " + dr + " ";
                    NameLabel.Text = "Name : "+name+" ";
                    drugQuantityLabel.Text = "Quantity : "+qty+" ";
                    updateQuantity.Text = qty;
                    phoneLable.Text = "Phone : "+ph+" ";
                    updatePhone.Text = ph;
                    updateDebtorPriceTextBox.Text = pri;

                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            viewDebtorFilterByPhone();
        }

        private void searchByDriverID_Click(object sender, EventArgs e)
        {
            viewDebtorFilterByPhone();
        }

        private void debtIDTextBox_TextChanged(object sender, EventArgs e)
        {
            searchStockID();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            viewDebtorFilterBystockID();
        }

        private void searchDebtorIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(searchDebtorIDTextBox.Text, "[^ 0-9]"))
            {
                searchDebtorIDTextBox.Text = "";
            }
            showDebtorData();
            viewDebtorFilterBystockID();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(userAmountTextBox.Text, "[^ 0-9]"))
            {
                userAmountTextBox.Text = "";
            }

            ComputeRemainingAmountAfterPaying();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double amt = Convert.ToDouble(totalAmountOwedLabel.Text);
            if (searchDebtorIDTextBox.Text != string.Empty && updateDebtorPrimaryKey.Text != string.Empty && userAmountTextBox.Text != string.Empty && amt!=0)
            {
               

                    dialog = MessageBox.Show("Are you sure you want to make the following changes?", "DEBT PAYMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        decimal amount = Convert.ToDecimal(totalAmountOwedLabel.Text);
                        decimal deposit = Convert.ToDecimal(depositTXTlabel.Text);
                        decimal currentAmt = Convert.ToDecimal(userAmountTextBox.Text);

                        if (amount <= (deposit+currentAmt))
                        {

                             CompletePayDebt();

                             insertToSales();

                             viewDebtor();
                        }
                        else
                        {

                            UpdateDebt();

                            viewDebtor();
                        }

                  

                }

                else
                {
                    MessageBox.Show("PLEASE ENTER THE DEBTOR ID FROM TABLE BELOW!", "PAYMENT ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
              }
                    else
                    {
                        MessageBox.Show("PLEASE ENSURE THAT YOU HAVE SEARCHED THE DEBTOR CORRECTLY USING DEBTOR ID", "NO DEBTOR SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
        }


        public void CompletePayDebt()
        {

            try
            {
                
                    MySqlConnection con = new MySqlConnection(db);
                    con.Open();

                    MySqlCommand c = new MySqlCommand("UPDATE `debtor` SET deposit='" + this.totalAmountOwedLabel.Text + "' WHERE id='" + this.searchDebtorIDTextBox.Text + "'", con);

                   c.ExecuteNonQuery();
                    MessageBox.Show("Debt Updated successfully. And is Settled.", "UPDATE DEBTOR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();

                   
            }
            catch (Exception)
            {

            }
            finally
            {

            }

        }


          public void UpdateDebt()
        {

            try
            {

                double deposit = Convert.ToDouble(depositTXTlabel.Text);
                double currentAmt = Convert.ToDouble(userAmountTextBox.Text);
                
                    MySqlConnection con = new MySqlConnection(db);
                    con.Open();

                    MySqlCommand c = new MySqlCommand("UPDATE `debtor` SET deposit='" + (currentAmt + deposit) + "' WHERE id='" + this.searchDebtorIDTextBox.Text + "'", con);

                    c.ExecuteNonQuery();
                    MessageBox.Show("Debt Updated successfully.", "UPDATE DEBTOR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    con.Close();
                
            }
            catch (Exception)
            {

            }
            finally
            {

            }

        }


        // Insert to sales from cart
        public void insertToSales()
        {
            
            
            string db = "datasource=localhost; port=3306; username=root; password=root; database=pms";
            MySqlConnection con = new MySqlConnection(db);

           
                try
                {
                    //current date
                    DateTime curdate = DateTime.Now;
                    String dateCurrent = curdate.ToString("yyyy-MM-dd");

                    con.Open();

                    MySqlCommand c = new MySqlCommand("INSERT INTO sales VALUES(NULL,'99','" + this.stockIDTextBox.Text + "','" + this.updateQuantity.Text + "','" + this.updateDebtorPriceTextBox.Text + "','" + this.pfSessionTextBox.Text + "','" + dateCurrent + "','DEBTOR','0.00')", con);
                    c.ExecuteNonQuery();
                    // cashSaleDelete();
                    MessageBox.Show("SUCCESS", "SECSESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            
        }

        public void ReverseStockQuantity()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand mc = new MySqlCommand("UPDATE stock set quantity_sold=(quantity_sold - '" + this.updateQuantity.Text + "'), status='1' WHERE stock_id= '" + this.stockIDTextBox.Text + "' ", con);
                mc.ExecuteNonQuery();
                MessageBox.Show("DRUG SUCCESSFULLY REVERSED", "DRUG REVERSAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception)
            {

            }
            finally
            {

            }

        }

        public void SetDebtorToZeroAfterReversal()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand mc = new MySqlCommand("UPDATE debtor set quantity='0.00' WHERE id= '" + this.updateDebtorPrimaryKey.Text + "' ", con);
                mc.ExecuteNonQuery();
                //MessageBox.Show("DRUG SUCCESSFULLY REVERSED", "DRUG REVERSAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception)
            {

            }
            finally
            {

            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            viewDebtor();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (searchDebtorIDTextBox.Text != string.Empty && updateDebtorPrimaryKey.Text != string.Empty)
            {


                dialog = MessageBox.Show("Are you sure you want to make the following changes?", "DRUG REVERSAL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {

                    ReverseStockQuantity();
                    SetDebtorToZeroAfterReversal();
                    ClearDetails();

                }

                else
                {
                    MessageBox.Show("PLEASE ENTER THE DEBTOR ID FROM TABLE BELOW!", "PAYMENT ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            else
            {
                MessageBox.Show("PLEASE ENSURE THAT YOU HAVE SEARCHED THE DEBTOR CORRECTLY USING DEBTOR ID", "NO DEBTOR SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void ClearDetails()
        {

            updatePhone.Text = string.Empty;
            //updateDebtorPriceTextBox.Text = string.Empty;
            searchDebtorIDTextBox.Text = string.Empty;
            stockIDTextBox.Text = string.Empty;
            updateDebtorPrimaryKey.Text = string.Empty;
            updateQuantity.Text = "0.00";
            updateDebtorPriceTextBox.Text = "0.00";
            amountLabel.Text = "0.00";
            stockIDTextBox.Text = string.Empty;
            DrugNameLabel.Text = string.Empty;
            NameLabel.Text = string.Empty;
            drugQuantityLabel.Text = string.Empty;
            phoneLable.Text = string.Empty;
            amountLabel.Text = string.Empty;
            depositAmount.Text = string.Empty;
            remainingAmount.Text = string.Empty;
        
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

    }
}
