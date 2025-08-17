using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTayana20241028
{
    public partial class Back : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPower();
            }
        }

        protected void ButtonToLoginPage_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogout.ashx");
        }


        //TODO 非ADMIN 把UserManagement拔掉
        /// <summary>
        /// 非ADMIN 把UserManagement功能拔掉
        /// </summary>
        protected void CheckPower()
        {
            //權限關門判斷 (Cookie)
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("WebForm1UserLogin.aspx"); //導回登入頁
            }
            else
            {
                //取得驗證票夾帶資訊
                string ticketUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
                string[] ticketUserDataArr = ticketUserData.Split(';');
                bool haveRight = HttpContext.Current.User.Identity.IsAuthenticated;
                //依管理權限導頁
                if (haveRight)
                {
                    if (ticketUserDataArr[0].Equals("True"))
                    {
                        //以驗證票夾帶資料作為限制，最高權限者使用時顯示使用者管理頁並切換圖示
                        HyperLinkUserManage.Visible = true;
                        ButtonLogout.Visible = true;
                    }
                    else
                    {
                        HyperLinkUserManage.Visible = false;
                        ButtonLogout.Visible = true;
                    }
                    //載入使用者個人基本資料(渲染畫面)
                    LabelUserNameLogin.Text = $"{ticketUserDataArr[1]},您好";
                    //LabMenuEmail.Text = ticketUserDataArr[3];
                    //LabHeadUserName.Text = ticketUserDataArr[2];
                }
            }
        }




    }
}