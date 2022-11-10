using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract.OrderDocumentReceipt
{
    public interface IOrderDocumentReceiptsApplication
    {
        Task CreateReceipt(CreateOrderDocumentReceiptViewModel commend);
        Task EditReceipt(EditCreateOrderDocumentReceiptViewModel commend);
        Task<List<DocumentReceiptViewModel>> GetReceiptsBy(long OrderId);
        Task<DocumentReceiptViewModel> GetReceiptInfoBy(long DocumentReceiptId);
        Task RemoveReceipt(long DocumentReceiptId);
    }
}
