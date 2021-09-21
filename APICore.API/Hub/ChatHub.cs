﻿using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICore.API.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private static readonly Dictionary<string, string> Users = new Dictionary<string, string>();

        public async Task Register(string username)
        {
            if (Users.ContainsKey(username))
            {
                Users.Add(username, this.Context.ConnectionId);
            }

            await Clients.All.SendAsync(WebSocketActions.USER_JOINED, username);
        }

        public async Task Leave(string username)
        {
            Users.Remove(username);
            await Clients.All.SendAsync(WebSocketActions.USER_LEFT, username);
        }

        public async Task Send(string username, string message)
        {
            await Clients.All.SendAsync(WebSocketActions.MESSAGE_RECEIVED, username, message);
        }

        public struct WebSocketActions
        {
            public static readonly string MESSAGE_RECEIVED = "messageReceived";
            public static readonly string USER_LEFT = "userLeft";
            public static readonly string USER_JOINED = "userJoined";
        }
    }
}