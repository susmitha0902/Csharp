<%@ Page Title="Admin Dashboard" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ElectricityBillingSystem.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin Dashboard</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align:center;">Electricity Bill Generation</h2>
        <div style ="text-align:center; margin-top:20px;">
            <asp:Label ID="lbl" runat="server" Text="Number of records to be inserted: "></asp:Label>
            <asp:TextBox ID="txt" runat="server"></asp:TextBox>
            <asp:Button ID="btnSetN" runat="server" Text="Set Total Bills" OnClick="btnSetN_Click" />
            <br /><br />
            <asp:Label ID="lblConsumerNo" runat="server" Text ="Consumer Number: " />
            <asp:TextBox ID="txtConsumerNo" runat="server" /> <br /><br />
            <asp:Label ID="lblConsumerName" runat="server" Text ="Consumer Name: " />
            <asp:TextBox ID="txtConsumerName" runat="server" /> <br /><br />
            <asp:Label ID="lblUnits" runat="server" Text ="Units Consumed: " />
            <asp:TextBox ID="txtUnits" runat="server" /> <br /><br />
            <asp:Button ID="btnGenerate" runat="server" Text="Generate Bill" OnClick="btnGenerate_Click" /><br /><br />
            <asp:Label ID="lblResult" runat="server" ForeColor="Green"></asp:Label>
        </div>
    <hr />
    <div style ="text-align:center; margin-top:20px;">
    <asp:Label ID="lblN" runat="server" Text="Enter N(number of latest bills you would like to view): "></asp:Label>
    <asp:TextBox ID="txtN" runat="server"></asp:TextBox>
    <asp:Button ID="btnShow" runat="server" Text="Show Bills" OnClick="btnShow_Click" /><br /><br />
    <asp:Label ID="Label" runat="server" ForeColor="Red"></asp:Label>
    <br /><br />
    <div style ="display:flex; justify-content:center;"><asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="true"></asp:GridView></div
    </div> 
    <br /><br />
</asp:Content>

