<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ElectricityBillingSystem.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin Login</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div style ="text-align:center; margin-top:100px;">
            <h2> Login </h2>
            <asp:Label ID="lblUser" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblPass" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br /><br />
             <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
</asp:Content>
   

