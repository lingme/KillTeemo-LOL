using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LolDataDb;
using Common.Redis;
using Common.RabbitMQ;
using Newtonsoft.Json.Linq;
using System.Configuration;
using KillTeemo_ASP_MVC.Models;
using Newtonsoft.Json;

namespace KillTeemo_ASP_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        ///GET SERVICE INFO
        public ActionResult ServicesInfo()
        {
            return View();
        }

        //GET:SEARCH
        public ActionResult Search()
        {
            var PlayerName = Request["name"];
            ViewBag.name = PlayerName ?? string.Empty;
            return View();
        }

        //GET:faq
        public ActionResult Faq()
        {
            return View();
        }

        /// <summary>
        /// GET:TOKEN
        /// </summary>
        /// <returns></returns>
        public string GetToken()
        {
            return ConfigurationManager.AppSettings["Token"];
        }

        /// <summary>
        /// get aero player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public string Get_Aero_Player(string player)
        {
            List<UserAero> T_list = new List<UserAero>();
            try
            {
                JObject ob = DaiWanAPI.AllMethod.GetUserAeroByCname(GetToken(), DaiWanAPI.Globals.SetPlayerName(player));
                RedisHelper redis = new RedisHelper();
                if(ob["retCode"].ToString() == "0")
                {
                    T_list = JsonConvert.DeserializeObject<List<UserAero>>(ob["data"].ToString());
                    for (int i = 0; i < T_list.Count; i++)
                    {
                        T_list[i].area_name = redis.StringGet($"aero_id_name:{T_list[i].area_id}");
                        T_list[i].tierqueue = redis.StringGet($"tier_queue:{T_list[i].tier}{T_list[i].queue}");
                    }
                }
                return JsonConvert.SerializeObject(T_list);
            }
            catch(Exception ex)
            {
                RabbitMqHelper.K_log(ex, player, "Get_Aero_Player", "C_Error");
                return string.Empty;
            }
        }
    }
}