using Frameworkes.Auth;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IAuth _auth;

        public AccountController(IUserApplication userapplication, IAuth auth)
        {
            _Userapplication = userapplication;
            _auth = auth;
        }

        public IActionResult Index()
        {
            if (_auth.IsAuthenticated()) return Redirect("/Admin/Home/Index");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel commend)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            
            var loginResult = await _Userapplication.Login(commend);
            if (loginResult.Message==nameof(LoginResultMessage.WrongUsername))
            {
                ModelState.AddModelError(commend.Code,LoginResultMessage.WrongUsername);
                return View("index");
            }
            else if (loginResult.Message == nameof(LoginResultMessage.WrongPassword))
            {
                ModelState.AddModelError(commend.Code, LoginResultMessage.WrongPassword);
                return View("index");
            }else if(loginResult.Message == nameof(LoginResultMessage.SuccessLogin))
            {
                return Redirect("/Admin/Home/Index");

            }
            return View();




        }


    }
}