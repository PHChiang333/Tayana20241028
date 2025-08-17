using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTayana20241028
{
    public partial class WebForm1UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegist_Click(object sender, EventArgs e)
        {
            bool haveSameAccount = false;

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);
            string sqlCheck = "SELECT * FROM managerData WHERE account = @account";
            string sqlAdd = "INSERT INTO managerData (account, password, salt) VALUES(@account, @password, @salt)";
            SqlCommand commandCheck = new SqlCommand(sqlCheck, connection);
            SqlCommand commandAdd = new SqlCommand(sqlAdd, connection);

            //檢查有無重複帳號
            commandCheck.Parameters.AddWithValue("@account", TextBoxAddAccount.Text);
            connection.Open();
            SqlDataReader readerCountry = commandCheck.ExecuteReader();
            if (readerCountry.Read())
            {
                haveSameAccount = true;
                LabelAlert.Text = "Account Exists!";
                LabelAlert.Visible = true; //帳號重複通知
            }
            connection.Close();

            //無重複帳號才執行加入
            if (!haveSameAccount)
            {
                //Hash 加鹽加密
                string password = TextBoxAddPassword.Text;
                var salt = CreateSalt();
                string saltStr = Convert.ToBase64String(salt); //將 byte 改回字串存回資料表
                var hash = HashPassword(password, salt);
                string hashPassword = Convert.ToBase64String(hash);

                commandAdd.Parameters.AddWithValue("@account", TextBoxAddAccount.Text);
                commandAdd.Parameters.AddWithValue("@password", hashPassword);
                commandAdd.Parameters.AddWithValue("@salt", saltStr);

                connection.Open();
                commandAdd.ExecuteNonQuery();
                connection.Close();
                //清空輸入欄位
                TextBoxAddAccount.Text = "";
                TextBoxAddPassword.Text = "";
                LabelAlert.Visible = false;

                //Response.Write("<script>alert('註冊成功，請重新登入。');</script>");
                //Response.Redirect(@"WebForm1Login.aspx");

                string script = "alert('註冊成功！即將跳轉至登入頁面。'); window.location.href='WebForm1UserLogin.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccess", script, true);

            }
            else
            {
                //Response.Write("<script>alert('註冊失敗，請重新註冊。');</script>");

                string script = "alert('註冊失敗，請重新註冊。'); window.location.href='WebForm1Register.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationFailure", script, true);

            }





            

        }

        // Argon2 加密
        //產生 Salt 功能
        private byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }

        // Hash 處理加鹽的密碼功能
        private byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            //底下這些數字會影響運算時間，而且驗證時要用一樣的值
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // 4 核心就設成 8
            argon2.Iterations = 4; // 迭代運算次數
            argon2.MemorySize = 1024 * 1024; // 1 GB

            return argon2.GetBytes(16);
        }




    }
}