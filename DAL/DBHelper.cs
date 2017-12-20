using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class DBHelper
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        static string conStr = ConfigurationManager.ConnectionStrings["conStr"].ToString();
        /// <summary>
        /// 创建连接对象
        /// </summary>
        static  SqlConnection con =null;

        static SqlConnection Conn() {
            if (con == null || con.ConnectionString == "")
            {
                con = new SqlConnection(conStr);
            }
            switch (con.State)
            {
                case ConnectionState.Closed:
                    con.Open();
                    break;
                case ConnectionState.Open:
                    con.Close();
                    break;
                case ConnectionState.Broken:
                    con.Close();
                    con.Open();
                    break;
                default:
                    break;
            }
            return con;
        }

        /// <summary>
        /// 实例化连接对象
        /// </summary>
        /// <returns></returns>
        static SqlConnection GetCon()
        {
            if (con == null || con.ConnectionString=="")
            {
                con = new SqlConnection(conStr);
            }
            return con;
        }

        /// <summary>
        /// 打开连接
        /// </summary>
        public static void OpenCon()
        {
            if (con.State==ConnectionState.Closed)
            {
                con.Open();
            }
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public static void CloseCon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        /// <summary>
        /// 查询返回多行多列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="type">SQL语句类型</param>
        /// <param name="paras">带入参数</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql,CommandType type,params SqlParameter[] paras)
        {
            SqlConnection con = GetCon();
            OpenCon();
            SqlCommand com = new SqlCommand(sql,con);
            com.CommandType = type;
            com.Parameters.AddRange(paras);
            SqlDataReader dr = com.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// 动作查询：增、删、改
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="type">SQL语句类型</param>
        /// <param name="paras">带入参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, CommandType type, params SqlParameter[] paras) {
            SqlConnection con = GetCon();
            OpenCon();
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = type;
            com.Parameters.AddRange(paras);
            int n = com.ExecuteNonQuery();
            CloseCon();
            return n;
        }

        public static DataSet GetDataSet(string sql, CommandType type, params SqlParameter[] paras) {
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(sql, Conn());
            sda.SelectCommand.CommandType = type;
            sda.SelectCommand.Parameters.AddRange(paras);
            sda.Fill(ds);
            return ds;
        }

    }
}
