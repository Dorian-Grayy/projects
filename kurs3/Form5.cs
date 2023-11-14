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
    public partial class Form5 : Form
    {
        //экземпляр класса подключения к бд
        ws31Entities conn = new ws31Entities();
        public Form5()
        {
            InitializeComponent();
        }
        //добавление нового заказа
        private void button3_Click(object sender, EventArgs e)
        {
            ЗАКАЗЫ addz = new ЗАКАЗЫ();
            addz.НАИМЕНОВАНИЕ = textBox1.Text;
            addz.ДАТА_ОФОРМЛЕНИЯ_ЗАКАЗА = textBox2.Text;
            addz.ДАТА_ОТДАЧИ_ЗАКАЗА = textBox3.Text;
            addz.СТОИМОСТЬ__РУБ = Convert.ToInt32(textBox4.Text);
            addz.ПРЕДОПЛАТА__РУБ = Convert.ToInt32(textBox5.Text);
            addz.ФИО = textBox6.Text;
            addz.СЕРИЯ_ПАСПОРТА = textBox7.Text;
            addz.НОМЕР_ПАСПОРТА = textBox8.Text;
            conn.ЗАКАЗЫ.Add(addz);
            conn.SaveChanges();
        }
        //выход
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
