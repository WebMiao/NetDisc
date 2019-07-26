<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NetDisc.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <style type="text/css">
        .auto-style2 {
            height: 30px;
            width: 190px;
        }
        .auto-style6 {
            height: 30px;
            width: 180px;
        }
    </style>
<div style="margin:0 auto; width:600px; height:200px; padding-left:100px; padding-right:100px; padding-top:50px">
        <div style=" width:300px; padding-bottom:10px">
            <asp:Label ID="title" runat="server" Text="Please Fill it with your information:" Font-Names="Century Gothic" Font-Size="Large" ForeColor="Black"></asp:Label>
        </div>
        <div style="margin:0 auto; width:400px">
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
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lbUsertype" runat="server" Text="Choose your user type: " Font-Names="Century Gothic" Font-Size="Medium" ForeColor="Black"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:RadioButton ID="rbTeacher" Checked="true" runat="server" GroupName="Type" Text="Teacher" Font-Names="Century Gothic" Font-Size="Small"/>
                    <asp:RadioButton ID="rbStudent" Checked="false" runat="server" GroupName="Type" Text="Student" Font-Names="Century Gothic" Font-Size="Small"/>
                </td>
            </tr>
        </table>
        </div>
        <div style="margin:0 auto; width:300px;">
            <div style="float:right; width:130px">
                <asp:Button ID="btnClear" runat="server" Text="Clear" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" BackColor="#666666" BorderStyle="None" Width="130px" OnClick="btnClear_Click"/>
            </div>
            <asp:Button ID="btnReg" runat="server" Text="Register" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" BackColor="#666666" BorderStyle="None" Width="130px" OnClick="btnReg_Click"/>
        </div>
        <div style="margin:0 auto; width:400px; padding-top:10px">
                <asp:Label ID="Message" runat="server" Text="" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>
