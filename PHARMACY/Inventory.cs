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

namespace PHARMACY
{
    public partial class Inventory : Form
    {
        MySqlConnection con = null;
        public Inventory(string mess, string firstname, string lastname)
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            firstNameTextBox.Text = firstname;
            lastNameTextBox.Text = lastname;
            //Welcome user.
            pfsession.Text = mess;
        }


       
        

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports r = new Reports(pfsession.Text);
            r.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vat vat = new Vat();
            vat.ShowDialog();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderList orderlist = new OrderList(pfsession.Text);
            orderlist.ShowDialog();
        }

        private void updateOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateOrderList update = new UpdateOrderList(pfsession.Text);
            update.ShowDialog();
        }

        private void viewOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ViewOrderList view = new ViewOrderList();
            view.ShowDialog();
        }

        private void addSupplierPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSupplierPriceList supplier = new AddSupplierPriceList(pfsession.Text);
            supplier.ShowDialog();
        }

        private void updateSupplierPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSupplierPriceList supplier = new UpdateSupplierPriceList(pfsession.Text);
            supplier.ShowDialog();
        }

        private void viewSupplierPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSupplierPriceList supplier = new ViewSupplierPriceList();
            supplier.ShowDialog();
        }

        private void viewSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSales salesReport = new ReportSales();
            salesReport.ShowDialog();
        }

        private void viewNetStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportNetStock v = new ReportNetStock();
            v.Show();
        }

        private void addStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStock a = new AddStock(pfsession.Text);
            a.ShowDialog();
        }

        private void updateStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStock u = new UpdateStock(pfsession.Text);
            u.ShowDialog();
        }

        private void viewStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ViewStock v = new ViewStock();
           // v.ShowDialog();

            ReportStock stock = new ReportStock();
            stock.ShowDialog();
        }

        private void addDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDrug a = new AddDrug(pfsession.Text);
            a.ShowDialog();
        }

        private void updateDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDrug u = new UpdateDrug(pfsession.Text);
            u.ShowDialog();
        }

        private void viewDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDrug v = new ViewDrug();
            v.ShowDialog();
        }

        private void drugFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrugForm form = new DrugForm();
            form.ShowDialog();
        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSupplier ad = new AddSupplier(pfsession.Text);
            ad.ShowDialog();
        }

        private void updateSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSupplier u = new UpdateSupplier(pfsession.Text);
            u.ShowDialog();
        }

        private void viewSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSupplier v = new ViewSupplier();
            v.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddSupplier ad = new AddSupplier(pfsession.Text);
            ad.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            UpdateSupplier u = new UpdateSupplier(pfsession.Text);
            u.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewSupplier v = new ViewSupplier();
            v.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            DrugForm form = new DrugForm();
            form.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            AddDrug a = new AddDrug(pfsession.Text);
            a.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            UpdateDrug u = new UpdateDrug(pfsession.Text);
            u.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ViewDrug v = new ViewDrug();
            v.ShowDialog();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            AddStock a = new AddStock(pfsession.Text);
            a.ShowDialog();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            UpdateStock u = new UpdateStock(pfsession.Text);
            u.ShowDialog();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            //ViewStock v = new ViewStock();
           // v.ShowDialog();
            ReportStock stock = new ReportStock();
            stock.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ReportNetStock net = new ReportNetStock();
            net.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            viewSales s = new viewSales();
            s.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Reports r = new Reports(pfsession.Text);
            r.ShowDialog();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            AddSupplierPriceList supplier = new AddSupplierPriceList(pfsession.Text);
            supplier.ShowDialog();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            UpdateSupplierPriceList supplier = new UpdateSupplierPriceList(pfsession.Text);
            supplier.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            ViewSupplierPriceList supplier = new ViewSupplierPriceList();
            supplier.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            OrderList orderlist = new OrderList(pfsession.Text);
            orderlist.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UpdateOrderList update = new UpdateOrderList(pfsession.Text);
            update.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewOrderList view = new ViewOrderList();
            view.ShowDialog();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {

        }

        private void netStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportNetStock net = new ReportNetStock();
            net.ShowDialog();
        }

        private void mINIMUMSTOCKLEVELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinishedDrugStockLevel drugLevel = new FinishedDrugStockLevel();
            drugLevel.ShowDialog();
        }

        private void updateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Vat vat = new Vat();
            vat.ShowDialog();
        }
    }
}
