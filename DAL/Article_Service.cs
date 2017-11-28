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
    /// 【文章】服务类
    /// </summary>
    public class Article_Service
    {
        #region 获取全部文章信息
        /// <summary>
        /// 获取全部文章信息
        /// </summary>
        /// <returns></returns>
        public static List<Article> GetAllArticle()
        {
            List<Article> list = new List<Article>();
            SqlDataReader dr = DBHelper.ExecuteReader("Select_Article", CommandType.StoredProcedure);
            while (dr.Read())
            {
                Article article = new Article() {
                    A_Author=dr["A_Author"].ToString(),
                    A_Content = dr["A_Content"].ToString(),
                    A_DateTime = dr["A_DateTime"].ToString(),
                    A_No = Convert.ToInt32( dr["A_No"]),
                    A_Title = dr["A_Title"].ToString(),
                    A_TypeName = dr["A_TypeName"].ToString()
                };
                list.Add(article);
            }
            dr.Close();
            DBHelper.CloseCon();
            return list;
        }
        #endregion

        #region 获取全部文章信息（编号[从大到小]）
        /// <summary>
        /// 获取全部文章信息（编号[从大到小]）
        /// </summary>
        /// <returns></returns>
        public static List<Article> GetArticleAllByDesc()
        {
            List<Article> list = new List<Article>();
            SqlDataReader dr = DBHelper.ExecuteReader("Select_ArticleAllByDesc", CommandType.StoredProcedure);
            while (dr.Read())
            {
                Article article = new Article()
                {
                    A_Author = dr["A_Author"].ToString(),
                    A_Content = dr["A_Content"].ToString(),
                    A_DateTime = dr["A_DateTime"].ToString(),
                    A_No = Convert.ToInt32(dr["A_No"]),
                    A_Title = dr["A_Title"].ToString(),
                    A_TypeName = dr["A_TypeName"].ToString()
                };
                list.Add(article);
            }
            dr.Close();
            DBHelper.CloseCon();
            return list;
        }
        #endregion

        #region 根据条件查询文章信息
        /// <summary>
        /// 根据条件查询文章信息
        /// </summary>
        /// <returns></returns>
        public static Article GetArticleByConn(string demandType, string demandContent)
        {
            string sql = "Select * from Article where " + demandType + " = @" + demandType; 
            Article article = new Article();
            SqlDataReader dr = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter[] {
                new SqlParameter("@" + demandType,demandContent)
            });
            if (dr.Read())
            {
                article = new Article()
                {
                    A_Author = dr["A_Author"].ToString(),
                    A_Content = dr["A_Content"].ToString(),
                    A_DateTime = dr["A_DateTime"].ToString(),
                    A_No = Convert.ToInt32(dr["A_No"]),
                    A_Title = dr["A_Title"].ToString(),
                    A_TypeName = dr["A_TypeName"].ToString()
                };
            }
            dr.Close();
            DBHelper.CloseCon();
            return article;
        }
        #endregion

        #region 添加文章数据
        /// <summary>
        /// 添加文章数据
        /// </summary>
        /// <returns></returns>
        public static int InsertArticle(Article obj)
        {
            int n = DBHelper.ExecuteNonQuery("Insert_Article",CommandType.StoredProcedure,new SqlParameter[] {
                new SqlParameter("@A_Author",obj.A_Author),
                new SqlParameter("@A_Content",obj.A_Content),
                new SqlParameter("@A_DateTime",obj.A_DateTime),
                new SqlParameter("@A_Title",obj.A_Title),
                new SqlParameter("@A_TypeName",obj.A_TypeName)
            });
            return n;
        }
        #endregion

        #region 修改文章数据
        /// <summary>
        /// 修改文章数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateArticle(Article obj)
        {
            int n = DBHelper.ExecuteNonQuery("Update_Article", CommandType.StoredProcedure, new SqlParameter[] {
                new SqlParameter("@A_Author",obj.A_Author),
                new SqlParameter("@A_Content",obj.A_Content),
                new SqlParameter("@A_DateTime",obj.A_DateTime),
                new SqlParameter("@A_Title",obj.A_Title),
                new SqlParameter("@A_TypeName",obj.A_TypeName),
                new SqlParameter("@A_No",obj.A_No)
            });
            return n;
        }
        #endregion

        #region 删除文章数据
        /// <summary>
        /// 删除文章数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteArticle(Article obj)
        {
            int n = DBHelper.ExecuteNonQuery("Delect_Article", CommandType.StoredProcedure, new SqlParameter[] {
                new SqlParameter("@A_No",obj.A_No)
            });
            return n;
        } 
        #endregion
    }
}
