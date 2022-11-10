using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract.OrderDocumentReceipt
{
    public class CreateOrderDocumentReceiptViewModel
    {
        public long OrderId { get; set; }
        public string Description { get; set; }
        public double AmountPaid { get; set; }
        public IFormFile DocumentReceiptPhoto { get; set; }
    }
}
