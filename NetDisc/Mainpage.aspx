<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Mainpage.aspx.cs" Inherits="NetDisc.Mainpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="margin:0 auto; width:950px; padding:30px">
        <div style="margin:0 auto; padding:5px" class="auto-style2">
            <asp:Label ID="lbNewsTitle" runat="server" Text="My Courses" Font-Names="Century Gothic" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
        </div>
        <div  style="margin:0 auto; width:900px; height:500px">

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebDiskConnectionString %>" SelectCommand="SELECT [coursename] FROM [courses]"></asp:SqlDataSource>

            <asp:bulletedlist runat="server" DataSourceID="SqlDataSource1" DataTextField="coursename" DataValueField="coursename" DisplayMode="LinkButton" Font-Names="Century Gothic" Font-Size="X-Large" ForeColor="Black" BulletStyle="Numbered" OnClick="Unnamed1_Click">

            </asp:bulletedlist>
            <div style="margin:0 auto; width:250px; height:60px; padding-top:30px" >
                <asp:Button ID="btnAdd" runat="server" Text="Add new Courses" Font-Names="Century Gothic" Font-Size="X-Large" ForeColor="White" BackColor="#0066CC" BorderStyle="None" Width="250px" OnClick="btnAdd_Click"/>
            </div>
            <div style="margin:0 auto; width:350px; height:100px;">
                <asp:Label ID="lbMessage" runat="server" Text="" Font-Names="Century Gothic" Font-Size="Large" ForeColor="Red"></asp:Label>
            </div>
            </div>
        </div>
</asp:Content>
