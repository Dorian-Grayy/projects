using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simplex_Method
{
    public partial class Form1 : Form
    {
        int col;
        int row;
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            col = Convert.ToInt32(textBox1.Text);

            row = Convert.ToInt32(textBox2.Text);

            dt.Columns.Add("Базисные");
            for (int i = 1; i < col + row + 1; i++)
            {
                dt.Columns.Add("X" + Convert.ToString(i));
            }
            dt.Columns.Add("Свободные");
            dt.Rows.Add("F");
            for (int i = col + 1; i < col + row + 1; i++)
            {
                dt.Rows.Add("X" + Convert.ToString(i));
            }
            
            dataGridView1.DataSource = dt;

            for (int i = 0; i < row + 1; i++)
            {
                for (int j = 0; j < col + row + 1; j++)
                {
                    if (j > col)
                    {
                        if ((i != 0) & (i == j - col))
                        {
                            dt.Rows[i][j] = "1";
                        }
                        else
                        {
                            dt.Rows[i][j] = "0";
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //нахождение минимума
            double minf;
            double minsv;
            for (int j = 0; j < 1; j++)
            {
                minf = Convert.ToDouble(dataGridView1.Rows[j].Cells[1].Value);
                //MessageBox.Show(minf.ToString());//1 строка и 1 столбец показывает

                for (int i = 1; i < col + 1; i++)
                {
                    if (Convert.ToDouble(dataGridView1.Rows[j].Cells[i].Value) < minf)
                    {
                        //MessageBox.Show(dataGridView1.Rows[i].ToString());
                        minf = Convert.ToDouble(dataGridView1.Rows[j].Cells[i].Value);
                        //dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.Red;
                        //MessageBox.Show(minf.ToString());

                        for (int k = 1; k < dataGridView1.RowCount - 1; k++)
                        {
                            dataGridView1.Rows[k].Cells[i].Style.BackColor = Color.Red;

                            if (Convert.ToDouble(dataGridView1.Rows[k].Cells[i].Value) >= 0)
                            {

                                for (int s = col + row + 1; s < col + row + 2; s++)
                                {
                                    minsv = Convert.ToDouble(dataGridView1.Rows[k].Cells[s].Value) / Convert.ToDouble(dataGridView1.Rows[k].Cells[i].Value);
                                    MessageBox.Show(Convert.ToDouble(dataGridView1.Rows[k].Cells[s].Value).ToString());
                                    MessageBox.Show(Convert.ToDouble(dataGridView1.Rows[k].Cells[i].Value).ToString());
                                    MessageBox.Show(minsv.ToString());
                                    for (int n = 1; n < dataGridView1.RowCount - 1; n++)
                                    {
                                        if (Convert.ToDouble(dataGridView1.Rows[k].Cells[i].Value) >= 0 && Convert.ToDouble(dataGridView1.Rows[n].Cells[s].Value) / Convert.ToDouble(dataGridView1.Rows[n].Cells[i].Value) < minsv)
                                        {
                                            minsv = Convert.ToDouble(dataGridView1.Rows[n].Cells[s].Value) / Convert.ToDouble(dataGridView1.Rows[n].Cells[i].Value);
                                            dataGridView1.Rows[n].Cells[i].Style.BackColor = Color.Green;
                                            //for (int m = 1; m < col + row + 2; m++)
                                            //{
                                            //    dataGridView1.Rows[n].Cells[m].Style.BackColor = Color.Green;
                                            //}
                                            tbminsv.Text = minsv.ToString();
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                tbmin.Text = minf.ToString(); //1 столбец не красится и не вычисляется
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dt.Clear();
            textBox1.Text = null;
            textBox2.Text = null;
            tbmin.Text = null;
            tbminsv.Text = null;
        }

        private void tbminsv_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
