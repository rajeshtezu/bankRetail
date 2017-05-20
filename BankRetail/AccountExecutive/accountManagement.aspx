<%@ Page Title="" Language="C#" MasterPageFile="~/Scope.Master" AutoEventWireup="true" CodeBehind="accountManagement.aspx.cs" Inherits="BankRetail.AccountExecutive.accountManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .noScroll
        {
            display: none;
        }
        .jumboIcon {
            padding-left: 15px;
            padding-top: 30px;
            padding-bottom: 40px;
            padding-right: 15px;
            background-color: aqua;
            border-radius: 15px;
            text-align: center;
            color: white;
        }
        .customerStatus:hover
        {
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row" style="margin-top: 50px; margin-bottom: 100px;">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <div class="container">

                    <%--Logo, name and Type --%>
                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-4 jumboIcon" style="background-color: #3d53b0; ">
                            <span class="fa fa-user fa-5x"></span>
                            <p>
                                <asp:Label ID="emp_name" Text="" runat="server"></asp:Label><br />
                                <asp:Label ID="EmpType" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="col-md-3"></div>
                    </div>

                    <%-- Functionality icons --%>
                    <div class="row" style="margin-top: 60px">

                        <%-- 1 create account --%>
                        <div class="col-md-3 col-lg-3 col-lg-offset-1 col-md-offset-1">
                            <asp:HyperLink ID="CreateAccount" CssClass="customerStatus" runat="server" NavigateUrl="~/AccountExecutive/CreateAccount.aspx">
                                <div class="jumboIcon">
                                    <i class="fa fa-3x fa-plus"></i><br />
                                    Create Account
                                </div>
                            </asp:HyperLink>
                        </div>

                        <%-- 3 delete account --%>
                        <div class="col-md-3 col-lg-3 col-md-offset-1 col-md-offset-1">
                            <asp:HyperLink ID="DeleteAccount" CssClass="customerStatus" runat="server" NavigateUrl="~/AccountExecutive/DeleteAccount.aspx">
                                <div class="jumboIcon">
                                    <i class="fa fa-3x fa-trash-o"></i><br />
                                    Delete Account
                                </div>
                            </asp:HyperLink>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
    </div>

</asp:Content>
