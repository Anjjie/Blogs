using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    /// <summary>
    /// 【网站信息】业务类
    /// </summary>
    public class WebInfo_Manager
    {

        #region 获取全部网站信息
        /// <summary>
        /// 获取全部网站信息
        /// </summary>
        /// <returns></returns>
        public static List<WebInfo> GetAllWebInfo()
        {
            return WebInfo_Service.GetAllWebInfo();
        }
        #endregion

        #region 根据条件查询网站信息
        /// <summary>
        /// 根据条件查询网站信息
        /// </summary>
        /// <param name="demandType">查询类型（实体类中的所有属性选其一）</param>
        /// <param name="demandContent">查询参数（要查询的条件参数）</param>
        /// <returns></returns>
        public static WebInfo GetWebInfoByConn(string demandType, string demandContent)
        {
            return WebInfo_Service.GetWebInfoByConn(demandType, demandContent);
        }
        #endregion

        #region 添加网站数据
        /// <summary>
        /// 添加网站数据
        /// </summary>
        /// <returns></returns>
        public static int InsertWebInfo(WebInfo obj)
        {
            return WebInfo_Service.InsertWebInfo(obj);
        }
        #endregion

        #region 修改网站数据
        /// <summary>
        /// 修改网站数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateWebInfo(WebInfo obj)
        {
            return WebInfo_Service.UpdateWebInfo(obj);
        }
        #endregion

        #region 删除网站数据
        /// <summary>
        /// 删除网站数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteWebInfo(WebInfo obj)
        {
            return WebInfo_Service.DeleteWebInfo(obj);
        }
        #endregion
    }
}
