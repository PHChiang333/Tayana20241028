<%@ Page Title="" Language="C#" MasterPageFile="~/SiteFronthomestyle.Master" AutoEventWireup="true" CodeBehind="WebForm1contact.aspx.cs" Inherits="WebApplicationTayana20241028.WebForm1compan01" %>

<%@ Register Assembly="Recaptcha.Web" Namespace="Recaptcha.Web.UI.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--遮罩-->
    <div class="bannermasks">
        <img src="tayana/html/images/contact.jpg" alt="&quot;&quot;" width="967" height="371" />
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
                <p><span>CONTACT</span></p>
                <ul>
                    <li><a href="#">contacts</a></li>
                </ul>



            </div>




        </div>







        <!--------------------------------左邊選單結束---------------------------------------------------->

        <!--------------------------------右邊選單開始---------------------------------------------------->
        <div id="crumb"><a href="WebForm1Index.aspx">Home</a> >> <a href="#"><span class="on1">Contact</span></a></div>
        <div class="right">
            <div class="right1">
                <div class="title"><span>Contact</span></div>

                <!--------------------------------內容開始---------------------------------------------------->
                <!--表單-->
                <div class="from01">
                    <p>
                        Please Enter your contact information<span class="span01">*Required</span>
                    </p>
                    <br />
                    <table>
                        <tr>
                            <td class="from01td01">Name :</td>
                            <td><span>*</span>
                                <%--<input type="text" name="textfield" id="textfield" />--%>
                                <asp:TextBox runat="server" name="Name" type="text" ID="Name" class="{validate:{required:true, messages:{required:'Required'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">Email :</td>
                            <td><span>*</span>
                                <%--<input type="text" name="textfield" id="textfield" />--%>
                                <asp:TextBox runat="server" name="Email" type="text" ID="Email" class="{validate:{required:true, email:true, messages:{required:'Required', email:'Please check the E-mail format is correct'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">Phone :</td>
                            <td><span>*</span>
                                <%--<input type="text" name="textfield" id="textfield" />--%>
                                <asp:TextBox runat="server" name="Phone" type="text" ID="Phone" class="{validate:{required:true, messages:{required:'Required'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">Country :</td>
                            <td><span>*</span>
                                <%--<select name="select" id="select">
                                    <option>Annapolis</option>
                                </select></td>--%>
                                <asp:DropDownList ID="Country" runat="server" DataSourceID="SqlDataSource2" DataTextField="DealerCountry" DataValueField="DealerCountry"></asp:DropDownList>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:tayanaConnectionString %>' SelectCommand="SELECT DISTINCT [DealerCountry] FROM [dealer]"></asp:SqlDataSource>
                        </tr>
                        <tr>
                            <td colspan="2"><span>*</span>Brochure of interest  *Which Brochure would you like to view?</td>
                        </tr>
                        <tr>
                            <td class="from01td01">&nbsp;</td>
                            <td>
                                <%--<select name="select" id="select">
                                    <option>Dynasty 72 </option>
                                </select>--%>
                                <asp:DropDownList name="Yachts" id="Yachts" runat="server" DataTextField="type" DataValueField="type"></asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">Comments:</td>
                            <td>
                                <%--<textarea name="textarea" id="textarea" cols="45" rows="5"></textarea></td>--%>
                            <asp:TextBox ID="Comments" runat="server" TextMode="MultiLine" cols="45" rows="5"></asp:TextBox>
                        </tr>
                        <tr>
                            <td class="from01td01">&nbsp;</td>
                            <td class="f_right">
                                <%--<cc1:RecaptchaApiScript ID="RecaptchaApiScript1" runat="server" />--%>
                                <cc1:RecaptchaWidget ID="Recaptcha1" runat="server" />
                                <asp:Label ID="lblMessage" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">&nbsp;</td>
                            <td class="f_right">
                                <asp:ImageButton ID="submitButton1" runat="server" ImageUrl='tayana/html/images/buttom03.gif' Height="25" Width="59" OnClick="submitButton1_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <!--表單-->

                <div class="box1">
                    <span class="span02">Contact with us</span><br />
                    Thanks for your enjoying our web site as an introduction to the Tayana world and our range of yachts.
As all the designs in our range are semi-custom built, we are glad to offer a personal service to all our potential customers. 
If you have any questions about our yachts or would like to take your interest a stage further, please feel free to contact us.
                </div>

                <div class="list03">
                    <p>
                        <span>TAYANA HEAD OFFICE</span><br />
                        NO.60 Haichien Rd. Chungmen Village Linyuan Kaohsiung Hsien 832 Taiwan R.O.C<br />
                        tel. +886(7)641 2422<br />
                        fax. +886(7)642 3193<br />
                        info@tayanaworld.com<br />
                    </p>
                </div>


                <div class="list03">
                    <p>
                        <span>SALES DEPT.</span><br />
                        +886(7)641 2422  ATTEN. Mr.Basil Lin<br />
                        <br />
                    </p>
                </div>

                <div class="box4">
                    <h4>Location</h4>
                    <p>
                        <iframe src="https://www.google.com/maps/embed?pb=!1m26!1m12!1m3!1d58961.369794352926!2d120.32160828178937!3d22.538465505859193!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!4m11!3e6!4m3!3m2!1d22.572609!2d120.35508019999999!4m5!1s0x3471e299c8cb4775%3A0x732765f73dab713!2zODMy6auY6ZuE5biC5p6X5ZyS5Y2A5Lit6ZaA6LevNjDomZ8!3m2!1d22.506150299999998!2d120.37019199999999!5e0!3m2!1szh-TW!2stw!4v1730636967520!5m2!1szh-TW!2stw"  width="695" height="518" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" ;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                    </p>

                </div>




                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>

        <!--------------------------------右邊選單結束---------------------------------------------------->
    </div>



</asp:Content>
