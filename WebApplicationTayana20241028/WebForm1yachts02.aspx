<%@ Page Title="" Language="C#" MasterPageFile="~/SiteFronthomestyleYachts03.Master" AutoEventWireup="true" CodeBehind="WebForm1yachts02.aspx.cs" Inherits="WebApplicationTayana20241028.WebForm1yachts02" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="tayana/html/css/jquery.ad-gallery.css">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="tayana/html/Scripts/jquery.ad-gallery.js"></script>
    <script type="text/javascript">
        $(function () {
            var galleries = $('.ad-gallery').adGallery();
            galleries[0].settings.effect = 'slide-hori';
        });
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--遮罩-->
    <div class="bannermasks">
        <img src="tayana/html/images/banner01_masks.png" alt="&quot;&quot;" />
    </div>
    <!--遮罩結束-->

    <div class="banner">
        <div id="gallery" class="ad-gallery">
            <div class="ad-image-wrapper">
            </div>
            <div class="ad-controls" style="display: none">
            </div>
            <div class="ad-nav">
                <div class="ad-thumbs">
                    <ul class="ad-thumb-list">
                        <%--                        <li>
                            <a href="tayana/html/images/test1.jpg">
                                <img src="tayana/html/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="tayana/html/images/test002.jpg">
                                <img src="tayana/html/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="tayana/html/images/test002.jpg">
                                <img src="tayana/html/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="tayana/html/images/test002.jpg">
                                <img src="tayana/html/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="tayana/html/images/test002.jpg">
                                <img src="tayana/html/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="tayana/html/images/test002.jpg">
                                <img src="tayana/html/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="tayana/html/images/test002.jpg">
                                <img src="tayana/html/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="tayana/html/images/test002.jpg">
                                <img src="tayana/html/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="tayana/html/images/test002.jpg">
                                <img src="tayana/html/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="tayana/html/images/test002.jpg">
                                <img src="tayana/html/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="tayana/html/images/test002.jpg">
                                <img src="tayana/html/images/pit003.jpg">
                            </a>
                        </li>--%>

                        <asp:Repeater ID="RepeaterAdThumb" runat="server">
                            <ItemTemplate>
                                <li>
                                    <%--                                    <a href="<%# Eval("YachtCoverImgPath") %>" style="width: 1001px; height: 406px;">
                                        <img src="<%# Eval("YachtCoverImgPath") %>" style="width: 99px; height: 59px;">
                                    </a>--%>
                                    <a href="<%# Eval("YachtCoverImgPath") %>">
                                        <img src="<%# Eval("YachtCoverImgPath") %>" style="width: 99px; height: 59px;">
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>



                    </ul>
                </div>
            </div>
        </div>
    </div>


    <%-----------舊的換圖---------------------------------------------------------------%>



    <!--遮罩-->
    <%--    <div class="bannermasks">
        <img src="tayana/html/images/banner01_masks.png" alt="&quot;&quot;" />
    </div>--%>
    <!--遮罩結束-->

    <%--    <div id="buttom01">
        <a href="#">
            <img src="tayana/html/images/buttom01.gif" alt="next" /></a>
    </div>--%>

    <!--小圖開始-->
    <%--    <div class="bannerimg">
        <ul>
            <li><a href="#">
                <div class="on">
                    <p class="bannerimg_p">
                        <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                    </p>
                </div>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" width="300" />
                </p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                </p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                </p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                </p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                </p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                </p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                </p>
            </a></li>
        </ul>

        <ul>
            <li><a class="on" href="#">
                <p class="bannerimg_p">
                    <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                </p>
            </a></li>
            <li>
                <p class="bannerimg_p">
                    <a href="#">
                        <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                </p>
            </li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                </p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                </p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                </p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                </p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                </p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/html/images/pit003.jpg" alt="&quot;&quot;" />
                </p>
            </a></li>
        </ul>


    </div>--%>
    <!--小圖結束-->


    <%--    <div id="buttom02">
        <a href="#">
            <img src="tayana/html/images/buttom02.gif" alt="next" /></a>
    </div>--%>

    <!--------------------------------換圖開始---------------------------------------------------->

    <%--    <div class="banner">
        <ul>
            <li>
                <img src="tayana/html/images/test002.jpg" /></li>
            <li>
                <img src="tayana/html/images/test002.jpg" /></li>
            <li>
                <img src="tayana/html/images/test002.jpg" /></li>
            <li>
                <img src="tayana/html/images/test002.jpg" /></li>
            <li>
                <img src="tayana/html/images/test002.jpg" /></li>
            <li>
                <img src="tayana/html/images/test002.jpg" /></li>
        </ul>

    </div>--%>
    <!--------------------------------換圖結束---------------------------------------------------->

    <%-----------舊的換圖---------------------------------------------------------------%>


    <div class="conbg">
        <!--------------------------------左邊選單開始---------------------------------------------------->
        <div class="left">

            <div class="left1">
                <p><span>YACHTS</span></p>
                <ul>
                    <%--<li><a href="#">Dynasty 72</a></li>--%>
                    <%--<li><a href="#">Tayana 64</a></li>--%>
                    <%--<li><a href="#">Tayana 58</a></li>--%>
                    <%--<li><a href="#">Tayana 55</a></li>--%>
                    <asp:Repeater ID="RepeaterLeftbarYacht" runat="server">
                        <ItemTemplate>
                            <li><a href="WebForm1yachts01.aspx?YachtId=<%# Eval("YachtId") %>"><%# !string.IsNullOrEmpty(Eval("YachtNameTag")?.ToString()) 
