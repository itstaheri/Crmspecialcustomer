using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract.OrderSupport
{
    public interface IOrderSupportApplication 
    {
        Task CreateOrderSupport(CreateOrderSupportViewModel commend);
        Task EditOrderSupport(EditOrderSupportViewModel commend);
        Task<OrderSupportViewModel> GetOrderSupportInfoBy(long OrderSupportId);
        Task<List<OrderSupportViewModel>> GetOrderSupportsBy(long OrderId);
        Task RemoveOrderSupport(long OrderSupportId);

    }
}
