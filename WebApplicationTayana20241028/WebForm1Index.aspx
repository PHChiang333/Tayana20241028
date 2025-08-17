<%@ Page Title="" Language="C#" MasterPageFile="~/SiteFront.Master" AutoEventWireup="true" CodeBehind="WebForm1Index.aspx.cs" Inherits="WebApplicationTayana20241028.WebFormIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript" src="tayana/html/Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="tayana/html/Scripts/jquery.cycle.all.2.74.js"></script>

    <script type="text/javascript">


        $(function () {

            // 先取得 #abgne-block-20110111 , 必要參數及輪播間隔
            var $block = $('#abgne-block-20110111'),
                timrt, speed = 2000;

            // 預設顯示第一張圖片及樣式
            $('#abgne-block-20110111 .bd .banner ul:eq(0)').children().hide().eq(0).show();
            $('.title ul li:eq(0)').addClass('on');

            // 幫 #abgne-block-20110111 .title ul li 加上 hover() 事件
            var $li = $('.title ul li', $block).hover(function () {
                // 當滑鼠移上時加上 .over 樣式
                $(this).addClass('over').siblings('.over').removeClass('over');
            }, function () {
                // 當滑鼠移出時移除 .over 樣式
                $(this).removeClass('over');
            }).click(function () {
                // 當滑鼠點擊時, 顯示相對應的 div.info
                // 並加上 .on 樣式

                $(this).addClass('on').siblings('.on').removeClass('on');
                $('#abgne-block-20110111 .bd .banner ul:eq(0)').children().hide().eq($(this).index()).fadeIn(1000);
            });

            // 幫 $block 加上 hover() 事件
            $block.hover(function () {
                // 當滑鼠移上時停止計時器
                clearTimeout(timer);
            }, function () {
                // 當滑鼠移出時啟動計時器
                timer = setTimeout(move, speed);
            });

            // 控制輪播
            function move() {
                var _index = $('.title ul li.on', $block).index();
                _index = (_index + 1) % $li.length;
                $li.eq(_index).click();

                timer = setTimeout(move, speed);
            }

            // 啟動計時器
            timer = setTimeout(move, speed);

        });


    </script>









