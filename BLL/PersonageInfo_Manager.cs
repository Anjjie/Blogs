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
    /// 【个人信息】业务类
    /// </summary>
    public class PersonageInfo_Manager
    {
        #region 获取全部个人信息
        /// <summary>
        /// 获取全部个人信息
        /// </summary>
        /// <returns></returns>
        public static List<PersonageInfo> GetAllPersonageInfo()
        {
            return PersonageInfo_Service.GetAllPersonageInfo();
        }
        #endregion
        #region 根据条件查询个人信息
        /// <summary>
        /// 根据条件查询个人信息
        /// </summary>
        /// <param name="demandType">查询类型（实体类中的所有属性选其一）</param>
        /// <param name="demandContent">查询参数（要查询的条件参数）</param>
        /// <returns></returns>
        public static PersonageInfo GetPersonageInfoByConn(string demandType, string demandContent)
        {
            return PersonageInfo_Service.GetPersonageInfoByConn(demandType, demandContent);
        }
        #endregion
        #region 添加个人信息数据
        /// <summary>
        /// 添加个人信息数据
        /// </summary>
        /// <returns></returns>
        public static int InsertPersonageInfo(PersonageInfo obj)
        {
            return PersonageInfo_Service.InsertPersonageInfo(obj);
        }
        #endregion
        #region 修改个人信息数据
        /// <summary>
        /// 修改个人信息数据
        /// </summary>
        /// <returns></returns>
        public static int UpdatePersonageInfo(PersonageInfo obj)
        {
            return PersonageInfo_Service.UpdatePersonageInfo(obj);
        }
        #endregion
        #region 删除个人信息数据
        /// <summary>
        /// 删除个人信息数据
        /// </summary>
        /// <returns></returns>
        public static int DeletePersonageInfo(PersonageInfo obj)
        {
            return PersonageInfo_Service.DeletePersonageInfo(obj);
        }
        #endregion
    }
}
