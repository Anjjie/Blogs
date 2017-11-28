using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 【评价】实体类
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// 评价编号
        /// </summary>
        public int Com_No { get; set; }
        /// <summary>
        /// 评价文章编号
        /// </summary>
        public int A_No { get; set; }
        /// <summary>
        /// 文章对象属性
        /// </summary>
        public Article GetArticle { get; set; }
        /// <summary>
        /// 评价昵称
        /// </summary>
        public string  NickName { get; set; }
        /// <summary>
        /// 评价内容
        /// </summary>
        public string Com_Content { get; set; }
        /// <summary>
        /// 评价时间
        /// </summary>
        public string Com_Datetime { get; set; }
        /// <summary>
        /// 审核编号
        /// </summary>
        public int Aduit_No { get; set; }
        /// <summary>
        /// 审核对象属性
        /// </summary>
        public Aduit GetAduit { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string Com_Cause { get; set; }
    }
}
