<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBack.Master" AutoEventWireup="true" CodeBehind="WebForm1NewsManage.aspx.cs" Inherits="WebApplicationTayana20241028.WebForm1NewsManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- [ Main Content ] start -->
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
                                <li class="breadcrumb-item" aria-current="page">News Management</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <!-- [ breadcrumb ] end -->

            <!-- [ Main Content01 ] start -->
            <div class="row">
                <!-- [ Recent Users ] start -->
                <div class="col-12">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>News Management - select to edit or delete</h5>
                        </div>
                        <div class="card-header">
                            <p>Select the News to Edit (Including Images and Files)</p>
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <asp:GridView ID="GridViewNewsList" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" DataKeyNames="NewsId" OnSelectedIndexChanged="GridViewNewsList_SelectedIndexChanged" OnRowDeleting="GridViewNewsList_RowDeleting">

                                    <columns>
                                        <%--<asp:BoundField DataField="NewsId" HeaderText="NewsId" ReadOnly="True" InsertVisible="False" SortExpression="NewsId"></asp:BoundField>--%>
                                        <asp:CommandField ShowSelectButton="True" SelectText="Select"></asp:CommandField>
                                        <asp:BoundField DataField="NewsTilte" HeaderText="NewsTilte" SortExpression="NewsTilte"></asp:BoundField>
                                        <asp:BoundField DataField="NewsSummary" HeaderText="NewsSummary" SortExpression="NewsSummary"></asp:BoundField>

                                        <%--<asp:BoundField DataField="NewsId" HeaderText="NewsId" ReadOnly="True" InsertVisible="False" SortExpression="NewsId"></asp:BoundField>--%>
                                        <%--<asp:BoundField DataField="NewsContent" HeaderText="NewsContent" SortExpression="NewsContent"></asp:BoundField>--%>
                                        <asp:BoundField DataField="NewsDate" HeaderText="NewsDate" SortExpression="NewsDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false"></asp:BoundField>
                                        <%--                                        <asp:BoundField DataField="CreatedTime" HeaderText="CreatedTime" SortExpression="CreatedTime"></asp:BoundField>--%>
                                        <asp:CheckBoxField DataField="IsPintop" HeaderText="IsPintop" SortExpression="IsPintop"></asp:CheckBoxField>
                                        <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                                            <itemtemplate>
                                                <asp:LinkButton runat="server" Text="Delete" CommandName="Delete" CausesValidation="False" ID="LinkButtonNewsDelete" OnClientClick="return confirm('Are you sure you want to delete this?');"></asp:LinkButton>
                                            </itemtemplate>
                                        </asp:TemplateField>

                                    </columns>
                                </asp:GridView>
                                <%--<asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:tayanaConnectionString %>' SelectCommand="SELECT * FROM [News]"></asp:SqlDataSource>--%>
                            </div>

                        </div>
                    </div>
                </div>
                <!-- [ Recent Users ] end -->

            </div>
            <!-- [ Main Content01 ] end -->

            <!-- [ Main Content02 ] start -->
            <div class="row">
                <!-- [ Recent Users ] start -->
                <div class="">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>News Management - Add</h5>
                        </div>
                        <div class="card-header">
                            <p>1. Create a News </p>
                            <p>2. If you want to add Images or Files, select and edit the news after the news created.</p>
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <table class="table table-hover">
                                    <tbody>
                                        <tr class="unread">
                                            <td>
                                                <asp:Button ID="ButtonToCreateNews" runat="server" Text="To create page" OnClick="ButtonToCreateNews_Click" />
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
            <!-- [ Main Content02 ] end -->



        </div>

    </div>
    <!-- [ Main Content ] end -->


</asp:Content>
