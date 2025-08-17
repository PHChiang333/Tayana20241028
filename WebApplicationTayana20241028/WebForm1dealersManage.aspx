<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBack.Master" AutoEventWireup="true" CodeBehind="WebForm1dealersManage.aspx.cs" Inherits="WebApplicationTayana20241028.WebForm1dealersManage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


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
                                <li class="breadcrumb-item"><a href="../dashboard/index.html">Home</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0)">Dashboard</a></li>
                                <li class="breadcrumb-item" aria-current="page">Home</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <!-- [ breadcrumb ] end -->

            <!-- [ Main Content ] start -->
            <div class="row">
                <!-- [ Recent Users ] start -->
                <div class="card-body">
                    <div class="col-12 ">
                        <h5>Dealers Management</h5>
                    </div>
                    <div class="col-12">
                        <div class="card Recent-Users">
                            <div class="card-header">
                                <h5>Country Management</h5>

                            </div>
                            <div class="card-body px-0 py-3 col-4">
                                <div class="table-responsive">
                                    <div class="card-header">
                                        <h5>Add Country</h5>
                                    </div>
                                    <table class="table table-hover">
                                        <tbody>
                                            <tr class="unread">
                                                <td>
                                                    <label class="form-label">Country</label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxAddCountry" runat="server" class="form-control"></asp:TextBox>
                                                </td>
                                                <td class="col-2">
                                                    <asp:Button ID="ButtonAddCountry" runat="server" Text="Add" OnClick="ButtonAddCountry_Click" CssClass="btn btn-secondary" />
                                                </td>

                                        </tbody>
                                    </table>
                                    <div class="card-header" style="color: red;">
                                        <asp:Label ID="LabelAddCountryAlert" runat="server" Text="" Visible="false"></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="card-body px-0 py-3 col-8">
                                <div class="table-responsive">
                                    <asp:GridView ID="GridViewCountry" runat="server" AutoGenerateColumns="False" CssClass="table text-center" DataKeyNames="country_ID" OnRowCancelingEdit="GridViewCountry_RowCancelingEdit" OnRowDeleting="GridViewCountry_RowDeleting" OnRowEditing="GridViewCountry_RowEditing" OnRowUpdating="GridViewCountry_RowUpdating">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                                                <EditItemTemplate>
                                                    <asp:LinkButton runat="server" Text="Update" CommandName="Update" CausesValidation="True" ID="LinkButtonCountryUpdate" CssClass="btn btn-primary"></asp:LinkButton>
                                                    <asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="False" ID="LinkButtonCountryCancel" CssClass="btn btn-primary"></asp:LinkButton>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" Text="Edit" CommandName="Edit" CausesValidation="False" ID="LinkButtonCountryEdit" CssClass="btn btn-primary"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="countrySort" SortExpression="countrySort">
                                                <EditItemTemplate>
                                                    <asp:TextBox runat="server" Text='<%# Bind("countrySort") %>' ID="TextBoxEditCountrySort"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%# Bind("countrySort") %>' ID="LabelCountrySort"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" Text="Delete" CommandName="Delete" CausesValidation="False" ID="LinkButtonCountryDelete" CssClass="btn btn-danger" OnClientClick="return confirm('確定要刪除嗎？');"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>



                        </div>
                    </div>
                </div>

                <!-- [ Recent Users ] end -->
                <div class="col-12">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>Dealer Management</h5>
                            <asp:Button ID="Button1" runat="server" Text="click here to edit" CssClass="btn btn-primary" OnClick="Button1_Click" />

                        </div>
                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                            我是panel

                            <div class="table-responsive">
                                <table class="table table-hover">
                                    <tbody>
                                        <tr class="unread">
                                            <td>
                                                <label class="form-label">Select Country</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="countrySort" DataValueField="countrySort" AutoPostBack="True"></asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:tayanaConnectionString %>' SelectCommand="SELECT DISTINCT [countrySort] FROM [CountrySort]"></asp:SqlDataSource>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </asp:Panel>











                    </div>
                </div>
            </div>
        </div>



    </div>








</asp:Content>
