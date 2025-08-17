using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplicationTayana20241028
{
    public partial class WebForm1UserManage : System.Web.UI.Page
    {

        string DbTable = "managerData";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindGV.ShowGV(DbTable, GridViewUserList);
            
            }
            else
            {

            }
            
            
            
            
            

        }

        //TODO 使用者管理(Admin權限)(後臺主題)

        protected void ButtonAddUser_Click(object sender, EventArgs e)
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
                LabelAdd.Text = "Account Exists!";
                LabelAdd.Visible = true; //帳號重複通知
                
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
                //畫面渲染
                //GridViewUserList.DataBind();
                BindGV.ShowGV(DbTable, GridViewUserList);
                //清空輸入欄位
                TextBoxAddAccount.Text = "";
                TextBoxAddPassword.Text = "";
                LabelAdd.Visible = false;
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



        protected void GridViewUserList_DataBound(object sender, EventArgs e)
        {
            GridViewUserList.Rows[0].Cells[1].Controls.Clear();
        }

        protected void GridViewUserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            bool haveSameAccount = false;

            // 1. 找到特定表格行數 (Row) ⇒ ex：第五行
            int IndexRow = e.RowIndex;

            // 2. 找到該行數的 Key Value (ID) ⇒ ex：第五行中的 ID 欄位值
            string IDkey = GridViewUserList.DataKeys[IndexRow].Value.ToString();

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);
            string sqlCheck = "SELECT * FROM managerData WHERE UserId = @UserId";
            string sqlAdd = "DELETE FROM managerData WHERE UserId = @UserId";
            SqlCommand commandCheck = new SqlCommand(sqlCheck, connection);
            SqlCommand commandAdd = new SqlCommand(sqlAdd, connection);

            //檢查有無重複帳號
            commandCheck.Parameters.AddWithValue("@UserId", IDkey);
            connection.Open();
            SqlDataReader readerCountry = commandCheck.ExecuteReader();

            if (readerCountry.Read())
            {
                haveSameAccount = true;
            }
            connection.Close();

            //有重複帳號才執行刪除
            if (haveSameAccount)
            {
                commandAdd.Parameters.AddWithValue("@UserId", IDkey);

                connection.Open();
                commandAdd.ExecuteNonQuery();
                connection.Close();
                //畫面渲染
                BindGV.ShowGV(DbTable, GridViewUserList);
                //清空輸入欄位


            }

        }

        //TODO USER 註冊(ADD)還沒做










    }
}