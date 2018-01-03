using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 【文章】实体类
    /// </summary>
    public class Article
    {
        /// <summary>
        /// 文章编号
        /// </summary>
        public int A_No { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string A_Title { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string A_Content { get; set; }
        /// <summary>
        /// 文章类型
        /// </summary>
        public string A_TypeName { get; set; }
        /// <summary>
        /// 文章类型对象属性
        /// </summary>
        public ArticleType GetArticleType { get; set; }
        /// <summary>
        /// 文章发布时间
        /// </summary>
        public string A_DateTime { get; set; }
        /// <summary>
        /// 文章作者
        /// </summary>
        public string A_Author { get; set; }
        /// <summary>
        /// 封面图片
        /// </summary>
        public string A_CoverImageUrl { get; set; }

    }
}
