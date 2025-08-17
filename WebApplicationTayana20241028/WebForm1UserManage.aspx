<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBack.Master" AutoEventWireup="true" CodeBehind="WebForm1UserManage.aspx.cs" Inherits="WebApplicationTayana20241028.WebForm1UserManage" EnableEventValidation="false" %>

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
                                <li class="breadcrumb-item" aria-current="page">User Management</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <!-- [ breadcrumb ] end -->
            <!-- [ Main Content ] start -->
            <div class="row">
                <!-- [ Recent Users ] start -->
                <div class="">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>User Management </h5>
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <table class="table table-hover">
                                    <tbody>
                                        <tr class="unread">
                                            <td>
                                                <label class="form-label">Account</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxAddAccount" runat="server" class="form-control"></asp:TextBox>
                                            </td>
                                            <td>
                                                <label class="form-label">Password</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxAddPassword" runat="server" class="form-control"></asp:TextBox>
                                            </td>
                                            <td class="col-2">
                                                <asp:Button ID="ButtonAddUser" runat="server" Text="Add" OnClick="ButtonAddUser_Click" CssClass="btn btn-secondary" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <asp:Label ID="LabelAdd" runat="server" Text="帳號重複" Visible="false"></asp:Label>
                            </div>
                        </div>



                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <asp:GridView ID="GridViewUserList" runat="server" AutoGenerateColumns="False" CssClass="table text-center"  OnDataBound="GridViewUserList_DataBound" OnRowDeleting="GridViewUserList_RowDeleting" DataKeyNames="UserId">
                                    <Columns>
<%--                                        <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                                            <EditItemTemplate>
                                                <asp:Button runat="server" Text="更新" CommandName="Update" CausesValidation="True" ID="Button1"></asp:Button>&nbsp;<asp:Button runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="False" ID="Button2" CssClass="btn btn-primary"></asp:Button>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Button runat="server" Text="Edit" CommandName="Edit" CausesValidation="False" ID="Button1" CssClass="btn btn-primary"></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:BoundField DataField="account" HeaderText="account" SortExpression="account"></asp:BoundField>
                                        <%--<asp:BoundField DataField="password" HeaderText="password" SortExpression="password"></asp:BoundField>--%>
                                        <%--<asp:BoundField DataField="email" HeaderText="email" SortExpression="email"></asp:BoundField>--%>
                                        <%--<asp:BoundField DataField="name" HeaderText="name" SortExpression="name"></asp:BoundField>--%>
                                        <%--<asp:BoundField DataField="initDate" HeaderText="initDate" SortExpression="initDate"></asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:Button runat="server" Text="刪除" CommandName="Delete" CausesValidation="False" ID="Button2" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete this?');"></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                <%--<asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:tayanaConnectionString %>' SelectCommand="SELECT [account], [password], [email], [name], [initDate] FROM [managerData]"></asp:SqlDataSource>--%>
                            </div>
                        </div>

                    </div>
                </div>
                <!-- [ Recent Users ] end -->

            </div>
        </div>
    </div>
</asp:Content>
