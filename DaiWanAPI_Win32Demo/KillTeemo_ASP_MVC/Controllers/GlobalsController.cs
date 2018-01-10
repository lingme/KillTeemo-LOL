using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.RabbitMQ;
using LolDataDb;

namespace KillTeemo_ASP_MVC.Controllers
{
    public class GlobalsController : Controller
    {
        // GET: Globals

        //
        public void UpdataWebsite(string broType)
        {
            try
            {
                website_info data = new website_info()
                {
                    Type = broType
                };
                string Json_str = RabbitMqHelper.Object_to_Json<website_info>(OperationType.Operation.update_web_site, data);
                RabbitMqHelper.SendMessageToQueue(OperationType.Mq_queue_name,Json_str);
            }
            catch (Exception) { }
        }
    }
}