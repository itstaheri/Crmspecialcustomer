using Frameworkes;
using Order.Domain.OrderDocumentReceiptAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.OrderAgg
{
    public interface IOrderRepository : IGenericRepository<OrderModel,OrderModel>
    {
        Task Remove(long OrderId);
        Task AddToOrderDetail(OrderDetailModel commend);
        Task<List<OrderDetailModel>> GetOrderDetailsBy(long OrderId);
        Task<OrderDetailModel> GetOrderDetailInfoBy(long OrderDetailId);
        Task<(double,bool)> CheckPaidOrder(long OrderId);
    }
}
