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
    public partial class Form4 : Form
    {
        //экземпляр класса подключения к бд
        ws31Entities conn = new ws31Entities();

        public Form4()
        {
            InitializeComponent();
        }
        //добавление новых пользователей
        private void button3_Click(object sender, EventArgs e)
        {
            ПОЛЬЗОВАТЕЛИ adduser = new ПОЛЬЗОВАТЕЛИ();
            adduser.ФИО = fiotb.Text;
            adduser.Логин = logtb.Text;
            adduser.Пароль = pastb.Text;
            adduser.Роль = Convert.ToInt32(roltb.Text);
            conn.ПОЛЬЗОВАТЕЛИ.Add(adduser);
            conn.SaveChanges();
        }
        //выход
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
