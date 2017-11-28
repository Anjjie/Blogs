using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    /// <summary>
    /// 【文章】接口类
    /// </summary>
    public interface IArticle_Service
    {
        /// <summary>
        /// 获取全部文章信息
        /// </summary>
        /// <returns></returns>
        List<Article> GetAllArticle();
        /// <summary>
        /// 根据条件查询文章信息
        /// </summary>
        /// <returns></returns>
        Article GetArticleByConn(Article obj);
        /// <summary>
        /// 添加文章数据
        /// </summary>
        /// <returns></returns>
        int InserArticle(Article obj);
        /// <summary>
        /// 修改文章数据
        /// </summary>
        /// <returns></returns>
        int UpdateArticle(Article obj);
        /// <summary>
        /// 删除文章数据
        /// </summary>
        /// <returns></returns>
        int DeleteArticle(Article obj);
    }
}
