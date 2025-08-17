<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1UserLogin.aspx.cs" Inherits="WebApplicationTayana20241028.WebForm1UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <!-- [Favicon] icon -->
    <link rel="icon" href="datta-able-bootstrap-dashboard/dist/assets/images/favicon.svg" type="image/x-icon">
    <!-- [Font] Family -->
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans:wght@300;400;500;600&display=swap" rel="stylesheet">
    <!-- [Tabler Icons] https://tablericons.com -->
    <link rel="stylesheet" href="datta-able-bootstrap-dashboard/dist/assets/fonts/tabler-icons.min.css">
    <!-- [Feather Icons] https://feathericons.com -->
    <link rel="stylesheet" href="datta-able-bootstrap-dashboard/dist/assets/fonts/feather.css">
    <!-- [Font Awesome Icons] https://fontawesome.com/icons -->
    <link rel="stylesheet" href="datta-able-bootstrap-dashboard/dist/assets/fonts/fontawesome.css">
    <!-- [Material Icons] https://fonts.google.com/icons -->
    <link rel="stylesheet" href="datta-able-bootstrap-dashboard/dist/assets/fonts/material.css">
    <!-- [Template CSS Files] -->
    <%--<link rel="stylesheet" href="../assets/css/style.css" id="main-style-link" >--%>
    <link rel="stylesheet" href="datta-able-bootstrap-dashboard/dist/assets/css/style.css" id="mainstylelink">
    <link rel="stylesheet" href="datta-able-bootstrap-dashboard/dist/assets/css/style-preset.css">
    <!-- Google tag (gtag.js) -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=G-14K1GBX9FG"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() {
            dataLayer.push(arguments);
        }
        gtag('js', new Date());

        gtag('config', 'G-14K1GBX9FG');
    </script>
    <!-- WiserNotify -->
    <script>
        !(function () {
            if (window.t4hto4) console.log('WiserNotify pixel installed multiple time in this page');
            else {
                window.t4hto4 = !0;
                var t = document,
                    e = window,
                    n = function () {
                        var e = t.createElement('script');
                        (e.type = 'text/javascript'),
                            (e.async = !0),
                            (e.src = 'https://pt.wisernotify.com/pixel.js?ti=1jclj6jkfc4hhry'),
                            document.body.appendChild(e);
                    };
                'complete' === t.readyState ? n() : window.attachEvent ? e.attachEvent('onload', n) : e.addEventListener('load', n, !1);
            }
        })();
    </script>
    <!-- Microsoft clarity -->
    <script type="text/javascript">
        (function (c, l, a, r, i, t, y) {
            c[a] =
                c[a] ||
                function () {
                    (c[a].q = c[a].q || []).push(arguments);
                };
            t = l.createElement(r);
            t.async = 1;
            t.src = 'https://www.clarity.ms/tag/' + i;
            y = l.getElementsByTagName(r)[0];
            y.parentNode.insertBefore(t, y);
        })(window, document, 'clarity', 'script', 'gkn6wuhrtb');
    </script>




</head>
<body data-pc-preset="preset-1" data-pc-sidebar-caption="true" data-pc-direction="ltr" data-pc-theme="light">
    <form id="form1" runat="server">




        <!-- [ Pre-loader ] start -->
        <div class="loader-bg">
            <div class="loader-track">
                <div class="loader-fill"></div>
            </div>
        </div>
        <!-- [ Pre-loader ] End -->

        <div class="auth-main">
            <div class="auth-wrapper v1">
                <div class="auth-form">
                    <div class="position-relative my-5">
                        <div class="auth-bg">
                            <span class="r"></span>
                            <span class="r s"></span>
                            <span class="r s"></span>
                            <span class="r"></span>
                        </div>
                        <div class="card mb-0">

                            <div class="card-body">
                                <div class="text-center">
                                    <a href="#">
                                        <%--<img src="datta-able-bootstrap-dashboard/dist/assets/images/logo-dark.svg" alt="img">--%>
                                    </a>
                                </div>
                                <h4 class="text-center f-w-500 mt-4 mb-3">Login</h4>
                                <div class="form-group mb-3">
                                    <asp:TextBox ID="TextBoxUserName" CssClass="form-control" runat="server" Text="" placeholder="Username"></asp:TextBox>
                                </div>
                                <div class="form-group mb-3">
                                    <asp:TextBox ID="TextBoxUserPassword" CssClass="form-control" runat="server" Text="" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="d-flex mt-1 justify-content-between align-items-center">
                                    <div class="form-check">
                                    </div>
                                </div>
                                <div class="text-center mt-4">
                                    <asp:Button ID="ButtonLogin" CssClass="btn btn-primary shadow px-sm-4" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
                                </div>
                                <div class="d-flex justify-content-between align-items-end mt-4">
                                    <h6 class="f-w-500 mb-0">Don't have an Account? </h6>
                                    <a href="WebForm1UserRegister.aspx" class="link-primary">Create Account</a>
                                </div>
                                <%--測試用 start--%>
                                <div class="text-center mt-4">
                                    <asp:Label ID="LabelAlert" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                                <%--測試用 end--%>


                                <div class="text-center mt-4">
                                    <div>
                                        <a href="WebForm1Index.aspx">To Home</a>
                                    </div>
                                    <div>
                                        <a href="WebForm1UserLogin.aspx">To Login</a>
                                    </div>
                                    <div>
                                        <a href="WebForm1UserRegister.aspx">To Register</a>
                                    </div>
                                </div>


                            </div>



                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ Main Content ] end -->



        <!-- Required Js -->
        <script src="datta-able-bootstrap-dashboard/dist/assets/js/plugins/popper.min.js"></script>
        <script src="datta-able-bootstrap-dashboard/dist/assets/js/plugins/simplebar.min.js"></script>
        <script src="datta-able-bootstrap-dashboard/dist/assets/js/plugins/bootstrap.min.js"></script>
        <script src="datta-able-bootstrap-dashboard/dist/assets/js/fonts/custom-font.js"></script>
        <script src="datta-able-bootstrap-dashboard/dist/assets/js/pcoded.js"></script>
        <script src="datta-able-bootstrap-dashboard/dist/assets/js/plugins/feather.min.js"></script>

        <script>layout_change('light');</script>
        <script>change_box_container('false');</script>
        <script>layout_caption_change('true');</script>
        <script>layout_rtl_change('false');</script>
        <script>preset_change("preset-1");</script>
        <script>layout_theme_sidebar_change('false');</script>
































    </form>
</body>
</html>
