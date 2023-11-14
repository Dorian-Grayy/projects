using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Kassa
{
    public partial class Form2 : Form
    {
        public static HttpListener list;
        private static readonly HttpClient client = new HttpClient();
        MySqlConnection conn = new MySqlConnection("Data source=localhost;port=3306;UserId=root;database=riteil;Password=123qweR%;");

        public Form2()
        {
            InitializeComponent();
        }

        private void exitOrd_Click(object sender, EventArgs e)
        {
            //проверяем есть чтото в поле поиска
            if (tb_poisk.Text.Any())
            {
                int idorder = Convert.ToInt32(tb_poisk.Text);

                //Get запрос - запускаем задачу
                //var t = Task.Run(() => GetURI(new Uri("http://192.168.0.88/closeorder?id_order=" + idorder)));
                var t = Task.Run(() => GetURI(new Uri("http://192.168.3.131/closeorder?id_order=" + idorder)));

                //Ожидаем завершение задачи
                t.Wait();
            }
                dataGridView1.DataSource = null;
            tb_poisk.Text = null;
            tb_itog.Text = null;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                //проверяем есть чтото в поле поиска
                if (tb_poisk.Text.Any())
                {
                    int idorder = Convert.ToInt32(tb_poisk.Text);

                    //Get запрос - запускаем задачу
                    //var t = Task.Run(() => GetURI(new Uri("http://192.168.0.88/order?id_order=" + idorder)));
                    var t = Task.Run(() => GetURI(new Uri("http://192.168.3.131/order?id_order=" + idorder)));

                    //Ожидаем завершение задачи
                    t.Wait();

                    //t.Result это json(контекст полученный из запроса)
                    //преобразуем его в DataTable

                    var table = JsonConvert.DeserializeObject<DataTable>(t.Result);

                    //выключаем автодобавление столбцев
                    dataGridView1.AutoGenerateColumns = false;

                    dataGridView1.DataSource = table;

                    //сопоставляем столбцы из table и dataGridView1
                    //dataGridView1.Columns["barcode"].DataPropertyName = "barcode";
                    dataGridView1.Columns["name"].DataPropertyName = "name";
                    dataGridView1.Columns["price"].DataPropertyName = "price";
                    dataGridView1.Columns["count"].DataPropertyName = "count";

                    dataGridView1.Invalidate();
                    dataGridView1.ClearSelection();

                    //к оплате
                    double sum = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                    }
                    tb_itog.Text = sum.ToString();
                }
                else MessageBox.Show("Заполните поле для поиска!");
            }
            catch { MessageBox.Show("Проверьте подключение к интернету или к серверу!"); }
            }


        static async Task<string> GetURI(Uri url)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }
            }
            return response;
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

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "HelpK.pdf");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
