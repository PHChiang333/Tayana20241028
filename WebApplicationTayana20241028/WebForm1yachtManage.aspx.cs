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
    public partial class WebForm1yachtManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGV.ShowGV("yacht", GridViewYachtList);
            }
        }

        //protected void ButtonToCreateYacht_Click(object sender, EventArgs e)
        //{
        //    string path = @"WebForm1yachtManageCreate1.aspx";
        //    Response.Redirect(path);
        //}

        protected void ButtonAddYacht_Click(object sender, EventArgs e)
        {
            string sqlcmd = $"INSERT INTO yacht([YachtName]) VALUES (@YachtName);";

            string connstring = "tayanaConnectionString";

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);

            SqlCommand command = new SqlCommand(sqlcmd, connection);
            command.Parameters.AddWithValue("@YachtName", TextBoxAddYachtName.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            TextBoxAddYachtName.Text = "";

            string script = @"<script type='text/javascript'>alert('新增成功！');";
            ClientScript.RegisterStartupScript(this.GetType(), "addYachtSuccess", script);

            BindGV.ShowGV("yacht", GridViewYachtList);

        }



        protected void GridViewYachtList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // 1. 找到特定表格行數 (Row) ⇒ ex：第五行
            int IndexRow = e.RowIndex;

            // 2. 找到該行數的 Key Value (ID) ⇒ ex：第五行中的 ID 欄位值
            string IDkey = GridViewYachtList.DataKeys[IndexRow].Value.ToString();

            // 3. 透過SQL語法進行資料的修改
            DbHelper db = new DbHelper();
            string sqlCommand = $"Delete From yacht Where YachtId = @YachtId";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@YachtId"] = IDkey;
            db.SearchDB(sqlCommand, parameters);


            // 4. 補充：不要忘記重新執行 showGV()
            db.CloseDB();
            BindGV.ShowGV("yacht", GridViewYachtList);  
        }

        protected void GridViewYachtList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 取得選取行的索引
            int selectedIndex = GridViewYachtList.SelectedIndex;

            // 使用 DataKeys 取得選取行的 IDKey 值
            string idKey = GridViewYachtList.DataKeys[selectedIndex].Value.ToString();

            // 跳轉到指定頁面，並使用 QueryString 傳遞 IDKey
            Response.Redirect($"WebForm1yachtManageEdit01.aspx?YachtId={idKey}");
            //Response.Write(idKey);
        }
    }
}