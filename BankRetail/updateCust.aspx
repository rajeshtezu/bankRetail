<%@ Page Title="" Language="C#" MasterPageFile="~/Cashier.Master" AutoEventWireup="true" CodeBehind="updateCust.aspx.cs" Inherits="BankRetail.updateCust" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <%-- Checking whether there is customer //showData(1) --%>
        <div class="row" id="searchCustomer" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <h2 class="jumboText" style="text-align: center;">Update Customer </h2>
                <div class="jumbotron customJumbo">
                    <div class="form-group formGroupCustom" id="ssnID">
                        <div>
                            <asp:ScriptManager ID="ScriptManager1" runat="server" />
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Height="23px" Width="243px">
                                    <asp:ListItem Value="SSN" Text="SSN" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="ID" Text="Customer ID" Selected="False"></asp:ListItem>
                                </asp:RadioButtonList>

                                <asp:Label runat="server" ID="SSN_customerID" Text="SSN&nbsp;/&nbsp;Customer ID"></asp:Label>
                                <asp:TextBox ID="SSN_customerIDText" runat="server" CssClass="form-control" placeholder="SSN&nbsp;/&nbsp;Customer ID"></asp:TextBox>
                                <asp:RegularExpressionValidator
                                    ID="SSNSizeCheck"
                                    ForeColor="Red"
                                    runat="server"
                                    ErrorMessage="Enter valid SSN/ID"
                                    ControlToValidate="SSN_customerIDText"
                                    ValidationGroup="SSN_ID"
                                    CssClass="validationError"
                                    ValidationExpression="^[0-9]{9}$" Font-Size="11px" />
                                <asp:Button ID="search" runat="server" Text="Search" OnClick="search_Click" class="btn btn-info form-control" />

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>


                </div>
            </div>
            <%--<div class="col-md-5 space"></div>--%>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <%-- If Custmer doesn't exist in DB //showData(2) --%>
                <div class="row" id="customerNotFound" runat="server">
                <div class="col-md-1"></div>
                    <div class="col-md-6" role="alert">
                        <div class="alert alert-danger errorText" role="alert">
                            <i class="fa fa-exclamation-triangle fa-2x"></i>
                            No data found related to given ID. Please check and try again or <asp:HyperLink Text="click here" ID="newCustomerCreation" runat="server" NavigateUrl="~/AccountExecutive/CreateCustomer.aspx"></asp:HyperLink> to create new customer.
                        </div>
                    </div>
                    <%--<div class="col-md-5 space"></div>--%>
                </div>

                <%-- Customer Exists. Create new customer //showData(3) --%>
                <div class="row" id="newAccount" runat="server">
                    <div class="col-md-1"></div>
                    <div class="col-md-6">
                        <div class="jumbotron createForm">

                            <%-- Customer ID --%>
                            <div class="form-group">
                                <asp:Label Text="Customer ID" runat="server" ID="fixedCustomerIDLabel"></asp:Label>
                                <asp:TextBox ID="fixedCustomerIDText" runat="server" CssClass="form-control" Text="" Enabled="false"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                     <asp:ListItem Value="0" Text="Select Item" Selected="False"></asp:ListItem>
                                     <asp:ListItem Value="C" Text="Current Account" Selected="False"></asp:ListItem>
                                     <asp:ListItem value="S" Text="Saving Account" Selected="False"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <%-- Customer Name -%>
                            <div class="form-group">
                                <asp:Label Text="Customer Name:" runat="server" ID="customerNameLabel"></asp:Label>
                                <asp:TextBox ID="customerNameText" runat="server" CssClass="form-control" placeholder="Customer Name"></asp:TextBox>
                            </div>

                                --%>

                            <%-- Amount --%>
                            <div class="form-group">
                                <asp:Label Text="Deposit Amount" runat="server" ID="depositAmountLabel"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="depositAmountText" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Please enter valid amount" ControlToValidate="depositAmountText" ForeColor="Red" MinimumValue="1000" MaximumValue="50000" Type="Integer"></asp:RangeValidator>
                                <asp:TextBox ID="depositAmountText" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group row">
                                <asp:Button ID="Create" runat="server" Text="Create" class="btn btn-info btn-block" OnClick="Create_Click" />
                            </div>
                        </div>
                    </div>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>

                <%-- account creation successful alert //showData(4) --%>
                <div id="creationSuccessful" runat="server">
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-6 top" role="alert">
                            <div class="alert alert-success errorText" role="alert">
                                <i class="fa fa-thumbs-o-up fa-2x"></i><b>Account creation Initiated successfully.  </b>
                            </div>
                        </div>
                        <div class="col-md-5"></div>

                    </div>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-6">
                            <div class="jumbotron createForm">
                                <h4 style="font-family: Tahoma;">Save this Data for future references.</h4><hr />
                                <%-- Customer ID --%>
                                <div class="form-group">
                                    <asp:Label Text="Customer ID:" runat="server" ID="customerIDSuccessFixed" Font-Bold="true"></asp:Label>
                                    <asp:Label ID="customerIDSuccessvalue" runat="server" Text=""></asp:Label>
                                </div>

                                <%-- Account Number --%>
                                <div class="form-group">
                                    <asp:Label Text="account Number:" runat="server" ID="successAccountNumber" Font-Bold="true"></asp:Label>
                                    <asp:Label Text="" runat="server" ID="successAccountNumberText"></asp:Label>
                                </div>

                                <%-- Account type --%>
                                <div class="form-group">
                                    <asp:Label Text="account Type:" runat="server" ID="successAccountType" Font-Bold="true"></asp:Label>
                                    <asp:Label Text="" runat="server" ID="successAccountTypeText"></asp:Label>
                                </div>

                                <%-- Customer Name -%>
                            <div class="form-group">
                                <asp:Label Text="Customer Name:" runat="server" ID="customerNameLabel"></asp:Label>
                                <asp:TextBox ID="customerNameText" runat="server" CssClass="form-control" placeholder="Customer Name"></asp:TextBox>
                            </div>

                                --%>

                                <%-- Amount --%>
                                <div class="form-group">
                                    <asp:Label Text="Deposited Amount:" runat="server" ID="successDepositedAmount" Font-Bold="true"></asp:Label>
                                    <asp:Label ID="successDepositedAmountText" runat="server" Text="" ></asp:Label>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                <%-- Error while Account creation // showData(5) --%>
                <div class="row" id="creationError" runat="server">
                    <div class="col-md-1"></div>
                    <div class="col-md-6 top" role="alert">
                        <div class="alert alert-danger errorText" role="alert">
                            <i class="fa fa-exclamation-triangle fa-2x"></i><b>Account creation could not be processed. Try again.</b>
                        </div>
                    </div>
                    <div class="col-md-5 space"></div>
                </div>

                <div class="row space" id="spacetoFullPage" runat="server"></div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>



<%--create table Account(
CustId numeric(9,0),
AccId numeric(9,0),
AccType char check(AccType='S' or AccType='C'),
Balance numeric,
CrDate date,
CrLastDate date,
Duration numeric
)--%>
</asp:Content>