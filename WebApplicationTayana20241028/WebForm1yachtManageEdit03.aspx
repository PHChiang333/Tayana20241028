<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBack.Master" AutoEventWireup="true" CodeBehind="WebForm1yachtManageEdit03.aspx.cs" Inherits="WebApplicationTayana20241028.WebForm1yachtManageEdit03" %>

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
                                <li class="breadcrumb-item" aria-current="page">Yachts Management - Spec List</li>
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
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- [ Recent Users ] end -->
            </div>
            <!-- [ Main Content ] end -->


            <!-- [ Main Content01 ] start -->
            <div class="row">
                <!-- [ Recent Users ] start -->
                <div class="col-12">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>Specification Management - select to edit or delete</h5>
                        </div>
                        <div class="card-header">
                            <p>Select the Spec to Edit</p>
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <asp:GridView ID="GridViewSpecList" runat="server"  AutoGenerateColumns="False" DataKeyNames="YachtSpecId" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="table table-hover">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" SelectText="select"></asp:CommandField>
                                        <%--                                        <asp:BoundField DataField="YachtSpecId" HeaderText="YachtSpecId" ReadOnly="True" InsertVisible="False" SortExpression="YachtSpecId"></asp:BoundField>--%>
                                        <%--<asp:BoundField DataField="YachtId" HeaderText="YachtId" SortExpression="YachtId"></asp:BoundField>--%>
                                        <asp:BoundField DataField="specTitle" HeaderText="specTitle" SortExpression="specTitle"></asp:BoundField>
                                        <%--<asp:BoundField DataField="specContent" HeaderText="specContent" SortExpression="specContent"></asp:BoundField>--%>
                                        <%--<asp:BoundField DataField="CreatedTime" HeaderText="CreatedTime" SortExpression="CreatedTime"></asp:BoundField>--%><asp:TemplateField HeaderText="delete" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" Text="delete" CommandName="Delete" CausesValidation="False" ID="LinkButton1"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>

<%--                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:tayanaConnectionString %>' SelectCommand="SELECT * FROM [yachtSpec]"></asp:SqlDataSource>--%>
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
                <div class="col-xl-8 col-md-6">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>Spec Management - Add</h5>
                        </div>
                        <div class="card-header">
                            <p>1. Create a Spec </p>
                            <p>2. If you want to edit Spec content, select and edit the Spec after it created.</p>
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <table class="table table-hover">
                                    <tbody>
                                        <tr class="unread">
                                            <td>
                                                <p>New Spec:</p>
                                                <asp:TextBox ID="TextBoxAddSpec" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="ButtonToCreateSpec" runat="server" Text="Create Spec" OnClick="ButtonToCreateSpec_Click" />
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





</asp:Content>
