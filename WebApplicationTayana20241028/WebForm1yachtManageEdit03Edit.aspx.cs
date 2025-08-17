using AjaxControlToolkit.HtmlEditor;
using Newtonsoft.Json;
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
    public partial class WebForm1yachtManageEdit03Edit : System.Web.UI.Page
    {

        string selYachtId;
        string selYachtSpecId;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["YachtId"] != null)
            {
                selYachtId = Request.QueryString["YachtId"];

                if (Request.QueryString["YachtSpecId"] != null) 
                {
                    selYachtSpecId = Request.QueryString["YachtSpecId"];

                }
                else
                {
                    Response.Redirect($"WebForm1yachtManageEdit03.aspx?YachtId={selYachtId}");
                }
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


                //編輯失敗的時候不會失去原本的資料
                //if (ViewState["NewsTilte"] != null || ViewState["NewsSummary"] != null || ViewState["NewsContent"] != null)
                //{
                //    TextBoxEditNewsTitle.Text = ViewState["EditNewsTilte"].ToString();
                //    TextBoxEditSummary.Text = ViewState["EditNewsSummary"].ToString();
                //    //TextBoxEditContent.Text = ViewState["EditNewsContent"].ToString();
                //    CheckBoxEditIsPintop.Checked = (bool)ViewState["EditIsPintop"];
                //}
            }
            else
            {

            }

        }

        private void TextboxDataBind()
        {
            if (Request.QueryString["YachtId"] != null)
            {
                selYachtId = Request.QueryString["YachtId"];

                if (Request.QueryString["YachtSpecId"] != null)
                {
                    selYachtSpecId = Request.QueryString["YachtSpecId"];

                    string sqlcmd = $"SELECT * FROM yachtSpec WHERE YachtSpecId = @YachtSpecId;";

                    string connstring = "tayanaConnectionString";
                    //連接資料庫
                    SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);

                    SqlCommand command = new SqlCommand(sqlcmd, connection);
                    command.Parameters.AddWithValue("@YachtSpecId", selYachtSpecId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        
                        TextBoxEditSepcTitle.Text = reader["specTitle"].ToString();
                        editorSpecContent.Value = HttpUtility.HtmlDecode(reader["specContent"].ToString());
                    }

                }
                else
                {
                    Response.Redirect($"WebForm1yachtManageEdit03.aspx?YachtId={selYachtId}");
                }
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


        }








        protected void ButtonUpdateSpec_Click(object sender, EventArgs e)
        {
            string IDkey = selYachtSpecId;

            string sqlcmd = $"UPDATE yachtSpec " +
                $"SET specTitle = @specTitle ,specContent = @specContent " +
                $"WHERE YachtSpecId = @YachtSpecId ; ";

            string connstring = "tayanaConnectionString";
            //連接資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);

            SqlCommand command = new SqlCommand(sqlcmd, connection);
            command.Parameters.AddWithValue("@YachtSpecId", IDkey);
            command.Parameters.AddWithValue("@specTitle", TextBoxEditSepcTitle.Text);
            string textValue = HttpUtility.HtmlEncode(editorSpecContent.Value);
            command.Parameters.AddWithValue("@specContent", textValue);

            //連接DB 執行SQL指令
            connection.Open();
            command.ExecuteNonQuery();
            //關閉DB
            connection.Close();

            //復歸input values
            editorSpecContent.Value = "";

            ViewState.Clear();

            //新增完成後跳出提示框
            //跳轉回去 List 頁面
            string script = $"<script type='text/javascript'>alert('修改成功！'); window.location.href = 'WebForm1yachtManageEdit03.aspx?YachtId={selYachtId}';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "editSpecSuccess", script);



        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            //回到 Spec ist
            string path = $"WebForm1yachtManageEdit03.aspx?YachtId={selYachtId}";
            Response.Redirect(path);

        }
    }
}