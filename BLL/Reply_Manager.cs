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
    /// 【回复】业务类
    /// </summary>
    public class Reply_Manager
    {
        #region 获取全部回复信息
        /// <summary>
        /// 获取全部回复信息
        /// </summary>
        /// <returns></returns>
        public static List<Reply> GetAllReply()
        {
            List<Reply> list = new List<Reply>();
            foreach (Reply obj in Reply_Service.GetAllReply())
            {
                obj.GetComment = Comment_Manager.GetCommentByConn("Com_No", obj.Com_No+"");
                list.Add(obj);
            }
            return list;
        }
        #endregion
        #region 根据条件查询回复信息
        /// <summary>
        /// 根据条件查询回复信息
        /// </summary>
        /// <param name="demandType">查询类型（实体类中的所有属性选其一）</param>
        /// <param name="demandContent">查询参数（要查询的条件参数）</param>
        /// <returns></returns>
        public static Reply GetReplyByConn(string demandType, string demandContent)
        {
            Reply obj = Reply_Service.GetReplyByConn(demandType, demandContent);
            obj.GetComment = Comment_Manager.GetCommentByConn("Com_No", obj.Com_No + "");
            return obj;
        }
        #endregion
        #region 添加回复数据
        /// <summary>
        /// 添加回复数据
        /// </summary>
        /// <returns></returns>
        public static int InsertReply(Reply obj)
        {
            return Reply_Service.InsertReply(obj);
        }
        #endregion
        #region 修改回复数据
        /// <summary>
        /// 修改回复数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateReply(Reply obj)
        {
            return Reply_Service.UpdateReply(obj);
        }
        #endregion
        #region 删除回复数据
        /// <summary>
        /// 删除回复数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteReply(Reply obj)
        {
            return Reply_Service.DeleteReply(obj);
        }
        #endregion
    }
}
