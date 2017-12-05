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
    /// 【个人信息】服务类
    /// </summary>
    public class PersonageInfo_Service
    {
        #region 获取全部个人信息
        /// <summary>
        /// 获取全部个人信息
        /// </summary>
        /// <returns></returns>
        public static List<PersonageInfo> GetAllPersonageInfo()
        {
            List<PersonageInfo> list = new List<PersonageInfo>();
            SqlDataReader dr = DBHelper.ExecuteReader("Select_PersonageInfo", CommandType.StoredProcedure);
            while (dr.Read())
            {
                PersonageInfo personagerInfo = new PersonageInfo()
                {
                    P_DataTime=dr["P_DataTime"].ToString(),
                    P_Head = dr["P_Head"].ToString(),
                    P_LoginName = dr["P_LoginName"].ToString(),
                    P_LoginPwd = dr["P_LoginPwd"].ToString(),
                    P_MyExplain = dr["P_MyExplain"].ToString(),
                    P_Phone = dr["P_Phone"].ToString(),
                    P_NickName = dr["P_NickName"].ToString()
                };
                list.Add(personagerInfo);
            }
            dr.Close();
            DBHelper.CloseCon();
            return list;
        }
        #endregion
        #region 根据条件查询个人信息
        /// <summary>
        /// 根据条件查询个人信息
        /// </summary>
        /// <returns></returns>
        public static PersonageInfo GetPersonageInfoByConn(string demandType, string demandContent)
        {
            string sql = "Select * from PersonageInfo where " + demandType + " = @" + demandType;
            PersonageInfo personagerInfo = new PersonageInfo();
            SqlDataReader dr = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter[] {
                new SqlParameter("@" + demandType,demandContent)
            });
            if (dr.Read())
            {
                personagerInfo = new PersonageInfo()
                {
                    P_DataTime = dr["P_DataTime"].ToString(),
                    P_Head = dr["P_Head"].ToString(),
                    P_LoginName = dr["P_LoginName"].ToString(),
                    P_LoginPwd = dr["P_LoginPwd"].ToString(),
                    P_MyExplain = dr["P_MyExplain"].ToString(),
                    P_Phone = dr["P_Phone"].ToString(),
                    P_NickName = dr["P_NickName"].ToString()
                };
            }
            dr.Close();
            DBHelper.CloseCon();
            return personagerInfo;
        }
        #endregion
        #region 添加个人信息数据
        /// <summary>
        /// 添加个人信息数据
        /// </summary>
        /// <returns></returns>
        public static int InsertPersonageInfo(PersonageInfo obj)
        {
            int n = DBHelper.ExecuteNonQuery("Insert_PersonageInfo", CommandType.StoredProcedure,
                new SqlParameter[] {
                    new SqlParameter("@P_DataTime",obj.P_DataTime),
                     new SqlParameter("@P_Head",obj.P_Head),
                      new SqlParameter("@P_LoginName",obj.P_LoginName),
                       new SqlParameter("@P_LoginPwd",obj.P_LoginPwd),
                        new SqlParameter("@P_MyExplain",obj.P_MyExplain),
                         new SqlParameter("@P_Phone",obj.P_Phone),
                          new SqlParameter("@P_NickName",obj.P_NickName)

                });
            return n;
        }
        #endregion
        #region 修改个人信息数据
        /// <summary>
        /// 修改个人信息数据
        /// </summary>
        /// <returns></returns>
        public static int UpdatePersonageInfo(PersonageInfo obj)
        {
            int n = DBHelper.ExecuteNonQuery("Update_PersonageInfo", CommandType.StoredProcedure,
                new SqlParameter[] {
                  new SqlParameter("@P_DataTime",obj.P_DataTime),
                     new SqlParameter("@P_Head",obj.P_Head),
                      new SqlParameter("@P_LoginName",obj.P_LoginName),
                       new SqlParameter("@P_LoginPwd",obj.P_LoginPwd),
                        new SqlParameter("@P_MyExplain",obj.P_MyExplain),
                         new SqlParameter("@P_Phone",obj.P_Phone),
                          new SqlParameter("@P_NickName",obj.P_NickName)

                });
            return n;
        }
        #endregion
        #region 删除个人信息数据
        /// <summary>
        /// 删除个人信息数据
        /// </summary>
        /// <returns></returns>
        public static int DeletePersonageInfo(PersonageInfo obj)
        {
            int n = DBHelper.ExecuteNonQuery("Delete_PersonageInfo", CommandType.StoredProcedure,
                new SqlParameter[] {
                      new SqlParameter("@P_LoginName",obj.P_LoginName)
                });
            return n;
        } 
        #endregion
    }
}
