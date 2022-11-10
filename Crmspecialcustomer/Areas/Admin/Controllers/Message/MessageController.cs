using Crmspecialcustomer.HostFrameworks.Pagination;
using Frameworkes.Auth;
using Message.Application.Contract;
using Message.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using User.Application.Services;

namespace Crmspecialcustomer.Areas.Admin.Controllers.Message
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IUserApplication _userApplication;
        private readonly IMessageApplication _messageApplication;
        private readonly IAuth _auth;

        public MessageController(IUserApplication userApplication, IMessageApplication messageApplication, IAuth auth)
        {
            _userApplication = userApplication;
            _messageApplication = messageApplication;
            _auth = auth;
        }

        public async Task<IActionResult> Index(MessageSearchViewModel model)
        {
            //get users by roles 
            ViewBag.ManagerUsers = (await _userApplication.GetAllInfo()).Where(x => x.RoleId == 1).ToList();
            ViewBag.AdminUsers = (await _userApplication.GetAllInfo()).Where(x => x.RoleId == 2).ToList();

            var messages = await _messageApplication.GetAllMessages(_auth.GetCurrentId());

            #region pagination 
            PaginationViewModel<MessageViewModel> page = new PaginationViewModel<MessageViewModel>();
            if (messages.Count >= 9)
            {
                page.CurrentPage = model.PageId;
                page.PageCount = (int)Math.Ceiling(messages.Count / (double)9);
                page.Models = messages.OrderBy(x => x.CreationDate).Skip((model.PageId - 1) * 9).Take(9).ToList();

            }
            else
            {
                page.CurrentPage = model.PageId > 0 ? model.PageId : 1;
                page.PageCount = 1;
                page.Models = messages;
            }
            #endregion

            return View(page);
        }
      
        public async Task<IActionResult> HideMessage(long MessageId)
        {
            await _messageApplication.HideMessage(MessageId);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ShowMessage(long MessageId)
        {
            await _messageApplication.ShowMessage(MessageId);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveMessage(long MessageId)
        {
            await _messageApplication.RemoveMessage(MessageId);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CreateMessage()
        {
            ViewBag.Users = (await _userApplication.GetAllInfo()).Select(x=>new SelectListItem(x.Username,x.UserId.ToString()));
            return View();

        }
        public async Task<IActionResult> Create(CreateMessageViewModel model)
        {
            //await _messageApplication.CreateMessage(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Message(long MessageId)
        {
            await _messageApplication.IsRead(MessageId, _auth.GetCurrentId());
            var message =await  _messageApplication.GetMessageDetailBy(MessageId);
            return View(message);
        }
        public async Task<IActionResult> GetAdminUsers()
        {
            var admins = (await _userApplication.GetAllInfo()).Where(x => x.RoleId == 2).Select(x => new { x.UserId, x.Username }).ToList();
            return new JsonResult(admins);
        }
        public async Task<IActionResult> GetManagerUsers()
        {
            var managers = (await _userApplication.GetAllInfo()).Where(x => x.RoleId == 1).Select(x => new { x.UserId, x.Username }).ToList();
            return new JsonResult(managers);
        }
    }
}
