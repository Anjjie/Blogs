using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using IDAL;
using Models;

namespace DAL
{
    /// <summary>
    /// 【评价】服务类
    /// </summary>
    public class Comment_Service
    {
        #region 获取全部评价信息
        /// <summary>
        /// 获取全部评价信息
        /// </summary>
        /// <returns></returns>
        public static List<Comment> GetAllComment()
        {
            List<Comment> list = new List<Comment>();
            SqlDataReader dr = DBHelper.ExecuteReader("Select_Comment",CommandType.StoredProcedure);
            while (dr.Read())
            {
                Comment comment = new Comment() {
                    Aduit_No=Convert.ToInt32( dr["Aduit_No"]),
                    A_No = Convert.ToInt32(dr["A_No"]),
                    Com_Cause= dr["Com_Cause"].ToString(),
                    Com_Datetime = dr["Com_Datetime"].ToString(),
                    Com_Content = dr["Com_Content"].ToString(),
                    Com_No = Convert.ToInt32(dr["Com_No"]),
                    NickName = dr["NickName"].ToString()
                    
                };
                list.Add(comment);
            }
            dr.Close();
            DBHelper.CloseCon();
            return list;
        }
        #endregion
        #region 根据条件查询评价信息
        /// <summary>
        /// 根据条件查询评价信息
        /// </summary>
        /// <returns></returns>
        public static Comment GetCommentByConn(string demandType, string demandContent)
        {
            string sql = "Select * from Comment where" + demandType + " = @" + demandType;
            Comment comment = new Comment();
            SqlDataReader dr = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter[] {
                new SqlParameter("@" + demandType,demandContent)
            });
            if (dr.Read())
            {
                comment = new Comment()
                {
                    Aduit_No = Convert.ToInt32(dr["Aduit_No"]),
                    A_No = Convert.ToInt32(dr["A_No"]),
                    Com_Cause = dr["Com_Cause"].ToString(),
                    Com_Datetime = dr["Com_Datetime"].ToString(),
                    Com_Content = dr["Com_Content"].ToString(),
                    Com_No = Convert.ToInt32(dr["Com_No"]),
                    NickName = dr["NickName"].ToString()
                };
            }
            dr.Close();
            DBHelper.CloseCon();
            return comment;
        }
        #endregion
        #region 添加评价数据
        /// <summary>
        /// 添加评价数据
        /// </summary>
        /// <returns></returns>
        public static int InsertComment(Comment obj)
        {
            int n = DBHelper.ExecuteNonQuery("Insert_Comment",CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@Aduit_No",obj.Aduit_No),
                    new SqlParameter("@A_No",obj.A_No),
                    new SqlParameter("@Com_Cause",obj.Com_Cause),
                    new SqlParameter("@Com_Datetime",obj.Com_Datetime),
                    new SqlParameter("@Com_Content",obj.Com_Content),
                    new SqlParameter("@NickName",obj.NickName)
                });
            return n;
        }
        #endregion
        #region 修改评价数据
        /// <summary>
        /// 修改评价数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateComment(Comment obj)
        {
            int n = DBHelper.ExecuteNonQuery("Update_Comment", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@Aduit_No",obj.Aduit_No),
                    new SqlParameter("@A_No",obj.A_No),
                    new SqlParameter("@Com_Cause",obj.Com_Cause),
                    new SqlParameter("@Com_Datetime",obj.Com_Datetime),
                    new SqlParameter("@Com_Content",obj.Com_Content),
                    new SqlParameter("@Com_Content",obj.Com_No),
                    new SqlParameter("@NickName",obj.NickName)
                });
            return n;
        }
        #endregion
        #region 删除评价数据
        /// <summary>
        /// 删除评价数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteComment(Comment obj)
        {
            int n = DBHelper.ExecuteNonQuery("Delect_Comment", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@Com_Content",obj.Com_No)
                });
            return n;
        } 
        #endregion
    }
}
