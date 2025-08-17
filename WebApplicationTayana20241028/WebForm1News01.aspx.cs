using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTayana20241028
{
    public partial class WebForm1news01 : System.Web.UI.Page
    {
        private int pageSize = 5;
        private int currentPage = 1;

        //public double PageSize { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 檢查 Query String 是否有 page 參數
            if (Request.QueryString["page"] != null)
            {
                int.TryParse(Request.QueryString["page"], out currentPage);
            }

            int offset = (currentPage - 1) * pageSize;

            if (!IsPostBack)
            {
                ShowRepeater(offset);
                LoadPages();
            }
        }

        protected void ShowRepeater(int offset)  //記得要把 ShowRepeater() 放到 Page_Load
        {

            DbHelper db = new DbHelper();
            string sql = $"SELECT * " +
                $"FROM News ORDER BY IsPintop DESC,CreatedTime DESC " +
                $"OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["@Offset"] = offset;
            param["@PageSize"] = pageSize;

            SqlDataReader rd = db.SearchDB(sql, param);

            if (rd.HasRows)
            {
                RepeaterNewsList.DataSource = rd;
                RepeaterNewsList.DataBind();
            }

            db.CloseDB();

            
        }

        private void GeneratePagination(int totalRecords)
        {
            int pageSize = 5; //每頁的數量 =5
            
            double doubleTotalRecords = Convert.ToDouble(totalRecords);
            double doublePageSize = Convert.ToDouble(pageSize);
            double doubleTotalPages = Math.Ceiling(doubleTotalRecords / doublePageSize);
            int totalPages = Convert.ToInt32(doubleTotalPages);
            StringBuilder sb = new StringBuilder();

            // 生成分頁連結
            for(int i = 1; i <= totalPages; i++)
            {
                if(i == currentPage)
                {
                    sb.Append($"|> <span class='current-page'>{i}</span> < ");
                }
                else
                {
                    sb.Append($"| <a href='WebForm1News01.aspx?page={i}' class='page-link'>{i}</a> ");
                }



                
            }

            sb.Append($"| <a href='WebForm1News01.aspx?page={currentPage + 1}' class='page-link'>Next</a> ");

            sb.Append($"| <a href='WebForm1News01.aspx?page={totalPages}' class='page-link'>LastPage</a> ");

            litPagination.Text = sb.ToString();
        }

        protected void LoadPages()
        {
            DbHelper dbPage = new DbHelper();
            string sqlPage = $"SELECT COUNT(*) AS cntRows FROM News;";

            //Dictionary<string, object> paramPage = new Dictionary<string, object>();
            //paramPage["@Offset"] = offset;
            //paramPage["@PageSize"] = pageSize;

            //SqlDataReader rdPage = db.SearchDB(sqlPage);

            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlPage);
            sqlCommand.Connection = conn;
            conn.Open();

            int totalRows = (int)sqlCommand.ExecuteScalar();
            GeneratePagination(totalRows);

            conn.Close();

            //if (rdPage.HasRows)
            //{
            //    if (rdPage.Read())
            //    {
            //        int totalRecords = rdPage.GetInt32(0);
            //        GeneratePagination(totalRecords);
            //    }
            //}
            //db.CloseDB();
        }

    }
}