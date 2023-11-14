using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Label[] lab = new Label[9];
        PictureBox[] pic = new PictureBox[7];
        int[,] arr;
        TextBox[,] tb_Step1 = new TextBox[10, 10];
        int number_of_rows = 7;
        int number_of_columns = 7;
        public Form1()
        {
            InitializeComponent();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tb_Step1[1, 1] = textBox15;
            tb_Step1[1, 2] = textBox16;
            tb_Step1[1, 3] = textBox17;
            tb_Step1[1, 4] = textBox18;
            tb_Step1[1, 5] = textBox37;
            tb_Step1[1, 6] = textBox44;

            tb_Step1[2, 1] = textBox4;
            tb_Step1[2, 2] = textBox7;
            tb_Step1[2, 3] = textBox10;
            tb_Step1[2, 4] = textBox13;
            tb_Step1[2, 5] = textBox39;
            tb_Step1[2, 6] = textBox46;

            tb_Step1[3, 1] = textBox5;
            tb_Step1[3, 2] = textBox8;
            tb_Step1[3, 3] = textBox11;
            tb_Step1[3, 4] = textBox14;
            tb_Step1[3, 5] = textBox38;
            tb_Step1[3, 6] = textBox45;

            tb_Step1[4, 1] = textBox22;
            tb_Step1[4, 2] = textBox21;
            tb_Step1[4, 3] = textBox20;
            tb_Step1[4, 4] = textBox19;
            tb_Step1[4, 5] = textBox36;
            tb_Step1[4, 6] = textBox43;

            tb_Step1[5, 1] = textBox27;
            tb_Step1[5, 2] = textBox26;
            tb_Step1[5, 3] = textBox25;
            tb_Step1[5, 4] = textBox24;
            tb_Step1[5, 5] = textBox35;
            tb_Step1[5, 6] = textBox42;

            tb_Step1[6, 1] = textBox32;
            tb_Step1[6, 2] = textBox31;
            tb_Step1[6, 3] = textBox30;
            tb_Step1[6, 4] = textBox29;
            tb_Step1[6, 5] = textBox34;
            tb_Step1[6, 6] = textBox41;

            arr = new int[number_of_rows, number_of_columns];

            arr[1, 1] = Convert.ToInt32(textBox15.Text);
            arr[1, 2] = Convert.ToInt32(textBox16.Text);
            arr[1, 3] = Convert.ToInt32(textBox17.Text);
            arr[1, 4] = Convert.ToInt32(textBox18.Text);
            arr[1, 5] = Convert.ToInt32(textBox37.Text);
            arr[1, 6] = Convert.ToInt32(textBox44.Text);

            arr[2, 1] = Convert.ToInt32(textBox4.Text);
            arr[2, 2] = Convert.ToInt32(textBox7.Text);
            arr[2, 3] = Convert.ToInt32(textBox10.Text);
            arr[2, 4] = Convert.ToInt32(textBox13.Text);
            arr[2, 5] = Convert.ToInt32(textBox39.Text);
            arr[2, 6] = Convert.ToInt32(textBox46.Text);

            arr[3, 1] = Convert.ToInt32(textBox5.Text);
            arr[3, 2] = Convert.ToInt32(textBox8.Text);
            arr[3, 3] = Convert.ToInt32(textBox11.Text);
            arr[3, 4] = Convert.ToInt32(textBox14.Text);
            arr[3, 5] = Convert.ToInt32(textBox38.Text);
            arr[3, 6] = Convert.ToInt32(textBox45.Text);

            arr[4, 1] = Convert.ToInt32(textBox22.Text);
            arr[4, 2] = Convert.ToInt32(textBox21.Text);
            arr[4, 3] = Convert.ToInt32(textBox20.Text);
            arr[4, 4] = Convert.ToInt32(textBox19.Text);
            arr[4, 5] = Convert.ToInt32(textBox36.Text);
            arr[4, 6] = Convert.ToInt32(textBox43.Text);

            arr[5, 1] = Convert.ToInt32(textBox27.Text);
            arr[5, 2] = Convert.ToInt32(textBox26.Text);
            arr[5, 3] = Convert.ToInt32(textBox25.Text);
            arr[5, 4] = Convert.ToInt32(textBox24.Text);
            arr[5, 5] = Convert.ToInt32(textBox35.Text);
            arr[5, 6] = Convert.ToInt32(textBox42.Text);

            arr[6, 1] = Convert.ToInt32(textBox32.Text);
            arr[6, 2] = Convert.ToInt32(textBox31.Text);
            arr[6, 3] = Convert.ToInt32(textBox30.Text);
            arr[6, 4] = Convert.ToInt32(textBox29.Text);
            arr[6, 5] = Convert.ToInt32(textBox34.Text);
            arr[6, 6] = Convert.ToInt32(textBox41.Text);

            lab[1] = label1;
            lab[2] = label2;
            lab[3] = label3;
            lab[4] = label4;
            lab[5] = label5;
            lab[6] = label6;
            lab[7] = label7;
            lab[8] = label8;

            pic[1] = pictureBox1;
            pic[2] = pictureBox2;
            pic[3] = pictureBox3;
            pic[4] = pictureBox4;
            pic[5] = pictureBox5;
            pic[6] = pictureBox6;

            for (int k = 1; k <= 8; k++)
            {
                for (int i = 1; i <= 6; i++)
                {
                    for (int j = 1; j <= 6; j++)
                    {
                        //MessageBox.Show(i.ToString());
                        //MessageBox.Show(j.ToString());
                        //MessageBox.Show(arr[i,j].ToString());
                        if (arr[i, j] != 0)
                        {
                            //MessageBox.Show(arr[i,j].ToString());
                            lab[k].Text = arr[i, j].ToString();
                            k++;
                        } 
                    }
                }
            }
            
            for (int i = 1; i <= 6; i++)
            {
                Font drawFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                pic[i].Image = new Bitmap(pic[i].Width, pic[i].Height);
                Graphics graphics = Graphics.FromImage(pic[i].Image);
                graphics.FillRectangle(Brushes.White, pic[i].ClientRectangle);
                graphics.DrawEllipse(Pens.Black, 5, 5, 45, 40);
                graphics.DrawString(i.ToString(), drawFont, drawBrush, 37, 13, drawFormat);
                graphics.Dispose();
            }
            Point p1 = new Point();
            Point p2 = new Point();
            p1.Y = pictureBox1.Location.Y + pictureBox1.Size.Height - 50;
            p1.X = pictureBox1.Location.X + pictureBox1.Size.Width / 2;
            p2.Y = pictureBox2.Location.Y + pictureBox2.Size.Height / 2;
            p2.X = pictureBox2.Location.X + pictureBox2.Size.Width - 57;
            Graphics gr = CreateGraphics();
            Pen pen = new Pen(Color.Black);
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            gr.DrawLine(pen, p1, p2);

            Point p3 = new Point();
            Point p4 = new Point();
            p3.Y = pictureBox2.Location.Y + pictureBox2.Size.Height / 2;
            p3.X = pictureBox2.Location.X + pictureBox2.Size.Width;
            p4.Y = pictureBox4.Location.Y + pictureBox4.Size.Height / 2;
            p4.X = pictureBox4.Location.X + pictureBox4.Size.Width - 57;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            gr.DrawLine(pen, p3, p4);

            Point p5 = new Point();
            Point p6 = new Point();
            p5.Y = pictureBox5.Location.Y + pictureBox5.Size.Height / 2;
            p5.X = pictureBox5.Location.X + pictureBox5.Size.Width;
            p6.Y = pictureBox6.Location.Y + pictureBox6.Size.Height - 15;
            p6.X = pictureBox6.Location.X + pictureBox6.Size.Width - 57;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            gr.DrawLine(pen, p5, p6);

            Point p7 = new Point();
            Point p8 = new Point();
            p7.Y = pictureBox4.Location.Y + pictureBox4.Size.Height / 2;
            p7.X = pictureBox4.Location.X + pictureBox4.Size.Width;
            p8.Y = pictureBox6.Location.Y + pictureBox6.Size.Height - 50;
            p8.X = pictureBox6.Location.X + pictureBox6.Size.Width / 2;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            gr.DrawLine(pen, p7, p8);

            p1.Y = pictureBox1.Location.Y + pictureBox1.Size.Height / 2;
            p1.X = pictureBox1.Location.X + pictureBox1.Size.Width;
            p4.Y = pictureBox4.Location.Y + pictureBox4.Size.Height;
            p4.X = pictureBox4.Location.X + pictureBox4.Size.Width / 2;
            gr.DrawLine(pen, p1, p4);

            p1.Y = pictureBox1.Location.Y + pictureBox1.Size.Height;
            p1.X = pictureBox1.Location.X + pictureBox1.Size.Width / 2;
            p5.Y = pictureBox5.Location.Y + pictureBox5.Size.Height / 2;
            p5.X = pictureBox5.Location.X + pictureBox5.Size.Width - 57;
            gr.DrawLine(pen, p1, p5);

            p2.Y = pictureBox2.Location.Y + pictureBox2.Size.Height;
            p2.X = pictureBox2.Location.X + pictureBox2.Size.Width / 2;
            p3.Y = pictureBox3.Location.Y + pictureBox3.Size.Height - 50;
            p3.X = pictureBox3.Location.X + pictureBox3.Size.Width / 2;
            gr.DrawLine(pen, p2, p3);

            p3.Y = pictureBox3.Location.Y + pictureBox3.Size.Height - 50;
            p3.X = pictureBox3.Location.X + pictureBox3.Size.Width - 20;
            p6.Y = pictureBox6.Location.Y + pictureBox6.Size.Height / 2;
            p6.X = pictureBox6.Location.X + pictureBox6.Size.Width - 57;
            gr.DrawLine(pen, p3, p6);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tb_Step1[1, 1].Clear();
            tb_Step1[1, 2].Clear();
            tb_Step1[1, 3].Clear();
            tb_Step1[1, 4].Clear();
            tb_Step1[1, 5].Clear();
            tb_Step1[1, 6].Clear();

            tb_Step1[2, 1].Clear();
            tb_Step1[2, 2].Clear();
            tb_Step1[2, 3].Clear();
            tb_Step1[2, 4].Clear();
            tb_Step1[2, 5].Clear();
            tb_Step1[2, 6].Clear();

            tb_Step1[3, 1].Clear();
            tb_Step1[3, 2].Clear();
            tb_Step1[3, 3].Clear();
            tb_Step1[3, 4].Clear();
            tb_Step1[3, 5].Clear();
            tb_Step1[3, 6].Clear();

            tb_Step1[4, 1].Clear();
            tb_Step1[4, 2].Clear();
            tb_Step1[4, 3].Clear();
            tb_Step1[4, 4].Clear();
            tb_Step1[4, 5].Clear();
            tb_Step1[4, 6].Clear();

            tb_Step1[5, 1].Clear();
            tb_Step1[5, 2].Clear();
            tb_Step1[5, 3].Clear();
            tb_Step1[5, 4].Clear();
            tb_Step1[5, 5].Clear();
            tb_Step1[5, 6].Clear();

            tb_Step1[6, 1].Clear();
            tb_Step1[6, 2].Clear();
            tb_Step1[6, 3].Clear();
            tb_Step1[6, 4].Clear();
            tb_Step1[6, 5].Clear();
            tb_Step1[6, 6].Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tb_Step1[1, 1] = textBox15;
            tb_Step1[1, 2] = textBox16;
            tb_Step1[1, 3] = textBox17;
            tb_Step1[1, 4] = textBox18;
            tb_Step1[1, 5] = textBox37;
            tb_Step1[1, 6] = textBox44;

            tb_Step1[2, 1] = textBox4;
            tb_Step1[2, 2] = textBox7;
            tb_Step1[2, 3] = textBox10;
            tb_Step1[2, 4] = textBox13;
            tb_Step1[2, 5] = textBox39;
            tb_Step1[2, 6] = textBox46;

            tb_Step1[3, 1] = textBox5;
            tb_Step1[3, 2] = textBox8;
            tb_Step1[3, 3] = textBox11;
            tb_Step1[3, 4] = textBox14;
            tb_Step1[3, 5] = textBox38;
            tb_Step1[3, 6] = textBox45;

            tb_Step1[4, 1] = textBox22;
            tb_Step1[4, 2] = textBox21;
            tb_Step1[4, 3] = textBox20;
            tb_Step1[4, 4] = textBox19;
            tb_Step1[4, 5] = textBox36;
            tb_Step1[4, 6] = textBox43;

            tb_Step1[5, 1] = textBox27;
            tb_Step1[5, 2] = textBox26;
            tb_Step1[5, 3] = textBox25;
            tb_Step1[5, 4] = textBox24;
            tb_Step1[5, 5] = textBox35;
            tb_Step1[5, 6] = textBox42;

            tb_Step1[6, 1] = textBox32;
            tb_Step1[6, 2] = textBox31;
            tb_Step1[6, 3] = textBox30;
            tb_Step1[6, 4] = textBox29;
            tb_Step1[6, 5] = textBox34;
            tb_Step1[6, 6] = textBox41;

            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    if (tb_Step1[i,j].Text != null)
                    {
                        //MessageBox.Show(tb_Step1[i, j].Text.ToString());
                        tb_Step1[i, j].Text = "0";
                    }
                }
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Point p1 = new Point();
            //Point p2 = new Point();
            //p1.Y = pictureBox1.Location.Y + pictureBox1.Size.Height-50;
            //p1.X = pictureBox1.Location.X + pictureBox1.Size.Width/2;
            //p2.Y = pictureBox2.Location.Y + pictureBox2.Size.Height/2;
            //p2.X = pictureBox2.Location.X + pictureBox2.Size.Width-57;
            //Graphics gr = CreateGraphics();
            //Pen pen = new Pen(Color.Black);
            //pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            //gr.DrawLine(pen, p1, p2);

            //Point p3 = new Point();
            //Point p4 = new Point();
            //p3.Y = pictureBox2.Location.Y + pictureBox2.Size.Height/2;
            //p3.X = pictureBox2.Location.X + pictureBox2.Size.Width;
            //p4.Y = pictureBox4.Location.Y + pictureBox4.Size.Height/2;
            //p4.X = pictureBox4.Location.X + pictureBox4.Size.Width-57;
            //pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            //gr.DrawLine(pen, p3, p4);

            //Point p5 = new Point();
            //Point p6 = new Point();
            //p5.Y = pictureBox5.Location.Y + pictureBox5.Size.Height / 2;
            //p5.X = pictureBox5.Location.X + pictureBox5.Size.Width;
            //p6.Y = pictureBox6.Location.Y + pictureBox6.Size.Height-15;
            //p6.X = pictureBox6.Location.X + pictureBox6.Size.Width - 57;
            //pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            //gr.DrawLine(pen, p5, p6);

            //Point p7 = new Point();
            //Point p8 = new Point();
            //p7.Y = pictureBox4.Location.Y + pictureBox4.Size.Height / 2;
            //p7.X = pictureBox4.Location.X + pictureBox4.Size.Width;
            //p8.Y = pictureBox6.Location.Y + pictureBox6.Size.Height-50;
            //p8.X = pictureBox6.Location.X + pictureBox6.Size.Width/2;
            //pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            //gr.DrawLine(pen, p7, p8);

            //p1.Y = pictureBox1.Location.Y + pictureBox1.Size.Height/2;
            //p1.X = pictureBox1.Location.X + pictureBox1.Size.Width;
            //p4.Y = pictureBox4.Location.Y + pictureBox4.Size.Height;
            //p4.X = pictureBox4.Location.X + pictureBox4.Size.Width/2;
            //gr.DrawLine(pen, p1, p4);

            //p1.Y = pictureBox1.Location.Y + pictureBox1.Size.Height;
            //p1.X = pictureBox1.Location.X + pictureBox1.Size.Width/2;
            //p5.Y = pictureBox5.Location.Y + pictureBox5.Size.Height/2;
            //p5.X = pictureBox5.Location.X + pictureBox5.Size.Width-57;
            //gr.DrawLine(pen, p1, p5);

            //p2.Y = pictureBox2.Location.Y + pictureBox2.Size.Height;
            //p2.X = pictureBox2.Location.X + pictureBox2.Size.Width / 2;
            //p3.Y = pictureBox3.Location.Y + pictureBox3.Size.Height-50;
            //p3.X = pictureBox3.Location.X + pictureBox3.Size.Width/2;
            //gr.DrawLine(pen, p2, p3);

            //p3.Y = pictureBox3.Location.Y + pictureBox3.Size.Height - 50;
            //p3.X = pictureBox3.Location.X + pictureBox3.Size.Width-20;
            //p6.Y = pictureBox6.Location.Y + pictureBox6.Size.Height / 2;
            //p6.X = pictureBox6.Location.X + pictureBox6.Size.Width - 57;
            //gr.DrawLine(pen, p3, p6);
        }
    }
}
