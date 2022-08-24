using Area.Application.Contract.City;
using Microsoft.AspNetCore.Mvc;

namespace Crmspecialcustomer.Areas.Admin.Controllers.Area
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly ICityApplication _cityApplication;
        public CityController(ICityApplication cityApplication)
        {
          
            _cityApplication = cityApplication;
        }
        public async Task<IActionResult> Index(long Id)
        {
            ViewData["stateid"] = Id;
            var cities = await _cityApplication.GetCitiesBy(Id);
            return View(cities);
        }
        public async Task<ActionResult> CreateCity(CreateCityViewModel model)
        {
            await _cityApplication.CreateCity(model);
            return RedirectToAction("Index",new {Id = model.StateId });
        }
        public async Task<IActionResult> RemoveCity(long cityId,long StateId)
        {
            await _cityApplication.RemoveCity(cityId);
            return RedirectToAction("Index", new { Id = StateId });
        }
        public async Task<IActionResult> EditCity(EditCityViewModel model)
        {
            await _cityApplication.Edit(model);
            return RedirectToAction("Index", new { Id = model.StateId });

        }
    }
}
