using Microsoft.AspNetCore.Mvc;
using User.Application.Common;
using User.Application.Contract;
using User.Application.Services;

namespace Crmspecialcustomer.Controllers.Users
{
    [Area("Admin")]

    public class UsersController : Controller
    {
        private readonly IUserApplication _UserApplication;
        [BindProperty] public EditUserViewModel ?UserEditValue { get; set; }
        public List<UserViewModel> Users { get; set; }
        public UsersController(IUserApplication userApplication)
        {
            _UserApplication = userApplication;
        }

        public async Task<IActionResult> Index()
        {
            Users = await _UserApplication.GetAllInfo();

            return View(Users);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel commend)
        {
            if (!ModelState.IsValid) return View("create");
            
            
            var result = await _UserApplication.CreateUser(commend);
            if (result.Status!=UserStatus.CreateSuccess)
            {
                ModelState.AddModelError(nameof(result), result.Message);
                return View("create");
            }
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Edit(long UserId)
        {
            UserEditValue = await _UserApplication.GetValueForEdit(UserId);
            return View(UserEditValue);
        }
        public async Task<IActionResult> EditUser(EditUserViewModel commend)
        {

            var result = await _UserApplication.EditUser(commend);
            if (result.Status!= UserStatus.CreateSuccess)
            {
                UserEditValue = await _UserApplication.GetValueForEdit(commend.UserId);
                ModelState.AddModelError(nameof(result), result.Message);
                return View("Edit", UserEditValue);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeActive(long UserId)
        {
            await _UserApplication.DeActiveUser(UserId);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Active(long UserId)
        {
            await _UserApplication.ActiveUser(UserId);
            return RedirectToAction("Index");
        }

        //public  IActionResult Password(long UserId)
        //{
        //    return View(UserId);
        //}
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword commend)
        {
            //if (!ModelState.IsValid) return View();
            var result = await _UserApplication.ChangePassword(commend);
            if (!result)
            {
                ModelState.AddModelError(nameof(result), "خطایی رخ داده است!");
                return View("Password",commend.UserId);
            }
            return RedirectToAction("index");
           

        }
    }
}
