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
    /// 【留言】业务类
    /// </summary>
    public class MassageBoard_Manager
    {
        #region 获取全部留言信息
        /// <summary>
        /// 获取全部留言信息
        /// </summary>
        /// <returns></returns>
        public static List<MassageBoard> GetAllMassageBoard()
        {
            List<MassageBoard> list = new List<MassageBoard>();
            foreach (MassageBoard obj in MassageBoard_Service.GetAllMassageBoard())
            {
                obj.GetAduit = Aduit_Manager.GetAduitByConn("Aduit_No", obj.Aduit_No+"");
                list.Add(obj);
            }
            return list;
        }
        #endregion
        #region 根据条件查询留言信息
        /// <summary>
        /// 根据条件查询留言信息
        /// </summary>
        /// <param name="demandType">查询类型（实体类中的所有属性选其一）</param>
        /// <param name="demandContent">查询参数（要查询的条件参数）</param>
        /// <returns></returns>
        public static List<MassageBoard> GetMassageBoardByConn(string demandType, string demandContent)
        {
            List<MassageBoard> list = new List<MassageBoard>();
            foreach (MassageBoard obj in MassageBoard_Service.GetMassageBoardByConn(demandType, demandContent))
            {
                obj.GetAduit = Aduit_Manager.GetAduitByConn("Aduit_No", obj.Aduit_No + "");
                list.Add(obj);
            }
            return list;
        }
        #endregion
        #region 添加留言数据
        /// <summary>
        /// 添加留言数据
        /// </summary>
        /// <returns></returns>
        public static int InsertMassageBoard(MassageBoard obj)
        {
            return MassageBoard_Service.InsertMassageBoard(obj);
        }
        #endregion
        #region 修改留言数据
        /// <summary>
        /// 修改留言数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateMassageBoard(MassageBoard obj)
        {
            return MassageBoard_Service.UpdateMassageBoard(obj);
        }
        #endregion
        #region 删除留言数据
        /// <summary>
        /// 删除留言数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteMassageBoard(MassageBoard obj)
        {
            return MassageBoard_Service.DeleteMassageBoard(obj);
        }
        #endregion
    }
}
