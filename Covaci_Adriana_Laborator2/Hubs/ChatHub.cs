using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Covaci_Adriana_Laborator2.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
          //  Context.User.Identity.Name
           Console.WriteLine(Context.User.Identity.Name);
        }
    }
}
