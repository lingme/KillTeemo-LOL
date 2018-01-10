using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace DaiWanAPI
{
    public class AllMethod
    {
        //=========================================================================================================
        //                                                                                                       数据字典
        //=========================================================================================================

        /// <summary>
        /// 获取所有大区数据
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        public static JObject GetAllAero(string Token)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, @"http://lol.apigod.com:8080/api/AllGameArea");
        }

        /// <summary>
        /// 获取所有英雄
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        public static JObject GetAllChampion(string Token)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, @"http://lol.apigod.com:8080/api/AllHero");
        }

        /// <summary>
        /// 获取周免英雄集合
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        public static JObject GetFreeChampion(string Token)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, @"http://lol.apigod.com:8080/api/Free");
        }

        //=========================================================================================================
        //                                                                                                        用户数据
        //=========================================================================================================

        /// <summary>
        /// 获取用户区域数据（通过昵称）
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static JObject GetUserAeroByCname(string Token, string UserName)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/UserArea?userName={0}", UserName));
        }

        /// <summary>
        /// 获取用户基本信息（通过Qquin和AeroId）
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="Qquin"></param>
        /// <param name="AeroId"></param>
        /// <returns></returns>
        public static JObject GetUserInfoByQquin(string Token,string Qquin,string AeroId)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/UserExtInfo?qquin={0}&areaid={1}", Qquin, AeroId));
        }

        /// <summary>
        /// 获取战绩列表
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="Qquin"></param>
        /// <param name="AeroId"></param>
        /// <param name="PageNum"></param>
        /// <returns></returns>
        public static JObject GetBattleList(string Token,string Qquin,string AeroId,string PageNum)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/BattleList?qquin={0}&areaid={1}&page={2}", Qquin, AeroId, PageNum));
        }

        /// <summary>
        /// 获取单场游戏数据
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="AeroId"></param>
        /// <param name="GameId"></param>
        /// <returns></returns>
        public static JObject GetGameDetail(string Token,string AeroId,string GameId)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/GameDetail?areaid={0}&gameid={1}", AeroId, GameId));
        }

        /// <summary>
        /// 获取荣誉数据（三杀，四杀，五杀，最高输出等）
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="AeroId"></param>
        /// <param name="Qquin"></param>
        /// <returns></returns>
        public static JObject GetUserHonor(string Token,string AeroId,string Qquin)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/UserHonor?areaid={0}&qquin={1}", AeroId, Qquin));
        }

        /// <summary>
        /// 获取30天的KDA
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="AeroId"></param>
        /// <param name="Qquin"></param>
        /// <returns></returns>
        public static JObject GetUserKDA30(string Token,string AeroId,string Qquin)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/UserKDA?areaid={0}&qquin={1}", AeroId, Qquin));
        }

        /// <summary>
        /// 获取赛季汇总信息
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="AeroId"></param>
        /// <param name="Qquin"></param>
        /// <returns></returns>
        public static JObject GetUserAllBattle(string Token,string AeroId,string Qquin)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/UserAllBattle?areaid={0}&qquin={1}", AeroId, Qquin));
        }

        /// <summary>
        /// 获取MVP数量
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="AeroId"></param>
        /// <param name="Qquin"></param>
        /// <returns></returns>
        public static JObject GetUserMvp(string Token,string AeroId ,string Qquin)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/UserMVP?areaid={0}&qquin={1}", AeroId, Qquin));
        }

        /// <summary>
        /// 获取英雄头像（返回图片网路地址）
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="ChampionId"></param>
        /// <returns></returns>
        public static JObject GetChampion(string Token,string ChampionId)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/ChampionIconStr?id={0}", ChampionId));
        }

        /// <summary>
        /// 获取召唤师头像（返回图片网路地址）
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="IconId"></param>
        /// <returns></returns>
        public static JObject GetUserIcon(string Token ,string IconId)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/UserIconStr?id={0}", IconId));
        }

        /// <summary>
        /// 获取召唤师技能图标（返回图片网络地址）
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="IconId"></param>
        /// <returns></returns>
        public static JObject GetSkillIcon(string Token,string IconId)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/SkillIconStr?id={0}", IconId));
        }

        /// <summary>
        /// 获取比赛类型
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public static JObject GetGameType(string Token,string TypeId)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/GameType?typeid={0}", TypeId));
        }

        /// <summary>
        /// 获取大区名称
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public static JObject GetAeroGame(string Token,string TypeId)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/GameArea?areaid={0}", TypeId));
        }

        /// <summary>
        /// 获取段位信息
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="Tier"></param>
        /// <param name="Queue"></param>
        /// <returns></returns>
        public static JObject GetTierQueue(string Token,string Tier,string Queue)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/TierQueue?tier={0}&queue={1}", Tier, Queue));
        }

        /// <summary>
        /// 获取战斗标签描述
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="TagId"></param>
        /// <returns></returns>
        public static JObject GetTagName(string Token, string TagId)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/TagName?tagid={0}", TagId));
        }

        /// <summary>
        /// 获取英雄皮肤（返回图片网络地址）
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="SkinId"></param>
        /// <returns></returns>
        public static JObject GetSkinImg(string Token,string SkinId)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/SkinIconStr?id={0}", SkinId));
        }

        /// <summary>
        /// 获取装备图标（返回图片网络地址）
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="ItemId"></param>
        /// <returns></returns>
        public static JObject GetItemIcon(string Token,string ItemId)
        {
            return CallDaiWanAPI.CallRemoteAPI(Token, string.Format(@"http://lol.apigod.com:8080/api/ItemIconStr?id={0}", ItemId));
        }
    }
}
