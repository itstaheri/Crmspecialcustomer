using Frameworkes.Auth;
using Message.Application.Contract;
using Message.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Contract;
using Request.Application.Contract.Request;
using Service.Application.Contract.Material;
using User.Application.Services;

namespace Crmspecialcustomer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IOrderApplication _orderApplication;
        private readonly IUserApplication _userApplication;
        private readonly IRequestApplication _requestApplication;
        private readonly IMaterialApplication _materialApplication;
        private readonly IMessageApplication _messageApplication;
        private readonly IAuth _auth;

        public HomeController(IOrderApplication orderApplication, IUserApplication userApplication, IRequestApplication requestApplication, IMaterialApplication materialApplication, IMessageApplication messageApplication, IAuth auth)
        {
            _orderApplication = orderApplication;
            _userApplication = userApplication;
            _requestApplication = requestApplication;
            _materialApplication = materialApplication;
            _messageApplication = messageApplication;
            _auth = auth;
        }

        public async Task<IActionResult> Index()
        {
            var order = (await _orderApplication.GetAllOrdersInfo(null)).Select(x => x.IsPaidInFull).ToList();
            ViewBag.OrderCountAll = order.Count();
            ViewBag.OrderIsPaid = order.Where(x=>x == true).Count();
            ViewBag.OrderIsNotPaid = order.Where(x=>x == false).Count();

            var request = (await _requestApplication.GetAllRequestInfo(null)).Select(x=>x.IsConfirm).ToList();
            ViewBag.RequestCountAll = request.Count();
            ViewBag.RequestIsConfirm = request.Where(x=>x == true).Count();
            ViewBag.RequestIsNotConfirmed = request.Where(x=>x == false).Count();
            var userMessages = (await _messageApplication.GetAllMessages(new MessageSearchViewModel()));
            ViewBag.UserMessagesCount = userMessages.Count();
            ViewBag.UnreadMessages = userMessages.Where(x=>!x.IsReadByCurrentUser).Count();
            ViewBag.ReadedMessages= userMessages.Where(x => x.IsReadByCurrentUser).Count();
            return View();


        }
        public async Task<IActionResult> Logout()
        {
            await _userApplication.Logout();
            return Redirect("/");
        }
        public async Task<IActionResult> GetMessages()
        {
           var messages = await _messageApplication.GetUnreadMessageFromUser(_auth.GetCurrentId());
            return new JsonResult(messages);
        }
      
    }
}
