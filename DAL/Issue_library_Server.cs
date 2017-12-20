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
    /// 【问题库】服务类
    /// </summary>
    public class Issue_library_Server
    {
        #region 获取全部问题库信息
        /// <summary>
        /// 获取全部问题库信息
        /// </summary>
        /// <returns></returns>
        public static List<Issue_library> GetAllIssue_library()
        {
            List<Issue_library> list = new List<Issue_library>();
            SqlDataReader dr = DBHelper.ExecuteReader("Select_Issue_library", CommandType.StoredProcedure);
            while (dr.Read())
            {
                Issue_library obj = new Issue_library()
                {
                    IssueI_Name = dr["IssueI_Name"].ToString(),
                    IssueI_No = Convert.ToInt32(dr["IssueI_No"])
                };
                list.Add(obj);
            }
            dr.Close();
            DBHelper.CloseCon();
            return list;
        }
        #endregion

        #region 根据条件查询问题库信息
        /// <summary>
        /// 根据条件查询问题库信息
        /// </summary>
        /// <returns></returns>
        public static Issue_library GetIssue_libraryByConn(string demandType, string demandContent)
        {
            string sql = "Select * from Issue_library where " + demandType + " = @" + demandType;
            Issue_library obj = new Issue_library();
            SqlDataReader dr = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter[] {
                new SqlParameter("@" + demandType,demandContent)
            });
            if (dr.Read())
            {
                obj = new Issue_library()
                {
                    IssueI_Name = dr["IssueI_Name"].ToString(),
                    IssueI_No = Convert.ToInt32(dr["IssueI_No"])
                };
            }
            dr.Close();
            DBHelper.CloseCon();
            return obj;
        }
        #endregion
        #region 添加问题库数据
        /// <summary>
        /// 添加问题库数据
        /// </summary>
        /// <returns></returns>
        public static int InsertIssue_library(Issue_library obj)
        {
            int n = DBHelper.ExecuteNonQuery("Insert_Issue_library", CommandType.StoredProcedure,
                new SqlParameter[] {
                      new SqlParameter("@IssueI_Name",obj.IssueI_Name)
                });
            return n;
        }
        #endregion
        #region 修改问题库数据
        /// <summary>
        /// 修改问题库数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateIssue_library(Issue_library obj)
        {
            int n = DBHelper.ExecuteNonQuery("Update_Issue_library", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@IssueI_Name",obj.IssueI_Name),
                    new SqlParameter("@IssueI_No",obj.IssueI_No)
                });
            return n;
        }
        #endregion
        #region 删除问题库数据
        /// <summary>
        /// 删除问题库数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteIssue_library(Issue_library obj)
        {
            int n = DBHelper.ExecuteNonQuery("Delete_Issue_library", CommandType.StoredProcedure,
                new SqlParameter[] {
                   new SqlParameter("@IssueI_No",obj.IssueI_No)
                });
            return n;
        }
        #endregion
    }
}
