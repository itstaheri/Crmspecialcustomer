using Area.Application.Common;
using Area.Application.Contract.State;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crmspecialcustomer.Areas.Admin.Controllers.Area
{
    [Area("Admin")]
    [Authorize("AdminAccess")]

    public class StateController : Controller
    {
        private readonly IStateApplication _stateApplication;
       // public List<StateViewModel> States { get; set; }
        public StateController(IStateApplication stateApplication)
        {
            _stateApplication = stateApplication;
            
        }

        public async Task<IActionResult> Index()
        {
            var states = await _stateApplication.GetAllStates();
            return View(states);
        }
        public async Task<IActionResult> CreateState(CreateStateViewModel commend)
        {
          
           var result = await _stateApplication.CreateState(commend);
            if (result.Status != Status.CreateSuccess)
            {
                ModelState.AddModelError(commend.StateName,result.Message);
                
            }
            return RedirectToAction("index");
        }
        public async Task<IActionResult> RemoveState(long stateId)
        {
            await _stateApplication.RemoveState(stateId);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditState(EditStateViewModel commend)
        {
           var result = await _stateApplication.Edit(commend);
            if (result.Status!=Status.CreateSuccess)
            {
                return View(commend);
            }
            
            return RedirectToAction("Index");

        }
    }
}
