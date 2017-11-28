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
    /// 【文章类型】业务类
    /// </summary>
    public class ArticleType_Manager
    {
        #region 获取全部文章类型信息
        /// <summary>
        /// 获取全部文章类型信息
        /// </summary>
        /// <returns></returns>
        public static List<ArticleType> GetAllArticleType()
        {
            return ArticleType_Service.GetAllArticleType();
        }
        #endregion
        #region 根据条件查询文章类型信息
        /// <summary>
        /// 根据条件查询文章类型信息
        /// </summary>
        /// <param name="demandType">查询类型（实体类中的所有属性选其一）</param>
        /// <param name="demandContent">查询参数（要查询的条件参数）</param>
        /// <returns></returns>
        public static ArticleType GetArticleTypeByConn(string demandType, string demandContent)
        {
            return ArticleType_Service.GetArticleTypeByConn(demandType, demandContent);
        }
        #endregion
        #region 添加文章类型数据
        /// <summary>
        /// 添加文章类型数据
        /// </summary>
        /// <returns></returns>
        public static int InsertArticleType(ArticleType obj)
        {
            return ArticleType_Service.InsertArticleType(obj);
        }
        #endregion
        #region 修改文章类型数据
        /// <summary>
        /// 修改文章类型数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateArticleType(ArticleType obj)
        {
            return ArticleType_Service.UpdateArticleType(obj);
        }
        #endregion
        #region 删除文章类型数据
        /// <summary>
        /// 删除文章类型数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteArticleType(ArticleType obj)
        {
            return ArticleType_Service.DeleteArticleType(obj);
        }
        #endregion
    }
}