? string.Format("{0}({1})", Eval("YachtName"), Eval("YachtNameTag")) : Eval("YachtName") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>



            </div>




        </div>







        <!--------------------------------左邊選單結束---------------------------------------------------->

        <!--------------------------------右邊選單開始---------------------------------------------------->
        <asp:Repeater ID="RepeaterCrumb" runat="server">
            <ItemTemplate>
        <div id="crumb"><a href="WebForm1Index.aspx">Home</a> >> <a href="WebForm1yachts01.aspx">Yachts</a> >> <a href="#"><span class="on1"><%# Eval("YachtName") %></span></a></div>
        <div class="right">
            <div class="right1">
                <div class="title"><span><%# Eval("YachtName") %></span></div>

            </ItemTemplate>
        </asp:Repeater>

                <!--------------------------------內容開始---------------------------------------------------->

                <!--次選單-->
                <div class="menu_y">
                    <ul>
                        <li class="menu_y00">YACHTS</li>
                        <%--                        <li><a class="menu_yli01" href="WebForm1yachts01.aspx">Overview</a></li>
                        <li><a class="menu_yli02" href="WebForm1yachts02.aspx">Layout & deck plan</a>n</li>
                        <li><a class="menu_yli03" href="WebForm1yachts03.aspx">Specification</a></li>
                        <li></li>--%>
                        <li>
                            <asp:HyperLink ID="HyperLinkOverview" runat="server" CssClass="menu_yli01">Overview</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLinkLayout" runat="server" CssClass="menu_yli02">Layout & deck plan</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLinkSpec" runat="server" CssClass="menu_yli03">Specification</asp:HyperLink></li>
                    </ul>
                </div>
                <!--次選單-->

                <div class="box6">
                    <p>Layout & deck plan</p>
                    <ul>
                        <li>
                            <img src="tayana/html/images/deckplan01.jpg" alt="&quot;&quot;" /></li>
                        <li>
                            <img src="tayana/html/images/deckplan01.jpg" alt="&quot;&quot;" /></li>

                        <asp:Repeater ID="RepeaterLayoutImg" runat="server">
                            <ItemTemplate>
                                <li>
                                    <img src="<%# Eval("YachtLayoutImgPath") %>" alt="&quot;&quot;" style="width: 100%" />
                                </li>
                            </ItemTemplate>

                        </asp:Repeater>

                    </ul>
                </div>


                <div class="clear"></div>
                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>

        <!--------------------------------右邊選單結束---------------------------------------------------->
    </div>



</asp:Content>
