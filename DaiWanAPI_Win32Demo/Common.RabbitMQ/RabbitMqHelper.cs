using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using LolDataDb;

namespace Common.RabbitMQ
{
    public class RabbitMqHelper
    {
        /// <summary>
        /// 发送Message到消息队列
        /// </summary>
        /// <param name="queue_name"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool SendMessageToQueue(string queue_name,string message)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost",Password="guest",UserName="guest" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare
                        (
                            queue: queue_name,      //队列名
                            durable: false,               //是否持久化
                            exclusive: false,              //排它性
                            autoDelete: false,           //一旦客户端连接断开则自动删除queue
                            arguments: null             //如果安装了队列优先级插件则可以设置优先级
                        );

                        channel.BasicPublish(exchange: "",                                                           //exchange名称
                                             routingKey: queue_name,                                                  //如果存在exchange,则消息被发送到名称为hello的queue的客户端
                                             basicProperties: null,                                                        //基本类型
                                             body: Encoding.UTF8.GetBytes(message));                        //消息体
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="TableName"></param>
        /// <param name="Ob"></param>
        /// <returns></returns>
        public static string Object_to_Json<T>(OperationType.Operation Ot_Type , T Ob) where 
            T : class,new()
        {
            try
            {
                List<string> Json_list = new List<string>();
                foreach(System.Reflection.PropertyInfo p in Ob.GetType().GetProperties())
                {
                    Json_list.Add(string.Format("\"{0}\":\"{1}\"" , p.Name.ToLower() , p.GetValue(Ob)));
                }
                return "{" + string.Format("\"tablename\":\"{0}\",\"operationname\":\"{1}\",{2}", Ob.GetType().Name, Ot_Type.ToString(), string.Join(",", Json_list)) + "}";
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Log 日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="API_Url"></param>
        public static void K_log(Exception ex, string parameter,string log_from,string log_type)
        {
            try
            {
                web_log log = new web_log()
                {
                    Log = $"{ex.Message} / {parameter}",
                    LogTime = DateTime.Now,
                    LogFrom = log_from,
                    LogType = log_type
                };
                string json_str = RabbitMqHelper.Object_to_Json<web_log>(OperationType.Operation.log, log);
                RabbitMqHelper.SendMessageToQueue(OperationType.Mq_queue_name, json_str);
            }
            catch (Exception) { }
        }
    }
}
