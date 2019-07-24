<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="NetDisc.Course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:0 auto; width:900px; padding:5px">
        <asp:Label ID="lbNewsTitle" runat="server" Font-Names="Century Gothic" Font-Size="XX-Large" ForeColor="Black" Font-Bold="True" OnDataBinding="Page_Load"></asp:Label>
            <div style="float:left; width:200px;">
            <div style=" width:150px; padding-top:50px;">
                <asp:imageButton ID="btnChat" runat="server" Text="Course Chat room" Font-Names="Century Gothic" Font-Size="X-Large" ForeColor="White" BackColor="#B9D1EA" BorderStyle="None" Width="50px" height ="50px" ImageUrl="~/images/chat.png" OnClick="btnChat_Click"></asp:imageButton>
                <asp:label runat="server" text="Char room" Font-Names="Century Gothic" Font-Size="Large" ForeColor="Black" height="40px"></asp:label>
            </div>
                <asp:imageButton ID="btnFile" runat="server" Text="Course files" Font-Names="Century Gothic" Font-Size="X-Large" ForeColor="White" BackColor="#B9D1EA" BorderStyle="None" Width="50px" height ="50px" ImageUrl="~/images/openedfolderL.png" OnClick="btnFile_Click"/>
                <asp:label runat="server" text="Course Files" Font-Names="Century Gothic" Font-Size="Large" ForeColor="Black" height="40px"></asp:label>
        </div>
    </div>
</asp:Content>
