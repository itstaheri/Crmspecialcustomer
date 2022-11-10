using Frameworkes.Auth;
using Frameworks;
using Message.Application.Contract;
using Message.Application.Services;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Crmspecialcustomer.Chat
{
    public class ChatHub : Hub
    {
        private readonly IMessageApplication _messageApplication;
        private readonly IAuth _auth;

        public ChatHub(IMessageApplication messageApplication, IAuth auth)
        {
            _messageApplication = messageApplication;
            _auth = auth;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
      
        public async Task SendMessage(string[] toUsersId, string subject, string bodyMessage)
        {
           // string name =;
            //Get current userId
            var fromUserId = _auth.GetCurrentId();
            //Create meesage
            await _messageApplication.CreateMessage(new CreateMessageViewModel { BodyMessage = bodyMessage, FormUserId = fromUserId, Subject = subject, ToUsersId = toUsersId });
            //Callback and send datetime & subject for show in UI
           await Clients.All.SendAsync("ReceiveMessage", DateTime.Now.ToFarsiFull(), subject);
           // await Clients.Groups(toUsersId).SendAsync("ReceiveMessage", DateTime.Now.ToFarsiFull(), subject);

           
        }
        public async Task CheckNotification()
        {
            var userMessages = await _messageApplication.GetUnreadMessageFromUser(_auth.GetCurrentId());
            if (userMessages.Count > 0)
            {
                await Clients.All.SendAsync("ReceiveUnreadMessage", _auth.GetCurrentId(), userMessages);
            }

        }


    }
}
