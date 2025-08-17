<%--<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBack.Master" AutoEventWireup="true" CodeBehind="WebForm1dealersManageV2.aspx.cs" Inherits="WebApplicationTayana20241028.Properties.WebForm1dealersManageV2" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBack.Master" AutoEventWireup="true" CodeBehind="WebForm1dealersManageV2.aspx.cs" Inherits="WebApplicationTayana20241028.Properties.WebForm1dealersManageV2" MaintainScrollPositionOnPostback="true" %>

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
                                <li class="breadcrumb-item" aria-current="page">Dealers Management</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <!-- [ breadcrumb ] end -->
            <!-- [ Main Content01 ] start -->
            <div class="row">
                <!-- [ Recent Users ] start -->
                <div class="col-xl-4 col-md-6">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>Country Management - Add</h5>
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <table class="table table-hover">
                                    <tbody>
                                        <%--第一欄--%>
                                        <tr class="unread">
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Label">Add Country</asp:Label>
                                                <asp:TextBox ID="TextBoxAddCountry" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="ButtonAddCountry" runat="server" Text="Add" OnClick="ButtonAddCountry_Click" /></td>
                                        </tr>
                                        <%--第一欄end--%>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- [ Recent Users ] end -->


                <!-- [ Recent Users ] start -->
                <div class="col-xl-8 col-md-6">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>Country Management - Update & Delete</h5>
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" DataKeyNames="country_ID" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" OnRowDeleted="GridView1_DeltedCountry" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" OnRowUpdated="GridView1_RowUpdated">
                                    <Columns>
                                        <asp:CommandField CancelText="Cancel" DeleteText="Delete" EditText="Edit" InsertText="Insert" NewText="New" SelectText="Select" ShowEditButton="True" UpdateText="Update" ButtonType="Button">
                                            <ControlStyle BorderColor="#66CCFF" BorderWidth="1px" BorderStyle="Solid" CssClass="btn btn-primary btn-block" ForeColor="White"></ControlStyle>
                                        </asp:CommandField>
                                        <asp:BoundField DataField="country_ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="country_ID">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="countrySort" HeaderText="Country Name" SortExpression="countrySort"></asp:BoundField>
                                        <asp:BoundField DataField="initDate" HeaderText="Creation Date" SortExpression="initDate" InsertVisible="False" ReadOnly="True"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Delete" ShowHeader="False" ControlStyle-BorderColor="#66CCFF" ControlStyle-BorderStyle="Solid" ControlStyle-BorderWidth="1px" ControlStyle-CssClass="btn btn-danger btn-block" FooterStyle-ForeColor="White">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" Text="Delete" CommandName="Delete" CausesValidation="False" ID="BtnDeleteCountry" OnClientClick="return confirm('Are you sure you want to delete？')"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>

                                <asp:SqlDataSource runat="server" ID="SqlDataSource1"
                                    ConnectionString='<%$ ConnectionStrings:tayanaConnectionString %>'
                                    SelectCommand="SELECT * FROM [CountrySort]"
                                    DeleteCommand="DELETE FROM [CountrySort] WHERE [country_ID] = @country_ID"
                                    UpdateCommand="UPDATE [CountrySort] SET [countrySort] = @countrySort WHERE [country_ID] = @country_ID">
                                    <DeleteParameters>
                                        <asp:Parameter Name="@country_ID" Type="Int32"></asp:Parameter>
                                    </DeleteParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="countrySort" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="@country_ID" Type="Int32"></asp:Parameter>
                                    </UpdateParameters>
                                </asp:SqlDataSource>
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
                <div class="col-xl-4 col-md-6">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>Select Area</h5>
                            <p>(*only one dealer in a area)</p>
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <table class="table table-hover">
                                    <tbody>
                                        <tr class="unread">
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="Label">Select Country to choose area</asp:Label>
                                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="countrySort" DataValueField="country_ID" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:tayanaConnectionString %>' SelectCommand="SELECT * FROM [CountrySort]"></asp:SqlDataSource>
                                            </td>
                                        </tr>
                                        <tr class="unread">
                                            <td>
                                                <asp:RadioButtonList ID="RadioButtonListArea" runat="server" OnSelectedIndexChanged="RadioButtonListArea_SelectedIndexChanged" AutoPostBack="True"></asp:RadioButtonList>
                                                <asp:Button ID="BtnDelArea" runat="server" Text="Delete Area" OnClick="BtnDelArea_Click" OnClientClick="return confirm('Are you sure you want to delete？')"/>
                                            </td>
                                        </tr>
                                        <tr class="unread">
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text="Label">Add Area (If choosen area doesn't exists)</asp:Label>
                                                <asp:TextBox ID="TextBoxAddArea" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="Button2" runat="server" Text="Add" OnClick="BtnAddArea_Click" />
                                                <asp:Literal ID="LiteralBtnAddAreaAlert" runat="server" Visible="false"></asp:Literal>
                                            </td>
                                        </tr>

                                    </tbody>
                                </table>
                                <table class="table table-hover">
                                    <tbody>
                                        <tr class="unread"><td><asp:Label ID="Label5" runat="server" Text="Label">Please select dealer to Edit (Dealer date would input after select dealer)</asp:Label></td></tr>
                                        <tr class="unread">
                                            <td>
                                                <asp:RadioButtonList ID="RadioButtonListSelAreaDealer" runat="server" OnSelectedIndexChanged="RadioButtonListSelAreaDealer_SelectedIndexChanged" AutoPostBack="True" DataSourceID="SqlDataSource4" DataTextField="name" DataValueField="DealerId"></asp:RadioButtonList>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString='<%$ ConnectionStrings:tayanaConnectionString %>' SelectCommand="SELECT * FROM [Dealers] WHERE ([area] = @area)">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="RadioButtonListArea" PropertyName="SelectedValue" Name="area" Type="String"></asp:ControlParameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                                <asp:Button ID="ButtonDeleteDealer" runat="server" Text="Delete Selected Dealer" CssClass="btn btn-danger" OnClick="ButtonDeleteDealer_Click" OnClientClick="return confirm('Are you sure you want to delete dealer data？')" Visible="false" />
                                                <asp:Literal ID="LiteralButtonDeleteDealerStatus" runat="server" Text="Delete status" Visible="false"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr class="unread">
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text="Label">Add Dealer (If choosen area doesn't exists)</asp:Label>
                                                <asp:TextBox ID="TextBoxAddDealer" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="BtnAddDealer" runat="server" Text="Add" OnClick="BtnAddDealer_Click"/>
                                                <asp:Literal ID="LiteralBtnAddDealerStatus" runat="server" Visible="false"></asp:Literal>
                                            </td>
                                        </tr>

                                    </tbody>
                                </table>

                            </div>
                        </div>
                    </div>
                </div>
                <!-- [ Recent Users ] end -->


                <!-- [ Recent Users ] start -->
                <div class="col-xl-8 col-md-6">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>Dealer Management </h5>
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <table class="table table-hover">

                                    <thead>
                                        <tr>
                                            <th class="w-25">Item</th>
                                            <th class="w-75">Value</th>
                                        </tr>
                                    </thead>


                                    <tbody>

                                        <tr class="unread bg-info-subtle">
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="Label" CssClass="text-start">Thumbnail</asp:Label>
                                            </td>
                                            <td>
                                                <%--                                                <asp:Image ID="ImageThumbnail" runat="server" Height="100" ImageUrl="~/tayana/html/images/portrait-00.jpg" ImageAlign="Middle" Width="100" />--%>
                                                <asp:Literal ID="LiteralImg" runat="server"></asp:Literal>
                                            </td>
                                        </tr>

                                        <tr class="unread bg-info-subtle">
                                            <td>
                                                <asp:FileUpload ID="FileUpload1" runat="server" Font-Names="Choose File" CssClass="" placeholder="No File Choosen" />
                                            </td>
                                            <td>
                                                <asp:Button ID="ButtonUploadImage" runat="server" Text="Upload Image" OnClick="ButtonUploadImage_Click" />
                                                <asp:Label ID="LabUploadImg" runat="server" Text="" Visible="false"></asp:Label>
                                            </td>
                                        </tr>

                                        <%--                                        <tr class="unread">
            <td>
                <p>Item</p>
            </td>
            <td>
                <p>Value</p>
            </td>
        </tr>--%>

                                        <tr>
                                            <td>
                                                <p>Country</p>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDealerUpdateCountry" runat="server" ReadOnly="true" class="text-dark border-light-subtle bg-light-subtle"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <p>Area</p>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDealerUpdateArea" runat="server" ReadOnly="true" class="text-dark border-light-subtle bg-light-subtle"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <p>Image</p>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDealerUpdateImage" runat="server" ReadOnly="true" class="text-dark border-light-subtle bg-light-subtle"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="bg-info-subtle">
                                            <td>
                                                <p>Name</p>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDealerUpdateName" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="bg-info-subtle">
                                            <td>
                                                <p>Contact</p>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDealerUpdateContact" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="bg-info-subtle">
                                            <td>
                                                <p>Address</p>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDealerUpdateAddress" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="bg-info-subtle">
                                            <td>
                                                <p>Tel</p>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDealerUpdateTel" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="bg-info-subtle">
                                            <td>
                                                <p>Fax</p>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDealerUpdateFax" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="bg-info-subtle">
                                            <td>
                                                <p>Email</p>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDealerUpdateEmail" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="bg-info-subtle">
                                            <td>
                                                <p>Link</p>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDealerUpdateLink" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="">
                                            <td>
                                                <p>Creation Time</p>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDealerUpdateInitDate" runat="server" ReadOnly="true" class="text-dark border-light-subtle bg-light-subtle"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="">
                                            <td>
                                                <p>Click for Update</p>
                                            </td>
                                            <td>
                                                <asp:Button ID="ButtonUpdateDelear" runat="server" Text="Update Dealer details" CssClass="btn btn-primary" OnClick="ButtonUpdateDelear_Click" />
                                                <asp:Literal ID="UpdateDealerListLab" runat="server" Text="Update status" Visible="false"></asp:Literal>

                                            </td>
                                        </tr>
<%--                                        <tr class="">
                                            <td>
                                                <p>Click for DELETE</p>
                                            </td>
                                            <td>
                                                <asp:Button ID="ButtonDelDelear" runat="server" Text="DELETE Dealer details" CssClass="btn btn-primary" OnClick="ButtonDelDelear_Click" OnClientClick="return confirm('Are you sure you want to delete？')" />
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

            <!-- [ Main Content03 ] start -->
<%--            <div class="row">
                <!-- [ Recent Users ] start -->
                <div class="col-xl-4 col-md-6">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>Dealers Management - Update</h5>
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                            </div>
                        </div>
                    </div>
                </div>--%>
                <!-- [ Recent Users ] end -->




            </div>
            <!-- [ Main Content03 ] end -->
            <!-- [ Main Content04 ] start -->
<%--            <div class="row">
                <!-- [ Recent Users ] start -->
                <div class="col-xl-12 col-md-6">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>Dealer Management - Delete</h5>
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <asp:GridView ID="GridViewDealerSelArea" runat="server" AutoGenerateColumns="False" DataKeyNames="DealerId" DataSourceID="SqlDataSource3">
                                    <Columns>
                                        <asp:BoundField DataField="DealerId" HeaderText="DealerId" ReadOnly="True" InsertVisible="False" SortExpression="DealerId"></asp:BoundField>
                                        <asp:BoundField DataField="country_ID" HeaderText="country_ID" SortExpression="country_ID"></asp:BoundField>
                                        <asp:BoundField DataField="area" HeaderText="area" SortExpression="area"></asp:BoundField>
                                        <asp:BoundField DataField="dealerImgPath" HeaderText="dealerImgPath" SortExpression="dealerImgPath"></asp:BoundField>
                                        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name"></asp:BoundField>
                                        <asp:BoundField DataField="contact" HeaderText="contact" SortExpression="contact"></asp:BoundField>
                                        <asp:BoundField DataField="address" HeaderText="address" SortExpression="address"></asp:BoundField>
                                        <asp:BoundField DataField="tel" HeaderText="tel" SortExpression="tel"></asp:BoundField>
                                        <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax"></asp:BoundField>
                                        <asp:BoundField DataField="Cell" HeaderText="Cell" SortExpression="Cell"></asp:BoundField>
                                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email"></asp:BoundField>
                                        <asp:BoundField DataField="link" HeaderText="link" SortExpression="link"></asp:BoundField>
                                        <asp:BoundField DataField="initDate" HeaderText="initDate" SortExpression="initDate"></asp:BoundField>
                                        <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                                    </Columns>
                                </asp:GridView>

                                <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:tayanaConnectionString %>' SelectCommand="SELECT * FROM [Dealers] WHERE ([area] = @area)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="RadioButtonListArea" PropertyName="SelectedValue" Name="area" Type="String"></asp:ControlParameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- [ Recent Users ] end -->--%>

            </div>



        </div>
    </div>
    <!-- [ Main Content ] end -->



</asp:Content>
