using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplicationTayana20241028
{
    public partial class WebForm1BackNewsCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //新增失敗的時候不會失去原本的資料
                if (ViewState["NewsTilte"] != null || ViewState["NewsSummary"] != null || ViewState["NewsContent"] != null)
                {
                    TextBoxAddNewsTitle.Text = ViewState["NewsTilte"].ToString();
                    TextBoxAddSummary.Text = ViewState["NewsSummary"].ToString();
                    TextBoxAddContent.Text = ViewState["NewsContent"].ToString();
                }
            }
            else
            {
                //填入暫存資料

            }
            //ShowRepeaterImg();
        }

        protected void ButtonAddNews_Click(object sender, EventArgs e)
        {
            string sqlcmd = $"INSERT INTO News([NewsTilte],[NewsSummary],[NewsContent],[NewsDate],[IsPintop]) VALUES (@NewsTilte,@NewsSummary,@NewsContent,@NewsDate,@IsPintop)";

            string connstring = "tayanaConnectionString";
            //連接資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);

            SqlCommand command = new SqlCommand(sqlcmd, connection);

            //確認時間格式
            DateTime selectedDateTime;
            if (DateTime.TryParseExact(TextBoxAddNewsDate.Text, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out selectedDateTime))
            {
                // 解析成功，繼續處理邏輯
                command.Parameters.AddWithValue("@NewsDate", TextBoxAddNewsDate.Text);

                if (CheckBoxAddIsPintop.Checked)
                {
                    command.Parameters.AddWithValue("@IsPintop", '1');
                }
                else
                {
                    command.Parameters.AddWithValue("@IsPintop", '0');
                }

                command.Parameters.AddWithValue("@NewsTilte", TextBoxAddNewsTitle.Text);
                command.Parameters.AddWithValue("@NewsSummary", TextBoxAddSummary.Text);
                //command.Parameters.AddWithValue("@NewsContent", TextBoxAddContent.Text);


                string textValue = HttpUtility.HtmlEncode(editor1.Value);
                command.Parameters.AddWithValue("@NewsContent", textValue);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                TextBoxAddNewsDate.Text = "";
                CheckBoxAddIsPintop.Checked = false;
                TextBoxAddNewsTitle.Text = "";
                TextBoxAddSummary.Text = "";
                TextBoxAddContent.Text = "";
                ViewState.Clear();


                //新增完成後跳出提示框
                //跳轉回去 List 頁面
                string script = @"<script type='text/javascript'>alert('新增成功！'); window.location.href = 'WebForm1NewsManage.aspx';</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "addNewsSuccess", script);

            }
            else
            {
                ViewState["NewsTilte"] = TextBoxAddNewsTitle.Text;
                ViewState["NewsSummary"] = TextBoxAddSummary.Text;
                ViewState["NewsContent"] = TextBoxAddContent.Text;
                // 解析失敗，顯示錯誤訊息
                ClientScript.RegisterStartupScript(this.GetType(), "dateFormatError", "alert('請確認日期格式！');", true);
            }


        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1NewsManage.aspx");
        }









        //protected void ShowImg()
        //{
        //    DbHelper db = new DbHelper();
        //    string sql = "SELECT * FROM NewsImg ORDER BY CreatedTime DESC";
        //    SqlDataReader rd = db.SearchDB(sql);
        //    if (rd.HasRows)
        //    {
        //        //rd.Read();   // Note： If 和 While 的用法差別，

        //        while (rd.Read())
        //        {
        //            Image1.ImageUrl = rd["ImgPath"].ToString();
        //        }


                
        //    }
        //    db.CloseDB();
        //}

        //protected void ButtonUploadImage_Click(object sender, EventArgs e)
        //{
        //    // 1. 取的Server資料夾路徑 (記得要先去 建立資料夾)
        //    string ServerFolderPath = Server.MapPath("~/image/upload/test/");

        //    string connstring = "tayanaConnectionString";
        //    using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
        //    {
        //        SqlCommand sqlCommand = new SqlCommand();
        //        sqlCommand.Connection = connection;
        //        connection.Open(); // 在使用之前打開連接
        //        // 2. 確認 FileUpload 控制項，是否有檔案
        //        if (FileUpload1.HasFiles)  // Note：控制項目可以開啟 "AllowMultiple" 功能
        //        {
        //            // 3. 將 FileUpload 控制項裡面的檔案跑迴圈
        //            foreach (var postfile in FileUpload1.PostedFiles)
        //            {
        //                // 4. 建立 單一檔案 篩選邏輯                                                                          
        //                int FileMemory = postfile.ContentLength;  // 取得 單一檔案 容量變數      
        //                string FileName = Path.GetFileName(postfile.FileName); // 取得 單一檔案 名稱變數
        //                string FileExtension = Path.GetExtension(postfile.FileName).ToLower(); // 取得 單一檔案 檔名變數，並轉成小寫
        //                string FilePath = Path.Combine(ServerFolderPath, FileName);  // 取得 單一檔案 儲存路徑

        //                if (FileMemory > 1000000)           // 4-1. 如果 單一檔案 大於 1M，跳過不存
        //                {
        //                    continue;
        //                }
        //                else if (FileExtension != ".jpg")   // 4-2. 如果 單一檔案 不是".jpg"檔名 跳過不存
        //                {
        //                    continue;
        //                }
        //                else    // 4-3. 如果 單一檔案 吻合格式
        //                {
        //                    // 5. 進行 資料庫 寫入
        //                    string pathStore = "/image/upload/test/" + FileName;


        //                    string sql = $"INSERT INTO NewsImg (ImgName, ImgPath) VALUES (@ImgName, @ImgPath)";
        //                    sqlCommand.CommandText = sql;
        //                    sqlCommand.Parameters.Clear(); // 確保每次執行前清除先前的參數
        //                    sqlCommand.Parameters.AddWithValue("@ImgName", FileName);
        //                    sqlCommand.Parameters.AddWithValue("@ImgPath", pathStore);

        //                    int result = sqlCommand.ExecuteNonQuery();
        //                    if (result == 1)
        //                    {
        //                        postfile.SaveAs(FilePath);  // 成功資料庫寫入後，將檔案存入指定資料夾路徑
        //                        Response.Write($"<script>alert('已上傳{result}個檔案')</script>");
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('沒有選擇任何檔案')</script>");
        //        }
        //        connection.Close();  // 在使用之後關閉連接
        //    }

        //    //ShowImg(); // 呼叫渲染圖片的function
        //    ShowRepeaterImg();

        //}

        //protected void ShowRepeater()  //記得要把 ShowRepeater() 放到 Page_Load
        //{
        //    DbHelper db = new DbHelper();
        //    string sql = "SELECT * FROM Video";
        //    SqlDataReader rd = db.SearchDB(sql);
        //    if (rd.HasRows)
        //    {
        //        RepeaterMultilImg.DataSource = rd;
        //        RepeaterMultilImg.DataBind();
        //    }
        //    db.CloseDB();
        //}

        //protected void ShowRepeaterImg()  //記得要把 ShowRepeater() 放到 Page_Load
        //{
        //    DbHelper db = new DbHelper();
        //    string sql = "SELECT * FROM NewsImg";
        //    SqlDataReader rd = db.SearchDB(sql);
        //    if (rd.HasRows)
        //    {
        //        RepeaterMultilImg.DataSource = rd;
        //        RepeaterMultilImg.DataBind();
        //    }
        //    db.CloseDB();
        //}


        //// 處理 Repeater 的按鈕指令
        //protected void rptPhotos_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "Delete")
        //    {
        //        int photoID = Convert.ToInt32(e.CommandArgument);
        //        DeletePhoto(photoID);
        //        ShowRepeaterImg();
        //    }
        //}





        //// 刪除照片
        //private void DeletePhoto(int NewsImgId)
        //{
        //    string connstring = "tayanaConnectionString";
        //    using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
        //    {
        //        // 先取得照片的路徑
        //        string getPathQuery = "SELECT ImgName FROM NewsImg WHERE NewsImgId = @NewsImgId";
        //        string deleteQuery = "DELETE FROM NewsImg WHERE NewsImgId = @NewsImgId";
        //        conn.Open();

        //        string imgPath = string.Empty;
        //        using (SqlCommand getCmd = new SqlCommand(getPathQuery, conn))
        //        {
        //            getCmd.Parameters.AddWithValue("@NewsImgId", NewsImgId);
        //            imgPath = getCmd.ExecuteScalar()?.ToString();
        //        }

        //        // 刪除資料庫記錄
        //        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
        //        {
        //            deleteCmd.Parameters.AddWithValue("@NewsImgId", NewsImgId);
        //            deleteCmd.ExecuteNonQuery();
        //        }

        //        // 刪除伺服器上的檔案
        //        if (!string.IsNullOrEmpty(imgPath))
        //        {
        //            string serverPath = Server.MapPath(imgPath);
        //            if (File.Exists(serverPath))
        //            {
        //                File.Delete(serverPath);
        //            }
        //        }
        //    }
        //    ShowRepeaterImg();
        //}



    }
}