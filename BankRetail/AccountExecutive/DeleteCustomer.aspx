<%@ Page Title="" Language="C#" MasterPageFile="~/Scope.Master" AutoEventWireup="true" CodeBehind="DeleteCustomer.aspx.cs" Inherits="BankRetail.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        AreYouSure = function () {
            var x = confirm("Are you sure, you want to delete this Customer?");
            return x;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <%-- Searching for customer to delete --%>
        <div class="row" id="searchCustomer" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <h2 class="jumboText"><b>Search Customer</b> </h2>
                <div class="jumbotron customJumbo">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Height="23px" Width="243px">
                        <asp:ListItem Value="SSN" Text="SSN" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="ID" Text="Customer ID" Selected="False"></asp:ListItem>
                    </asp:RadioButtonList>

                    <div class="form-group" id="ssnID">
                        <asp:Label Font-Bold="true" runat="server" ID="SSN_accountNumberlabel" Text="SSN&nbsp;/&nbsp;Customer ID"></asp:Label>
                        <asp:TextBox ID="SSN_customerIdText" runat="server" CssClass="form-control" placeholder="SSN&nbsp;/&nbsp;Customer Id"></asp:TextBox>
                        <asp:RegularExpressionValidator
                                    ID="SSNSizeCheck"
                                    ForeColor="Red"
                                    runat="server"
                                    ErrorMessage="Should be 9 digit numeric."
                                    ControlToValidate="SSN_customerIdText"
                                    ValidationGroup="SSN_ID"
                                    CssClass="validationError"
                                    ValidationExpression="^[0-9]{9}$" Font-Size="11px" />
                                <asp:RequiredFieldValidator
                                    CssClass="validationError"
                                    runat="server"
                                    ID="SSNRequiredCheck"
                                    ForeColor="Red"
                                    ControlToValidate="SSN_customerIdText"
                                    ValidationGroup="SSN_ID"
                                    ErrorMessage="Please enter SSN/Customer ID" Font-Size="11px" />
                    </div>

                    <asp:Button ID="search" runat="server" Text="Search" class="btn btn-info form-control" OnClick="search_Click" CausesValidation="true"/>
                </div>
            </div>
            <div class="col-md-5 space"></div>
        </div>

        <%-- Customer details not found --%>
        <div class="row" id="customerNotFound" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <div class="alert alert-danger errorText" role="alert">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>Customer details not Found. Provide correct details.
                </div>
            </div>
            <div style="margin-bottom: 600px;"></div>
        </div>

        <%-- Customer details found --%>
        <div class="row" id="customerFound" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <h2 class="jumboText">Customer Details</h2>
                <div class="jumbotron">
                    <div class="form-group row">
                        <asp:Label Text="Customer ID:" Font-Bold="true" runat="server" ID="customerIDlabel" CssClass="col-md-4"></asp:Label>
                        <asp:Label Text="123456789" Font-Bold="true" runat="server" ID="customerIDText" CssClass="col-md-8"></asp:Label>
                    </div>

                    <div class="form-group row">
                        <asp:Label Text="Customer Name:" Font-Bold="true" runat="server" ID="customerNameLabel" CssClass="col-md-4"></asp:Label>
                        <asp:Label ID="customerNameText" Font-Bold="true" runat="server" Text="Customer_Name" CssClass="col-md-8"></asp:Label>
                    </div>

                    <div class="form-group row">
                        <asp:Label Text="Age:" Font-Bold="true" runat="server" ID="DateOfBirthLabel" CssClass="col-md-4"></asp:Label>
                        <asp:Label ID="AgeText" Font-Bold="true" runat="server" Text="Age" CssClass="col-md-8"></asp:Label>
                    </div>

                    <div class="form-group row">
                        <asp:Label Text="Address" Font-Bold="true" runat="server" ID="permanentAddressLabel" CssClass="col-md-4"></asp:Label>
                        <asp:Label ID="AddressText" Font-Bold="true" runat="server" Text="Address" CssClass="col-md-8"></asp:Label><br />
                    </div>

                    <div class="form-group row">
                        <asp:Button ID="Delete" runat="server" Text="Delete Customer" class="btn btn-danger form-control" OnClick="Delete_Click" />
                    </div>

                </div>
            </div>
            <div class="col-md-5 space" style="margin-bottom: 600px;"></div>
        </div>

        <%-- Deletion processed succesfully --%>
        <div class="row" id="deletionSuccessful" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <div class="alert alert-success errorText" role="alert">
                    <i class="fa fa-thumbs-o-up fa-2x"></i>Customer Deletion Processed Successfully.
                </div>
            </div>
            <div class="space" style="margin-bottom: 600px;"></div>
        </div>

        <%-- Deletion couldn't be processed --%>
        <div class="row" id="deletionUnsuccessful" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <div class="alert alert-danger errorText" role="alert">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>Deletion couldn't be processed. Try again later.
                </div>
            </div>
            <div class="space" style="margin-bottom: 600px;"></div>
        </div>

        <div class="row space" id="spacetoFullPage" runat="server"></div>

    </div>
</asp:Content>
