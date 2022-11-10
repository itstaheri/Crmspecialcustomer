using Microsoft.AspNetCore.Mvc;
using Request.Application.Contract.Service;

namespace Crmspecialcustomer.Areas.Admin.Controllers.Request
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceApplication _serviceApplication;

        public ServiceController(IServiceApplication serviceApplication)
        {
            _serviceApplication = serviceApplication;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _serviceApplication.GetAllServiceInfo();
            return View(services);
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("index");
            }
            await _serviceApplication.CreateService(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditService(EditServiceViewModel model)
        {
            await _serviceApplication.EditService(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveService(long ServiceId)
        {
            await _serviceApplication.RemoveService(ServiceId);
            return RedirectToAction("Index");
        }


    }
}
