using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    /// <summary>
    /// 【文章类型】接口类
    /// </summary>
    public interface IArticleTypeType_Service
    {
        /// <summary>
        /// 获取全部文章类型信息
        /// </summary>
        /// <returns></returns>
        List<ArticleType> GetAllArticleType();
        /// <summary>
        /// 根据条件查询文章类型信息
        /// </summary>
        /// <returns></returns>
        ArticleType GetArticleTypeByConn(ArticleType obj);
        /// <summary>
        /// 添加文章类型数据
        /// </summary>
        /// <returns></returns>
        int InserArticleType(ArticleType obj);
        /// <summary>
        /// 修改文章类型数据
        /// </summary>
        /// <returns></returns>
        int UpdateArticleType(ArticleType obj);
        /// <summary>
        /// 删除文章类型数据
        /// </summary>
        /// <returns></returns>
        int DeleteArticleType(ArticleType obj);
    }
}
