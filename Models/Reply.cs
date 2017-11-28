using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 【回复】实体类
    /// </summary>
    public class Reply
    {
        /// <summary>
        /// 回复序号
        /// </summary>
        public int R_No { get; set; }
        /// <summary>
        /// 评论序号
        /// </summary>
        public int Com_No { get; set; }
        /// <summary>
        /// 评论对象属性
        /// </summary>
        public Comment GetComment { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string R_Content { get; set; }
        /// <summary>
        /// 回复时间
        /// </summary>
        public string R_Datetime { get; set; }
    }
}
