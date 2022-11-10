using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.OrderDocumentReceiptAgg
{
    public interface IOrderDocumentReceiptRepository : IGenericRepository<OrderDocumentReceiptModel, OrderDocumentReceiptModel>
    {
        Task Remove(long id);
    }
}
