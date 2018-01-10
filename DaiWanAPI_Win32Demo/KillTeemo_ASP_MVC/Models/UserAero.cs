using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Redis;
using KillTeemo_ASP_MVC.Common;

namespace KillTeemo_ASP_MVC.Models
{
    public class UserAero
    {
        public int area_id { get; set; }
        public string qquin { get; set; }
        public int icon_id { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public int tier { get; set; }
        public int queue { get; set; }
        public int win_point { get; set; }


        ///自定义属性
        
        public string icon_src
        {
            get
            {
                return $"http://cdn.tgp.qq.com/lol/images/resources/usericon/{icon_id}.png";
            }
        }

        public string area_name { get; set; }

        public string tierqueue { get; set; }

        /// <summary>
        /// 加密qquin + 大区ID
        /// </summary>
        public string Ency_qquin
        {
            get
            {
                return GlobalsCommon.Encryption($"{qquin}-{area_id}");
            }
        }
    }
}