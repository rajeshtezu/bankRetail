<%@ Page Title="" Language="C#" MasterPageFile="~/Scope.Master" AutoEventWireup="true" CodeBehind="Status.aspx.cs" Inherits="BankRetail.AccountExecutive.Status" %>
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
                    <div class="row" style="margin-top: 60px">
                        <div class="col-md-3 col-md-offset-1">
                            <asp:HyperLink ID="customerStatus" CssClass="customerStatus" runat="server" NavigateUrl="~/AccountExecutive/CustomerStatus.aspx" Text="Customer Status">
                                <div class="jumboIcon">
                                    <i class="fa fa-3x fa-user-o"></i><br />
                                    Customer Status
                                </div>
                            </asp:HyperLink>
                        </div>
                        <div class="col-md-3 col-md-offset-1">
                           
                            <asp:HyperLink ID="accountStatus" CssClass="customerStatus" runat="server" NavigateUrl="~/AccountExecutive/AccountStatus.aspx" Text="Account Status">
                                <div class="jumboIcon">
                                    <i class="fa fa-3x fa-list"></i><br />
                                    Account Status
                                </div>
                            </asp:HyperLink>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
    </div>

</asp:Content>
