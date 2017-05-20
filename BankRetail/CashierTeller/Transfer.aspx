<%@ Page Title="" Language="C#" MasterPageFile="~/Cashier.Master" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="BankRetail.WebForm13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Transfer :: ABC Bank</title>
    <script type="text/javascript">
        function disableF5(e) { if ((e.which || e.keyCode) == 116 || (e.which || e.keyCode) == 82) e.preventDefault(); };
        $(document).ready(function () {
            $(document).on("keydown", disableF5);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        disableF5();
        document.getElementById("ctrl").setAttribute('disabled', true);
        document.addEventListener('contextmenu', event => event.preventDefault());
    </script>
    <div class="container">
        <div class="row" id="transferForm" runat="server">
            <div class="col-md-1 col-lg-1 hidden-sm hidden-xs"></div>
            <div class="col-md-6 col-lg-6 hidden-sm hidden-xs">
                <h2 class="jumboText" style="text-align: center;">Deposit Money </h2>
                <div class="jumbotron customJumbo">
                    <div class="form-group formGroupCustom">
                        <div class="form-group">
                            <asp:Label ID="sourceAccountLabel" Font-Bold="true" runat="server" Text="Source Account: "></asp:Label>
                            <asp:TextBox ID="sourceAccountText" CssClass="form-control" runat="server" placeholder=""></asp:TextBox>
                            <asp:RegularExpressionValidator
                                ID="SSNSizeCheck"
                                ForeColor="Red"
                                runat="server"
                                ErrorMessage="Should be 9 digit numeric."
                                ControlToValidate="sourceAccountText"
                                CssClass="validationError"
                                ValidationExpression="^[0-9]{9}$" Font-Size="11px" />
                            <asp:RequiredFieldValidator
                                CssClass="validationError"
                                runat="server"
                                ID="SSNRequiredCheck"
                                ForeColor="Red"
                                ControlToValidate="sourceAccountText"
                                ErrorMessage="Please enter source account number." Font-Size="11px" />
                        </div>

                        <div class="form-group">
                            <asp:Label ID="targetAccountLabel" Font-Bold="true" runat="server" Text="Target Account: "></asp:Label>
                            <asp:TextBox ID="targetAccountText" CssClass="form-control" runat="server" placeholder=""></asp:TextBox>
                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidator1"
                                ForeColor="Red"
                                runat="server"
                                ErrorMessage="Should be 9 digit numeric."
                                ControlToValidate="targetAccountText"
                                CssClass="validationError"
                                ValidationExpression="^[0-9]{9}$" Font-Size="11px" />
                            <asp:RequiredFieldValidator
                                CssClass="validationError"
                                runat="server"
                                ID="RequiredFieldValidator1"
                                ForeColor="Red"
                                ControlToValidate="targetAccountText"
                                ErrorMessage="Please enter target account number." Font-Size="11px" />
                        </div>

                        <div class="form-group">
                            <asp:Label ID="transferAmountLabel" Font-Bold="true" runat="server" Text="Transfer Amount: "></asp:Label>
                            <asp:TextBox ID="transferAmountText" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                            <asp:RangeValidator
                                ID="RangeValidator1"
                                runat="server"
                                ErrorMessage="amount should be between 100 and 50,000."
                                ControlToValidate="transferAmountText"
                                ForeColor="Red"
                                MinimumValue="100"
                                MaximumValue="50000"
                                Type="Integer"></asp:RangeValidator>
                            <asp:RequiredFieldValidator
                                CssClass="validationError"
                                runat="server"
                                ID="RequiredFieldValidator2"
                                ForeColor="Red"
                                ControlToValidate="transferAmountText"
                                ErrorMessage="Please enter Amount" Font-Size="11px" />

                        </div>

                        <div class="form-group">
                            <asp:Button ID="transfer" runat="server" Text="Transfer" CssClass="btn btn-info btn-block" OnClick="transfer_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- Account Not Found --%>
        <div class="row" id="accountNotFound" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6" style="margin-top: 150px; margin-bottom: 50px;" role="alert">
                <div class="alert alert-danger errorText" role="alert">
                    <i class="fa fa-exclamation-triangle fa-2x"></i><b>
                        <asp:Label ID="account404" runat="server"></asp:Label>
                        <asp:Label ID="accountDet" runat="server"></asp:Label>
                        Please input correct account.   </b>
                </div>
            </div>
            <div class="col-md-5"></div>
        </div>

        <%-- Inefficient Balance --%>
        <div class="row" id="inefficientBalance" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6" style="margin-top: 150px; margin-bottom: 50px;" role="alert">
                <div class="alert alert-danger errorText" role="alert">
                    <i class="fa fa-exclamation-triangle fa-2x"></i><b>
                        <asp:Label ID="inefficientBalanceLabel" runat="server"></asp:Label><asp:Label ID="errorMsg" runat="server"></asp:Label>
                        Please input amount less than available balance.   </b>
                </div>
            </div>
            <div class="col-md-5"></div>
        </div>

        <%-- Transfer Successful --%>
        <div id="transferSuccessful" runat="server">
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-6" style="margin-top: 50px; margin-bottom: 25px;" role="alert">
                    <div class="alert alert-success errorText" role="alert">
                        <i class="fa fa-thumbs-o-up fa-2x"></i><b>Money Transferred Successfully.   </b>
                    </div>
                </div>
                <div class="col-md-5"></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-6">

                    <div class="jumbotron customJumbo">
                        <div class="form-group formGroupCustom">
                            <div class="form-group">
                                <asp:Label ID="successSourceAccountIDLabel" Font-Bold="true" runat="server" Text="Source Account ID: "></asp:Label>
                                <asp:Label ID="successSourceAccountIDText" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="successTargetAccountIDLabel" Font-Bold="true" runat="server" Text="Target Account ID: "></asp:Label>
                                <asp:Label ID="successTargetAccountIDText" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="transactionIDLable" Font-Bold="true" runat="server" Text="Transaction ID: "></asp:Label>
                                <asp:Label ID="transactionIDText" runat="server" Text=""></asp:Label>
                            </div>

                            <h4><u>Balance Before Transaction</u></h4>
                            <div class="form-group">
                                <asp:Label ID="successBalPrTrnsctnSrcAccntLabel" Font-Bold="true" runat="server" Text="Source Account: "></asp:Label>
                                <asp:Label ID="successBalPrTrnsctnSrcAccntText" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="successBalPrTrnsctnTrgAccntLabel" Font-Bold="true" runat="server" Text="Transaction Account: "></asp:Label>
                                <asp:Label ID="successBalPrTrnsctnTrgAccntText" runat="server" Text=""></asp:Label>
                            </div>

                            <h4><u>Balance After Transaction</u></h4>
                            <div class="form-group">
                                <asp:Label ID="successBalPoTrnsctnSrcAccntLabel" Font-Bold="true" runat="server" Text="Source Account: "></asp:Label>
                                <asp:Label ID="successBalPoTrnsctnSrcAccntText" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="successBalPoTrnsctnTrgAccntLabel" Font-Bold="true" runat="server" Text="Transaction Account: "></asp:Label>
                                <asp:Label ID="successBalPoTrnsctnTrgAccntText" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>


        <div class="space" id="manageSpace" runat="server"></div>
    </div>

</asp:Content>
