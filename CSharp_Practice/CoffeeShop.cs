using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_Shop_Pos_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string name;
        int price;
        int total;


        private void button1_Click(object sender, EventArgs e)
        {
            //Sandwich
            if(chhamcheese.Checked)
            {
                name = "Hamcheese";
                int qty = int.Parse(numericUpDown1.Value.ToString());
                price = 5000;
                total = qty * price;
                this.dataGridView1.Rows.Add(name, price, qty, total);
            }
            if(chchicken.Checked)
            {
                name = "Chicken";
                int qty = int.Parse(numericUpDown2.Value.ToString());
                price = 5500;
                total = qty * price;
                this.dataGridView1.Rows.Add(name, price, qty, total);
            }
            if(chsalmon.Checked)
            {
                name = "Salmon";
                int qty = int.Parse(numericUpDown3.Value.ToString());
                price = 6000;
                total = qty * price;
                this.dataGridView1.Rows.Add(name, price, qty, total);
            }
            //Beverage
            if (chicedcoffee.Checked)
            {
                name = "Iced Coffee";
                int qty = int.Parse(numericUpDown4.Value.ToString());
                price = 3500;
                total = qty * price;
                this.dataGridView1.Rows.Add(name, price, qty, total);
            }
            if (chchicken.Checked)
            {
                name = "Hot Coffee";
                int qty = int.Parse(numericUpDown5.Value.ToString());
                price = 3000;
                total = qty * price;
                this.dataGridView1.Rows.Add(name, price, qty, total);
            }
            if (chsalmon.Checked)
            {
                name = "Tea";
                int qty = int.Parse(numericUpDown6.Value.ToString());
                price = 2800;
                total = qty * price;
                this.dataGridView1.Rows.Add(name, price, qty, total);
            }

            int sum = 0;
            for(int row=0; row< dataGridView1.Rows.Count; row++)
            {
                sum = sum + Convert.ToInt32(dataGridView1.Rows[row].Cells[3].Value);
            }

            textBox1.Text = sum.ToString();

        }
    }
}
