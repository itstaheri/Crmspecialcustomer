using Area.Application.Contract.Center;
using Area.Application.Contract.City;
using Area.Application.Contract.State;
using Crmspecialcustomer.HostFrameworks.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Request.Application.Contract.Request;
using Request.Application.Contract.Service;

namespace Crmspecialcustomer.Areas.Admin.Controllers.Request
{
    [Area("Admin")]
    [Authorize("RequestCreatorAccess")]
    public class RequestController : Controller
    {
        private readonly IRequestApplication _requestApplication;
        private readonly IServiceApplication _serviceApplication;
        private readonly IStateApplication _stateApplication;
        private readonly ICenterApplication _centerApplication;

        public RequestController(IRequestApplication requestApplication, IServiceApplication serviceApplication, 
            IStateApplication stateApplication, ICenterApplication centerApplication)
        {
            _requestApplication = requestApplication;
            _serviceApplication = serviceApplication;
            _stateApplication = stateApplication;
            _centerApplication = centerApplication;
        }

        public async Task<IActionResult> Index(RequestSearchViewModel model)
        {
            var requests = await _requestApplication.GetAllRequestInfo(model);
            #region pagination 
            PaginationViewModel<RequestViewModel> page = new PaginationViewModel<RequestViewModel>();
            if (requests.Count >= 9)
            {
                page.CurrentPage = model.pageId;
                page.PageCount = (int)Math.Ceiling(requests.Count / (double)50);
                page.Models = requests.OrderBy(x => x.CreationDate).Skip((model.pageId - 1) * 50).Take(50).ToList();

            }
            else
            {
                page.CurrentPage = model.pageId > 0 ? model.pageId : 1;
                page.PageCount = 1;
                page.Models = requests;
            }
            #endregion
            return View(page);
        }
        public async  Task<IActionResult> Create()
        {
            ViewBag.States = (await _stateApplication.GetAllStates()).Select(x=>new SelectListItem(x.StateName,x.StateId.ToString()));
            ViewBag.Services = (await _serviceApplication.GetAllServiceInfo()).Select(x => new SelectListItem(x.ServiceName, x.ServiceId.ToString()));
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRequest(CreateRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            await _requestApplication.CreateRequest(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetCities(long StateId)
        {
            var cities = await _stateApplication.GetStateCities(StateId);
            return new JsonResult(cities);
        }
        public async Task<IActionResult> GetCenters(long CityId)
        {
            var centers = await _centerApplication.GetAllCityCenters(CityId);
            return new JsonResult(centers);
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmRequest(long RequestId)
        {
            await _requestApplication.ConfirmRequest(RequestId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeConfirmRequest(long RequestId)
        {
            await _requestApplication.DeConfirmRequest(RequestId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> RemoveRequest(long RequestId)
        {
            await _requestApplication.RemoveRequest(RequestId);
            return RedirectToAction("Index");
        }
        public  async Task<IActionResult> Edit(long RequestId)
        {
            //get stateId of Request by RequestId for get cities of a state
            var stateId = await _requestApplication.GetStateId(RequestId);
          
            ViewBag.States = (await _stateApplication.GetAllStates()).Select(x => new SelectListItem(x.StateName, x.StateId.ToString()));
            ViewBag.Cities = (await _stateApplication.GetStateCities(stateId)).Select(x => new SelectListItem(x.CityName, x.CityId.ToString()));
            ViewBag.Services = (await _serviceApplication.GetAllServiceInfo()).Select(x => new SelectListItem(x.ServiceName, x.ServiceId.ToString()));


            var request = await _requestApplication.GetValueForEdit(RequestId);
            return View(request);
        }
        [HttpPost]
        public async Task<IActionResult> EditRequest(EditRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit",new { RequestId  = model.RequestId});
            }
            await _requestApplication.EditRequest(model);
            return RedirectToAction("Index");

        }
    }
 

}
