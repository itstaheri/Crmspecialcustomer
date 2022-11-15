using Frameworkes.Auth;
using Message.Application.Contract;
using Message.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crmspecialcustomer.Areas.Admin.ViewComponents
{
    public class MessageListViewComponent : ViewComponent
    {
        private readonly IMessageApplication _messageApplication;
        private readonly IAuth _auth;

        public MessageListViewComponent(IMessageApplication messageApplication, IAuth auth)
        {
            _messageApplication = messageApplication;
            _auth = auth;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userMessages = await _messageApplication.GetAllMessages(new MessageSearchViewModel());
            return View(userMessages.Take(4)?.ToList());
        }
    }
}
