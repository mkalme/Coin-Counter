using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coin_Counter
{
    public partial class Form1 : Form
    {
        public static Double[] arrayCents = { 1, 2, 5, 10, 20, 50, 100, 200};
        public static Double[] arrayWeight = {2.3, 3.06, 3.92, 4.1, 5.74, 7.8, 7.5, 8.5};
        public static String[] arrayAmount = new String[11];
        public static Double sum = 0.0;

        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            TextBox[] arrayTextBox = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8};
            for (int i = 0; i < arrayTextBox.Length; i++) {
                String temp = arrayTextBox[i].Text.Replace('.', ',');
                arrayAmount[i] = (((string.IsNullOrEmpty(temp.Trim()) ? 0.0 : Double.Parse(temp)) / arrayWeight[i] * arrayCents[i]) / 100).ToString();
            }

            arrayAmount[8] = string.IsNullOrEmpty(textBox9.Text.Trim()) ? "0,0" : textBox9.Text.Replace('.', ',');
            arrayAmount[9] = string.IsNullOrEmpty(textBox10.Text.Trim()) ? "0,0" : textBox10.Text.Replace('.', ',');
            arrayAmount[10] = string.IsNullOrEmpty(textBox11.Text.Trim()) ? "0,0" : textBox11.Text.Replace('.', ',');

            sum = 0.0;

            for (int i = 0; i < arrayAmount.Length; i++) {
                sum += Double.Parse(arrayAmount[i]);
            }

            textBox12.Text = (Math.Floor(sum * 100) / 100).ToString() + " EUR";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TextBox[] arrayTextBox = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12};
            for (int i = 0; i < arrayTextBox.Length; i++)
            {
                arrayTextBox[i].Text = "";
            }
        }
    }
}
