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
    public partial class WebForm1dealersManage : System.Web.UI.Page
    {
        string connstring = "tayanaConnectionString";

        string DbTable = "CountrySort";



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindGV.ShowGV(DbTable,GridViewCountry);
            }
            else
            {
                
            }


        }


        

        #region country CRUD

        protected void GridViewCountry_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewCountry.EditIndex = e.NewEditIndex;
            BindGV.ShowGV(DbTable, GridViewCountry);
            DropDownList1.DataBind();
        }

        protected void GridViewCountry_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewCountry.EditIndex = -1;
            BindGV.ShowGV(DbTable, GridViewCountry);
            DropDownList1.DataBind();
        }

        protected void GridViewCountry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IndexRow = e.RowIndex;
            string IDKey = GridViewCountry.DataKeys[IndexRow].Value.ToString();

            DbHelper dbHelper = new DbHelper();
            string sqlcommand = $"DELETE FROM {DbTable} WHERE [country_ID] = @country_ID";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@country_ID"] = IDKey;
            dbHelper.SearchDB(sqlcommand, parameters);

            dbHelper.CloseDB();
            BindGV.ShowGV(DbTable, GridViewCountry);
            DropDownList1.DataBind();
        }

        protected void GridViewCountry_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int IndexRow = e.RowIndex;
            GridViewRow row = GridViewCountry.Rows[IndexRow];

            TextBox TextEditCountrySort = (TextBox)row.FindControl("TextBoxEditCountrySort");
            //TextBox TextVideoTitle = (TextBox)row.FindControl("TextBoxEditVideoTitle");

            string IDKey = GridViewCountry.DataKeys[IndexRow].Value.ToString();

            DbHelper dbHelper = new DbHelper();

            string sqlCommand = $"UPDATE {DbTable} SET [countrySort] = @countrySort WHERE [country_ID] = @country_ID";

            //string sqlCommand = $"UPDATE {DbTable} SET [VideoTitle] = @VideoTitle , [VideoCategory] = @VideoCategory , [VideoScrUrl_YT] = @VideoScrUrl_YT, [VideoScrUrl_YT_vID] = @VideoScrUrl_YT_vID, [VideoCoverUrl] = @VideoCoverUrl, [VideoContent] = @VideoContent, [PinTop] = @PinTop, [CreatedTime] = {CreatedTimeStr} WHERE [VideoID] = @VideoID";

            //不要忘記檢查WHERE!!!!!!!!!!
            //不要忘記檢查WHERE!!!!!!!!!!
            //不要忘記檢查WHERE!!!!!!!!!!

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@country_ID"] = IDKey;
            parameters["@countrySort"] = TextEditCountrySort.Text;

            dbHelper.SearchDB(sqlCommand, parameters);

            dbHelper.CloseDB();
            GridViewCountry.EditIndex = -1;
            BindGV.ShowGV(DbTable, GridViewCountry);
        }

        protected void ButtonAddCountry_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);
            //2.sql語法
            string sqlcheck = "SELECT COUNT(countrySort) FROM CountrySort WHERE countrySort = @countrySort";

            SqlCommand commandcheck = new SqlCommand(sqlcheck, connection);
            commandcheck.Parameters.AddWithValue("@countrySort", TextBoxAddCountry.Text);
            connection.Open();

            int chknum = (int)commandcheck.ExecuteScalar();
            connection.Close();

            if (chknum > 0 || string.IsNullOrEmpty(TextBoxAddCountry.Text) || string.IsNullOrWhiteSpace(TextBoxAddCountry.Text))
            {
                //有資料重複or空白or Null
                TextBoxAddCountry.Text = "";
                LabelAddCountryAlert.Visible = true;
                LabelAddCountryAlert.Text = "輸入值重複、空白或未輸入，請確認";
            }
            else
            {
                //2.sql語法
                string sql = "INSERT INTO CountrySort (countrySort) VALUES(@countryName)";
                //3.創建command物件
                SqlCommand command = new SqlCommand(sql, connection);
                //4.參數化避免攻擊
                command.Parameters.AddWithValue("@countryName", TextBoxAddCountry.Text);
                //5.資料庫連線開啟
                connection.Open();
                //6.執行sql (新增刪除修改)
                command.ExecuteNonQuery(); //無回傳值
                                           //7.資料庫關閉
                connection.Close();
                //畫面渲染

                BindGV.ShowGV(DbTable, GridViewCountry);
                //GridViewCountry.DataBind();
                DropDownList1.DataBind();
                //清空輸入欄位
                TextBoxAddCountry.Text = "";
                LabelAddCountryAlert.Visible = true;
                LabelAddCountryAlert.Text = "";
            }

        }


        #endregion

        #region 

        #endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Panel1.Visible)
            {
                Panel1.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
            }
            
           
        }
    }
}