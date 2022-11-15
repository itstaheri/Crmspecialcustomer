using Microsoft.AspNetCore.Mvc;
using User.Application.Services;

namespace Crmspecialcustomer.Areas.Admin.ViewComponents
{
    public class UserLogsViewComponent : ViewComponent
    {
        private readonly IUserApplication _userApplication;

        public UserLogsViewComponent(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = (await _userApplication.GetAllUsersLogInfo()).OrderByDescending(x => x.ActionDate).Take(8).ToList();
            return View(query);
        }
    }
}
