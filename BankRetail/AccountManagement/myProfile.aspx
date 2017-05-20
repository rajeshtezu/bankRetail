<%@ Page Title="" Language="C#" MasterPageFile="~/Scope.Master" AutoEventWireup="true" CodeBehind="myProfile.aspx.cs" Inherits="BankRetail.AccountManagement.myProfile" %>
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
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <div class="container">

                    <%--Logo, name and Type --%>
                    <div class="row" style="margin-top: 100px; margin-bottom: 100px;">
                        <div class="col-md-2"></div>
                        <div class="col-md-4 jumboIcon" style="background-color: #3d53b0; ">
                            <span class="fa fa-user fa-5x"></span>
                            <p>
                                <asp:Label ID="empID" Text="" runat="server" Font-Bold="true"></asp:Label><br />
                                <asp:Label ID="empName" Text="" runat="server"></asp:Label><br />
                                <asp:Label ID="empType" runat="server" Text=""></asp:Label>
                                <hr />
                                <asp:Label ID="empGenderMale" runat="server">
                                    <i class="fa fa-male fa-2x"></i>Male
                                </asp:Label>
                                <asp:Label ID="empGenderFemale" runat="server">
                                    <i class="fa fa-female fa-2x"></i>Female
                                </asp:Label>
                            </p>
                        </div>
                        <div class="col-md-3"></div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
