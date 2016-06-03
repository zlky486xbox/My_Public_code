using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;


namespace OA_ASP
{
    public class Public_SQL_Action
    {
        /// <summary>
        /// 链接语句
        /// </summary>
        /// <returns></returns>
        #region SQLConnection
        public SqlConnection sqlconn()
        {
            SqlConnection conn = new SqlConnection(Public_String.sql_con_cmd);
            return conn;

        }
        public void Sql_closed()
        {
            SqlConnection conn = sqlconn();
            if(conn.State==ConnectionState.Open)
            {
                conn.Dispose();
                conn.Close();
            }
        }
        #endregion
        #region  SQLCommand-执行
        /// <summary>
        /// Update,insert,del执行
        /// </summary>
        /// <param name="cmd_txt"></param>
        /// <param name="paras"></param>
        public void command_action(string cmd_txt,params SqlParameter[] paras)
        { 
            SqlConnection conn = sqlconn();   
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmd_txt;
            cmd.Parameters.AddRange(paras);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }         
            conn.Dispose();
            conn.Close();
            
        }
        #endregion
      
        #region SQLCommand-查询
        
        /// <summary>
        /// 判断是否有数据,返回true或false
        /// </summary>
        /// <param name="cmd_text"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public bool sql_select_bool(string cmd_text, params SqlParameter[] paras)
        {
            SqlConnection conn = sqlconn();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmd_text;
            cmd.Connection = conn;        
            cmd.Parameters.AddRange(paras);         
            SqlDataReader sdr = cmd.ExecuteReader();
          
            if (sdr.HasRows)
            {
                Sql_closed();
                return true;
            }
            else
            {
                Sql_closed();
                return false;
            }
        }
    
        #endregion
        /// <summary>
        /// SqlDateReader时用(select 返回一个值时) 返回sqldatareader
        /// </summary>
        /// <param name="cmd_txt"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        #region sqldatereader
        public SqlDataReader SqlDR(string cmd_txt,params SqlParameter[] paras)
        {
            SqlConnection conn = sqlconn();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmd_txt;
            cmd.Parameters.AddRange(paras);
            SqlDataReader sdr = cmd.ExecuteReader();
            conn.Dispose();
            conn.Close();
            return sdr;

        }
        #endregion
        /// <summary>
        /// dataset相关
        /// </summary>
        /// <param name="cmd_text"></param>
        /// <param name="table_name"></param>
        /// <returns></returns>
        #region dataset
        public DataTable  get_DT(string cmd_text,string table_name)      
        {
            SqlConnection conn = sqlconn();
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmd_text, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds,table_name);
            DataTable dt = ds.Tables[table_name];
            sda.Dispose();
            conn.Dispose();
            conn.Close();
            return dt;  
        }
        #endregion
        
    }

}