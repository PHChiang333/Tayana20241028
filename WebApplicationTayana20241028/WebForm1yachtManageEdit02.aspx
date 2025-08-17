   <%@ Page Title="" Language="C#" MasterPageFile="~/SiteBack.Master" AutoEventWireup="true" CodeBehind="WebForm1yachtManageEdit02.aspx.cs" Inherits="WebApplicationTayana20241028.WebForm1yachtManageEdit02" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="pc-container">
        <div class="pc-content">
            <!-- [ breadcrumb ] start -->
            <div class="page-header">
                <div class="page-block">
                    <div class="row align-items-center">
                        <div class="col-md-12">
                            <div class="page-header-title">
                                <h5 class="mb-0">Home</h5>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <ul class="breadcrumb mb-0">
                                <li class="breadcrumb-item"><a href="WebForm1BackIndex.aspx">Home</a></li>
                                <li class="breadcrumb-item"><a href="WebForm1yachtManage.aspx">Yachts Management</a></li>
                                <li class="breadcrumb-item" aria-current="page">Yachts Management - Layouts</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <!-- [ breadcrumb ] end -->
            <!-- [ Main Content ] start -->
            <div class="row">
                <!-- [ Recent Users ] start -->
                <div class="col-xl-8 col-md-6">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>Yacht Edit Table</h5>
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <table class="table table-hover">
                                    <tbody>
                                        <tr class="unread">
                                            <td>
                                                <label class="form-label">Yacht Model</label>
                                                <asp:TextBox ID="TextBoxEditYachtName" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>


                                        <tr class="unread">
                                            <td>
                                                <label class="form-label">layout & deck plan</label>
                                            </td>
                                        </tr>
                                        <tr class="unread">
                                            <td>
                                                <p>
                                                    Please upload layout & deck plan images.
                                                </p>
                                            </td>

                                        </tr>

                                        <%--圖片區(layout & deck plan) start--%>
                                        <tr class="unread">

                                            <td>
                                                <p>請上傳圖片  (上傳僅接受.jpg 且<1MB)</p>
                                                <asp:FileUpload ID="FileUploadImg" runat="server" AllowMultiple="true" />
                                                <asp:Button ID="ButtonUploadImage" runat="server" Text="Upload Image" OnClick="ButtonUploadImage_Click" />
                                            </td>


                                        </tr>
                                        <asp:Repeater ID="RepeaterMultilImg" runat="server" OnItemCommand="RepeaterMultilImg_ItemCommand">
                                            <ItemTemplate>
                                                <tr class="unread">
                                                    <td>
                                                        <asp:Image ID="ImageRepeater" runat="server" ImageUrl='<%# Eval("YachtLayoutImgPath") %>' Style="width: 150px; height: 100px;" />
                                                        </t>
                                                    <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("YachtLayoutImgId") %>' Text="刪除" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <%--圖片區(layout & deck plan) end--%>

                                        <tr class="unread">
                                            <td>
                                                <asp:Button ID="ButtonToSaveNNextStep" runat="server" Text="Click to Next Step" OnClick="ButtonToSaveNNextStep_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- [ Recent Users ] end -->




            </div>
        </div>
    </div>






</asp:Content>
