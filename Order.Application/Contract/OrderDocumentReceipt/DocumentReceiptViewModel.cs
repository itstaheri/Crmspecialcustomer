using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contract.OrderDocumentReceipt
{
    public class DocumentReceiptViewModel
    {
        public long DocumentReceiptId { get; set; }
        public long OrderId { get; set; }
        public string Description { get; set; }
        public double AmountPaid { get; set; }
        public string CreationDate { get; set; }
        public string DocumentReceiptPhoto { get; set; }
    }
}
