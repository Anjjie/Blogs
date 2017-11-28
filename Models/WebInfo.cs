using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    /// <summary>
    /// 【网站】实体类
    /// </summary>
    public class WebInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Web_No { get; set; }
        /// <summary>
        /// 网站名称
        /// </summary>
        public string Web_Name { get; set; }
        /// <summary>
        /// 网站主页
        /// </summary>
        public string Web_Index { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string Web_Date { get; set; }
    }
}
