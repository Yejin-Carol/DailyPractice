using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MyfirstCalculator : Form
    {
        string flag = "";
        string stock = "";
        public MyfirstCalculator()
        {
            InitializeComponent();
            input1.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bt7_Click(object sender, EventArgs e)
        {
            input1.Text += "7";
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            input1.Text += "8";
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            input1.Text += "9";
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            input1.Text += "4";
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            input1.Text += "5";
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            input1.Text += "6";
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            input1.Text += "1";
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            input1.Text += "2";
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            input1.Text += "3";
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            input1.Text += "0";
        }

        private void btplus_Click(object sender, EventArgs e)
        {
          
            stock = input1.Text;
            input1.Text = "";
            flag += "+";

        }

        private void btminus_Click(object sender, EventArgs e)
        {
            stock = input1.Text;
            input1.Text = "";
            flag += "-";
        }

        private void btmultiply_Click(object sender, EventArgs e)
        {
            stock = input1.Text;
            input1.Text = "";
            flag += "*";
        }

        private void btdivide_Click(object sender, EventArgs e)
        {
            stock = input1.Text;
            input1.Text = "";
            flag += "/";
        }
             
        private void btequal_Click(object sender, EventArgs e)
        {
            if(flag == "+")
            {
                input1.Text =
                    (double.Parse(stock) + double.Parse(input1.Text.Trim())).ToString("0.000");
            }
            else if (flag == "-")
            {
                input1.Text =
                   (double.Parse(stock) - double.Parse(input1.Text.Trim())).ToString("0.000");
            }
            else if (flag == "*")
            {
                input1.Text =
                   (double.Parse(stock) * double.Parse(input1.Text.Trim())).ToString("0.000");
            }
            else if (flag == "/")
            {
                input1.Text =
                    (double.Parse(stock) / double.Parse(input1.Text.Trim())).ToString("0.000");
            }
            else
            {

            }

            input1.Text += "\n" + input1.Text;

            flag = "";
            stock = input1.Text;

        }

        private void btce_Click(object sender, EventArgs e)
        {
            stock = "";
            input1.Text = "";
            flag = "";

        }

     
    }
}
