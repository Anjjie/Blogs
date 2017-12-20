using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using IDAL;
using Models;

namespace DAL
{
    /// <summary>
    /// 【审核】服务类
    /// </summary>
    public class Aduit_Service 
    {
        #region 获取全部审核信息
        /// <summary>
        /// 获取全部审核信息
        /// </summary>
        /// <returns></returns>
        public static List<Aduit> GetAllAduit()
        {
            string sql = "Select_Aduit";
            List<Aduit> list = new List<Aduit>();
            SqlDataReader dr =DBHelper.ExecuteReader(sql,CommandType.StoredProcedure);
            while (dr.Read())
            {
                Aduit aduit = new Aduit() {
                    Aduit_Name = dr["Aduit_Name"].ToString(),
                    Aduit_No = Convert.ToInt32(dr["Aduit_No"])
                };
                list.Add(aduit);
            }
            dr.Close();
            DBHelper.CloseCon();
            return list;
        }
        #endregion

        #region 根据条件查询审核信息
        /// <summary>
        /// 根据条件查询审核信息
        /// </summary>
        /// <returns></returns>
        public static Aduit GetAduitByConn(string demandType,string demandContent)
        {
            string parameter = "@"+ demandType;
            Aduit aduit = null;
            string sql = "Select * from Aduit where "+ demandType + "="+ parameter ;
            SqlDataReader dr = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter[] {
                new SqlParameter(parameter,demandContent)
            });
            if (dr.Read())
            {
                aduit = new Aduit()
                {
                    Aduit_Name = dr["Aduit_Name"].ToString(),
                    Aduit_No = Convert.ToInt32(dr["Aduit_No"])
                };
            }
            dr.Close();
            DBHelper.CloseCon();
            return aduit;
        }
        #endregion

        #region 添加审核数据
        /// <summary>
        /// 添加审核数据
        /// </summary>
        /// <returns></returns>
        public static int InsertAduit(Aduit obj)
        {
            int n = DBHelper.ExecuteNonQuery("Insert_Aduit", CommandType.StoredProcedure,new SqlParameter[] {
                new SqlParameter("@Aduit_Name",obj.Aduit_Name)
            });
            return n;
        }
        #endregion

        #region 修改审核数据
        /// <summary>
        /// 修改审核数据
        /// </summary>
        /// <returns></returns>
        public static int UpdateAduit(Aduit obj)
        {
            int n = DBHelper.ExecuteNonQuery("Update_Aduit", CommandType.StoredProcedure, new SqlParameter[] {
                new SqlParameter("@Aduit_Name",obj.Aduit_Name),
                new SqlParameter("@Aduit_No",obj.Aduit_No)
            });
            return n;
        }
        #endregion

        #region 删除审核数据
        /// <summary>
        /// 删除审核数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteAduit(Aduit obj)
        {
            int n = DBHelper.ExecuteNonQuery("Delete_Aduit", CommandType.StoredProcedure, new SqlParameter[] {
                new SqlParameter("@Aduit_No",obj.Aduit_No)
            });
            return n;
        } 
        #endregion
    }
}
