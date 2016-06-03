using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Data.SqlClient;
namespace OA_ASP
{ 
    public class Public_String
    {
        #region 链接字符串
        public static string sql_con_cmd = "Data Source=*;Integrated Security=False;User ID=*;Password=*;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        #endregion
        #region formate Parameters
        /// <summary>
        /// 格式化parameter，方便在sql执行时调用
        /// </summary>
        /// <param name="list"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public SqlParameter[] sql_params(string[] list, object[] value)
        {

            SqlParameter[] temp_params = new SqlParameter[list.Length];
          
            for (int i = 0; i <= list.Length - 1; i++)
            {
                SqlParameter temp_param = new SqlParameter(list[i], value[i]);
                temp_params[i] = temp_param;
            }


            return temp_params;
        }
        /*
        public SqlParameter[] sql_params(string in_text, object in_value)
        {
            SqlParameter[] temp_params = new SqlParameter[1];
            SqlParameter temp_param = new SqlParameter(in_text, in_value);
            temp_params[0] = temp_param;
            return temp_params;
        }
        */
        #endregion
    }

}