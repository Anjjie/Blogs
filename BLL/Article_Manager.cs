using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    /// <summary>
    /// 【文章】业务类
    /// </summary>
    public class Article_Manager
    {
        #region 获取全部文章信息
        /// <summary>
        /// 获取全部文章信息
        /// </summary>
        /// <returns></returns>
        public static List<Article> GetAllArticle()
        {
            List<Article> list= new List<Article> ();
            foreach (Article obj in Article_Service.GetAllArticle())
            {
                obj.GetArticleType = ArticleType_Manager.GetArticleTypeByConn("At_Name", obj.A_TypeName);
                list.Add(obj);
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
            foreach (Article obj in Article_Service.GetArticleAllByDesc())
            {
                obj.GetArticleType = ArticleType_Manager.GetArticleTypeByConn("At_Name", obj.A_TypeName);
                list.Add(obj);
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
            foreach (Article obj in Article_Service.GetArticlePaging(pageNo, pageSize))
            {
                obj.GetArticleType = ArticleType_Manager.GetArticleTypeByConn("At_Name", obj.A_TypeName);
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
        public static List<Article> GetArticlePagingByConn(int pageNo, int pageSize, string conn)
        {
            List<Article> list = new List<Article>();
            foreach (Article obj in Article_Service.GetArticlePagingByConn(pageNo, pageSize, conn))
            {
                obj.GetArticleType = ArticleType_Manager.GetArticleTypeByConn("At_Name", obj.A_TypeName);
                list.Add(obj);
            }
            return list;
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
            foreach (Article obj in Article_Service.GetArticleByConns(demandType, demandContent))
            {
                obj.GetArticleType = ArticleType_Manager.GetArticleTypeByConn("At_Name", obj.A_TypeName);
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region 查询全部有关的数据：条件
        /// <summary>
        /// 查询全部有关的数据：条件
        /// </summary>
        /// <param name="pageNo">当前页编号</param>
        /// <param name="pageSize">每页显示数</param>
        /// <returns></returns>
        public static List<Article> Select_ArticleDescPagingByConn(int pageNo, int pageSize, string conn)
        {
            List<Article> list = new List<Article>();
            foreach (Article obj in Article_Service.Select_ArticleDescPagingByConn(pageNo, pageSize, conn))
            {
                obj.GetArticleType = ArticleType_Manager.GetArticleTypeByConn("At_Name", obj.A_TypeName);
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
            foreach (Article obj in Article_Service.Select_ArticleDescCorrelationByConn( conn))
            {
                obj.GetArticleType = ArticleType_Manager.GetArticleTypeByConn("At_Name", obj.A_TypeName);
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region 根据条件查询文章信息
        /// <summary>
        /// 根据条件查询文章信息
        /// </summary>
        /// <param name="demandType">查询类型（实体类中的所有属性选其一）</param>
        /// <param name="demandContent">查询参数（要查询的条件参数）</param>
        /// <returns></returns>
        public static Article GetArticleByConn(string demandType, string demandContent)
        {
            Article obj= Article_Service.GetArticleByConn(demandType, demandContent);
            obj.GetArticleType = ArticleType_Manager.GetArticleTypeByConn("At_Name", obj.A_TypeName);
            return obj;
        }
        #endregion
        #region 添加文章数据
        /// <summary>
        /// 添加文章数据
        /// </summary>
        /// <returns></returns>
        public static int InsertArticle(Article obj)
        {
            return Article_Service.InsertArticle(obj);
        }
        #endregion
        #region 修改文章数据
        /// <summary>
        /// 修改文章数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateArticle(Article obj)
        {
            return Article_Service.UpdateArticle(obj);
        }
        #endregion
        #region 删除文章数据
        /// <summary>
        /// 删除文章数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteArticle(Article obj)
        {
            return Article_Service.DeleteArticle(obj);
        }
        #endregion

        #region 删除多条文章数据
        /// <summary>
        /// 删除文章数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteArticleMore(string MoreNo)
        {
            return Article_Service.DeleteArticleMore(MoreNo); 
        }
        #endregion

    }
}
