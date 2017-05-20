<%@ Page Title="" Language="C#" MasterPageFile="~/Scope.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BankRetail.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            
            <div id="hexagons">
                <img src="../Asset/images/Account.png" usemap="#hexMap" class="hexagons img-responsive" />
                <map name="hexMap">
                    <area shape="poly" href="CreateCustomer.aspx" coords="98,119,169,121,205,183,169,246,97,245,61,184" class="hexagon" alt="1" />
                    <area shape="poly" href="AccountStatus.aspx" coords="220,50,290,50,330,115,295,175,220,175,185,115" class="hexagon" alt="1" />
                    <area shape="poly" href="DeleteAccount.aspx" coords="340,120,415,120,450,185,415,245,340,245,310,185" class="hexagon" alt="1" />
                    <area shape="poly" href="CreateAccount.aspx" coords="340,265,415,265,450,325,415,390,342,385,305,325" class="hexagon" alt="1" />
                    <area shape="poly" href="UpdateCustomer.aspx" coords="220,335,290,335,330,400,290,460,220,460,185,395" class="hexagon" alt="1" />
                    <area shape="poly" href="DeleteCustomer.aspx" coords="170,390,95,389,60,325,95,260,170,265,205,325" class="hexagon" alt="1" />
                </map>
            </div>

            
        </div>
    </div>
</asp:Content>
