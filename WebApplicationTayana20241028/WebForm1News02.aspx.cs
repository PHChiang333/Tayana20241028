using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTayana20241028
{
    public partial class WebForm1news02 : System.Web.UI.Page
    {

        string NewsId;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["NewsId"] != null)
            {
                NewsId = Request.QueryString["NewsId"];
            }
            else
            {

                Response.Redirect("WebForm1News01.aspx");
            }


            if (!IsPostBack)
            {
                ShowRepeaterNews();
                ShowRepeaterNewsImg();
                ShowRepeaterNewsFile();
            }

        }

        #region repeaters
        protected void ShowRepeater(Repeater rpt, string sqlcmd)  //記得要把 ShowRepeater() 放到 Page_Load
        {
            DbHelper db = new DbHelper();
            SqlDataReader rd = db.SearchDB(sqlcmd);

            if (rd.HasRows)
            {
                rpt.DataSource = rd;
                rpt.DataBind();
            }
            db.CloseDB();
        }


        protected void ShowRepeaterNews()  //記得要把 ShowRepeater() 放到 Page_Load
        {
            string sql = $"SELECT * FROM News WHERE NewsId = {NewsId}";

            ShowRepeater(RepeaterNews,sql);

        }
        protected void ShowRepeaterNewsImg()  //記得要把 ShowRepeater() 放到 Page_Load
        {
            string sql = $"SELECT * FROM NewsImg WHERE NewsId = {NewsId}";

            ShowRepeater(RepeaterNewsImg, sql);

        }
        protected void ShowRepeaterNewsFile()  //記得要把 ShowRepeater() 放到 Page_Load
        {
            string sql = $"SELECT * FROM NewsFile WHERE NewsId = {NewsId}";

            ShowRepeater(RepeaterNewsFile, sql);

        }





        #endregion


        protected string HtmlEncodeContent(object content)
        {
            return HttpUtility.HtmlEncode(content.ToString());
        }

        protected string DecodeHtmlContent(object content)
        {
            // 使用 HtmlDecode 解碼內容
            return Server.HtmlDecode(content.ToString());
        }
    }
}