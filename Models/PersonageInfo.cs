using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 【个人信息】实体类
    /// </summary>
    public class PersonageInfo
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string P_LoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string P_LoginPwd { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string P_Head { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string P_Phone { get; set; }
        /// <summary>
        /// 站长说明
        /// </summary>
        public string P_MyExplain { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string P_DataTime { get; set; }
    }
}
