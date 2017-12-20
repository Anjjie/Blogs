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
    /// 【密保问题】服务类
    /// </summary>
    public class Issue_Server
    {
        #region 获取全部密保问题信息
        /// <summary>
        /// 获取全部密保问题信息
        /// </summary>
        /// <returns></returns>
        public static List<Issue> GetAllIssue()
        {
            List<Issue> list = new List<Issue>();
            SqlDataReader dr = DBHelper.ExecuteReader("Select_Issue", CommandType.StoredProcedure);
            while (dr.Read())
            {
                Issue obj = new Issue()
                {
                    P_LoginName = dr["P_LoginName"].ToString(),
                    Issue_No = Convert.ToInt32(dr["Issue_No"]),
                    Answer_1 = dr["Answer_1"].ToString(),
                    Answer_2 = dr["Answer_2"].ToString(),
                    Answer_3 = dr["Answer_3"].ToString(),
                    Issue_1 = dr["Issue_1"].ToString(),
                    Issue_2 = dr["Issue_2"].ToString(),
                    Issue_3 = dr["Issue_3"].ToString()
                };
                list.Add(obj);
            }
            dr.Close();
            DBHelper.CloseCon();
            return list;
        }
        #endregion

        #region 根据条件查询密保问题信息
        /// <summary>
        /// 根据条件查询密保问题信息
        /// </summary>
        /// <returns></returns>
        public static Issue GetIssueByConn(string demandType, string demandContent)
        {
            string sql = "Select * from Issue where " + demandType + " = @" + demandType;
            Issue obj = new Issue();
            SqlDataReader dr = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter[] {
                new SqlParameter("@" + demandType,demandContent)
            });
            if (dr.Read())
            {
                obj = new Issue()
                {
                    P_LoginName = dr["P_LoginName"].ToString(),
                    Issue_No = Convert.ToInt32(dr["Issue_No"]),
                    Answer_1 = dr["Answer_1"].ToString(),
                    Answer_2 = dr["Answer_2"].ToString(),
                    Answer_3 = dr["Answer_3"].ToString(),
                    Issue_1 = dr["Issue_1"].ToString(),
                    Issue_2 = dr["Issue_2"].ToString(),
                    Issue_3 = dr["Issue_3"].ToString()
                };
            }
            dr.Close();
            DBHelper.CloseCon();
            return obj;
        }
        #endregion
        #region 添加密保问题数据
        /// <summary>
        /// 添加密保问题数据
        /// </summary>
        /// <returns></returns>
        public static int InsertIssue(Issue obj)
        {
            int n = DBHelper.ExecuteNonQuery("Insert_Issue", CommandType.StoredProcedure,
                new SqlParameter[] {
                      new SqlParameter("@P_LoginName",obj.P_LoginName),
                      new SqlParameter("@Answer_1",obj.Answer_1),
                      new SqlParameter("@Answer_2",obj.Answer_2),
                      new SqlParameter("@Answer_3",obj.Answer_3),
                      new SqlParameter("@Issue_1",obj.Issue_1),
                      new SqlParameter("@Issue_2",obj.Issue_2),
                      new SqlParameter("@Issue_3",obj.Issue_3)
                });
            return n;
        }
        #endregion
        #region 修改密保问题数据
        /// <summary>
        /// 修改密保问题数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateIssue(Issue obj)
        {
            int n = DBHelper.ExecuteNonQuery("Update_Issue", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@P_LoginName",obj.P_LoginName),
                      new SqlParameter("@Answer_1",obj.Answer_1),
                      new SqlParameter("@Answer_2",obj.Answer_2),
                      new SqlParameter("@Answer_3",obj.Answer_3),
                      new SqlParameter("@Issue_1",obj.Issue_1),
                      new SqlParameter("@Issue_2",obj.Issue_2),
                      new SqlParameter("@Issue_3",obj.Issue_3)
                });
            return n;
        }
        #endregion
        #region 删除密保问题数据
        /// <summary>
        /// 删除密保问题数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteIssue(Issue obj)
        {
            int n = DBHelper.ExecuteNonQuery("Delete_Issue", CommandType.StoredProcedure,
                new SqlParameter[] {
                   new SqlParameter("@Issue_No",obj.Issue_No)
                });
            return n;
        }
        #endregion
    }
}
