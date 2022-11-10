using Crmspecialcustomer.HostFrameworks.Pagination;
using Crmspecialcustomer.HostFrameworks.Permission;
using Frameworkes.OrderOutputExcel;
using Frameworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Order.Application.Contract;
using Order.Application.Contract.OrderDetail;
using Order.Application.Contract.OrderDocumentReceipt;
using Request.Application.Contract.Request;
using Service.Application.Contract.Material;
using System.Security.Claims;
using User.Application.Common;

namespace Crmspecialcustomer.Areas.Admin.Controllers.Order
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderApplication _orderApplication;
        private readonly IMaterialApplication _materialApplication;
        private readonly IRequestApplication _requestApplication;
        private readonly IOrderDocumentReceiptsApplication _orderDocumentReceiptsApplication;

        public OrderController(IOrderApplication orderApplication, IMaterialApplication materialApplication, IRequestApplication requestApplication, IOrderDocumentReceiptsApplication orderDocumentReceiptsApplication)
        {
            _orderApplication = orderApplication;
            _materialApplication = materialApplication;
            _requestApplication = requestApplication;
            _orderDocumentReceiptsApplication = orderDocumentReceiptsApplication;
        }

        public async Task<IActionResult> Index(SearchOrderViewModel model)
        {
            var orders = await _orderApplication.GetAllOrdersInfo(model);
            #region pagination 
            PaginationViewModel<OrderViewModel> page = new PaginationViewModel<OrderViewModel>();
            if (orders.Count >= 9)
            {
                page.CurrentPage = model.PageId;
                page.PageCount = (int)Math.Ceiling(orders.Count / (double)9);
                page.Models = orders.OrderBy(x => x.CreationDate).Skip((model.PageId - 1) * 9).Take(9).ToList();

            }
            else
            {
                page.CurrentPage = model.PageId > 0 ? model.PageId : 1;
                page.PageCount = 1;
                page.Models = orders;
            }
            #endregion
            return View(page);
        }
        //select material part
        public async Task<IActionResult> Select()
        {

            //select all requests Isconfirmed
            var requests = (await _requestApplication.GetAllRequestInfo(null)).Where(x => x.IsConfirm == true);

            ViewBag.Requests = requests.Select(x => new SelectListItem(x.CompanyName, x.RequestId.ToString()));
            return View();
        }
        public async Task<IActionResult> CreateOrder(long RequestId)
        {
            var orderId = await _orderApplication.ActionOrder(new CreateOrderViewModel { RequestId = RequestId });
            return RedirectToAction("OrderDetail", new { OrderId = orderId });
        }
        public async Task<IActionResult> OrderDetail(long OrderId)
        {
            ViewBag.OrderId = OrderId;
            ViewBag.Materials = (await _materialApplication.GetAllServiceNameandDate())
                .Select(x => new SelectListItem(x.ServiceAndDate, x.MaterialId.ToString()));
            return View();
        }
        public async Task<IActionResult> AddOrderDetail(CreateOrderDetailViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("OrderDetail", new {OrderId= model.OrderId});
            //    //return View(model);
            //}
            //if (model.CoreCount < model.CoreCountSide)
            //{
            //    ModelState.AddModelError(nameof(model.CoreCountSide),errorMessage: "تعداد core طرف سهم قرارداد بیشتر از مقدار موجود وارد شده است!");
            //    return View("OrderDetail", new { OrderId = model.OrderId });

            //}
            await _orderApplication.AddOrderDetail(model);
            return RedirectToAction("OrderDetail", new { OrderId = model.OrderId });
        }
        public async Task<IActionResult> GetMaterialInfo(long MaterialId)
        {
            var material = await _materialApplication.GetMaterialInfoBy(MaterialId);
            return new JsonResult(material);
        }
        public async Task<IActionResult> RemoveOrder(long OrderId)
        {
            await _orderApplication.RemoveOrder(OrderId);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditOrderDetail(EditOrderDetailViewModel model)
        {
            await _orderApplication.EditOrderDetail(model);
            return RedirectToAction("OrderDetail", new { OrderId = model.OrderId });
        }
       
        public async Task<IActionResult> Excel(long OrderId)
        {
            var orderDetails = await _orderApplication.GetOrderDetailsBy(OrderId);


            OrderExportExcel excel = new OrderExportExcel();
            var details = orderDetails.Select(x => new OrderDetailOutput
            {
                Description = x.Description,
                ManualDiscount = x.ManualDiscount,
                CoreCount = x.CoreCount,
                CoreCountSide = x.CoreCountSide,
                CustomerShare = x.CustomerShare,
                MaterialPrice = x.MaterialPrice,
                PayAmount = x.PayAmount,
                SalaryPrice = x.SalaryPrice,
                TotalPrice = x.TotalPrice,
                ServiceName = x.ServiceName,
                UnitPrice = x.UnitPrice,
                Value = x.Value,
                UnitOfMaterial = x.UnitOfMaterial,
                CreationDate = x.CreationDate,
                DiscountRate = x.DiscountRate,

            }).ToList();
            var content = await excel.GenerateExcel(details);
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "");

        }
        public async Task<IActionResult> DocumentReceiptIndex(long OrderId)
        {
            ViewBag.OrderId = OrderId;
            var documentReceipt = await _orderDocumentReceiptsApplication.GetReceiptsBy(OrderId);
            return View(documentReceipt);
        }
     
        public async Task<IActionResult> AddDocumentReceipt(CreateOrderDocumentReceiptViewModel model)
        {
            await _orderDocumentReceiptsApplication.CreateReceipt(model);
            return RedirectToAction("DocumentReceiptIndex", new { OrderId = model.OrderId });
        }
        public async Task<IActionResult> EditDocumentReceipt(EditCreateOrderDocumentReceiptViewModel model)
        {
            await _orderDocumentReceiptsApplication.EditReceipt(model);
            return RedirectToAction("DocumentReceiptIndex", new { OrderId = model.OrderId });
        } 
        public async Task<IActionResult> DocumentReceiptRemove(long DocumentReceiptId,long OrderId)
        {
            await _orderDocumentReceiptsApplication.RemoveReceipt(DocumentReceiptId);
            return RedirectToAction("DocumentReceiptIndex", new { OrderId = OrderId });
        }
        public async Task<IActionResult> pdf(List<OrderViewModel> model)
        {
            return View();
        }
       
    }
}
