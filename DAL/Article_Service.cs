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
        //public static List<Article> GetAllArticle()
        //{
        //    List<Article> list = new List<Article>();
        //    SqlDataReader dr = DBHelper.ExecuteReader("Select_Article", CommandType.StoredProcedure);
        //    while (dr.Read())
        //    {
        //        Article article = new Article() {
        //            A_Author=dr["A_Author"].ToString(),
        //            A_Content = dr["A_Content"].ToString(),
        //            A_DateTime = dr["A_DateTime"].ToString(),
        //            A_No = Convert.ToInt32( dr["A_No"]),
        //            A_Title = dr["A_Title"].ToString(),
        //            A_TypeName = dr["A_TypeName"].ToString()
        //        };
        //        list.Add(article);
        //    }
        //    dr.Close();
        //    DBHelper.CloseCon();
        //    return list;
        //}
        public static List<Article> GetAllArticle()
        {
            List<Article> list = new List<Article>();
            DataSet ds = DBHelper.GetDataSet("Select_Article", CommandType.StoredProcedure);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Article article = new Article()
                {
                    A_Author = dr["A_Author"].ToString(),
                    A_Content = dr["A_Content"].ToString(),
                    A_DateTime = dr["A_DateTime"].ToString(),
                    A_No = Convert.ToInt32(dr["A_No"]),
                    A_Title = dr["A_Title"].ToString(),
                    A_TypeName = dr["A_TypeName"].ToString(),
                    A_CoverImageUrl = dr["A_CoverImageUrl"].ToString()
                };
                list.Add(article);
            }
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
            DataSet ds = DBHelper.GetDataSet("Select_ArticleAllByDesc", CommandType.StoredProcedure);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Article article = new Article()
                {
                    A_Author = dr["A_Author"].ToString(),
                    A_Content = dr["A_Content"].ToString(),
                    A_DateTime = dr["A_DateTime"].ToString(),
                    A_No = Convert.ToInt32(dr["A_No"]),
                    A_Title = dr["A_Title"].ToString(),
                    A_TypeName = dr["A_TypeName"].ToString(),
                    A_CoverImageUrl = dr["A_CoverImageUrl"].ToString()
                };
                list.Add(article);
            }
            return list;
        }
        #endregion

        #region 分页查询文章信息
        /// <summary>
        /// 分页查询文章信息
        /// </summary>
        /// <param name="pageNo">当前页编号</param>
        /// <param name="pageSize">每页显示数</param>
        /// <returns></returns>
        public static List<Article> GetArticlePaging(int pageNo, int pageSize)
        {
            List<Article> list = new List<Article>();

            DataSet ds = DBHelper.GetDataSet("Select_ArticlePaging", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@pageNo",pageNo),
                    new SqlParameter("@pageSize",pageSize)
                });

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Article obj = new Article()
                {
                    A_Author = dr["A_Author"].ToString(),
                    A_Content = dr["A_Content"].ToString(),
                    A_DateTime = dr["A_DateTime"].ToString(),
                    A_No = Convert.ToInt32(dr["A_No"]),
                    A_Title = dr["A_Title"].ToString(),
                    A_TypeName = dr["A_TypeName"].ToString(),
                    A_CoverImageUrl = dr["A_CoverImageUrl"].ToString()
                };
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region 分页查询文章信息：条件
        /// <summary>
        /// 分页查询文章信息：条件
        /// </summary>
        /// <param name="pageNo">当前页编号</param>
        /// <param name="pageSize">每页显示数</param>
        /// <returns></returns>
        public static List<Article> GetArticlePagingByConn(int pageNo, int pageSize,string conn)
        {
            List<Article> list = new List<Article>();

            DataSet ds = DBHelper.GetDataSet("Select_ArticlePagingByConn", CommandType.StoredProcedure,
                new SqlParameter[] {
                     new SqlParameter("@Conn",conn),
                    new SqlParameter("@pageNo",pageNo),
                    new SqlParameter("@pageSize",pageSize)
                });

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Article obj = new Article()
                {
                    A_Author = dr["A_Author"].ToString(),
                    A_Content = dr["A_Content"].ToString(),
                    A_DateTime = dr["A_DateTime"].ToString(),
                    A_No = Convert.ToInt32(dr["A_No"]),
                    A_Title = dr["A_Title"].ToString(),
                    A_TypeName = dr["A_TypeName"].ToString(),
                    A_CoverImageUrl = dr["A_CoverImageUrl"].ToString()
                };
                list.Add(obj);
            }
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
                    A_TypeName = dr["A_TypeName"].ToString(),
                    A_CoverImageUrl = dr["A_CoverImageUrl"].ToString()
                };
            }
            dr.Close();
            DBHelper.CloseCon();
            return article;
        }
        #endregion

        #region 根据条件查询文章信息:多条
        /// <summary>
        /// 根据条件查询文章信息:多条
        /// </summary>
        /// <returns></returns>
        public static List<Article> GetArticleByConns(string demandType, string demandContent)
        {
            List<Article> list = new List<Article>();
            string sql = "Select * from Article where " + demandType + " = @" + demandType;
            Article article = new Article();
            SqlDataReader dr = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter[] {
                new SqlParameter("@" + demandType,demandContent)
            });
            while(dr.Read())
            {
                article = new Article()
                {
                    A_Author = dr["A_Author"].ToString(),
                    A_Content = dr["A_Content"].ToString(),
                    A_DateTime = dr["A_DateTime"].ToString(),
                    A_No = Convert.ToInt32(dr["A_No"]),
                    A_Title = dr["A_Title"].ToString(),
                    A_TypeName = dr["A_TypeName"].ToString(),
                    A_CoverImageUrl = dr["A_CoverImageUrl"].ToString()
                };
                list.Add(article);
            }
            dr.Close();
            DBHelper.CloseCon();
            
            return list;
        }
        #endregion

        #region 分页显示：全部相关查询列条件
        /// <summary>
        /// 分页显示：全部相关查询列条件
        /// </summary>
        /// <param name="pageNo">当前页编号</param>
        /// <param name="pageSize">每页显示数</param>
        /// <returns></returns>
        public static List<Article> Select_ArticleDescPagingByConn(int pageNo, int pageSize, string conn)
        {
            List<Article> list = new List<Article>();

            DataSet ds = DBHelper.GetDataSet("Select_ArticleDescPagingByConn", CommandType.StoredProcedure,
                new SqlParameter[] {
                     new SqlParameter("@Conn","%"+conn+"%"),
                      new SqlParameter("@pageNo",pageNo),
                    new SqlParameter("@pageSize",pageSize)
                });

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Article obj = new Article()
                {
                    A_Author = dr["A_Author"].ToString(),
                    A_Content = dr["A_Content"].ToString(),
                    A_DateTime = dr["A_DateTime"].ToString(),
                    A_No = Convert.ToInt32(dr["A_No"]),
                    A_Title = dr["A_Title"].ToString(),
                    A_TypeName = dr["A_TypeName"].ToString(),
                    A_CoverImageUrl = dr["A_CoverImageUrl"].ToString()
                };
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region 显示全部：全部相关查询列条件
        /// <summary>
        /// 显示全部：全部相关查询列条件
        /// </summary>
        /// <returns></returns>
        public static List<Article> Select_ArticleDescCorrelationByConn(string conn)
        {
            List<Article> list = new List<Article>();

            DataSet ds = DBHelper.GetDataSet("Select_ArticleDescCorrelationByConn", CommandType.StoredProcedure,
                new SqlParameter[] {
                     new SqlParameter("@Conn","%"+conn+"%")
                });

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Article obj = new Article()
                {
                    A_Author = dr["A_Author"].ToString(),
                    A_Content = dr["A_Content"].ToString(),
                    A_DateTime = dr["A_DateTime"].ToString(),
                    A_No = Convert.ToInt32(dr["A_No"]),
                    A_Title = dr["A_Title"].ToString(),
                    A_TypeName = dr["A_TypeName"].ToString(),
                    A_CoverImageUrl = dr["A_CoverImageUrl"].ToString()
                };
                list.Add(obj);
            }
            return list;
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
                new SqlParameter("@A_TypeName",obj.A_TypeName),
                 new SqlParameter("@A_CoverImageUrl",obj.A_CoverImageUrl)
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
                new SqlParameter("@A_No",obj.A_No),
                 new SqlParameter("@A_CoverImageUrl",obj.A_CoverImageUrl)
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
            int n = DBHelper.ExecuteNonQuery("Delete_Article", CommandType.StoredProcedure, new SqlParameter[] {
                new SqlParameter("@A_No",obj.A_No)
            });
            return n;
        }
        #endregion

        #region 删除多条文章数据
        /// <summary>
        /// 删除文章数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteArticleMore(string MoreNo)
        {
            int n = DBHelper.ExecuteNonQuery("Delete from Article where A_No in ("+ MoreNo + ")", CommandType.Text);
            return n;
        }
        #endregion

    }
}
