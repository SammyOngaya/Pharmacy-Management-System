using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Diagnostics;

namespace PHARMACY
{
    public partial class AdminHelp : Form
    {
        public AdminHelp()
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;

            viewPdfHelp();
        }

        //view pdf
        public void viewPdfHelp() {

               // Create object of Open file dialog class
 
            {
                OpenFileDialog dlg = new OpenFileDialog();
                // set file filter of dialog 
               // dlg.Filter = "pdf files (*.pdf) |*.pdf;";
             //   dlg.ShowDialog();
             //   if (dlg.FileName!= null)
             //   {
                    // use the LoadFile(ByVal fileName As String) function for open the pdf in control
                //adminHelpAxAcroPDF1.LoadFile("C:\\Users\\sam\\Desktop\\openmrs-developers-guide");
                //adminHelpAxAcroPDF1.Location("C:\\Users\\sam\\Desktop\\openmrs-developers-guide");
                //adminHelpAxAcroPDF1
                System.Diagnostics.Process.Start("C:\\Users\\sam\\Desktop\\openmrs-developers-guide.pdf");
              //  }
 
            
 
        }


           //System.Diagnostics.Process.Start("C:\\Users\\sam\\Desktop\\C#\\PHARMACY\\Reports\\drug pdf");
        }

        private void AdminHelp_Load(object sender, EventArgs e)
        {

        }
    }
}
