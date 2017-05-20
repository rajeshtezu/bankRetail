<%@ Page Title="" Language="C#" MasterPageFile="~/Scope.Master" AutoEventWireup="true" CodeBehind="CustomerStatus.aspx.cs" EnableEventValidation="false" Inherits="BankRetail.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
    </div>
    
    <h2> CUSTOMER STATUS   </h2>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table"  AlternatingRowStyle-BackColor="#ccffff" HorizontalAlign="Center" RowStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="Customer ID">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("CustomerID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer SSN ID">
                        <ItemTemplate>
                            <asp:Label ID="CustSSNID" runat="server" Text='<%# Eval("CustomerSSN") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="CustStatus" runat="server" Text='<%# Eval("CustomerStatusValue") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Message">
                        <ItemTemplate>
                            <asp:Label ID="message" runat="server" Text='<%# Eval("CustomerMessage") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Updated">
                        <ItemTemplate>
                            <asp:Label ID="lastUpdated" runat="server" Text='<%# Eval("LastUpdated") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="REFRESH">
                        <ItemTemplate>
                            <asp:Button 
                                ID="refresh" 
                                runat="server" 
                                CssClass="btn btn-success"
                                CommandName="refresh"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                Text="REFRESH" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="margin-bottom: 600px;"></div>
</asp:Content>
