<%@ Page Title="" Language="C#" MasterPageFile="~/Scope.Master" AutoEventWireup="true" CodeBehind="CreateCustomer.aspx.cs" Inherits="BankRetail.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <%-- Checking whether there is any customer associated with SSN //showData(1) --%>
        <div class="row" id="CheckSSN" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <h2 class="jumboText" style="text-align: center; margin-bottom: 20px;">Create Customer </h2>
                <div class="jumbotron customJumbo">
                    <div class="form-group formGroupCustom" id="ssnID">
                        <div>
                            <asp:ScriptManager ID="ScriptManager1" runat="server" />
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Label runat="server" ID="SSNLabel" Text="SSN"></asp:Label>
                                <asp:TextBox ID="SSNText" runat="server" CssClass="form-control" ValidationGroup="SSN_ID" placeholder="SSN"></asp:TextBox>
                                <asp:RegularExpressionValidator
                                    ID="SSNSizeCheck"
                                    ForeColor="Red"
                                    runat="server"
                                    ErrorMessage="Should be 9 digit numeric."
                                    ControlToValidate="SSNText"
                                    ValidationGroup="SSN_ID"
                                    CssClass="validationError"
                                    ValidationExpression="^[0-9]{9}$" Font-Size="11px" />
                                <asp:RequiredFieldValidator
                                    CssClass="validationError"
                                    runat="server"
                                    ID="SSNRequiredCheck"
                                    ForeColor="Red"
                                    ControlToValidate="SSNText"
                                    ValidationGroup="SSN_ID"
                                    ErrorMessage="Please enter SSN!" Font-Size="11px" />
                                <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="SSN cannot be zero" ControlToValidate="AgeText" ForeColor="Red" MinimumValue="000000001" MaximumValue="999999999" Type="Integer"></asp:RangeValidator>
                                <asp:Button ID="search" runat="server" Text="Search" class="btn btn-info form-control" OnClick="search_Click" ValidationGroup="SSN_ID" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>


                </div>
            </div>
            <%--<div class="col-md-5 space"></div>--%>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <%-- If SSN exist in DB //showData(2) --%>
                <div class="row" id="SSNExist" runat="server">
                <div class="col-md-1"></div>
                    <div class="col-md-6" role="alert">
                        <div class="alert alert-danger errorText" role="alert">
                            <i class="fa fa-exclamation-triangle fa-2x"></i>There is already a customer with similar SSN. Please check and try again.
                        </div>
                    </div>
                    <%--<div class="col-md-5 space"></div>--%>
                </div>

                <%-- SSN doesn't exist. Create new customer //showData(3) --%>
                <div class="row" id="newCustomer" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <div class="jumbotron createForm">

                    <%--SSN--%>
                    <div class="form-group">
                        <asp:Label Text="SSN" runat="server" ID="fixedSSNLabel"></asp:Label>
                        <asp:TextBox ID="fixedSSNText" runat="server" CssClass="form-control" Text="SSN" Enabled="false"></asp:TextBox>
                    </div>

                    <%-- Customer Name --%>
                    <div class="form-group">
                        <asp:Label Text="Customer Name:" runat="server" ID="customerNameLabel"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="customerNameText" runat="server" ErrorMessage="Please enter name"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                                        ErrorMessage="Name should contain only alphabets" 
                                                        ControlToValidate="customerNameText" 
                                    ValidationExpression="^[a-zA-Z'\s]{3,50}$" ForeColor="Red">
                        </asp:RegularExpressionValidator>
                        <asp:TextBox ID="customerNameText" runat="server" CssClass="form-control" placeholder="Customer Name"></asp:TextBox>
                    </div>

                    <%-- Age --%>
                    <div class="form-group">
                        <asp:Label Text="Age" runat="server" ID="AgeLabel"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="AgeText" runat="server" ErrorMessage="Please enter age"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                                        ErrorMessage="Please enter valid age" 
                                                        ControlToValidate="AgeText" 
                                                        ValidationExpression="^[0-9]{1,3}$" ForeColor="Red"> 
                        </asp:RegularExpressionValidator>--%>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Age must be between 14 and 125" ControlToValidate="AgeText" ForeColor="Red" MinimumValue="14" MaximumValue="125" Type="Integer"></asp:RangeValidator>
                        <asp:TextBox ID="AgeText" runat="server" CssClass="form-control" placeholder="Age"></asp:TextBox>
                            </div>


                    <%-- Address --%>
                    <asp:Label Text="Address" runat="server" ID="AddressLabel" Font-Bold="true"></asp:Label>
                    <div class="form-group">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="AddressText1" runat="server" ErrorMessage="Please enter Address"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                            ErrorMessage="Address must be only alphanumeric"
                            ControlToValidate="AddressText1"
                                    ValidationExpression="^[a-zA-Z0-9.'\s]{3,40}$" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                            ErrorMessage="Address must be only alphanumeric"
                            ControlToValidate="AddressText2"
                                    ValidationExpression="^[a-zA-Z0-9.'\s]{3,40}$" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="AddressText1" runat="server" CssClass="form-control" placeholder="Line1"></asp:TextBox><br />
                        <asp:TextBox ID="AddressText2" runat="server" CssClass="form-control" placeholder="Line2"></asp:TextBox>
                    </div>

                    <%-- City --%>
                    <div class="form-group">
                        <asp:Label Text="City" runat="server" ID="cityLabel"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ControlToValidate="CityText" runat="server" ErrorMessage="Please enter city"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"     
                                    ErrorMessage="City must contain only alphabets" 
                                    ControlToValidate="CityText"     
                                    ValidationExpression="^[a-zA-Z]{3,20}$" ForeColor="Red" />
                       
                        <asp:TextBox ID="CityText" runat="server" CssClass="form-control" placeholder="City"></asp:TextBox>
                    </div>
                    <%-- States --%>
                    <div class="form-group">
                        <asp:Label Text="State" ID="stateLabel" runat="server"></asp:Label>
                                <asp:DropDownList ID="StateList" runat="server" OnSelectedIndexChanged="StateList_SelectedIndexChanged" CssClass="form-control">
                        </asp:DropDownList>
                    </div>

                    <%-- PIN --%>
                    <div class="form-group">
                       <asp:Label Text="PIN" ID="PINLabel" runat="server"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" ControlToValidate="PINText" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                           <asp:RegularExpressionValidator 
                               ID="RegularExpressionValidator7" 
                               runat="server"     
                               ErrorMessage="Pin must be of six digits" 
                               ControlToValidate="PINText"     
                               ValidationExpression="^[0-9]{6}$" 
                               ForeColor="Red" />
                                <asp:TextBox ID="PINText" runat="server" CssClass="form-control" placeholder="PIN"></asp:TextBox>
                            </div>
                            <hr />

                    <div class="form-group row">
                        <asp:Button ID="Create" runat="server" Text="Create" class="btn btn-info col-md-4 col-md-offset-1" OnClick="FormSubmit" />
                        <asp:Button ID="reset" runat="server" Text="Reset" class="btn btn-default col-md-4 col-md-offset-1" OnClick="reset_Click" />
                    </div>
                </div>
            </div>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>

                <%-- Customer creation successful alert //showData(4) --%>
                <div class="row" id="creationSuccessful" runat="server">
                    <div class="col-md-1"></div>
                    <div class="col-md-6 top" role="alert">
                        <div class="alert alert-success errorText" role="alert">
                            <i class="fa fa-thumbs-o-up fa-2x"></i><br/><b> Customer creation Initiated successfully.</b>
                            <asp:Label ID="cID" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-5 space"></div>
                </div>

                <%-- Error while customer creation // showData(5) --%>
                <div class="row" id="creationError" runat="server">
                    <div class="col-md-1"></div>
                    <div class="col-md-6 top" role="alert">
                        <div class="alert alert-danger errorText" role="alert">
                            <i class="fa fa-exclamation-triangle fa-2x"></i><b>Customer creation could not be processed. Try again.</b>
                        </div>
                    </div>
                    <div class="col-md-5 space"></div>
                </div>

                <div class="row space" id="spacetoFullPage" runat="server"></div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>



    


<%-- CustSSN numeric(9,0),
custID numeric(9,0),
CustName varchar(20),
CustAge numeric(3,0), 
AddrLine1 varchar(40), 
AddrLine2 varchar(40), 
CityName varchar(20), 
StateName varchar(20)
    --%>
</asp:Content>
