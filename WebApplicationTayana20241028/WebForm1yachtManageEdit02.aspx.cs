using AjaxControlToolkit.HtmlEditor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTayana20241028
{
    public partial class WebForm1yachtManageEdit02 : System.Web.UI.Page
    {

        string selYachtId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["YachtId"] != null)
            {
                selYachtId = Request.QueryString["YachtId"];
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
                //ShowRepeaterImg();
                //ShowRepeaterFile();
                //loadRowList(); //取得尺寸欄位內容
                //renderRowList(); //渲染尺寸欄位內容
                ShowRepeaterImg();


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


        //protected void RepeaterMultilImg_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{

        //}

        protected void ButtonToSaveNNextStep_Click(object sender, EventArgs e)
        {
            
            // 跳轉到指定頁面，並使用 QueryString 傳遞 IDKey
            Response.Redirect($"WebForm1yachtManageEdit03.aspx?YachtId={selYachtId}");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {

        }


        #region 圖片處理


        protected void ButtonUploadImage_Click(object sender, EventArgs e)
        {

            // 1. 取的Server資料夾路徑 (記得要先去 建立資料夾)
            string ServerFolderPath = Server.MapPath("~/image/upload/Yacht/LayoutImg/");

            string connstring = "tayanaConnectionString";
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                connection.Open(); // 在使用之前打開連接
                // 2. 確認 FileUpload 控制項，是否有檔案
                if (FileUploadImg.HasFiles)  // Note：控制項目可以開啟 "AllowMultiple" 功能
                {
                    // 3. 將 FileUpload 控制項裡面的檔案跑迴圈
                    foreach (var postfile in FileUploadImg.PostedFiles)
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
                            string pathStore = "/image/upload/Yacht/LayoutImg/" + FileName;


                            string sql = $"INSERT INTO yachtLayoutImg (YachtLayoutImgName, YachtLayoutImgPath, YachtId) VALUES (@YachtLayoutImgName, @YachtLayoutImgPath, @YachtId)";
                            sqlCommand.CommandText = sql;
                            sqlCommand.Parameters.Clear(); // 確保每次執行前清除先前的參數
                            sqlCommand.Parameters.AddWithValue("@YachtLayoutImgName", FileName);
                            sqlCommand.Parameters.AddWithValue("@YachtLayoutImgPath", pathStore);
                            string IDkey = Request.QueryString["YachtId"];
                            sqlCommand.Parameters.AddWithValue("@YachtId", IDkey);

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


        protected void ShowRepeaterImg()  //記得要把 ShowRepeater() 放到 Page_Load
        {
            string IDkey = Request.QueryString["YachtId"];


            DbHelper db = new DbHelper();
            string sql = "SELECT * FROM yachtLayoutImg WHERE YachtId = @YachtId";
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["@YachtId"] = IDkey;

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
        protected void RepeaterMultilImg_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int YachtLayoutImgId = Convert.ToInt32(e.CommandArgument);
                DeletePhoto(YachtLayoutImgId);
                ShowRepeaterImg();
            }
        }




        // 刪除照片
        private void DeletePhoto(int YachtLayoutImgId)
        {
            string connstring = "tayanaConnectionString";
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
            {
                // 先取得照片的路徑
                string getPathQuery = "SELECT YachtLayoutImgName FROM yachtLayoutImg WHERE YachtLayoutImgId = @YachtLayoutImgId";
                string deleteQuery = "DELETE FROM yachtLayoutImg WHERE YachtLayoutImgId = @YachtLayoutImgId";
                conn.Open();

                string imgPath = string.Empty;
                using (SqlCommand getCmd = new SqlCommand(getPathQuery, conn))
                {
                    getCmd.Parameters.AddWithValue("@YachtLayoutImgId", YachtLayoutImgId);
                    imgPath = getCmd.ExecuteScalar()?.ToString();
                }

                // 刪除資料庫記錄
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@YachtLayoutImgId", YachtLayoutImgId);
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



        private void TextboxDataBind()
        {
            if (Request.QueryString["YachtId"] != null)
            {
                string IDkey = Request.QueryString["YachtId"];

                string sqlcmd = $"SELECT * FROM yacht WHERE YachtId = @YachtId;";

                string connstring = "tayanaConnectionString";
                //連接資料庫
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);

                SqlCommand command = new SqlCommand(sqlcmd, connection);
                command.Parameters.AddWithValue("@YachtId", IDkey);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    TextBoxEditYachtName.Text = reader["YachtName"].ToString();
                    //TextBoxEditYachtNameTag.Text = reader["YachtNameTag"].ToString();
                    //editor1.Value = HttpUtility.HtmlDecode(reader["YachtDesc"].ToString());

                    //CheckBoxEditYachtIsPintop.Checked = (bool)reader["IsPintop"];

                }
                else
                {
                    //沒找到資料 後跳出提示框
                    //跳轉回去 List 頁面
                    string script = @"<script type='text/javascript'>alert('請確認資料是否正確'); window.location.href = 'WebForm1NewsManage.aspx';</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "NoData", script);
                }
            }
            else
            {

            }


        }

    }
}