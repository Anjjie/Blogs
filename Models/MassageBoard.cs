using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 【留言】实体类
    /// </summary>
    public class MassageBoard
    {
        
        /// <summary>
        /// 留言编号
        /// </summary>
        public int Mb_No { get; set; }
        /// <summary>
        /// 留言昵称
        /// </summary>
        public string Mb_NickName { get; set; }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string Mb_Content { get; set; }
        /// <summary>
        /// 留言时间
        /// </summary>
        public string Mb_Datetime { get; set; }
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
        public string Mb_Cause { get; set; }
    }
}
