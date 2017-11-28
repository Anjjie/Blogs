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
    /// 【回复】服务类
    /// </summary>
    public class Reply_Service
    {
        #region 获取全部回复信息
        /// <summary>
        /// 获取全部回复信息
        /// </summary>
        /// <returns></returns>
        public static List<Reply> GetAllReply()
        {
            List<Reply> list = new List<Reply>();
            SqlDataReader dr = DBHelper.ExecuteReader("Select_Reply",CommandType.StoredProcedure);
            while (dr.Read())
            {
                Reply reply = new Reply() {
                    Com_No=Convert.ToInt32( dr["Com_No"]),
                    R_Content=dr["R_Content"].ToString(),
                    R_Datetime = dr["R_Datetime"].ToString(),
                    R_No = Convert.ToInt32(dr["R_No"])
                };
                list.Add(reply);
            }
            dr.Close();
            DBHelper.CloseCon();
            return list;
        } 
        #endregion
        #region 根据条件查询回复信息
        /// <summary>
        /// 根据条件查询回复信息
        /// </summary>
        /// <returns></returns>
        public static Reply GetReplyByConn(string demandType, string demandContent)
        {
            string sql = "Select * from Reply where " + demandType + " = @" + demandType;
            Reply reply = new Reply();
            SqlDataReader dr = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter[] {
                new SqlParameter("@" + demandType,demandContent)
            });
            if (dr.Read())
            {
                reply = new Reply()
                {
                    Com_No = Convert.ToInt32(dr["Com_No"]),
                    R_Content = dr["R_Content"].ToString(),
                    R_Datetime = dr["R_Datetime"].ToString(),
                    R_No = Convert.ToInt32(dr["R_No"])
                };
            }
            dr.Close();
            DBHelper.CloseCon();
            return reply;
        }
        #endregion
        #region 添加回复数据
        /// <summary>
        /// 添加回复数据
        /// </summary>
        /// <returns></returns>
        public static int InsertReply(Reply obj)
        {
            int n = DBHelper.ExecuteNonQuery("Insert_Reply", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@R_Datetime",obj.R_Datetime),
                     new SqlParameter("@R_Content",obj.R_Content),
                      new SqlParameter("@Com_No",obj.Com_No)
                });
            return n; ;
        }
        #endregion
        #region 修改回复数据
        /// <summary>
        /// 修改回复数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateReply(Reply obj)
        {
            int n = DBHelper.ExecuteNonQuery("Update_Reply", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@R_Datetime",obj.R_Datetime),
                     new SqlParameter("@R_Content",obj.R_Content),
                      new SqlParameter("@Com_No",obj.Com_No),
                      new SqlParameter("@R_No",obj.R_No)
                });
            return n; ;
        }
        #endregion
        #region 删除回复数据
        /// <summary>
        /// 删除回复数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteReply(Reply obj)
        {
            int n = DBHelper.ExecuteNonQuery("Delete_Reply", CommandType.StoredProcedure,
                new SqlParameter[] {
                      new SqlParameter("@R_No",obj.R_No)
                });
            return n; ;
        } 
        #endregion
    }
}
