using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LolDataDb;
using Common.RabbitMQ;
using Common.Redis;

namespace KillTeemo_ASP_MVC.Controllers
{
    public class BigDataController : Controller
    {
        // GET: BigData
        public ActionResult ChampionTrend()
        {

            return View();
        }

        //GET：AeroTrend
        public ActionResult AeroTrend()
        {
            return View();
        }

        //GET:Hero_list
        public ActionResult HeroList()
        {
            return View();
        }

        //GET:HERO_INFO
        public ActionResult HeroInfo()
        {
            var HeroName = Request["heroname"];
            ViewBag.Title = HeroName == null ? "???" : HeroName.ToLower();
            ViewBag.Bg = (HeroName == null ? "ornn" : HeroName.ToLower()) + ".jpg";
            return View();
        }

        //GET ；FREE_HERO
        public ActionResult FreeHero()
        {
            return View();
        }

        //GET:Champion_Trend
        public JsonResult Get_Champion_Trend(string TierQueue)
        {
            try
            {
                var redis = new RedisHelper();
                return Json(redis.StringGet($"tierpox:{TierQueue}"));
            }
            catch (Exception ex)
            {
                RabbitMqHelper.K_log(ex, TierQueue, "Get_Champion_Trend", "C_Error");
                return Json(new { });
            }
        }

        //GET：Aero_num
        public JsonResult Get_Aero_Num()
        {
            try
            {
                var redis = new RedisHelper();
                return Json(redis.StringGet("aeronum:num"));
            }
            catch (Exception ex)
            {
                RabbitMqHelper.K_log(ex, "aeronum:num", "Get_Aero_Num", "C_Error");
                return Json(new { });
            }
        }

        //GET:HERO_LIST
        public JsonResult Get_Hero_List(string Hero_type)
        {
            try
            {
                var redis = new RedisHelper();
                return Json(redis.StringGet($"hero_list:{Hero_type}"));
            }
            catch(Exception ex)
            {
                RabbitMqHelper.K_log(ex, Hero_type, "Get_Hero_List", "C_Error");
                return Json(new { });
            }
        }

        //GET:HERO_INFO
        public JsonResult Get_Hero_Info(string Hero_Ename)
        {
            try
            {
                var redis = new RedisHelper();
                return Json(redis.StringGet($"heroinfo:{Hero_Ename.ToLower()}"));
            }
            catch (Exception ex)
            {
                RabbitMqHelper.K_log(ex, Hero_Ename, "Get_Hero_Info", "C_Error");
                return Json(new { });
            }
        }

        //GET:FREE_HERO
        public JsonResult Get_Free_Hero()
        {
            try
            {
                var redis = new RedisHelper();
                return Json(redis.StringGet("free_new_skin:result"));
            }
            catch (Exception ex)
            {
                RabbitMqHelper.K_log(ex, "free_new_skin:result" , "Get_Free_Hero", "C_Error");
                return Json(new { });
            }
        }
    }
}