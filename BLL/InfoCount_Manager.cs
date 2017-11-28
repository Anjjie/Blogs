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
    /// 【信息统计】业务类
    /// </summary>
    public class InfoCount_Manager
    {
        #region 获取全部信息统计信息
        /// <summary>
        /// 获取全部信息统计信息
        /// </summary>
        /// <returns></returns>
        public static List<InfoCount> GetAllInfoCount()
        {
            return InfoCount_Service.GetAllInfoCount();
        }
        #endregion
        #region 根据条件查询信息统计信息
        /// <summary>
        /// 根据条件查询信息统计信息
        /// </summary>
        /// <param name="demandType">查询类型（实体类中的所有属性选其一）</param>
        /// <param name="demandContent">查询参数（要查询的条件参数）</param>
        /// <returns></returns>
        public static InfoCount GetInfoCountByConn(string demandType, string demandContent)
        {
            return InfoCount_Service.GetInfoCountByConn(demandType, demandContent);
        }
        #endregion
        #region 添加信息统计数据
        /// <summary>
        /// 添加信息统计数据
        /// </summary>
        /// <returns></returns>
        public static int InsertInfoCount(InfoCount obj)
        {
            return InfoCount_Service.InsertInfoCount(obj);
        }
        #endregion
        #region 修改信息统计数据
        /// <summary>
        /// 修改信息统计数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateInfoCount(InfoCount obj)
        {
            return InfoCount_Service.UpdateInfoCount(obj);
        }
        #endregion
        #region 删除信息统计数据
        /// <summary>
        /// 删除信息统计数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteInfoCount(InfoCount obj)
        {
            return InfoCount_Service.DeleteInfoCount(obj);
        }
        #endregion
    }
}
