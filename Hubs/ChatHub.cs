using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public static int UsersCounter = 0;

        // Online users
        public async Task SendUsersCounter()
        {
            await Clients.All.SendAsync("GetUsersCounter", UsersCounter.ToString());
        }

        // Chat
        public async Task Send(string message, string userName)
        {
            await Clients.All.SendAsync("Receive", message, userName);
        }

        public override async Task OnConnectedAsync()
        {
            //increase when the user connect
            UsersCounter++;
            await SendUsersCounter();

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            //decrease when the user disconnect 
            UsersCounter--;
            await SendUsersCounter();
            await base.OnDisconnectedAsync(exception);
        }
    }
}
