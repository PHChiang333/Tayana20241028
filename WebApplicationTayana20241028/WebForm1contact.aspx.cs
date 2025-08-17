using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

using MailKit.Net.Smtp;
using MimeKit;

namespace WebApplicationTayana20241028
{
    public partial class WebForm1compan01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadModelList();
            }
        }




        protected void submitButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (String.IsNullOrEmpty(Recaptcha1.Response))
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Captcha cannot be empty.";
            }
            else
            {
                var result = Recaptcha1.Verify();
                if (result.Success)
                {
                    //此處可加入"我不是機器人驗證"成功後要做的事
                    sendGmail();
                }
                else
                {
                    lblMessage.Text = "Error(s): ";

                    foreach (var err in result.ErrorCodes)
                    {
                        lblMessage.Text = lblMessage.Text + err;
                    }
                }
            }
        }

        /// <summary>
        /// Yachts下拉選單載入
        /// </summary>
        private void loadModelList()
        {
            // 1. 連線資料庫：使用 Web.Config 中的連接字串建立 SqlConnection 物件
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);

            // 2. SQL 語法：定義 SQL 查詢語句，選取 Yachts 資料表中的所有資料
            string sql = "SELECT * FROM yacht";

            // 3. 創建 SqlCommand 物件：將 SQL 語句和連線物件傳入，以便之後執行查詢
            SqlCommand command = new SqlCommand(sql, connection);

            // 取得遊艇型號分類，打開資料庫連接
            connection.Open();

            // 執行 SQL 查詢並取得 SqlDataReader 物件，用於讀取查詢結果
            SqlDataReader readerType = command.ExecuteReader();

            // 4. 使用 while 迴圈逐行讀取查詢結果，直到沒有更多資料為止
            while (readerType.Read())
            {
                // 取得當前行的 YachtName 欄位並轉為字串，代表遊艇型號
                string YachtName = readerType["YachtName"].ToString();

                // 取得當前行的 YachtNameTag 欄位並轉為字串，判斷是否為新設計
                string YachtNameTag = readerType["YachtNameTag"].ToString();

                // 5. 建立新的 ListItem 物件，表示下拉選單中的一個項目
                ListItem listItem = new ListItem();

                // 判斷是否有Tag
                if (!string.IsNullOrEmpty(YachtNameTag))
                {
                    // 若為新設計，則將下拉選單項目的文字設為“型號 (Tag)”
                    listItem.Text = $"{YachtName} ({YachtNameTag})";

                    // 將新設計的 ListItem 物件加入到下拉選單 Yachts 中
                    Yachts.Items.Add(listItem);
                }
                else
                {
                    // 若不是新設計或新建，則僅將下拉選單項目的文字設為型號名稱
                    listItem.Text = YachtName;
                    listItem.Value = YachtName;

                    // 將標準型號的 ListItem 物件加入到下拉選單 Yachts 中
                    Yachts.Items.Add(listItem);
                }
            }

            // 6. 查詢結束後關閉資料庫連接，以釋放資源
            connection.Close();
        }

        public void sendGmail()
        {
            //宣告使用 MimeMessage
            var message = new MimeMessage();
            //設定發信地址 ("發信人", "發信 email")
            message.From.Add(new MailboxAddress("TayanaYacht", "franktestplatform001@gmail.com"));
            //設定收信地址 ("收信人", "收信 email")
            message.To.Add(new MailboxAddress(Name.Text.Trim(), Email.Text.Trim()));
            //寄件副本email
            message.Cc.Add(new MailboxAddress("收信人名稱", "franktestplatform001@gmail.com"));
            //設定優先權
            //message.Priority = MessagePriority.Normal;
            //信件標題
            message.Subject = "TayanaYacht Auto Email";
            //建立 html 郵件格式
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody =
                "<h1>Thank you for contacting us!</h1>" +
                $"<h3>Name : {Name.Text.Trim()}</h3>" +
                $"<h3>Email : {Email.Text.Trim()}</h3>" +
                $"<h3>Phone : {Phone.Text.Trim()}</h3>" +
                $"<h3>Country : {Country.SelectedValue}</h3>" +
                $"<h3>Type : {Yachts.SelectedValue}</h3>" +
                $"<h3>Comments : </h3>" +
                $"<p>{Comments.Text.Trim()}</p>";
            //設定郵件內容
            message.Body = bodyBuilder.ToMessageBody(); //轉成郵件內容格式

            using (var client = new SmtpClient())
            {
                //有開防毒時需設定 false 關閉檢查
                client.CheckCertificateRevocation = false;
                //設定連線 gmail ("smtp Server", Port, SSL加密) 
                client.Connect("smtp.gmail.com", 587, false); // localhost 測試使用加密需先關閉 

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("franktestplatform001@gmail.com", "tmzcllcdkfwcvfsb");  //Email,應用程式密碼16碼
                //發信
                client.Send(message);
                //結束連線
                client.Disconnect(true);
            }
        }





    }
}