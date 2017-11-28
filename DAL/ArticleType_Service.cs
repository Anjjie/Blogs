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
    /// 【文章类型】服务类
    /// </summary>
    public class ArticleType_Service
    {
        #region 获取全部文章类型信息
        /// <summary>
        /// 获取全部文章类型信息
        /// </summary>
        /// <returns></returns>
        public static List<ArticleType> GetAllArticleType()
        {
            List<ArticleType> list = new List<ArticleType>();
            SqlDataReader dr = DBHelper.ExecuteReader("Select_ArticleType",CommandType.StoredProcedure);
            while (dr.Read())
            {
                ArticleType atype = new ArticleType() {
                    At_Name = dr["At_Name"].ToString(),
                    At_No = Convert.ToInt32(dr["At_No"])
                };
                list.Add(atype);
            }
            dr.Close();
            DBHelper.CloseCon();
            return list;
        }
        #endregion
        #region 根据条件查询文章类型信息
        /// <summary>
        /// 根据条件查询文章类型信息
        /// </summary>
        /// <returns></returns>
        public static ArticleType GetArticleTypeByConn(string demandType, string demandContent)
        {
            string sql = "Select * from ArticleType where " + demandType + " = @" + demandType;
            ArticleType articleType = new ArticleType();
            SqlDataReader dr = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter[] {
                new SqlParameter("@" + demandType,demandContent)
            });
            if (dr.Read())
            {
                articleType = new ArticleType()
                {
                    At_Name = dr["At_Name"].ToString(),
                    At_No = Convert.ToInt32(dr["At_No"])
                };
            }
            dr.Close();
            DBHelper.CloseCon();
            return articleType;
        }
        #endregion
        #region 添加文章类型数据
        /// <summary>
        /// 添加文章类型数据
        /// </summary>
        /// <returns></returns>
        public static int InsertArticleType(ArticleType obj)
        {
            int n = DBHelper.ExecuteNonQuery("Insert_ArticleType",CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@At_Name",obj.At_Name)
                });
            return n;
        }
        #endregion
        #region 修改文章类型数据
        /// <summary>
        /// 修改文章类型数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateArticleType(ArticleType obj)
        {
            int n = DBHelper.ExecuteNonQuery("Insert_ArticleType", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@At_Name",obj.At_Name),
                    new SqlParameter("@At_No",obj.At_No)
                });
            return n;
        }
        #endregion
        #region 删除文章类型数据
        /// <summary>
        /// 删除文章类型数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteArticleType(ArticleType obj)
        {
            int n = DBHelper.ExecuteNonQuery("Insert_ArticleType", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@At_No",obj.At_No)
                });
            return n;
        } 
        #endregion
    }
}
