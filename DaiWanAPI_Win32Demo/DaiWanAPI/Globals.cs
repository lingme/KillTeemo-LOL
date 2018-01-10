using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace DaiWanAPI
{
    public class Globals
    {
        /// <summary>
        /// 设置搜索的玩家姓名（如果有中文，进行URL编码）
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static string SetPlayerName(string Name)
        {
            return IsChinaese(Name) ? StrToUrlCode(Name) : Name;
        }

        /// <summary>
        /// 中文Url编码
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string StrToUrlCode(string Str)
        {
            return System.Web.HttpUtility.UrlEncode(Str);
        }

        /// <summary>
        /// 是否有中文
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static bool IsChinaese(string Str)
        {
            Regex RegChinese = new Regex(@"[\u4e00-\u9fa5]", RegexOptions.IgnoreCase);
            return RegFormat(RegChinese, Str);
        }

        /// <summary>
        /// 是否为邮箱
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmail(string str)
        {
            Regex RegEmail = new Regex(@"^([a-zA-Z0-9]|[._-])+@([a-zA-Z0-9_-])+\.([a-zA-Z0-9_-])+", RegexOptions.IgnoreCase);
            return RegFormat(RegEmail, str);
        }

        /// <summary>
        /// 是否为身份证号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsIdNumb(string str)
        {
            Regex RegIdNumb = new Regex(@"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$", RegexOptions.IgnoreCase);
            return RegFormat(RegIdNumb, str);
        }

        /// <summary>
        /// 是否是浮点数
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(string str)
        {
            Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
            return RegFormat(RegDecimal, str);
        }

        /// <summary>
        /// 是否数字字符串
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string Str)
        {
            Regex RegNumber = new Regex("^[0-9]+$");
            return RegFormat(RegNumber, Str);
        }

        /// <summary>
        /// 格式验证
        /// </summary>
        /// <param name="Reg"></param>
        /// <param name="Str"></param>
        /// <returns></returns>
        private static bool RegFormat(Regex Reg, string Str)
        {
            if (string.IsNullOrEmpty(Str))
            {
                return false;
            }
            else
            {
                return Reg.Match(Str).Success;
            }
        }
    }
}
