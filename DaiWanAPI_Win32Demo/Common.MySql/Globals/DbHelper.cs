using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Common.MySql.Globals
{
    public class DbHelper
    {
        /// <summary>
        /// 数据库连接串
        /// </summary>
        private string conStr;

        /// <summary>
        /// 构造函数，初始化连接串
        /// </summary>
        /// <param name="dbConStr"></param>
        public DbHelper(string dbConStr)
        {
            conStr = dbConStr;
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strSql)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conStr))
                {
                    con.Open();
                    DataTable Dt = new DataTable();
                    MySqlCommand cmd = new MySqlCommand(strSql, con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    Dt.Load(dr);
                    return Dt;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        /// <summary>
        /// 执行sql,返回受影响的行数
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public bool ExecuteSql(string strSql)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conStr))
                {
                    con.Open();
                    MySqlCommand command = new MySqlCommand(strSql, con);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 执行sql,返回首行首列
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string strSql)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conStr))
                {
                    con.Open();
                    MySqlCommand command = new MySqlCommand(strSql, con);
                    return command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="sqlStrList"></param>
        /// <returns></returns>
        public bool ExecuteSqlTran(List<string> sqlStrList)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conStr))
                {
                    con.Open();
                    using (MySqlTransaction sqlTransaction = con.BeginTransaction())
                    {
                        try
                        {
                            foreach (string sqlStr in sqlStrList)
                            {
                                MySqlCommand command = new MySqlCommand(sqlStr, con);
                                command.Transaction = sqlTransaction;
                                command.ExecuteNonQuery();
                            }
                            sqlTransaction.Commit();
                            return true;
                        }
                        catch (Exception transEx)
                        {
                            sqlTransaction.Rollback();
                            return false;
                            throw transEx;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}
