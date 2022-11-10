using Frameworkes.Auth;
using Message.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crmspecialcustomer.Areas.Admin.ViewComponents
{
    public class DropDownNotificationViewComponent : ViewComponent
    {
        private readonly IMessageApplication _messageApplication;
        private readonly IAuth _auth;

        public DropDownNotificationViewComponent(IMessageApplication messageApplication, IAuth auth)
        {
            _messageApplication = messageApplication;
            _auth = auth;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var UnreadMessages = await _messageApplication.GetUnreadMessageFromUser(_auth.GetCurrentId());
            return View(UnreadMessages);
        }
    }
}
