using Microsoft.AspNetCore.SignalR;

namespace DIFAChat.API.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage (string user, string message)
        {
            await Clients.All.SendAsync (user, message);
        }
    }
}
