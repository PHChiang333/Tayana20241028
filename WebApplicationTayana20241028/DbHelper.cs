using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebApplicationTayana20241028
{
    
    
    public class DbHelper
    {
        
        //建立SQL連線物件
        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);

        //建立SQL命令物件
        SqlCommand sqlCommand = new SqlCommand();


        //連線資料庫，讓別人不能連線，設成私人
        private void ConnectDB()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        /// <summary>
        /// 關閉資料庫
        /// </summary>
        public void CloseDB()
        {
            connection.Close();
        }

        /// <summary>
        /// 查詢資料庫,用Dictionary進行sqlCommand.Parameters.AddWithValue(item.Key, item.Value)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="Dictionary"></param>
        /// <returns></returns>
        public SqlDataReader SearchDB(string sql, Dictionary<string, object> Dictionary = null)
        {
            ConnectDB();
            if (Dictionary != null)
            {
                foreach (var item in Dictionary)
                {
                    sqlCommand.Parameters.AddWithValue(item.Key, item.Value);
                }

            }
            //發送SQL語法，取得結果，第一句前面有宣告過
            sqlCommand.Connection = connection;



            //查詢的方法，刪除並帶入上面參數
            //string sql = $"select * from Student";

            //將準備的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            //執行該SQL查詢，用reader接資料
            SqlDataReader reader = sqlCommand.ExecuteReader();

            //不能放在return下面
            //CloseDB();

            //必須把reader傳出
            return reader;
        }

        public int ExecuteNonQueryDB(string sql, Dictionary<string, object> Dictionary = null)
        {
            ConnectDB();
            if (Dictionary != null)
            {
                sqlCommand.Parameters.Clear(); // 確保每次不重複參數
                foreach (var item in Dictionary)
                {
                    sqlCommand.Parameters.AddWithValue(item.Key, item.Value);
                }

            }
            //發送SQL語法，取得結果，第一句前面有宣告過
            sqlCommand.Connection = connection;



            //查詢的方法，刪除並帶入上面參數
            //string sql = $"select * from Student";

            //將準備的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            //執行該SQL ExecuteNonQuery
            sqlCommand.ExecuteNonQuery();

            //不能放在return下面
            //CloseDB();

            int rowsAffected = sqlCommand.ExecuteNonQuery(); // 用來執行非查詢語句 (如更新、刪除)
            return rowsAffected;
        }
    }
}