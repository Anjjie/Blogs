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
    /// 【密保问题】业务类
    /// </summary>
    public class Issue_Manager
    {
        #region 获取全部密保问题信息
        /// <summary>
        /// 获取全部密保问题信息
        /// </summary>
        /// <returns></returns>
        public static List<Issue> GetAllIssue()
        {
            return Issue_Server.GetAllIssue(); 
        }
        #endregion

        #region 根据条件查询密保问题信息
        /// <summary>
        /// 根据条件查询密保问题信息
        /// </summary>
        /// <returns></returns>
        public static Issue GetIssueByConn(string demandType, string demandContent)
        {
            return Issue_Server.GetIssueByConn(demandType, demandContent) ;
        }
        #endregion
        #region 添加密保问题数据
        /// <summary>
        /// 添加密保问题数据
        /// </summary>
        /// <returns></returns>
        public static int InsertIssue(Issue obj)
        {
            return Issue_Server.InsertIssue(obj);
        }
        #endregion
        #region 修改密保问题数据
        /// <summary>
        /// 修改密保问题数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateIssue(Issue obj)
        {
            return Issue_Server.UpdateIssue(obj);
        }
        #endregion
        #region 删除密保问题数据
        /// <summary>
        /// 删除密保问题数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteIssue(Issue obj)
        {
            return Issue_Server.DeleteIssue(obj);
        }
        #endregion
    }
}
