using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    /// <summary>
    /// 【留言】接口类
    /// </summary>
    public interface IMassageBoard_Service
    {
        /// <summary>
        /// 获取全部留言信息
        /// </summary>
        /// <returns></returns>
        List<MassageBoard> GetAllMassageBoard();
        /// <summary>
        /// 根据条件查询留言信息
        /// </summary>
        /// <returns></returns>
        MassageBoard GetMassageBoardByConn(MassageBoard obj);
        /// <summary>
        /// 添加留言数据
        /// </summary>
        /// <returns></returns>
        int InserMassageBoard(MassageBoard obj);
        /// <summary>
        /// 修改留言数据
        /// </summary>
        /// <returns></returns>
        int UpdateMassageBoard(MassageBoard obj);
        /// <summary>
        /// 删除留言数据
        /// </summary>
        /// <returns></returns>
        int DeleteMassageBoard(MassageBoard obj);
    }
}
