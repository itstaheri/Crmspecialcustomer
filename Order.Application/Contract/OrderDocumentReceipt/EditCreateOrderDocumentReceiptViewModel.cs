using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract.OrderDocumentReceipt
{
    public class EditCreateOrderDocumentReceiptViewModel : CreateOrderDocumentReceiptViewModel
    {
        public long OrderDocumentReceiptId { get; set; }
    }
}
