<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Enroll.aspx.cs" Inherits="NetDisc.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:0 auto; width:950px; padding:30px">
        <asp:BulletedList ID="BulletedList1" runat="server" BulletStyle="Numbered" DisplayMode="LinkButton" OnClick="BulletedList1_Click" Font-Names="Century Gothic" Font-Size="Large" ForeColor="Black"></asp:BulletedList>
        <asp:Label ID="lbMessage" runat="server" Text="" Font-Names="Century Gothic" Font-Size="Large" ForeColor="red"></asp:Label>
    </div>
</asp:Content>
