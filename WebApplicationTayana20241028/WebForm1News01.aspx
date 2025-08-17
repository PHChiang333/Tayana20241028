<%@ Page Title="" Language="C#" MasterPageFile="~/SiteFronthomestyle.Master" AutoEventWireup="true" CodeBehind="WebForm1News01.aspx.cs" Inherits="WebApplicationTayana20241028.WebForm1news01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!--遮罩-->
<%--    <div class="bannermasks">
        <img src="tayana/html/images/banner02_masks.png" alt="&quot;&quot;" />
    </div>--%>
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
                <p><span>NEWS</span></p>
                <ul>
                    <li><a href="#">News & Events</a></li>

                </ul>



            </div>




        </div>







        <!--------------------------------左邊選單結束---------------------------------------------------->

        <!--------------------------------右邊選單開始---------------------------------------------------->
        <div id="crumb"><a href="WebForm1Index.aspx">Home</a> >> <a href="WebForm1News01.aspx">News </a>>> <a href="#"><span class="on1">News & Events</span></a></div>
        <div class="right">
            <div class="right1">
                <div class="title"><span>News & Events</span></div>

                <!--------------------------------內容開始---------------------------------------------------->

                <div class="box2_list">
                    <ul>

                        <%--                        <li>
                            <div class="list01">
                                <ul>
                                    <li>
                                        <div>
                                            <p>
                                                <img src="tayana/html/images/pit006.jpg" alt="&quot;&quot;" />
                                            </p>
                                        </div>
                                    </li>
                                    <li><span>2012-01-28</span><br />
                                        Tayana 58 CE Certificates are availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are available</li>
                                    <li>availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are available</li>
                                </ul>
                            </div>
                        </li>--%>

                        <asp:Repeater ID="RepeaterNewsList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <div class="list01">
                                        <ul>
                                            <li>
                                                <div>
                                                    <p>
                                                        <img src="<%# Eval("CoverImgPath") %>" alt="&quot;&quot;" style="width:187px;height:121px;" />
                                                    </p>
                                                </div>
                                            </li>
                                            <li><span><%# Eval("NewsDate", "{0:yyyy-MM-dd}") %></span>
                                                <br />
                                                <a href="WebForm1News02.aspx?NewsId=<%# Eval("NewsId") %>" target="_blank" style="text-decoration:none"><%# Eval("NewsTilte") %></a></li>
                                            <br />
                                            <li><%# Eval("NewsSummary") %></li>
                                        </ul>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>



                    </ul>

<%--                    <div class="pagenumber">
                        | <span>1</span>
                        | <a href="#">2</a> | <a href="#">3</a> | <a href="#">4</a> | <a href="#">5</a> |  <a href="#">Next</a>  <a href="#">LastPage</a>
                    </div>--%>
                    <%--<div class="pagenumber1">Items：<span>89</span>  |  Pages：<span>1/9</span></div>--%>

                    <div class="pagenumber">
                        <asp:Literal ID="litPagination" runat="server"></asp:Literal>
                    </div>
                </div>


                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>

        <!--------------------------------右邊選單結束---------------------------------------------------->
    </div>




</asp:Content>
