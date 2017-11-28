using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    /// <summary>
    /// 【网站信息】接口类
    /// </summary>
    public interface IWebInfo_Service
    {
        /// <summary>
        /// 获取全部网站信息
        /// </summary>
        /// <returns></returns>
        List<WebInfo> GetAllWebInfo();
        /// <summary>
        /// 根据条件查询网站信息
        /// </summary>
        /// <returns></returns>
        WebInfo GetWebInfoByConn(WebInfo obj);
        /// <summary>
        /// 添加网站数据
        /// </summary>
        /// <returns></returns>
        int InserWebInfo(WebInfo obj);
        /// <summary>
        /// 修改网站数据
        /// </summary>
        /// <returns></returns>
        int UpdateWebInfo(WebInfo obj);
        /// <summary>
        /// 删除网站数据
        /// </summary>
        /// <returns></returns>
        int DeleteWebInfo(WebInfo obj);
    }
}
