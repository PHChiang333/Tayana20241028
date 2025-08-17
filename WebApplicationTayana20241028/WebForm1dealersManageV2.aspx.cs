using MimeKit;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplicationTayana20241028.Properties
{
    public partial class WebForm1dealersManageV2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataSource2.DataBind();
                DropDownList1.DataBind(); //先綁定取得選取預設值
                showAreaList();
                ClearDealerTable();
                //showDealerListTable();
                //GridViewDealerSelArea.DataBind();
            }
            else
            {

            }
        }

       





        #region btnList

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //當選擇國家改變時刷新畫面資料
            RadioButtonListArea.Items.Clear();
            BtnDelArea.Visible = false;
            //DealerList.Visible = false;
            //LabUploadImg.Visible = false;
            //UpdateDealerListLab.Visible = false;
            showAreaList();
            RadioButtonListSelAreaDealer.DataBind();
            ClearDealerTable();


        }

        protected void RadioButtonListArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnDelArea.Visible = true;
            //showDealerListTable();
            //GridViewDealerSelArea.DataBind(); //TODO ???
            ClearDealerTable();
            //showDealerListTable();// check
        }

        protected void RadioButtonListSelAreaDealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //當選擇Area改變時刷新畫面資料
            ButtonDeleteDealer.Visible = true;
            //DealerList.Visible = false;
            //LabUploadImg.Visible = false;
            //UpdateDealerListLab.Visible = false;
            showDealerListTable();
        }


        protected void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            // 設定存檔路徑，需填完整路徑，結尾反斜線如果沒加要用 Path.Combine() 可自動添加
            string savePath = Server.MapPath("~/image/upload/");

            //判斷有選檔案才可上傳
            if (FileUpload1.HasFile)
            {
                //取得選擇區域名稱
                string selAreaStr = RadioButtonListArea.SelectedValue;

                //先執行刪除舊圖檔
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);
                string sqlDel = "SELECT dealerImgPath FROM Dealers WHERE area = @selAreaStr";
                SqlCommand commandDel = new SqlCommand(sqlDel, connection);
                commandDel.Parameters.AddWithValue("@selAreaStr", selAreaStr);
                connection.Open();
                SqlDataReader reader = commandDel.ExecuteReader();
                if (reader.Read())
                {
                    string delFileName = reader["dealerImgPath"].ToString();
                    //有舊圖才執行刪除
                    if (!String.IsNullOrEmpty(delFileName))
                    {
                        File.Delete(savePath + delFileName);
                    }
                }
                connection.Close();

                //儲存圖片檔案及圖片名稱
                //檢查專案資料夾內有無同名檔案，有同名就加流水號 (避免同名檔案覆蓋)
                DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
                //取得選取檔案名稱
                string fileName = FileUpload1.FileName;
                string[] fileNameArr = fileName.Split('.');
                int count = 0;
                foreach (var fileItem in directoryInfo.GetFiles())
                {
                    if (fileItem.Name.Contains(fileNameArr[0]))
                    {
                        count++;
                    }
                }
                fileName = fileNameArr[0] + $"({count + 1})." + fileNameArr[1];
                FileUpload1.SaveAs(savePath + fileName);

                //渲染畫面
                DateTime nowtime = DateTime.Now;
                LabUploadImg.Visible = true;
                LabUploadImg.ForeColor = Color.Green;
                LabUploadImg.Text = "*Upload Success! - " + nowtime.ToString("G");

                //更新資料庫資料
                string sql = "UPDATE Dealers SET dealerImgPath = @fileName WHERE area = @selAreaStr";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@fileName", fileName);
                command.Parameters.AddWithValue("@selAreaStr", selAreaStr);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                //渲染畫面
                showDealerListTable();
            }
            else
            {
                //警告沒有選取檔案
                LabUploadImg.Visible = true;
                LabUploadImg.ForeColor = Color.Red;
                LabUploadImg.Text = "*Need Choose File!";
            }
        }

        #endregion



        private void ClearDealerTable()
        {
            TextBoxDealerUpdateCountry.Text = "";
            TextBoxDealerUpdateArea.Text = "";
            LiteralImg.Text = "";
            TextBoxDealerUpdateImage.Text = "";
            TextBoxDealerUpdateName.Text = "";
            TextBoxDealerUpdateContact.Text = "";
            TextBoxDealerUpdateAddress.Text = "";
            TextBoxDealerUpdateTel.Text = "";
            TextBoxDealerUpdateFax.Text = "";
            TextBoxDealerUpdateEmail.Text = "";
            TextBoxDealerUpdateLink.Text = "";
            TextBoxDealerUpdateInitDate.Text = "";
        }

        #region show databind

        private void showAreaList()
        {
            //依下拉選單選取國家的值 (id) 取得地區分類
            string selCountry_id = DropDownList1.SelectedValue;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);
            string sql = "SELECT DISTINCT area FROM Dealers WHERE country_ID = @selCountry_id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@selCountry_id", selCountry_id);
            //取得地區分類
            connection.Open();
            SqlDataReader readerCountry = command.ExecuteReader();
            RadioButtonListArea.Items.Clear(); //先清空再新增
            while (readerCountry.Read())
            {
                string typeStr = readerCountry["area"].ToString();
                // RadioButtonList 增加方式
                ListItem listItem = new ListItem();
                listItem.Text = typeStr;
                listItem.Value = typeStr;

                RadioButtonListArea.Items.Add(listItem);
            }
            connection.Close();
        }

        private void showSelAreaDealerList()
        {
            //依下拉選單選取國家的值 (id) 取得地區分類
            string selCountry_id = DropDownList1.SelectedValue;
            string selArea = RadioButtonListArea.SelectedValue;

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);
            string sql = "SELECT name FROM Dealers WHERE country_ID = @selCountry_id AND area=@area";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@selCountry_id", selCountry_id);
            command.Parameters.AddWithValue("@area", selArea);

            //取得地區分類
            connection.Open();
            SqlDataReader readerCountry = command.ExecuteReader();
            while (readerCountry.Read())
            {
                string typeStr = readerCountry["name"].ToString();
                // RadioButtonList 增加方式
                ListItem listItem = new ListItem();
                listItem.Text = typeStr;
                listItem.Value = typeStr;
                RadioButtonListSelAreaDealer.Items.Add(listItem);
            }
            connection.Close();
        }

        private void showDealerListTable()
        {
            //當區域選取時才顯示代理商資料表
            //DealerList.Visible = true;
            //放入國家顯示文字
            TextBoxDealerUpdateCountry.Text = DropDownList1.SelectedItem.Text;
            //放入區域
            TextBoxDealerUpdateArea.Text = RadioButtonListArea.SelectedValue;

            //依選取區域的值連接資料庫取得資料
            string selDealerId = RadioButtonListSelAreaDealer.SelectedValue;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);
            string sql = $"SELECT * FROM Dealers WHERE DealerId = @DealerId";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@DealerId", selDealerId);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            //放入個別資料
            while (reader.Read())
            {


                string savePath = reader["dealerImgPath"].ToString();
                LiteralImg.Text = $"<img alt='Thumbnail Image' src='/image/upload/{savePath}' Width='209px'/>";
                TextBoxDealerUpdateImage.Text = reader["dealerImgPath"].ToString();
                TextBoxDealerUpdateName.Text = reader["name"].ToString();
                TextBoxDealerUpdateContact.Text = reader["contact"].ToString();
                TextBoxDealerUpdateAddress.Text = reader["address"].ToString();
                TextBoxDealerUpdateTel.Text = reader["tel"].ToString();
                TextBoxDealerUpdateFax.Text = reader["fax"].ToString();
                TextBoxDealerUpdateEmail.Text = reader["email"].ToString();
                TextBoxDealerUpdateLink.Text = reader["link"].ToString();
                TextBoxDealerUpdateInitDate.Text = reader["initDate"].ToString();
            }
            connection.Close();
        }

        #endregion


        #region Country CRUD

        protected void ButtonAddCountry_Click(object sender, EventArgs e)
        {
            //1.連線資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);
            //2.sql語法
            string sql = "INSERT INTO [CountrySort] ([countrySort]) VALUES(@countrySort)";
            //3.創建command物件
            SqlCommand command = new SqlCommand(sql, connection);
            //4.參數化避免攻擊
            command.Parameters.AddWithValue("@countrySort", TextBoxAddCountry.Text);
            //5.資料庫連線開啟
            connection.Open();
            //6.執行sql (新增刪除修改)
            command.ExecuteNonQuery(); //無回傳值
                                       //7.資料庫關閉
            connection.Close();
            //畫面渲染
            GridView1.DataBind();
            SqlDataSource2.DataBind();
            DropDownList1.DataBind();

            //清空輸入欄位
            TextBoxAddCountry.Text = "";
        }

        //用內建小精靈做 Edit, Cancel Edit, Update, Delete

        protected void GridView1_DeltedCountry(object sender, GridViewDeletedEventArgs e)
        {
            SqlDataSource2.DataBind();
            DropDownList1.DataBind(); //刷新國家下拉列表資料
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlDataSource2.DataBind();
            DropDownList1.DataBind(); //先綁定取得選取預設值
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SqlDataSource2.DataBind();
            DropDownList1.DataBind(); //先綁定取得選取預設值
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            SqlDataSource2.DataBind();
            DropDownList1.DataBind(); //先綁定取得選取預設值
        }

        #endregion




        #region Area CRUD

        protected void BtnAddArea_Click(object sender, EventArgs e)
        {
            //取得下拉選單國家的值 (id)
            string selCountry_id = DropDownList1.SelectedValue;
            //取得輸入欄內的文字
            string areaStr = TextBoxAddArea.Text;
            //判斷是否重複用
            bool isRepeat = false;

            //取得地區分類
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);
            string sql = $"SELECT area FROM Dealers WHERE country_ID = @selCountry_id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@selCountry_id", selCountry_id);
            connection.Open();
            SqlDataReader readerCountry = command.ExecuteReader();
            while (readerCountry.Read())
            {
                string typeStr = readerCountry["area"].ToString();
                //判斷有無重複名稱
                if (areaStr.Equals(typeStr))
                {
                    isRepeat = true;
                    //重複警告
                    TextBoxAddArea.ForeColor = Color.Red;
                    LiteralBtnAddAreaAlert.Text = "The area name is repeated!";
                    LiteralBtnAddAreaAlert.Visible = true;
                }
            }
            connection.Close();

            //輸入的區域名稱不重複才執行
            if (!isRepeat)
            {
                TextBoxAddArea.ForeColor = Color.Black;
                //新增區域
                string sql2 = "INSERT INTO Dealers (country_ID, area) VALUES(@selCountry_id, @areaStr)";
                SqlCommand command2 = new SqlCommand(sql2, connection);
                command2.Parameters.AddWithValue("@selCountry_id", selCountry_id);
                command2.Parameters.AddWithValue("@areaStr", areaStr);
                connection.Open();
                command2.ExecuteNonQuery();
                connection.Close();

                //畫面渲染
                RadioButtonListArea.Items.Clear(); //清掉舊的
                BtnDelArea.Visible = false;
                //TODO ???
                //DealerList.Visible = false;
                LabUploadImg.Visible = false;
                UpdateDealerListLab.Visible = false;
                showAreaList(); //讀取新的

                //清空輸入欄位
                TextBoxAddArea.Text = "";
            }

        }

        protected void BtnDelArea_Click(object sender, EventArgs e)
        {
            //取得選取資料的值
            string selAreaStr = RadioButtonListArea.SelectedValue;

            //按照順序刪除資料

            //刪除實際圖檔檔案
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);
            string sql = "SELECT dealerImgPath FROM Dealers WHERE area = @selAreaStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@selAreaStr", selAreaStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string imgPath = reader["dealerImgPath"].ToString();
                if (!imgPath.Equals(""))
                {
                    string savePath = Server.MapPath($"~/image/upload/{imgPath}");
                    File.Delete(savePath);

                }
            }
            connection.Close();

            //刪除資料庫該筆資料
            string sqlDel = "DELETE FROM Dealers WHERE area = @selAreaStr";
            SqlCommand commandDel = new SqlCommand(sqlDel, connection);
            commandDel.Parameters.AddWithValue("@selAreaStr", selAreaStr);
            connection.Open();
            commandDel.ExecuteNonQuery();
            connection.Close();

            //畫面渲染
            RadioButtonListArea.Items.Clear(); //清掉舊的
            BtnDelArea.Visible = false;
            //DealerList.Visible = false;
            LabUploadImg.Visible = false;
            UpdateDealerListLab.Visible = false;
            showAreaList(); //讀取新的
            TextBoxAddArea.ForeColor = Color.Black;
            TextBoxAddArea.Text = "";
        }

        #endregion



        #region Dealer CRUD


        protected void BtnAddDealer_Click(object sender, EventArgs e)
        {
            //依國家及選取區域的值連接資料庫取得資料
            string selCountry_id = DropDownList1.SelectedValue;
            string selAreaStr = RadioButtonListArea.SelectedValue;

            DateTime nowtime = DateTime.Now;

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);

            string sqlFind = "SELECT * FROM Dealers WHERE name=@name AND country_ID=@selCountry_id AND area = @selAreaStr";
            SqlCommand commandFind = new SqlCommand(sqlFind, connection);
            commandFind.Parameters.AddWithValue("@selCountry_id", selCountry_id);
            commandFind.Parameters.AddWithValue("@selAreaStr", selAreaStr);
            commandFind.Parameters.AddWithValue("@name", TextBoxAddDealer.Text);
            connection.Open();
            SqlDataReader reader = commandFind.ExecuteReader();
            if (reader.Read())
            {
                connection.Close();
                //找到重複的dealer

                //渲染上傳成功提示
                LiteralBtnAddDealerStatus.Visible = true;
                LiteralBtnAddDealerStatus.Text = "*Dealer Exist! - " + nowtime.ToString("G");
                Page.SetFocus(LiteralBtnAddDealerStatus);
            }
            else
            {
                connection.Close();
                //未找到重複的dealer

                string sqlFindNull = $"SELECT * FROM Dealers WHERE name IS NULL AND country_ID=@selCountry_id AND area = @selAreaStr";
                SqlCommand commandFindNull = new SqlCommand(sqlFindNull, connection);
                commandFindNull.Parameters.AddWithValue("@selCountry_id", selCountry_id);
                commandFindNull.Parameters.AddWithValue("@selAreaStr", selAreaStr);
                commandFindNull.Parameters.AddWithValue("@name", TextBoxAddDealer.Text);

                connection.Open();
                SqlDataReader readerUpdateDealer = commandFindNull.ExecuteReader();
                if (readerUpdateDealer.Read())
                {
                    connection.Close();

                    string sqlUpdateDealer = $"UPDATE Dealers SET name=@name WHERE name IS NULL AND country_ID=@selCountry_id AND area = @selAreaStr";
                    SqlCommand commandUpdateDealer = new SqlCommand(sqlUpdateDealer, connection);
                    commandUpdateDealer.Parameters.AddWithValue("@selCountry_id", selCountry_id);
                    commandUpdateDealer.Parameters.AddWithValue("@selAreaStr", selAreaStr);
                    commandUpdateDealer.Parameters.AddWithValue("@name", TextBoxAddDealer.Text);
                    connection.Open();
                    commandUpdateDealer.ExecuteNonQuery();
                    connection.Close();

                    //渲染上傳成功提示
                    LiteralBtnAddDealerStatus.Visible = true;
                    LiteralBtnAddDealerStatus.Text = "*Add Dealer Success! - " + nowtime.ToString("G");
                    Page.SetFocus(LiteralBtnAddDealerStatus);

                }
                else
                {
                    connection.Close();
                    //都沒找到dealer 改用insert

                    string sqlInsertDealer = $"INSERT INTO Dealers (country_ID, area, name) VALUES (@selCountry_id, @selAreaStr, @name)";
                    SqlCommand commandInsertDealer = new SqlCommand(sqlInsertDealer, connection);
                    commandInsertDealer.Parameters.AddWithValue("@selCountry_id", selCountry_id);
                    commandInsertDealer.Parameters.AddWithValue("@selAreaStr", selAreaStr);
                    commandInsertDealer.Parameters.AddWithValue("@name", TextBoxAddDealer.Text);
                    connection.Open();
                    commandInsertDealer.ExecuteNonQuery();
                    connection.Close();

                    //渲染上傳成功提示
                    LiteralBtnAddDealerStatus.Visible = true;
                    LiteralBtnAddDealerStatus.Text = "*Add Dealer Success!! - " + nowtime.ToString("G");
                    Page.SetFocus(LiteralBtnAddDealerStatus);
                }


            }

            RadioButtonListSelAreaDealer.Items.Clear();
            RadioButtonListSelAreaDealer.DataBind();
            //showSelAreaDealerList();
            ClearDealerTable();
            TextBoxAddDealer.Text = "";
            //ButtonDeleteDealer.Visible = true;
        }


        protected void ButtonUpdateDelear_Click(object sender, EventArgs e)
        {
            //依國家及選取區域的值連接資料庫取得資料
            string selAreaStr = RadioButtonListArea.SelectedValue;
            string selCountry_id = DropDownList1.SelectedValue;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);
            string sql = $"UPDATE Dealers SET name=@name, contact=@contact, address=@address, tel=@tel, fax=@fax, email=@email, link=@link WHERE country_ID=@selCountry_id AND area = @selAreaStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", TextBoxDealerUpdateName.Text);
            command.Parameters.AddWithValue("@contact", TextBoxDealerUpdateContact.Text);
            command.Parameters.AddWithValue("@address", TextBoxDealerUpdateAddress.Text);
            command.Parameters.AddWithValue("@tel", TextBoxDealerUpdateTel.Text);
            command.Parameters.AddWithValue("@fax", TextBoxDealerUpdateFax.Text);
            command.Parameters.AddWithValue("@email", TextBoxDealerUpdateEmail.Text);
            command.Parameters.AddWithValue("@link", TextBoxDealerUpdateLink.Text);
            command.Parameters.AddWithValue("@selCountry_id", selCountry_id);
            command.Parameters.AddWithValue("@selAreaStr", selAreaStr);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            //渲染上傳成功提示
            DateTime nowtime = DateTime.Now;
            UpdateDealerListLab.Visible = true;
            UpdateDealerListLab.Text = "*Upload Success! - " + nowtime.ToString("G");
            Page.SetFocus(UpdateDealerListLab);

            RadioButtonListSelAreaDealer.DataBind();
            ClearDealerTable();
        }


        protected void ButtonDeleteDealer_Click(object sender, EventArgs e)
        {
            //依國家及選取區域的值連接資料庫取得資料
            string selCountry_id = DropDownList1.SelectedValue;
            string selAreaStr = RadioButtonListArea.SelectedValue;
            string selDealerId = RadioButtonListSelAreaDealer.SelectedValue;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ConnectionString);
            //string sql = $"DELETE FROM Dealers WHERE country_ID=@selCountry_id AND area = @selAreaStr AND name=@name";
            string sql = $"DELETE FROM Dealers WHERE DealerId=@DealerId AND country_ID=@selCountry_id AND area = @selAreaStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@DealerId", selDealerId);
            command.Parameters.AddWithValue("@selCountry_id", selCountry_id);
            command.Parameters.AddWithValue("@selAreaStr", selAreaStr);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            //渲染上傳成功提示
            DateTime nowtime = DateTime.Now;
            LiteralButtonDeleteDealerStatus.Visible = true;
            LiteralButtonDeleteDealerStatus.Text = "*Delete Success! - " + nowtime.ToString("G");

            showAreaList();  //重新render清單
            RadioButtonListSelAreaDealer.Items.Clear();
            RadioButtonListSelAreaDealer.DataBind();
            showDealerListTable();
        }



        #endregion



        protected void ButtonDelDelear_Click(object sender, EventArgs e)
        {

        }


    }
}