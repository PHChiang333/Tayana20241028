<%@ Page Title="" Language="C#" MasterPageFile="~/SiteFronthomestyle.Master" AutoEventWireup="true" CodeBehind="WebForm1News02.aspx.cs" Inherits="WebApplicationTayana20241028.WebForm1news02"  ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--遮罩-->
    <div class="bannermasks">
        <img src="tayana/html/images/banner02_masks.png" alt="&quot;&quot;" />
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
                <asp:Repeater ID="RepeaterNews" runat="server">
                    <ItemTemplate>
                        <div class="box3">
                            <h4><%# Eval("NewsTilte") %></h4>
                            <br />
 <%--                           <p>
                                <%# HttpUtility.HtmlEncode(Eval("NewsContent").ToString()) %>
                            </p>--%>
<%--                            <asp:Literal ID="Literal1" runat="server" Text='<%# HtmlEncodeContent(Eval("NewsContent")) %>'></asp:Literal>
                            <asp:Literal ID="litNewsContent" runat="server" Mode="PassThrough" Text='<%# Eval("NewsContent") %>'></asp:Literal>--%>
                        </div>
                        <div>
                            <asp:Literal ID="Literal2" runat="server" Mode="PassThrough" Text='<%# DecodeHtmlContent(Eval("NewsContent")) %>'></asp:Literal>
<%--                             <asp:Literal ID="Literal2" runat="server" Mode="PassThrough" Text='<%# Eval("NewsContent") %>'></asp:Literal>--%>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="RepeaterNewsImg" runat="server">
                    <ItemTemplate>
                        <div class="box3">
                            <img src="<%# Eval("ImgPath") %>" alt="ImgPath" style="width:100%" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>


                <!--下載開始-->
                <div class="downloads">
                    <p>
                        <img src="tayana/html/images/downloads.gif" alt="&quot;&quot;" />
                    </p>
                    <ul>
                        <asp:Repeater ID="RepeaterNewsFile" runat="server">
                            <ItemTemplate>
                                <li><a href="<%# Eval("FilePath") %>" download="<%# Eval("FileName") %>"><%# Eval("FileName") %></a></li>

                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
                <!--下載結束-->

                <div class="buttom001">
                    <a href="WebForm1News01.aspx">
                        <img src="tayana/html/images/back.gif" alt="&quot;&quot;" width="55" height="28" /></a>
                </div>

                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>

        <!--------------------------------右邊選單結束---------------------------------------------------->
    </div>




</asp:Content>
