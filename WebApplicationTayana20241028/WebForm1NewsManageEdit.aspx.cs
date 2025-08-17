using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplicationTayana20241028
{




    public partial class WebForm1NewsManageEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["NewsId"] != null)
            {
                string selNewsId = Request.QueryString["NewsId"];
            }
            else
            {
                //TODO 跳轉不會顯示提示框，待解決

                ////沒找到NewsId 後跳出提示框
                ////跳轉回去 List 頁面
                //string script = @"<script type='text/javascript'>alert('請選擇News再修改'); window.location.href='WebForm1NewsManage.aspx';</script>";
                //ClientScript.RegisterStartupScript(this.GetType(), "NoIDKey", script,true);

                //Response.End();
                Response.Redirect("WebForm1NewsManage.aspx");
                //Response.Write("<script>alert('請選擇 News 再修改');</script>");
                //return;
            }


            if (!IsPostBack)
            {
                //databinging
                TextboxDataBind();
                ShowRepeaterCover();
                ShowRepeaterImg();
                ShowRepeaterFile();
                //編輯失敗的時候不會失去原本的資料
                if (ViewState["NewsTilte"] != null || ViewState["NewsSummary"] != null || ViewState["NewsContent"] != null)
                {
                    TextBoxEditNewsTitle.Text = ViewState["EditNewsTilte"].ToString();
                    TextBoxEditSummary.Text = ViewState["EditNewsSummary"].ToString();
                    //TextBoxEditContent.Text = ViewState["EditNewsContent"].ToString();
                    CheckBoxEditIsPintop.Checked = (bool)ViewState["EditIsPintop"];
                }
            }
        }

        private void TextboxDataBind()
        {
            if (Request.QueryString["NewsId"] != null)
            {
                string IDkey = Request.QueryString["NewsId"];

                string sqlcmd = $"SELECT * FROM News WHERE NewsId = @NewsId;";

                string connstring = "tayanaConnectionString";
                //連接資料庫
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);

                SqlCommand command = new SqlCommand(sqlcmd, connection);
                command.Parameters.AddWithValue("@NewsId", IDkey);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    TextBoxEditNewsTitle.Text = reader["NewsTilte"].ToString();
                    TextBoxEditSummary.Text = reader["NewsSummary"].ToString();
                    //TextBoxEditContent.Text = reader["NewsContent"].ToString();
                    editor1.Value = HttpUtility.HtmlDecode(reader["NewsContent"].ToString());

                    CheckBoxEditIsPintop.Checked = (bool)reader["IsPintop"];

                    //TODO 轉換為指定日期格式(yyyy-mm-dd)
                    //TextBoxEditNewsDate.Text = reader["NewsDate"].ToString();

                    //string newsDate = reader["NewsDate"].ToString();
                    //TextBoxEditNewsDate.Text = Regex.Match(newsDate, @"^\d{4}-\d{2}-\d{2}").Value;

                    //轉換日期為指定格式
                    if (!reader.IsDBNull(reader.GetOrdinal("NewsDate")))
                    {
                        DateTime NewsDate = (DateTime)reader["NewsDate"];

                        // 格式化為 yyyy-MM-dd 並賦值給 TextBox
                        TextBoxEditNewsDate.Text = NewsDate.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        // 如果是 NULL，則設置為空字串
                        TextBoxEditNewsDate.Text = "";
                    }



                }
                else
                {
                    //沒找到資料 後跳出提示框
                    //跳轉回去 List 頁面
                    string script = @"<script type='text/javascript'>alert('請確認資料是否正確'); window.location.href = 'WebForm1NewsManage.aspx';</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "addNewsSuccess", script);
                }
            }
            else
            {

            }






        }




        protected void ButtonUpdateNews_Click(object sender, EventArgs e)
        {
            string IDkey = Request.QueryString["NewsId"];

            string sqlcmd = $"UPDATE [News] " +
                $"SET [NewsTilte] = @NewsTilte,[NewsSummary] = @NewsSummary,[NewsContent] =@NewsContent,[NewsDate] = @NewsDate,[IsPintop] = @IsPintop ,[CoverImgPath]=@CoverImgPath " + " " +
                $"WHERE NewsId = @NewsId;";

            string connstring = "tayanaConnectionString";
            //連接資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);

            SqlCommand command = new SqlCommand(sqlcmd, connection);

            //確認時間格式
            DateTime selectedDateTime;
            if (DateTime.TryParseExact(TextBoxEditNewsDate.Text, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out selectedDateTime))
            {
                // 解析成功，繼續處理邏輯
                command.Parameters.AddWithValue("@NewsId", IDkey);

                //DateTime EditNewsDate;
                //DateTime.TryParse(TextBoxEditNewsDate.Text, out EditNewsDate);
                //command.Parameters.AddWithValue("@NewsDate", EditNewsDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@NewsDate", TextBoxEditNewsDate.Text);


                if (CheckBoxEditIsPintop.Checked)
                {
                    command.Parameters.AddWithValue("@IsPintop", '1');
                }
                else
                {
                    command.Parameters.AddWithValue("@IsPintop", '0');
                }

                command.Parameters.AddWithValue("@NewsTilte", TextBoxEditNewsTitle.Text);
                command.Parameters.AddWithValue("@NewsSummary", TextBoxEditSummary.Text);
                //command.Parameters.AddWithValue("@NewsContent", TextBoxEditContent.Text);
                string textValue = HttpUtility.HtmlEncode(editor1.Value);
                command.Parameters.AddWithValue("@NewsContent", textValue);

                string coverPath = @"/image/upload/NewsImg/Cover/sail-boat-in-water-33689.jpg";
                
                foreach (RepeaterItem item in RepeaterCover.Items)
                {
                    // 取得 Image 控制項
                    System.Web.UI.WebControls.Image imgCover = (System.Web.UI.WebControls.Image)item.FindControl("ImageRepeaterCover");

                    string rptCoverPath = imgCover.ImageUrl.ToString();
                    if (!string.IsNullOrEmpty(rptCoverPath))
                    {
                        // 取得 ImageUrl 屬性
                        coverPath = imgCover.ImageUrl;
                    }
                    else
                    {

                    }
                }

                command.Parameters.AddWithValue("@CoverImgPath", coverPath);



                //連接DB 執行SQL指令
                connection.Open();
                command.ExecuteNonQuery();
                //關閉DB
                connection.Close();


                ////圖片 update NewsId


                //string sqlcmdUpdateImg = "UPDATE NewsImg SET NewsId = @NewsId WHERE ImgPath = @ImgPath";

                //SqlCommand sqlUpdateImg = new SqlCommand(sqlcmdUpdateImg, connection);

                //foreach(RepeaterItem item in RepeaterMultilImg.Items)
                //{
                //    Label lblImgPath = (Label)item.FindControl("ImageRepeater");
                //    string imgPath = lblImgPath.Text;

                //    sqlUpdateImg.Parameters.AddWithValue("@ImgPath", imgPath);
                //    sqlUpdateImg.Parameters.AddWithValue("@NewsId", IDkey);

                //    connection.Open();
                //    command.ExecuteNonQuery();
                //    connection.Close();
                //}





                //復歸input values
                TextBoxEditNewsDate.Text = "";
                TextBoxEditNewsTitle.Text = "";
                TextBoxEditSummary.Text = "";
                //TextBoxEditContent.Text = "";
                ViewState.Clear();

                //新增完成後跳出提示框
                //跳轉回去 List 頁面
                string script = @"<script type='text/javascript'>alert('修改成功！'); window.location.href = 'WebForm1NewsManage.aspx';</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "addNewsSuccess", script);

            }
            else
            {
                ViewState["EditNewsTilte"] = TextBoxEditNewsTitle.Text;
                ViewState["EditNewsSummary"] = TextBoxEditSummary.Text;
                //ViewState["EditNewsContent"] = TextBoxEditContent.Text;
                ViewState["EditIsPintop"] = CheckBoxEditIsPintop.Checked;


                // 解析失敗，顯示錯誤訊息
                ClientScript.RegisterStartupScript(this.GetType(), "dateFormatError", "alert('請確認日期格式！');", true);

            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1NewsManage.aspx");
        }

        #region 圖片處理

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

        protected void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            // 1. 取的Server資料夾路徑 (記得要先去 建立資料夾)
            string ServerFolderPath = Server.MapPath("~/image/upload/test/");

            string connstring = "tayanaConnectionString";
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                connection.Open(); // 在使用之前打開連接
                // 2. 確認 FileUpload 控制項，是否有檔案
                if (FileUpload1.HasFiles)  // Note：控制項目可以開啟 "AllowMultiple" 功能
                {
                    // 3. 將 FileUpload 控制項裡面的檔案跑迴圈
                    foreach (var postfile in FileUpload1.PostedFiles)
                    {
                        // 4. 建立 單一檔案 篩選邏輯                                                                          
                        int FileMemory = postfile.ContentLength;  // 取得 單一檔案 容量變數      
                        string FileName = Path.GetFileName(postfile.FileName); // 取得 單一檔案 名稱變數
                        string FileExtension = Path.GetExtension(postfile.FileName).ToLower(); // 取得 單一檔案 檔名變數，並轉成小寫
                        string FilePath = Path.Combine(ServerFolderPath, FileName);  // 取得 單一檔案 儲存路徑

                        if (FileMemory > 1000000)           // 4-1. 如果 單一檔案 大於 1M，跳過不存
                        {
                            continue;
                        }
                        else if (FileExtension != ".jpg")   // 4-2. 如果 單一檔案 不是".jpg"檔名 跳過不存
                        {
                            continue;
                        }
                        else    // 4-3. 如果 單一檔案 吻合格式
                        {

                            // 5. 檢查是否有同名檔案，若有則加上流水號
                            FileName = GetUniqueFileName(ServerFolderPath, FileName);
                            FilePath = Path.Combine(ServerFolderPath, FileName);


                            // 5. 進行 資料庫 寫入
                            string pathStore = "/image/upload/test/" + FileName;


                            string sql = $"INSERT INTO NewsImg (ImgName, ImgPath, NewsId) VALUES (@ImgName, @ImgPath, @NewsId)";
                            sqlCommand.CommandText = sql;
                            sqlCommand.Parameters.Clear(); // 確保每次執行前清除先前的參數
                            sqlCommand.Parameters.AddWithValue("@ImgName", FileName);
                            sqlCommand.Parameters.AddWithValue("@ImgPath", pathStore);
                            string IDkey = Request.QueryString["NewsId"];
                            sqlCommand.Parameters.AddWithValue("@NewsId", IDkey);

                            int result = sqlCommand.ExecuteNonQuery();
                            if (result == 1)
                            {
                                postfile.SaveAs(FilePath);  // 成功資料庫寫入後，將檔案存入指定資料夾路徑
                                Response.Write($"<script>alert('已上傳{result}個檔案')</script>");
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('沒有選擇任何檔案')</script>");
                }
                connection.Close();  // 在使用之後關閉連接
            }

            //ShowImg(); // 呼叫渲染圖片的function
            ShowRepeaterImg();

        }

        /// <summary>
        /// 判斷檔案同名與否，如果是則增加流水號
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetUniqueFileName(string folderPath, string fileName)
        {
            // 取得檔案名稱和副檔名
            string[] fileNameArr = fileName.Split('.');
            string nameWithoutExtension = fileNameArr[0];
            string extension = "." + fileNameArr[1];

            // 檢查是否有同名檔案，若有則加上流水號
            int count = 0;
            string newFileName = fileName;
            while (File.Exists(Path.Combine(folderPath, newFileName)))
            {
                count++;
                newFileName = $"{nameWithoutExtension}({count}){extension}";
            }

            return newFileName;
        }





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

        protected void ShowRepeaterImg()  //記得要把 ShowRepeater() 放到 Page_Load
        {
            string IDkey = Request.QueryString["NewsId"];


            DbHelper db = new DbHelper();
            string sql = "SELECT * FROM NewsImg WHERE NewsId = @NewsId";
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["@NewsId"] = IDkey;

            SqlDataReader rd = db.SearchDB(sql, param);

            if (rd.HasRows)
            {
                RepeaterMultilImg.DataSource = rd;
                RepeaterMultilImg.DataBind();
            }
            else
            {
                RepeaterMultilImg.DataSource = null; //刪光資料後會無法重新databind, 要補上null後重新databind
                RepeaterMultilImg.DataBind();
            }
            db.CloseDB();
        }


        // 處理 Repeater 的按鈕指令
        protected void rptPhotos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int photoID = Convert.ToInt32(e.CommandArgument);
                DeletePhoto(photoID);
                ShowRepeaterImg();
            }
        }





        // 刪除照片
        private void DeletePhoto(int NewsImgId)
        {
            string connstring = "tayanaConnectionString";
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
            {
                // 先取得照片的路徑
                string getPathQuery = "SELECT ImgName FROM NewsImg WHERE NewsImgId = @NewsImgId";
                string deleteQuery = "DELETE FROM NewsImg WHERE NewsImgId = @NewsImgId";
                conn.Open();

                string imgPath = string.Empty;
                using (SqlCommand getCmd = new SqlCommand(getPathQuery, conn))
                {
                    getCmd.Parameters.AddWithValue("@NewsImgId", NewsImgId);
                    imgPath = getCmd.ExecuteScalar()?.ToString();
                }

                // 刪除資料庫記錄
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@NewsImgId", NewsImgId);
                    deleteCmd.ExecuteNonQuery();
                }

                // 刪除伺服器上的檔案
                if (!string.IsNullOrEmpty(imgPath))
                {
                    string serverPath = Server.MapPath(imgPath);
                    if (File.Exists(serverPath))
                    {
                        File.Delete(serverPath);
                    }
                }
            }
            ShowRepeaterImg();
        }









        #endregion



        #region 附件處理


        protected void ButtonUploadFile_Click(object sender, EventArgs e)
        {
            // 1. 取的Server資料夾路徑 (記得要先去 建立資料夾)
            string ServerFolderPath = Server.MapPath("~/File/Upload/NewsFile");

            string connstring = "tayanaConnectionString";
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                connection.Open(); // 在使用之前打開連接
                // 2. 確認 FileUpload 控制項，是否有檔案
                if (FileUploadFile.HasFiles)  // Note：控制項目可以開啟 "AllowMultiple" 功能
                {
                    // 3. 將 FileUpload 控制項裡面的檔案跑迴圈
                    foreach (var postfile in FileUploadFile.PostedFiles)
                    {
                        // 4. 建立 單一檔案 篩選邏輯                                                                          
                        int FileMemory = postfile.ContentLength;  // 取得 單一檔案 容量變數      
                        string FileName = Path.GetFileName(postfile.FileName); // 取得 單一檔案 名稱變數
                        string FileExtension = Path.GetExtension(postfile.FileName).ToLower(); // 取得 單一檔案 檔名變數，並轉成小寫
                        string FilePath = Path.Combine(ServerFolderPath, FileName);  // 取得 單一檔案 儲存路徑

                        if (FileMemory > 1000000)           // 4-1. 如果 單一檔案 大於 1M，跳過不存
                        {
                            Response.Write("<script>alert('檔案過大')</script>");
                            continue;
                        }
                        else if (FileExtension != ".pdf")   // 4-2. 如果 單一檔案 不是".jpg"檔名 跳過不存
                        {
                            Response.Write("<script>alert('請上傳正確檔案類型')</script>");
                            continue;
                        }
                        else    // 4-3. 如果 單一檔案 吻合格式
                        {
                            // 5-0.檢查是否有同名檔案，若有則加上流水號
                            FileName = GetUniqueFileName(ServerFolderPath, FileName);
                            FilePath = Path.Combine(ServerFolderPath, FileName);

                            // 5. 進行 資料庫 寫入
                            string pathStore = "/File/Upload/NewsFile/" + FileName;


                            string sql = $"INSERT INTO NewsFile (FileName, FilePath, NewsId) VALUES (@FileName, @FilePath, @NewsId)";
                            sqlCommand.CommandText = sql;
                            sqlCommand.Parameters.Clear(); // 確保每次執行前清除先前的參數
                            sqlCommand.Parameters.AddWithValue("@FileName", FileName);
                            sqlCommand.Parameters.AddWithValue("@FilePath", pathStore);
                            string IDkey = Request.QueryString["NewsId"];
                            sqlCommand.Parameters.AddWithValue("@NewsId", IDkey);

                            int result = sqlCommand.ExecuteNonQuery();
                            if (result == 1)
                            {
                                postfile.SaveAs(FilePath);  // 成功資料庫寫入後，將檔案存入指定資料夾路徑
                                Response.Write($"<script>alert('已上傳{result}個檔案')</script>");
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('沒有選擇任何檔案')</script>");
                }
                connection.Close();  // 在使用之後關閉連接
            }

            //ShowImg(); // 呼叫渲染圖片的function
            ShowRepeaterFile();

        }

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

        protected void ShowRepeaterFile()  //記得要把 ShowRepeater() 放到 Page_Load
        {
            string IDkey = Request.QueryString["NewsId"];


            DbHelper db = new DbHelper();
            string sql = "SELECT * FROM NewsFile WHERE NewsId = @NewsId";
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["@NewsId"] = IDkey;

            SqlDataReader rd = db.SearchDB(sql, param);

            if (rd.HasRows)
            {
                RepeaterMultiFiles.DataSource = rd;
                RepeaterMultiFiles.DataBind();
            }
            else
            {
                RepeaterMultiFiles.DataSource = null;
                RepeaterMultiFiles.DataBind();
            }


            db.CloseDB();
        }


        // 處理 Repeater 的按鈕指令
        protected void rptFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int fileID = Convert.ToInt32(e.CommandArgument);
                DeleteFile(fileID);
                ShowRepeaterFile();
            }
        }





        // 刪除檔案
        private void DeleteFile(int NewsFileId)
        {
            string connstring = "tayanaConnectionString";
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
            {
                // 先取得照片的路徑
                string getPathQuery = "SELECT FileName FROM NewsFile WHERE NewsFileId = @NewsFileId";
                string deleteQuery = "DELETE FROM NewsFile WHERE NewsFileId = @NewsFileId";
                conn.Open();

                string imgPath = string.Empty;
                using (SqlCommand getCmd = new SqlCommand(getPathQuery, conn))
                {
                    getCmd.Parameters.AddWithValue("@NewsFileId", NewsFileId);
                    imgPath = getCmd.ExecuteScalar()?.ToString();
                }

                // 刪除資料庫記錄
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@NewsFileId", NewsFileId);
                    deleteCmd.ExecuteNonQuery();
                }

                // 刪除伺服器上的檔案
                if (!string.IsNullOrEmpty(imgPath))
                {
                    string serverPath = Server.MapPath(imgPath);
                    if (File.Exists(serverPath))
                    {
                        File.Delete(serverPath);
                    }
                }
            }
            ShowRepeaterFile();
        }


        #endregion

        #region CoverImg

        protected void ButtonCoverUpload_Click(object sender, EventArgs e)
        {
            // 1. 取的Server資料夾路徑 (記得要先去 建立資料夾)
            string ServerFolderPath = Server.MapPath("~/image/upload/NewsImg/Cover/");

            string connstring = "tayanaConnectionString";
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                connection.Open(); // 在使用之前打開連接
                // 2. 確認 FileUpload 控制項，是否有檔案
                if (FileUploadCover.HasFiles)  // Note：控制項目可以開啟 "AllowMultiple" 功能
                {
                    // 3. 將 FileUpload 控制項裡面的檔案跑迴圈
                    foreach (var postfile in FileUploadCover.PostedFiles)
                    {
                        // 4. 建立 單一檔案 篩選邏輯                                                                          
                        int FileMemory = postfile.ContentLength;  // 取得 單一檔案 容量變數      
                        string FileName = Path.GetFileName(postfile.FileName); // 取得 單一檔案 名稱變數
                        string FileExtension = Path.GetExtension(postfile.FileName).ToLower(); // 取得 單一檔案 檔名變數，並轉成小寫
                        string FilePath = Path.Combine(ServerFolderPath, FileName);  // 取得 單一檔案 儲存路徑

                        if (FileMemory > 1000000)           // 4-1. 如果 單一檔案 大於 1M，跳過不存
                        {
                            Response.Write("<script>alert('檔案過大')</script>");
                            continue;
                        }
                        else if (FileExtension != ".jpg")   // 4-2. 如果 單一檔案 不是".jpg"檔名 跳過不存
                        {
                            Response.Write("<script>alert('請上傳正確檔案類型')</script>");
                            continue;
                        }
                        else    // 4-3. 如果 單一檔案 吻合格式
                        {

                            // 5. 檢查是否有同名檔案，若有則加上流水號
                            FileName = GetUniqueFileName(ServerFolderPath, FileName);
                            FilePath = Path.Combine(ServerFolderPath, FileName);


                            // 5. 進行 資料庫 寫入
                            string pathStore = "/image/upload/NewsImg/Cover/" + FileName;


                            string sql = $"UPDATE News SET CoverImgPath = @CoverImgPath WHERE NewsId = @NewsId";
                            sqlCommand.CommandText = sql;
                            sqlCommand.Parameters.Clear(); // 確保每次執行前清除先前的參數
                            sqlCommand.Parameters.AddWithValue("@CoverImgPath", pathStore);
                            string IDkey = Request.QueryString["NewsId"];
                            sqlCommand.Parameters.AddWithValue("@NewsId", IDkey);

                            int result = sqlCommand.ExecuteNonQuery();
                            if (result == 1)
                            {
                                postfile.SaveAs(FilePath);  // 成功資料庫寫入後，將檔案存入指定資料夾路徑
                                Response.Write($"<script>alert('已上傳{result}個檔案')</script>");
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('沒有選擇任何檔案')</script>");
                }
                connection.Close();  // 在使用之後關閉連接
            }

            //ShowImg(); // 呼叫渲染圖片的function
            ShowRepeaterCover();

        }

        protected void ShowRepeaterCover()  //記得要把 ShowRepeater() 放到 Page_Load
        {
            string IDkey = Request.QueryString["NewsId"];


            DbHelper db = new DbHelper();
            string sql = "SELECT * FROM News WHERE NewsId = @NewsId";
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["@NewsId"] = IDkey;

            SqlDataReader rd = db.SearchDB(sql, param);

            //if (rd.HasRows)
            //{
            //    while (rd.Read())
            //    {

            //        if (rd["CoverImgPath"].ToString() != null)
            //        {
            //            RepeaterCover.DataSource = rd;
            //            RepeaterCover.DataBind();
            //        }
            //        else
            //        {
            //            RepeaterCover.DataSource = null; //刪光資料後會無法重新databind, 要補上null後重新databind
            //            RepeaterCover.DataBind();
            //        }
            //    }

            //}

            if (rd.HasRows)
            {
                RepeaterCover.DataSource = rd;
                RepeaterCover.DataBind();
            }
            else
            {
                RepeaterCover.DataSource = null; //刪光資料後會無法重新databind, 要補上null後重新databind
                RepeaterCover.DataBind();
            }




            db.CloseDB();
        }


        // 處理 Repeater 的按鈕指令
        protected void RtrCover_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int newsID = Convert.ToInt32(e.CommandArgument);
                DeleteCover(newsID);
                ShowRepeaterCover();
            }
        }





        // 刪除照片
        private void DeleteCover(int NewsId)
        {
            string connstring = "tayanaConnectionString";
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
            {
                // 先取得照片的路徑
                string getPathQuery = "SELECT CoverImgPath FROM News WHERE NewsId = @NewsId";
                string deleteQuery = "UPDATE News SET CoverImgPath = @CoverImgPath WHERE NewsId = @NewsId";
                conn.Open();

                string coverPath = string.Empty;
                using (SqlCommand getCmd = new SqlCommand(getPathQuery, conn))
                {
                    getCmd.Parameters.AddWithValue("@NewsId", NewsId);
                    coverPath = getCmd.ExecuteScalar()?.ToString();
                }

                // 刪除資料庫記錄
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@NewsId", NewsId);

                    string pathDefault = "/image/upload/NewsImg/Cover/sail-boat-in-water-33689.jpg";
                    deleteCmd.Parameters.AddWithValue("@CoverImgPath", pathDefault);//改為預設圖片
                    deleteCmd.ExecuteNonQuery();
                }

                // 刪除伺服器上的檔案
                if (!string.IsNullOrEmpty(coverPath))
                {
                    string serverPath = Server.MapPath(coverPath);
                    if (File.Exists(serverPath))
                    {
                        File.Delete(serverPath);
                    }
                }
            }
            ShowRepeaterCover();
        }



        #endregion







    }


}
