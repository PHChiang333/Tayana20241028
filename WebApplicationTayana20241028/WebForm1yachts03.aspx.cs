using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTayana20241028
{
    public partial class WebForm1yachts03 : System.Web.UI.Page
    {
        string selYachtId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["YachtId"] != null)
            {
                selYachtId = Request.QueryString["YachtId"];
            }
            else
            {
                selYachtId = FindSelIdKey();
            }


            if (!IsPostBack)
            {
                //共用
                ShowRepeaterLeftbar();  //Left sidevbar   
                YachtRightMenu();  //right menu links
                ShowRepeaterAdThumb(); //bind ad-thumb data
                ShowRepeaterCrumb();

                //databinging
                ShowRepeaterSpec();  //bind spec data
            }
            else
            {

            }
        }






        #region yacht共用

        protected string FindSelIdKey()
        {
            string idKey = "";

            string query = "SELECT TOP 1 YachtId FROM yacht ORDER BY IsPintop DESC, CreatedTime DESC";

            string connstring = "tayanaConnectionString";
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        idKey = result.ToString(); // 獲取 TOP 1 的 YachtId
                    }
                }
            }

            return idKey;

        }

        protected void ShowRepeaterLeftbar()  //記得要把 ShowRepeater() 放到 Page_Load
        {

            DbHelper db = new DbHelper();


            string sql = $"SELECT * " + " " +
                        $"FROM yacht " + " " +
                        $"ORDER BY IsPintop DESC, CreatedTime DESC ;";

            Dictionary<string, object> param = new Dictionary<string, object>();

            SqlDataReader rd = db.SearchDB(sql, param);

            if (rd.HasRows)
            {
                RepeaterLeftbarYacht.DataSource = rd;
                RepeaterLeftbarYacht.DataBind();
            }

            db.CloseDB();

        }



        protected void YachtRightMenu()
        {


            HyperLinkOverview.NavigateUrl = $"WebForm1yachts01.aspx?YachtId={selYachtId}";
            HyperLinkLayout.NavigateUrl = $"WebForm1yachts02.aspx?YachtId={selYachtId}";
            HyperLinkSpec.NavigateUrl = $"WebForm1yachts03.aspx?YachtId={selYachtId}";
        }

        protected void ShowRepeaterAdThumb()  //記得要把 ShowRepeater() 放到 Page_Load
        {

            DbHelper db = new DbHelper();


            string sql = $"SELECT * " + " " +
                        $"FROM yacht " + " " +
                        $"ORDER BY IsPintop DESC, CreatedTime DESC ;";

            Dictionary<string, object> param = new Dictionary<string, object>();

            SqlDataReader rd = db.SearchDB(sql, param);

            if (rd.HasRows)
            {
                RepeaterAdThumb.DataSource = rd;
                RepeaterAdThumb.DataBind();
            }

            db.CloseDB();





        }

        protected void ShowRepeaterCrumb()  //記得要把 ShowRepeater() 放到 Page_Load
        {

            DbHelper db = new DbHelper();


            string sql = $"SELECT * " + " " +
                        $"FROM yacht " + " " +
                        $"WHERE YachtId = @YachtId" + " " +
                        $";";

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["@YachtId"] = selYachtId;

            SqlDataReader rd = db.SearchDB(sql, param);

            if (rd.HasRows)
            {
                RepeaterCrumb.DataSource = rd;
                RepeaterCrumb.DataBind();
            }

            db.CloseDB();





        }






        #endregion


        protected void ShowRepeaterSpec()  //記得要把 ShowRepeater() 放到 Page_Load
        {

            DbHelper db = new DbHelper();


            string sql = $"SELECT * " + " " +
                        $"FROM yachtSpec " + " " +
                        $"WHERE YachtId = @YachtId" + " " +
                        $"ORDER BY CreatedTime ASC ;";

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["@YachtId"] = selYachtId;

            SqlDataReader rd = db.SearchDB(sql, param);

            if (rd.HasRows)
            {
                RepeaterSpec.DataSource = rd;
                RepeaterSpec.DataBind();
            }

            db.CloseDB();





        }










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