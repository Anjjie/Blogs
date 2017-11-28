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
    /// 【审核】业务类
    /// </summary>
    public class Aduit_Manager
    {
        #region 获取全部审核信息
        /// <summary>
        /// 获取全部审核信息
        /// </summary>
        /// <returns></returns>
        public static List<Aduit> GetAllAduit()
        {
            return Aduit_Service.GetAllAduit();
        }
        #endregion
        #region 根据条件查询审核信息
        /// <summary>
        /// 根据条件查询审核信息
        /// </summary>
        /// <param name="demandType">查询类型（实体类中的所有属性选其一）</param>
        /// <param name="demandContent">查询参数（要查询的条件参数）</param>
        /// <returns></returns>
        public static Aduit GetAduitByConn(string demandType, string demandContent)
        {
            return Aduit_Service.GetAduitByConn(demandType, demandContent);
        }
        #endregion
        #region 添加审核数据
        /// <summary>
        /// 添加审核数据
        /// </summary>
        /// <returns></returns>
        public static int InsertAduit(Aduit obj)
        {
            return Aduit_Service.InsertAduit(obj);
        }
        #endregion
        #region 修改审核数据
        /// <summary>
        /// 修改审核数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateAduit(Aduit obj)
        {
            return Aduit_Service.UpdateAduit(obj);
        }
        #endregion
        #region 删除审核数据
        /// <summary>
        /// 删除审核数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteAduit(Aduit obj)
        {
            return Aduit_Service.DeleteAduit(obj);
        }
        #endregion
    }
}
