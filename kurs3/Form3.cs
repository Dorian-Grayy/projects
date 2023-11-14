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
    public partial class Form3 : Form
    {
        //экземпляр класса подключения к бд
        ws31Entities conn = new ws31Entities();
        public Form3()
        {
            InitializeComponent();
            //отображеие таблиц
            dataGridView1.DataSource = conn.РЕМОНТ.ToList();
            dataGridView2.DataSource = conn.ИЗГОТОВЛЕНИЕ.ToList();
            dataGridView4.DataSource = conn.ЗАКАЗЫ.ToList();
            dataGridView3.DataSource = conn.МАТЕРИАЛЫ.ToList();

            dataGridView1.Columns[0].Visible = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView3.Columns[0].Visible = false;
            dataGridView4.Columns[0].Visible = false;
            dataGridView3.Columns[4].Visible = false;
            dataGridView4.Columns[9].Visible = false;
        }

        //добавление заказов
        private void button4_Click(object sender, EventArgs e)
        {
            //переход на 5-ю форму
            Form5 f5 = new Form5();
            f5.Show();
        }

        //поиск в таблицах ремонт и изготовление+
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.РЕМОНТ.Where(c => c.НАИМЕНОВАНИЕ_РАБОТ.ToString().Contains(textBox2.Text)).ToList();
            dataGridView2.DataSource = conn.ИЗГОТОВЛЕНИЕ.Where(c => c.НАИМЕНОВАНИЕ_РАБОТ.ToString().Contains(textBox2.Text)).ToList();
        }
        //поиск по фио в заказе
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            dataGridView4.DataSource = conn.ЗАКАЗЫ.Where(c => c.ФИО.Contains(textBox5.Text)).ToList();
        }
        //поиск по наименванию в заказе
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataGridView4.DataSource = conn.ЗАКАЗЫ.Where(c => c.НАИМЕНОВАНИЕ.Contains(textBox4.Text)).ToList();
        }
        //закрыть форму
        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //переход на 6-ю форму
            Form6 f6 = new Form6();
            f6.Show();
        }
        //добавить в заказ изготовление
        private void button3_Click_1(object sender, EventArgs e)
        {
            string id = dataGridView2.SelectedCells[0].Value.ToString();
            ИЗГОТОВЛЕНИЕ select = conn.ИЗГОТОВЛЕНИЕ.Where(c => c.ID.ToString() == id).FirstOrDefault();
            ЗАКАЗЫ addz = new ЗАКАЗЫ();
            addz.НАИМЕНОВАНИЕ = select.НАИМЕНОВАНИЕ_РАБОТ;
            conn.ЗАКАЗЫ.Add(addz);
            conn.SaveChanges();
            dataGridView4.DataSource = conn.ЗАКАЗЫ.ToList();
        }
        //поиск по дате в заказе
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView4.DataSource = conn.ЗАКАЗЫ.Where(c => c.ДАТА_ОФОРМЛЕНИЯ_ЗАКАЗА.Contains(textBox1.Text)).ToList();
        }
        //удалить заказ
        private void button5_Click(object sender, EventArgs e)
        {
                string id = dataGridView4.SelectedCells[0].Value.ToString();
                ЗАКАЗЫ select = conn.ЗАКАЗЫ.Where(c => c.ID.ToString() == id).FirstOrDefault();
                if (select != null)
                {
                    conn.ЗАКАЗЫ.Remove(select);
                    conn.SaveChanges();
                    dataGridView4.DataSource = conn.ЗАКАЗЫ.ToList();
                }
        }
        //сохранить редактирование+
        private void button6_Click(object sender, EventArgs e)
        {
            conn.SaveChanges();
            dataGridView4.DataSource = conn.ЗАКАЗЫ.ToList();
        }
        //поиск материалов
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridView3.DataSource = conn.МАТЕРИАЛЫ.Where(c=>c.НАИМЕНОВАНИЕ.Contains(textBox3.Text)).ToList();
        }
        //сохранить материал
        private void button7_Click(object sender, EventArgs e)
        {
            conn.SaveChanges();
            dataGridView3.DataSource = conn.МАТЕРИАЛЫ.ToList();

        }
        //добавить в заказ ремонт
        private void button8_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedCells[0].Value.ToString();
            РЕМОНТ select = conn.РЕМОНТ.Where(c => c.ID.ToString() == id).FirstOrDefault();
            ЗАКАЗЫ addz = new ЗАКАЗЫ();
            addz.НАИМЕНОВАНИЕ = select.НАИМЕНОВАНИЕ_РАБОТ;
            addz.СТОИМОСТЬ__РУБ = Convert.ToInt32(select.ЦЕНА__РУБ__ЗОЛОТО_СЕРЕБРО_);
            conn.ЗАКАЗЫ.Add(addz);
            conn.SaveChanges();
            dataGridView4.DataSource = conn.ЗАКАЗЫ.ToList();
        }
        //удалить материалы
        private void button9_Click(object sender, EventArgs e)
        {
            string id = dataGridView3.SelectedCells[0].Value.ToString();
            МАТЕРИАЛЫ select = conn.МАТЕРИАЛЫ.Where(c => c.ID.ToString() == id).FirstOrDefault();
            if (select != null)
            {
                conn.МАТЕРИАЛЫ.Remove(select);
                conn.SaveChanges();
                dataGridView3.DataSource = conn.МАТЕРИАЛЫ.ToList();
            }
        }
        //считать остатки
        private void button10_Click(object sender, EventArgs e)
        {
            string id = dataGridView3.SelectedCells[0].Value.ToString();
            МАТЕРИАЛЫ select = conn.МАТЕРИАЛЫ.Where(c => c.ID.ToString() == id).FirstOrDefault();
            if (textBox6.Text != "")
            {
                if (select != null)
                {
                    double ost = Convert.ToDouble(select.ОСТАТОК__ГР);
                    double isp = Convert.ToDouble(textBox6.Text);
                    double itogo = ost - isp;
                    double min = isp - ost;
                    if (ost > isp) 
                    {
                        select.ОСТАТОК__ГР = itogo;
                        conn.SaveChanges();
                        dataGridView3.DataSource = conn.МАТЕРИАЛЫ.ToList();
                    }
                    else MessageBox.Show("Не хватает материалов: " + min.ToString() + "гр");
                }
            } 
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
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
