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
    public partial class Form6 : Form
    {
        ws31Entities conn = new ws31Entities();
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            МАТЕРИАЛЫ addmat = new МАТЕРИАЛЫ();
            addmat.НАИМЕНОВАНИЕ = fiotb.Text;
            addmat.ЦЕНА_ЗА_ГРАММ = logtb.Text;
            addmat.ОСТАТОК__ГР = Convert.ToDouble(pastb.Text);
            conn.МАТЕРИАЛЫ.Add(addmat);
            conn.SaveChanges();
        }
    }
}
