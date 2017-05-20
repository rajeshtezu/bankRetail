<%@ Page Title="" Language="C#" MasterPageFile="~/Cashier.Master" AutoEventWireup="true" CodeBehind="Withdraw.aspx.cs" Inherits="BankRetail.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #withdrawError
        {
            margin-top: 100px;
        }
        .space
        {
            margin-top: 360px;
        }
    </style>
    <script type="text/javascript">
        function disableF5(e) { if ((e.which || e.keyCode) == 116 || (e.which || e.keyCode) == 82) e.preventDefault(); };

        $(document).ready(function () {
            $(document).on("keydown", disableF5);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <script type="text/javascript">
            disableF5();
            document.getElementById("ctrl").setAttribute('disabled', true);
            document.addEventListener('contextmenu', event => event.preventDefault());
        </script>
        <div class="row" id="withdrawForm" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">

                <h2 class="jumboText" style="text-align: center;">Withdraw Money </h2>
                <div class="jumbotron customJumbo">
                    <div class="form-group formGroupCustom">
                        <div class="form-group">
                            <asp:Label ID="customerIDLabel" Font-Bold="true" CssClass="col-lg-5 col-md-5" runat="server" Text="Customer ID: "></asp:Label>
                            <asp:Label ID="customerIDText" runat="server" CssClass="col-lg-7 col-md-7" Text=""></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="accountIDLabel" Font-Bold="true" CssClass="col-lg-5 col-md-5" runat="server" Text="Account ID: "></asp:Label>
                            <asp:Label ID="accountIDText" runat="server" CssClass="col-lg-7 col-md-7" Text=""></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="accountTypeLabel" Font-Bold="true" CssClass="col-lg-5 col-md-5" runat="server" Text="Account Type:"></asp:Label>
                            <asp:Label ID="accountTypeText" runat="server" CssClass="col-lg-7 col-md-7" Text=""></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="availableBalanceLabel" Font-Bold="true" CssClass="col-lg-5 col-md-5" runat="server" Text="Available Balance: "></asp:Label>
                            <asp:Label ID="availableBalanceText" runat="server" CssClass="col-lg-7 col-md-7" Text=""></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="withdrawAmountLabel" Font-Bold="true" runat="server" Text="Withdraw Amount: "></asp:Label>
                            <asp:TextBox ID="withdrawAmountText" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                            <asp:RangeValidator 
                                ID="RangeValidator1" 
                                runat="server" 
                                ControlToValidate="withdrawAmountText" 
                                MinimumValue="100" 
                                MaximumValue="50000" 
                                Type="Integer"
                                ErrorMessage="Amount should be more than 100 and less than 50,000."></asp:RangeValidator>
                        </div>

                        <div class="form-group">
                            <asp:Button ID="submit" runat="server" CssClass="btn btn-info btn-block" Text="Withdraw" OnClick="submit_Click" />
                        </div>
                    </div>
                </div>
                
            </div>
        </div>

        <%-- Withdrawal Success --%>
        <div id="withdrawalSuccessful" runat="server">
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-6" role="alert">
                    <div class="alert alert-success errorText" role="alert">
                        <i class="fa fa-thumbs-o-up fa-2x"></i><b>Money Withdrawn Successfully.   </b>
                    </div>
                </div>
                <div class="col-md-5"></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-6  jumbotron">

                    <div class="jumbotron customJumbo">
                        <div class="form-group formGroupCustom">
                            <div class="form-group">
                                <asp:Label ID="successCustomerIDLabel" Font-Bold="true" CssClass="col-lg-5 col-md-5" runat="server" Text="Customer ID"></asp:Label>
                                <asp:Label ID="successCustomerIDText" runat="server" CssClass="col-lg-7 col-md-7" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="successAccountIDLabel" Font-Bold="true" CssClass="col-lg-5 col-md-5" runat="server" Text="Account ID"></asp:Label>
                                <asp:Label ID="successAccountIDText" runat="server" CssClass="col-lg-7 col-md-7" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="successAccountTypeLabel" Font-Bold="true" CssClass="col-lg-5 col-md-5" runat="server" Text="account Type"></asp:Label>
                                <asp:Label ID="successAccountTypeText" runat="server" CssClass="col-lg-7 col-md-7" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="transactionIDLabel" Font-Bold="true" CssClass="col-lg-5 col-md-5" runat="server" Text="Transaction ID"></asp:Label>
                                <asp:Label ID="transactionIDText" runat="server" CssClass="col-lg-7 col-md-7" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="successAvailableBalanceLabel" Font-Bold="true" CssClass="col-lg-5 col-md-5" runat="server" Text="Available Balance: "></asp:Label>
                                <asp:Label ID="successAvailableBalanceText" runat="server" CssClass="col-lg-7 col-md-7" Text=""></asp:Label>
                            </div>

                            
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <%-- deposit error --%>
        <div class="row" id="withdrawError" runat="server" >
            <div class="col-md-1"></div>
            <div class="col-md-6" role="alert">
                <div class="alert alert-danger errorText" role="alert">
                    <i class="fa fa-exclamation-triangle fa-2x"></i><b><asp:Label ID="errorMsg" runat="server"></asp:Label> Please try again.   </b>
                </div>
            </div>
            <div class="col-md-5"></div>
        </div>

        <div class="row space" id="spacetoFullPage" runat="server"></div>

          
    </div>

</asp:Content>
