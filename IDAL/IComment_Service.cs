using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    /// <summary>
    /// 【评价】接口类
    /// </summary>
    public interface IComment_Service
    {
        /// <summary>
        /// 获取全部评价类型信息
        /// </summary>
        /// <returns></returns>
        List<Comment> GetAllComment();
        /// <summary>
        /// 根据条件查询评价类型信息
        /// </summary>
        /// <returns></returns>
        Comment GetCommentByConn(Comment obj);
        /// <summary>
        /// 添加评价类型数据
        /// </summary>
        /// <returns></returns>
        int InserComment(Comment obj);
        /// <summary>
        /// 修改评价类型数据
        /// </summary>
        /// <returns></returns>
        int UpdateComment(Comment obj);
        /// <summary>
        /// 删除评价类型数据
        /// </summary>
        /// <returns></returns>
        int DeleteComment(Comment obj);
    }
}
