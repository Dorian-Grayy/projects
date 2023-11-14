using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsKursach2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "daria" && textBox2.Text == "123")
            {
                Form2 f2 = new Form2(this.textBox1.Text);
                f2.Show();
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                label3.Text = "Введен неверный логин или пароль";
                textBox1.Text = null;
                textBox2.Text = null;
            }
        }
    }
}
