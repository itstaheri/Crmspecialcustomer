using Crmspecialcustomer.HostFrameworks.Pagination;
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

        public async Task<IActionResult> Index(int pageId = 1)
        {
            var material = await _materialApplication.GetAllMaterialsInfo();
            #region pagination 
            PaginationViewModel<MaterialViewModel> page = new PaginationViewModel<MaterialViewModel>();
            if (material.Count >= 9)
            {
                page.CurrentPage = pageId;
                page.PageCount = (int)Math.Ceiling(material.Count / (double)9);
                page.Models = material.OrderBy(x => x.CreationDate).Skip((pageId - 1) * 9).Take(9).ToList();

            }
            else
            {
                page.CurrentPage = pageId > 0 ? pageId : 1;
                page.PageCount = 1;
                page.Models = material;
            }
            #endregion

            return View(page);

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
        [HttpGet]
        public async Task<IActionResult> RemoveMaterial(long MaterialId)
        {
            await _materialApplication.Remove(MaterialId);
            return RedirectToAction("Index");
        }
    }
}
