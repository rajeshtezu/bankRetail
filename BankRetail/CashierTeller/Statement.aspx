<%@ Page Title="" Language="C#" MasterPageFile="~/Cashier.Master" AutoEventWireup="true" CodeBehind="Statement.aspx.cs" Inherits="BankRetail.WebForm14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .printBtn {
            margin-left: 98%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" id="searchCustomerForm" runat="server">
            <div class="col-md-1"></div>
            <div class="col-md-6">

                <h2 class="jumboText"><b>Get Statement</b> </h2>
                <div class="jumbotron customJumbo">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="ACCOUNT ID"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Field" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            ID="AccountSizeCheck"
                            ForeColor="Red"
                            runat="server"
                            ErrorMessage="Should be 9 digit numeric."
                            ControlToValidate="TextBox1"
                            CssClass="validationError"
                            ValidationExpression="^[0-9]{9}$" Font-Size="11px" />

                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="LAST N TRANSACTIONS"></asp:Label>
                        <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <asp:Button ID="Button1" runat="server" Text="View Transactions" class="btn btn-info form-control" OnClick="Button1_Click" />
                </div>
            </div>


        </div>
    </div>

    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-lg-6 col-md-6 col-md-offset-1">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table">
                <Columns>
                    <asp:TemplateField HeaderText="DATE">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TRN_DESCRIPTION">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Trn_description") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TRN_TYPE">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Trn_type") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="BALANCE">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("Balance") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%--<asp:Button ID="Button2" runat="server" Text="Print" CssClass="btn btn-success btn-lg printBtn" OnClick="Button2_Click" />--%>

        </div>

    </div>


    <div class="space"></div>
</asp:Content>
