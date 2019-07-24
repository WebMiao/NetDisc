using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace NetDisc
{
    public class Chat : Hub
    {
        public void Join(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
        }

        public void Send(MyMessage message)
        {
            // Call the addMessage method on all clients            
            //Clients.All.addMessage(message.Msg);
            Clients.Group(message.Group).addMessage(message.Group, message.Msg, message.Name);
        }
    }


    public class MyMessage
    {
        public string Msg { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }

        //头像地址
    }
}