<%@ Page Title="" Language="C#" MasterPageFile="~/Scope.Master" AutoEventWireup="true" CodeBehind="changePassword.aspx.cs" Inherits="BankRetail.AccountManagement.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row" style="margin-top: 50px;" id="changePasswordDiv" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <h2 class="jumboText" style="text-align: center;">Change Password </h2>
                <div class="jumbotron customJumbo">
                    <div class="form-group formGroupCustom" id="lastPassword">
                        <asp:Label runat="server" ID="lastPasswordlabel" Font-Bold="true" Text="Old Password:"></asp:Label>
                        <asp:TextBox ID="lastPasswordText" TextMode="Password" runat="server" CssClass="form-control" placeholder="Old Password"></asp:TextBox>
                        <asp:RequiredFieldValidator
                                    CssClass="validationError"
                                    runat="server"
                                    ID="SSNRequiredCheck"
                                    ForeColor="Red"
                                    ControlToValidate="lastPasswordText"
                                    ValidationGroup="SSN_ID"
                                    ErrorMessage="Please enter Old Password" Font-Size="11px" />
                    </div>
                    <div class="form-group formGroupCustom" id="newPassword">
                        <asp:Label runat="server" ID="newPasswordLabel" Font-Bold="true" Text="New Password:"></asp:Label>
                        <asp:TextBox ID="newPasswordText" runat="server" TextMode="Password" CssClass="form-control" placeholder="New Password"></asp:TextBox>
                        <asp:RequiredFieldValidator
                                    CssClass="validationError"
                                    runat="server"
                                    ID="RequiredFieldValidator1"
                                    ForeColor="Red"
                                    ControlToValidate="newPasswordText"
                                    ValidationGroup="SSN_ID"
                                    ErrorMessage="Please enter New Password" Font-Size="11px" />
                    </div>
                    <div class="form-group formGroupCustom" id="confirmPassword">
                        <asp:Label runat="server" ID="confirmPasswordLabel" Font-Bold="true" Text="Confirm Password:"></asp:Label>
                        <asp:TextBox ID="confirmPasswordText" runat="server" TextMode="Password" CssClass="form-control" placeholder="Confirm Password"></asp:TextBox>
                        <asp:RequiredFieldValidator
                                    CssClass="validationError"
                                    runat="server"
                                    ID="RequiredFieldValidator2"
                                    ForeColor="Red"
                                    ControlToValidate="confirmPasswordText"
                                    ValidationGroup="SSN_ID"
                                    ErrorMessage="Please enter New password again" Font-Size="11px" />
                    </div>
                    <br />
                    <asp:Button ID="changePassword" runat="server" Text="Change Password" class="btn btn-info form-control" OnClick="changePassword_Click" />
                </div>
            </div>
        </div>

        <div class="row" id="changeUnsuccessful" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6" role="alert">
                <div class="alert alert-danger errorText" role="alert">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>
                    <asp:Label ID="errorMessageLabel" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <div class="row" id="changeSuccessful" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6" role="alert">
                <div class="alert alert-success errorText" role="alert">
                    <i class="fa fa-thumbs-o-up fa-2x"></i>
                    Password Changed successfully.
                </div>
            </div>
        </div>

        <div class="row">
            <div class="space"></div>
        </div>
    </div>
</asp:Content>
