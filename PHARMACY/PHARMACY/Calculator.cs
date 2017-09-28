using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PHARMACY
{
    public partial class Calculator : Form
    {
        Double results = 0;
        String operation = "";
        bool isOperationPerformed = false;

        public Calculator()
        {
            InitializeComponent();
            System.Drawing.Icon ico = new System.Drawing.Icon("C:\\PMS\\Resources\\form-icon.ico");
            this.Icon = ico;
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((resultsTextBox.Text == "0") || (isOperationPerformed))
                resultsTextBox.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!(resultsTextBox.Text.Contains(".")))
                    resultsTextBox.Text = resultsTextBox.Text + button.Text;

            }
            else
            {

                resultsTextBox.Text = resultsTextBox.Text + button.Text;
            }
            }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (results != 0)
            {
                equalsButton11.PerformClick();

                operation = button.Text;

                displayResults.Text = results + " " + operation;
                results = Double.Parse(resultsTextBox.Text);
                isOperationPerformed = true;
            }
            else {
                operation = button.Text;

                displayResults.Text = results + " " + operation;
                results = Double.Parse(resultsTextBox.Text);
                isOperationPerformed = true;
            }

           
        }

        private void cancelEntryButton5_Click(object sender, EventArgs e)
        {
            resultsTextBox.Text = "0";
        }

        private void cancelButton6_Click(object sender, EventArgs e)
        {
            resultsTextBox.Text = "0";
            results = 0;
        }

        private void equalsButton11_Click(object sender, EventArgs e)
        {
            switch (operation) { 
            
                case "+":
                    resultsTextBox.Text = (results + Double.Parse(resultsTextBox.Text)).ToString();
                    break;
                case "-":
                    resultsTextBox.Text = (results - Double.Parse(resultsTextBox.Text)).ToString();
                    break;
                case "*":
                    resultsTextBox.Text = (results * Double.Parse(resultsTextBox.Text)).ToString();
                    break;
                case "/":
                    resultsTextBox.Text = (results / Double.Parse(resultsTextBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            results=Double.Parse(resultsTextBox.Text);
            displayResults.Text = "";
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

       
    }
}
