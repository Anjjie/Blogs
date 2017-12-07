using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 【密保问题】实体类
    /// </summary>
    public class Issue
    {
        /// <summary>
        /// 密保序号
        /// </summary>
        public int Issue_No { get; set; }
        /// <summary>
        /// 绑定密保账号
        /// </summary>
        public string P_LoginName { get; set; }
        /// <summary>
        /// 问题1
        /// </summary>
        public string Issue_1 { get; set; }
        /// <summary>
        /// 问题2
        /// </summary>
        public string Issue_2 { get; set; }
        /// <summary>
        /// 问题3
        /// </summary>
        public string Issue_3 { get; set; }
        /// <summary>
        /// 答案1
        /// </summary>
        public string Answer_1 { get; set; }
        /// <summary>
        /// 答案2
        /// </summary>
        public string Answer_2 { get; set; }
        /// <summary>
        /// 答案3
        /// </summary>
        public string Answer_3 { get; set; }
    }
}
