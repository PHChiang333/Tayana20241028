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
    public partial class WebForm1yachtManageEdit03 : System.Web.UI.Page
    {
        //TODO  邏輯:
        //先新增spec title
        //選擇spec title  (dropdown list) 或是用gridview 的 select處理
        //在下方的ckeditor編輯後update

        //delete 用gridview 處理

        //DB 邏輯
        // spec table
        // specId -- yachtId --specTitle -- specContent

        //渲染的時候
        //SELECT * FROM yachtSpec WHERE yachtId = @yachtId ORDER BY createdTime ASC;

        string selYachtId;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["YachtId"] != null)
            {
                selYachtId = Request.QueryString["YachtId"];
            }
            else
            {
                //TODO 跳轉不會顯示提示框，待解決

                ////沒找到YachtId 後跳出提示框
                ////跳轉回去 List 頁面
                //string script = @"<script type='text/javascript'>alert('請選擇News再修改'); window.location.href='WebForm1NewsManage.aspx';</script>";
                //ClientScript.RegisterStartupScript(this.GetType(), "NoIDKey", script,true);

                //Response.End();
                Response.Redirect("WebForm1yachtManage.aspx");
                //Response.Write("<script>alert('請選擇 News 再修改');</script>");
                //return;
            }


            if (!IsPostBack)
            {
                //databinging
                TextboxDataBind();
                //ShowRepeaterImg();
                //ShowRepeaterFile();
                //loadRowList(); //取得尺寸欄位內容
                //renderRowList(); //渲染尺寸欄位內容


                //編輯失敗的時候不會失去原本的資料
                //if (ViewState["NewsTilte"] != null || ViewState["NewsSummary"] != null || ViewState["NewsContent"] != null)
                //{
                //    TextBoxEditNewsTitle.Text = ViewState["EditNewsTilte"].ToString();
                //    TextBoxEditSummary.Text = ViewState["EditNewsSummary"].ToString();
                //    //TextBoxEditContent.Text = ViewState["EditNewsContent"].ToString();
                //    CheckBoxEditIsPintop.Checked = (bool)ViewState["EditIsPintop"];
                //}

                ShowGVYachtSpec("yachtSpec", GridViewSpecList,selYachtId);
            }
            else
            {

            }
        }

        protected void ButtonToCreateSpec_Click(object sender, EventArgs e)
        {
            string IDKey = selYachtId;
            
            string sqlcmd = $"INSERT INTO yachtSpec([YachtId] ,[specTitle]) VALUES (@YachtId ,@specTitle);";

            string connstring = "tayanaConnectionString";

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);

            SqlCommand command = new SqlCommand(sqlcmd, connection);
            command.Parameters.AddWithValue("@YachtId", IDKey);
            command.Parameters.AddWithValue("@specTitle", TextBoxAddSpec.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            TextBoxAddSpec.Text = "";

            string script = @"<script type='text/javascript'>alert('新增成功！');";
            ClientScript.RegisterStartupScript(this.GetType(), "addYachtSpecSuccess", script);

            ShowGVYachtSpec("yachtSpec", GridViewSpecList, selYachtId);
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // 1. 找到特定表格行數 (Row) ⇒ ex：第五行
            int IndexRow = e.RowIndex;

            // 2. 找到該行數的 Key Value (ID) ⇒ ex：第五行中的 ID 欄位值
            string IDkey = GridViewSpecList.DataKeys[IndexRow].Value.ToString();

            // 3. 透過SQL語法進行資料的修改
            DbHelper db = new DbHelper();
            string sqlCommand = $"Delete From yachtSpec Where YachtSpecId = @YachtSpecId";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@YachtSpecId"] = IDkey;
            db.SearchDB(sqlCommand, parameters);


            // 4. 補充：不要忘記重新執行 showGV()
            db.CloseDB();
            ShowGVYachtSpec("yachtSpec", GridViewSpecList,selYachtId);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 取得選取行的索引
            int selectedIndex = GridViewSpecList.SelectedIndex;

            // 使用 DataKeys 取得選取行的 IDKey 值
            string idKey = GridViewSpecList.DataKeys[selectedIndex].Value.ToString();

            // 跳轉到指定頁面，並使用 QueryString 傳遞 IDKey
            Response.Redirect($"WebForm1yachtManageEdit03Edit.aspx?YachtId={selYachtId}&YachtSpecId={idKey}");
            //Response.Write(idKey);
        }

        private void TextboxDataBind()
        {
            if (Request.QueryString["YachtId"] != null)
            {
                string IDkey = Request.QueryString["YachtId"];

                string sqlcmd = $"SELECT * FROM yacht WHERE YachtId = @YachtId;";

                string connstring = "tayanaConnectionString";
                //連接資料庫
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);

                SqlCommand command = new SqlCommand(sqlcmd, connection);
                command.Parameters.AddWithValue("@YachtId", IDkey);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    TextBoxEditYachtName.Text = reader["YachtName"].ToString();
                    //TextBoxEditYachtNameTag.Text = reader["YachtNameTag"].ToString();
                    //editor1.Value = HttpUtility.HtmlDecode(reader["YachtDesc"].ToString());

                    //CheckBoxEditYachtIsPintop.Checked = (bool)reader["IsPintop"];

                }
                else
                {
                    //沒找到資料 後跳出提示框
                    //跳轉回去 List 頁面
                    string script = @"<script type='text/javascript'>alert('請確認資料是否正確'); window.location.href = 'WebForm1NewsManage.aspx';</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "NoData", script);
                }
            }
            else
            {

            }


        }

        public static void ShowGVYachtSpec(string DbTable, GridView GridID, string selYachtId)
        {
            DbHelper helper = new DbHelper();

            string sqlCommand = $"Select * From {DbTable} WHERE YachtId = {selYachtId}";
            using (SqlDataReader reader = helper.SearchDB(sqlCommand))
            {
                GridID.DataSource = reader;
                GridID.DataBind();
            }

        }



    }
}