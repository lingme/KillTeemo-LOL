using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Common.RabbitMQ;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Common.MySql;
using LolDataDb;
using Common.MySql.Globals;
using MySql.Data.MySqlClient;

namespace RabbitMQ_Consumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Received_messmage(OperationType.Mq_queue_name);
        }

        /// <summary>
        /// 获取连接
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection getmysqlcon()
        {
            string M_str_sqlcon = "Data Source=localhost;database=loldata;user id=root;password=killteemo4869123aASD!@#-=;port=4869";
            MySqlConnection myCon = new MySqlConnection(M_str_sqlcon);
            return myCon;
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="M_str_sqlstr"></param>
        public static bool getmysqlcomanti(string M_str_sqlstr)
        {
            try
            {
                MySqlConnection mysqlcon = getmysqlcon();
                mysqlcon.Open();
                MySqlCommand mysqlcom = new MySqlCommand(M_str_sqlstr, mysqlcon);
                mysqlcom.ExecuteNonQuery();
                mysqlcom.Dispose();
                mysqlcon.Close();
                mysqlcon.Dispose();
                return true;
            }
            catch (Exception) { return false; }
        }

        /// <summary>
        /// 消费者收取消息
        /// </summary>
        /// <param name="queue_name"></param>
        public static void Received_messmage(string queue_name)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost", Password = "guest", UserName = "guest" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(
                                             queue: queue_name,
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                        var consumer = new EventingBasicConsumer(channel);
                        //注册接收事件，一旦创建连接就去拉取消息
                        consumer.Received += (model, ea) =>
                        {
                            Swith_operation(Encoding.UTF8.GetString(ea.Body));
                        };
                        channel.BasicConsume(
                                             queue: queue_name,
                                             noAck: true,
                                             consumer: consumer);
                        Console.WriteLine(" Press [enter] to exit.");
                        Console.ReadLine();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error : " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// 解析操作
        /// </summary>
        /// <param name="web_json"></param>
        public static void Swith_operation(string web_json)
        {
            try
            {

                JObject j_data = JObject.Parse(web_json);
                if (j_data["tablename"].ToString() == "website_info")
                {
                    switch (j_data["operationname"].ToString())
                    {
                        case "update_web_site":
                            Update_web_site(j_data["type"].ToString());
                            break;
                        case "api":
                            Updata_web_api();
                            break;
                    }
                }
                if(j_data["tablename"].ToString() == "web_log")
                {
                    K_log(web_json);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error : " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="Json_str"></param>
        public static void K_log(string Json_str)
        {
            try
            {
                JObject j_data = JObject.Parse(Json_str);
                string sql_str = string.Format("INSERT into web_log(Log,LogTime,LogFrom,LogType)VALUES('{0}','{1}','{2}','{3}')", j_data["log"].ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), j_data["logfrom"].ToString(), j_data["logtype"].ToString());
                if(getmysqlcomanti(sql_str))
                {
                    Console.WriteLine(string.Format("[{0}] <K_log> ---> 记录日志：{1}", DateTime.Now.ToString("MM-dd HH:mm:ss"), j_data["logtype"].ToString()));
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error : " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// 更新站点API调用量
        /// </summary>
        /// <param name="data"></param>
        public static void Updata_web_api()
        {
            try
            {
                string sql_str = "UPDATE website_info set Count_num=Count_num+1 where Type = 'api'";
                if (getmysqlcomanti(sql_str))
                {
                    Console.WriteLine(string.Format("[{0}] <Update_web_site> ---> 更新 API 调用量成功！", DateTime.Now.ToString("MM-dd HH:mm:ss")));
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error : " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// 更新站点信息
        /// </summary>
        /// <param name="data"></param>
        public static void Update_web_site(string data)
        {
            try
            {
                string sql_visit = "UPDATE website_info set Count_num=Count_num+1 where Type = 'visit'";
                if (getmysqlcomanti(sql_visit))
                {
                    Console.WriteLine(string.Format("[{0}] <Update_web_site> ---> 更新站点浏览量成功！", DateTime.Now.ToString("MM-dd HH:mm:ss")));
                }

                string sql_browser_type = string.Format("UPDATE website_info set Count_num=Count_num+1 where Type = '{0}'", data);
                if(getmysqlcomanti(sql_browser_type))
                {
                    Console.WriteLine(string.Format("[{0}] <Update_web_site> ---> 更新（{1}）浏览量成功！", DateTime.Now.ToString("MM-dd HH:mm:ss"), data));
                }

                string sql_time = string.Format("UPDATE website_info set Count_num=Count_num+1 where Type = 'visit'", Get_time_par());
                if(getmysqlcomanti(sql_time))
                {
                    Console.WriteLine(string.Format("[{0}] <Update_web_site> ---> 更新用户浏览时段（{1}）成功！", DateTime.Now.ToString("MM-dd HH:mm:ss"),Get_time_par()));
                }
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error : " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// 获取时间段
        /// </summary>
        /// <returns></returns>
        public static string Get_time_par()
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 4)
            {
                return "0-4";
            }
            if (DateTime.Now.Hour >= 4 && DateTime.Now.Hour < 8)
            {
                return "4-8";
            }
            if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 12)
            {
                return "8-12";
            }
            if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 16)
            {
                return "12-16";
            }
            if (DateTime.Now.Hour >= 16 && DateTime.Now.Hour < 20)
            {
                return "16-20";
            }
            if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
            {
                return "20-0";
            }
            return string.Empty;
        }
    }
}
