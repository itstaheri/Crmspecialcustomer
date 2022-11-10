using Microsoft.AspNetCore.Mvc;
using Order.Application.Contract;
using Order.Domain.OrderAgg;

namespace Crmspecialcustomer.Areas.Admin.ViewComponents
{
    public class OrderDetailsViewComponent : ViewComponent
    {
        private readonly IOrderApplication _orderApplication;

        public OrderDetailsViewComponent(IOrderApplication orderApplication)
        {
            _orderApplication = orderApplication;
        }

        public async Task<IViewComponentResult> InvokeAsync(long OrderId)
        {
            var orderDetails = (await _orderApplication.GetOrderDetailsBy(OrderId));
            return View(orderDetails);
        }
    }
}
