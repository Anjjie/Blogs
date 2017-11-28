using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 【登录日志】实体类
    /// </summary>
    public class LoginLog
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Log_No { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        public string P_LoginName { get; set; }
        /// <summary>
        /// 个人信息属性对象
        /// </summary>
        public PersonageInfo GetPersonageInfo{get;set;}
        /// <summary>
        /// 登录IP地址
        /// </summary>                
        public string Log_ipAddress { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public string Log_Country { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Log_Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string Log_City { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string Log_Date { get; set; }       
    }
}
