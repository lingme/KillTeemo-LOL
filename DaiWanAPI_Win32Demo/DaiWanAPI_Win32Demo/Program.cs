using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using DaiWanAPI;
using System.Configuration;
using System.Runtime.InteropServices;
using Common.Redis;
using LolDataDb;
using Common.MySql.Globals;
using Common.RabbitMQ;

namespace DaiWanAPI_Win32Demo
{
    class Program
    {
        #region EnableCopy
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out int mode);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetStdHandle(int handle);
        const int STD_INPUT_HANDLE = -10;
        const int ENABLE_QUICK_EDIT_MODE = 0x40 | 0x80;
        public static void EnableQuickEditMode()
        {
            int mode;
            IntPtr handle = GetStdHandle(STD_INPUT_HANDLE);
            GetConsoleMode(handle, out mode);
            mode |= ENABLE_QUICK_EDIT_MODE;
            SetConsoleMode(handle, mode);
        }
        #endregion

        static void Main(string[] args)
        {
            EnableQuickEditMode();
            Console.SetWindowSize(170, 64);
            Console.BufferHeight = 3500;

            using (Repository db = new Repository())
            {
                var q = db.Get<hero_info>().FirstOrDefault();

            }


            //hero_info bo = new hero_info()
            //{
            //    Id = 1,
            //    c_name = "aaaaa",
            //    dataFrom = "bbbbbb",
            //    UpdateTime = DateTime.Now,
            //    dataJson = "sdfsdfsdfsdf"
            //};

            //string dddd = RabbitMqHelper.Object_to_Json<hero_info>("heroTable", OperationType.Operation.Update, bo);



            //while(true)
            //{
            //    Console.WriteLine("Presss Enter Your Message : ");
            //    string message = Console.ReadLine();
            //    if(RabbitMqHelper.SendMessageToQueue("killteemo_queue",message))
            //    {
            //        Console.WriteLine(string.Format("[{0}] ---> {1}", DateTime.Now.ToString("HH:mm:ss"), "Message Send Successful !"));
            //    }
            //}





            //====================================================================
            //                                                                        测试API
            //====================================================================
            if (false)
                {
                    AllMethod.GetAllAero(GetToken());

                    AllMethod.GetAllChampion(GetToken());

                    AllMethod.GetFreeChampion(GetToken());

                    AllMethod.GetUserAeroByCname(GetToken(), Globals.SetPlayerName("Zonx"));

                    AllMethod.GetUserInfoByQquin(GetToken(), "U12073669367109930161", "9");

                    AllMethod.GetBattleList(GetToken(), "U12073669367109930161", "9", "0");

                    AllMethod.GetGameDetail(GetToken(), "9", " 1662669388");

                    AllMethod.GetUserHonor(GetToken(), "9", "U12073669367109930161");

                    AllMethod.GetUserKDA30(GetToken(), "9", "U12073669367109930161");

                    AllMethod.GetUserAllBattle(GetToken(), "9", "U12073669367109930161");

                    AllMethod.GetUserMvp(GetToken(), "9", "U12073669367109930161");

                    AllMethod.GetChampion(GetToken(), "9");

                    AllMethod.GetUserIcon(GetToken(),"770");

                    AllMethod.GetSkillIcon(GetToken(), "21");

                    AllMethod.GetGameType(GetToken(),"1");

                    AllMethod.GetAeroGame(GetToken(), "1");

                    AllMethod.GetTierQueue(GetToken(), "1", "0");

                    AllMethod.GetTagName(GetToken(), "3");

                    AllMethod.GetSkinImg(GetToken(), "31006");

                    AllMethod.GetItemIcon(GetToken(), "3085");
                }
            //====================================================================
            

            for (int i = 1; i<3;i++)
            {
                Console.WriteLine(i.ToString());
                JObject anti = AllMethod.GetTagName(GetToken(), i.ToString());



                UnSerialize(anti.Cast<JToken>().ToList());
            }




            Console.ReadLine();
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns></returns>
        public static string GetToken()
        {
            return ConfigurationManager.AppSettings["Token"];
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="Ob"></param>
        public static void UnSerialize(List<JToken> JTList)
        {
            foreach (JToken item in JTList)
            {
                if (item.Children().Children().FirstOrDefault() != null && item.Children().Children().FirstOrDefault().HasValues)
                {
                    UnSerialize(item.Cast<JToken>().ToList());
                }
                else
                {
                    Display(item);
                }
            }
        }


        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="JT"></param>
        public static void Display(JToken JT)
        {
            var JOb = JT as JProperty;
            if (JOb == null)
            {
                foreach (JProperty JP in JT)
                {
                    Console.WriteLine(String.Format("{0} \t\t {1}", JP.Name, JP.Value));

                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine(String.Format("{0} \t\t {1}", JOb.Name, JOb.Value));
            }
        }
    }
}