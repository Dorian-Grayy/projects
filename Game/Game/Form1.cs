using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a11 = Convert.ToInt32(textBox1.Text);
            double a12 = Convert.ToInt32(textBox3.Text);
            double a21 = Convert.ToInt32(textBox2.Text);
            double a22 = Convert.ToInt32(textBox4.Text);

            double A1 = (a22 - a21) / (a11 + a22 - (a12 + a21));
            double A2 = (a11 - a12) / (a11 + a22 - (a12+a21));
            double V = (a11 * a22 - a12 * a21) / (a11 + a22 - (a12 + a21));

            double B1 = (V - a12) / (a11 - a12);
            double B2 = (a11 - V) / (a11 - a12);

            textBox5.Text = "(" + A1.ToString() + ";" + A2.ToString() + ")";
            textBox6.Text = "(" + B1.ToString() + ";" + B2.ToString() + ")";
            textBox7.Text = V.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
        }
    }
}