</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!--------------------------------換圖開始---------------------------------------------------->
    <div id="abgne-block-20110111">
        <div class="bd">
            <div class="banner" style="border-radius: 5px; height: 424px; width: 978px;">

                <ul>
                    <asp:Literal ID="LitBanner" runat="server"></asp:Literal>


                    <%--                    <li class="info on"><a href="#">
                        <img src="tayana/html/images/banner001b.jpg" /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>48</span><br />
                            <p>SPECIFICATION SHEET</p>
                        </div>
                        <!--文字結束-->
                    </li>--%>
                    <%--                    <li class="info"><a href="#">
                        <img src="tayana/html/images/banner002b.jpg" /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>54</span><br />
                            <p>SPECIFICATION SHEET</p>
                        </div>
                        <!--文字結束-->
                        <!--新船型開始  54型才出現其於隱藏 -->
                        <div class="new">
                            <img src="tayana/html/images/new01.png" alt="new" />
                        </div>
                        <!--新船型結束-->
                    </li>
                    <li class="info"><a href="#">
                        <img src="tayana/html/images/banner003b.jpg" /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>37</span><br />
                            <p>SPECIFICATION SHEET</p>
                        </div>
                        <!--文字結束-->
                    </li>
                    <li class="info"><a href="#">
                        <img src="tayana/html/images/banner004b.jpg" /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>64</span><br />
                            <p>SPECIFICATION SHEET</p>
                        </div>
                        <!--文字結束-->
                    </li>
                    <li class="info"><a href="#">
                        <img src="tayana/html/images/banner005b.jpg" /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>58</span><br />
                            <p>SPECIFICATION SHEET</p>
                        </div>
                        <!--文字結束-->
                    </li>
                    <li class="info"><a href="#">
                        <img src="tayana/html/images/banner006b.jpg" /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>55</span><br />
                            <p>SPECIFICATION SHEET</p>
                        </div>
                        <!--文字結束-->
                    </li>--%>
                </ul>


                <!--小圖開始-->
                <div class="bannerimg title" >
                    <%--<div class="bannerimg title" style="display:none;">--%>
                    <ul>
                        <asp:Literal ID="LitBannerNum" runat="server"></asp:Literal>


                        <%--                        <li class="on">
                            <div>
                                <p class="bannerimg_p">
                                    <img src="tayana/html/images/i001.jpg" alt="&quot;&quot;" />
                                </p>
                            </div>
                        </li>--%>
                        <%--<li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src="tayana/html/images/i002.jpg" alt="&quot;&quot;" />
                                </p>
                            </div>
                        </li>
                        <li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src="tayana/html/images/i003.jpg" alt="&quot;&quot;" />
                                </p>
                            </div>
                        </li>
                        <li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src="tayana/html/images/i004.jpg" alt="&quot;&quot;" />
                                </p>
                            </div>
                        </li>
                        <li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src="tayana/html/images/i005.jpg" alt="&quot;&quot;" />
                                </p>
                            </div>
                        </li>
                        <li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src="tayana/html/images/i006.jpg" alt="&quot;&quot;" />
                                </p>
                            </div>
                        </li>--%>
                    </ul>
                </div>
                <!--小圖結束-->
            </div>
        </div>
    </div>
    <!--------------------------------換圖結束---------------------------------------------------->











    <!--------------------------------最新消息---------------------------------------------------->
    <div class="news">
        <div class="newstitle">
            <p class="newstitlep1">
                <img src="tayana/html/images/news.gif" alt="news" />
            </p>
            <p class="newstitlep2"><a href="WebForm1News01.aspx">More>></a></p>
        </div>

        <ul>
            <!--TOP第一則最新消息-->
            <li>
                <div class="news01">
                    <!--TOP標籤-->
                    <div class="newstop">
                        <asp:Image ID="ImgIsTop1" runat="server" AlternateText="&quot;&quot;" Visible="false" ImageUrl="tayana/html/images/new_top01.png" />
                    </div>
                    <!--TOP標籤結束-->
                    <div class="news02p1">
                        <p class="news02p1img">
                            <asp:Literal ID="LiteralNewsImg1" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <p class="news02p2">
                        <span>
                            <asp:Label ID="LabNewsDate1" runat="server" ForeColor="#02A5B8"></asp:Label>
                        </span>
                        <span>
                            <asp:HyperLink ID="HLinkNews1" runat="server"></asp:HyperLink>
                        </span>
                    </p>
                    <input type="hidden" value="0" />
                </div>
            </li>
            <!--TOP第一則最新消息結束-->

            <!--第二則-->
            <li>

                <div class="news01">
                    <!--TOP標籤-->
                    <div class="newstop">
                        <asp:Image ID="ImgIsTop2" runat="server" AlternateText="&quot;&quot;" Visible="false" ImageUrl="tayana/html/images/new_top01.png" />
                    </div>
                    <!--TOP標籤結束-->
                    <div class="news02p1">
                        <p class="news02p1img">
                            <asp:Literal ID="LiteralNewsImg2" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <p class="news02p2">
                        <span>
                            <asp:Label ID="LabNewsDate2" runat="server" ForeColor="#02A5B8"></asp:Label>
                        </span>
                        <span>
                            <asp:HyperLink ID="HLinkNews2" runat="server"></asp:HyperLink>
                        </span>
                    </p>
                    <input type="hidden" value="0" />
                </div>
            </li>
            <!--第二則結束-->

            <!--第三則-->
            <li>
                <div class="news02">
                    <!--TOP標籤-->
                    <div class="newstop">
                        <asp:Image ID="ImgIsTop3" runat="server" AlternateText="&quot;&quot;" Visible="false" ImageUrl="tayana/html/images/new_top01.png" />
                    </div>
                    <!--TOP標籤結束-->
                    <div class="news02p1">
                        <p class="news02p1img">
                            <asp:Literal ID="LiteralNewsImg3" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <p class="news02p2">
                        <span>
                            <asp:Label ID="LabNewsDate3" runat="server" ForeColor="#02A5B8"></asp:Label>
                        </span>
                        <span>
                            <asp:HyperLink ID="HLinkNews3" runat="server"></asp:HyperLink>
                        </span>
                    </p>
                    <input type="hidden" value="0" />
                </div>
            </li>
            <!--第三則結束-->


        </ul>
    </div>
    <!--------------------------------最新消息結束---------------------------------------------------->



</asp:Content>
