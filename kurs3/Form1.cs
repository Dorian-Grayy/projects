using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach01
{
    public partial class Form1 : Form
    {
        //экземпляр класса подключения к бд
        ws31Entities conn = new ws31Entities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //проверка входа с данными из бд+
            if(logtb.Text != "" && pastb.Text != "")
            {
                ПОЛЬЗОВАТЕЛИ select = conn.ПОЛЬЗОВАТЕЛИ.Where(c => c.Логин == logtb.Text && c.Пароль == pastb.Text).FirstOrDefault();
                if(select!=null)
                {
                    if (select.Роль == 1)
                    {
                        Form2 f2 = new Form2();
                        f2.Show();
                    }
                    else
                    if (select.Роль == 0)
                    {
                        Form3 f3 = new Form3();
                        f3.Show();
                    }
                }
                else MessageBox.Show("Неверный логин или пароль!");
            }
            else MessageBox.Show("Заполните поля!");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //отображение и скрытие пароля+
            if (checkBox1.Checked)
            {
                pastb.UseSystemPasswordChar = true;
            }

            if (checkBox1.Checked == false)
            {
                pastb.UseSystemPasswordChar = false;
            }
        }
        //вопрос закрытия формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string message = "Вы действительно хотите выйти?";
            const string caption = "Закрытие формы";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
