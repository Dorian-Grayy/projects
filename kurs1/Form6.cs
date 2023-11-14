using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace WindowsFormsKursach2
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            // Строка подключения
            // Указать свои данные: сервер, база данных, пользователь, пароль
            string connectionString = @"Data Source=WSS\SQLEXPRESS;Database=ws31;User ID=ws31;Password=123qweR%";

            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);

            // Строка запроса
            string select = "SELECT ID_Member, Data FROM Membership";

            try
            {
                // Открываем подключение
                connection.Open();

                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(select, connection);
                // Создаем объект DataTable
                DataTable dt = new DataTable();
                // Заполняем DataTable
                adapter.Fill(dt);

                // Отображаем данные
                //  comboBox1 должен присутствовать на форме
                comboBox1.DataSource = dt;

                // столбец для отображения, помещаем NameDep - название отдела
                comboBox1.DisplayMember = dt.Columns[1].ColumnName;

                // столбец для значения, помещаем ID_Dep - идентификатор отдела
                // это значение будет выбранным значением в списке
                comboBox1.ValueMember = dt.Columns[0].ColumnName;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка подключения");
            }
            finally
            {
                // закрываем подключение
                connection.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Строка подключения
            // Указать свои данные: сервер, база данных, пользователь, пароль
            string connectionString = @"Data Source=WSS\SQLEXPRESS;Database=ws31;User ID=ws31;Password=123qweR%";

            // Запрос на получение данных, изменить на требуемый
            string select = "SELECT * FROM Membership";

            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                // Открываем подключение
                connection.Open();

                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(select, connection);
                // Создаем объект DataTable
                DataTable dt = new DataTable();
                // Заполняем DataTable
                adapter.Fill(dt);
                // Отображаем данные
                // dataGridView1 должен присутствовать на форме
                dataGridView1.DataSource = dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка подключения");
            }
            finally
            {
                // закрываем подключение
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Строка подключения
            // Указать свои данные: сервер, база данных, пользователь, пароль
            string connectionString = @"Data Source=WSS\SQLEXPRESS;Database=ws31;User ID=ws31;Password=123qweR%";

            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);

            // Значения полей
            //  textBox1 и textBox2 должны быть на форме
            string Price = textBox1.Text;
            string Data = textBox2.Text;
            string Period = textBox3.Text;

            // Если, например, поле Man числовое, нужно из конструкции убрать
            // лишние одинарные кавычки (поле не текстовое), записать так:
            string insert = "INSERT INTO Membership (Price, Data, Period) VALUES ('" + Price + "','" + Data + "','" + Period + "')";

            // Если первичный ключ объявлен как автозаполняемый,
            // в конструкции он не нужен - как видите, его нет

            try
            {
                // Открываем подключение
                connection.Open();

                SqlCommand command = new SqlCommand(insert, connection);
                int num = command.ExecuteNonQuery();
                MessageBox.Show("Добавлено " + num + " записей");
            }
            catch
            {
                MessageBox.Show("Ошибка подключения");
            }
            finally
            {
                // закрываем подключение
                connection.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Строка подключения
            // Указать свои данные: сервер, база данных, пользователь, пароль
            string connectionString = @"Data Source=WSS\SQLEXPRESS;Database=ws31;User ID=ws31;Password=123qweR%";

            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);

            // Значение идентификатора берем из comboBox1
            // нужно конвертировать его в целый тип
            long imeb = Convert.ToInt64(comboBox1.SelectedValue);

            // Строка запроса
            // удаляем запись с выбранным идентификатором
            string delete = "DELETE FROM Membership WHERE ID_Member = " + imeb;

            try
            {
                // Открываем подключение
                connection.Open();

                SqlCommand command = new SqlCommand(delete, connection);
                int num = command.ExecuteNonQuery();
                MessageBox.Show("Удалено " + num + " записей");
            }
            catch
            {
                MessageBox.Show("Ошибка подключения");
            }
            finally
            {
                // закрываем подключение
                connection.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this.textBox1.Text);
            f2.Show();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox5.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }
    }
}
