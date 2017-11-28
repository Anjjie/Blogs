using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    /// <summary>
    /// 【个人信息】接口类
    /// </summary>
    public interface IPersonageInfo_Service
    {
        /// <summary>
        /// 获取全部个人信息
        /// </summary>
        /// <returns></returns>
        List<PersonageInfo> GetAllPersonageInfo();
        /// <summary>
        /// 根据条件查询个人信息
        /// </summary>
        /// <returns></returns>
        PersonageInfo GetPersonageInfoByConn(PersonageInfo obj);
        /// <summary>
        /// 添加个人信息数据
        /// </summary>
        /// <returns></returns>
        int InserPersonageInfo(PersonageInfo obj);
        /// <summary>
        /// 修改个人信息数据
        /// </summary>
        /// <returns></returns>
        int UpdatePersonageInfo(PersonageInfo obj);
        /// <summary>
        /// 删除个人信息数据
        /// </summary>
        /// <returns></returns>
        int DeletePersonageInfo(PersonageInfo obj);
    }
}
