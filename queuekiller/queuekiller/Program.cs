using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Text;
using System.Web;

namespace queuekiller
{
    class queuekiller
    {
        public static bool runServer = true;

        public static HttpListener list;
        public static string conns;

        public static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            //Коннект к MySQL
            conns = "Server=localhost; database=riteil; UID=root; password=123qweR%; charset=utf8";

            // Создание прослушивания страниц
            list = new HttpListener();
            //list.Prefixes.Add("http://localhost/");
            //list.Prefixes.Add("http://192.168.0.88/");
            list.Prefixes.Add("http://192.168.3.131/");
            list.Start();

            //ЗАДАНИЯ
            Task InTask = TaskIn();

            Console.WriteLine("Сервер запущен!");

            //Ожидаем завершение Заданий 
            InTask.GetAwaiter().GetResult();

            //Закрываем прослушивание страниц
            list.Close();

            Console.WriteLine("Сервер остановлен!");
            Console.ReadKey();
        }

        public static async Task TaskIn()
        {
            byte[] buffer;
            while (runServer)
            {
                HttpListenerContext ctx = await list.GetContextAsync();
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;
                try
                {
                    string patch = req.Url.AbsolutePath;
                    System.IO.Stream output;
                    string sqltext;
                    if (req.HttpMethod == "GET")
                    {
                        Console.WriteLine("GET :: " + req.Url.AbsoluteUri);
                        switch (patch)
                        {
                            case "/inven":
                                string barcode = HttpUtility.ParseQueryString(req.Url.Query).Get("barcode");
                                //проверяем штрихкод
                                if (barcode.Any())
                                {
                                    string id = "";
                                    string name = "";
                                    string price = "";
                                    string count = "";
                                    //string price_sale = "";

                                    //коннект к базе
                                    using (MySqlConnection c = new MySqlConnection(conns))
                                    {
                                        c.Open();

                                        //запрос информации о товаре
                                        sqltext = "SELECT id_invent, Name, Price, Count " +
                                                        "FROM riteil.invent " +
                                                        "where Barcode = " + barcode;

                                        var cmd = new MySqlCommand(sqltext, c);

                                        var reader = cmd.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            id = reader.GetString(0);
                                            name = reader.GetString(1);
                                            price = reader.GetString(2).Replace(",",".");
                                            count = reader.GetString(3);
                                        }

                                        c.Close();
                                    }
                                    //собираем json
                                    string json = $"{{\"id\":\"{id}\"," +
                                                    $"\"name\":\"{name}\"," +
                                                    $"\"price\":\"{price}\"," +
                                                    $"\"count\":\"{count}\"}}";

                                    //добавляем его в ответ
                                    buffer = System.Text.Encoding.UTF8.GetBytes(json); ;
                                    resp.ContentType = "application/json";
                                    resp.ContentLength64 = buffer.Length;
                                    output = resp.OutputStream;
                                    output.Write(buffer, 0, buffer.Length);
                                    output.Close();

                                    resp.StatusCode = 200;
                                }

                                break;
                            case "/order":
                                //вернуть заказ по идентификатору
                                string order = HttpUtility.ParseQueryString(req.Url.Query).Get("id_order");
                                //проверяем заказ
                                if (order.Any())
                                {
                                    string json = "";
                                    //коннект к базе 
                                    using (MySqlConnection c = new MySqlConnection(conns))
                                    {
                                        c.Open();

                                        //запрос информации о товаре
                                        sqltext = "SELECT Name,Count,Price " +
                                                    "FROM riteil.orderdetail " +
                                                    "where id_order = " + order;

                                        var cmd = new MySqlCommand(sqltext, c);

                                        var reader = cmd.ExecuteReader();

                                        //ответ преобразуем в DataTable
                                        var dataTable = new DataTable();
                                        dataTable.Load(reader);

                                        //таблицу сериализуем в json
                                        json = JsonConvert.SerializeObject(dataTable);

                                        c.Close();
                                    }

                                    buffer = System.Text.Encoding.UTF8.GetBytes(json); ;
                                    resp.ContentType = "application/json";
                                    resp.ContentLength64 = buffer.Length;
                                    output = resp.OutputStream;
                                    output.Write(buffer, 0, buffer.Length);
                                    output.Close();

                                    resp.StatusCode = 200;
                                }

                                break;
                            case "/closeorder":
                                string corder = HttpUtility.ParseQueryString(req.Url.Query).Get("id_order");
                                if (corder.Any())
                                {
                                    //делаем запись в таблицу order
                                    sqltext = "UPDATE riteil.order " +
                                              "SET status = 'закрыт' " +
                                              "WHERE id_order = " + corder;
                                    sqlquery(sqltext);

                                    resp.StatusCode = 204;
                                }
                                break;
                            default:
                                resp.StatusCode = 404;
                                break;

                        }
                    }
                    else if (req.HttpMethod == "POST")
                    {
                        Console.WriteLine("POST :: " + req.Url.AbsoluteUri);
                        //разбираем json
                        System.IO.Stream body = req.InputStream;

                        //!!! если проблемы с кририлицей, выбрать кодировку
                        //System.Text.Encoding encoding = req.ContentEncoding;
                        System.Text.Encoding encoding = Encoding.UTF8;


                        System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
                        string sbody = reader.ReadToEnd();
                        body.Close();
                        reader.Close();

                        //разбираем json
                        switch (patch)
                        {
                            case "/order":
                                if (sbody.Any())
                                {
                                    //разбираем заказ
                                    List<JsonOrder> Order = JsonConvert.DeserializeObject<List<JsonOrder>>(sbody);

                                    //получаем последний номер заказа
                                    sqltext = "select ifnull(max(id_order),0) " +
                                                    "from riteil.order";
                                    //прибавляем 1
                                    int order = Int16.Parse(sqlquery(sqltext)) + 1;
                                                                                                    
                                    //делаем запись в таблицу order
                                    sqltext = $"INSERT INTO riteil.order(id_order,date,status) VALUES({order},now(),'новый')";
                                    sqlquery(sqltext);

                                    //делаем запись в базу каждой строки заказа в таблицу orderdetail
                                    foreach (JsonOrder detail in Order)
                                    {
                                        //алтернативный вариант сделать инсерт, с использованием параметризации
                                        //insert_order_detail(order,detail.barcode,detail.name,detail.price,detail.quantity);

                                        sqltext = "INSERT INTO riteil.orderdetail(id_order,Name,Price,Count) " +
                                                 $"VALUES({order},N'{detail.name}',{detail.price},{detail.count})";
                                        sqlquery(sqltext);
                                    }

                                    //отвечаем, выдаем номер заказа и QR
                                    string json = $"{{\"id_order\":\"{order}\"}}";

                                    buffer = System.Text.Encoding.UTF8.GetBytes(json); ;
                                    resp.ContentType = "application/json";
                                    resp.ContentLength64 = buffer.Length;
                                    output = resp.OutputStream;
                                    output.Write(buffer, 0, buffer.Length);
                                    output.Close();

                                    resp.StatusCode = 200;
                                }
                                break;
                            default:
                                resp.StatusCode = 404;
                                break;
                        }

                    }

                    resp.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    resp.StatusCode = 400;

                    buffer = System.Text.Encoding.UTF8.GetBytes("{\"error\":\"Неудалось принять сообщение: " + ex.Message + " \"}");
                    resp.ContentType = "application/json";
                    resp.ContentLength64 = buffer.Length;
                    System.IO.Stream output = resp.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();

                    resp.Close();
                }
            }
        }

        public class JsonOrder
        {
            //public Int32 barcode { get; set; }
            public string name { get; set; }
            public string price { get; set; }
            public Int32 count { get; set; }
        }

        public static string sqlquery(string sqltext)
        {
            string outs = "";
            using (MySqlConnection c = new MySqlConnection(conns))
            {
                c.Open();

                string query = sqltext;
                var cmd = new MySqlCommand(query, c);

                var reader = cmd.ExecuteScalar();

                if (reader != null)
                {
                    outs = reader.ToString();
                }

                c.Close();
            }
            return outs;
        }

        //public static void insert_order_detail(int order, int barcode, string name, double price, int quantity)
        //{
        //    string outs = "";
        //    using (MySqlConnection c = new MySqlConnection(conns))
        //    {
        //        c.Open();

        //        string query = "INSERT INTO queuekiller.orderdetail(idorder,barcode,name,price,quantity) VALUES(@order,@barcode,@name,@price,@quantity)";
        //        var cmd = new MySqlCommand();
        //        cmd.Connection = c;
        //        cmd.CommandText = query;
        //        cmd.Parameters.AddWithValue("@order", order);
        //        cmd.Parameters.AddWithValue("@barcode", barcode);
        //        cmd.Parameters.AddWithValue("@name", name);
        //        cmd.Parameters.AddWithValue("@price", price);
        //        cmd.Parameters.AddWithValue("@quantity", quantity);
        //        cmd.ExecuteNonQuery();
        //        cmd.Clone();

        //        c.Close();
        //    }
        //}

    }
}