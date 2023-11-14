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
    public partial class Form2 : Form
    {
        //экземпляр класса подключения к бд
        ws31Entities conn = new ws31Entities();
        public Form2()
        {
            InitializeComponent();
            dataGridView1.DataSource = conn.ПОЛЬЗОВАТЕЛИ.ToList();

            dataGridView1.Columns[0].Visible = false;
        }
        //переход на 4-ю форму для добавления новых пользователей
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }
        //удалить пользователя+
        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedCells[0].Value.ToString();
            ПОЛЬЗОВАТЕЛИ select = conn.ПОЛЬЗОВАТЕЛИ.Where(c => c.ID.ToString() == id && c.Роль != 1).FirstOrDefault(); //нельзя удалить админа
            if (select != null)
            {
                conn.ПОЛЬЗОВАТЕЛИ.Remove(select);
                conn.SaveChanges();
                dataGridView1.DataSource = conn.ПОЛЬЗОВАТЕЛИ.ToList();
            }
        }
        //поиск по фио+
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.ПОЛЬЗОВАТЕЛИ.Where(c => c.Логин.ToString().Contains(textBox2.Text)).ToList();
        }
        //поиск по логину+
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.ПОЛЬЗОВАТЕЛИ.Where(c => c.ФИО.ToString().Contains(textBox1.Text)).ToList();
        }
        //редактирование+
        private void button1_Click(object sender, EventArgs e)
        {
            conn.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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
