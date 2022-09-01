using Microsoft.AspNetCore.Mvc;
using Service.Application.Contract.Material;

namespace Crmspecialcustomer.Areas.Admin.Controllers.Service
{
    [Area("Admin")]
    public class MaterialController : Controller
    {
        private readonly IMaterialApplication _materialApplication;

        public MaterialController(IMaterialApplication materialApplication)
        {
            _materialApplication = materialApplication;
        }

        public async Task<IActionResult> Index()
        {
            var material = await _materialApplication.GetAllMaterialsInfo();
            return View(material);

        }
        //create index
        public IActionResult Create()
        {
            return View();
        }
        //create Action
        [HttpPost]
        public async Task<IActionResult> CreateMaterial(CreateMaterialViewModel model)
        {
            await _materialApplication.CreateMaterial(model);
            return RedirectToAction("Index");
        }
        //edit Action
        [HttpPost]
        public async Task<IActionResult> EditMaterial(EditMaterialViewModel model)
        {
            await _materialApplication.EditMaterial(model);
            return RedirectToAction("Index");
        }
        //remove Action
        [HttpPost]
        public async Task<IActionResult> RemoveMaterial(long MaterialId)
        {
            await _materialApplication.Remove(MaterialId);
            return RedirectToAction("Index");
        }
    }
}
