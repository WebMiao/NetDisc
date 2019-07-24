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
            <div style="margin:0 auto; width:350px; height:50px;">
                <asp:Label ID="lbMessage" runat="server" Text="" Font-Names="Century Gothic" Font-Size="Large" ForeColor="Red"></asp:Label>
            </div>
            <asp:table ID="Addtable" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lbname" runat="server" Text="Course Name: " Font-Names="Century Gothic" Font-Size="Large"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="tbname" runat="server" Font-Names="Century Gothic" Font-Size="Large" Width="600px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lbDescrip" runat="server" Text="Course Description: " Font-Names="Century Gothic" Font-Size="Large"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="tbDescription" runat="server" Font-Names="Century Gothic" Font-Size="Large" Width="600px" Height="134px" TextMode="MultiLine"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:table>
            </div>
            <div style="margin:0 auto; width:350px; height:60px; padding-top:30px" >
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm add new Courses" Font-Names="Century Gothic" Font-Size="X-Large" ForeColor="White" BackColor="#0066CC" BorderStyle="None" Width="350px" OnClick="btnConfirm_Click"/>
            </div>
        </div>
</asp:Content>
