using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTayana20241028
{
    public partial class WebForm1NewsManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGV.ShowGV("News", GridViewNewsList);
            }
        }





        protected void ButtonToCreateNews_Click(object sender, EventArgs e)
        {
            string path = @"WebForm1NewsManageCreate.aspx";
            Response.Redirect(path);
        }

        protected void GridViewNewsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 取得選取行的索引
            int selectedIndex = GridViewNewsList.SelectedIndex;

            // 使用 DataKeys 取得選取行的 IDKey 值
            string idKey = GridViewNewsList.DataKeys[selectedIndex].Value.ToString();

            // 跳轉到指定頁面，並使用 QueryString 傳遞 IDKey
            Response.Redirect($"WebForm1NewsManageEdit.aspx?NewsId={idKey}");
        }

        protected void GridViewNewsList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // 1. 找到特定表格行數 (Row) ⇒ ex：第五行
            int IndexRow = e.RowIndex;

            // 2. 找到該行數的 Key Value (ID) ⇒ ex：第五行中的 ID 欄位值
            string IDkey = GridViewNewsList.DataKeys[IndexRow].Value.ToString();

            // 3. 透過SQL語法進行資料的修改
            DbHelper db = new DbHelper();
            string sqlCommand = $"Delete From News Where NewsId = @NewsId";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@NewsId"] = IDkey;
            db.SearchDB(sqlCommand, parameters);


            // 4. 補充：不要忘記重新執行 showGV()
            db.CloseDB();
            BindGV.ShowGV("News", GridViewNewsList); ;   //當然也可以Redirect，就不用showGV了
        }





    }
}