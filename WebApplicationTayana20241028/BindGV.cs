using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplicationTayana20241028
{
    public static class BindGV
    {
        public static void ShowGV(string DbTable, GridView GridID)
        {
            DbHelper helper = new DbHelper();

            string sqlCommand = $"Select * From {DbTable}";
            using (SqlDataReader reader = helper.SearchDB(sqlCommand))
            {
                GridID.DataSource = reader;
                GridID.DataBind();
            }

        }

        public static void ShowGV(string DbTable, GridView GridID, string Category)
        {
            DbHelper helper = new DbHelper();


            string sqlCommand = $"Select * From {DbTable} WHERE Category= '{Category}' ";

            using (SqlDataReader reader = helper.SearchDB(sqlCommand))
            {
                GridID.DataSource = reader;
                GridID.DataBind();
            }

        }



    }


}