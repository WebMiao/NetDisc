<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NetDisc.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="margin:0 auto; width:400px; height:200px; padding-left:200px; padding-right:200px; padding-top:50px">
        <div style="margin:0 auto; width:50px;">
            <asp:Label ID="title" runat="server" Text="Login" Font-Names="Century Gothic" Font-Size="Large" ForeColor="Black" Font-Bold="True"></asp:Label>
        </div>
        <div style="margin:0 auto;  width:300px">
        <table>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lbUsername" runat="server" Text="Username: " Font-Names="Century Gothic" Font-Size="Medium" ForeColor="Black"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="tbUsername" runat="server" Width="185px" Height="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lbPassword" runat="server" Text="Password: " Font-Names="Century Gothic" Font-Size="Medium" ForeColor="Black"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="tbPassword" runat="server" Width="185px" Height="20px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>
        </div>
        <div style="margin:0 auto; width:300px;">
            <div style="float:right; width:130px">
                <asp:Button ID="btnClear" runat="server" Text="clear" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" BackColor="#666666" BorderStyle="None" Width="130px" OnClick="btnClear_Click"/>

            </div>
            <asp:Button ID="btnLogin" runat="server" Text="login" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" BackColor="#666666" BorderStyle="None" Width="130px" OnClick="btnLogin_Click"/>
            
        </div>
        <div style="margin:0 auto; width:400px; padding-top:10px">
                <asp:Label ID="Message" runat="server" Text="" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </div>
    </div>

</asp:Content>
