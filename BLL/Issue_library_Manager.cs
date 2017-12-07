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
    /// 【问题库】业务类
    /// </summary>
    public class Issue_library_Manager
    {
        #region 获取全部问题库信息
        /// <summary>
        /// 获取全部问题库信息
        /// </summary>
        /// <returns></returns>
        public static List<Issue_library> GetAllIssue_library()
        {
            return Issue_library_Server.GetAllIssue_library();
        }
        #endregion

        #region 根据条件查询问题库信息
        /// <summary>
        /// 根据条件查询问题库信息
        /// </summary>
        /// <returns></returns>
        public static Issue_library GetIssue_libraryByConn(string demandType, string demandContent)
        {
            return Issue_library_Server.GetIssue_libraryByConn(demandType, demandContent);
        }
        #endregion
        #region 添加问题库数据
        /// <summary>
        /// 添加问题库数据
        /// </summary>
        /// <returns></returns>
        public static int InsertIssue_library(Issue_library obj)
        {
            return Issue_library_Server.InsertIssue_library(obj);
        }
        #endregion
        #region 修改问题库数据
        /// <summary>
        /// 修改问题库数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateIssue_library(Issue_library obj)
        {
            return Issue_library_Server.UpdateIssue_library(obj);
        }
        #endregion
        #region 删除问题库数据
        /// <summary>
        /// 删除问题库数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteIssue_library(Issue_library obj)
        {
            return Issue_library_Server.DeleteIssue_library(obj);
        }
        #endregion
    }
}
