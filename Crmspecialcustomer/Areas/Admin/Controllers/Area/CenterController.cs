using Area.Application.Contract.Center;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crmspecialcustomer.Areas.Admin.Controllers.Area
{
    [Area("Admin")]
    [Authorize("AdminAccess")]
    public class CenterController : Controller
    {
        private readonly ICenterApplication _centerApplication;

        public CenterController(ICenterApplication centerApplication)
        {
            _centerApplication = centerApplication;
        }

        public async Task<IActionResult> Index(long cityId)
        {
            ViewData["cityId"] = cityId;
            var centers = await _centerApplication.GetAllCityCenters(cityId);
            return View(centers);
        }
        public async Task<IActionResult> CreateCenter(CreateCenterViewModel commend)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(commend.CenterName, "خطا!");
                return View(commend);
            }
            await _centerApplication.CreateCenter(commend);
            return RedirectToAction("Index", new { cityId = commend.CityId });

        }
        public async Task<IActionResult> RemoveCenter(long centerId,long cityId)
        {
            await _centerApplication.RemoveCenter(centerId);
            return RedirectToAction("Index", new { cityId = cityId });

        }
        public async Task<IActionResult> EditCenter(EditCenterViewModel commend)
        {
            await _centerApplication.Edit(commend);
            return RedirectToAction("Index",new { cityId = commend.CityId });

        }

    }
}
