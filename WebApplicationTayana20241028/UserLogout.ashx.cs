using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebApplicationTayana20241028.datta_able_bootstrap_dashboard
{
    /// <summary>
    /// UserLogout 的摘要描述
    /// </summary>
    public class UserLogout : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            if (context.Session != null)
            {
                context.Session.Abandon();
                context.Session.RemoveAll();
            }
            HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            authenticationCookie.Expires = DateTime.Now.AddYears(-1);
            context.Response.Cookies.Add(authenticationCookie);
            FormsAuthentication.SignOut();
            context.Response.Redirect("WebForm1Index.aspx", true);


        }






    

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}