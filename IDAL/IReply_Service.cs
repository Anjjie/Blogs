using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    /// <summary>
    /// 【回复】接口类
    /// </summary>
    public interface IReply_Service
    {
        /// <summary>
        /// 获取全部回复信息
        /// </summary>
        /// <returns></returns>
        List<Reply> GetAllReply();
        /// <summary>
        /// 根据条件查询回复信息
        /// </summary>
        /// <returns></returns>
        Reply GetReplyByConn(Reply obj);
        /// <summary>
        /// 添加回复数据
        /// </summary>
        /// <returns></returns>
        int InserReply(Reply obj);
        /// <summary>
        /// 修改回复数据
        /// </summary>
        /// <returns></returns>
        int UpdateReply(Reply obj);
        /// <summary>
        /// 删除回复数据
        /// </summary>
        /// <returns></returns>
        int DeleteReply(Reply obj);
    }
}
