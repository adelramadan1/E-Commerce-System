using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ShoppingCartSystem
{
    [HubName("chat")]
    public class ChatHub:Hub
    {
        public void SendMessage(string Message)
        {
            Clients.All.RecieveMessage(Message);
        }
        //public void ReceiveMessage(string Message)
        //{
        //    Clients.All.ReceiveMessage(Message);
        //}
    }
}