using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        int num1, num2, num3;
        string action;
        public Form1()
        {

            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox.Text += "1";

        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox.Text += "3";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox.Text += "4";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox.Text += "5";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox.Text += "6";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox.Text += "7";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            textBox.Text += "8";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            textBox.Text += "9";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            textBox.Text += "0";
        }

        private void buttonSum_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Contains("+") || textBox.Text.Contains("x") || textBox.Text.Contains("/") || textBox.Text.Contains("-"))
            {
                textBox.Text = Convert.ToString(num1);
            }
            num1 = Convert.ToInt32(textBox.Text);
            textBox.Text += "+";
            action = "+";

        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            char[] rb = textBox.Text.ToCharArray();
            for (int i = 0; i < textBox.Text.ToCharArray().Length; i++)
            {

                if (rb[i].Equals('+') || rb[i].Equals('-') || rb[i].Equals('x') || rb[i].Equals('/'))
                {
                    num2 = Convert.ToInt32(textBox.Text.Substring(i+1));

                }

            }
            
            switch (action)
            {
                case "+":
                    num3 = num1 + num2;
                    textBox.Text = Convert.ToString(num3);
                    break;
                case "-":
                    textBox.Text = Convert.ToString(num1 - num2);
                    break;
                case "x":
                    num3 = num1 * num2;
                    textBox.Text = Convert.ToString(num3);
                    break;
                case "/":
                    num3 = num1 / num2;
                    textBox.Text = Convert.ToString(num3);
                    break;
                default:
                    MessageBox.Show("Hello, world!");
                    break;
            }

        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {

            if (textBox.Text.Contains("+") || textBox.Text.Contains("x") || textBox.Text.Contains("/") || textBox.Text.Contains("-"))
            {
                textBox.Text = Convert.ToString(num1);
            }
            num1 = Convert.ToInt32(textBox.Text);
            textBox.Text += "-";
            action = "-";
        }

        private void buttonZarb_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Contains("+") || textBox.Text.Contains("x") || textBox.Text.Contains("/") || textBox.Text.Contains("-"))
            {
                textBox.Text = Convert.ToString(num1);
                Console.WriteLine("zarb");
            }
            num1 = Convert.ToInt32(textBox.Text);
            textBox.Text += "x";
            action = "x";
        }

        private void buttonDevide_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Contains("+") || textBox.Text.Contains("x") || textBox.Text.Contains("/") || textBox.Text.Contains("-"))
            {
                textBox.Text = Convert.ToString(num1);
            }
            num1 = Convert.ToInt32(textBox.Text);
            textBox.Text += "/";
            action = "/";
        }

        private void buttonMom_Click(object sender, EventArgs e)
        {
            textBox.Text += ".";
        }


    }
}
