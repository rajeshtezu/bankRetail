<%@ Page Title="" Language="C#" MasterPageFile="~/Scope.Master" AutoEventWireup="true" CodeBehind="customerManagement.aspx.cs" Inherits="BankRetail.AccountExecutive.customerManagement" %>
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

                        <%-- 1 create customer --%>
                        <div class="col-md-3">
                            <asp:HyperLink ID="customerStatus" CssClass="customerStatus" runat="server" NavigateUrl="~/AccountExecutive/CreateCustomer.aspx">
                                <div class="jumboIcon">
                                    <i class="fa fa-3x fa-user-plus"></i><br />
                                    Create Customer
                                </div>
                            </asp:HyperLink>
                        </div>

                        <%-- 2 update customer --%>
                        <div class="col-md-3">
                            <asp:HyperLink ID="accountStatus" CssClass="customerStatus" runat="server" NavigateUrl="~/AccountExecutive/UpdateCustomer.aspx">
                                <div class="jumboIcon">
                                    <i class="fa fa-3x fa-pencil"></i><br />
                                    Update Customer
                                </div>
                            </asp:HyperLink>
                        </div>

                        <%-- 3 delete customer --%>
                        <div class="col-md-3">
                            <asp:HyperLink ID="HyperLink1" CssClass="customerStatus" runat="server" NavigateUrl="~/AccountExecutive/DeleteCustomer.aspx">
                                <div class="jumboIcon">
                                    <i class="fa fa-3x fa-user-times"></i><br />
                                    Delete Customer
                                </div>
                            </asp:HyperLink>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
