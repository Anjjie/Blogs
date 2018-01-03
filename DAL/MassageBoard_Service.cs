using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Models;
using IDAL;

namespace DAL
{
    /// <summary>
    /// 【留言】服务类
    /// </summary>
    public class MassageBoard_Service
    {
        #region 获取全部留言信息
        /// <summary>
        /// 获取全部留言信息
        /// </summary>
        /// <returns></returns>
        public static List<MassageBoard> GetAllMassageBoard()
        {
            List<MassageBoard> list = new List<MassageBoard>();
            SqlDataReader dr = DBHelper.ExecuteReader("Select_MassageBoard",CommandType.StoredProcedure);
            while (dr.Read())
            {
                MassageBoard massage = new MassageBoard() {
                    Aduit_No = Convert.ToInt32(dr["Aduit_No"]),
                    Mb_NickName= dr["Mb_NickName"].ToString(),
                    Mb_Cause =dr["Mb_Cause"].ToString(),
                    Mb_Content = dr["Mb_Content"].ToString(),
                    Mb_Datetime = dr["Mb_Datetime"].ToString(),
                    Mb_No =Convert.ToInt32( dr["Mb_No"])
                };
                list.Add(massage);
            }
            dr.Close();
            DBHelper.CloseCon();
            return list;
        }
        #endregion
        #region 根据条件查询留言信息
        /// <summary>
        /// 根据条件查询留言信息
        /// </summary>
        /// <returns></returns>
        public static List<MassageBoard> GetMassageBoardByConn(string demandType, string demandContent)
        {
            string sql = "Select * from MassageBoard where " + demandType + " = @" + demandType;
            List<MassageBoard> list = new List<MassageBoard>();
           MassageBoard massage = new MassageBoard();
            SqlDataReader dr = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter[] {
                new SqlParameter("@" + demandType,demandContent)
            });
            while (dr.Read())
            {
                massage = new MassageBoard()
                {
                    Aduit_No = Convert.ToInt32(dr["Aduit_No"]),
                    Mb_NickName = dr["Mb_NickName"].ToString(),
                    Mb_Cause = dr["Mb_Cause"].ToString(),
                    Mb_Content = dr["Mb_Content"].ToString(),
                    Mb_Datetime = dr["Mb_Datetime"].ToString(),
                    Mb_No = Convert.ToInt32(dr["Mb_No"])
                };
                list.Add(massage);
            }
            dr.Close();
            DBHelper.CloseCon();
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
            int n = DBHelper.ExecuteNonQuery("Insert_MassageBoard", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@Mb_NickName",obj.Mb_NickName),
                    new SqlParameter("@Mb_Datetime",obj.Mb_Datetime),
                    new SqlParameter("@Mb_Content",obj.Mb_Content),
                    new SqlParameter("@Mb_Cause",obj.Mb_Cause),
                    new SqlParameter("@Aduit_No",obj.Aduit_No)
                });
            return n;
        }
        #endregion
        #region 修改留言数据
        /// <summary>
        /// 修改留言数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateMassageBoard(MassageBoard obj)
        {
            int n = DBHelper.ExecuteNonQuery("Update_MassageBoard", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@Mb_NickName",obj.Mb_NickName),
                    new SqlParameter("@Mb_Datetime",obj.Mb_Datetime),
                    new SqlParameter("@Mb_Content",obj.Mb_Content),
                    new SqlParameter("@Mb_Cause",obj.Mb_Cause),
                     new SqlParameter("@Mb_No",obj.Mb_No),
                    new SqlParameter("@Aduit_No",obj.Aduit_No)
                });
            return n;
        }
        #endregion
        #region 删除留言数据
        /// <summary>
        /// 删除留言数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteMassageBoard(MassageBoard obj)
        {
            int n = DBHelper.ExecuteNonQuery("Delete_MassageBoard", CommandType.StoredProcedure,
                new SqlParameter[] {
                     new SqlParameter("@Mb_No",obj.Mb_No)
                });
            return n;
        } 
        #endregion
    }
}
