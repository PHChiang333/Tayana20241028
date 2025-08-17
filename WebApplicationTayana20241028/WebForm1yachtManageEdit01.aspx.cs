using AjaxControlToolkit.HtmlEditor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace WebApplicationTayana20241028
{
    public partial class WebForm1yachtManageEdit01 : System.Web.UI.Page
    {

        // 定義 RowData 類別，代表每個欄位的名稱與值
        public class RowData
        {
            public string SaveItem { get; set; } // 欄位名稱
            public string SaveValue { get; set; } // 欄位值
        }

        // 使用 List<RowData> 作為資料容器
        private List<RowData> saveRowList = new List<RowData>();

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
                ShowRepeaterImg();
                ShowRepeaterFile();
                ShowGVYachtDimension("YachtDimension", GridViewDimensionList, selYachtId);
                //loadRowList(); //取得尺寸欄位內容
                //renderRowList(); //渲染尺寸欄位內容


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
                    TextBoxEditYachtNameTag.Text = reader["YachtNameTag"].ToString();
                    editor1.Value = HttpUtility.HtmlDecode(reader["YachtDesc"].ToString());

                    CheckBoxEditYachtIsPintop.Checked = (bool)reader["IsPintop"];

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












        protected void ButtonToSaveNNextStep_Click(object sender, EventArgs e)
        {
            ////儲存，並進到下一個Edit page

            string IDkey = Request.QueryString["YachtId"];

            string sqlcmd = $"UPDATE [yacht] " +
                $"SET [YachtName] = @YachtName,[YachtNameTag] = @YachtNameTag,[YachtDesc] =@YachtDesc,[IsPintop] = @IsPintop ,[YachtCoverImgPath]=@YachtCoverImgPath, [YachtDimensionsJson] = @YachtDimensionsJson " + " " +
                $"WHERE YachtId = @YachtId;";

            string connstring = "tayanaConnectionString";
            //連接資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);

            SqlCommand command = new SqlCommand(sqlcmd, connection);
            command.Parameters.AddWithValue("@YachtId", IDkey);

            command.Parameters.AddWithValue("@YachtName", TextBoxEditYachtName.Text);
            command.Parameters.AddWithValue("@YachtNameTag", TextBoxEditYachtNameTag.Text);

            string textValue = HttpUtility.HtmlEncode(editor1.Value);
            command.Parameters.AddWithValue("@YachtDesc", textValue);

            if (CheckBoxEditYachtIsPintop.Checked)
            {
                command.Parameters.AddWithValue("@IsPintop", '1');
            }
            else
            {
                command.Parameters.AddWithValue("@IsPintop", '0');
            }

            string pathDefault = "/image/upload/NewsImg/Cover/sail-boat-in-water-33689.jpg";//預設圖片位址
            command.Parameters.AddWithValue("@YachtCoverImgPath", pathDefault);

            //------------動態欄位區 start---------------------------

            // 將 List 轉換為 JSON
            string saveJson = JsonConvert.SerializeObject(saveRowList);



            //string yachtSpecJSON = "";  //Dimension JSON
            command.Parameters.AddWithValue("@YachtDimensionsJson", saveJson);

            //------------動態欄位區 end---------------------------

            //連接DB 執行SQL指令
            connection.Open();
            command.ExecuteNonQuery();
            //關閉DB
            connection.Close();

            //復歸input values
            TextBoxEditYachtName.Text = "";
            TextBoxEditYachtNameTag.Text = "";
            CheckBoxEditYachtIsPintop.Checked = false;
            editor1.Value = "";


            ViewState.Clear();

            //新增完成後跳出提示框
            //跳轉回去 List 頁面
            string script = $"<script type='text/javascript'>alert('修改成功！'); window.location.href = 'WebForm1yachtManageEdit02.aspx?YachtId={IDkey}';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "addNewsSuccess", script);


        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            //退回Manage pge

            Response.Write("<script>alert('資料未儲存')</script>");

            string path = @"WebForm1yachtManage.aspx";
            Response.Redirect(path);

        }

        #region 圖片



        protected void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            //先上傳，再更新

            // 1. 取的Server資料夾路徑 (記得要先去 建立資料夾)
            string ServerFolderPath = Server.MapPath("~/image/upload/Yacht/DimensionImg/");

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
                            string pathStore = "/image/upload/Yacht/DimensionImg/" + FileName;


                            string sql = $"INSERT INTO yachtDimensionImg (YachtDimensionImgName, YachtDimensionImgPath, YachtId) VALUES (@YachtDimensionImgName, @YachtDimensionImgPath, @YachtId)";
                            sqlCommand.CommandText = sql;
                            sqlCommand.Parameters.Clear(); // 確保每次執行前清除先前的參數
                            sqlCommand.Parameters.AddWithValue("@YachtDimensionImgName", FileName);
                            sqlCommand.Parameters.AddWithValue("@YachtDimensionImgPath", pathStore);
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
            string sql = "SELECT * FROM yachtDimensionImg WHERE YachtId = @YachtId";
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

        protected void rptPhotos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int YachtDimensionImgId = Convert.ToInt32(e.CommandArgument);
                DeletePhoto(YachtDimensionImgId);
                ShowRepeaterImg();
            }
        }

        private void DeletePhoto(int YachtDimensionImgId)
        {
            string connstring = "tayanaConnectionString";
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
            {
                // 先取得照片的路徑
                string getPathQuery = "SELECT YachtDimensionImgName FROM yachtDimensionImg WHERE YachtDimensionImgId = @YachtDimensionImgId";
                string deleteQuery = "DELETE FROM yachtDimensionImg WHERE YachtDimensionImgId = @YachtDimensionImgId";
                conn.Open();

                string imgPath = string.Empty;
                using (SqlCommand getCmd = new SqlCommand(getPathQuery, conn))
                {
                    getCmd.Parameters.AddWithValue("@YachtDimensionImgId", YachtDimensionImgId);
                    imgPath = getCmd.ExecuteScalar()?.ToString();
                }

                // 刪除資料庫記錄
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@YachtDimensionImgId", YachtDimensionImgId);
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

        #region 檔案處理




        protected void ButtonUploadFile_Click(object sender, EventArgs e)
        {
            //先上傳，再更新

            // 1. 取的Server資料夾路徑 (記得要先去 建立資料夾)
            string ServerFolderPath = Server.MapPath("~/image/upload/Yacht/File");

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

                            continue;
                        }
                        else if (FileExtension != ".pdf")   // 4-2. 如果 單一檔案 不是".jpg"檔名 跳過不存
                        {

                            continue;
                        }
                        else    // 4-3. 如果 單一檔案 吻合格式
                        {
                            // 5-0.檢查是否有同名檔案，若有則加上流水號
                            FileName = GetUniqueFileName(ServerFolderPath, FileName);
                            FilePath = Path.Combine(ServerFolderPath, FileName);

                            // 5. 進行 資料庫 寫入
                            string pathStore = "/image/upload/Yacht/File/" + FileName;


                            string sql = $"INSERT INTO yachtFile (FileName, FilePath, YachtId) VALUES (@FileName, @FilePath, @YachtId)";
                            sqlCommand.CommandText = sql;
                            sqlCommand.Parameters.Clear(); // 確保每次執行前清除先前的參數
                            sqlCommand.Parameters.AddWithValue("@FileName", FileName);
                            sqlCommand.Parameters.AddWithValue("@FilePath", pathStore);
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
            ShowRepeaterFile();

        }


        protected void ShowRepeaterFile()  //記得要把 ShowRepeater() 放到 Page_Load
        {
            string IDkey = Request.QueryString["YachtId"];


            DbHelper db = new DbHelper();
            string sql = "SELECT * FROM yachtFile WHERE YachtId = @YachtId";
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["@YachtId"] = IDkey;

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
                int yachtFileId = Convert.ToInt32(e.CommandArgument);
                DeleteFile(yachtFileId);
                ShowRepeaterFile();
            }
        }





        // 刪除檔案
        private void DeleteFile(int yachtFileId)
        {
            string connstring = "tayanaConnectionString";
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
            {
                // 先取得照片的路徑
                string getPathQuery = "SELECT FileName FROM yachtFile WHERE yachtFileId = @yachtFileId";
                string deleteQuery = "DELETE FROM yachtFile WHERE yachtFileId = @yachtFileId";
                conn.Open();

                string imgPath = string.Empty;
                using (SqlCommand getCmd = new SqlCommand(getPathQuery, conn))
                {
                    getCmd.Parameters.AddWithValue("@yachtFileId", yachtFileId);
                    imgPath = getCmd.ExecuteScalar()?.ToString();
                }

                // 刪除資料庫記錄
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@yachtFileId", yachtFileId);
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

        protected void ButtonUploadCover_Click(object sender, EventArgs e)
        {






        }

        protected void RepeaterCover_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }


        #region 動態欄位



        //private void loadRowList()
        //{
        //    // 取得選取型號的欄位資料
        //    string YachtId = Request.QueryString["YachtId"]; //找到yacht Id

        //    string connstring = "tayanaConnectionString";
        //    SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);

        //    string sql = "SELECT * FROM yacht WHERE YachtId = @YachtId";

        //    SqlCommand command = new SqlCommand(sql, connection);
        //    command.Parameters.AddWithValue("@YachtId", YachtId);

        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        // 讀取 JSON 格式欄位資料
        //        string loadJson = HttpUtility.HtmlDecode(reader["YachtDimensionsJson"].ToString());
        //        saveRowList = JsonConvert.DeserializeObject<List<RowData>>(loadJson); // 將 JSON 轉換成 List
        //    }
        //    connection.Close();
        //}

        //private void renderRowList()
        //{
        //    if (saveRowList?.Count > 0)
        //    {
        //        string addRowHtmlStr = "";  //清空，重新給string
        //        int index = 0;

        //        foreach (var item in saveRowList)
        //        {

        //            // 動態生成 HTML 表格
        //            addRowHtmlStr += $@"
        //                                <tr class='unread'>
        //                                    <td>
        //                                        <input id='item{index}' name='item{index}' type='text' 
        //                                            class='form-control' value='{item.SaveItem}' />
        //                                    </td>
        //                                    <td>
        //                                        <input id='value{index}' name='value{index}' type='text' 
        //                                            class='form-control' value='{item.SaveValue}' />
        //                                    </td>
        //                                </tr>";
        //            index++;
        //        }

        //        // 更新頁面上的 HTML
        //        LiteralDimensionsHtml.Text = addRowHtmlStr;
        //    }
        //}


        //protected void AddRow_Click(object sender, EventArgs e)
        //{
        //    //將 JSON 資料載入 List<T>
        //    loadRowList();


        //    // 新增一筆空的資料至 List
        //    saveRowList.Add(new RowData { SaveItem = "", SaveValue = "" });
        //    //loadRowList(); //取得尺寸欄位內容
        //    renderRowList(); //渲染尺寸欄位內容
        //}

        //protected void DeleteRow_Click(object sender, EventArgs e)
        //{
        //    //將 JSON 資料載入 List<T>
        //    loadRowList();
            

        //    if (saveRowList.Count > 0) 
        //    {
        //        saveRowList.RemoveAt(saveRowList.Count - 1); // 刪除最後一筆
        //    }
        //    //loadRowList(); //取得尺寸欄位內容
        //    renderRowList(); //渲染尺寸欄位內容
        //}

        //protected void BtnUpdateDimensionsList_Click(object sender, EventArgs e)
        //{
        //    // 清空原有的資料結構
        //    saveRowList = new List<RowData>();

        //    // 假設欄位名稱規則為 item{index} 和 value{index}
        //    int index = 0;
        //    while (true)
        //    {
        //        string itemKey = $"item{index}";
        //        string valueKey = $"value{index}";

        //        // 檢查欄位是否存在
        //        if (Request.Form[itemKey] == null || Request.Form[valueKey] == null)
        //        {
        //            break; // 如果欄位不存在，結束迴圈
        //        }

        //        // 從表單取值並加入資料結構
        //        saveRowList.Add(new RowData
        //        {
        //            SaveItem = Request.Form[itemKey],
        //            SaveValue = Request.Form[valueKey]
        //        });

        //        index++;
        //    }



        //    // 將 List 轉換為 JSON
        //    string saveJson = JsonConvert.SerializeObject(saveRowList);

        //    // 更新資料庫
        //    string selectModel_id = Request.QueryString["YachtId"]; //找到yacht Id
        //    string connstring = "tayanaConnectionString";
        //    SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);
        //    string sql = "UPDATE yacht SET YachtDimensionsJson = @saveJson WHERE YachtId = @selectModel_id";
        //    SqlCommand command = new SqlCommand(sql, connection);
        //    command.Parameters.AddWithValue("@saveJson", saveJson);
        //    command.Parameters.AddWithValue("@selectModel_id", selectModel_id);
        //    connection.Open();
        //    command.ExecuteNonQuery();
        //    connection.Close();

        //    //loadRowList(); //取得尺寸欄位內容
        //    renderRowList(); //渲染尺寸欄位內容

        //    // 更新成功提示
        //    //LabUpdateDimensionsList.Visible = true;

        //    // 錨點，將畫面移至出現上傳按鈕處
        //    Page.SetFocus(ButtonUpdateDimensionsList);


        //}





        #endregion

        #region CKE

        //   public string getMark(string Data)
        //   {
        //       string s = Data;
        //       int x = s.IndexOf("marker-yellow");
        //       if (x > 0)
        //       {
        //           s = s.Replace("class="marker - yellow"", "class="marker - yellow" style="background - color:#fdfd77"");
        //}

        //       x = s.IndexOf("marker-green");
        //       if (x > 0)
        //       {
        //           s = s.Replace("class="marker - green"", "class="marker - green" style="background - color:#63f963"");
        //}

        //       x = s.IndexOf("marker-pink");
        //       if (x > 0)
        //       {
        //           s = s.Replace("class="marker - pink"", "class="marker - pink" style="background - color:#fc7999"");
        //}

        //       x = s.IndexOf("marker-blue");
        //       if (x > 0)
        //       {
        //           s = s.Replace("class="marker - blue"", "class="marker - blue" style="background - color:#72cdfd"");
        //}
        //       x = s.IndexOf("pen-red");
        //       if (x > 0)
        //       {
        //           s = s.Replace("class="pen - red"", "class="pen - red" style="background - color:transparent; color:#e91313"");
        //}
        //       x = s.IndexOf("pen-green");
        //       if (x > 0)
        //       {
        //           s = s.Replace("class="pen - green"", "class="pen - green" style="background - color:transparent; color:#118800"");
        //}
        //       return s;
        //   }

        #endregion

        protected void ButtonToNextStep_Click(object sender, EventArgs e)
        {
            string IDkey = Request.QueryString["YachtId"];
            string path = $"WebForm1yachtManageEdit02.aspx?YachtId={IDkey}";
            Response.Redirect(path);
        }

        #region DimensionListCRUD

        protected void GridViewDimensionList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewDimensionList.EditIndex = e.NewEditIndex;  // 將資料行轉換為：編輯模式
            ShowGVDimension("YachtDimension", GridViewDimensionList); // 記得呼叫讀取Griview的function，進行重新Binding，不然會出錯
        }
        protected void GridViewDimensionList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewDimensionList.EditIndex = -1;  // 將資料行取消：編輯模式
            ShowGVDimension("YachtDimension", GridViewDimensionList); // 記得呼叫讀取Griview的function，進行重新Binding，不然會出錯
        }
    

        protected void GridViewDimensionList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // 1. 找到特定表格行數 (Row) ⇒ ex：第五行
            int IndexRow = e.RowIndex;

            // 2. 找到該行數的 Key Value (ID) ⇒ ex：第五行中的 ID 欄位值
            string IDkey = GridViewDimensionList.DataKeys[IndexRow].Value.ToString();

            // 3. 透過SQL語法進行資料的修改
            DbHelper db = new DbHelper();
            string sqlCommand = $"Delete From YachtDimension Where YachtDimensionId = @YachtDimensionId";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@YachtDimensionId"] = IDkey;
            db.SearchDB(sqlCommand, parameters);


            // 4. 補充：不要忘記重新執行 BindGV.ShowGV("YachtDimension", GridViewDimensionList)
            db.CloseDB();
            ShowGVDimension("YachtDimension", GridViewDimensionList);   //當然也可以Redirect，就不用showGV了
        }

        protected void GridViewDimensionList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // 1. 找到特定表格行數 (Row) ⇒ ex：第五行
            int IndexRow = e.RowIndex;

            // 2. 取得該行數的表格行數物件 (GridViewRow) ⇒ ex：第五行的物件 
            GridViewRow TargetRow = GridViewDimensionList.Rows[IndexRow];

            // 3. 於該物件內部找到要修改的欄位 (Column) 物件⇒ ex：物件中的 link 物件
            TextBox TextboxUpadateDimensionTitle = TargetRow.FindControl("TextBoxDimensionTitle") as TextBox;
            TextBox TextboxUpadateDimensionContent = TargetRow.FindControl("TextBoxDimensionContent") as TextBox;

            // 4. 找到該行數的 Key Value (ID) ⇒ ex：第五行中的 ID 欄位值
            string IDkey = GridViewDimensionList.DataKeys[IndexRow].Value.ToString();

            // 5. 透過SQL語法進行資料的修改 (開始撰寫dbhelper 4 個流程)
            DbHelper db = new DbHelper();
            string sqlCommand = "UPDATE YachtDimension SET DimensionTitle = @DimensionTitle, DimensionContent = @DimensionContent WHERE YachtDimensionId = @YachtDimensionId";

            // 使用參數化查詢來避免 SQL 注入攻擊
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@DimensionTitle"] = TextboxUpadateDimensionTitle.Text;
            parameters["@DimensionContent"] = TextboxUpadateDimensionContent.Text;
            parameters["@YachtDimensionId"] = IDkey;
            db.SearchDB(sqlCommand, parameters);

            // 6. 補充：不要忘記重新 把 編輯模式 改回 閱讀模式 以及執行 BindGV.ShowGV("YachtDimension", GridViewDimensionList)
            db.CloseDB();
            GridViewDimensionList.EditIndex = -1;
            ShowGVDimension("YachtDimension", GridViewDimensionList);   //當然也可以Redirect，就不用showGV了
        }

        protected void ButtonAddDimension_Click(object sender, EventArgs e)
        {

            string sqlcmd = $"INSERT INTO YachtDimension([YachtId],[DimensionTitle], [DimensionContent]) VALUES (@YachtId,@DimensionTitle, @DimensionContent) ;";

            string connstring = "tayanaConnectionString";

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);

            SqlCommand command = new SqlCommand(sqlcmd, connection);
            command.Parameters.AddWithValue("@YachtId", selYachtId);
            command.Parameters.AddWithValue("@DimensionTitle", TextBoxAddDimensionTitle.Text);
            command.Parameters.AddWithValue("@DimensionContent", TextBoxAddDimensionContent.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            TextBoxAddDimensionTitle.Text = "";
            TextBoxAddDimensionContent.Text = "";


            string script = @"<script type='text/javascript'>alert('新增成功！');";
            ClientScript.RegisterStartupScript(this.GetType(), "addYachtSuccess", script);

            ShowGVDimension("YachtDimension", GridViewDimensionList);

        }





        private void ShowGVDimension(string DbTable, GridView GridID)
        {
            DbHelper helper = new DbHelper();

            string sqlCommand = $"Select * From {DbTable} WHERE YachtId ={selYachtId} ";
            using (SqlDataReader reader = helper.SearchDB(sqlCommand))
            {
                GridID.DataSource = reader;
                GridID.DataBind();
            }

        }

        #endregion

        

        public static void ShowGVYachtDimension(string DbTable, GridView GridID, string selYachtId)
        {
            DbHelper helper = new DbHelper();

            string sqlCommand = $"Select * From {DbTable} WHERE YachtId = {selYachtId}";
            using (SqlDataReader reader = helper.SearchDB(sqlCommand))
            {
                GridID.DataSource = reader;
                GridID.DataBind();
            }

        }

    }
}