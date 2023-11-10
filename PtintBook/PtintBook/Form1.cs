using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PtintBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    dgw1.Rows[i].Cells[j].Value = "Единая тетрадь";
                    dgw2.Rows[i].Cells[j].Value = "Единая тетрадь";
                }
            }
        }

    private void btncountstr_Click(object sender, EventArgs e)
        {
            string count = tbstr.Text;
            if (count == "")
            {
                MessageBox.Show("Введите количество страниц!");
            }
            else
            {
                double k = Convert.ToInt32(count);
                double s = k / 4;
                lbstr.Text = Math.Ceiling(s).ToString();

                //первый проход
                int nach = 1;
                string strlen = count + "," + nach + ",";
                //MessageBox.Show(strlen);
                int cou = Convert.ToInt32(count);
                //if (cou % 2 == 1) { strlen = strlen.Substring(0, strlen.Length - 2); }
                while (cou >= 1 && nach >=1 && nach != cou && nach < cou-3)
                {
                        cou = cou - 2;
                        nach += 2;
                        strlen = strlen + cou + "," + nach + ",";
                    //MessageBox.Show(strlen);
                }
                if (nach == cou) strlen = strlen.Substring(0, strlen.Length - 2);
                MessageBox.Show(strlen);

                //второй проход
                int nach2 = 2;
                int cou2 = Convert.ToInt32(count);
                int cou22 = cou2 - 1;
                string strlen2 = nach2 + "," + cou22 + ",";
                //MessageBox.Show(strlen2);
                while (cou22 >= 1 && nach2 >= 1 && nach2 != cou22 && nach2 < cou22-3)
                {
                    if (nach2 != cou22)
                    {
                        cou22 -= 2;
                        nach2 += 2;
                        strlen2 = strlen2 + nach2 + "," + cou22 + ",";
                        //MessageBox.Show(strlen2);
                    }
                    else strlen2 = strlen2 + cou22 + ",";
                }
                if (nach2 == cou22) strlen2 = strlen2.Substring(0, strlen2.Length - 2);
                MessageBox.Show(strlen2);

                dgw1.Rows[0].Cells[1].Value = strlen;
                dgw2.Rows[0].Cells[1].Value = strlen2;
            }
        }

        private void dgw1_CellMouseDoubleClick1(object sender, DataGridViewCellMouseEventArgs e)
        {
                if(dgw1.Rows[0].Cells[1].Value != null)
                Clipboard.SetText(dgw1[e.ColumnIndex, e.RowIndex].Value.ToString());
                else MessageBox.Show("Рассчитайте последовательность страниц!"); 
        }

        private void dgw2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgw2.Rows[0].Cells[1].Value != null)
                Clipboard.SetText(dgw2[e.ColumnIndex, e.RowIndex].Value.ToString());
            else MessageBox.Show("Рассчитайте последовательность страниц!");
        }
    }
}
