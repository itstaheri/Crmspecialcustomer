using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.OrderSupportAgg
{
    public interface IOrderSupportRepository : IGenericRepository<OrderSupportModel, OrderSupportModel>
    {
        Task Remove(long SupportId);
    }
}
