using Microsoft.AspNetCore.Http;
using Order.Application.Contract.OrderDetail;
using Order.Application.Contract.OrderDocumentReceipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract
{
    public interface IOrderApplication
    {
        Task<long> ActionOrder(CreateOrderViewModel commend);
        Task AddOrderDetail(CreateOrderDetailViewModel commend);
        Task<List<OrderViewModel>> GetAllOrdersInfo(SearchOrderViewModel commend);
        Task RemoveOrder(long OrderId);
        Task PaidOrder(long OrderId);
        Task UnPaidOrder(long OrderId);
        Task<List<OrderDetailViewModel>> GetOrderDetailsBy(long OrderId);
        Task EditOrderDetail(EditOrderDetailViewModel commend);
        Task<OrderViewModel> GetOrderInfoBy(long OrderId);

    }
}
