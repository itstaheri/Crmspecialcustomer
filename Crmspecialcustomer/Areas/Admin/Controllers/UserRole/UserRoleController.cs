using Microsoft.AspNetCore.Mvc;
using User.Application.Services;

namespace Crmspecialcustomer.Areas.Admin.Controllers.UserRole
{
    [Area("Admin")]

    public class UserRoleController : Controller
    {
        private readonly IUserRoleApplication _UserRoleApplication;

        public UserRoleController(IUserRoleApplication userRoleApplication)
        {
            _UserRoleApplication = userRoleApplication;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _UserRoleApplication.GetAllRoles();
            return View(roles);
        }
        public async Task<RedirectToActionResult> Permission(List<string> permissions,long RoleId)
        {
            await _UserRoleApplication.ActionPermissions(permissions, RoleId);
            return RedirectToAction("Index");  
        }
    }
}
