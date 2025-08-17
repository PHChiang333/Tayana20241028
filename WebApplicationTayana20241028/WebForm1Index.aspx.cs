using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTayana20241028
{
    public partial class WebFormIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //共用
                //ShowRepeaterLeftbar();  //Left sidevbar   
                //YachtRightMenu();  //right menu links
                //ShowRepeaterAdThumb(); //bind ad-thumb data
                loadBanner();
                loadNews();

                //databinging
                //ShowRepeaterSpec();  //bind spec data
            }
            else
            {

            }
        }

        private void loadBanner()
        {
            DbHelper db = new DbHelper();


            string sql = $"SELECT * " + " " +
                        $"FROM yacht " + " " +
                        $"ORDER BY IsPintop DESC, CreatedTime ASC ;";

            Dictionary<string, object> param = new Dictionary<string, object>();

            SqlDataReader reader = db.SearchDB(sql, param);

            StringBuilder bannerHtml = new StringBuilder();
            StringBuilder bannerHtmlNum = new StringBuilder();  // 小圖

            while (reader.Read())
            {
                //每個型號只取出第一張圖
                string imgPahtStr = "";

                if (!string.IsNullOrEmpty(reader["YachtCoverImgPath"].ToString()))
                {
                    imgPahtStr = reader["YachtCoverImgPath"].ToString();
                }

                //遊艇型號字串用空格切割區分文字及數字
                string[] modelArr = reader["YachtName"].ToString().Split(' ');
                //依新設計或新建造來切換顯示標籤

                string newTagStr = ""; //標籤檔名用  
                string displayStr = "none";
                string displayNewStr = "0"; // value 預設為 0 不顯示標籤
                //判斷是否顯示對應標籤
                if (reader["YachtNameTag"].ToString() == "New Design")
                {
                    displayNewStr = "true";
                    displayStr = "block";
                    newTagStr = "tayana/html/images/new02.png";
                }
                else if (reader["YachtNameTag"].ToString() == "New Building")
                {
                    displayNewStr = "true";
                    displayStr = "block";
                    newTagStr = "tayana/html/images/new01.png";
                }



                //加入遊艇型號輪播圖 HTML
                bannerHtml.Append($"" +
                    $"<li class='info' style='border-radius: 5px;height: 424px;width: 966px;'><a href='' target='_blank'><img src='{imgPahtStr}' style='width: 966px;height: 424px;border-radius: 5px;'/></a><div class='wordtitle'>{modelArr[0]} <span>{modelArr[1]}</span><br /><p>SPECIFICATION SHEET</p></div><div class='new' style='display: {displayStr};overflow: hidden;border-radius:10px;'><img src='{newTagStr}' alt='new' /></div><input type='hidden' value='{displayNewStr}' /></li>");

                //bannerHtmlNum.Append($"" +
                //    $"<li class='info' style='border-radius: 5px;height: 59px;'><a href='' target='_blank'><img src='{imgPahtStr}' style='height: 59px;border-radius: 5px;'/></a><div class='wordtitle'>{modelArr[0]} <span>{modelArr[1]}</span><br /><p>SPECIFICATION SHEET</p></div><div class='new' style='display: none;overflow: hidden;border-radius:10px;'><img src='{newTagStr}' alt='new' /></div><input type='hidden' value='{displayNewStr}' /></li>");

                bannerHtmlNum.Append($"<li><div><p class='bannerimg_p'><img src='{imgPahtStr}' style='width:100px;height: 60px;' alt='&quot;&quot;'/></p></div></li>");
                


                //TODO 小圖不顯示問題，改寫為本來的格式
                //bannerHtml.Append($"");
                //bannerHtml.Append($"");

            }


            db.CloseDB();

            LitBanner.Text = bannerHtml.ToString();
            LitBannerNum.Text = bannerHtmlNum.ToString(); //不顯示但影響輪播圖片數量計算

        }

        private void loadNews()
        {
            //設定首頁 3 筆新聞的時間範圍
            DateTime nowTime = DateTime.Now;
            string nowDate = nowTime.ToString("yyyy-MM-dd");
            int startDate = -1;
            DateTime limitTime = nowTime.AddMonths(startDate);
            string limitDate = limitTime.ToString("yyyy-MM-dd");

            //計算設定的時間範圍內新聞數量
            string connstring = "tayanaConnectionString";
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString);
            string sql = "SELECT COUNT(NewsId) FROM News WHERE NewsDate >= @limitDate AND NewsDate <= @nowDate";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@nowDate", nowDate);
            command.Parameters.AddWithValue("@limitDate", limitDate);
            connection.Open();

            //用 ExecuteScalar() 來算數量
            int newsNum = Convert.ToInt32(command.ExecuteScalar());
            //時間範圍設定持續往前 1 個月，直到取出新聞數量超過 3 筆
            while (newsNum < 3)
            {
                startDate--;
                limitTime = nowTime.AddDays(startDate);
                limitDate = limitTime.ToString("yyyy-MM-dd");
                SqlCommand command2 = new SqlCommand(sql, connection);
                command2.Parameters.AddWithValue("@nowDate", nowDate);
                command2.Parameters.AddWithValue("@limitDate", limitDate);
                newsNum = Convert.ToInt32(command2.ExecuteScalar());
            }
            connection.Close();

            //取出時間範圍內首 3 筆新聞，且 TOP 會放在取出項的最前面
            connection.Open();
            string sql2 = "SELECT TOP 3 * FROM News WHERE NewsDate >= @limitDate AND NewsDate <= @nowDate ORDER BY IsPintop DESC, NewsDate DESC";
            SqlCommand command3 = new SqlCommand(sql2, connection);
            command3.Parameters.AddWithValue("@nowDate", nowDate);
            command3.Parameters.AddWithValue("@limitDate", limitDate);
            SqlDataReader reader = command3.ExecuteReader();
            int count = 1; //第幾筆新聞

            while (reader.Read())
            {
                string isTopStr = reader["IsPintop"].ToString();
                //string guidStr = reader["guid"].ToString();
                if (count == 1)
                {
                    //渲染第1筆新聞圖卡
                    string newsImg = reader["CoverImgPath"].ToString();
                    LiteralNewsImg1.Text = $"<img id='thumbnail_Image1' src='{newsImg}' style='border-width: 0px; width=95px;height:95px;' />";
                    DateTime dateTimeTitle = DateTime.Parse(reader["NewsDate"].ToString());
                    LabNewsDate1.Text = dateTimeTitle.ToString("yyyy/M/d");
                    HLinkNews1.Text = reader["NewsTilte"].ToString();
                    HLinkNews1.NavigateUrl = $"WebForm1News02.aspx?NewsId={reader["NewsId"].ToString()}";
                    if (isTopStr.Equals("True"))
                    {
                        ImgIsTop1.Visible = true;
                    }
                }
                else if (count == 2)
                {
                    //渲染第2筆新聞圖卡
                    string newsImg = reader["CoverImgPath"].ToString();
                    LiteralNewsImg2.Text = $"<img id='thumbnail_Image2' src='{newsImg}' style='border-width: 0px; width=95px;height:95px;' />";
                    DateTime dateTimeTitle = DateTime.Parse(reader["NewsDate"].ToString());
                    LabNewsDate2.Text = dateTimeTitle.ToString("yyyy/M/d");
                    HLinkNews2.Text = reader["NewsTilte"].ToString();
                    HLinkNews2.NavigateUrl = $"WebForm1News02.aspx?NewsId={reader["NewsId"].ToString()}";
                    if (isTopStr.Equals("True"))
                    {
                        ImgIsTop2.Visible = true;
                    }
                }
                else if (count == 3)
                {
                    //渲染第3筆新聞圖卡
                    string newsImg = reader["CoverImgPath"].ToString();
                    LiteralNewsImg3.Text = $"<img id='thumbnail_Image2' src='{newsImg}' style='border-width: 0px; width=95px;height:95px;' />";
                    DateTime dateTimeTitle = DateTime.Parse(reader["NewsDate"].ToString());
                    LabNewsDate3.Text = dateTimeTitle.ToString("yyyy/M/d");
                    HLinkNews3.Text = reader["NewsTilte"].ToString();
                    HLinkNews3.NavigateUrl = $"WebForm1News02.aspx?NewsId={reader["NewsId"].ToString()}";
                    if (isTopStr.Equals("True"))
                    {
                        ImgIsTop3.Visible = true;
                    }
                }
                else break; //超過3筆後停止
                count++;
            }
            connection.Close();



        }








    }
}