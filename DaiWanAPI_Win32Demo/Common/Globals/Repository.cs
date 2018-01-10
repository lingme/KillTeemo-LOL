using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolDataEntityFramework;
using Common.Service;

namespace Common.Globals
{
    public class Repository : EFRepository<LolDataEntities>
    {
        /// <summary>
        /// 指定连接串
        /// </summary>
        /// <param name="conStr"></param>
        public Repository(string conStr)
        {
            this.DbContext.Database.Connection.ConnectionString = conStr;
        }

        /// <summary>
        /// 使用默认连接
        /// </summary>
        public Repository() { }
    }
}
