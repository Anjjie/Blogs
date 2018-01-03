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
    /// 【】
    /// </summary>
   public class Comment_Manager
    {
        #region 获取全部评价信息
        /// <summary>
        /// 获取全部评价信息
        /// </summary>
        /// <returns></returns>
        public static List<Comment> GetAllComment()
        {
            List<Comment> list = new List<Comment>();
            foreach (Comment obj in Comment_Service.GetAllComment())
            {
                obj.GetAduit = Aduit_Manager.GetAduitByConn("Aduit_No", obj.Aduit_No+"");
                obj.GetArticle = Article_Manager.GetArticleByConn("A_No", obj.A_No+"");
                list.Add(obj);
            }
            return list;
        }
        #endregion
        #region 根据条件查询评价信息
        /// <summary>
        /// 根据条件查询评价信息
        /// </summary>
        /// <param name="demandType">查询类型（实体类中的所有属性选其一）</param>
        /// <param name="demandContent">查询参数（要查询的条件参数）</param>
        /// <returns></returns>
        public static List<Comment> GetCommentByConn(string demandType, string demandContent)
        {
            List<Comment> list = new List<Comment>();
            foreach (Comment obj in Comment_Service.GetCommentByConn(demandType, demandContent))
            {
                obj.GetAduit = Aduit_Manager.GetAduitByConn("Aduit_No", obj.Aduit_No + "");
                obj.GetArticle = Article_Manager.GetArticleByConn("A_No", obj.A_No + "");
                list.Add(obj);
            }
            return list;
        }
        #endregion
        #region 添加评价数据
        /// <summary>
        /// 添加评价数据
        /// </summary>
        /// <returns></returns>
        public static int InsertComment(Comment obj)
        {
            return Comment_Service.InsertComment(obj);
        }
        #endregion
        #region 修改评价数据
        /// <summary>
        /// 修改评价数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateComment(Comment obj)
        {
            return Comment_Service.UpdateComment(obj);
        }
        #endregion
        #region 删除评价数据
        /// <summary>
        /// 删除评价数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteComment(Comment obj)
        {
            return Comment_Service.DeleteComment(obj);
        }
        #endregion
    }
}
