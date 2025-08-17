<%@ Page Title="" Language="C#" MasterPageFile="~/SiteFronthomestyle.Master" AutoEventWireup="true" CodeBehind="WebForm1dealers.aspx.cs" Inherits="WebApplicationTayana20241028.WebForm1dealers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        img{
            width:100%;
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--遮罩-->
    <div class="bannermasks">
        <img src="tayana/html/images/DEALERS.jpg" alt="&quot;&quot;" width="967" height="371" />
    </div>
    <!--遮罩結束-->

    <!--<div id="buttom01"><a href="#"><img src="tayana/html/images/buttom01.gif" alt="next" /></a></div>-->

    <!--小圖開始-->
    <!--<div class="bannerimg">
<ul>
<li> <a href="#"><div class="on"><p class="bannerimg_p"><img  src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></div></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" width="300" /></p>
</a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
</ul>

<ul>
<li> <a class="on" href="#"><p class="bannerimg_p"><img  src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <p class="bannerimg_p"><a href="#"><img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></li>
<li> <a href="#"><p class="bannerimg_p"><img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
</ul>


</div>-->
    <!--小圖結束-->


    <!--<div id="buttom02"> <a href="#"><img src="tayana/html/images/buttom02.gif" alt="next" /></a></div>-->

    <!--------------------------------換圖開始---------------------------------------------------->

    <div class="banner">
        <ul>
            <li>
                <img src="tayana/html/images/newbanner.jpg" alt="Tayana Yachts" /></li>
        </ul>

    </div>
    <!--------------------------------換圖結束---------------------------------------------------->




    <div class="conbg">
        <!--------------------------------左邊選單開始---------------------------------------------------->
        <div class="left">

            <div class="left1">
                <p><span>DEALERS</span></p>
                <ul>
                    <asp:Repeater ID="RepeaterSidebar" runat="server">
                        <ItemTemplate>
                            <li><a href="WebForm1dealers.aspx?country_ID=<%# Eval("country_ID") %>"><%# Eval("countrySort") %></a></li>
                        </ItemTemplate>


                    </asp:Repeater>
                </ul>



            </div>




        </div>







        <!--------------------------------左邊選單結束---------------------------------------------------->

        <!--------------------------------右邊選單開始---------------------------------------------------->
        <div id="crumb">
            <a href="WebForm1Index.aspx">Home</a> >> <a href="#">Dealers </a>>>
            <asp:Repeater ID="RepeaterTopbar" runat="server">
                <ItemTemplate><a href="WebForm1dealers.aspx?country_ID=<%# Eval("country_ID") %>"><span class="on1"><%# Eval("countrySort") %></span></a></ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="right">
            <div class="right1">
                <div class="title">
                    <span>
                        <asp:Repeater ID="RepeaterTopbar2" runat="server">
                            <ItemTemplate><%# Eval("countrySort") %></ItemTemplate>
                        </asp:Repeater>
                    </span>
                </div>

                <!--------------------------------內容開始---------------------------------------------------->
                <div class="box2_list">
                    <ul>

<%--                        <li>
                            <div class="list02">
                                <ul>
                                    <li class="list02li">
                                        <div>
                                            <p>
                                                <img src="tayana/html/images/dealers001.jpg" />>
                                            </p>
                                        </div>
                                    </li>
                                    <li><span>Annapolis  我是sample</span><br />
                                        Noyce Yachts<br />
                                        Contact：Mr. Robert Noyce
                                        <br />
                                        Address：4880 Church Lane Galesville, MD 20765
                                        <br />
                                        TEL：(410)263-3346
                                        <br />
                                        E-mail：Robert@noyceyachts.com
                                        <br />
                                        <a href="http://www.noyceyachts.com" target="_blank">www.noyceyachts.com</a></li>
                                </ul>
                            </div>
                        </li>--%>

                        <asp:Repeater ID="RepeaterDealerList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <div class="list02">
                                        <ul>
                                            <li class="list02li">
                                                <div>
                                                    <p>
                                                        <img src="../image/upload/<%# Eval("dealerImgPath") %>" >
                                                    </p>
                                                </div>
                                            </li>
                                            <li><span><%# Eval("area") %></span>
                                                <br />
                                                <%# Eval("name") %>
                                                <br />
                                                Contact：<%# Eval("contact") %>
                                                <br />
                                                Address：<%# Eval("address") %>
                                                <br />
                                                TEL：<%# Eval("tel") %>
                                                <br />
                                                FAX: <%# Eval("Fax") %>
                                                <br />
                                                Cell: <%# Eval("Cell") %>
                                                <br />
                                                E-mail：<%# Eval("email") %>
                                                <br />
                                                <a href="<%# Eval("link") %>" target="_blank"><%# Eval("link") %></a></li>
                                            </ul>
                                        </div>
                                    </li>
                            </ItemTemplate>
                        </asp:Repeater>



                    </ul>

<%--                    <div class="pagenumber">| <span>1</span> | <a href="#">2</a> | <a href="#">3</a> | <a href="#">4</a> | <a href="#">5</a> |  <a href="#">Next</a>  <a href="#">LastPage</a></div>
                    <div class="pagenumber1">Items：<span>89</span>  |  Pages：<span>1/9</span></div>--%>


                </div>

                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>

        <!--------------------------------右邊選單結束---------------------------------------------------->
    </div>


</asp:Content>
