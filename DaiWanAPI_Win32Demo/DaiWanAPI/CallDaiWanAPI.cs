using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Common.RabbitMQ;
using LolDataDb;

namespace DaiWanAPI
{
    public class CallDaiWanAPI
    {
        /// <summary>
        /// DaiWan API Post请求
        /// </summary>
        /// <param name="TOKEN">DaiWan Toekn</param>
        /// <param name="API_Url">API 地址</param>
        /// <returns></returns>
        public static JObject CallRemoteAPI(string TOKEN, string API_Url)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Token", TOKEN);
                HttpResponseMessage response = httpClient.GetAsync(API_Url).Result;
                if (response.IsSuccessStatusCode)
                {
                    Update_website_api();
                    return JObject.Parse(response.Content.ReadAsStringAsync().Result.ToString());
                }
                return JObject.Parse("{\"data\":\"" + response.RequestMessage + "\",\"retCode\":777,\"msg\":\"Bad\"}");
            }
            catch (Exception ex)
            {
                K_log(ex, API_Url);
                return JObject.Parse("{\"data\":\"" + ex.Message + "\",\"retCode\":777,\"msg\":\"Bad\"}");
            }
        }

        /// <summary>
        /// 更新API调用量
        /// </summary>
        public static void Update_website_api()
        {
            try
            {
                website_info data = new website_info()
                {
                    Type = OperationType.Operation.api.ToString()
                };
                string json_str = RabbitMqHelper.Object_to_Json<website_info>(OperationType.Operation.api, data);
                RabbitMqHelper.SendMessageToQueue(OperationType.Mq_queue_name, json_str);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Log 日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="API_Url"></param>
        public static void K_log(Exception ex,string API_Url)
        {
            try
            {
                web_log log = new web_log()
                {
                    Log = $"{ex.Message} / {API_Url}",
                    LogTime = DateTime.Now,
                    LogFrom = "CallRemoteAPI",
                    LogType = "Api_Error"
                };
                string json_str = RabbitMqHelper.Object_to_Json<web_log>(OperationType.Operation.log, log);
                RabbitMqHelper.SendMessageToQueue(OperationType.Mq_queue_name, json_str);
            }
            catch (Exception) { }
        }
    }
}
