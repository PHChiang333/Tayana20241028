<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBack.Master" AutoEventWireup="true" CodeBehind="WebForm1yachtManage.aspx.cs" Inherits="WebApplicationTayana20241028.WebForm1yachtManage" %>

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
                                <li class="breadcrumb-item" aria-current="page">Yachts Management</li>
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
                            <h5>Yacht Management - select to edit or delete</h5>
                        </div>
                        <div class="card-header">
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <%--GV--%>
                                <asp:GridView ID="GridViewYachtList" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" DataKeyNames="YachtId" OnRowDeleting="GridViewYachtList_RowDeleting" OnSelectedIndexChanged="GridViewYachtList_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField SelectText="Select" ShowSelectButton="True"></asp:CommandField>
                                        <asp:BoundField DataField="YachtName" HeaderText="YachtName" SortExpression="YachtName"></asp:BoundField>
                                        <asp:BoundField DataField="YachtNameTag" HeaderText="YachtNameTag" SortExpression="YachtNameTag"></asp:BoundField>
                                        <asp:CheckBoxField DataField="IsPintop" HeaderText="IsPintop" SortExpression="IsPintop"></asp:CheckBoxField>
                                        <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" Text="Delete" CommandName="Delete" CausesValidation="False" ID="LinkButtonDeleteYacht" OnClientClick="return confirm('Are you sure you want to delete this?');"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                <%--GV--%>

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
                <div class="col-12">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>Yacht Management - Add yacht</h5>
                        </div>
                        <div class="card-header">
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <table class="table table-hover">
                                    <tbody>
                                        <tr class="unread">
                                            <td>
                                                <label class="form-label">New Yacht Model:</label>
                                                <asp:TextBox ID="TextBoxAddYachtName" runat="server" class="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="unread">
                                            <td>
                                                <asp:Button ID="ButtonAddYacht" runat="server" Text="To Add New Yacht" OnClick="ButtonAddYacht_Click" />
                                            </td>
                                        </tr>
                                        <%--                                        <tr class="unread">
                                            <td>
                                                <asp:Button ID="ButtonToCreateYacht" runat="server" Text="To create page" OnClick="ButtonToCreateYacht_Click" />
                                            </td>
                                        </tr>--%>
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
