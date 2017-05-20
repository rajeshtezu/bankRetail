<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BankRetail.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        
        <%-- Login Content --%>
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 loginSide1">
                <h2 class="jumboText" style="text-align: center;">Login </h2>
                <div class="jumbotron customJumbo">
                    <div class="form-group formGroupCustom" id="userIDDiv">
                        <asp:Label runat="server" ID="UserIDlabel" Font-Bold="true" Text="User ID"></asp:Label>
                        <asp:TextBox ID="userIDText" runat="server" CssClass="form-control" placeholder="user ID"></asp:TextBox>
                                <asp:RequiredFieldValidator
                                    CssClass="validationError"
                                    runat="server"
                                    ID="SSNRequiredCheck"
                                    ForeColor="Red"
                                    ControlToValidate="userIDText"
                                    ValidationGroup="SSN_ID"
                                    ErrorMessage="Please enter user ID" Font-Size="11px" />
                    </div>
                    <div class="form-group formGroupCustom" id="passwordDiv">
                        <asp:Label runat="server" ID="passwordLabel" Font-Bold="true" Text="Password"></asp:Label>
                        <asp:TextBox ID="passwordText" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator
                                    CssClass="validationError"
                                    runat="server"
                                    ID="RequiredFieldValidator1"
                                    ForeColor="Red"
                                    ControlToValidate="passwordText"
                                    ValidationGroup="SSN_ID"
                                    ErrorMessage="Please enter Password" Font-Size="11px" />
                    </div><br />
                    <asp:Button ID="login" runat="server" Text="Login" class="btn btn-info form-control" OnClick="LoginButton" />
                </div>

                <%-- Account Not Found --%>
                <div class="row" id="loginFail" runat="server">
                    <div role="alert">
                        <div class="alert alert-danger errorText" style="border-radius: 5px;" role="alert">
                            <i class="fa fa-exclamation-triangle fa-2x"></i>
                            <b>
                                <asp:Label ID="Label1" runat="server" Text="" Font-Size="Large" Style="color: red;"></asp:Label>
                                 
                            </b>
                        </div>
                    </div>
                    <div class="col-md-5"></div>
                </div>
                

                <%-- API Sign IN --%>

                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 jumbotron jumboBorder">
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Login/Login.aspx">
                            <asp:Image ID="APILogo" runat="server" ImageUrl="~/Asset/images/Tata_Consultancy_Services_Logo1.jpg" Width="100%" />
                        </asp:HyperLink>
                    </div>
                </div>

            </div>

            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <img src="../Asset/images/bank.jpg" class="img-thumbnail hidden-xs" width="100%" height="300px" />
                    </div>
                </div>
                
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                        <h2 class="jumboText" style="text-align: center;">About Us </h2>
                        <div class="jumbotron customJumbo">
                            <p>ABC Bank is a bank where retailers trust banking.</p>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                        <h2 class="jumboText" style="text-align: center;">Notifications </h2>
                        <div class="jumbotron customJumbo" style="font-weight: 600;">
                            <p>
                                Today, we have presentation postlunch.
                            </p>
                            <p>Meet Abhis at 05:00 PM.
                            </p>
                            
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                        <h2 class="jumboText" style="text-align: center;">Quick Links </h2>
                        <div class="jumbotron customJumbo">
                            <ul>
                                <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://www.rbi.org.in/">RBI</asp:HyperLink></li>
                                <li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="https://www.google.co.in/">Google</asp:HyperLink></li>
                                <li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="https://www.tcs.com/">TCS</asp:HyperLink></li>
                            </ul>
                            
                            
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
