﻿using Microsoft.AspNetCore.SignalR;

namespace ETicaretAPI.SignalR.Hubs
{
    public class ProductHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}