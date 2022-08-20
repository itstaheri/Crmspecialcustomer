using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using User.Application.Common;
using User.Application.Contract;
using User.Application.Services;

namespace Crmspecialcustomer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserApplication _Userapplication;

        public AccountController(IUserApplication userapplication)
        {
            _Userapplication = userapplication;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel commend)
        {
            var loginResult = await _Userapplication.Login(commend);
            if (loginResult.Message==nameof(LoginResultMessage.WrongUsername))
            {
                ModelState.AddModelError(commend.Code,LoginResultMessage.WrongUsername);
                return View();
            }
            else if (loginResult.Message == nameof(LoginResultMessage.WrongPassword))
            {
                ModelState.AddModelError(commend.Code, LoginResultMessage.WrongPassword);
                return View();
            }
            else if (loginResult.Message == nameof(LoginResultMessage.SuccessLogin))
            {
                return RedirectToAction();
            }
            else
            {
                return View();
            }

        }

       
    }
}