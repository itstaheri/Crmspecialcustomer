using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using User.Application.Contract.UserRole;
using User.Application.Services;

namespace Crmspecialcustomer.Areas.Admin.ViewComponents
{
    public class RoleListViewComponent : ViewComponent
    {
        private readonly IUserRoleApplication _UserRole;
        public List<UserRoleViewModel> RolesList { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public RoleListViewComponent(IUserRoleApplication userRole)
        {
            _UserRole = userRole;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Roles = (await _UserRole.GetAllRoles()).Select(x => new SelectListItem(x.RoleName, x.RoleId.ToString())).ToList();
            return View(Roles);
        }


    }
}
