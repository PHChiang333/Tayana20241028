using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTayana20241028
{
    public partial class WebForm1dealers : System.Web.UI.Page
    {

        string DbTableD = "Dealers";
        string DbTableC = "CountrySort";
        string connstring = "tayanaConnectionString";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["country_ID"] != null)
            {
                string selCountry_Id = Request.QueryString["country_ID"];
            }
            else
            {
            }


            if (!IsPostBack)
            {
                BindRepeaterSidebar(RepeaterSidebar);
                BindRepeaterTopbar(RepeaterTopbar); //麵包屑
                BindRepeaterTopbar(RepeaterTopbar2);  //title
                BindRepeaterContent(RepeaterDealerList); //Dealer list
            }
        }



        #region repeater

        private void BindRepeaterSidebar(Repeater repeaterId)
        {
            string SQLquery;

            //if (Request.QueryString["country_ID"] != null) {
            //    SQLquery = $"SELECT * FROM {DbTableC} WHERE [country_ID] = @selCountry_ID;";
            //}
            //else
            //{
            //    SQLquery = $"SELECT * FROM {DbTableC};";
            //}

            SQLquery = $"SELECT * FROM {DbTableC};";

            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLquery, conn))
                {
                    cmd.Parameters.Clear();

                    //if (Request.QueryString["country_ID"] != null)
                    //{
                    //    cmd.Parameters.AddWithValue("@selCountry_ID", Request.QueryString["country_ID"]);
                    //}

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        repeaterId.DataSource = reader;
                        repeaterId.DataBind();
                    }
                }

            }
        }

        private void BindRepeaterTopbar(Repeater repeaterId)
        {
            string SQLquery;

            if (Request.QueryString["country_ID"] != null)
            {
                SQLquery = $"SELECT * FROM {DbTableC} WHERE [country_ID] = @selCountry_ID;";
            }
            else
            {
                SQLquery = $"SELECT TOP (1) * FROM {DbTableC};";
            }


            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLquery, conn))
                {
                    cmd.Parameters.Clear();

                    if (Request.QueryString["country_ID"] != null)
                    {
                        cmd.Parameters.AddWithValue("@selCountry_ID", Request.QueryString["country_ID"]);
                    }

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        repeaterId.DataSource = reader;
                        repeaterId.DataBind();
                    }
                }

            }
        }


        private void BindRepeaterContent(Repeater repeaterId)
        {
            string SQLquery;

            SQLquery = $"SELECT * FROM {DbTableD} WHERE [country_ID] = @selCountry_ID;";

            string firstCountryId = "";

            if (Request.QueryString["country_ID"] != null)
            {
                firstCountryId = Request.QueryString["country_ID"];
            }
            else
            {
                //找到第一個country_ID

                string sqlFindCountryId = $"SELECT TOP (1) * FROM {DbTableD}";

                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlFindCountryId, conn))
                    {
                        cmd.Parameters.Clear();

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            firstCountryId = reader["country_ID"].ToString();
                        }
                    }


                }
            }
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings[connstring].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLquery, conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@selCountry_ID", firstCountryId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        repeaterId.DataSource = reader;
                        repeaterId.DataBind();
                    }
                }

            }











        }

        #endregion



    }
}