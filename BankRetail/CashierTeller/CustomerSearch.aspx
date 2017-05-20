<%@ Page Title="" Language="C#" MasterPageFile="~/Cashier.Master" AutoEventWireup="true" CodeBehind="CustomerSearch.aspx.cs" Inherits="BankRetail.CashierTeller.Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="row" id="searchCustomerForm" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">

                <h2 class="jumboText"><b>Search Customer</b> </h2>
                <div class="jumbotron customJumbo">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Height="23px" Width="243px">
                        <asp:ListItem Value="SSN" Text="SSN" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="ID" Text="Customer ID" Selected="False"></asp:ListItem>
                    </asp:RadioButtonList>

                    <div class="form-group" id="ssnID">
                        <asp:Label Font-Bold="true" runat="server" ID="SSN_CustomerIDlabel" Text="SSN&nbsp;/&nbsp;Customer ID"></asp:Label>
                        <asp:TextBox ID="SSN_CustomerIDText" runat="server" CssClass="form-control" placeholder="SSN&nbsp;/&nbsp;Customer ID"></asp:TextBox>
                        <asp:RequiredFieldValidator
                                CssClass="validationError"
                                runat="server"
                                ID="SSNRequiredCheck"
                                ForeColor="Red"
                                ControlToValidate="SSN_CustomerIDText"
                                ErrorMessage="Please enter SSN or Customer ID." Font-Size="11px" />
                        <asp:RegularExpressionValidator
                                ID="SSNSizeCheck"
                                ForeColor="Red"
                                runat="server"
                                ErrorMessage="Should be 9 digit numeric."
                                ControlToValidate="SSN_CustomerIDText"
                                CssClass="validationError"
                                ValidationExpression="^[0-9]{9}$" Font-Size="11px" />
                        <asp:RangeValidator
                                ID="RangeValidator1"
                                runat="server"
                                ErrorMessage="Should be 9 digit numeric."
                                ControlToValidate="SSN_CustomerIDText"
                                ForeColor="Red"
                                MinimumValue="100000000" MaximumValue="999999999"
                                Type="Integer"></asp:RangeValidator>
                    </div>

                    <asp:Button ID="search" runat="server" Text="Search" class="btn btn-info form-control" OnClick="search_Click" />
                </div>
            </div>
        </div>

        <%-- Customer Found --%>
        <div id="customerFound" runat="server">

            <div class="row">
                <div class="col-md-1 col-lg-1 hidden-sm hidden-xs"></div>
                <div class="col-md-6 col-lg-6 hidden-sm hidden-xs">
                    <h2 class="jumboText"><b>Customer Details</b> </h2>
                    <div class="jumbotron customJumbo">
                        <div class="form-group formGroupCustom">

                            <div class="form-group">
                                <asp:Label ID="CustomerSSNLabel" Font-Bold="true" CssClass="col-md-5 col-lg-5" runat="server" Text="SSN: "></asp:Label>
                                <asp:Label ID="CustomerSSNText" runat="server" CssClass="col-md-7 col-lg-7" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="CustomerIDLabel" Font-Bold="true" CssClass="col-md-5 col-lg-5" runat="server" Text="Customer ID: "></asp:Label>
                                <asp:Label ID="CustomerIDText" runat="server" CssClass="col-md-7 col-lg-7" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="CustomerNameLabel" Font-Bold="true" CssClass="col-md-5 col-lg-5" runat="server" Text="Customer Name: "></asp:Label>
                                <asp:Label ID="customerNameText" runat="server" CssClass="col-md-7 col-lg-7" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="customerAgeLabel" Font-Bold="true" CssClass="col-md-5 col-lg-5" runat="server" Text="Customer Age: "></asp:Label>
                                <asp:Label ID="customerAgetext" runat="server" CssClass="col-md-7 col-lg-7" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="customerAddressLable" Font-Bold="true" CssClass="col-md-5 col-lg-5" runat="server" Text="Customer Address: "></asp:Label>
                                <asp:Label ID="cutomerAddressText" runat="server" CssClass="col-md-7 col-lg-7" Text=""></asp:Label>
                            </div>

                        </div>


                        <div class="form-group">
                            <asp:GridView ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Account Number">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("AccNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Account Type">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("AccType") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Balance">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Balance") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Deposit">
                                        <ItemTemplate>
                                            <asp:Button ID="deposit" runat="server"
                                                CommandName="deposit"
                                                CssClass="btn btn-success"
                                                CommandArgument='<%# Eval("AccNo") %>'
                                                Text="Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Withdraw">
                                        <ItemTemplate>
                                            <asp:Button ID="withdraw" runat="server"
                                                CommandName="withdraw"
                                                CssClass="btn btn-info"
                                                CommandArgument='<%# Eval("AccNo") %>'
                                                Text="Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Transfer">
                                        <ItemTemplate>
                                            <asp:Button ID="transfer" runat="server"
                                                CommandName="transfer"
                                                CssClass="btn btn-default"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div class="space"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="space"></div>
        </div>

        <%-- customer Not Found --%>
        <div class="row" id="customerNotFound" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6" role="alert">
                <div class="alert alert-danger errorText" role="alert">
                    <i class="fa fa-exclamation-triangle fa-2x"></i><b>
                        <asp:Label ID="errorMsg" runat="server"></asp:Label>
                        No customer found with given detail.   </b>
                </div>
            </div>
            <div class="col-md-5"></div>
        </div>

        <div class="row space" id="spacetoFullPage" runat="server"></div>

    </div>
    <%--<div style="min-height: 400px; margin-bottom:"></div>--%>

</asp:Content>
