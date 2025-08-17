<%@ Page Title="" Language="C#" MasterPageFile="~/SiteFronthomestyle.Master" AutoEventWireup="true" CodeBehind="WebForm1yachts01.aspx.cs" Inherits="WebApplicationTayana20241028.WebForm1yachts01" %>

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
    <%--<!--遮罩-->
    <div class="bannermasks">
        <img src="tayana/html/images/banner01_masks.png" alt="&quot;&quot;" />
    </div>
    <!--遮罩結束-->

    <div id="buttom01">
        <a href="#">
            <img src="tayana/html/images/buttom01.gif" alt="next" /></a>
    </div>

    <!--小圖開始-->
    <div class="bannerimg">
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


    </div>
    <!--小圖結束-->


    <div id="buttom02">
        <a href="#">
            <img src="tayana/html/images/buttom02.gif" alt="next" /></a>
    </div>

    <!--------------------------------換圖開始---------------------------------------------------->

    <div class="banner">
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

    </div>
    <!--------------------------------換圖結束---------------------------------------------------->--%>

    <%-----------舊的換圖---------------------------------------------------------------%>


    <div class="conbg">
        <!--------------------------------左邊選單開始---------------------------------------------------->
        <div class="left">

            <div class="left1">
                <p><span>YACHTS</span></p>
                <ul>
                    <%--                    <li><a href="#">Dynasty 72</a></li>
                    <li><a href="#">Tayana 64</a></li>
                    <li><a href="#">Tayana 58</a></li>
                    <li><a href="#">Tayana 55</a></li>--%>
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
                        <%--                        <li><a class="menu_yli01" href="#">Interior</a></li>
                        <li><a class="menu_yli02" href="#">Layout & deck pla</a>n</li>
                        <li><a class="menu_yli03" href="#">Specification</a></li>--%>
                        <li>
                            <asp:HyperLink ID="HyperLinkOverview" runat="server" CssClass="menu_yli01">Overview</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLinkLayout" runat="server" CssClass="menu_yli02">Layout & deck plan</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLinkSpec" runat="server" CssClass="menu_yli03">Specification</asp:HyperLink></li>
                    </ul>
                </div>
                <!--次選單-->

                <div class="box1">
                    <%--                    With the world renowned pedigree combination of Ta Yang Yacht Builders, Andrew Winch Designs, and Bill Dixon Naval Architects, the Tayana Dynasty 72 ranks as an exceptional high performance cruising yacht. Space abounds in the Dynasty 72, with two spacious cockpits and a sunbathing area on the deck. The central cockpit houses twin steering positions with outdoor dining for eight and access forward into the pilothouse. All control and command equipment is readily available for minimal crew handling. The aft cockpit is accessed from the large owner's cabin and provides a pleasant seating area which opens out through a drop-down transom to the bathing platform. The Dynasty is very much a semi-custom yacht. The interior styling, furniture, and fabrics will reflect the owner's ideals and will blend with an extensive range of high quality fittings and equipment. The technical specification of the yacht will be to a very high standard. Three interior styles have been developed by Andrew Winch. Two owner versions each have four staterooms but different positions for the galley; a charter version has six double cabins with en suite heads. All versions have separate crew quarters, and all versions have the magnificent split level pilot house connecting the forward and aft lower accommodation levels. Custom interiors are available to fit the needs of you and your crew. Ta Yang has been constructing first class yachts for many years. The reputation of Chinese craftsmen over thousands of years is renowned, and it is the combination of their skills with modern design and naval architecture that has created the Tayana Dynasty 72.--%>
                    <asp:Repeater ID="RepeaterContent" runat="server">
                        <ItemTemplate>
                            <%# DecodeHtmlContent(Eval("YachtDesc")) %>
                        </ItemTemplate>
                    </asp:Repeater>
                    <br />
                    <br />

                </div>

                <div class="box3">
                    <h4>PRINCIPAL DIMENSION</h4>
                    <table class="table02">
                        <tr>
                            <td class="table02td01">
                                <table>
                                    <%--                                  <tr>
                                        <th>L.O.A.</th>
                                        <td>72’-0”</td>
                                    </tr>
                                    <tr class="tr003">
                                        <th>L.W.L.</th>
                                        <td>60’-10”</td>
                                    </tr>
                                    <tr>
                                        <th>Beam</th>
                                        <td>20’-0”</td>
                                    </tr>
                                    <tr class="tr003">
                                        <th>Draft (Fin Keel)</th>
                                        <td>8’-6”</td>
                                    </tr>
                                    <tr>
                                        <th>Displacement</th>
                                        <td>96100lbs</td>
                                    </tr>
                                    <tr class="tr003">
                                        <th>Ballast (Fin Keel)</th>
                                        <td>24850lbs</td>
                                    </tr>
                                    <tr>
                                        <th>Sail Area (Main + 150% Triangle)<br />
                                            Main (9.0 oz)<br />
                                            Stays (9.0 oz)<br />
                                            No. 1 Genoa (7.2 oz)<br />
                                            Genoa (150%) (7.2 oz)<br />
                                            I :<br />
                                            J :<br />
                                            P :<br />
                                            E :</th>
                                        <td>2748 sq.
                                            <br />
                                            ft996 sq. ft<br />
                                            386 sq. ft<br />
                                            1167 sq. ft<br />
                                            1782 sq. ft<br />
                                            87’-0”<br />
                                            27’-1.75”<br />
                                            75’-4”<br />
                                            26’-0”<br />
                                        </td>
                                    </tr>
                                    <tr class="tr003">
                                        <th>D/L=191.47Ballast/Displacement</th>
                                        <td>28.10%</td>
                                    </tr>
                                    <tr>
                                        <th>Exterior Style, Interior Designer</th>
                                        <td>Andrew Winch</td>
                                    </tr>
                                    <tr class="tr003">
                                        <th>Naval Architect Designer</th>
                                        <td>Bill Dixon</td>
                                    </tr>--%>
                                    <asp:Repeater ID="RepeaterDimensionTable" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <th><%# Eval("DimensionTitle") %></th>
                                                <td><%# Eval("DimensionContent") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>



                                </table>
                            </td>
                            <td>
                                <%--<img src="tayana/html/images/ya01.jpg" alt="&quot;&quot;" width="278" height="345" />--%>

                                <asp:Repeater ID="RepeaterDimensionImg" runat="server">
                                    <ItemTemplate>
                                        <img src="<%# Eval("YachtDimensionImgPath") %>" alt="&quot;&quot;" width="278" height="345" />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>


                </div>
                <p class="topbuttom">
                    <img src="tayana/html/images/top.gif" alt="top" />
                </p>

                <!--下載開始-->
                <div class="downloads">
                    <p>
                        <img src="tayana/html/images/downloads.gif" alt="&quot;&quot;" />
                    </p>
                    <ul>
                        <%--                        <li><a href="#">Downloads 001</a></li>
                        <li><a href="#">Downloads 001</a></li>
                        <li><a href="#">Downloads 001</a></li>
                        <li><a href="#">Downloads 001</a></li>
                        <li><a href="#">Downloads 001</a></li>--%>
                        <asp:Repeater ID="RepeaterDownload" runat="server">
                            <ItemTemplate>
                                <li><a href="<%# Eval("FilePath") %>" download="<%# Eval("FileName") %>"><%# Eval("FileName") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
                <!--下載結束-->


                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>

        <!--------------------------------右邊選單結束---------------------------------------------------->
    </div>






</asp:Content>
