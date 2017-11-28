using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    /// <summary>
    /// 【审核】接口类
    /// </summary>
    public interface IAduit_Service
    {
        /// <summary>
        /// 获取全部审核信息
        /// </summary>
        /// <returns></returns>
        List<Aduit> GetAllAduit();
        /// <summary>
        /// 根据条件查询审核信息
        /// </summary>
        /// <returns></returns>
        Aduit GetAduitByConn(Aduit obj);
        /// <summary>
        /// 添加审核数据
        /// </summary>
        /// <returns></returns>
        int InserAduit(Aduit obj);
        /// <summary>
        /// 修改审核数据
        /// </summary>
        /// <returns></returns>
        int UpdateAduit(Aduit obj);
        /// <summary>
        /// 删除审核数据
        /// </summary>
        /// <returns></returns>
        int DeleteAduit(Aduit obj);
    }
}
