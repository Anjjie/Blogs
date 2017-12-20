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
{  /// <summary>
   /// 【信息统计】服务类
   /// </summary>
    public class InfoCount_Service
    {
        #region 获取全部信息统计信息
        /// <summary>
        /// 获取全部信息统计信息
        /// </summary>
        /// <returns></returns>
        public static List<InfoCount> GetAllInfoCount()
        {
            List<InfoCount> list = new List<InfoCount>();
            SqlDataReader dr = DBHelper.ExecuteReader("Select_InfoCount", CommandType.StoredProcedure);
            while (dr.Read())
            {
                InfoCount infoCount = new InfoCount() {
                    A_No = Convert.ToInt32(dr["A_No"]),
                    IC_Count = Convert.ToInt32(dr["IC_Count"])
                };
                list.Add(infoCount);
            }
            dr.Close();
            DBHelper.CloseCon();
            return list;
        }
        #endregion
        #region 根据条件查询信息统计信息
        /// <summary>
        /// 根据条件查询信息统计信息
        /// </summary>
        /// <returns></returns>
        public static InfoCount GetInfoCountByConn(string demandType, string demandContent)
        {
            string sql = "Select * from InfoCount where " + demandType + " = @" + demandType;
            InfoCount infoCount = new InfoCount();
            SqlDataReader dr = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter[] {
                new SqlParameter("@" + demandType,demandContent)
            });
            if (dr.Read())
            {
                infoCount = new InfoCount()
                {
                    A_No = Convert.ToInt32(dr["A_No"]),
                    IC_Count = Convert.ToInt32(dr["IC_Count"])
                };
            }
            dr.Close();
            DBHelper.CloseCon();
            return infoCount;
        }
        #endregion
        #region 添加信息统计数据
        /// <summary>
        /// 添加信息统计数据
        /// </summary>
        /// <returns></returns>
        public static int InsertInfoCount(InfoCount obj)
        {
            int n = DBHelper.ExecuteNonQuery("Insert_InfoCount",CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@A_No",obj.A_No),
                    new SqlParameter("@IC_Count",obj.IC_Count)
                });
            return n;
        }
        #endregion
        #region 修改信息统计数据
        /// <summary>
        /// 修改信息统计数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateInfoCount(InfoCount obj)
        {
            int n = DBHelper.ExecuteNonQuery("Update_InfoCount", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@A_No",obj.A_No),
                    new SqlParameter("@IC_Count",obj.IC_Count)
                });
            return n;
        }
        #endregion
        #region 删除信息统计数据
        /// <summary>
        /// 删除信息统计数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteInfoCount(InfoCount obj)
        {
            int n = DBHelper.ExecuteNonQuery("Delete_InfoCount", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@A_No",obj.A_No)
                });
            return n;
        } 
        #endregion
    }
}
