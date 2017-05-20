<%@ Page Title="" Language="C#" MasterPageFile="~/Scope.Master" AutoEventWireup="true" CodeBehind="UpdateCustomer.aspx.cs" Inherits="BankRetail.UpdateCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" runat="server">
        <%-- Search box showdata(1) --%>
        <div class="row" id="searchCustomer" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <h2 class="jumboText" style="text-align: center;">Update Customer </h2>
                <div class="jumbotron customJumbo">
                    <div class="form-group formGroupCustom" id="update">
                        <%--<div>
                            <asp:ScriptManager ID="ScriptManager1" runat="server" />
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Height="23px" Width="243px">
                            <asp:ListItem Value="SSN" Text="SSN" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="ID" Text="Customer ID" Selected="False"></asp:ListItem>
                        </asp:RadioButtonList>

                        <asp:Label runat="server" ID="SSN_customerID" Text="SSN&nbsp;/&nbsp;Customer ID"></asp:Label>
                        <asp:TextBox ID="SSN_customerIDText" runat="server" CssClass="form-control" placeholder="SSN&nbsp;/&nbsp;Customer ID"></asp:TextBox>
                        <asp:RegularExpressionValidator
                            ID="SSNSizeCheck"
                            ForeColor="Red"
                            runat="server"
                            ErrorMessage="Enter valid SSN/ID"
                            ControlToValidate="SSN_customerIDText"
                            ValidationGroup="SSN_ID"
                            CssClass="validationError"
                            ValidationExpression="^[0-9]{9}$" Font-Size="11px" />
                        <asp:Button ID="search" runat="server" Text="Search" OnClick="search_Click" class="btn btn-info form-control" CausesValidation="false" />
                      

                        <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>
            <div class="col-md-5 space"></div>
        </div>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
                <%-- no customer associated with given data found --%>
                <div class="row" id="noCustomer" runat="server">
                    <div class="col-md-1"></div>
                    <div class="col-md-6" role="alert">
                        <div class="alert alert-danger errorText" role="alert">
                            <i class="fa fa-exclamation-triangle fa-2x"></i>Customer not found with provided details. provide correct details.
                        </div>
                    </div>
                    <div class="col-md-5 space"></div>
                </div>

                <%-- Customer Found --%>
                <div class="row" id="customerFound" runat="server">
                    <div class="col-md-1"></div>
                    <div class="col-md-6">
                        <div class="jumbotron">
                            <div class="form-group">
                                <asp:Label Text="Customer ID" runat="server" ID="fixedCustomerIDlabel"></asp:Label>
                                <asp:TextBox ID="fixedCustomerIDText" runat="server" CssClass="form-control" Text="" Enabled="false"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label Text="Customer Name:" runat="server" ID="customerNameLabel"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="customerNameText" runat="server" ErrorMessage="Please enter Name"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                    ErrorMessage="Name must contain only alphabets"
                                    ControlToValidate="customerNameText"
                                    ValidationExpression="^[a-zA-Z.'\s]{3,50}$" ForeColor="Red">
                                </asp:RegularExpressionValidator>
                                <asp:TextBox ID="customerNameText" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label Text="Age" runat="server" ID="AgeLabel"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="AgeText" runat="server" ErrorMessage="Please enter Age"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Age must be in between 14 and 125" ControlToValidate="AgeText" ForeColor="Red" MinimumValue="14" MaximumValue="125" Type="Integer"></asp:RangeValidator>
                                <asp:TextBox ID="AgeText" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label Text="Address" runat="server" ID="permanentAddressLabel"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="AddressText1" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                    ErrorMessage="Address must contain only alphanumeric"
                                    ControlToValidate="AddressText1"
                                    ValidationExpression="^[a-zA-Z0-9.'\s]{3,40}$" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                                    ErrorMessage="Address must contain only alphanumeric"
                                    ControlToValidate="AddressText2"
                                    ValidationExpression="^[a-zA-Z0-9.'\s]{3,40}$" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="AddressText1" runat="server" CssClass="form-control" Text=""></asp:TextBox><br />
                                <asp:TextBox ID="AddressText2" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label Text="City" runat="server" ID="CityLabel"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ControlToValidate="CityText" runat="server" ErrorMessage="Please enter city"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                    ErrorMessage="City must contain only alphabets"
                                    ControlToValidate="CityText"
                                    ValidationExpression="^[a-zA-Z]{3,20}$" ForeColor="Red" />
                                <asp:TextBox ID="CityText" runat="server" CssClass="form-control" Text=""></asp:TextBox><br />
                            </div>
                            <div class="form-group">
                                <asp:Label Text="State" ID="stateLabel" runat="server"></asp:Label>
                                <asp:DropDownList ID="StateList" runat="server" OnSelectedIndexChanged="StateList_SelectedIndexChanged" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label Text="Pin" runat="server" ID="PinLabel"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" ControlToValidate="PinText" runat="server" ErrorMessage="Please enter pin"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator7"
                                    runat="server"
                                    ErrorMessage="Pin must be of 6 digit"
                                    ControlToValidate="PINText"
                                    ValidationExpression="^[0-9]{6}$"
                                    ForeColor="Red"/>
                                <asp:TextBox ID="PinText" runat="server" CssClass="form-control" Text=""></asp:TextBox><br />
                            </div>

                            <div class="form-group row">
                                <asp:Button ID="Update" runat="server" Text="Update" class="btn btn-info col-md-4 col-md-offset-1" OnClick="Update_Click" />
                                <asp:Button ID="reset" runat="server" Text="Reset" class="btn btn-default col-md-4 col-md-offset-1" OnClick="reset_Click" CausesValidation="false"/>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-5"></div>
                </div>

                <%-- updation successfull --%>
                <div class="row" id="updationSuccessful" runat="server">
                    <div class="col-md-1"></div>
                    <div class="col-md-6" role="alert">
                        <div class="alert alert-success errorText" role="alert">
                            <i class="fa fa-thumbs-o-up fa-2x"></i>Updation processed successfully.
                        </div>
                    </div>
                    <div class="col-md-5 space"></div>
                </div>

                <%-- Error while updation --%>
                <div class="row" id="errorInUpdation" runat="server">
                    <div class="col-md-1"></div>
                    <div class="col-md-6" role="alert">
                        <div class="alert alert-danger errorText" role="alert">
                            <i class="fa fa-exclamation-triangle fa-2x"></i>Customer Updation Failed.
                        </div>
                    </div>
                    <div class="col-md-5 space"></div>
                </div>

                <div class="row space" id="spacetoFullPage" runat="server"></div>

           <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>
</asp:Content>
