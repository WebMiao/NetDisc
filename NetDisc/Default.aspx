<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NetDisc.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Scripts/layui/css/layui.css" rel="stylesheet" />
    <link href="Scripts/layui/css/layim.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:900px; margin:0 auto">
    <div class="layui-layer-title" style="height:50px;text-align:center" >
        <!--<asp:Image ID="chatroom" runat="server" ImageUrl="Icon/4.png" Height="100px" Width="200px"/>-->
        <asp:Label ID="lbTitle" runat="server" Text="" Font-Names="Century Gothic" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
    </div>       
<!--预留聊天室图片-->  <!--可以的话加上房间信息：名称--> 

    <div class="layim-chat-box" > 
        <div class="layim-chat layim-chat-friend layui-show">
            <div style="display:none">
                <asp:Image id="image" runat="server"  Height="55px" Width="64px"  />
            </div>   <!--预留去后端取数据的入口-->
            <div style="display:none"> 
                <input type="text" id="room" />
            </div>
            <div class="layim-chat-main" style="height: 450px;">
                <ul id="dis"> </ul>
            </div>
            <div class="layim-chat-footer">  
                <div class="layim-chat-textarea">
                    <textarea id="msg"  class="layui-textarea" style="max-width:100%"></textarea>
                </div> 
                <div class="layim-chat-bottom">
                    <div class="layim-chat-send">
                        <span class="layim-send-btn" id="broadcast" layim-event="send" >Send</span>
                        <input type="hidden" id="name" /> 
                    </div>
                </div>
            </div>
         </div> 
       </div>
    </div>
     <div style="display:none">
        <input type="hidden" id="url" /> 
    </div>
<script src="Scripts/jquery-3.3.1.js" type="text/javascript"></script>
<script src="Scripts/jquery.signalR-2.2.2.min.js" type="text/javascript"></script>
<script src="signalr/hubs" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            // proxy created on the fly          
            var chat = $.connection.chat;

            // declare a function on the chat hub so the server can invoke it          
            chat.client.addmessage = function (group, message, name,url) {
                var mydate = new Date();
                var datestr = mydate.toDateString();
                var encodedName = $('<div />').text(name).html();
                var encodedMsg = $('<div />').text(message).html();
                if (name == $('#name').val()) {
                    $('#dis').append('<li class="layim-chat-mine"><div class="layim-chat-user"><img src="'+url+'"/><cite><i>' + getNowFormatDate() + '</i>' + encodedName +
                        '</cite></div> <div class="layim-chat-text">' + encodedMsg + '</div> </li >');
                }
                else {
                    $('#dis').append('<li><div class="layim-chat-user"><image src="'+url+'"/><cite>' + encodedName+' '+getNowFormatDate() + '<i>' 
                        + '</i></cite></div><div class="layim-chat-text">' + encodedMsg + '</div></li>');
                }



                // $('#dis').append('<li>' + message + name + '</li>');
            };
            //$('#room').val(prompt('Enter your room:', ''));
            //$('#name').val(prompt('Enter your name:', '')); //输入
            //$('#msg').focus();

            const urlParams = new URLSearchParams(window.location.search);
            const coursename = urlParams.get('coursename');
            const courseid = urlParams.get('courseid');
            $('#url').val('<%= Session["url"] %>');
            $('#room').val(coursename);
            $('#name').val('<%= Session["UserName"] %>');
            url = $('#url').val();

            $.connection.hub.start(function () {
                chat.server.join($('#room').val());
            });
            // start the connection
            $.connection.hub.start().done(function () {

                $(document).keypress(function (e) {  //按Enter键发送
                    if (e.keyCode == 13) {
                        $('#broadcast').click();
                    }
                })

                $("#broadcast").click(function () {
                    // call the chat method on the server
                    //chat.server.send($('#msg').val());
                    chat.server.send({ msg: $('#msg').val(), group: $('#room').val(), name: $('#name').val(), url: $('#url').val()}); // +url作为参数回传
                    $('#msg').val('').focus();
                });
            });
        });
        function getNowFormatDate() {
            var date = new Date();
            var seperator1 = "-";
            var seperator2 = ":";
            var month = date.getMonth() + 1;
            var strDate = date.getDate();
            if (month >= 1 && month <= 9) {
                month = "0" + month;
            }
            if (strDate >= 0 && strDate <= 9) {
                strDate = "0" + strDate;
            }
            var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
                + " " + date.getHours() + seperator2 + date.getMinutes()
                + seperator2 + date.getSeconds();
            return currentdate;
        }

</script>

</asp:Content>

    



