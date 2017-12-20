using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Models;
using IDAL;

namespace DAL
{
    /// <summary>
    /// 【网站信息】服务类
    /// </summary>
    public class WebInfo_Service
    {
        #region 获取全部网站信息
        /// <summary>
        /// 获取全部网站信息
        /// </summary>
        /// <returns></returns>
        public static List<WebInfo> GetAllWebInfo()
        {
            List<WebInfo> list = new List<WebInfo>();
            SqlDataReader dr = DBHelper.ExecuteReader("Select_WebInfo", CommandType.StoredProcedure);
            while (dr.Read())
            {
                WebInfo webinfo = new WebInfo()
                {
                    Web_Date = dr["Web_Date"].ToString(),
                    Web_Index = dr["Web_Index"].ToString(),
                    Web_Name = dr["Web_Name"].ToString(),
                    Web_No = Convert.ToInt32(dr["Web_No"])
                };
                list.Add(webinfo);
            }
            dr.Close();
            DBHelper.CloseCon();
            return list;
        } 
        #endregion

        #region 根据条件查询网站信息
        /// <summary>
        /// 根据条件查询网站信息
        /// </summary>
        /// <returns></returns>
        public static WebInfo GetWebInfoByConn(string demandType, string demandContent)
        {
            string sql = "Select * from WebInfo where " + demandType + "= @" + demandType;
            WebInfo webinfo = new WebInfo();
            SqlDataReader dr = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter[] {
                new SqlParameter("@" + demandType,demandContent)
            });
            if (dr.Read())
            {
                webinfo = new WebInfo()
                {
                    Web_Date = dr["Web_Date"].ToString(),
                    Web_Index = dr["Web_Index"].ToString(),
                    Web_Name = dr["Web_Name"].ToString(),
                    Web_No = Convert.ToInt32(dr["Web_No"])
                };
            }
            dr.Close();
            DBHelper.CloseCon();
            return webinfo;
        } 
        #endregion

        #region 添加网站数据
        /// <summary>
        /// 添加网站数据
        /// </summary>
        /// <returns></returns>
        public static int InsertWebInfo(WebInfo obj)
        {
            int n = DBHelper.ExecuteNonQuery("Insert_WebInfo", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@Web_Date",obj.Web_Date),
                     new SqlParameter("@Web_Index",obj.Web_Index),
                      new SqlParameter("@Web_Name",obj.Web_Name)
                });
            return n;
        } 
        #endregion

        #region 修改网站数据
        /// <summary>
        /// 修改网站数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateWebInfo(WebInfo obj)
        {
            int n = DBHelper.ExecuteNonQuery("Update_WebInfo", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@Web_Date",obj.Web_Date),
                     new SqlParameter("@Web_Index",obj.Web_Index),
                      new SqlParameter("@Web_Name",obj.Web_Name),
                      new SqlParameter("@Web_No",obj.Web_No)
                });
            return n;
        } 
        #endregion

        #region 删除网站数据
        /// <summary>
        /// 删除网站数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteWebInfo(WebInfo obj)
        {
            int n = DBHelper.ExecuteNonQuery("Delete_WebInfo", CommandType.StoredProcedure,
                new SqlParameter[] {
                   new SqlParameter("@Web_No",obj.Web_No)
                });
            return n;
        } 
        #endregion
    }
}
