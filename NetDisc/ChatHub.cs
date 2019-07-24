using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace NetDisc
{
    public class ChatHub : Hub
    {
        //声明静态变量存储当前在线用户
        public static class UserHandler
        {
            public static Dictionary<string, string> ConnectedIds = new Dictionary<string, string>();
        }

        //用户进入页面时执行的（连接操作）
        public void userConnected(string name)
        {
            //进行编码，防止XSS攻击
            name = HttpUtility.HtmlEncode(name);
            string message = "用户 " + name + " 登录";

            //发送信息给其他人
            Clients.Others.addList(Context.ConnectionId, name);
            //   Clients.Others.hello(message);

            //发送信息给自己，并显示上线清单
            Clients.Caller.getList(UserHandler.ConnectedIds.Select(p => new { id = p.Key, name = p.Value }).ToList());

            //新增目前使用者上线清单
            UserHandler.ConnectedIds.Add(Context.ConnectionId, name);
        }

        //发送信息给所有人
        public void sendAllMessage(string message)
        {
            //   message = HttpUtility.HtmlEncode(message);
            var name = UserHandler.ConnectedIds.Where(p => p.Key == Context.ConnectionId).FirstOrDefault().Value;
            //  message = name + "说：" + message;
            Clients.All.sendAllMessge(message, name);
        }

        //发送信息给特定人
        public void sendMessage(string ToId, string message)
        {
            // message = HttpUtility.HtmlEncode(message);
            var fromName = UserHandler.ConnectedIds.Where(p => p.Key == Context.ConnectionId).FirstOrDefault().Value;
            // message = fromName + " <span style='color:red'>悄悄说</span>：" + message;
            Clients.Client(ToId).sendMessage(message, fromName);
            Clients.Client(Context.ConnectionId).sendMessage(message, fromName);
        }

    }
}