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
    /// 【登录日志】业务类
    /// </summary>
    public class LoginLog_Manager
    {
        #region 获取全部登录日志信息
        /// <summary>
        /// 获取全部登录日志信息
        /// </summary>
        /// <returns></returns>
        public static List<LoginLog> GetAllLoginLog()
        {
            List<LoginLog> list = new List<LoginLog>();
            foreach (LoginLog obj in LoginLog_Service.GetAllLoginLog())
            {
                obj.GetPersonageInfo = PersonageInfo_Manager.GetPersonageInfoByConn("P_LoginName", obj.P_LoginName);
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region 获取全部登录日志信息（按序号从大到小排序）
        /// <summary>
        /// 获取全部登录日志信息（按序号从大到小排序）
        /// </summary>
        /// <returns></returns>
        public static List<LoginLog> GetAllLoginLogByDesc(string LoginName)
        {
            List<LoginLog> list = new List<LoginLog>();
            foreach (LoginLog obj in LoginLog_Service.GetAllLoginLogByDesc(LoginName))
            {
                obj.GetPersonageInfo = PersonageInfo_Manager.GetPersonageInfoByConn("P_LoginName", obj.P_LoginName);
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region 根据条件查询登录日志信息
        /// <summary>
        /// 根据条件查询登录日志信息
        /// </summary>
        /// <param name="demandType">查询类型（实体类中的所有属性选其一）</param>
        /// <param name="demandContent">查询参数（要查询的条件参数）</param>
        /// <returns></returns>
        public static LoginLog GetLoginLogByConn(string demandType, string demandContent)
        {
            LoginLog obj = LoginLog_Service.GetLoginLogByConn(demandType, demandContent);
            obj.GetPersonageInfo = PersonageInfo_Manager.GetPersonageInfoByConn("P_LoginName", obj.P_LoginName);
            return obj;
        }
        #endregion
        #region 添加登录日志数据
        /// <summary>
        /// 添加登录日志数据
        /// </summary>
        /// <returns></returns>
        public static int InsertLoginLog(LoginLog obj)
        {
            return LoginLog_Service.InsertLoginLog(obj);
        }
        #endregion
        #region 修改登录日志数据
        /// <summary>
        /// 修改登录日志数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateLoginLog(LoginLog obj)
        {
            return LoginLog_Service.UpdateLoginLog(obj);
        }
        #endregion
        #region 删除登录日志数据
        /// <summary>
        /// 删除登录日志数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteLoginLog(LoginLog obj)
        {
            return LoginLog_Service.DeleteLoginLog(obj);
        }
        #endregion
    }
}
