using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    /// <summary>
    /// 【登录日志】服务类
    /// </summary>
    public class LoginLog_Service
    {
        #region 获取全部登录日志信息
        /// <summary>
        /// 获取全部登录日志信息
        /// </summary>
        /// <returns></returns>
        public static List<LoginLog> GetAllLoginLog()
        {
            List<LoginLog> list = new List<LoginLog>();
            SqlDataReader dr = DBHelper.ExecuteReader("Select_LoginLog", CommandType.StoredProcedure);
            while (dr.Read())
            {
                LoginLog atype = new LoginLog()
                {
                    Log_City = dr["Log_City"].ToString(),
                    Log_Country = dr["Log_Country"].ToString(),
                    Log_Date = dr["Log_Date"].ToString(),
                    Log_ipAddress = dr["Log_ipAddress"].ToString(),
                    Log_Province = dr["Log_Province"].ToString(),
                    P_LoginName = dr["P_LoginName"].ToString(),
                    Log_No = Convert.ToInt32(dr["Log_No"])
                };
                list.Add(atype);
            }
            dr.Close();
            DBHelper.CloseCon();
            return list;
        }
        #endregion

        #region 获取全部登录日志信息（按序号从大到小排序）
        /// <summary>
        /// 获取全部登录日志信息（按序号从大到小排序）
        /// </summary>
        /// <returns></returns>
        public static List<LoginLog> GetAllLoginLogByDesc(string LoginName)
        {
            List<LoginLog> list = new List<LoginLog>();
            SqlDataReader dr = DBHelper.ExecuteReader("Select_LoginLogByDesc", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@P_LoginName",LoginName)
                });
            while (dr.Read())
            {
                LoginLog atype = new LoginLog()
                {
                    Log_City = dr["Log_City"].ToString(),
                    Log_Country = dr["Log_Country"].ToString(),
                    Log_Date = dr["Log_Date"].ToString(),
                    Log_ipAddress = dr["Log_ipAddress"].ToString(),
                    Log_Province = dr["Log_Province"].ToString(),
                    P_LoginName = dr["P_LoginName"].ToString(),
                    Log_No = Convert.ToInt32(dr["Log_No"])
                };
                list.Add(atype);
            }
            dr.Close();
            DBHelper.CloseCon();
            return list;
        }
        #endregion

        #region 根据条件查询登录日志信息
        /// <summary>
        /// 根据条件查询登录日志信息
        /// </summary>
        /// <returns></returns>
        public static LoginLog GetLoginLogByConn(string demandType, string demandContent)
        {
            string sql = "Select * from LoginLog where " + demandType + " = @" + demandType;
            LoginLog LoginLog = new LoginLog();
            SqlDataReader dr = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter[] {
                new SqlParameter("@" + demandType,demandContent)
            });
            if (dr.Read())
            {
                LoginLog = new LoginLog()
                {
                    Log_City = dr["Log_City"].ToString(),
                    Log_Country = dr["Log_Country"].ToString(),
                    Log_Date = dr["Log_Date"].ToString(),
                    Log_ipAddress = dr["Log_ipAddress"].ToString(),
                    Log_Province = dr["Log_Province"].ToString(),
                    P_LoginName = dr["P_LoginName"].ToString(),
                    Log_No = Convert.ToInt32(dr["Log_No"])
                };
            }
            dr.Close();
            DBHelper.CloseCon();
            return LoginLog;
        }
        #endregion
        #region 添加登录日志数据
        /// <summary>
        /// 添加登录日志数据
        /// </summary>
        /// <returns></returns>
        public static int InsertLoginLog(LoginLog obj)
        {
            int n = DBHelper.ExecuteNonQuery("Insert_LoginLog", CommandType.StoredProcedure,
                new SqlParameter[] {
                      new SqlParameter("@Log_City",obj.Log_City),
                    new SqlParameter("@Log_Country",obj.Log_Country),
                    new SqlParameter("@Log_Date",obj.Log_Date),
                    new SqlParameter("@Log_ipAddress",obj.Log_ipAddress),
                    new SqlParameter("@Log_Province",obj.Log_Province),
                    new SqlParameter("@P_LoginName",obj.P_LoginName)
                });
            return n;
        }
        #endregion
        #region 修改登录日志数据
        /// <summary>
        /// 修改登录日志数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateLoginLog(LoginLog obj)
        {
            int n = DBHelper.ExecuteNonQuery("Update_LoginLog", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@Log_City",obj.Log_City),
                    new SqlParameter("@Log_Country",obj.Log_Country),
                    new SqlParameter("@Log_Date",obj.Log_Date),
                    new SqlParameter("@Log_ipAddress",obj.Log_ipAddress),
                    new SqlParameter("@Log_Province",obj.Log_Province),
                    new SqlParameter("@P_LoginName",obj.P_LoginName),
                    new SqlParameter("@Log_No",obj.Log_No)
                });
            return n;
        }
        #endregion
        #region 删除登录日志数据
        /// <summary>
        /// 删除登录日志数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteLoginLog(LoginLog obj)
        {
            int n = DBHelper.ExecuteNonQuery("Delete_LoginLog", CommandType.StoredProcedure,
                new SqlParameter[] {
                   new SqlParameter("@Log_No",obj.Log_No)
                });
            return n;
        }
        #endregion
    }
}
