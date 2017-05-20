<%@ Page Title="" Language="C#" MasterPageFile="~/Cashier.Master" AutoEventWireup="true" CodeBehind="Deposit.aspx.cs" Inherits="BankRetail.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Asset/Scripts/refreshBanned.js"></script>
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
        <div class="row" id="depositForm" runat="server">
            <div class="col-md-1 col-lg-1 hidden-sm hidden-xs"></div>
            <div class="col-md-6 col-lg-6 hidden-sm hidden-xs">

                <h2 class="jumboText" style="text-align: center;">Deposit Money </h2>
                <div class="jumbotron customJumbo">
                    <div class="form-group formGroupCustom">
                        <div class="form-group">
                            <asp:Label ID="customerIDLabel" CssClass="col-md-5 col-lg-5" Font-Bold="true" runat="server" Text="Customer ID: "></asp:Label>
                            <asp:Label ID="customerIDText" CssClass="col-md-7 col-lg-7" runat="server" Text=""></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="accountIDLabel" CssClass="col-md-5 col-lg-5" Font-Bold="true" runat="server" Text="Account ID: "></asp:Label>
                            <asp:Label ID="accountIDText" CssClass="col-md-7 col-lg-7" runat="server" Text=""></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="accountTypeLabel" CssClass="col-md-5 col-lg-5" Font-Bold="true" runat="server" Text="account Type: "></asp:Label>
                            <asp:Label ID="accountTypeText" CssClass="col-md-7 col-lg-7" runat="server" Text=""></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="availableBalanceLabel" CssClass="col-md-5 col-lg-5" Font-Bold="true" runat="server" Text="Available Balance: "></asp:Label>
                            <asp:Label ID="availableBalanceText" CssClass="col-md-7 col-lg-7" runat="server" Text=""></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="depositAmountLabel" Font-Bold="true" runat="server" Text="Deposit Amount: "></asp:Label>
                            <asp:TextBox ID="depositAmountText" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                            <asp:RangeValidator
                                ID="RangeValidator1"
                                runat="server"
                                ErrorMessage="amount should be between 100 and 50,000."
                                ControlToValidate="depositAmountText"
                                ForeColor="Red"
                                MinimumValue="100"
                                MaximumValue="50000"
                                Type="Integer"></asp:RangeValidator>
                            <asp:RequiredFieldValidator
                                CssClass="validationError"
                                runat="server"
                                ID="RequiredFieldValidator2"
                                ForeColor="Red"
                                ControlToValidate="depositAmountText"
                                ErrorMessage="Please enter Amount" Font-Size="11px" />
                        </div>

                        <div class="form-group">
                            <asp:Button ID="submit" runat="server" Text="Deposit" CssClass="btn btn-info btn-block" OnClick="submit_Click" />
                        </div>
                    </div>
                </div>
                
            </div>
        </div>

        <%-- Deposit Success --%>
        <div id="depositSuccessful" runat="server">
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-6" role="alert">
                    <div class="alert alert-success errorText" role="alert">
                        <i class="fa fa-thumbs-o-up fa-2x"></i><b>Money deposited Successfully.   </b>
                    </div>
                </div>
                <div class="col-md-5"></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-6">

                    <div style="margin-bottom: 50px;">
                        <div class="formGroupCustom">
                            <div class="form-group">
                                <asp:Label ID="successCustomerIDLabel" CssClass="col-md-5 col-lg-5" Font-Bold="true" runat="server" Text="Customer ID: "></asp:Label>
                                <asp:Label ID="successCustomerIDText" CssClass="col-md-7 col-lg-7" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="successAccountIDLabel" CssClass="col-md-5 col-lg-5" Font-Bold="true" runat="server" Text="Account ID: "></asp:Label>
                                <asp:Label ID="successAccountIDText" CssClass="col-md-7 col-lg-7" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="successAccountTypeLabel" CssClass="col-md-5 col-lg-5" Font-Bold="true" runat="server" Text="Account Type: "></asp:Label>
                                <asp:Label ID="successAccountTypeText" CssClass="col-md-7 col-lg-7" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="transactionIDLabel" CssClass="col-md-5 col-lg-5" Font-Bold="true" runat="server" Text="Transaction ID: "></asp:Label>
                                <asp:Label ID="transactionIDText" CssClass="col-md-7 col-lg-7" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="successAvailableBalanceLabel" CssClass="col-md-5 col-lg-5" Font-Bold="true" runat="server" Text="Available Balance: "></asp:Label>
                                <asp:Label ID="successAvailableBalanceText" CssClass="col-md-7 col-lg-7" runat="server" Text=""></asp:Label>
                            </div>
                            
                        </div>
                    </div>

                </div>
                <div class="space"></div>
            </div>
        </div>

        <%-- deposit error --%>
        <div class="row" id="depositError" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6" role="alert">
                <div class="alert alert-danger errorText" role="alert">
                    <i class="fa fa-exclamation-triangle fa-2x"></i><b>Could not process the transaction. Please try again.   </b>
                </div>
            </div>
            <div class="col-md-5"></div>
        </div>

        <div class="row space" id="spacetoFullPage" runat="server"></div>

          
    </div>

</asp:Content>
