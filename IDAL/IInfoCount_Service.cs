using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    /// <summary>
    /// 【信息统计】接口类
    /// </summary>
    public interface IInfoCount_Service
    {
        /// <summary>
        /// 获取全部信息统计信息
        /// </summary>
        /// <returns></returns>
        List<InfoCount> GetAllInfoCount();
        /// <summary>
        /// 根据条件查询信息统计信息
        /// </summary>
        /// <returns></returns>
        InfoCount GetInfoCountByConn(InfoCount obj);
        /// <summary>
        /// 添加信息统计数据
        /// </summary>
        /// <returns></returns>
        int InserInfoCount(InfoCount obj);
        /// <summary>
        /// 修改信息统计数据
        /// </summary>
        /// <returns></returns>
        int UpdateInfoCount(InfoCount obj);
        /// <summary>
        /// 删除信息统计数据
        /// </summary>
        /// <returns></returns>
        int DeleteInfoCount(InfoCount obj);
    }
}
