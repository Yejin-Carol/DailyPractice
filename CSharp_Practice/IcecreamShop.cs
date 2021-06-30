using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Coffee_Shop_Pos_System
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            pictureBox1.MouseClick += mouseClick;
            pictureBox2.MouseClick += mouseClick;
            pictureBox3.MouseClick += mouseClick;
            pictureBox4.MouseClick += mouseClick;
            pictureBox5.MouseClick += mouseClick;
            pictureBox6.MouseClick += mouseClick;
            pictureBox7.MouseClick += mouseClick;

        }

        int price;
        string name;
        int qty;
        int total;
        private void mouseClick(object sender, MouseEventArgs e)
        {
            var clickpic = (PictureBox)sender;

            if(clickpic ==pictureBox1)
            {
                name = "Popcorn";
                price = 2000;
                qty = int.Parse(Interaction.InputBox("Enter the Qty ?", "Qty", ""));                
            }

            else if (clickpic == pictureBox2)
            {
                name = "Vanilla";
                price = 1500;
                qty = int.Parse(Interaction.InputBox("Enter the Qty ?", "Qty", ""));
            }
            else if (clickpic == pictureBox3)
            {
                name = "Chocolate";
                price = 1500;
                qty = int.Parse(Interaction.InputBox("Enter the Qty ?", "Qty", ""));
            }
            else if (clickpic == pictureBox4)
            {
                name = "Strawberry";
                price = 1500;
                qty = int.Parse(Interaction.InputBox("Enter the Qty ?", "Qty", ""));
            }
            else if (clickpic == pictureBox5)
            {
                name = "Berry Juice";
                price = 3500;
                qty = int.Parse(Interaction.InputBox("Enter the Qty ?", "Qty", ""));
            }
            else if (clickpic == pictureBox6)
            {
                name = "Passion Fruit Juice";
                price = 3500; 
                qty = int.Parse(Interaction.InputBox("Enter the Qty ?", "Qty", ""));
            }
            else if (clickpic == pictureBox7)
            {
                name = "Straw Berry Juice";
                price = 2500;
                qty = int.Parse(Interaction.InputBox("Enter the Qty ?", "Qty", ""));
            }

            total = price * qty;

            this.dataGridView1.Rows.Add(name, price, qty, total.ToString());

            int sum = 0;
            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                sum = sum + Convert.ToInt32(dataGridView1.Rows[row].Cells[3].Value);
            }
            textBox1.Text = sum.ToString();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
