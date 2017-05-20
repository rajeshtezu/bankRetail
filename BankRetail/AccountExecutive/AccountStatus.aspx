<%@ Page Title="" Language="C#" MasterPageFile="~/Scope.Master" AutoEventWireup="true" CodeBehind="AccountStatus.aspx.cs" Inherits="BankRetail.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <%--customer ID, account type, status, message, Last updated and refresh button--%>

    <h2>Account Status</h2>

    <div>
        <asp:ScriptManager ID="ScriptManager" runat="server" />
    </div>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <asp:GridView ID="AccStatusGridView" AutoGenerateColumns="False" CssClass="table" runat="server" OnRowCommand="AccStatusGridView_RowCommand"  AlternatingRowStyle-BackColor="#ccffff" HorizontalAlign="Center" RowStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="Customer ID">
                        <ItemTemplate>
                            <asp:Label ID="CustIdLabel" runat="server" Text='<%# Eval("CustId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Account Id">
                        <ItemTemplate>
                            <asp:Label ID="AccIdLabel" runat="server" Text='<%# Eval("AccId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Account Type">
                        <ItemTemplate>
                            <asp:Label ID="AccTypeLabel" runat="server" Text='<%# Eval("AccType") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Message">
                        <ItemTemplate>
                            <asp:Label ID="MessageLabel" runat="server" Text='<%# Eval("Msg") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Updated">
                        <ItemTemplate>
                            <asp:Label ID="LastUpdateLabel" runat="server" Text='<%# Eval("LastUpdated") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Refresh">
                        <ItemTemplate>
                            <%--<asp:Button ID="Button1" runat="server" Text="Refresh" CommandArgument='<%# Eval("AccId") %>'/>--%>
                            <asp:LinkButton CssClass="btn btn-success" ID="LinkButton1" runat="server" CommandArgument='<%# Eval("AccId") %>'>Refresh</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            <div style="min-height: 500px;"></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
