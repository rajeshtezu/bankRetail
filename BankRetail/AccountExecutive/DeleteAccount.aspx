<%@ Page Title="" Language="C#" MasterPageFile="~/Scope.Master" AutoEventWireup="true" CodeBehind="DeleteAccount.aspx.cs" Inherits="BankRetail.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
        </div>
        <%-- Searching for Account // showData(1) --%>
        <div class="row" id="searchAccount" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <h2 class="jumboText"><b>Delete Account</b> </h2>
                        <div class="jumbotron customJumbo">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Height="23px" Width="243px">
                                <asp:ListItem Value="SSN" Text="SSN" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="ID" Text="Customer ID" Selected="False"></asp:ListItem>
                            </asp:RadioButtonList>

                            <div class="form-group" id="ssnID">
                                <asp:Label Font-Bold="true" runat="server" ID="SSN_accountNumberlabel" Text="SSN&nbsp;/&nbsp;Customer ID"></asp:Label>
                                <asp:RegularExpressionValidator
                                    ID="SSNSizeCheck"
                                    ForeColor="Red"
                                    runat="server"
                                    ErrorMessage="Should be 9 digit numeric."
                                    ControlToValidate="SSN_CustomerIDText"
                                    ValidationGroup="SSN_ID"
                                    CssClass="validationError"
                                    ValidationExpression="^[0-9]{9}$" Font-Size="11px" />
                                <asp:RequiredFieldValidator
                                    CssClass="validationError"
                                    runat="server"
                                    ID="SSNRequiredCheck"
                                    ForeColor="Red"
                                    ControlToValidate="SSN_CustomerIDText"
                                    ValidationGroup="SSN_ID"
                                    ErrorMessage="Please enter SSN/Customer ID" Font-Size="11px" />
                                <asp:TextBox ID="SSN_CustomerIDText" runat="server" CssClass="form-control" placeholder="SSN&nbsp;/&nbsp;Customer ID"></asp:TextBox>
                            </div>

                            <asp:Button ID="search" runat="server" Text="Search" class="btn btn-info form-control" OnClick="search_Click"/>
                        </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <%-- Customer Details not found // showData(2) --%>
        <div class="row" id="CustomerDetailsNotFound" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6 col-lg-6 col-md-offset-1">
                <div class="alert alert-danger errorText" role="alert">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>Customer details not Found. Provide correct details.
                </div>
            </div>
            <div class="col-md-5 space"></div>
        </div>

        <%-- Account Found // showData(3) --%>

        <div class="row" id="accountDetails" runat="server">
            <h2>Queried Account Details</h2>

            <asp:GridView ID="GridViewAccount" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridViewAccount_RowDeleting"
                Font-Bold="true" Font-Size="Medium" AlternatingRowStyle-BackColor="#ccffff" CssClass="table" HorizontalAlign="Center" RowStyle-HorizontalAlign="Center">

                <Columns>
                    <asp:TemplateField HeaderText="Account Number">
                        <ItemTemplate>
                            <asp:Label ID="AccNoLabel" runat="server" Text='<%# Eval("AccNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer ID">
                        <ItemTemplate>
                            <asp:Label ID="CustIDLabel" runat="server" Text='<%# Eval("CustId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer Name">
                        <ItemTemplate>
                            <asp:Label ID="CustNameLabel" runat="server" Text='<%# Eval("CustName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Account Type">
                        <ItemTemplate>
                            <asp:Label ID="AccTypeLabel" runat="server" Text='<%# Eval("AccType") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Balance">
                        <ItemTemplate>
                            <asp:Label ID="BalanceLabel" runat="server" Text='<%# Eval("Balance") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="Delete Account" ShowDeleteButton="True" ShowHeader="True"/>
                </Columns>

            </asp:GridView>
            <div class="space" style="margin-top: 200px; margin-bottom: 400px;"></div>

        </div>

        <%-- Account not Found --%>
     <div class="row" id="AccountDetailsNotFound" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <div class="alert alert-danger errorText" role="alert">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>No active Account for this Customer.
                </div>
            </div>
            <div class="col-md-5 space" style="margin-bottom:400px;"></div>
        </div>
        
        
            <%-- Deletion success // showData(4) --%>
        <div class="row" id="deletionSuccess" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <div class="alert alert-success errorText" role="alert">
                    <i class="fa fa-thumbs-o-up fa-2x"></i>Account deletion Processed Successfully.
                </div>
            </div>
            <div class="col-md-5 space" style="margin-top:200px;margin-bottom: 400px;"></div>
        </div>

        <%-- Deletion Couldn't complete // showData() --%>
        <div class="row" id="deletionUnsuccessfull" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <div class="alert alert-danger errorText" role="alert">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>Couldn't process account deletion. Try again later.
                </div>
            </div>
            <div class="col-md-5 space"></div>
        </div>

        <div class="row space" id="spacetoFullPage" runat="server"></div>

    </div>
</asp:Content>
